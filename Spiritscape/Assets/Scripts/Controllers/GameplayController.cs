using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.IO;


public class GameplayController : MonoBehaviour {

	public static GameplayController instance;
	
	[SerializeField]
	private TextMeshProUGUI scoreText, endScore, bestScore, gameOverText;
	
	[SerializeField]
	private Button restartGameButton, instructionsButton;
	
	[SerializeField]
	private GameObject pausePanel;
	
	[SerializeField]
	private GameObject[] spirits;
	
	[SerializeField]
	private Sprite[] medals;
	
	[SerializeField]
	private Image medalImage;

	void Awake() {
		MakeInstance ();
		Time.timeScale = 0f;
	}

	void Start () {
	
	}
	
	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	public void PauseGame() {
		if (SpiritScript.instance != null) {
			if(SpiritScript.instance.isAlive) {
				pausePanel.SetActive(true);
				gameOverText.gameObject.SetActive(false);
				endScore.text = "" + SpiritScript.instance.score;
				bestScore.text = "" + GameController.instance.GetHighscore();
				Time.timeScale = 0f;
				restartGameButton.onClick.RemoveAllListeners();
				restartGameButton.onClick.AddListener(() => ResumeGame());
			}
		}
	}

	public void GoToMenuButton() {
		SceneFader.instance.FadeIn ("MainMenu");
	}

	public void ResumeGame() {
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}

	public void RestartGame() {
		SceneFader.instance.FadeIn (Application.loadedLevelName);
	}

	public void PlayGame() {
		scoreText.gameObject.SetActive (true);
		spirits [GameController.instance.GetSelectedSpirit ()].SetActive (true);
		instructionsButton.gameObject.SetActive (false);
		Time.timeScale = 1f;
	}

	public void SetScore(int score) {
		scoreText.text = "" + score;
	}

	public void PlayerDiedShowScore(int score) {
		pausePanel.SetActive (true);
		gameOverText.gameObject.SetActive (true);
		scoreText.gameObject.SetActive (false);

		endScore.text = "" + score;

		if (score > GameController.instance.GetHighscore ()) {
			GameController.instance.SetHighscore(score);
		}

		bestScore.text = "" + GameController.instance.GetHighscore ();

		if (score <= 20) {
			medalImage.sprite = medals [0];
		} else if (score > 20 && score < 40) {
			medalImage.sprite = medals [1];

			if (GameController.instance.IsGreenSpiritUnlocked () == 0) {
				GameController.instance.UnlockGreenSpirit ();
			}

		} else {
			medalImage.sprite = medals [2];
			
			if (GameController.instance.IsGreenSpiritUnlocked () == 0) {
				GameController.instance.UnlockGreenSpirit ();
			}

			if (GameController.instance.IsYellowSpiritUnlocked () == 0) {
				GameController.instance.UnlockYellowSpirit ();
			}

		}

		restartGameButton.onClick.RemoveAllListeners ();
		restartGameButton.onClick.AddListener (() => RestartGame());

	}

	public void ShareScore ()
	{
		pausePanel.SetActive (true);//show the panel
		StartCoroutine ("TakeScreenShotAndShare");
	}

	IEnumerator TakeScreenShotAndShare ()
	{
		yield return new WaitForEndOfFrame ();

		Texture2D tx = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
		tx.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		tx.Apply ();

		string path = Path.Combine (Application.temporaryCachePath, "sharedImage.png");//image name
		File.WriteAllBytes (path, tx.EncodeToPNG ());

		Destroy (tx); //to avoid memory leaks

		new NativeShare ()
			.AddFile (path)
			.SetSubject ("This is my score")
			.SetText ("share your score with your friends")
			.Share ();


		pausePanel.SetActive (false); //hide the panel
		SceneFader.instance.FadeIn ("MainMenu");
	}


} 









































































