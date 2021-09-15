using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClaimButtonScript : MonoBehaviour
{
    public int nextLevel = 1;
    Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void LoadNextLevel()
    {
        player.SaveData();

        string levelName = "Level " + nextLevel.ToString();

        if (levelName == "Level 0")
            Application.Quit();
        else
        {
            player.SaveData();
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));
        }

    }
}
