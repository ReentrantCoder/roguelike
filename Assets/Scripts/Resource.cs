using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour, ICollectible
{
    private Stats stats;

    public readonly int Turns;

    // Use this for initialization
    void Start()
    {
        stats = new Stats();
        stats.Turns = Turns;
    }

    public Stats Collect()
    {
        gameObject.SetActive(false);
        return stats;
    }
}