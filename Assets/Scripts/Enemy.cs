using UnityEngine;
using System;
using System.Collections;

/// <summary>
///Enemy inherits from MovingObject, our base class for objects that can move
/// </summary>
public abstract class Enemy : MovingObject, IAttackable, IComparable
{
    public Stats EnemyStats; 							//The amount of food points to subtract from the player when attacking.
    public AudioClip[] AttackSounds;					//array of audio clips to play when attacking the player.
    public int MoveFrequency;                           //enemy moves once every x moves
    public int PowerLevel;                              //power level of enemy, used by EnemyFactory

    private Animator animator;							//Variable of type Animator to store a reference to the enemy's Animator component.
    protected Transform target;							//Transform to attempt to move toward each turn.
    protected int turnNumber;                           //Current turn number referenced by lastMoved
    private int lastMoved;								//Turn number of the last move to determine whether or not enemy should skip a turn or move this turn.


    //Start overrides the virtual Start function of the base class.
    protected override void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.
        GameManager.instance.AddEnemyToList(this);

        //Get and store a reference to the attached Animator component.
        animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Call the start function of our base class MovingObject.
        base.Start();
    }


    //Override the AttemptMove function of MovingObject to include functionality needed for Enemy to skip turns.
    //See comments in MovingObject for more on how base AttemptMove function works.
    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        //Check if we are allowed to move based on our speed
        if ((lastMoved + MoveFrequency) > turnNumber)
        {
            return;
        }

        //Call the AttemptMove function from MovingObject.
        base.AttemptMove<T>(xDir, yDir);

        //Now that Enemy has moved, set skipMove to true to skip next move.
        lastMoved = turnNumber;
    }


    /// <summary>
    /// TakeTurn is called by the GameManger each turn to tell each Enemy to try to move towards the player.
    /// </summary>
    public abstract void TakeTurn();


    /// <summary>
    /// OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
    /// </summary>
    /// <typeparam name="T">Type of the component we expect to encounter</typeparam>
    /// <param name="component">Component we expect to encounter. Usually Player</param>
    protected override void OnCantMove<T>(T component)
    {
        //Declare hitPlayer and set it to equal the encountered component.
        Player hitPlayer = component as Player;

        //Call the LoseFood function of hitPlayer passing it playerDamage, the amount of foodpoints to be subtracted.
        hitPlayer.Attack(EnemyStats.Damage);

        //Set the attack trigger of animator to trigger Enemy attack animation.
        animator.SetTrigger("enemyAttack");

        //Call the RandomizeSfx function of SoundManager passing in the two audio clips to choose randomly between.
        SoundManager.instance.RandomizeSfx(AttackSounds);
    }

    public void Attack(int damage)
    {

    }

    /// <summary>
    /// Compares to another Enemy by PowerLevel
    /// </summary>
    /// <param name="other">Enemy to compare to</param>
    public int CompareTo(object other)
    {
        return PowerLevel - ((Enemy)other).PowerLevel;
    }
}