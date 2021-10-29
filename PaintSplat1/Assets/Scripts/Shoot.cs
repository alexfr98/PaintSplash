using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject Player;
    public GameObject window;
    public GameObject Bullet;

    public GameObject painting;
    private bool overlap = false;

    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shot()
    {
        var bullet = Instantiate(Bullet);
  
        bullet.transform.position = Camera.main.transform.position;
       
        bullet.GetComponent<Rigidbody>().velocity = (Player.transform.position - bullet.transform.position)*4 ;

        Debug.Log("P:"+ Player.transform.position);
        Debug.Log("B:"+bullet.transform.position);

        if (Player.transform.position.x < window.transform.position.x + window.transform.localScale.x/2 && Player.transform.position.x > window.transform.position.x - window.transform.localScale.x / 2
            && Player.transform.position.y < window.transform.position.y + window.transform.localScale.y / 2 && Player.transform.position.y > window.transform.position.y - window.transform.localScale.y / 2)
        {
            Debug.Log("hello");

            foreach (Transform child in window.transform)
            {
                if(Player.transform.position.x < child.transform.position.x + child.transform.localScale.x / 2 && Player.transform.position.x > child.transform.position.x - child.transform.localScale.x / 2
            && Player.transform.position.y < child.transform.position.y + child.transform.localScale.y / 2 && Player.transform.position.y > child.transform.position.y - child.transform.localScale.y / 2)
                {
                    Debug.Log("Overlap");
                    overlap = true;
                }
            }

            if (!overlap)
            {

                var newPainting = Instantiate(painting, Player.transform.position, Quaternion.identity);
                newPainting.transform.parent = window.transform;
                score += 1;
                scoreText.text = "SCORE : " + score.ToString();
                //scoreText.text("hello");



            }
            overlap = false;
        }



    }

}
