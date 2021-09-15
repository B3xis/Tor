using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    public GameObject enemy, bullet;

  
    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.name);
        if(hit.tag == "Player")
        {
            Instantiate(bullet, enemy.transform.position + Vector3.up, transform.rotation);
        }
        
    }
    
}
