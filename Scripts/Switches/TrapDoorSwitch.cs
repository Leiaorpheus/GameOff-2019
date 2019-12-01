using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorSwitch : DoorSwitch
{
    [SerializeField]
    GameObject trapDoor;
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // turn off switch
    protected new void OnTriggerEnter2D(Collider2D collision)
    {

        base.OnTriggerEnter2D(collision);

    }

    // flipping behaviour
    public override void flip()
    {
        base.flip();
        trapDoor.GetComponent<TrapDoor>().isSwitchedOff = true;
    }
}
