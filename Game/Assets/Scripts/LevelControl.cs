using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	
	public bool IsBedRoom = false;
	
	// this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
	}
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseUp()
	{
		if(IsBedRoom)
		{
			Application.LoadLevel(2);
		}
		else
		{
			Application.LoadLevel(3);
		}
		
	}
}