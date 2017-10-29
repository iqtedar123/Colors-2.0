using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public static int arcadeScore;
	public Button launchArcadeBtnRef;
	// Use this for initialization
	void Start () {
		if(launchArcadeBtnRef != null)
		{
			Button launchArcadeBtn = launchArcadeBtnRef.GetComponent<Button>();
			launchArcadeBtn.onClick.AddListener(launchArcade);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void launchArcade()
	{
		//Opens Arcade Menu
		SceneManager.LoadScene("ArcadeLevel");
	}
}
