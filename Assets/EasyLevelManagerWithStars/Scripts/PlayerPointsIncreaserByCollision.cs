
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointsIncreaserByCollision : MonoBehaviour {
public string WorldName;
public string NextWorldName;
public int currlvl;
private int pointsstorer;
private int pointstoincrease=1;//Dont change it to 2 or more
public int totalstarsrequiredtounlocknextworld;
private int totalstars;
void Start()
{
	PlayerPrefs.SetInt((currlvl-1).ToString()+WorldName+"temp",0);
}
public void OnCollisionEnter(Collision obj)
{
	
	DeactivateStar(obj.gameObject);
}
public void OnCollisionEnter2D(Collision2D obj)
{

	DeactivateStar(obj.gameObject);
}
public void OnTriggerEnter2D(Collider2D obj)
{
	
	DeactivateStar(obj.gameObject);
}
public void OnTriggerEnter(Collider obj)
{
	
	DeactivateStar(obj.gameObject);
}
	void DeactivateStar(GameObject obj)
	{
		for(int i=0;i< PlayerPrefs.GetInt("LevelAvailable"+WorldName);i++)
        totalstars=totalstars+PlayerPrefs.GetInt(i.ToString()+WorldName);
		
		if(obj.gameObject.tag=="Player")
		{
			pointsstorer=PlayerPrefs.GetInt((currlvl-1).ToString()+WorldName+"temp")+pointstoincrease;
			PlayerPrefs.SetInt((currlvl-1).ToString()+WorldName+"temp",pointsstorer);
	    	this.gameObject.SetActive(false);
		}
		if(totalstars>=totalstarsrequiredtounlocknextworld-1)
		PlayerPrefs.SetInt("LevelAvailable"+NextWorldName,1);

	}
	
}
