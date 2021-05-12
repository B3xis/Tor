using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public string levname;
    public Text textLvl;

    void Start()
    {
        levname = PlayerPrefs.GetString("Level");
        if (levname == null)
        {
            levname = "Level1";
            PlayerPrefs.SetString("Level", levname);
        }
        textLvl.text = levname;
    }
    public void OnButtonFunc()
    {


        SceneManager.LoadScene(levname);
    }
}
