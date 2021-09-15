using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bricks : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-8f, -1f), Random.Range(2f, 4f), Random.Range(9f,25f)), ForceMode.VelocityChange);
        GetComponent<Rigidbody>().useGravity = true;
        Destroy(gameObject, 4f);

    }
}
