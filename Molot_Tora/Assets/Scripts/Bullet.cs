using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    float speed = 0.3f;
   
    // Update is called once per frame
    void Update()
    {
        bullet.transform.Translate(Vector3.back * speed * Time.deltaTime * 100);
    }

  
    
}
