using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function is where we will design our interaction using code
    protected override void Interact()
    {
        //Debug.Log("You have interacted with the keypad to open the door");
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        //Debug.Log("Door open is" + doorOpen);

    }
}
