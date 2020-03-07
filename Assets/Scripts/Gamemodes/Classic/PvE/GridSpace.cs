using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameControllerPvE gameController;

	public void SetSpace()
	{
		if(gameController.playerMove == true) //**
		{
			buttonText.text = gameController.GetPlayerSide();
			button.interactable = false;
			gameController.EndTurn ();
		}
	}

	public void SetGameControllerReference(GameControllerPvE controller)
	{
		gameController = controller;
	}
}
