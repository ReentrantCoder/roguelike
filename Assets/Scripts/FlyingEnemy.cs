using UnityEngine;
using System.Collections;

public class FlyingEnemy : Enemy
{
    public override void TakeTurn()
    {
        //increment the turn number
        turnNumber++;

        //Declare variables for X and Y axis move directions, these range from -1 to 1.
        //These values allow us to choose between the cardinal directions: up, down, left and right.
        int xDir = 0;
        int yDir = 0;

        //set the direction of movement
        if (Mathf.Abs(target.position.y - transform.position.y) > Mathf.Epsilon)
        {
            yDir = (target.position.y > transform.position.y) ? 1 : -1;
        }
        if (Mathf.Abs(target.position.x - transform.position.x) > Mathf.Epsilon)
        {
            xDir = (target.position.x > transform.position.x) ? 1 : -1;
        }

        //Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
        AttemptMove<Player>(xDir, yDir);
    }
}