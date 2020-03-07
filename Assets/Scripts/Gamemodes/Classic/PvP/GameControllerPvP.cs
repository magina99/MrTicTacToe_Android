using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//////////////////////////////////////
/*
Diogo Magina
Mr. TicTacToe - GameControllerPvP
*/
//////////////////////////////////////

public class GameControllerPvP : MonoBehaviour 
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
	public Text pvpTotalGamesText;
	public Text[] buttonList;
    public Text bigPlayerSymbol;
    public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
	public int xPlayersScore;
	public int oPlayersScore;
	public Button mainMenuButton;

	public int totalXWins;
	public int totalOWins;
	public int totalPlayedPVP;

	private string playerSide;
	private int moveCount;

	void Awake()
	{
		gameOverPanel.SetActive(false);                                     // Deactivates the textBox that says who won
		SetGameControllerReferenceOnButtons ();                             // Executes the method
		moveCount = 0;                                                      // Resets the number of plays
		//restartButton.SetActive (false);                                    // Deactivates the restart button

        // Deactivates all the win lines
		finishLine0.SetActive (false);
		finishLine1.SetActive (false);
		finishLine2.SetActive (false);
		finishLine3.SetActive (false);
		finishLine4.SetActive (false);
		finishLine5.SetActive (false);
		finishLine6.SetActive (false);
		finishLine7.SetActive (false);

        // Sets the statistics in the Stats Screen
		xTotalWinsText.text = PlayerPrefs.GetInt ("XTotalWins", 0).ToString ();
		oTotalWinsText.text = PlayerPrefs.GetInt ("OTotalWins", 0).ToString ();
		pvpTotalGamesText.text = PlayerPrefs.GetInt ("TotalPVPGames", 0).ToString ();
	}

    /// <summary>
    /// Defines all the buttons so that the code know they exist and how to use them
    /// </summary>
	void SetGameControllerReferenceOnButtons()
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].GetComponentInParent<GridSpacePvP> ().SetGameControllerReference (this);
		}
	}

	public void SetStartingSide (string startingSide)
	{
		playerSide = startingSide;

		if(playerSide == "X")
		{
			SetPlayerColors (playerX, playerO);
		}
		else
		{
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

		else if (moveCount >= 9)
		{

			GameOver ("draw");
		}

		else
		{
			ChangeSides ();
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

            totalPlayedPVP = PlayerPrefs.GetInt("TotalPVPGames", 0) + 1;
			PlayerPrefs.SetInt ("TotalPVPGames", totalPlayedPVP);
			pvpTotalGamesText.text = totalPlayedPVP.ToString ();
		}
		else
		{
			gameOverPanel.SetActive (true);
			gameOverText.text = winningPlayer + " Wins!";

            if (winningPlayer == "X")
            {
                bigPlayerSymbol.text = "X";
            }
            else if (winningPlayer == "O")
            {
                bigPlayerSymbol.text = "O";
            }
        }


		if(winningPlayer == "X")
		{
			xPlayersScore++;
			xPlayersScoreText.text = xPlayersScore.ToString ();

			totalXWins = PlayerPrefs.GetInt("XTotalWins", 0) + 1;
			PlayerPrefs.SetInt ("XTotalWins", totalXWins);
			xTotalWinsText.text = totalXWins.ToString ();

			totalPlayedPVP = PlayerPrefs.GetInt("TotalPVPGames", 0) + 1;
			PlayerPrefs.SetInt ("TotalPVPGames", totalPlayedPVP);
			pvpTotalGamesText.text = totalPlayedPVP.ToString ();
		}
		else
		{
			if(winningPlayer == "O")
			{
				oPlayersScore++;
				oPlayersScoreText.text = oPlayersScore.ToString ();

				totalOWins = PlayerPrefs.GetInt("OTotalWins", 0) + 1;
				PlayerPrefs.SetInt ("OTotalWins", totalOWins);
				oTotalWinsText.text = totalOWins.ToString ();

				totalPlayedPVP = PlayerPrefs.GetInt("TotalPVPGames", 0) + 1;
				PlayerPrefs.SetInt ("TotalPVPGames", totalPlayedPVP);
				pvpTotalGamesText.text = totalPlayedPVP.ToString ();
			}
		}

		//restartButton.SetActive (true);

		SetMainMenuInteractable (true);
	}

	void ChangeSides()
	{
		playerSide = (playerSide == "X") ? "O" : "X";

		if(playerSide == "X")
		{
			SetPlayerColors (playerX, playerO);
		}
		else
		{
			SetPlayerColors (playerO, playerX);
		}
	}
		
    /// <summary>
    /// Restart Game
    /// Executes all the following actions when the player chooses to start another game
    /// </summary>
	public void RestartGame()
	{
		moveCount = 0;                                      // Resets the number of plays
        gameOverPanel.SetActive (false);                    // Deactivates the textBox that says who won
        //restartButton.SetActive (false);                    // Deactivates the restart button

        // Deactivates all the win lines
        finishLine0.SetActive (false);
		finishLine1.SetActive (false);
		finishLine2.SetActive (false);
		finishLine3.SetActive (false);
		finishLine4.SetActive (false);
		finishLine5.SetActive (false);
		finishLine6.SetActive (false);
		finishLine7.SetActive (false);


		SetPlayerButtons (true);                            // Turns ON the interactibility to the player buttons
		SetPlayerColorsInactive();
		startInfo.SetActive (true);                         // Activates the textBox that contains start information

        // Resets all the buttons
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList[i].text = "";
		}
	}

    /// <summary>
    /// Sets the interactibility to the game board
    /// </summary>
    /// <param name="toggle"></param>
	void SetBoardInteractable(bool toggle)
	{
        // For each button of the game board
		for (int i = 0; i < buttonList.Length; i++)
		{
            // If the game hasn´t started, toggles the interactibility to OFF
            // Otherwise, toggles it ON
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

    /// <summary>
    /// Sets the main menu button's interactibility before and after the game starts
    /// </summary>
    /// <param name="toggle"></param>
	void SetMainMenuInteractable(bool toggle)
	{
        // If the game hasn´t started, toggles the interactibility to ON
        // Otherwise, toggles it OFF
        mainMenuButton.interactable = toggle;
	}

    /// <summary>
    /// Sets the players button's interactibility before and after the game starts
    /// </summary>
    /// <param name="toggle"></param>
	void SetPlayerButtons(bool toggle)
	{
        // If the game hasn´t started, toggles the interactibility to ON
        // Otherwise, toggles it OFF
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

    /// <summary>
    /// Sets the color of the inactive player
    /// </summary>
	void SetPlayerColorsInactive()
	{
        // Sets the inactive colors for playerX
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;

        // Sets the inactive colors for PlayerO
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}

    /// <summary>
    /// Resets all the statistics
    /// </summary>
	public void ResetStatistics ()
	{
        // Deletes all the stats values from PlayerPrefs
		PlayerPrefs.DeleteKey("XTotalWins");
		PlayerPrefs.DeleteKey("OTotalWins");
		PlayerPrefs.DeleteKey("TotalPVPGames");

        // Resets the text values from the Stats Screen to 0
		xTotalWinsText.text = "0";
		oTotalWinsText.text = "0";
		pvpTotalGamesText.text = "0";

		statisticsWarning.SetActive (false);        // Deactivates the reset confirmation box
	}
}