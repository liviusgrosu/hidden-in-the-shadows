//Author: Ryan Randive
//File Name: GameOver
//Project Name: Hidden In the Shadows
//Creation Date: Fri, Jan 17, 2014
//Date Modified: Sun 19, 2014
//Description: Determines if players of monster wins
using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	//check to see how many players are dead
	public static int isPlayerDead;
	//if the monster wins
	bool isGameOver;
	//if players win
	bool isPlayersWin;
	
	//game lasts 2 min
	float maxGameTime = 120f;
	
	// Use this for initialization
	void Start () {
	
		isPlayerDead = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		//the total game time is being lowered every second the game goes by
		maxGameTime -= Time.deltaTime;
		
		//if 3 players are dead
		if(isPlayerDead == 3)
		{
			//monster wins
			isGameOver = true;
			//loads game over scene
			Application.LoadLevel("Game Over");
		}
		//if the time runs out the players win
		if(maxGameTime <= 0f)
		{
			//players win
			isPlayersWin = true;
			//loads the players win scene
			Application.LoadLevel("Players Win");
		}
	
	}
	
	void OnGUI () 
	{
		//draws the time left on the screen
		GUI.Box (new Rect (Screen.width/2 - 100,Screen.height/2 -25,200,25), "Time Left: " + maxGameTime);
	}
}
