using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStarsOnPlayerDeath : MonoBehaviour {
private GameObject[] Stars;
	// Use this for initialization
	void Start () {
		Stars=GameObject.FindGameObjectsWithTag("Star");
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("Player")==null)
		{PlayerPrefs.SetInt(((Stars[0].GetComponent<PlayerPointsIncreaserByCollision>().currlvl)-1).ToString()+(Stars[0].GetComponent<PlayerPointsIncreaserByCollision>().WorldName)+"temp",0);
			for(int i=0;i<Stars.Length;i++)
         Stars[i].SetActive(true);
		}

	}
}
