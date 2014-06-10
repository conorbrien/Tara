using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{

	public Color texturecolorused;
	bool mouseOver =false;
	bool mouseClick = false;
	public Texture cardButton;
	Color originalColor;
	public float guiRatioX;
	public float guiRatioY;
	public float nativeWidth;
	public float nativeHeight;
	public float adjustedWidth;
	public float multiplyFactor;
	public float insetX;
	public float insetY;
	public float insetWidth;
	public float insetHeight;


	//This can be changed to Update when testing resolutions
	void Start()
	{


		originalColor = guiTexture.color;
		cardButton = this.GetComponent<GUITexture> ().texture;
	}

	void OnGUI()
	{
		guiRatioX = Screen.width /nativeWidth;
		guiRatioY = Screen.height /nativeHeight;
		
		multiplyFactor = (guiRatioX + guiRatioY) /2;
		
		insetX = this.GetComponent<GUITexture>().pixelInset.x;
		insetY = this.GetComponent<GUITexture>().pixelInset.y;
		insetWidth = this.GetComponent<GUITexture>().pixelInset.width;
		insetHeight = this.GetComponent<GUITexture>().pixelInset.height;
		adjustedWidth = nativeWidth * (guiRatioX / guiRatioY);

		//Rect inset = new Rect(0, 0, cardButton.width, cardButton.height);
		insetX *= multiplyFactor;
		insetY *= multiplyFactor;
		insetWidth *= multiplyFactor;
		insetHeight *= multiplyFactor;
		Rect inset = new Rect(0, 0, cardButton.width * guiRatioX, cardButton.height *guiRatioY);
		//Rect inset = new Rect(insetX, insetY, insetWidth, insetHeight);
		this.GetComponent<GUITexture> ().pixelInset = inset;

	}

	void OnMouseOver()
	{
		mouseOver = true;
		Color textureColor = guiTexture.color;
		textureColor.a = 1f;
		guiTexture.color = textureColor;
	}

	void OnMouseExit()
	{
		if (mouseClick == false) 
		{
			mouseOver = false;
			Color textureColor = guiTexture.color;
			textureColor.a = .128f;
			guiTexture.color = textureColor;
		}
	}

	void OnMouseDown()
	{
		if (mouseClick == false) 
		{
			Color textureColor = guiTexture.color;
			textureColor.a = 1f;
			mouseClick = !mouseClick;
			guiTexture.color = texturecolorused;
		}
		else 
		{
			mouseClick = !mouseClick;
			guiTexture.color = originalColor;
		}
	}
}
