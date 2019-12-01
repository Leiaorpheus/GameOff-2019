using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 5;

    // properties for jumping
    [SerializeField]
    bool isGrounded;
    public Transform groundCheck;
    public float checkX, checkY;
    public LayerMask whatIsGround;
    public LayerMask whatIsBound;

    [SerializeField]
    AudioSource jumpAudio;

    private Rigidbody2D rb2d;

    [SerializeField]
    GameObject jumpCloud;

    private void OnEnable()
    {
        isGrounded = checkLayer(whatIsGround);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        isGrounded = checkLayer(whatIsGround) || checkLayer(whatIsBound);
        GetComponent<Animator>().SetBool("Landed", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            Instantiate(jumpCloud, groundCheck.position, Quaternion.identity);
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<PlaySound>().play(jumpAudio);
        }
    }

    bool checkLayer(LayerMask item)
    {
        Vector2 check = new Vector2(checkX, checkY);
        if (Physics2D.OverlapBox(groundCheck.position, check, 0, item))
            return true;

        else
            return false;

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(groundCheck.position, new Vector3(checkX, checkY, 0));

    }


   
}
