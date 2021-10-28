using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    int level = 3;
    private float speed = 300.0f;
    Vector3 LastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));

    }

    // Update is called once per frame
    void Update()
    {
        LastVelocity = rb.velocity;
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

    private void OnTriggerEnter2D(Collider2D collision)
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
}