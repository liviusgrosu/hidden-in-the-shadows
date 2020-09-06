//Author: Ryan Randive
//File Name: MonsterStunMines
//Project Name: Hidden In the Shadows
//Creation Date: Thu, Jan 16, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Places a mine so the monster can stun players
using UnityEngine;
using System.Collections;

public class MonsterStunMines : MonoBehaviour {
	
	//if mine is equipped
	static public bool isMineEquipped;
	//range at which player can throw mine
	public float range = 1f;
	
	public GameObject mine;
	
	// Use this for initialization
	void Start () {
	
		//isMineEquipped = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isMineEquipped == true)
		{
			PlaceMine();
		}
	}
	
	void PlaceMine()
	{
		if(isMineEquipped == true)
		{
			//Randive: a hit detection 
			RaycastHit hit;
			//Randive: this is the ray the it emitted from the user, in the forward direction being pointed at
			Vector3 directionRay = transform.TransformDirection(Vector3.forward);
			//Randive: draws the ray on the screen as far as the range is
			Debug.DrawRay(transform.position, directionRay * range, Color.red);
			
			//if player presses fire button
			if(Input.GetAxis("P2 Fire")>0)
			{
				//Randive: if the ray it emitted 
				if(Physics.Raycast(transform.position, directionRay, out hit, range))
				{
					//Randive: if the ray hits an object (rigid body object specifically)
					if(hit.rigidbody)
					{
						//unequipps mine
						isMineEquipped = false;
						
						//creates an instance of a mine at that location
						Instantiate(mine, hit.point, Quaternion.identity);
					}
				}
			}
		}	
	}
	
	void OnGUI () 
	{
		//tells monster if the mine if equipped
		if(isMineEquipped == true)
		{
			GUI.Box (new Rect (Screen.width/2,25,150,25), "Mine Equipped");
		}
	}
}
