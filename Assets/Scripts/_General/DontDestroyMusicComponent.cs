using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////////////
/*
IntroByte Entertainment
Mr. TicTacToe - DontDestroyMusicComponent
*/
//////////////////////////////////////

public class DontDestroyMusicComponent : MonoBehaviour {

	private static DontDestroyMusicComponent instance = null;

	public static DontDestroyMusicComponent Instance
	{
		get 
		{ 
			return instance;
		}
	}

	void Awake()
	{
		Scene currentScene = SceneManager.GetActiveScene ();

		string sceneName = currentScene.name;

		if(sceneName == "Main" || sceneName == "MainPvP")
		{
			Destroy (this.gameObject);
			return;
		}
		else
		{
			if(instance != null && instance != this)
			{
				Destroy (this.gameObject);
				return;
			}
			else
			{
				instance = this;
			}

			DontDestroyOnLoad (this.gameObject);
		}
	}
}
