//Author: Savan Patel
//File Name: Teleport
//Project Name: Hidden In the Shadows
//Creation Date: Thu, Jan 16, 2014
//Date Modified: Sun Jan 19, 2014
//Description: lets player teleport up ladder
using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	//if player is teleported
	public bool teleported = false;
	
	//player destination
	public Teleport destination;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c)
	{
		if(!teleported)
		{
			destination.teleported = true;
			c.gameObject.transform.position=destination.gameObject.transform.position;
		}
	}
	void OnTriggerExit(Collider c)
	{
		teleported=false;
	}
}
