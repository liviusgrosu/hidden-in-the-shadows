//Author: Ryan Randive
//File Name: Stun Monster
//Project Name: Hidden In the Shadows
//Creation Date: Sun, Jan 12, 2014
//Date Modified: Sun 19, 2014
//Description: Stuns monster if the player shoots it 
using UnityEngine;
using System.Collections;

public class StunMonster : MonoBehaviour {
	
	//checks to see if stun is equipped
	static public bool isStunEquipped;
	
	public int numOfStuns;
	
	//range at which the player can hit the monster
	public float range = 1000f;
	
	//the time it takes the stun shot to cool down
	public float stunCoolTime = 3f;
	
	//Randive: a check to see if the enemy is hit
	public bool isMonsterHit;
	
	int playerNum = 1;
	
	
	// Use this for initialization
	void Start () {
		
		isMonsterHit = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isStunEquipped == true)
		{
			//the cool down time is decreased
			stunCoolTime -= Time.deltaTime;
			
			//prevents cool time from going below zero
			if(stunCoolTime < 0)
			{
				stunCoolTime = 0;
			}
			
			//if player hits shoot button
			if(Input.GetAxis("P" + playerNum + " Fire")>0)
			{
				//if player has stuns and the shot is cool
				if(stunCoolTime <= 0 && numOfStuns > 0)
				{
					UseStun();
				}
			}
			
			//run out of stuns
			if(numOfStuns == 0)
			{
				//item is unequipped
				isStunEquipped = false;
				//so the next time you pick it up, you have a full set of stuns
				numOfStuns = 3;
			}
		}
	
	}
	
	//Pre: none
	//Post: sends is frozen to monster
	//Description: Determines if the player's shot hits the monster
	public void UseStun(){
		
		//Randive: a hit detection 
		RaycastHit hit;
		//Randive: this is the ray the it emitted from the user, in the forward direction being pointed at
		Vector3 directionRay = transform.TransformDirection(Vector3.forward);
		//Randive: draws the ray on the screen as far as the range is
		Debug.DrawRay(transform.position, directionRay * range, Color.red);
		
		
		
		//Randive: if the ray it emitted 
		if(Physics.Raycast(transform.position, directionRay, out hit, range))
		{
			//Randive: if the ray hits an object (rigid body object specifically)
			if(hit.rigidbody && hit.rigidbody.gameObject.CompareTag("Monster"))
			{
				isMonsterHit = true;
				//Randive: applies damage to to objects with the give damage subprogram
				hit.collider.SendMessageUpwards("HitMonster", isMonsterHit, SendMessageOptions.DontRequireReceiver);
				
				isMonsterHit = false;
			}
			
			numOfStuns -= 1;
			stunCoolTime = 3f;
		}
	}
	
	void OnGUI () 
	{
		//tells user they have a stun and the number of shots left
		if(isStunEquipped == true)
		{
			GUI.Box (new Rect (0,25,100,25), "Stun Equipped");
			GUI.Box (new Rect (0,50,100,25), numOfStuns + " stuns left");
		}
	}
}
