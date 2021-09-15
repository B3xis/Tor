using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject assembledModel;
    public GameObject disassembledModel;


    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            disassembledModel.SetActive(true);
            assembledModel.SetActive(false);
        }
    }
}
