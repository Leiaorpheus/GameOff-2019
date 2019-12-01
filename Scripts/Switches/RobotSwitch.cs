using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSwitch : DoorSwitch
{
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject turret;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // turn off switch
    protected new void OnTriggerEnter2D(Collider2D collision) {


        base.OnTriggerEnter2D(collision);


    }

    // flipping behaviour
    public override void flip() {
        base.flip();
        laser.SetActive(false);
        turret.GetComponent<Turret>().isDead = true;
        turret.GetComponent<Animator>().SetTrigger("Dead");
        turret.layer = LayerMask.NameToLayer("Ground");
    }

    
}
