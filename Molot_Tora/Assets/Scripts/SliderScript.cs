using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    GameObject player, boss;
    Vector3 start, finish;
    float levelLength;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();

        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("BOSS");

        start = player.transform.position;
        finish = boss.transform.position;
        levelLength = Vector3.Distance(start, finish);
    }


    void Update()
    {
        slider.value = Vector3.Distance(player.transform.position, start) / levelLength;
        if (slider.value > 1f)
            slider.value = 1f;
    }
}
