using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotObject : MonoBehaviour
{
    public GameObject Painting;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Image");
    }
    public void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;

        
        if (collision.collider.name == "Sphere")
        {
            Debug.Log(this.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.collider.name == "Cube")
        {
            Debug.Log(collision.collider.name);
            Destroy(this.gameObject);
            var painting = Instantiate(Painting);
            painting.transform.parent = canvas.transform;
            painting.transform.position = pos;
            painting.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
