using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////
/*
IntroByte Entertainment
Mr. TicTacToe - URLController
*/
//////////////////////////////////////

public class URLController : MonoBehaviour {

	public void websiteButton()
	{
		Application.OpenURL ("http://t03.magina.vigion.pt/");
	}

	public void twitterButton()
	{
		Application.OpenURL ("https://twitter.com/KiddVernic");
	}
}
