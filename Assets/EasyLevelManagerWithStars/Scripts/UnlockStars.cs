using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockStars : MonoBehaviour {
public StarsController starscontroller;
private int levelavailable;
public string Worldname;
private int stars;

	void Update () {
		
		levelavailable=PlayerPrefs.GetInt("LevelAvailable"+Worldname);
		for(int i=0;i<levelavailable;i++)
		{
			if(!PlayerPrefs.HasKey(i.ToString()+Worldname))
			PlayerPrefs.SetInt(i.ToString()+Worldname,0);
		}

		for(int k=0;k<levelavailable;k++)
		{   
			stars=PlayerPrefs.GetInt(k.ToString()+Worldname);
			starscontroller.ActivateStars(k,stars);
			
		}
	}
}
