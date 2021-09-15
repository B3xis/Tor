using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDisassembledBricks : MonoBehaviour
{
  

    private void Start ()
    {
       BlowUp();
    }

    void BlowUp()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.2f, 1f) * 35, ForceMode.VelocityChange);
    }
}
