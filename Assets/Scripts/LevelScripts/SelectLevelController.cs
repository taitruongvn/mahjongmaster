using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelController : MonoBehaviour {

	public static SelectLevelController instance;

	public int level;
	public GameObject ImageLock;

	void Start(){
		if(PlayerPrefs.GetInt("Level Pass")>=level){
			ImageLock.SetActive(false);
		}
	}

	void Awake(){
		_MakeInstance ();
	}

	void _MakeInstance(){
			instance = this;
		}
	}
