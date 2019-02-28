using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	public static GameScript instance;

	public GameObject cubeGameObjects;
	private AudioSource audioSource;
	public int hintTurn;
	public AudioClip clickClip;

	public List<GameObject> cubeList = new List<GameObject> ();
	public List<GameObject> countingList = new List<GameObject> ();

	public int score =0;

	void Awake()
	{
		hintTurn = 4;
		GamePlay.instance.hint.text = "" + (hintTurn - 1);
		audioSource = GetComponent<AudioSource> ();
		_MakeInstance();
	}



	void Start ()  
	{
		UpdateColor ();
	}

	void _MakeInstance()
	{
		if (instance == null) 
		{
			instance = this;
		}
	}

	public void compare()
	{
		if (cubeList.Count == 2) 
		{
			if (cubeList [0].GetComponent<Renderer> ().material.name == cubeList [1].GetComponent<Renderer> ().material.name) 
			{
				
				countingList.Add (cubeList [0]);
				countingList.Add (cubeList [1]);
			
				cubeList [0].SetActive(false);
				cubeList [1].SetActive(false);

				UpdateColor ();
				score++;
				PlayerPrefs.SetInt ("TempScore",(PlayerPrefs.GetInt("TempScore")+1));
				GamePlay.instance._SetScore (score);
				if (countingList.Count==cubeGameObjects.transform.childCount)
				{

					GamePlay.instance.ShowOverPanel (score);
				}

			} else 
			{
				cubeList [0].GetComponent<Renderer> ().material.color=Color.white;	
				cubeList [1].GetComponent<Renderer> ().material.color=Color.white;	
				cubeList.Clear();
			}
			cubeList.Clear();
		}

	}

	public void PlayClickClip()
	{
		audioSource.PlayOneShot (clickClip);
	}

	public void CheckWin()
	{
		if (countingList.Count==cubeGameObjects.transform.childCount)
		{

			GamePlay.instance.nextLevelButton.SetActive (true);
			if(GamePlay.instance.NextLevel>PlayerPrefs.GetInt("Level Pass"))
			{
				PlayerPrefs.SetInt ("Level Pass",GamePlay.instance.NextLevel);
			}

		}
	}

	public void UpdateColor()
	{
		
		for (int i = 0; i < cubeGameObjects.transform.childCount; i++)
		{
			int tempcount = 0;
			for(int j = i+1; j < cubeGameObjects.transform.childCount; j++)
			{
				if (cubeGameObjects.transform.GetChild (i).transform.position.z > cubeGameObjects.transform.GetChild (j).transform.position.z && 
                    cubeGameObjects.transform.GetChild (i).gameObject.active==true && 
                    cubeGameObjects.transform.GetChild (j).gameObject.active==true) 
				{
					if (
						cubeGameObjects.transform.GetChild (j).transform.position.x > cubeGameObjects.transform.GetChild (i).transform.position.x - 1 &&
						cubeGameObjects.transform.GetChild (j).transform.position.x < cubeGameObjects.transform.GetChild (i).transform.position.x + 1 &&
						cubeGameObjects.transform.GetChild (j).transform.position.y > cubeGameObjects.transform.GetChild (i).transform.position.y - 1.8 &&
						cubeGameObjects.transform.GetChild (j).transform.position.y < cubeGameObjects.transform.GetChild (i).transform.position.y + 1.8) 
					{
						tempcount++;
					}
				} 
				if (tempcount >= 1) {
					cubeGameObjects.transform.GetChild (i).transform.GetComponent<Renderer> ().material.color = Color.gray;
				} else {
					cubeGameObjects.transform.GetChild(i).transform.GetComponent<Renderer>().material.color=Color.white;
				}
			}
		}
	}

	int HintCounter;

	IEnumerator Hint()
	{
		if(hintTurn>0){
		for (int i = 0; i < cubeGameObjects.transform.childCount; i++)
		{		
			for(int j = i+1; j < cubeGameObjects.transform.childCount; j++)
			{
				if(HintCounter == 0)					{
					if(cubeGameObjects.transform.GetChild(i).transform.GetComponent<Renderer>().material.color==Color.white && 
					cubeGameObjects.transform.GetChild(j).transform.GetComponent<Renderer>().material.color==Color.white && 
					cubeGameObjects.transform.GetChild(i).gameObject.activeSelf &&
					cubeGameObjects.transform.GetChild(j).gameObject.activeSelf &&
					cubeGameObjects.transform.GetChild (i).transform.GetComponent<Renderer> ().material.name == cubeGameObjects.transform.GetChild (j).transform.GetComponent<Renderer> ().material.name)						
					{
						HintCounter = 1;
						cubeGameObjects.transform.GetChild(i).transform.GetComponent<Renderer>().material.color=Color.yellow;
						yield return new WaitForSeconds(0.1f); 
						cubeGameObjects.transform.GetChild(i).transform.GetComponent<Renderer>().material.color=Color.white;
						yield return new WaitForSeconds(0.1f);

						cubeGameObjects.transform.GetChild(j).transform.GetComponent<Renderer>().material.color=Color.yellow;
						yield return new WaitForSeconds(0.1f); 
						cubeGameObjects.transform.GetChild(j).transform.GetComponent<Renderer>().material.color=Color.white;
						yield return new WaitForSeconds(0.1f);
					}
				}
			}
		}
		}
	}

	public void _hint()
	{
		hintTurn --;
		if(hintTurn>0)
		{
			GamePlay.instance.hint.text = "" + (hintTurn-1);
		}

		HintCounter = 0;
		StartCoroutine (Hint ());
	}
}
