//Author: Savan Patel and Mr.Lane
//File Name: CharacterControl2
//Project Name: Final Destiny
//Creation Date: May 15 2013
//Date Modified: June 12, 2013
//Description: This is the script that enables the user to move around the map, move the camera around, and allows the user to jump
using UnityEngine;
using System.Collections;

public class CharacterControl2 : MonoBehaviour {
	
	//This controls the players movement
	public float playerMovementSpeed = 2f;
	//This controls the speed of the camera that the user is able to control
	public float mouseSpeed = 2f;
	
	//this controls how much of a rotation occurs vertically
	float verticalRotation = 0f;
	//this is the max rotation that is able to occur
	public float UpDownRotation = 60.0f;
	
	//this controls the speed that the character is going to jump at
	public float jumpSpeed = 5f;
	
	//This is a vector 3 stores the amount of force that the character undergoes
	public Vector3 gravity = Vector3.zero;
	//this is a variable to increase the speed of gravity acting on the character
	public float gravityIncrease = 5.0f;
	
	//this is a bool statement that tells us if the character is jumping or if they are not jumping
	protected bool isJump;

    //LANE - UPDATE: Use this so you can reuse the same script for all players simply by specifying the player number
    public string playerNumber = "2";
	
	//public bool isMonsterHit;
	public static bool isMonsterBoost;
	
	protected bool isCrouch;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		MonsterBoost();
		
		//This code is for mouse rotation
		
		//this gets the mouse's x position and makes it faster
        //LANE - UPDATE
		//set the horizontal rotation to 0
        float leftRightRot = 0f;
		//if the player is moving the camera on the horizontal axis store that into a variable
        float rightXAxis = Input.GetAxis("P" + playerNumber + " Right Analog X");
		//if the RightXaxis value is 1 or -1 then run the following code
        if (rightXAxis == 1f || rightXAxis == -1f)
        {
			//stores the mouse movemnt in a variable
            leftRightRot = rightXAxis * mouseSpeed;
        }
		
		//this draws the new position of the mouse onto the screen
		transform.Rotate(0,leftRightRot,0);
		
		//This line lets the character rotate up and down
        //LANE - UPDATE
		//if the player is moving the camera on the vertical axis store that into a variable
        float rightYAxis = Input.GetAxis("P" + playerNumber + " Right Analog Y");
		//if the RightYaxis value is 1 or -1 then run the following code
        if (rightYAxis == 1f || rightYAxis == -1f)
        {
			//stores the mouse movemnt in a variable
            verticalRotation -= rightYAxis * mouseSpeed;
        }

		//this line stops the character from looking up or down past a straight rotation
		verticalRotation = Mathf.Clamp(verticalRotation,-UpDownRotation,UpDownRotation);
		
		//LANE - UPDATE
		GameObject.Find("P" + playerNumber + "Cam").camera.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);

		//The following code is for the character movement
		//this calculates how fast the character is moving vertically
        //LANE - UPDATE
		//set ahedspeed to 0
        float ahedSpeed = 0f;
		//store the user left analog input into a variable
        float yLeftYAxis = Input.GetAxis("P" + playerNumber + " Left Analog Y");
		//if the left analog y axis input is 1 or -1 run the following code
        if (yLeftYAxis == 1f || yLeftYAxis == -1f)
        {
			//calculate how much the character is going to move
            ahedSpeed = yLeftYAxis * playerMovementSpeed;
        }

        //LANE - UPDATE
		//set sidespeed to 0
        float sideSpeed = 0f;
		//store the user left analog input into a variable		
        float xLeftXAxis = Input.GetAxis("P" + playerNumber + " Left Analog X");
		//if the left analog X axis input is 1 or -1 run the following code		
        if (xLeftXAxis == 1f || xLeftXAxis == -1f)
        {
			//calculate how much the character is going to move			
            sideSpeed = xLeftXAxis * playerMovementSpeed;
        }
		
		//this is to update the character to move forward
		Vector3 forwardSpeed =  new Vector3(sideSpeed,0,ahedSpeed);
		
		//this line of code allows for the characters direction to take the mouse view into account too, creating an FPS affect
		forwardSpeed = transform.rotation * forwardSpeed;
		
		//this is to rename the character controller making it easier for future use
		CharacterController control = GetComponent <CharacterController>();
		
		// this multiples player movement speed by the forward speed
		forwardSpeed *= playerMovementSpeed;
		
		//if the character is not on the ground
		if(!control.isGrounded)
		{
			//our gravity factors in how much time has passed for the character in the air
		    gravity += Physics.gravity*Time.deltaTime;
		}
		
		//if the character is on the ground
		else
		{
			//reset the graivity acting on the character back to 0
			gravity = Vector3.zero;
			
			//if the character is jumping
			if(isJump)
			{
				//the y axis of the gravity is going to become equal to the jump speed
				gravity.y = jumpSpeed;
			}
		}


        //LANE - UPDATE
        forwardSpeed += gravity;
		//this line of code moves the character
        control.Move(forwardSpeed * Time.deltaTime);

        //LANE - UPDATE
		//if the player presses Jump axis button and the character is on the ground
        if (Input.GetButton("P" + playerNumber + " Jump") && control.isGrounded)
		{
			//the character is jumping
			isJump=true;
		}
		
		//if the character is not grounded
		if(!control.isGrounded)
		{
			//the player is not jumping
			isJump = false;
		}
				
		if(Input.GetAxis("P" + playerNumber + " Crouch")>0 && !isCrouch)
		{
			transform.localScale = new Vector3(1,0.25f,1);
			isCrouch = true;
		}
		else if(Input.GetAxis("P" + playerNumber + " Crouch")==0 && isCrouch)
		{
			transform.localScale = new Vector3(1,1,1);
			transform.Translate(0,0.8f,0);
			isCrouch = false;
		}
		
	
	}
	
	public void HitMonster(bool isMonsterHit)
	{
		if(isMonsterHit == true)
		{
			StartCoroutine(HowLongIsStun());
			isMonsterHit = false;
		}
	}
	
	IEnumerator HowLongIsStun()
	{
		
		float monsterMoveSpeed = 0.5f;
		float monsterJump = 0f;
		
		playerMovementSpeed = monsterMoveSpeed;
		jumpSpeed = monsterJump;
		
		yield return new WaitForSeconds(4f);
	
		playerMovementSpeed = 2f;
		jumpSpeed = 5f;
	}
	
	public void MonsterBoost()
	{
		if(isMonsterBoost == true)
		{
			StartCoroutine(HowLongIsBoost());
			isMonsterBoost = false;
		}
		
	}
	
	IEnumerator HowLongIsBoost()
	{
		float monsterMoveSpeed = 3.5f;
		float monsterJump = 6f;
		
		playerMovementSpeed = monsterMoveSpeed;
		jumpSpeed = monsterJump;
		
		yield return new WaitForSeconds(5f);
	
		playerMovementSpeed = 2f;
		jumpSpeed = 5f;
	}
	
	void OnGUI () 
	{
		GUI.Box (new Rect (Screen.width/2,0,100,25), "Monster");
		if(playerMovementSpeed > 2f)
		{
			GUI.Box (new Rect (Screen.width/2,25,100,25), "Boost Equipped");
		}
	}
	
}