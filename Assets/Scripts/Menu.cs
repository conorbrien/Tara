using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public Texture menuCard;

	//floats to keep track of Ratio textures should display off
	float guiRatioX;
	float guiRatioY;
	
	//public floats to declare Native Resolution from which all is scaled
	public float nativeWidth;
	public float nativeHeight;
	
	//Declares a public float to be used as Texture Master Scale
	public float masterScale;

	void Start()
	{	
		//Assigns texture in inspector to cardButton variable
		menuCard = this.GetComponent<GUITexture> ().texture;
	}

	void OnGUI()
	{
		//Calculated the require scaling based off native Width and Height against what user has
		//These are declared in OnGUI in the event of resolution changes during playtime
		
		guiRatioX = Screen.width /nativeWidth;
		guiRatioY = Screen.height /nativeHeight;
		
		//Calculates the Start position for X Based off Current ScreenWidth and the texture size (and its ratio scale)
		float buttonX = 0;
		
		//Calculates the Start position for Y Based off Current ScreenHeight and the texture size (and its ratio scale)
		float buttonY = 0;
		
		//Creates the Rectangle for the UI Based off buttonX and buttonY above, multiplies the cardButton width and Height by Ratio so its the correct scale
		Rect inset = new Rect(buttonX, buttonY, (menuCard.width * guiRatioX) / masterScale, (menuCard.height * guiRatioY) / masterScale);
		
		//Set the pixelInset value of GUI Texture to the rectangle declared above
		this.GetComponent<GUITexture> ().pixelInset = inset;
		
	}
}
