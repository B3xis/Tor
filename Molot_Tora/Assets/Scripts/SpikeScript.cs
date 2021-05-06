using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider hit)
    {
        Application.Quit();
    }
}
