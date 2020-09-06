//Author: Ryan Randive
//File Name: RandomObjectSpawn
//Project Name: Hidden In the Shadows
//Creation Date: Sat, Jan 11, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Spawns the objects in the map
using UnityEngine;
using System.Collections;


public class RandomObjectSpawn : MonoBehaviour {
	
	//random choice as to where it will spawm
	public int spawnChoice;
	
	//whether it should spawn or not
	bool shouldSpawn;
	bool noSpawn;
	public float timerOne = 0.0f;
	
	//time the object exists in one spot
	public int objectLife; 
	public GameObject powerupItem;
	Vector3 powerupPosition;
	
	public bool isObjectAlive = false;
	
	// Use this for initialization
	void Start () {
		
		noSpawn = true;
		shouldSpawn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		//when the object isnt spawned
	    if(noSpawn == true)
		{
			//increase timer to when the next powerup will spawn
			timerOne += Time.deltaTime;
		}
		
		//if the timer hits 10 seconds
		if(timerOne >= 10)
		{
			//spawns the powerup
			noSpawn = false;
			timerOne = 0;
			SpawnPowerup();
		}
		
		
	}
	
	//Pre: none
	//Post: none
	//Description: randomly choose where in the map to spawn the powerup
	public void SpawnPowerup(){
		
		//randomly choose where to spawn
        spawnChoice = Mathf.Abs(Random.Range(1,6));
		Transform location;
		
		//5 positions as to where the powerup can spawn
		if(spawnChoice == 1)
		{
			powerupPosition = new Vector3(29.88717f,21.03424f,32.68854f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 2)
		{
			powerupPosition = new Vector3(39.50623f,35.38276f,2.367467f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 3)
		{
			powerupPosition = new Vector3(-33.34642f,26.28466f,29.39409f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 4)
		{
			powerupPosition = new Vector3(-53.14084f,74.02935f,-31.92119f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 5)
		{
			powerupPosition = new Vector3(-10.52001f,41.83567f,-24.83682f);
			PowerupChoice(powerupPosition);
		}
		
	}
	
	//Pre: takes position the powerup is at
	//Post: destroys powerup 
	//Description: creates the powerup and lets it stay in one spot until moving it somewhere else
	public void PowerupChoice(Vector3 powerupPosition)
	{
		//creates an instance of a powerup
		GameObject tempPowerup = (GameObject)Instantiate(powerupItem, powerupPosition, Quaternion.identity);
		noSpawn = true;
		timerOne = 0;
		StartCoroutine(PowerupLifeTime(tempPowerup));
	}
	
	//Pre: takes powerup
	//Post: destorys powerup
	//Description: destroys powerup after 10 seconds
	IEnumerator PowerupLifeTime(GameObject tempPowerup){
	
		objectLife = 10;
			 	
		//wait 10 seconds
		yield return new WaitForSeconds(objectLife);
		
		//destroys powerup
		Destroy(tempPowerup);
}
}