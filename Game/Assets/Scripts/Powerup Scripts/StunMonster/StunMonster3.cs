using UnityEngine;
using System.Collections;

public class StunMonster3 : MonoBehaviour {
	
	
	static public bool isStunEquipped;
	
	public int numOfStuns;
	public float range = 1000f;
	
	//the time in between shots from the stun
	//public float timeBtwnStuns = 0.2f;
	//the time it takes the stun shot to cool down
	public float stunCoolTime = 3f;
	
	//Randive: a check to see if the enemy is hit
	public bool isMonsterHit;
	
	int playerNum = 3;
	
	
	// Use this for initialization
	void Start () {
		
		isStunEquipped = true;
		isMonsterHit = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//isStunEquipped = true;
		
		if(isStunEquipped == true)
		{
			stunCoolTime -= Time.deltaTime;
			
			if(stunCoolTime < 0)
			{
				stunCoolTime = 0;
			}
			
			if(Input.GetAxis("P" + playerNum + " Fire")>0)
			{
				if(stunCoolTime <= 0 && numOfStuns > 0)
				{
					UseStun();
				}
			}
			
			if(numOfStuns == 0)
			{
				isStunEquipped = false;
				//so the next time you pick it up, you have a full set of stuns
				numOfStuns = 3;
			}
		}
	
	}
	
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
				//if(rigidbody.gameObject.CompareTag("Monster"))
				//{
					isMonsterHit = true;
					//Randive: applies damage to to objects with the give damage subprogram
					hit.collider.SendMessageUpwards("HitMonster", isMonsterHit, SendMessageOptions.DontRequireReceiver);
					isMonsterHit = false;
				//}
			}
			
			numOfStuns -= 1;
			stunCoolTime = 3f;
		}
	}
	
	void OnGUI () 
	{
		if(isStunEquipped == true)
		{
			GUI.Box (new Rect (0,Screen.height/2 + 25,100,25), "Stun Equipped");
			GUI.Box (new Rect (0,Screen.height/2 + 50,100,25), numOfStuns + " stuns left");
		}
	}
}
