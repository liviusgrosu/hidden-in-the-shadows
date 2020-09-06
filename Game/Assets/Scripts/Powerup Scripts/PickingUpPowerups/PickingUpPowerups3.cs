using UnityEngine;
using System.Collections;

public class PickingUpPowerups3 : MonoBehaviour {
	
	//ATTACH THIS SCRIPT TO EVERY PLAYER EXCEPT THE MONSTER
	public GameObject player;
	GameObject powerupObject;
	
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
		if(other.gameObject.CompareTag("Powerup"))
		{
			int whichPowerup = Mathf.Abs(Random.Range(1,4));
			
			Destroy(other.gameObject);
			
			//Stun Powerup
			if(whichPowerup == 1)
			{
				isStunEquipped = true;
				//collider.SendMessageUpwards("Update", isStunEquipped, SendMessageOptions.RequireReceiver);
				StunMonster3.isStunEquipped = true;
			}
			
			//Invisibility Powerup
			else if(whichPowerup == 2)
			{
				isInvisibleEquipped = true;
				//collider.SendMessageUpwards("Update", isInvisibleEquipped, SendMessageOptions.RequireReceiver);
				PlayerInvisible3.isPlayerInvisible = true;
			}
			
			//Speed Powerup
			else if(whichPowerup == 3)
			{
				isBoostEquipped = true;
				CharacterControl3.isBoostEquipped = true;
			}
			
			
			isStunEquipped = false;
	 		isInvisibleEquipped = false;
			isBoostEquipped = false;
			
		}
	}
}
