using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

[SerializeField]
	private Button musicButton;

	[SerializeField]
	private Sprite[] musicIcons;

	void Start() {
		CheckToPlayTheMusic ();
	}

	void CheckToPlayTheMusic() {
		if (GamePreferences.GetMusicState () == 1) {
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcons [0];
		} else {
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcons [1];
		}
	}

	public void StartGame () {
		GameManager.instance.gameStartedFromMainMenu = true;
		Application.LoadLevel("Gameplay");
	}

	public void HighScoreMenu() {
		Application.LoadLevel("HighScore");
	}

	public void OptionsMenu() {
		Application.LoadLevel("OptionsMenu");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void ToggleMusic() {
		if (GamePreferences.GetMusicState () == 0) {
			GamePreferences.SetMusicState (1);
			MusicController.instance.PlayMusic (true);
			musicButton.image.sprite = musicIcons [0];
		} else if (GamePreferences.GetMusicState() == 1) {
			GamePreferences.SetMusicState (0);
			MusicController.instance.PlayMusic (false);
			musicButton.image.sprite = musicIcons [1];
		}
		
	}
}
