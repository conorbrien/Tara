using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{

	public Color texturecolorused;
	bool mouseOver =false;
	bool mouseClick = false;
	public Texture cardButton;
	public float cardButtonButtonXDivision;
	public float cardButtonButtonYDivision;
	public float cardButtonRectWidthDivision;
	public float cardButtonRectHeightDivision;
	Color originalColor;

	//This can be changed to Update when testing resolutions
	void Start()
	{
		originalColor = guiTexture.color;
		cardButton = this.GetComponent<GUITexture> ().texture;
		float buttonX = (Screen.width - (cardButton.width /cardButtonButtonXDivision));
		float buttonY = (Screen.height -(cardButton.height /cardButtonButtonYDivision));
		Rect inset = new Rect(buttonX, buttonY, cardButton.width / cardButtonRectWidthDivision, cardButton.height / cardButtonRectHeightDivision);
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
