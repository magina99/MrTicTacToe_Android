using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//////////////////////////////////////
/*
IntroByte Entertainment
Mr. TicTacToe - GameControllerPvE
*/
//////////////////////////////////////

[System.Serializable]
public class Player
{
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColor
{
	public Color panelColor;
	public Color textColor;
}

public class GameControllerPvE : MonoBehaviour 
{
	public GameObject gameOverPanel;
	public GameObject restartButton;
	public GameObject startInfo;
	public GameObject finishLine0;
	public GameObject finishLine1;
	public GameObject finishLine2;
	public GameObject finishLine3;
	public GameObject finishLine4;
	public GameObject finishLine5;
	public GameObject finishLine6;
	public GameObject finishLine7;
	public GameObject scoreTextBox;
	public GameObject statisticsWarning;
	public Text gameOverText;
	public Text xPlayersScoreText;
	public Text oPlayersScoreText;
	public Text xTotalWinsText;
	public Text oTotalWinsText;
	public Text pvcTotalGamesText;
	public Text[] buttonList;
    public Text bigPlayerSymbol;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
	public int xPlayersScore;
	public int oPlayersScore;
	public Button mainMenuButton;
	public bool playerMove; //**
	public float delay; //**

	public int totalXWinsPVC;
	public int totalOWinsPVC;
	public int totalPlayedPVC;

	private string playerSide;
	private string computerSide; //**
	private int moveCount;
	private int value; //**

	void Awake()
	{
		gameOverPanel.SetActive(false);
		SetGameControllerReferenceOnButtons ();
		moveCount = 0;
		//restartButton.SetActive (false);
		playerMove = true; //**

		finishLine0.SetActive (false);
		finishLine1.SetActive (false);
		finishLine2.SetActive (false);
		finishLine3.SetActive (false);
		finishLine4.SetActive (false);
		finishLine5.SetActive (false);
		finishLine6.SetActive (false);
		finishLine7.SetActive (false);

		xTotalWinsText.text = PlayerPrefs.GetInt ("XTotalWinsPVC", 0).ToString ();
		oTotalWinsText.text = PlayerPrefs.GetInt ("OTotalWinsPVC", 0).ToString ();
		pvcTotalGamesText.text = PlayerPrefs.GetInt ("TotalPVCGames", 0).ToString ();
	}

