//Author: Ryan Randive
//File Name: MonsterMapDark
//Project Name: Hidden In the Shadows
//Creation Date: Wed, Jan 15, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Darkens the map
using UnityEngine;
using System.Collections;

public class MonsterMapDark : MonoBehaviour {
	
	//the main game light
	public GameObject mainLight;
	
	//the tiny emergency spotlights
	public GameObject [] dimLights = new GameObject [9];
	
	//keeps track when assigning lights
	int count;
	
	//check to see if the map should be dark
	public static bool isMapDark;
	
	// Use this for initialization
	void Start () {
		
		//assigns the light
		mainLight = GameObject.Find("Area Light");
		
		//makes the main light on
		mainLight.light.enabled = true;
		
		//assigns the lights
		for (int i = 0; i < dimLights.Length; i++) 
		{	
			count++;
			dimLights[i] = GameObject.Find("EmergencyLight" + count);
			dimLights[i].light.enabled = false;
		}
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		SetToDark();
	}
	
	//Pre: none
	//Post: changes lights state
	//Description: if the monster activates the light, the map is set to dark
	public void SetToDark()
	{
		//if map should be dark
		if(isMapDark == true)
		{
			//turns off main light
			mainLight.light.enabled = false;
			
			//turns on emergency lights
			for (int i = 0; i < dimLights.Length; i++) 
			{
				dimLights[i].light.enabled = true;
			}
			
			StartCoroutine(DarkDuration());
			
			//map is no longer set to dark
			isMapDark = false;
		}
	}
	
	//Pre: none
	//Post: lights change state
	//Description: main light turned on, other lights turned off
	IEnumerator DarkDuration()
	{
		//map is dark for 15 seconds
		yield return new WaitForSeconds(15f);
		
		//main light turned on
		mainLight.light.enabled = true;
			
		//emergency lights turned off
		for (int i = 0; i < dimLights.Length; i++) 
		{
			dimLights[i].light.enabled = false;
		}
	}
	
	void OnGUI () 
	{
		//informs monster when powerup is on
		if(isMapDark == true)
		{
			GUI.Box (new Rect (Screen.width/2,25,150,25), "Dark Map");
		}
	}
}
