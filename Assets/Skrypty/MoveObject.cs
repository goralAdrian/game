using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private GameObject myobject;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && Input.GetMouseButton(0))
        {
            myobject = hit.collider.gameObject;

            GameObject.FindGameObjectWithTag("GameController").GetComponent<NoweBloki>().Ustawienia(myobject);

            MyGameManager.gameObjectWybrany = myobject;

        }
        else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && Input.GetMouseButton(1))
        {
            if (!hit.collider.gameObject.name.Equals("-1") && !hit.collider.gameObject.name.Equals("-2"))
            {
                hit.collider.gameObject.SetActive(false);
                hit.collider.gameObject.transform.position = new Vector3(100,100,100);

                GameObject.FindGameObjectWithTag("GameController").GetComponent<NoweBloki>().Ustawienia(null);
            }

        }

        if (myobject != null)
            if (myobject.tag.Equals("Untagged"))
            {


                Vector3 myPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

                float x = myPosition.x;
                float y = myPosition.y;

                int xx = Mathf.RoundToInt(x);
                int yy = Mathf.RoundToInt(y);


                if (xx >= 0 && xx <= 23 && yy >= 0 && yy <= 14)
                {
                    myobject.transform.position = new Vector3(xx, yy, myPosition.z);
                }
            }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            myobject = null;
        }
    }
}
