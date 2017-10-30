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
	public Text currentColorName;
	public static int numberOfQuestions = 0;
	public List<Sprite> colorSprites = new List<Sprite>();
	public List<String> colorNames = new List<String>();
	public float timeLeft = 30;
	Sprite currentSprite;
	String currentSpriteName;
	String word;
	// Use this for initialization
	void Start () {
		if(colorSprites.Count != 0)
		{
			for(int i=0; i< colorSprites.Count; i++)
			{
				Debug.Log(colorSprites[i].name);
				colorNames.Add(colorSprites[i].name);
			}
			chooseNextBackground();
		}
		if(yes!= null)
		{
			Button yesBtn = yes.GetComponent<Button>();
			yesBtn.onClick.AddListener(yesPressed);
		}
		if (no != null)
		{
			Button noBtn = no.GetComponent<Button>();
			noBtn.onClick.AddListener(noPressed);
		}

	}



	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		ScoreText.text = "" + UIManager.arcadeScore;
		if(TimeText != null)
		{
			TimeText.text = "" + timeLeft.ToString("F0");
		}
		if (timeLeft <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		Debug.Log("Game Over! Score is: " + UIManager.arcadeScore);
		SceneManager.LoadScene("GameOver");
	}


	void chooseNextBackground()
	{
		int nextIndex = UnityEngine.Random.Range(0, colorSprites.Count - 1);
		Sprite nextSprite = colorSprites[nextIndex];
		background.GetComponent<Image>().sprite = nextSprite;
		currentSprite = nextSprite;
		currentSpriteName = nextSprite.name;
		currentColorName.text = chooseNextName();
		word = currentColorName.text;
		//Now set the color for the word. 
		currentColorName.color = getColorObject();
		numberOfQuestions++;
		//Debug.Log(currentSpriteName);
	}
	String chooseNextName()
	{
		int nextIndex = UnityEngine.Random.Range(0, colorNames.Count - 1);
		String name = colorNames[nextIndex];
		return name;
	}
	Color getColorObject()
	{
		Color color =Color.clear;
		ColorUtility.TryParseHtmlString(currentSpriteName, out color);
		return color;
	}
	void yesPressed()
	{
		//Check to see if text matches with actual color. 
		if(currentSpriteName == word)
		{
			//They got it right. 
			UIManager.arcadeScore += 10;
			//timeLeft += 5;
		}
		else
		{
			//Got it wrong!
			UIManager.arcadeScore -= 10;
			//timeLeft -= 5;
		}
		chooseNextBackground();
	}
	void noPressed()
	{
		//Check to see if text matches with actual color. 
		if (currentSpriteName != word)
		{
			//They got it right. 
			UIManager.arcadeScore += 10;
			//timeLeft += 5;
		}
		else
		{
			//Got it wrong!
			UIManager.arcadeScore -= 10;
			//timeLeft -= 5;
		}
		chooseNextBackground();
	}
}
