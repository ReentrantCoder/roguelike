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

    // Update is called once per frame
    void Update()
    {

    }
}