using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingController : MonoBehaviour {

	public static SettingController instance;

	void Awake()
	{
		_MakeSingleInstance ();
		IsSoundCheck ();
	
	}

	void IsSoundCheck ()
	{
		if(!PlayerPrefs.HasKey("IsSoundCheck")){
			PlayerPrefs.SetInt ("Mute",0);
			PlayerPrefs.SetInt ("IsSoundCheck",0);
		}
	}

	void _MakeSingleInstance()
	{
		if (instance != null) 
		{
			instance = this;
		}  
	}
		
	Toggle musicToggle;

	void Start()
	{
		musicToggle = GameObject.Find ("Mute").GetComponent<Toggle> ();
		if (PlayerPrefs.GetInt("Mute") == 1) {	
			musicToggle.isOn = true;
		} else 
		{
			musicToggle.isOn = false;
		}
		musicToggle.onValueChanged.AddListener((value)=>{
			MyListener(value);
		});
	}

	public void MyListener(bool value){
		if (value) {
			PlayerPrefs.SetInt ("Mute", 1);
			Mute();
		} 
		if (!value) {
			PlayerPrefs.SetInt ("Mute", 0);
			Mute();
		}
	}

	public void Mute(){
		if (PlayerPrefs.GetInt ("Mute") == 1) {
			AudioListener.volume = 0f;
		} else {
			AudioListener.volume = 1f;
		}
	}
}
