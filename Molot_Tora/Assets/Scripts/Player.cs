using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player, hummer;
    public Slider progressBar;

    public List<GameObject> hummerBricks = new List<GameObject>();


    float speed = -0.25f;

    public Text ScoreText;
    public Text CoinsText;
    public int CoinsScore;
    public int score = 0;

    public int bricksNum;

    public string lname;

    public Transform MoovePan;
   public int clock ;
   void Start()
    {
        lname = SceneManager.GetActiveScene().name;
        if(lname == "Level6")
        {
            progressBar.maxValue = 191;
        }
        else
        {
            progressBar.maxValue = 303;
        }
       


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
        MoovePan.Translate(Vector3.forward * (-speed));
        player.transform.Translate(Vector3.forward * speed);
        progressBar.value+= 0.25f;
        
        
        //  if (Input.GetKey("a"))
        //  {
        //      if (player.transform.position.x >= 5)
        //      {
        //          player.transform.position = new Vector3(5, 0, 0);
        //
        //      }
        //
        //      player.transform.Translate(new Vector3(Input.mousePosition.x / 7500, 0, 0));
        //
        //      
        //  }
        //  else if (Input.GetKey("d"))
        //  {
        //      if (player.transform.position.x <= -5)
        //      {
        //          player.transform.position = new Vector3(-5, 0, 0);
        //      }
        //      player.transform.Translate(new Vector3(-(Screen.width - Input.mousePosition.x) / 7500, 0, 0));
        //  }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "sLAVE")
        {
            score += 5;
            
        }

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

    }
}
