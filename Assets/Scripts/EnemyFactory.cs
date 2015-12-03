using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour
{
    public List<Enemy> Enemies;

    // Use this for initialization
    void Start()
    {
        Enemies.Sort();
        foreach (Enemy e in Enemies)
        {
            Debug.Log(e.name + " power level " + e.PowerLevel);
        }
    }
    
    /// <summary>
    /// Instantiates an instance of an Enemy prefab based on power level
    /// </summary>
    /// <param name="powerLevel">maximum power level to allow</param>
    /// <returns>Instantiated Enemy GameObject</returns>
    public Enemy CreateEnemy(int powerLevel)
    {
        int max = Enemies.FindIndex(x => x.PowerLevel > powerLevel);
        Debug.Log("Index of enemy found: " + max);

        //FindIndex returns -1 if a result isn't found, so make sure we have the highest if that is the case
        if (max < 0)
        {
            max = Enemies.Count;
        }
        Debug.Log("Index of biggest enemy to spawn: " + (max - 1));

        return Object.Instantiate<Enemy>(Enemies[Random.Range(0, max)]);
    }
}