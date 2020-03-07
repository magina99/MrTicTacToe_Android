using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	public GameObject quitScreen;
	public GameObject statsScreen;
	public GameObject statsResetScreen;
	public GameObject playScreen;
	public GameObject easterEggScreen;
    public GameObject thankYouScreen;
    public GameObject changeUsernameScreen;

    public Text version;
    public Text username;

    /// <summary>
    /// Is initialized before the game starts
    /// </summary>
    void Awake()
    {
        // If the active scene is 'Credits', gets the current game version and puts it into a textbox
        if(SceneManager.GetActiveScene().name == "Credits")
        {
            version.text = Application.version.ToString();
        }

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            username.text = PlayerPrefs.GetString("username");
        }
    }

    /// <summary>
    /// Load the scene with the name indicated in the Inspector
    /// </summary>
    /// <param name="name"></param>
	public void LoadScene (string name)
	{
		SceneManager.LoadScene (name);
		ChangeLevel ();
	}

	public IEnumerator ChangeLevel()
	{
		float fadeTime = GameObject.Find ("FadingController").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
	}

    /// <summary>
    /// Quits the game
    /// </summary>
	public void QuitGame()
	{
		Application.Quit ();
	}

    /// <summary>
    /// Controls the Quit Screen
    /// </summary>
	public void QuitScreen()
	{
        // If the Quit Screen isn't active, activates it
        if (!quitScreen.activeInHierarchy)
        {
            quitScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            quitScreen.SetActive(false);
        }
	}

    /// <summary>
    /// Controls the Stats Screen
    /// </summary>
	public void StatsScreen()
	{
        // If the Stats Screen isn't active, activates it
        if (!statsScreen.activeInHierarchy)
        {
            statsScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            statsScreen.SetActive(false);
        }
	}

    /// <summary>
    /// Controls the Stats Reset Screen
    /// </summary>
	public void StatsResetScreen()
	{
        // If the Stats Reset Screen isn't active, activates it
        if (!statsResetScreen.activeInHierarchy)
        {
            statsResetScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            statsResetScreen.SetActive(false);
        }
	}

    /// <summary>
    /// Controls the Play Screen
    /// </summary>
	public void PlayScreen()
	{
        // If the Play Screen isn't active, activates it
        if (!playScreen.activeInHierarchy)
        {
            playScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            playScreen.SetActive(false);
        }
	}

    /// <summary>
    /// Controls the Easter Egg Screen
    /// </summary>
	public void EasterEggScreen()
	{
        // If the Easter Egg Screen isn't active, activates it
        if (!easterEggScreen.activeInHierarchy)
        {
            easterEggScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            easterEggScreen.SetActive(false);
        }
	}

    /// <summary>
    /// Controls the Thank You Screen
    /// </summary>
    public void ThankYouScreen()
    {
        // If the Thank You Screen isn't active, activates it
        if (!thankYouScreen.activeInHierarchy)
        {
            thankYouScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            thankYouScreen.SetActive(false);
        }
    }

    public void ChangeUsernameScreen()
    {
        // If the Thank You Screen isn't active, activates it
        if (!changeUsernameScreen.activeInHierarchy)
        {
            changeUsernameScreen.SetActive(true);
        }
        else    // Else, deactivates it
        {
            changeUsernameScreen.SetActive(false);
        }
    }
}