using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Biura : MonoBehaviour
{
	
	public static int peopleCount = 1;
	public static int lvlOfBuilding = 1;
	public static int timer = 0, timer2 = 0, timer3 = 0;

	Biuro smallMoney;
	Biuro bigMoney;
	void Start()
	{
		peopleCount = 1;
		lvlOfBuilding = 1;
		timer = 0;
		timer2 = 0;
		timer3 = 0;
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget - 2500;
		smallMoney = new MediumPremia();
		bigMoney = new LargePremia();
	}


	void Update()
	{
		if(timer == 1250 || timer > 1250)
		{
			Updater();
			timer = 0;
		}
		if(timer2 == 5000 || timer2 > 5000)
		{
			GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + smallMoney.moreMoney();
			timer2=0;
		}
		if(timer2 == 12500 || timer2 > 12500)
		{
			GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + bigMoney.moreMoney();
			timer3=0;
		}
	
		timer++;
		timer2++;
		timer3++;
	}
	
	public static void Updater()
	{
		if(peopleCount <= 1024)
		{
			peopleCount = peopleCount + 3;
			if(peopleCount > 1024)
			{
				peopleCount = 1024;
			}
		}
		if(peopleCount >= 8 && peopleCount < 16)
		{
			lvlOfBuilding = 2;
		}
		if(peopleCount >= 16 && peopleCount < 32)
		{
			lvlOfBuilding = 3;
		}
		if(peopleCount >= 32 && peopleCount < 64)
		{
			lvlOfBuilding = 4;
		}
		if(peopleCount >= 64 && peopleCount < 128)
		{
			lvlOfBuilding = 5;
		}
		if(peopleCount >= 128 && peopleCount < 256)
		{
			lvlOfBuilding = 6;
		}
		if(peopleCount >= 256 && peopleCount < 512)
		{
			lvlOfBuilding = 7;
		}
		if(peopleCount >= 512 && peopleCount < 1024)
		{
			lvlOfBuilding = 8;
		}
		if(peopleCount == 1014)
		{
			lvlOfBuilding = 9;
		}
		
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().people = GameObject.Find("Main Camera").GetComponent<MyGameManager>().people + peopleCount;
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + (peopleCount * lvlOfBuilding);
	}
}

public abstract class Biuro
{
    public abstract int moreMoney();
}

public class LargePremia : Biuro
{
    public override int moreMoney()
    {
		GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia o wysokości 250";
        return 250;
    }

}
public class MediumPremia : Biuro
{
    public override int moreMoney()
    {
		GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia o wysokości 125";
        return 125;
    }

}

abstract public class BiuroDecorator : Biuro
{

    protected Biuro _biuro;

    public BiuroDecorator(Biuro biuro)
    {
        _biuro = biuro;
    }
    public override int moreMoney()
    {
		if(_biuro!=null)
        {
			return _biuro.moreMoney();
		}
		else return 100;
    }

}

public class PlusDecorator : BiuroDecorator
{
    public PlusDecorator(Biuro biuro) 
        : base(biuro)
    {

    }

    public override int moreMoney()
    {
		GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia o wysokości 270";
        return base.moreMoney() + 500;
    }
}