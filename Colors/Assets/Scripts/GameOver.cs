using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
	public Text resultText;
	public Button restart;
	// Use this for initialization
	void Start () {
		if (restart != null)
		{
			Debug.Log("Initializeing restart");
			Button restartBtn = restart.GetComponent<Button>();
			restartBtn.onClick.AddListener(restartArcade);
		}
		string result = "";
		result = "Answered " + ArcadeScript.numberOfQuestions + " with a final score of " + UIManager.arcadeScore + "!";
		if (resultText != null)
		{
			resultText.text = result;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void restartArcade()
	{
		Debug.Log("Hit restart");
		//Restart arcade mode
		SceneManager.LoadScene("ArcadeLevel");
	}
}
