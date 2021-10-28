using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    
    public GameObject Image_2;
    public float speed=5f;
    Vector3 Begin_position;
    float x, y;

    // Start is called before the first frame update
    void Start()
    {
        Begin_position = Image_2.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        x = Image_2.GetComponent<Transform>().position.x- Begin_position.x;
        y = Image_2.GetComponent<Transform>().position.y-Begin_position.y;

        if (x > 0.005&&transform.position.x<=10)
        {
            transform.Translate(speed * Time.deltaTime , 0, 0);
        }
        if (x < -0.005 && transform.position.x >= -10)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (y > 0.005 && transform.position.y <= 6)
        {
            transform.Translate(0, speed * Time.deltaTime ,0 );
        }
        if (y < -0.005 && transform.position.y >= -6)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

}
