using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    [SerializeField]
    GameObject jumpEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(jumpEffect, transform.position, jumpEffect.transform.rotation);
    }
}
