using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	//variables to hold the X,Y,Z value of the camera
	public float posX;
	public float posY;
	public float posZ;
	public float cameraVelocity;
	public float zoomVelocity;

	// Use this for initialization
	void Start () 
	{
		//Detect initial position of camera
		posX = transform.position.x;
		posY = transform.position.y;
		posZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Left
		if (Input.GetKey (KeyCode.A)) 
		{
			if (posX < 1.803896)
			{
				posX += cameraVelocity*Time.deltaTime;
				//posZ -= cameraVelocity*Time.deltaTime;
				transform.position = new Vector3(posX,posY,posZ);
			}
		}
		//Right
		if (Input.GetKey (KeyCode.D)) 
		{
			if (posX > 0.5800563)
			{
				posX -= cameraVelocity*Time.deltaTime;
				//posZ += cameraVelocity*Time.deltaTime;
				transform.position = new Vector3(posX,posY,posZ);
			}
		}	

		//Down
		if (Input.GetKey (KeyCode.S)) 
		{
			if (posZ < 1.621507)
			{
				posZ += cameraVelocity*Time.deltaTime;
				transform.position = new Vector3(posX,posY,posZ);
			}
		}	

		//Up
		if (Input.GetKey (KeyCode.W)) 
		{
			if (posZ > 1.016423)
			{
				posZ -= cameraVelocity*Time.deltaTime;
				transform.position = new Vector3(posX,posY,posZ);
			}
		}	

		//Zoom Out
		if (Input.GetAxis("Mouse ScrollWheel") < 0) 
		{
			if(posY < 2.27438)
			{
				posY += zoomVelocity*Time.deltaTime;
				transform.position = new Vector3(posX,posY,posZ);
			}
		}

		//Zoom In
		if (Input.GetAxis("Mouse ScrollWheel") > 0) 
		{
			if(posY > 1.58801)
			{
				posY -= zoomVelocity*Time.deltaTime;
				transform.position = new Vector3(posX,posY,posZ);
			}
		}
	}
}
