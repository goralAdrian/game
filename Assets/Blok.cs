using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blok : MonoBehaviour
{
    public int id;
    public int typ;
    //public string zawartosc;

   // public InputField input;
   // public Text myText;

    void Update()
    {
        typ = int.Parse(gameObject.name);

       // if (Input.GetMouseButton(0))
      //  {
          //  if (typ == 1) //Warunek
           // {
                //zawartosc = input.text;
           // }
           // else if (typ == 2) //Podaj
          //  {
                // zawartosc = input.text;
          //  }
//else if (typ == 3)//Wypisz
           // {
                // myText.text = "Wypisz a: " + zawartosc;
          //  }
          //  else if (typ == 4) //Obliczen
          //  {
                // myText.text = "Wypisz a: " + zawartosc;
          //  }

           // Debug.Log(zawartosc);
        }
        //RaycastHit hit;

        /*
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity))
        {
            this.gameObject.transform.position = Input.mousePosition;
        }
        */
        /*
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && Input.GetMouseButton(0))
        {

            //print(hit.collider.name.ToString());

            if (hit.collider.tag.Equals("Untagged"))
            {
                hit.collider.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6));
            }

        }*/
   // }

   // void Update()
   // {
       
   // }
}
