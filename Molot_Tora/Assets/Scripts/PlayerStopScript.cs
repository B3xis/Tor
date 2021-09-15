using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopScript : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player.speed = 0f;
    }
}
