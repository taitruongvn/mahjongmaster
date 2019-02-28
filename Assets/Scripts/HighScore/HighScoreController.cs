using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour {

	public static HighScoreController instance;

	[SerializeField]
	private Text highScoreText;

	string TotValue;

	public void Awake()
	{
		TotValue = "";
		_MakeInstance ();
	}

	void _MakeInstance(){
		if(instance==null){
			instance = this;
		}
	}

	void Start(){
		GetHighScoreTable ();
	}

	public void GetHighScoreTable()
	{
		string tempstring;
		string tempscore;
		for (int k = 1; k <= 5; k++) 
		{
			tempstring=PlayerPrefs.GetString("HighScoreName"+k);
			tempscore =PlayerPrefs.GetInt("HighScoreScore"+k).ToString();
			TotValue=TotValue+ "Name: "+tempstring+" - "+" Score: "+tempscore+"\n\n";
		}

		highScoreText.text = TotValue;
	}

	public void _BackToMenu()
	{
		SceneManager.LoadScene ("GameMenu");
	}
}
