using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnButtonFunc()
    {
        string Scname = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(Scname);
    }
}
