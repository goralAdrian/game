using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System;
using System.Text;

public class BloczekScript : MonoBehaviour
{

	//public double id;


	void Start()
	{
		
	}



	void Update()
	{
		
	}





	/*
	public GameObject wpisywania;
	public GameObject warunkowy;
	public GameObject wypisywania;
	public GameObject obliczeniowy;
	public GameObject Canvas;

	public Dropdown dropdown;
    List<string> opcje = new List<string>() {"Dodaj blok", "Blok wyświetlenia", "Blok obliczeniowy", "Blok warunkowy", "Blok wprowadzeniowy"};
	
	
    void Start()
    {
        Lista();
    }
	
    void Lista()
    {
        dropdown.AddOptions(opcje);
    }
	
    void Update()
    {
		Dropdown_IndexChanged(dropdown.value);
		if(dropdown.value !=0){
			dropdown.value = 0;
			//dropdown.Select();
			//dropdown.RefreshShownValue();
		}
    }
	
	public void Dropdown_IndexChanged(int index)
	{
		string i = opcje[index];
		
		if(i == "Blok startowy"){
			
		}
		if(i == "Blok obliczeniowy"){
			GameObject a = Instantiate(obliczeniowy, new Vector3(0,0,0), Quaternion.identity);
			a.transform.SetParent(Canvas.transform);
		}
		if(i == "Blok warunkowy"){
			GameObject b = Instantiate(warunkowy, new Vector3(0,0,0), Quaternion.identity);
			b.transform.SetParent(Canvas.transform);
		}
		if(i == "Blok wprowadzeniowy"){
			GameObject c = Instantiate(wpisywania, new Vector3(0,0,0), Quaternion.identity);
			c.transform.SetParent(Canvas.transform);
		}
		if(i == "Blok wyświetlenia")
		{
			GameObject d = Instantiate(wypisywania, new Vector3(0,0,0), Quaternion.identity);
			d.transform.SetParent(Canvas.transform);
		}
	}

	*/
}