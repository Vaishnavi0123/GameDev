using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public static MenuController instance;

	[SerializeField]
	private GameObject[] spirits;

	private bool isGreenSpiritUnlocked, isYellowSpiritUnlocked;

	[SerializeField]
	private Animator notificationAnim;
	
	[SerializeField]
	private Text notificationText;
		
	void Awake() {
		MakeInstance();
	}

	void Start() {
		spirits [GameController.instance.GetSelectedSpirit ()].SetActive (true);
		CheckIfSpiritsAreUnlocked ();
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void CheckIfSpiritsAreUnlocked() {
		if (GameController.instance.IsYellowSpiritUnlocked () == 1) {
			isYellowSpiritUnlocked = true;
		}

		if (GameController.instance.IsGreenSpiritUnlocked () == 1) {
			isGreenSpiritUnlocked = true;
		}
	}

	public void PlayGame() {
		SceneFader.instance.FadeIn ("Gameplay");
	}
	
	public void ChangeSpirit() {

		if (GameController.instance.GetSelectedSpirit()==0) {

			if (isGreenSpiritUnlocked) {
				spirits[0].SetActive(false);
				GameController.instance.SetSelectedSpirit(1);
				spirits[GameController.instance.GetSelectedSpirit()].SetActive(true);
			}

		} else if (GameController.instance.GetSelectedSpirit()==1) {

			if (isYellowSpiritUnlocked) {

				spirits[1].SetActive(false);
				GameController.instance.SetSelectedSpirit(2);
				spirits[GameController.instance.GetSelectedSpirit()].SetActive(true);

			} else {

				spirits[1].SetActive (false);
				GameController.instance.SetSelectedSpirit(0);
				spirits[GameController.instance.GetSelectedSpirit()].SetActive(true);

			}

		} else if (GameController.instance.GetSelectedSpirit()==2) {
			spirits[2].SetActive(false);
			GameController.instance.SetSelectedSpirit(0);
			spirits[GameController.instance.GetSelectedSpirit()].SetActive(true);
		}

	}

	public void NotificationMessage(string message)
	 {
		StartCoroutine (AnimateNotificationPanel(message));
	}

	IEnumerator AnimateNotificationPanel(string message) {
		notificationAnim.Play("SlideIn");
		notificationText.text = message;
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(2f));
		notificationAnim.Play("SlideOut");
	}

	
} 































































