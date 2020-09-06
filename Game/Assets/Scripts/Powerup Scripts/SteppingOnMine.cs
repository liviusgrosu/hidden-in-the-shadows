//Author: Ryan Randive
//File Name: Stepping on Mine
//Project Name: Hidden In the Shadows
//Creation Date: Fri, Jan 17, 2014
//Date Modified: Sun Jan 19, 2014
//Description: what happens when a player hits a mine
using UnityEngine;
using System.Collections;

public class SteppingOnMine : MonoBehaviour {
	
	public bool isPlayerHit;
	public GameObject mine;
	
	// Use this for initialization
	void Start () {
		
		//assigns the mine as itself
		mine = this.gameObject;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		//if the mine collides with a player
		if(other.gameObject.CompareTag("Player"))
		{
			//player is hit
			isPlayerHit = true;
			//tells the  player that they are stunned
			other.gameObject.SendMessageUpwards("StunPlayer",isPlayerHit,SendMessageOptions.DontRequireReceiver);
			//destroys the mine
			Destroy (mine);
		}
		
		//player is not hit
		isPlayerHit = false;
	}
}
