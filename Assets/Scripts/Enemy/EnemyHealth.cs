using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //? Script needs to give health to each body part of the enemy
    //? Script needs to destroy the body part its attached to
    //? Script needs to turn off part of the AI associated with that part
    /*
        1.Destorying the ball turns off the enemy nav mesh agent, which means they
        can't move and fall to the ground
        2. Destroying the arm turns off the enemies ability to shoot
        3. Destorying the eye turns off the enemies ability to find you and cause
        it to run around randomly and will shoot randomly
    */

    [SerializeField]
    public float health = 10f;
    private bool isBallGone;
    private bool isEyeGone;
    private bool isArmGone;

    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount, string bodyPartName)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Body part name sent was " + bodyPartName);
            BodyCheck(bodyPartName);
        }
    }

    public void BodyCheck(string bodyPartName)
    {
        switch (bodyPartName)
        {
            case "MrCubesBall":
                enemy.lostLegs = true;
                //enemy.Agent.enabled = false;
                break;
            case "MainEye":
                enemy.lostEye = true;
                break;
            case "RightGun":
                enemy.lostArms = true;
                break;
            default:
                break;
        }
    }
}
