using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class windowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    int level = 1;
    private float speed = 300.0f;
    Vector3 LastVelocity;
    private bool start = false;
    private bool finish = false;
    public Button shootButton;
    public Text gameOverText;
    public Text timeText;
    public Button repeatButton;
    private int timeWaiting = 2;
    private int gameDuration = 5; //This number is the TOTAL GAME time. So it would be gameDuration-timeWaiting seconds playing
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        repeatButton.GetComponentInChildren<Text>().text = "Return to lobby";
        repeatButton.onClick.AddListener(TaskOnClick);
        repeatButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Time.time);
        if (Time.time > timeWaiting && !start) {
            start = true;
            int decision = Random.Range(0, 2);
            timeText.gameObject.SetActive(true);
            shootButton.gameObject.SetActive(true);
            if (decision == 0)
            {
               
                Debug.Log("0,0");
                rb.AddForce(new Vector2(Random.Range(-150, -100) * level, Random.Range(-150, -100) * level));
            }
            else if (decision == 1)
            {
                Debug.Log("1");
                rb.AddForce(new Vector2(Random.Range(100, 150) * level, Random.Range(-150, -100) * level));
            }
        }
        if (Time.time > gameDuration && !finish)
        {
            repeatButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            repeatButton.onClick.AddListener(TaskOnClick);
            finish = true;
            this.gameObject.SetActive(false);
            timeText.gameObject.SetActive(false);

        }
        if (start && !finish)
        {
            timeText.text = "Time: " + (gameDuration - timeWaiting + 1 - (int)(Time.time)).ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        int decision = Random.Range(0, 2);

        if (collision.gameObject.name == "UpCollider")
        {
            if (decision == 0)
            {
                Debug.Log("0,0");
                rb.AddForce(new Vector2(Random.Range(-150, -100) * level, Random.Range(-150, -100) * level));
            }
            else if (decision == 1)
            {
                Debug.Log("1");
                rb.AddForce(new Vector2(Random.Range(100, 150) * level, Random.Range(-150, -100) * level));
            }

        }
        if (collision.gameObject.name == "DownCollider")
        {
            if (decision == 0)
            {
                Debug.Log("0");
                rb.AddForce(new Vector2(Random.Range(-150, -100) * level, Random.Range(100, 150) * level));
            }
            else if (decision == 1)
            {
                Debug.Log("1");
                rb.AddForce(new Vector2(Random.Range(100, 150) * level, Random.Range(100, 150) * level));
            }
        }
        if (collision.gameObject.name == "LeftCollider")
        {
            if (decision == 0)
            {
                Debug.Log("0");
                rb.AddForce(new Vector2(Random.Range(100, 150) * level, Random.Range(100, 150) * level));
            }
            else if (decision == 1)
            {
                Debug.Log("1");
                rb.AddForce(new Vector2(Random.Range(100, 150) * level, Random.Range(-150, -100) * level));
            }
        }
        if (collision.gameObject.name == "RightCollider")
        {
            if (decision == 0)
            {
                Debug.Log("0");
                rb.AddForce(new Vector2(Random.Range(-150, -100) * level, Random.Range(-150, -100) * level));
            }
            else if (decision == 1)
            {
                Debug.Log("1");
                rb.AddForce(new Vector2(Random.Range(-150, -100) * level, Random.Range(100, 150) * level));
            }
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}