using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoweBloki : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject[] kindres;

	/*
    void Start()
    {
    }
    void Update()
    {
    }
	*/

    public void Ustawienia(GameObject gameObject)
    {
        foreach (GameObject a in kindres)
        {
            a.SetActive(false);
        }

        if (gameObject == null)
            return;
    }
	

    public GameObject BuildingsKind(string name)
    {
        return buildings[int.Parse(name)-1];
    }

}
