using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour {
public GameObject[] Starsoflevels;
public int numberofstarsforeachlevel;
private int divide;
private int lowerlimit;
private int upperlimit;
	public void ActivateStars(int level,int stars)
	{
		if(stars!=0)
		{
		
			upperlimit=(numberofstarsforeachlevel*(level+1))-1;
             lowerlimit=upperlimit-(numberofstarsforeachlevel-1);
			for(int i=lowerlimit;i<=upperlimit;i++)
			{
				
              if(stars>0)
				{
				Starsoflevels[i].SetActive(true);
				stars--;
				}
				else
				break;
			}
        
		}
	}
}
