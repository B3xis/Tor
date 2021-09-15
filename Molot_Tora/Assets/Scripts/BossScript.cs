using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    Player player;
    public GameObject disassembled, parentWithRigidbody;
    Rigidbody parentRB;

    private Animator animator;

    bool activated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();

        parentRB = parentWithRigidbody.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if ((hit.tag == "Player")&&(!activated))
        {
            activated = true;
            animator.SetBool("isDead", true);

            parentRB.useGravity = true;
            parentRB.AddForce(new Vector3(0, 1.85f, 39f), ForceMode.VelocityChange);

            player.speed = 0.25f;
            StartCoroutine(WaitUntil_Frame(12f*2f));

            PlayerPrefs.Save();
        }
    }

    IEnumerator WaitUntil_Frame(float frame)
    {
        yield return new WaitForSeconds(frame / 30f);
        disassembled.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnButtonFunc()
    {
        SceneManager.LoadScene("Menu");
    }
}
