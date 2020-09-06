//Author: Ryan Randive
//File Name: MonsterInstantKill
//Project Name: Hidden In the Shadows
//Creation Date: Fri, Jan 17, 2014
//Date Modified: Sun 19, 2014
//Description: Kills a player upon contact
using UnityEngine;
using System.Collections;

public class MonsterInstantKill : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Pre: collided object
	//Post: none
	//Description: destroys player if monster touches
	void OnTriggerEnter(Collider other)
	{
		//if touching a player
		if(other.gameObject.CompareTag("Player"))
		{
			//number of players dead increases by one
			GameOver.isPlayerDead += 1;
			//destroy player
			Destroy(other.gameObject);
		}
		
	}
}
