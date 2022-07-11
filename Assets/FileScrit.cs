using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text;

public class FileScrit : MonoBehaviour
{
    string path = "";
  //  string a = "";
    public GameObject[] gameObjects;
    public string[] splitArray;
    public GameObject[] bloki = new GameObject[22];
    private GameObject myObject;


	public void savingScript()
    {
		
        StringBuilder stringBud = new StringBuilder();
        path = "file.txt";//EditorUtility.SaveFilePanel("Zapisz schemat jako", "", "savingFile.txt", "txt");

        if (path.Length != 0)
        {
            for (int i = 0; i < GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Count; i++)
            {
               if(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position.x.Equals("100"))
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].name);
                stringBud.Append(";");
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position.x);
                stringBud.Append(";");
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position.y);
                stringBud.Append(";");

                stringBud.Append("¡");
                stringBud.Append("\r\n");
            }
            File.WriteAllText(path, stringBud.ToString());
        }

    }

    public void loadingScipt()
    {
		Debug.Log("Loading");
        int i = 0;
        path = "C:/Users/Adrian/Desktop/projekt/file.txt";// EditorUtility.OpenFilePanel("Otwórz plik", "Wybierz plik", "txt");
        string stringToParse = "";
        if (!path.ToString().Equals(null))
        {
            stringToParse = File.ReadAllText(@path, Encoding.UTF8);
            char[] b = { '¡' };                         //¡ oddziela linijki
            splitArray = stringToParse.Split(b);
            string[] line;
            Vector3 vectorOfElem;                       //vector odpowiedzialny za umiejscowienie elementow na planszy podczas ladowania




            for (i = 0; i < GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Count; i++)
            {
                GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].gameObject.SetActive(false);
                GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position = new Vector2(100, 100);
            }

            i = 0;
            int j = 0;
            int x = 1, y = 1;
            bool foundStart = false, foundStop = false;
            if (stringToParse.Length > 0)
            {
                if (splitArray.Length > 1)
                {
                    i = 0;
                      do
                        {
							line = splitArray[i].Split(';');
							if (line[1] != "100" && line[2] != "100")
                            {
                                if (
                                    line[0].Contains("2")
                                    )
                                {
                                    if ((!(int.Parse(line[1]) == 100)) && (!(int.Parse(line[2]) == 100)))
                                    {
                                        myObject = Instantiate(bloki[3]);

                                        GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);

                                        vectorOfElem = new Vector3(int.Parse(line[1]), int.Parse(line[2]), 0);
                                        myObject.name = "2";
										Debug.Log(myObject.name);
                                    }
                                }
                                else if (
                                    line[0].Contains("1")
                                    )
                                {
                                    if ((!(int.Parse(line[1]) == 100)) && (!(int.Parse(line[2]) == 100)))
                                    {
                                        Debug.Log("1");
                                        myObject = Instantiate(bloki[2]);
                                        Debug.Log("2");
                                        GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);

                                        vectorOfElem = new Vector3(int.Parse(line[1]), int.Parse(line[2]), 0);
                                        myObject.name = "1";
										Debug.Log(myObject.name);
                                    }
                                }
                                else if (line[0].Contains("3"))
                                {
                                    if ((!(int.Parse(line[1]) == 100)) && (!(int.Parse(line[2]) == 100)))
                                    {
                                        myObject = Instantiate(bloki[4]);

                                        GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);

                                        vectorOfElem = new Vector3(int.Parse(line[1]), int.Parse(line[2]), 0);
                                        myObject.name = "3";
										Debug.Log(myObject.name);
                                    }
                                }
                            }

                            i++;
                        } while (i < splitArray.Length - 1);

                }
            }
        }
		else
		{
			Debug.Log("brak pliku");
		}
    }
}