//Author: Ryan Randive
//File Name: MonsterIsStunned
//Project Name: Hidden In the Shadows
//Creation Date: Sun, Jan 12, 2014
//Date Modified: Sun, Jan 12, 2014
//Description: Stuns monster
using UnityEngine;
using System.Collections;

public class MonsterIsStunned : MonoBehaviour {
	
	public bool isMonsterStunned;
	float monsterMoveSpeed = 5f;
	
	// Use this for initialization
	void Start () {
	
		isMonsterStunned = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void HitMonster(bool isMonsterHit){
	
		//when the monster is hit
		if(isMonsterHit == true)
		{
			//calls subprogram
			StartCoroutine(HowLongIsStun());
			//monster is not longer stunned
			isMonsterHit = false;
		}
	}
	
	//Pre: none
	//Post: none
	//Description: makes monster move slowly for a few seconds
	IEnumerator HowLongIsStun()
	{
		//speed is slow
		monsterMoveSpeed = 0.5f;
		
		yield return new WaitForSeconds(4f);
	
		//speed is fast again
		monsterMoveSpeed = 5f;
		
	}
}
