using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player, hummer;
    public Slider progressBar;

    public List<GameObject> hummerBricks = new List<GameObject>();


    float speed = -0.25f;

    public Text ScoreText;
    public int score = 0;

    public int bricksNum;


   public int clock ;
   void Start()
    {
        progressBar.maxValue = 303;

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
    void OnMouseDrag()
    {

        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //player.transform.position = Vector3.MoveTowards(player.transform.position,  new Vector2(mousePosition.x, player.transform.position.y), 0.2f);

        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 mousePosition  = Input.mousePosition;
        //mousePosition.x = mousePosition.x > 5f ? 5f : mousePosition.x;
        //mousePosition.x = mousePosition.x < -5f ? -5f : mousePosition.x;
        //player.transform.position = new Vector2(mousePosition.x, this.transform.position.y);


        // Vector2 mousePosition = new Vector2(Input.mousePosition.x, player.position.y); // переменной записываютьс€ координаты мыши по иксу и игрику
        // Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваетьс€ переменна€ с координатами мыши
        // player.position = objPosition; // и собственно объекту записываютьс€ координаты  



        //Vector2 targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //targetPos.y = 0; // I fixed Y value to zero you may change this to value you want
        //player.position = targetPos;
        //if ((Vector2)transform.position != targetPos)
        //{
        //    player.position = Vector2.MoveTowards(player.position, targetPos, speed * Time.deltaTime);
        //
        //}

        //if (Input.mousePosition.x > Screen.width / 2)
        //    player.GetComponent<Rigidbody>().MovePosition(new Vector3(Input.mousePosition.x / 100000, 1, 0));
        //else
        //    player.GetComponent<Rigidbody>().MovePosition(new Vector3(-(Screen.width - Input.mousePosition.x) / 100000, 1, 0));
        if (Input.mousePosition.x > Screen.width / 2)
        {
            
           
            if (player.transform.position.x <= 4.7f)
            {
                if (player.transform.position.x >= 5)
                {
                    player.transform.position = new Vector3(5,0,0);
                    
                }
               // player.transform.Rotate(0,-0.1f,0);
                player.transform.Translate(new Vector3(Input.mousePosition.x / 8000*(-1), 0, 0));
            }
            
        }
        else
        {
            if (player.transform.position.x >= -4.2f)
            {
                if (player.transform.position.x <= -5)
                {
                    player.transform.position = new Vector3(-5, 0, 0);
                }
                //player.transform.Rotate(0,0.1f, 0);
                player.transform.Translate(new Vector3(-(Screen.width - Input.mousePosition.x) /8000 * (-1), 0, 0));
            }
        }
            
    }
    
    void Move()
    {
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
        

    }
}
