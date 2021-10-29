using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

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

		//gameObject.GetComponent<PhotonView>().Owner;

		var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
		foreach (var view in photonViews)
		{
			var player = view.Owner;
			//Objects in the scene don't have an owner, its means view.owner will be null
			if (player != null)
			{
				var playerPrefabObject = view.gameObject;

				Player = playerPrefabObject;
			}
		}

		//Debug.Log("Photon Shoot Code " + m);

	}
    // Update is called once per frame
    void Update()
    {

		
	}
    public void Shot()
    {

		//if (IsMine)
		{
			var bullet = Instantiate(Bullet);


			//go = PhotonNetwork.Instantiate(Bullet, transform.position, transform.rotation, 0);

			bullet.transform.position = Camera.main.transform.position;

			bullet.GetComponent<Rigidbody>().velocity = (Player.transform.position - bullet.transform.position) * 4;

			Debug.Log("P:" + Player.transform.position);
			Debug.Log("B:" + bullet.transform.position);

			if (Player.transform.position.x < window.transform.position.x + window.transform.localScale.x / 2 && Player.transform.position.x > window.transform.position.x - window.transform.localScale.x / 2
				&& Player.transform.position.y < window.transform.position.y + window.transform.localScale.y / 2 && Player.transform.position.y > window.transform.position.y - window.transform.localScale.y / 2)
			{
				Debug.Log("hello");

				foreach (Transform child in window.transform)
				{
					if (Player.transform.position.x < child.transform.position.x + child.transform.localScale.x / 2 && Player.transform.position.x > child.transform.position.x - child.transform.localScale.x / 2
				&& Player.transform.position.y < child.transform.position.y + child.transform.localScale.y / 2 && Player.transform.position.y > child.transform.position.y - child.transform.localScale.y / 2)
					{
						Debug.Log("Overlap");
						overlap = true;
					}
				}

				if (!overlap)
				{

					var newPainting = PhotonNetwork.Instantiate(painting.name, Player.transform.position, Quaternion.identity, 0);
						//Instantiate(painting, Player.transform.position, Quaternion.identity);
					newPainting.transform.parent = window.transform;
                    //Change Color?
					score += 1;
					scoreText.text = score.ToString();
					//scoreText.text("hello");

					

				}
				overlap = false;
			}

		}

    }

}
