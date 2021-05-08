using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject light;
    public void OnButtonFunc()
    {
        
        SceneManager.LoadScene("GameScene");
    }
}
