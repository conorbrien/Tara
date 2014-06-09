using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{
	public Texture moneyButton;

	void OnGUI()
	{

		float buttonX = (Screen.width - moneyButton.width /2.0f);
		float buttonY = (Screen.height - moneyButton.height /2.0f);

		GUI.Button( new Rect(buttonX, buttonY, moneyButton.width /2, moneyButton.height /2.0f),moneyButton ); 
	}
}
