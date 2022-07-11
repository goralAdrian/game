using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DomKultury : MonoBehaviour
{
	Premia premia;
	public static int lvlOfBuilding = 1;
	public static int timer = 0;
	public static int combo = 0;
	
void Start()
{
		premia = new Premia();
		lvlOfBuilding = 1;
		timer = 0;
		combo = 0;
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget - 2000;
}

	void Update()
	{
		if(timer == 1500 || timer > 1500)
		{
			Updater();
			timer = 0;
			if(combo==25 || combo>25)
			{
				combo = 0;
				premia.Description();
				print(premia.Description());
			}
			combo++;
		}
		timer++;
	}

	public static void Updater()
	{
		lvlOfBuilding++;
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + (lvlOfBuilding * lvlOfBuilding);
	}

	public string Description()
	{
		return "Nie została przyznana premia";
	}

}

public abstract class ComponentDecorator : DomKultury {
	new public abstract string Description();
}

public class Premia : ComponentDecorator {

	public override string Description(){
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + 2000;
		GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia";
		return "Została przyznana premia";
	}
}