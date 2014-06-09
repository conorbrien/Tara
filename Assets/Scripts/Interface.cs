using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{

	public bool mouseOver =false;
	public Texture cardButton;
	public float cardButtonButtonXDivision;
	public float cardButtonButtonYDivision;
	public float cardButtonRectWidthDivision;
	public float cardButtonRectHeightDivision;

	//This can be changed to Update when testing resolutions
	void Update()
	{

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
		mouseOver = false;

		Color textureColor = guiTexture.color;
		textureColor.a = .128f;
		guiTexture.color = textureColor;
	}
}
