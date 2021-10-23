using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject shootingWindow;
    public Camera cam;

    public float speed = 1;

    public Collider2D UpCol;
    public Collider2D DownCol;
    public Collider2D LeftCol;
    public Collider2D RightCol;

    //speed and movement
    //Score Controllers
    //game timer = 1.5 minutes


    // Start is called before the first frame update
    void Start()
    {
        shootingWindow.transform.position = new Vector3(0, 0, 0);

        UpCol.transform.position = cam.ScreenToWorldPoint(new Vector3(-Screen.width / 2 , Screen.height / 2 , 0));
        DownCol.transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        LeftCol.transform.position = cam.ScreenToWorldPoint(new Vector3(-Screen.width / 2, -Screen.height / 2, 0));
        RightCol.transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, -Screen.height / 2, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
