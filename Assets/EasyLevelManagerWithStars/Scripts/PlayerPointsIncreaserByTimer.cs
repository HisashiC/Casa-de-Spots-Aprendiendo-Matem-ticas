using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPointsIncreaserByTimer : MonoBehaviour {
public Text Timer;
public Text ShowTimeRequired;
private float StartTime=0f;
public float EndTime;
public GameObject[] Stars;
public float[] TimeRequiredForStars;
public  string WorldName;
public  string NextWorldName;
public  int currlvl;
public  int totalstarsrequiredtounlocknextworld;
private  int totalstars;
private int pointsstorer;
private int i;
private int showtime;
private  int setstars;
public bool stop=false;
void Start()
{
	Timer.text=StartTime.ToString()+" s";
	for(i=0;i<Stars.Length;i++)
	{
	Stars[i].SetActive(true);
	}
	showtime=(TimeRequiredForStars.Length)-1;
	setstars=Stars.Length;
	StartCoroutine(Wait());
	
}
IEnumerator Wait()
{
	if(!stop)
	{
	if(showtime!=-1)
	if(StartTime>=TimeRequiredForStars[showtime])
		{
		Stars[showtime].SetActive(false);
		showtime--;
		setstars--;
		Debug.Log(pointsstorer);
		}
		
	yield return new WaitForSeconds(1f);
	if(showtime==-1)
		ShowTimeRequired.text="No stars for this level";
    else
	    ShowTimeRequired.text="Star number "+(showtime+1)+" vanishes after "+TimeRequiredForStars[showtime].ToString()+" s";
	StartTime++;
    if(StartTime<=EndTime)
	Timer.text=StartTime.ToString()+" s";
	else
	Timer.text="Time up !!!";
	
	StartCoroutine(Wait());
	}
}
		public  void UnlockNextWorld()
	{
		for(int j=0;j< PlayerPrefs.GetInt("LevelAvailable"+WorldName);j++)
        totalstars=totalstars+PlayerPrefs.GetInt(j.ToString()+WorldName);
		PlayerPrefs.SetInt((currlvl-1).ToString()+WorldName+"temp",setstars);		
		
		if(totalstars>=totalstarsrequiredtounlocknextworld-1)
		PlayerPrefs.SetInt("LevelAvailable"+NextWorldName,1);
	}

	
}
