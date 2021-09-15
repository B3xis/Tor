using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endUIScript : MonoBehaviour
{

    public float rulerMultiplier = 0f;

    public GameObject coinsTextGO, scoreTextGO, rulerMultiplierGO, LevelNameGO;
    Text coinsText, scoreText, rulerMultiplierText, LevelNameText;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        coinsText = coinsTextGO.GetComponent<Text>();
        scoreText = scoreTextGO.GetComponent<Text>();
        LevelNameText = LevelNameGO.GetComponent<Text>();

        LevelNameText.text = SceneManager.GetActiveScene().name;

        rulerMultiplierText = rulerMultiplierGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = player.CoinsScore.ToString();
        scoreText.text = player.score.ToString();
        rulerMultiplierText.text = rulerMultiplier.ToString();
    }
}
