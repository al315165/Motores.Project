using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_ChangeScreen : MonoBehaviour {
	public Vector2 cursorWorld;

	public Image Pointer;

	void Awake()
	{
		Screen.SetResolution (1102, 560, false);
		Cursor.visible = false;
	}

	void Update()
	{

		//We want to make the image Pointer to move along with the cursor.
		//cursorWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		cursorWorld = Input.mousePosition;

		Pointer.rectTransform.position = cursorWorld;

	}

	public void ScreenChange(int level)
	{
			SceneManager.LoadScene(level);
	}

	public void QuitGame()
	{
			Application.Quit();
	}

}

//Sergi Estuvo Aquí
