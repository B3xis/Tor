using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
