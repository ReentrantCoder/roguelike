using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    public Stats ResourceStats;

    public AudioClip[] CollectSounds;

    public Sprite Image;

    void Start()
    {
        Image = GetComponent<SpriteRenderer>().sprite;
    }

    public Stats Collect()
    {
        //Call the RandomizeSfx function of SoundManager and pass in two eating sounds to choose between to play the eating sound effect.
        SoundManager.instance.RandomizeSfx(CollectSounds);

        gameObject.SetActive(false);
        return ResourceStats;
    }
}