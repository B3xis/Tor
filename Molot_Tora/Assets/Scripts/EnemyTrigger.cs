using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    public GameObject enemy1, enemy2, enemy3, bullet;

  
    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.name);
        if(hit.tag == "Player")
        {
            Instantiate(bullet, enemy1.transform.position, transform.rotation);
            Instantiate(bullet, enemy2.transform.position, transform.rotation);
            Instantiate(bullet, enemy3.transform.position, transform.rotation);
        }
        
    }
    
}
