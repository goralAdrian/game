using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skrypt : MonoBehaviour
{
	private Camera ImCamera;
	private float targetZoom;
	private float zoomFactory = 3f;
	[SerializeField] private float zoomLerpSpeed = 10;
	
	void Start()
	{
		ImCamera = Camera.main;
		targetZoom = ImCamera.orthographicSize;
	}
	
    void Update()
    {
		float scrollData;
		scrollData = Input.GetAxis("Mouse ScrollWheel");
		
		targetZoom -= scrollData * zoomFactory;
		ImCamera.orthographicSize = Mathf.Lerp(ImCamera.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
		

		if (Input.GetKey(KeyCode.UpArrow))
		{
			if(ImCamera.transform.position.y < 10)
			{
				transform.Translate(Vector3.up);
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			if(ImCamera.transform.position.y > 4)
			{
				transform.Translate(Vector3.down);
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if(ImCamera.transform.position.x > 9)
			{
				transform.Translate(Vector3.left);
			}

		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if(ImCamera.transform.position.x < 16)
			{
				transform.Translate(Vector3.right);
			}

		}
		if (Input.GetKey(KeyCode.R))
		{
			ImCamera.transform.position = new Vector3(12.5f, 7.0f, -10);
			targetZoom = 7.5f;
		}
		
	}
}