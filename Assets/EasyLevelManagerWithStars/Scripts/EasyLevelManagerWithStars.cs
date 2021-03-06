﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EasyLevelManagerWithStars : MonoBehaviour {
public string Worldname; 
public int[] numberofstarsrequiredtounlockthelevels;
private int totalstars=0;
public GameObject[] Levellockbuttons;
private bool keycheck;
private int temp;
void Start()
{

	 for(int i=0;i< PlayerPrefs.GetInt("LevelAvailable"+Worldname);i++)
        totalstars=totalstars+PlayerPrefs.GetInt(i.ToString()+Worldname);
		 for(int i=0 ;i < Levellockbuttons.Length; i++){
		Levellockbuttons[i].transform.parent.GetComponent<Button>().interactable=false;	 
		 Levellockbuttons[i].SetActive(true);
		 }
}
	void Update () {

		keycheck=PlayerPrefs.HasKey("LevelAvailable"+Worldname);
		if(keycheck)
		{
		 for(int i=0 ;i < PlayerPrefs.GetInt("LevelAvailable"+Worldname) ; i++){
		if(totalstars>=numberofstarsrequiredtounlockthelevels[i])	
		{ 	Levellockbuttons[i].transform.parent.GetComponent<Button>().interactable=true;	 
		 Levellockbuttons[i].SetActive(false);
		}
		 }
		
		}
	}
}
