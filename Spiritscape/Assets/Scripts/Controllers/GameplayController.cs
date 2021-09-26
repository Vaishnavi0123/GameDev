using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

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


} 









































































