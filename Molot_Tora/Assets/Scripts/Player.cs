using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.IO;

public class Player : MonoBehaviour
{
    public GameObject player, hummer, hummerModelPrefab;
    public List<GameObject> hummerBricks = new List<GameObject>();


    public float speed = 0.5f;

    public Text ScoreText;
    public Text CoinsText;
    public int CoinsScore;
    public int score = 0;


    private Animator animator;
    private Animator hummerAnimator;

    public int bricksNum;

    public string lname;

   // public Transform MoovePan;
   public int clock ;

    bool bossIsKilled = false;

    Transform defaultTransform;

    bool inputIsAlowed = true;

    public int coinsOnTheStart;

    void Start()
    {
        LoadData();

        Application.targetFrameRate = 90;

        lname = SceneManager.GetActiveScene().name;

        animator = GetComponent<Animator>();
        hummerAnimator = hummer.GetComponent<Animator>();


        CoinsScore = PlayerPrefs.GetInt("Coins", 0);
        coinsOnTheStart = CoinsScore;

        defaultTransform = GetComponent<Transform>().transform;

       for (int i = 0; i < 48; i++)
       {
          hummerBricks[i].gameObject.SetActive(false);
       }
    }

    void Update()
    {
            Move();
        

        ScoreText.text = score.ToString();
        CoinsText.text = CoinsScore.ToString();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    void Move()
    {
     //   MoovePan.Translate(Vector3.forward * (speed) * Time.deltaTime * 60f);
        player.transform.Translate(Vector3.forward * (-speed) * Time.deltaTime * 100f);  //speed Up)

        if (inputIsAlowed)
        {
            if (Input.GetKey("w"))
            {
                player.transform.Translate(new Vector3(0, 0, -30 * Time.deltaTime));
            }

            if (Input.GetKey("a"))
            {
                player.transform.Translate(new Vector3(13 * Time.deltaTime, 0, 0));

            }

            else if (Input.GetKey("d"))
            {
                player.transform.Translate(new Vector3(-13 * Time.deltaTime, 0, 0));

            }
        }

     }

    public IEnumerator TwitchScaleAnimTo(float s = 0.925f, float speed = 1.5f)
    {
        float val = speed;
        while (transform.localScale.x > s)
        {
            yield return new WaitForFixedUpdate();
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * val, transform.localScale.y - Time.deltaTime * val, transform.localScale.z - Time.deltaTime * val);
        }

        while (transform.localScale.x < 1f)
        {
            yield return new WaitForFixedUpdate();
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * val, transform.localScale.y + Time.deltaTime * val, transform.localScale.z + Time.deltaTime * val);
        }

        transform.localScale = defaultTransform.localScale;
    }

    private void LateUpdate()
    {
        animator.SetBool("IsHit", false);
        hummerAnimator.SetBool("IsHit", false);
    }

    IEnumerator GloryKillAnimation()
    {
        float sinArgument = 0f;

        while (sinArgument < Mathf.PI)
        {
            yield return new WaitForFixedUpdate();
            
            sinArgument += Time.deltaTime * Mathf.PI / 1.995f;
            GetComponent<Transform>().SetPositionAndRotation(new Vector3(player.transform.position.x + Mathf.Clamp((bossTransform.position.x - player.transform.position.x), -1, 1) * Time.deltaTime*5f, Mathf.Sin(sinArgument) * 7f, player.transform.position.z), GetComponent<Transform>().rotation);
        }

        GetComponent<Transform>().SetPositionAndRotation(new Vector3(player.transform.position.x, 0f, player.transform.position.z), GetComponent<Transform>().rotation);

    }

    public void addHummerBrick(int amount)
    {
        bricksNum += amount;
        clock += amount;
        for (int i = clock - amount; i < clock; i++)
        {
            hummerBricks[i].gameObject.SetActive(true);
        }
    }

    void GetDamage(int blocksNum)
    {
        StartCoroutine(TwitchScaleAnimTo());

        for (int i = 0; i<blocksNum;i++)
        {
            GameObject cloneBrick = GameObject.Instantiate(hummerBricks[clock].gameObject, hummerBricks[clock].gameObject.transform);
            cloneBrick.transform.SetParent(null);
            cloneBrick.SetActive(true);
            cloneBrick.transform.localScale = new Vector3(8000f, 8000f, 8000f);
            cloneBrick.AddComponent<Rigidbody>();
            cloneBrick.GetComponent<Rigidbody>().useGravity = true;
            cloneBrick.GetComponent<Rigidbody>().isKinematic = false;
            cloneBrick.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(1f, 2f), 5f), ForceMode.VelocityChange);

            Destroy(cloneBrick, 2f);

            bricksNum--;
            clock--;
            hummerBricks[clock].gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.name);
      
        if (hit.tag == "bullet")
            {
                GetDamage(3);
            }

        else if (hit.tag == "Spike")
        {
            GetDamage(5);

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
        else if ((hit.tag == "BOSS")&&(bossIsKilled == false))
        {
            score += 50;

            bossIsKilled = true;
            inputIsAlowed = false;

            bossTransform = hit.GetComponent<Transform>();
            StartCoroutine(GloryKillAnimation());
            animator.SetBool("IsGloryKill", true);
            hummerAnimator.SetBool("IsGloryKill", true);
        }

    }


    Transform bossTransform;

    public Vector3 GetPosition()
    {
        return GetComponent<Transform>().position;
    }

    public void SetCoins(int c)
    {
        CoinsScore = c;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Coins", CoinsScore);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        CoinsScore = PlayerPrefs.GetInt("Coins", 0);
    }
}
