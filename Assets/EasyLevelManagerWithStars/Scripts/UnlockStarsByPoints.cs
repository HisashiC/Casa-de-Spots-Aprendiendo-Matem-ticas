using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockStarsByPoints : MonoBehaviour {
public string WorldName;
public string NextWorldName;
public int currlvl;
private int pointsstorer;
private int pointstoincrease=1;//Dont change it to 2 or more
public int totalstarsrequiredtounlocknextworld;
private int totalstars;
public int[] pointsrequiredtonlockthestars;
		void OnCollisionEnter2D(Collision2D obj)
	{
		 Check(obj.gameObject);
	}
	void OnCollisionEnter(Collision obj)
	{
	 Check(obj.gameObject);
	}
	void OnTriggerEnter(Collider obj)
	{
 Check(obj.gameObject);
	}
	void OnTriggerEnter2D(Collider2D obj)
	{
       Check(obj.gameObject);
	}
	void Check(GameObject obj)
	{	if(obj.gameObject.tag=="Player")
	{for(int i=0;i< PlayerPrefs.GetInt("LevelAvailable"+WorldName);i++)
        totalstars=totalstars+PlayerPrefs.GetInt(i.ToString()+WorldName);
		PlayerPrefs.SetInt((currlvl-1).ToString()+WorldName+"temp",0);
		for(int j=0;j<pointsrequiredtonlockthestars.Length;j++)
		{
		if(PlayerPrefs.GetInt("PlayerPoints")>=pointsrequiredtonlockthestars[j])
		{
		pointsstorer=PlayerPrefs.GetInt((currlvl-1).ToString()+WorldName+"temp")+pointstoincrease;
		PlayerPrefs.SetInt((currlvl-1).ToString()+WorldName+"temp",pointsstorer);
		}
        }
		if(totalstars>=totalstarsrequiredtounlocknextworld-1)
		PlayerPrefs.SetInt("LevelAvailable"+NextWorldName,1);
	}

	}
}
