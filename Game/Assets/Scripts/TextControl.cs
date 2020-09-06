using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {
	
	public bool isQuitButton = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
		//change the color of the text
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseUp()
	{
		if (isQuitButton)
		{
			Application.Quit();
		}
		else
		{
			Application.LoadLevel(1);
		}
	}
}
