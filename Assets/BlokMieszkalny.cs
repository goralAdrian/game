using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlokMieszkalny : MonoBehaviour
{
	public static int peopleCount = 1;
	public static int lvlOfBuilding = 1;
	public static int timer = 0, timer2 = 0, timer3 = 0;
	public static int combo = 0;
	
	Bloczek smallMoneyBloczek;
	Bloczek bigMoneyBloczek;
	
    void Start()
    {
        peopleCount = 1;
		lvlOfBuilding = 1;
		timer = 0;
		combo = 0;
		GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget - 1500;
		smallMoneyBloczek = new MediumPremiaBlok();
		bigMoneyBloczek = new LargePremiaBlok();
    }

	void Update()
    {
		
        if(timer == 1000 || timer > 1000)
		{
			Updater();
			timer = 0;
		}
		if(timer2 == 5000 || timer2 > 5000)
		{
			GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + smallMoneyBloczek.moreMoneyBlok();
			timer2=0;
		}
		if(timer2 == 12500 || timer2 > 12500)
		{
			GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget = GameObject.Find("Main Camera").GetComponent<MyGameManager>().budget + bigMoneyBloczek.moreMoneyBlok();
			timer3=0;
		}
		timer++;
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
	public string Description()
	{
		return "Nie została przyznana premia";
	}
}


public abstract class Bloczek
{
    public abstract int moreMoneyBlok();

}
public class LargePremiaBlok : Bloczek
{
    public override int moreMoneyBlok()
    {
		GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia o wysokości 250";
        return 250;
    }
}
public class MediumPremiaBlok : Bloczek
{
    public override int moreMoneyBlok()
    {
		GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia o wysokości 125";
        return 125;
    }
}

abstract public class BloczekDecorator : Bloczek
{
    protected Bloczek _bloczek;

    public BloczekDecorator(Bloczek bloczek)
    {
        this._bloczek = bloczek;
    }

    public override int moreMoneyBlok()
    {
		if(this._bloczek!=null)
        {
			return _bloczek.moreMoneyBlok();
		}
		else
			return 100;
    }

}

public class PlusDecoratorBloczek : BloczekDecorator
{
    public PlusDecoratorBloczek(Bloczek bloczek) 
        : base(bloczek)
    {

    }

    public override int moreMoneyBlok()
    {
		GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Została przyznana premia o wysokości 750";
        return base.moreMoneyBlok() + 500;
    }
}

/*
abstract class Decorator : Bloczek
{
	protected Bloczek _bloczek;
	
	public Decotator(Bloczek bloczek)
	{
		this._bloczek = bloczek;
	}
	public void SetComponent(Bloczek bloczek)
	{
		this._bloczek = bloczek;
	}
	public override int moreMoneyBlok()
	{
		if(this._bloczek != null)
		{
			this._bloczek.moreMoneyBlok();
		}
		else
		{
			Debug.Log("Blad przy dekoratorze!");
		}
	}
}
*/