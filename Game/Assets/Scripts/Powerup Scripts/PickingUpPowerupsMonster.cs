//Author: Ryan Randive
//File Name: PickingUpPowerupsMonster
//Project Name: Hidden In the Shadows
//Creation Date: Sat, Jan 18, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Darkens the map
using UnityEngine;
using System.Collections;

public class PickingUpPowerupsMonster : MonoBehaviour {
	
	public GameObject monster;
	GameObject powerupObject;
	
	//check to see which powerup is equipped
	public bool isMapDarkEquipped;
	public bool isMineEquipped;
	public bool isBoostEquipped;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		//if monster collides with a powerup
		if(other.gameObject.CompareTag("Powerup"))
		{
			//randomly chooses powerup
			int whichPowerup = Mathf.Abs(Random.Range(1,4));
						
			//destroys the powerup pickup item
			Destroy(other.gameObject);
			
			//Map dark Powerup
			if(whichPowerup == 1)
			{
				isMapDarkEquipped = true;
				MonsterMapDark.isMapDark = true;
			}
			
			//Mine(stun) Powerup
			else if(whichPowerup == 2)
			{
				isMineEquipped = true;
				MonsterStunMines.isMineEquipped = true;
			}
			
			//Speed Powerup
			else if(whichPowerup == 3)
			{
				isBoostEquipped = true;
				CharacterControl2.isMonsterBoost = true;
			}
			
			isMineEquipped = false;
	 		isMapDarkEquipped = false;
			isBoostEquipped = false;
			
		}
	}
}
