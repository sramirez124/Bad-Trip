using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public float shotTimer;

    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer() || enemy.lostArms == false) // player can be seen.
        {
            //lock the lose player timer and increment the move and shot timers.
            Timers();

            // If Robot loses eye it will not look at the player.
            CanLookAtPlayerCheck();

            //if shot time > fireRate
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            //move the enemy to a random position after a random time.
            MoveToRandomPosition();
            
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                //Change to the search state;
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {

    }

    public void Shoot()
    {
        //! store reference to the gun barrel
        Transform gunbarrel = enemy.gunBarrel;

        //! instantiate a new bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);

        //! calculate the direction to the player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;

        //! add force rigidbody of the bullet
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40; //! make this a variable you can change
        //Debug.Log("Shoot");
        shotTimer = 0;
    }

    public void Timers()
    {
        losePlayerTimer = 0;
        moveTimer += Time.deltaTime;
        shotTimer += Time.deltaTime;
    }

    public void CanLookAtPlayerCheck()
    {
        if (enemy.CanSeePlayer())
        {
            enemy.transform.LookAt(enemy.Player.transform);
        }
    }

    public void MoveToRandomPosition()
    {
        if (moveTimer > Random.Range(3, 7) || enemy.lostEye == true)
        {
            enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
            moveTimer = 0;
        }
    }

    public void Start()
    {

    }

    public void Update()
    {
        
    }
}
