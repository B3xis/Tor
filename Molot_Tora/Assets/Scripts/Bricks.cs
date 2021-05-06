using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bricks : MonoBehaviour
{
    public GameObject wall;
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = false;  
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.2f, 1f) * 10, ForceMode.VelocityChange);
        //Vector3 exppoint = collision.gameObject.transform.position + new Vector3(0, -1, -122.72f);
        //Debug.Log(exppoint);
        //GetComponent<Rigidbody>().AddExplosionForce(1000, exppoint, 10, 10, ForceMode.VelocityChange);
        Destroy(gameObject, 3);
    }
}
