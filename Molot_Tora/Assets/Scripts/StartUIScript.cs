using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartUIScript : MonoBehaviour
{
    public GameObject LevelName;
    public GameObject InGameUI;
    Text text;
    void Start()
    {
        Time.timeScale = 0f;
        text = LevelName.GetComponent<Text>();
        text.text = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            InGameUI.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
