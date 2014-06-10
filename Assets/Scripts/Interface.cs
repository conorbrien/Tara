using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{
	//Public Declaration for the color the texture changes to when OnMouseOver is true
	public Color texturecolorused;

	//boolean to keep track of mouseOver status
	bool mouseOver =false;

	//boolean to keep track of mouseClick status
	bool mouseClick = false;

	//public declaration for texture to be used as primary GUI element
	public Texture cardButton;

	//Non Public Variable for original color - records original color of texture for reset OnMouseExit.
	Color originalColor;

	//floats to keep track of Ratio textures should display off
	float guiRatioX;
	float guiRatioY;

	//public floats to declare Native Resolution from which all is scaled
	public float nativeWidth;
	public float nativeHeight;

	//Iteration Float (For multiple textures)
	public float fromRight;

	//Function called at Start
	void Start()
	{
		//Original Texture Color is recorded
		originalColor = guiTexture.color;

		//Assigns texture in inspector to cardButton variable
		cardButton = this.GetComponent<GUITexture> ().texture;
	}

	void OnGUI()
	{
		//Calculated the require scaling based off native Width and Height against what user has
		//These are declared in OnGUI in the event of resolution changes during playtime

		guiRatioX = Screen.width /nativeWidth;
		guiRatioY = Screen.height /nativeHeight;

		//Calculates the Start position for X Based off Current ScreenWidth and the texture size (and its ratio scale)
		float buttonX = Screen.width - ((cardButton.width *guiRatioX) * fromRight);

		//Calculates the Start position for Y Based off Current ScreenHeight and the texture size (and its ratio scale)
		float buttonY = Screen.height - Screen.height;

		//Creates the Rectangle for the UI Based off buttonX and buttonY above, multiplies the cardButton width and Height by Ratio so its the correct scale
		Rect inset = new Rect(buttonX, buttonY, cardButton.width * guiRatioX, cardButton.height * guiRatioY);

		//Set the pixelInset value of GUI Texture to the rectangle declared above
		this.GetComponent<GUITexture> ().pixelInset = inset;

	}

	void OnMouseOver()
	{
		//Sets mouseOver boolean to true
		mouseOver = true;

		//Creates a variable to take the color set in GUI texture
		Color textureColor = guiTexture.color;

		//Removes Alpha/Transparancy on texture
		textureColor.a = 1f;

		//Shows the color displayed in GUI Texture
		guiTexture.color = textureColor;
	}

	void OnMouseExit()
	{
		//Checks to ensure the button has not been clicked
		if (mouseClick == false) 
		{
			//sets mouseover boolean to false
			mouseOver = false;

			//Creates a variable to store current texture color
			Color textureColor = guiTexture.color;

			//Makes the image transparent again
			textureColor.a = .128f;

			//Assigns changes back to GUITexture
			guiTexture.color = textureColor;
		}
	}

	void OnMouseDown()
	{
		//Checks the button had not been clicked already (enabled)
		if (mouseClick == false) 
		{
			//Creates a variable to assign the guitexture color
			Color textureColor = guiTexture.color;

			//Removes alpha/transparency from texture
			textureColor.a = 1f;

			//toggle MouseClick boolean
			mouseClick = !mouseClick;

			//Change texture color to color set in inspector for used textures
			guiTexture.color = texturecolorused;
		}
		else 
		{
			//toggle MouseClick boolean
			mouseClick = !mouseClick;

			//Revert texture to Original Color
			guiTexture.color = originalColor;
		}
	}
}
