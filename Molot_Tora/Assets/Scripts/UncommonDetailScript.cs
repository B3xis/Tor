using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncommonDetailScript : MonoBehaviour
{
    [SerializeField]
    GameObject regularDetail;

    public int pieceWeight = 3;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            for (int i = 0; i< pieceWeight; ++i)
            {
                Instantiate(regularDetail, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
