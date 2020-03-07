using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UsernameController : MonoBehaviour
{
    public Text welcomeUsername;
    public InputField usernameBox;
    public GameObject usernameCreation;

    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "BootScreen")
        {
            if (PlayerPrefs.GetInt("firstBoot") == 0)
            {
                usernameCreation.SetActive(true);
            }
            else
            {
                welcomeUsername.text = "Welcome " + PlayerPrefs.GetString("username");
            }
        }
    }

    public void InsertUsername()
    {
        PlayerPrefs.SetString("username", usernameBox.text);
        PlayerPrefs.SetInt("firstBoot", 1);
        welcomeUsername.text = "Welcome " + PlayerPrefs.GetString("username");
        usernameCreation.SetActive(false);
    }

    public void ChangeUsername()
    {
        string usernameTemp = usernameBox.text;

        if(usernameTemp.Length < 3 || usernameTemp == " ")
        {
            welcomeUsername.text = "The username cannot be invalid or be smaller than 3 characters long!";
        }
        else if(usernameTemp == PlayerPrefs.GetString("username"))
        {
            welcomeUsername.text = "The new username cannot be the same as the one you are currently using!";
        }
        else
        {
            PlayerPrefs.SetString("username", usernameTemp);
            usernameCreation.SetActive(false);
        }
    }
}