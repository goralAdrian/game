using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoMenu : MonoBehaviour
{
	public void returnToMenu(){
		SceneManager.LoadScene("Scene");
	}
}
