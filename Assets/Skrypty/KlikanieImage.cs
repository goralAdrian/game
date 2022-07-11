using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KlikanieImage : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    private GameObject myObject;
    public void OnBeginDrag(PointerEventData eventData)
    {
        myObject = Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<NoweBloki>().BuildingsKind(this.gameObject.name));

        myObject.name = this.gameObject.name;
        


        myObject.transform.position = new Vector2(Mathf.RoundToInt(eventData.delta.x), Mathf.RoundToInt(eventData.delta.y));

       // GameObject.Find("Main Camera").GetComponent<MyGameManager>().lista.Add(myObject.transform.position);
        GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 current = Camera.main.ScreenToWorldPoint(eventData.position);


        if (current.x >= 0 && current.x <= 23 && current.y >= 0 && current.y <= 14)
        {
            myObject.transform.position = new Vector2(Mathf.RoundToInt(current.x), Mathf.RoundToInt(current.y));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
