using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject PlayerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(PlayerPrefab.name, randomPos, Quaternion.identity);
		//pl.GetComponent<PhotonView>().owner.TagObject = pl;
	}

	// Update is called once per frame
	void Update()
    {

    }
}
