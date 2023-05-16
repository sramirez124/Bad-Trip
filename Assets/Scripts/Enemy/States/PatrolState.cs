using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{

    public int waypointIndex;
    public float waitTimer;

    public override void Enter()
    {
        //throw new System.NotImplementedException();
    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public void PatrolCycle()
    {
        // implemenet our patrol logics
        if (enemy.Agent.remainingDistance < 0.02f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > 3)
            {
                if (waypointIndex < enemy.path.waypoints.Count - 1)
                    waypointIndex++;
                else
                    waypointIndex = 0;
                    enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                    waitTimer = 0;
            }
            
        }
    }
}
