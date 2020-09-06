//Author: Ryan Randive
//File Name: RandomObjectSpawnMansion
//Project Name: Hidden In the Shadows
//Creation Date: Sat, Jan 11, 2014
//Date Modified: Sun Jan 19, 2014
//Description: Spawns the objects in the mansion map
using UnityEngine;
using System.Collections;


public class RandomObjectSpawnMansion : MonoBehaviour {
	
	public int spawnChoice;
	
	bool shouldSpawn;
	bool noSpawn;
	public float timerOne = 0.0f;
	
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
	
	    if(noSpawn == true)
		{
			timerOne += Time.deltaTime;
		}
		
		if(timerOne >= 10)
		{
			noSpawn = false;
			timerOne = 0;
			SpawnPowerup();
		}
		
		
	}
	
	public void SpawnPowerup(){
		
        spawnChoice = Mathf.Abs(Random.Range(1,6));
		Transform location;
		
		if(spawnChoice == 1)
		{
			powerupPosition = new Vector3(-1f,1f,9f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 2)
		{
			powerupPosition = new Vector3(-12.65335f,1.6644673f,-4.936543f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 3)
		{
			powerupPosition = new Vector3(9.970778f,0.7226367f,-9.694898f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 4)
		{
			powerupPosition = new Vector3(8.3893629f,-3.323613f,-1.175485f);
			PowerupChoice(powerupPosition);
		}
		
		else if(spawnChoice == 5)
		{
			powerupPosition = new Vector3(12.02328f,-0.914438f,9.711394f);
			PowerupChoice(powerupPosition);
		}
		
	}
	
	public void PowerupChoice(Vector3 powerupPosition)
	{
		GameObject tempPowerup = (GameObject)Instantiate(powerupItem, powerupPosition, Quaternion.identity);
		noSpawn = true;
		timerOne = 0;
		StartCoroutine(PowerupLifeTime(tempPowerup));
	}
	
	//public void 
	IEnumerator PowerupLifeTime(GameObject tempPowerup){
	
		objectLife = 10;
			 	
		yield return new WaitForSeconds(objectLife);

		Destroy(tempPowerup);
}
}