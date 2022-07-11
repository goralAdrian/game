using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChanger : MonoBehaviour
{
	public Text DebugText;
	string text = "ala ma kota";

	void Start(){
		DebugText.text = "ala ma kota";



		
	}


	public void changeText()
	{
		GameObject.Find("ThisText").GetComponent<Text>().text = text;
	}
}