	//**
	void Update()
	{
		if(playerMove == false)
		{
			delay += delay * Time.deltaTime;

			if(delay >= 75)
			{
				value = Random.Range (0, 8);

				if(buttonList [value].GetComponentInParent<Button> ().interactable == true)
				{
					buttonList [value].text = GetComputerSide ();
					buttonList [value].GetComponentInParent<Button> ().interactable = false;
					EndTurn ();
				}
			}
		}
	}
	//**

	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].GetComponentInParent<GridSpace> ().SetGameControllerReference (this);
		}
	}

	public void SetStartingSide (string startingSide)
	{
		playerSide = startingSide;

		if(playerSide == "X")
		{
			computerSide = "O"; //**
			SetPlayerColors (playerX, playerO);
		}
		else
		{
			computerSide = "X"; //**
			SetPlayerColors (playerO, playerX);
		}

		StartGame ();
	}

	void StartGame()
	{
		SetBoardInteractable (true);
		SetPlayerButtons (false);
		startInfo.SetActive (false);
		SetMainMenuInteractable (false);
	}

	public string GetPlayerSide()
	{
		return playerSide;
	}

	//**
	public string GetComputerSide()
	{
		return computerSide;
	}
	//**

	public void EndTurn()
	{
		moveCount++;

		if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
		{
			GameOver (playerSide);
			finishLine0.SetActive (true);
		}

		else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
		{
			GameOver (playerSide);
			finishLine1.SetActive (true);
		}

		else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver (playerSide);
			finishLine2.SetActive (true);
		}

		else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver (playerSide);
			finishLine3.SetActive (true);
		}

		else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
		{
			GameOver (playerSide);
			finishLine4.SetActive (true);
		}

		else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver (playerSide);
			finishLine5.SetActive (true);
		}

		else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver (playerSide);
			finishLine6.SetActive (true);
		}

		else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver (playerSide);
			finishLine7.SetActive (true);
		}

		//**
		else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
		{
			GameOver (computerSide);
			finishLine0.SetActive (true);
		}

		else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
		{
			GameOver (computerSide);
			finishLine1.SetActive (true);
		}

		else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
		{
			GameOver (computerSide);
			finishLine2.SetActive (true);
		}

		else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
		{
			GameOver (computerSide);
			finishLine3.SetActive (true);
		}

		else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
		{
			GameOver (computerSide);
			finishLine4.SetActive (true);
		}

		else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
		{
			GameOver (computerSide);
			finishLine5.SetActive (true);
		}

		else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
		{
			GameOver (computerSide);
			finishLine6.SetActive (true);
		}

		else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
		{
			GameOver (computerSide);
			finishLine7.SetActive (true);
		}
		//**

		else if (moveCount >= 9)
		{
			
			GameOver ("draw");
		}

		else
		{
			ChangeSides ();
			delay = 10; //**
		}
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;

		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	void GameOver(string winningPlayer)
	{
		SetBoardInteractable (false);

		if(winningPlayer == "draw")
		{
			gameOverPanel.SetActive (true);
			gameOverText.text = "Draw!";
			SetPlayerColorsInactive ();

            bigPlayerSymbol.text = "XO";

			totalPlayedPVC = PlayerPrefs.GetInt("TotalPVCGames", 0) + 1;
			PlayerPrefs.SetInt ("TotalPVCGames", totalPlayedPVC);
			pvcTotalGamesText.text = totalPlayedPVC.ToString ();
		}
		else
		{
			gameOverPanel.SetActive (true);
			gameOverText.text = winningPlayer + " Wins!";

            if(winningPlayer == "X")
            {
                bigPlayerSymbol.text = "X";
            }
            else if(winningPlayer == "O")
            {
                bigPlayerSymbol.text = "O";
            }
		}


		if(winningPlayer == "X")
		{
			xPlayersScore++;
			xPlayersScoreText.text = xPlayersScore.ToString ();

			totalXWinsPVC = PlayerPrefs.GetInt("XTotalWinsPVC", 0) + 1;
			PlayerPrefs.SetInt ("XTotalWinsPVC", totalXWinsPVC);
			xTotalWinsText.text = totalXWinsPVC.ToString ();

			totalPlayedPVC = PlayerPrefs.GetInt("TotalPVCGames", 0) + 1;
			PlayerPrefs.SetInt ("TotalPVCGames", totalPlayedPVC);
			pvcTotalGamesText.text = totalPlayedPVC.ToString ();
		}
		else
		{
			if(winningPlayer == "O")
			{
				oPlayersScore++;
				oPlayersScoreText.text = oPlayersScore.ToString ();

				totalOWinsPVC = PlayerPrefs.GetInt("OTotalWinsPVC", 0) + 1;
				PlayerPrefs.SetInt ("OTotalWinsPVC", totalOWinsPVC);
				oTotalWinsText.text = totalOWinsPVC.ToString ();

				totalPlayedPVC = PlayerPrefs.GetInt("TotalPVCGames", 0) + 1;
				PlayerPrefs.SetInt ("TotalPVCGames", totalPlayedPVC);
				pvcTotalGamesText.text = totalPlayedPVC.ToString ();
			}
		}

		//restartButton.SetActive (true);

		SetMainMenuInteractable (true);
	}

	void ChangeSides()
	{
		//playerSide = (playerSide == "X") ? "O" : "X";
		playerMove = (playerMove == true) ? false : true; //**

		//if(playerSide == "X")
		if(playerMove == true) //**
		{
			SetPlayerColors (playerX, playerO);
		}
		else
		{
			SetPlayerColors (playerO, playerX);
		}
	}

	/*
	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
	}
	*/

	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive (false);
		//restartButton.SetActive (false);
		finishLine0.SetActive (false);
		finishLine1.SetActive (false);
		finishLine2.SetActive (false);
		finishLine3.SetActive (false);
		finishLine4.SetActive (false);
		finishLine5.SetActive (false);
		finishLine6.SetActive (false);
		finishLine7.SetActive (false);
		SetPlayerButtons (true);
		SetPlayerColorsInactive ();
		startInfo.SetActive (true);
		playerMove = true; //**
		delay = 10; //**

		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].text = "";
		}
	}

	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

	void SetMainMenuInteractable(bool toggle)
	{
		mainMenuButton.interactable = toggle;
	}

	void SetPlayerButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetPlayerColorsInactive()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;

		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}

	public void ResetStatisticsPVC ()
	{
		PlayerPrefs.DeleteKey("XTotalWinsPVC");
		PlayerPrefs.DeleteKey("OTotalWinsPVC");
		PlayerPrefs.DeleteKey("TotalPVCGames");
		xTotalWinsText.text = "0";
		oTotalWinsText.text = "0";
		pvcTotalGamesText.text = "0";

		statisticsWarning.SetActive (false);
	}
}