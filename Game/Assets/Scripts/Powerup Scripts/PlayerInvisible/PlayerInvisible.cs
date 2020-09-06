//Author: Ryan Randive
//File Name: PlayerInvisibile
//Project Name: Hidden In the Shadows
//Creation Date: Wed, Jan 15, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Makes player invisible
using UnityEngine;
using System.Collections;

public class PlayerInvisible : MonoBehaviour {
	
	//the player themself
	public GameObject player;
	//check to see if the player is invisible
	public static bool isPlayerInvisible;
	
	// Use this for initialization
	void Start () {
		
		isPlayerInvisible = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//if player is invisible
		if(isPlayerInvisible == true)
		{
			StartCoroutine(PlayerInvisibleTime());
			isPlayerInvisible = false;
		}
	
	}
	
	//Pre: none
	//Post: none
	//Description: disables the renderer of player
	IEnumerator PlayerInvisibleTime(){
	
		//disbles the player renderer to make them invisble on screen
		player.renderer.enabled = false;
		
		//player is invisible for 20 seconds
		yield return new WaitForSeconds(20f);
		
		//player is visible again
		player.renderer.enabled = true;
		
	}
	
	void OnGUI () 
	{
		//tells user that the powerup is equipped
		if(player.renderer.enabled == false)
		{
			GUI.Box (new Rect (0,25,150,25), "Invisibility Equipped");
		}
	}
}
