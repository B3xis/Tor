using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.IO;

public class Player : MonoBehaviour
{
    public GameObject player, hummer, hummerModelPrefab;
    public Slider progressBar;

    public List<GameObject> hummerBricks = new List<GameObject>();


    float speed = 0.25f * 60f;

    public Text ScoreText;
    public Text CoinsText;
    public int CoinsScore;
    public int score = 0;

    private Animator animator;
    private Animator hummerAnimator;

    public int bricksNum;

    public string lname;

    public Transform MoovePan;
   public int clock ;
   void Start()
    {
        Application.targetFrameRate = 90;

        lname = SceneManager.GetActiveScene().name;
        if(lname == "Level6")
        {
            progressBar.maxValue = 191;
        }
        else
        {
            progressBar.maxValue = 303;
        }

        animator = GetComponent<Animator>();
        hummerAnimator = hummer.GetComponent<Animator>();


        CoinsScore = PlayerPrefs.GetInt("Coins", CoinsScore);
        

       for (int i = 0; i < 48; i++)
       {
          hummerBricks[i].gameObject.SetActive(false);
       }
    }

    void Update()
    {
        Move();
        ScoreText.text = score.ToString();
        
    }
   
    
    void Move()
    {
        MoovePan.Translate(Vector3.forward * (speed) * Time.deltaTime);
        player.transform.Translate(Vector3.forward * (-speed) * Time.deltaTime);
        progressBar.value+= 0.25f;

        if (Input.GetKey("w"))
        {
            player.transform.Translate(new Vector3(0, 0, - 20 * Time.deltaTime));

        }

        if (Input.GetKey("a"))
        {
            player.transform.Translate(new Vector3(20 * Time.deltaTime, 0, 0));

        }

        else if (Input.GetKey("d"))
        {
            player.transform.Translate(new Vector3(-20 * Time.deltaTime, 0, 0));

        }
    }

    private void LateUpdate()
    {
        animator.SetBool("IsHit", false);
        hummerAnimator.SetBool("IsHit", false);
    }

    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.name);

        if (hit.tag == "x1")
        {
            bricksNum ++;
            
            hummerBricks[clock].gameObject.SetActive(true);
            clock++;
            bricksNum++;

            hummerBricks[clock].gameObject.SetActive(true);
            clock++;
        }
        if (hit.tag == "Gold")
        {
            if (lname == "Level5")
            {
                bricksNum += 16;
                clock += 16;
                for (int i = clock - 16; i < clock; i++)
                {
                    hummerBricks[i].gameObject.SetActive(true);
                }
            }
            else
            {
                bricksNum++;

                hummerBricks[clock].gameObject.SetActive(true);
                clock++;
                bricksNum++;

                hummerBricks[clock].gameObject.SetActive(true);
                clock++;
                bricksNum++;

                hummerBricks[clock].gameObject.SetActive(true);
                clock++;
                bricksNum++;

                hummerBricks[clock].gameObject.SetActive(true);
                clock++;
            }
          
        }
        else if (hit.tag == "x3")
        {
            bricksNum += 10;
            clock += 10;
            for (int i = clock-10; i < clock; i++)
            {
                hummerBricks[i].gameObject.SetActive(true);
            }
            
        }
       
        else if (hit.tag == "bullet")
            {
                

                bricksNum--;
                clock--;
                hummerBricks[clock].gameObject.SetActive(false);
                bricksNum--;
                clock--;
                hummerBricks[clock].gameObject.SetActive(false);

        }
        else if (hit.tag == "Coins")
        {

            CoinsScore += 25;
            CoinsText.text = CoinsScore.ToString();
            PlayerPrefs.SetInt("Coins", CoinsScore);
        }
        else if (hit.tag == "Wall")
        {
            score += 5;

            animator.SetBool("IsHit", true);
            hummerAnimator.SetBool("IsHit", true);
        }
        else if (hit.tag == "Enemy")
        {
            score += 20;

            animator.SetBool("IsHit", true);
            hummerAnimator.SetBool("IsHit", true);
        }

    }
}
