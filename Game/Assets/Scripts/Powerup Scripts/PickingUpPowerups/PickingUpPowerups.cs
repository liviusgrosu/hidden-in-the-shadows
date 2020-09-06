//Author: Ryan Randive
//File Name: PickingUpPowerups
//Project Name: Hidden In the Shadows
//Creation Date: Sat, Jan 11, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Darkens the map
using UnityEngine;
using System.Collections;

public class PickingUpPowerups : MonoBehaviour {
	
	//the player
	public GameObject player;
	//the powerupobject
	GameObject powerupObject;
	
	//checks which powerup is equipped
	public bool isStunEquipped;
	public bool isInvisibleEquipped;
	public bool isBoostEquipped;
	
	// Use this for initialization
	void Start () {
	 
		isStunEquipped = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		//if the player collides with a powerup
		if(other.gameObject.CompareTag("Powerup"))
		{
			//randomly chooses powerup
			int whichPowerup = Mathf.Abs(Random.Range(1,4));
			
			//destroys the powerups
			Destroy(other.gameObject);
			
			//Stun Powerup
			if(whichPowerup == 1)
			{
				isStunEquipped = true;
				StunMonster.isStunEquipped = true;
			}
			
			//Invisibility Powerup
			else if(whichPowerup == 2)
			{
				isInvisibleEquipped = true;
				PlayerInvisible.isPlayerInvisible = true;
			}
			
			//Speed Powerup
			else if(whichPowerup == 3)
			{
				isBoostEquipped = true;
				CharacterControl.isBoostEquipped = true;
			}
			
			
			isStunEquipped = false;
	 		isInvisibleEquipped = false;
			isBoostEquipped = false;
			
		}
	}
}
