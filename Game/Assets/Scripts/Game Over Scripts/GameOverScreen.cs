//Author: Ryan Randive
//File Name: GameOverScreen
//Project Name: Hidden In the Shadows
//Creation Date: Sun, Jan 19, 2014
//Date Modified: Sun 19, 2014
//Description: Exits game
using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	
	float timeOnScreen;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		timeOnScreen += Time.deltaTime;
		
		//when the screen is on for 5 or more seconds
		if(timeOnScreen >= 5f)
		{
			//close game
			Application.Quit();
		}
	
	}
}
