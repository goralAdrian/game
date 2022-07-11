using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
	public Caretaker c;
	float timerOfTime = 0;
	int timer = 0;
	int timer2 = 0;
	public int budget = 0;
	public int people = 0;
	int randomNumber = 0;
	Customers customeres;
	private List<Vector2> listOfVector = new List<Vector2>();
	public List<GameObject> listOfObjects = new List<GameObject>();

	public static Vector2 zmiennastatyczna;
	

	public int[][] tab;
		

	public Vector2 actual;
	public GameObject myObject;

	public static GameObject gameObjectWybrany;

	public GameObject[] mojetypy;

	public string[,] tableOfVariables = new string[64, 2];
	bool breakingCircle = false;

	public string textToShow = "1";
	public Originator o;
	public void restartPlace()
	{
		SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
	}
	
	
	void Start()
	{
		timerOfTime = 0;
		
		timer = 0;
		timer2 = 0;
		budget = 0;
		people = 0;
		randomNumber = 1;
		int i = 0;
		do
		{
			tableOfVariables[i, 0] = "";
			tableOfVariables[i, 1] = "";
			i++;
		} while (i < 64);

		int xxx = 0, x2 = 0;


		o = new Originator();
		o.State = listOfVector;
		o.State2 = listOfObjects;
		
		c = new Caretaker();
		c.Memento = o.CreateMemento();
	}


	void Update()
	{
		if (Input.GetKey(KeyCode.F1))
		{
			Debug.Log("info");
		}
		
		/*
			opcje zapisu i  wczytania
		
		*/
		
		if (Input.GetKey(KeyCode.Q))
		{
			o.State = listOfVector;
			o.State2 = listOfObjects;
		
			c = new Caretaker();
			c.Memento = o.CreateMemento();
			
			Debug.Log("1a");
		}

		if (Input.GetKey(KeyCode.W))
		{
			listOfVector = o.State;
			listOfObjects = o.State2;
			Debug.Log("2a");
		}
		
		timerOfTime += Time.deltaTime;

		listOfVector.Clear();
		foreach (GameObject a in listOfObjects)
		{  
			listOfVector.Add(new Vector2(a.GetComponent<Transform>().position.x, a.GetComponent<Transform>().position.y));
		}
		if(budget>10000000)
			{
				String ResultValue = Convert.ToString(timer2);
				File.WriteAllText("BestScore.txt", "Twoj wynik to: " + ResultValue + " sekund");
				
				SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
			}
		if(timer==1000 || timer>1000)
		{
			
			GameObject.Find("PeopleCounter").GetComponent<UnityEngine.UI.Text>().text = "Mieszkańców: " + people;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "";
			timer=0;
		}
		timer++;
		if(timer==24000 || timer>24000)
		{
			if(randomNumber>8 || randomNumber<1)
			{
				randomNumber = 4;
				Singleton s1 = Singleton.GetInstance();
			}
			if(randomNumber==1)
			{
				Debug.Log("1");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Z podowu zalania kilku budynkow, miasto musi oplacic remonty tychze budynkow.";
				budget = budget - 25000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 3;
				Singleton s2 = Singleton.GetInstance();
			}
			if(randomNumber==2)
			{
				Debug.Log("2");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Kapela metalowa przyjechala do miasta podczas trasy koncertowej, przez co miasto zyskuje pewna sumke pieniedzy zwiazana z rzesza fanow.";
				budget = budget + 12500;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 4;
			}
			if(randomNumber==3)
			{
				Debug.Log("3");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 10 000";
				budget = budget + 10000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 5;
			}
			if(randomNumber==4)
			{
				Debug.Log("4");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 15 000";
				budget = budget + 15000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 6;
			}
			if(randomNumber==5)
			{
				Debug.Log("5");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 20 000";
				budget = budget + 20000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 7;
				Singleton s3 = Singleton.GetInstance();
			}
			if(randomNumber==6)
			{
				Debug.Log("6");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 25 000";
				budget = budget + 25000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 8;
			}
			if(randomNumber==7)
			{
				Debug.Log("7");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 50 000";
				budget = budget + 50000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 2;
			}
			if(randomNumber==8)
			{
				Debug.Log("8");
				GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Z powodu konfliktu interesów z Czechami, musisz zapłacić Cr. 1 000 000 kary.";
				budget = budget - 1000000;
				GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
				randomNumber = 1;
			}
		
			GameObject.Find("PeopleCounter").GetComponent<UnityEngine.UI.Text>().text = "Mieszkańców: " + people;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "";
			
		}
		timer2++;
	
	}

	public void showInfo()
	{
		Singleton singleton = Singleton.GetInstance();
	}

	/*
	singleton
	*/

	public sealed class Singleton
		{
		private Singleton() { }
		private static Singleton _instance;
		public static Singleton GetInstance()
		{
			if (_instance == null)
			{
				_instance = new Singleton();
			}
			return _instance;
		}
		public static void showInfoSingleton()
		{
			
			Debug.Log("przyznano premię");
		}
	}



	public class CustomersBase
	{
		private DataObject dataObject;
		public DataObject Data
		{
			set { dataObject = value; }
			get { return dataObject; }
		}
		public virtual void Next()
		{
			dataObject.NextRecord();
		}
		public virtual void Prior()
		{
			dataObject.PriorRecord();
		}
		public virtual void Add(string customer)
		{
			dataObject.AddRecord(customer);
		}
		public virtual void Delete(string customer)
		{
			dataObject.DeleteRecord(customer);
		}
		public virtual void Show()
		{
			dataObject.ShowRecord();
		}
		public virtual void ShowAll()
		{
			dataObject.ShowAllRecords();
		}
	}

	public class Customers : CustomersBase
	{
		public override void ShowAll()
		{
			Console.WriteLine();
			Console.WriteLine("------------------------");
			base.ShowAll();
			Console.WriteLine("------------------------");
		}
	}
	public abstract class DataObject
	{
		public abstract void NextRecord();
		public abstract void PriorRecord();
		public abstract void AddRecord(string name);
		public abstract void DeleteRecord(string name);
		public abstract string GetCurrentRecord();
		public abstract void ShowRecord();
		public abstract void ShowAllRecords();
	}
	public class CustomersData : DataObject
	{
		private readonly List<string> customers = new List<string>();
		private int current = 0;
		private string city;
		public CustomersData(string city)
		{
			this.city = city;
			// Loaded from a database 
			customers.Add("Jim Jones");
			customers.Add("Samual Jackson");
			customers.Add("Allen Good");
			customers.Add("Ann Stills");
			customers.Add("Lisa Giolani");
		}
		public override void NextRecord()
		{
			if (current <= customers.Count - 1)
			{
				current++;
			}
		}
		public override void PriorRecord()
		{
			if (current > 0)
			{
				current--;
			}
		}
		public override void AddRecord(string customer)
		{
			customers.Add(customer);
		}
		public override void DeleteRecord(string customer)
		{
			customers.Remove(customer);
		}
		public override string GetCurrentRecord()
		{
			return customers[current];
		}
		public override void ShowRecord()
		{
			Console.WriteLine(customers[current]);
		}
		public override void ShowAllRecords()
		{
			Console.WriteLine("Customer City: " + city);
			foreach (string customer in customers)
			{
				Console.WriteLine(" " + customer);
			}
		}
	}
}


	/*
	memento, odpowiedzialne za zapamiętywania danych
	*/

	public class Originator
	{
		List<Vector2> state;
		List<GameObject> state2;
		
		public List<Vector2> State
		{
			get { Debug.Log("2--a");return state; }
			set
			{
				state = value;
				Console.WriteLine("State = " + state);
			}
		}
		
		public List<GameObject> State2
		{
			get { Debug.Log("2--b");return state2; }
			set
			{
				state2 = value;
				Console.WriteLine("State = " + state2);
			}
		}

		public Memento CreateMemento()
		{
			Debug.Log("1b");
			return (new Memento(state, state2));
		}

		public void SetMemento(Memento memento)
		{
			Console.WriteLine("Restoring state...");
			State = memento.State;
		}
	}

	public class Memento
	{
		List<Vector2> state;
		List<GameObject> state2;

		public Memento(List<Vector2> state, List<GameObject> state2)
		{
			Debug.Log("1c");
			this.state = state;
			this.state2 = state2;
			
			Debug.Log(state);
			Debug.Log(state2);
			Debug.Log("--//--");
		}
		public List<Vector2> State
		{
			
			get { Debug.Log("2c1"); return state; }
		}
		public List<GameObject> State2
		{
			
			get { Debug.Log("2c2"); return state2; }
		}
	}

	public class Caretaker
	{
		Memento memento;
		public Memento Memento
		{
			set { Debug.Log("2bb"); memento = value; }
			get { Debug.Log("2b");return memento; }
		}
		
	}
	/*
	public class SalesProspect
	{
		List<Vector2> listOfVector2;
		List<GameObject> listOfObjects2;
		public List<Vector2> listOfVector
		{
			get { Console.WriteLine("loaded Vector");return listOfVector2; }
			set
			{
				Console.WriteLine("saved Vector");
				listOfVector2 = value;
			}
		}

		public List<GameObject> listOfObjects
		{
			get { Console.WriteLine("loaded List of objects");return listOfObjects2; }
			set
			{
				Console.WriteLine("saved List of objects");
				listOfObjects2 = value;
			}
		}

		public Memento SaveMemento()
		{
			//Console.WriteLine("\nSaving state --\n");
			return new Memento(listOfVector, listOfObjects);
		}

		public void RestoreMemento(Memento memento)
		{
			Console.WriteLine("\nRestoring state --\n");
			listOfVector = memento.listOfVector;
			listOfObjects = memento.listOfObjects;
		}
	}

	public class Memento
	{
		List<Vector2> listOfVector2;
		List<GameObject> listOfObjects2;

		public Memento(List<Vector2> listOfVector, List<GameObject> listOfObjects)
		{
			this.listOfVector2 = listOfVector2;
			this.listOfObjects2 = listOfObjects2;
		}
		public List<Vector2> listOfVector
		{
			get { return listOfVector2; }
			set { listOfVector2 = value; }
		}
		public List<GameObject> listOfObjects
		{
			get { return listOfObjects2; }
			set { listOfObjects2 = value; }
		}
	}

	public class Mem_Pros
	{
		Memento memento;
		public Memento Memento
		{
			set { memento = value; }
			get { return memento; }
		}
	}
	
	*/




	/*
		Bridge
	*/
