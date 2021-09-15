using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailManager : MonoBehaviour
{
    Transform hummerAttractor;
    Player player;

    public float FusionSpeed = 0.35f;
    public int pieceWeight = 1;

    private void Start()
    {
        hummerAttractor = GameObject.FindGameObjectWithTag("HummerAttractor").GetComponent<Transform>();
        FusionSpeed *= 100f;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            player = hit.GetComponent<Player>();
            StartCoroutine(FusionAnim());
        }

        if (hit.tag == "Hummer")
        {
            Destroy(gameObject);
            player.addHummerBrick(pieceWeight);
        }
    }

    IEnumerator FusionAnim()
    {
     //   float repulsionRad = 5.5f, xRepulsioRand = Random.Range(0.45f, 0.55f), yRepulsioRand = Random.Range(0.07f, 0.12f); //defines  right-wide curve of the repulsion

        float repulsionRad = 5.5f, xRepulsioRand = Random.Range(0.15f, 0.25f), yRepulsioRand = Random.Range(0.04f, 0.07f); //defines left curve of the repulsion
        Vector3 translateVector;

        gameObject.transform.localScale /= 2.5f; // scale to the sive of the Details in the hammer

        while (Vector3.Distance(hummerAttractor.position, gameObject.transform.position) < repulsionRad)
        {
            yield return new WaitForEndOfFrame();

            translateVector = (gameObject.transform.position - hummerAttractor.position).normalized;
            translateVector.Scale(new Vector3(FusionSpeed * Time.deltaTime, FusionSpeed * Time.deltaTime, FusionSpeed * Time.deltaTime));

            gameObject.transform.Translate(new Vector3(translateVector.x + xRepulsioRand * Time.deltaTime * 60, translateVector.y + yRepulsioRand * Time.deltaTime * 60, translateVector.z));

        }

        while (true)
        {
            yield return new WaitForEndOfFrame();            

            translateVector = (hummerAttractor.position - gameObject.transform.position).normalized;
            translateVector.Scale(new Vector3(FusionSpeed*Time.deltaTime*1f, FusionSpeed * Time.deltaTime*1f, FusionSpeed * Time.deltaTime*1.1f));

            gameObject.transform.Translate(translateVector);

        }

    }

}
