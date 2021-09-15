using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RulerScript : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject endUIGO;

    endUIScript endUI;
    Player player;
    float decreaseValue;
    Vector3 playerStartPos, playerEndPos;

    float currentLevelCoinScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        endUI = endUIGO.GetComponent<endUIScript>();

        decreaseValue = Random.Range(0.034f, 0.21f);
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            

            if (other.gameObject.tag == "Player")
            {
                currentLevelCoinScore = player.CoinsScore - player.coinsOnTheStart;

                Debug.Log("currentLevelCoinScore");
                Debug.Log(currentLevelCoinScore);


                inGameUI.SetActive(false);
                endUIGO.SetActive(true);

                StartCoroutine(Measuring());

                playerStartPos = player.GetPosition();


            }
        }
    }


    IEnumerator Measuring()
    {
        while (player.speed > 0f)
        {
            yield return new WaitForEndOfFrame();
            player.speed -= decreaseValue*Time.deltaTime;
            if (player.speed < 0f) player.speed = 0f;

            playerEndPos = player.GetPosition();

            endUI.rulerMultiplier = Vector3.Distance(playerStartPos, player.GetPosition())/10f + 1f;
            player.SetCoins(player.coinsOnTheStart + Mathf.RoundToInt(currentLevelCoinScore * endUI.rulerMultiplier));
        }
    }

}