/*
public class CustomersBase
	{
	private DataObject dataObject;

	public DataObject Data
	{
		set { dataObject = value; }
		get { return dataObject; }
	}

	public virtual void Next()
	{
		dataObject.NextRecord();
	}

	public virtual void Prior()
	{
		dataObject.PriorRecord();
	}

	public virtual void Add(string customer)
	{
		dataObject.AddRecord(customer);
	}

	public virtual void Delete(string customer)
	{
		dataObject.DeleteRecord(customer);
	}

	public virtual void Show()
	{
		dataObject.ShowRecord();
	}

	public virtual void ShowAll()
	{
		dataObject.ShowAllRecords();
	}
}

public abstract class DataObject
{
	public abstract void NextRecord();
	public abstract void AddRecord(string name);
	public abstract void DeleteRecord(string name);
	public abstract string GetCurrentRecord();
	public abstract void ShowRecord();
	public abstract void ShowAllRecords();
}

public class CustomersData : DataObject
{
	private readonly List<Double> premia = new List<Double>();
	private int current = 0;

	public CustomersData(string city)
	{

		premia.Add(200.00);
		premia.Add(250.00);
		premia.Add(500.00);
		premia.Add(12500.00);
	}

	public override void NextRecord()
	{
		if (current <= customers.Count - 1)
		{
			current++;
		}
	}

	public override void AddRecord(string customer)
	{
		customers.Add(customer);
	}

	public override void DeleteRecord(string customer)
	{
		customers.Remove(customer);
	}

	public override string GetCurrentRecord()
	{
		return customers[current];
	}

	public override void ShowRecord()
	{
		Console.WriteLine(customers[current]);
	}

	public override void ShowAllRecords()
	{
		Console.WriteLine("Customer City: " + city);

		foreach (string customer in customers)
		{
			Console.WriteLine(" " + customer);
		}
	}
}
public class Customers : CustomersBase
{
	public override void ShowAll()
	{
		// Add separator lines

		Console.WriteLine();
		base.ShowAll();
	}
}

*/
