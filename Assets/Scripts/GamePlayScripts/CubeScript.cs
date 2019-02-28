using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
	public void OnMouseDown()
	{
		if (gameObject.GetComponent<Renderer> ().material.color == Color.white) 
		{
			if (Time.timeScale != 0) 
			{
				GameScript.instance.PlayClickClip ();
				gameObject.GetComponent<Renderer> ().material.color = Color.yellow;	
				GameScript.instance.cubeList.Add (gameObject);
				GameScript.instance.compare ();
			}

		}else if (gameObject.GetComponent<Renderer> ().material.color == Color.yellow) 
		{
			if (Time.timeScale != 0) 
			{
				GameScript.instance.PlayClickClip ();
				gameObject.GetComponent<Renderer> ().material.color = Color.white;	
				GameScript.instance.cubeList.Clear ();
			}

		} 				
	}

	public void _SelectCube(){
		OnMouseDown();
	}
}
