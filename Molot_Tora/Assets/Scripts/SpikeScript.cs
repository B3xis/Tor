using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public GameObject obj;
    Player player;
    
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            player = obj.GetComponent<Player>();
            
              //Debug.Log("spike");
              //Debug.Log(Player.bricksNum);
              //Debug.Log(Player.clock);
            
            player.bricksNum--;
            player.clock--;
            player.hummerBricks[player.clock].gameObject.SetActive(false);
            player.bricksNum--;
            player.clock--;
            player.hummerBricks[player.clock].gameObject.SetActive(false);
            // Application.Quit();
        }
    }
}
