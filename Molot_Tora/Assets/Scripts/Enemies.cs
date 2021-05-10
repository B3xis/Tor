using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject obj;
    Player player ;
    private void OnTriggerEnter(Collider hit)
    {
        player = obj.GetComponent<Player>();
        if (hit.tag == "Player")
        {

         // Debug.Log("enem");
         // Debug.Log(Player.bricksNum);
         // Debug.Log(Player.clock);

            player.score += 20;
            Destroy(gameObject);
        }
    }
}
