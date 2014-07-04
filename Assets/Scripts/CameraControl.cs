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
			posX += cameraVelocity*Time.deltaTime;
			posZ -= cameraVelocity*Time.deltaTime;
			transform.position = new Vector3(posX,posY,posZ);
		}
		//Right
		if (Input.GetKey (KeyCode.D)) 
		{
			posX -= cameraVelocity*Time.deltaTime;
			posZ += cameraVelocity*Time.deltaTime;
			transform.position = new Vector3(posX,posY,posZ);
		}	

		if (Input.GetKey (KeyCode.S)) 
		{
			posZ += cameraVelocity*Time.deltaTime;
			transform.position = new Vector3(posX,posY,posZ);
		}	

		if (Input.GetKey (KeyCode.W)) 
		{
			posZ -= cameraVelocity*Time.deltaTime;
			transform.position = new Vector3(posX,posY,posZ);
		}	


		if (Input.GetAxis("Mouse ScrollWheel") < 0) 
		{
			posY += zoomVelocity*Time.deltaTime;
			transform.position = new Vector3(posX,posY,posZ);
		}
		//Down
		if (Input.GetAxis("Mouse ScrollWheel") > 0) 
		{
			posY -= zoomVelocity*Time.deltaTime;
			transform.position = new Vector3(posX,posY,posZ);
		}
	}
}
