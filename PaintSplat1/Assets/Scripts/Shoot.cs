using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
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

        bullet.GetComponent<Rigidbody>().velocity = (Player.transform.position - bullet.transform.position) * 5;




    }
}
