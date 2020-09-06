using UnityEngine;
using System.Collections;

public class PlayerInvisible4 : MonoBehaviour {
	
	public GameObject player;
	public static bool isPlayerInvisible;
	
	// Use this for initialization
	void Start () {
		
		isPlayerInvisible = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(isPlayerInvisible == true)
		{
			StartCoroutine(PlayerInvisibleTime());
			isPlayerInvisible = false;
		}
	
	}
	
	IEnumerator PlayerInvisibleTime(){
	
		player.renderer.enabled = false;
		
		yield return new WaitForSeconds(20f);
		
		player.renderer.enabled = true;
		
	}
	
	void OnGUI () 
	{
		if(player.renderer.enabled == false)
		{
			GUI.Box (new Rect (Screen.width/2,Screen.height/2 + 25,150,25), "Invisibility Equipped");
		}
	}
}