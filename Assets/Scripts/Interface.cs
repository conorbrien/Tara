using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{
	public Texture moneyButton;
	public bool mouseOver =false;

	void OnGUI()
	{

		float buttonX = (Screen.width - (moneyButton.width /2.2f));
		float buttonY = (Screen.height -(moneyButton.height /2.2f));

		GUI.DrawTexture( new Rect(buttonX, buttonY, moneyButton.width /2.2f, moneyButton.height /2.2f),moneyButton, ScaleMode.ScaleToFit, true); 
	}
	void onMouseOver()
	{
		mouseOver = true;
		Debug.Log ("Entered");
	}

	void onMouseExit()
	{
		mouseOver = false;
		Debug.Log ("Exited");
	}
}
