using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;
	private const string HIGH_SCORE = "High Score";
	private const string SELECTED_SPIRIT = "Selected Spirit";
	private const string GREEN_SPIRIT = "Green Spirit";
	private const string YELLOW_SPIRIT = "Yellow Spirit";

	void Awake() {
		MakeSingleton ();
		IsTheGameStartedForTheFirstTime ();
		PlayerPrefs.DeleteAll ();
	}

	void Start () {
		
	}
	
	void MakeSingleton() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void IsTheGameStartedForTheFirstTime() {
		if (!PlayerPrefs.HasKey ("IsTheGameStartedForTheFirstTime")) {
			PlayerPrefs.SetInt(HIGH_SCORE, 0);
			PlayerPrefs.SetInt(SELECTED_SPIRIT, 0);
			PlayerPrefs.SetInt(GREEN_SPIRIT, 1);
			PlayerPrefs.SetInt(YELLOW_SPIRIT, 1);
			PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 0);
		} 
	}

	public void SetHighscore(int score) {
		PlayerPrefs.SetInt (HIGH_SCORE, score);
	}

	public int GetHighscore() {
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

	public void SetSelectedSpirit(int selectedSpirit) {
		PlayerPrefs.SetInt (SELECTED_SPIRIT, selectedSpirit);
	}

	public int GetSelectedSpirit() {
		return PlayerPrefs.GetInt (SELECTED_SPIRIT);
	}

	public void UnlockGreenSpirit() {
		PlayerPrefs.SetInt (GREEN_SPIRIT, 1);
	}
	
	public int IsGreenSpiritUnlocked() {
		return PlayerPrefs.GetInt(GREEN_SPIRIT);
	}

	public void UnlockYellowSpirit() {
		PlayerPrefs.SetInt (YELLOW_SPIRIT, 1);
	}

	public int IsYellowSpiritUnlocked() {
		return PlayerPrefs.GetInt(YELLOW_SPIRIT);
	}

} 


























































