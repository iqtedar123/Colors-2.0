using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ArcadeScript : MonoBehaviour {
	public Image background;
	public Button yes;
	public Button no;
	public Text TimeText;
	public Text ScoreText;
	public List<Sprite> colorSprites = new List<Sprite>();
	public float timeLeft = 100;
	// Use this for initialization
	void Start () {

		
	}



	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(TimeText != null)
		{
			TimeText.text = "" + timeLeft.ToString("F2");
		}
		if (timeLeft <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		Debug.Log("Game Over! Score is: " + UIManager.arcadeScore);
		//SceneManager.LoadScene("GameOver");
	}



}
