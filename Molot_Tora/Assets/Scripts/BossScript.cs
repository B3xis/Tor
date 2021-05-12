using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
   
    public int levelId=1;
    public string lvl,scn;

    void Start()
    {
        scn = PlayerPrefs.GetString("Level");
        levelId = PlayerPrefs.GetInt("lvlID");
    }
    private void OnTriggerEnter(Collider hit)
    {
        if (levelId<16)
        {
            levelId++;
            lvl = "Level" + levelId;
            scn = lvl;
            PlayerPrefs.SetString("Level", scn);
            PlayerPrefs.SetInt("lvlID", levelId);
        }
        PlayerPrefs.Save();
    }
}
