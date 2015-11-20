using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour, ICollectible
{
    private Stats stats;

    public AudioClip[] CollectSounds;

    public int Turns;

    // Use this for initialization
    void Start()
    {
        stats = new Stats();
        stats.Turns = Turns;
    }

    public Stats Collect()
    {
        //Call the RandomizeSfx function of SoundManager and pass in two eating sounds to choose between to play the eating sound effect.
        SoundManager.instance.RandomizeSfx(CollectSounds);

        gameObject.SetActive(false);
        return stats;
    }
}