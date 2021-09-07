using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore : MonoBehaviour
{
  
	[SerializeField]
	private TextMeshProUGUI scoreText, coinText;
    

	void Start () {
		SetScoreBasedOnDifficulty ();
        // Debug.Log("CHECK");
	}

	void SetScore(int score, int coinScore) {
		scoreText.text = score.ToString ();
		coinText.text = coinScore.ToString ();
	}

	void SetScoreBasedOnDifficulty() {

		if (GamePreferences.GetEasyDifficulty () == 1) {
			SetScore (GamePreferences.GetEasyDifficultyHighScore (), GamePreferences.GetEasyDifficultyCoinScore ());
		}

		if (GamePreferences.GetMediumDifficulty () == 1) {
			SetScore (GamePreferences.GetMediumDifficultyHighScore (), GamePreferences.GetMediumDifficultyCoinScore ());
		}

		if (GamePreferences.GetHardDifficulty () == 1) {
			SetScore (GamePreferences.GetHardDifficultyHighScore (), GamePreferences.GetHardDifficultyCoinScore ());
		}
	}

    public void GoBackToMainMenu(){
        Application.LoadLevel("MainMenu");
    }
}
