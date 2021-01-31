using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTimer : MonoBehaviour {

	public void OnCollisionEnter(Collision obj)
{
	
	StopTimer(obj.gameObject);
}
public void OnCollisionEnter2D(Collision2D obj)
{

	StopTimer(obj.gameObject);
}
public void OnTriggerEnter2D(Collider2D obj)
{
	
	StopTimer(obj.gameObject);
}
public void OnTriggerEnter(Collider obj)
{
	
	StopTimer(obj.gameObject);
}
void StopTimer(GameObject obj)
{
	if(obj.tag=="Player")
	GameObject.FindGameObjectWithTag("Timer").GetComponent<PlayerPointsIncreaserByTimer>().stop=true;

    GameObject.FindGameObjectWithTag("Timer").GetComponent<PlayerPointsIncreaserByTimer>().UnlockNextWorld();
}
}
