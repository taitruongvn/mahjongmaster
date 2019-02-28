using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

	public static GamePlay instance;

	private int time;

	[SerializeField]
	private Text endScore, bestScore, currentScore, gameTime, levelName;
	[SerializeField]
	public GameObject overPanel, pausePanel, gameTable, nextLevelButton;
	[SerializeField]
	public Text hint;

	[SerializeField]
	private Text scoreText;

	public int NextLevel;

	void Awake()
	{
		gameTable.SetActive (true);
		time = 70;
		_MakeInstance ();
		_SetTime ();
		int currentLevel = NextLevel - 1;
		levelName.text = "Level" + currentLevel;
		StartCoroutine (_TimeCounter());
	}

	void _MakeInstance()
	{
		if(instance==null){
			instance = this;
		}
	}

	public void _SetScore(int score)
	{
		scoreText.text = "" + score;
	}

	IEnumerator _TimeCounter()
	{
		if (time == 0) 
		{
			StopCoroutine( _TimeCounter ());
			ShowOverPanel (GameScript.instance.score);
		} 
		else 
		{
			yield return new WaitForSeconds (1f);
			time--;
			StartCoroutine (_TimeCounter ());
			_SetTime ();
		}
	}

	public void _SetTime()
	{
			gameTime.text = time + "s";
	}

	public void ShowOverPanel(int score)
	{
		gameTable.SetActive (false);
		Time.timeScale = 0;
		overPanel.SetActive (true);

		endScore.text = "" + PlayerPrefs.GetInt("TempScore");
		GameScript.instance.CheckWin ();

		if(GameManager.instance !=null)
		{
			if(score>GameManager.instance._GetHighScore())
			{
				GameManager.instance._SetHighScore (score);
			}
			bestScore.text = "" + GameManager.instance._GetHighScore ();
		}
	}

	public void ShowPausePanel(int score)
	{
		Time.timeScale = 0;
		pausePanel.SetActive (true);
		currentScore.text = "" + score;
	}

	public void _RestartGame()
	{	
		Time.timeScale = 1;
		PlayerPrefs.SetInt ("TempScore", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void _PauseGame(){
		ShowPausePanel (GameScript.instance.score);
		gameTable.SetActive (false);
	}

	public void _ResumeGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		gameTable.SetActive (true);
	}

	public void _BacktoMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("GameMenu");
		if(NextLevel != 5)
		{
			CheckHighScore ();
		}
		PlayerPrefs.SetInt ("TempScore", 0);
	}

	public void _Reload()
	{
		Time.timeScale = 1;
		PlayerPrefs.SetInt ("TempScore", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void _NextLevel(){
		if (NextLevel==4)
		{
			CheckHighScore ();
		}
		Time.timeScale = 1;
		SceneManager.LoadScene (GamePlay.instance.NextLevel);
	}

	public void CheckHighScore()
	{
		int tempi=5;
		for(int i=5;i>=1;i--)
		{
			if(PlayerPrefs.GetInt("TempScore")>PlayerPrefs.GetInt("HighScoreScore"+i))
			{
				tempi = i;
			}

			for(int j=6;j>tempi;j--)
			{
				int tempj = j - 1;
				PlayerPrefs.SetInt ("HighScoreScore" + j, PlayerPrefs.GetInt ("HighScoreScore" + tempj));
				PlayerPrefs.SetString ("HighScoreName" + j, PlayerPrefs.GetString ("HighScoreName" + tempj));
			}

		}
		PlayerPrefs.SetInt ("HighScoreScore" + tempi,PlayerPrefs.GetInt("TempScore"));
		PlayerPrefs.SetString("HighScoreName" + tempi,PlayerPrefs.GetString ("Player Name"));
	}
}