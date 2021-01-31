
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressSaverbyCollision : MonoBehaviour {
public GameObject LevelPassedPanel;	
public int Leveltounlock;
public string WorldName;
private int points;
private int temppoints;
public bool hastogainpoints=false;
public void OnCollisionEnter(Collision obj)
{
	
	LevelProgressSaver(obj.gameObject);
}
public void OnCollisionEnter2D(Collision2D obj)
{

	LevelProgressSaver(obj.gameObject);
}
public void OnTriggerEnter2D(Collider2D obj)
{
	
	LevelProgressSaver(obj.gameObject);
}
public void OnTriggerEnter(Collider obj)
{
	
	LevelProgressSaver(obj.gameObject);
}
void LevelProgressSaver(GameObject obj)
{ 
if(obj.gameObject.tag=="Player"&&!hastogainpoints)
	UnlockLevel();
	
}



public void UnlockLevel()
{
	
		temppoints=PlayerPrefs.GetInt((Leveltounlock-2).ToString()+WorldName+"temp");
		points=PlayerPrefs.GetInt((Leveltounlock-2).ToString()+WorldName);
		if(points<temppoints)
		PlayerPrefs.SetInt((Leveltounlock-2).ToString()+WorldName,temppoints);
		LevelPassedPanel.SetActive(true);
		if(PlayerPrefs.GetInt("LevelAvailable"+WorldName)>Leveltounlock)
		{

		}
		else{
		PlayerPrefs.SetInt("LevelAvailable"+WorldName,Leveltounlock);
		}
}

}
