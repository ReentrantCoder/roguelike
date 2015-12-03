using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour, ICollectible
{
    public Stats ResourceStats;

    public AudioClip[] CollectSounds;

    // Use this for initialization
    void Start()
    {
        ResourceStats = new Stats();
    }

    public Stats Collect()
    {
        //Call the RandomizeSfx function of SoundManager and pass in two eating sounds to choose between to play the eating sound effect.
        SoundManager.instance.RandomizeSfx(CollectSounds);

        gameObject.SetActive(false);
        return ResourceStats;
    }
}