using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowStarsNeeded : MonoBehaviour {
public Text text;
public EasyLevelManagerWithStars elm;
private int totalstars=0;
 public void ShowStars(int levelnumber)
 {
	for(int k=0;k<PlayerPrefs.GetInt("LevelAvailable"+elm.Worldname);k++)
	totalstars+=PlayerPrefs.GetInt(k.ToString()+elm.Worldname);
    text.text="You still need "+(elm.numberofstarsrequiredtounlockthelevels[levelnumber]-totalstars)+" stars to unlock level "+(levelnumber+1);
    if((elm.numberofstarsrequiredtounlockthelevels[levelnumber]-totalstars)==0)
    text.text="You must play the previous level to unlock this level";
    if(!PlayerPrefs.HasKey("LevelAvailable"+elm.Worldname))
    text.text="Complete previous world first";
StartCoroutine(SetBlank());
 }
 IEnumerator SetBlank()
 {
     yield return new WaitForSeconds(3f);
     text.text="";
     totalstars=0;
 }
}
