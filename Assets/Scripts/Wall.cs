using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour, IAttackable
{
    public AudioClip[] ChopSounds;
    public AudioClip chopSound1;				//1 of 2 audio clips that play when the wall is attacked by the player.
    public AudioClip chopSound2;				//2 of 2 audio clips that play when the wall is attacked by the player.
    public Sprite dmgSprite;					//Alternate sprite to display after Wall has been attacked by player.
    public Stats stats;

    private SpriteRenderer spriteRenderer;		//Store a component reference to the attached SpriteRenderer.


    void Awake()
    {
        //Get a component reference to the SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public int Attack(int damage)
    {
        //Call the RandomizeSfx function of SoundManager to play one of two chop sounds.
        SoundManager.instance.RandomizeSfx(chopSound1, chopSound2);

        //Set spriteRenderer to the damaged wall sprite.
        spriteRenderer.sprite = dmgSprite;

        //Subtract loss from hit point total.
        damage -= stats.DamageReduction;
        damage = Mathf.Max(0, damage);
        stats.HP -= damage;

        //If hit points are less than or equal to zero:
        if (stats.HP <= 0)
            //Disable the gameObject.
            gameObject.SetActive(false);

        return damage;
    }

    public string GetName()
    {
        return "Wall";
    }
}