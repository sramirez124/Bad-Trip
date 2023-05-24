using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Path path;

    [Header("Sight Values")]
    private float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    //! These bools allow the Enemys body parts to shut down when lost.
    [Header("Script Bools")]
    public bool lostEye;
    public bool lostLegs;
    public bool lostArms;

    [Header("Weapon Values")]
    public Transform gunBarrel;
    
    [Range(0.1f, 10f)]
    public float fireRate;


    [SerializeField] // just for debugging purposes
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        BodyCheck();
    }

    public bool CanSeePlayer()
    {
        if (player != null && lostEye == false)
        {
            // is the player close enough to be seen?
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();

                    if (Physics.Raycast(ray,out hitInfo, sightDistance))
                    {
                        Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                    
                }
            }
        }
        return false;
    }

    public void BodyCheck()
    {
        bool rbCheck = false;
        if(lostLegs == true && rbCheck == false)
        {
            Rigidbody rb = this.gameObject.AddComponent<Rigidbody>() as Rigidbody;
            rb.useGravity = true;
            rbCheck = true;
        }
    }
}
