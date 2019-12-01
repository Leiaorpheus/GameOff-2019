using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 0.5f);
    }


}
