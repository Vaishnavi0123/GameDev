using UnityEngine;
using System.Collections;

public static class MyCoroutine {

	public static IEnumerator WaitForRealSeconds(float time) {
		
		float start = Time.realtimeSinceStartup;
		Debug.Log("Test");

		while(Time.realtimeSinceStartup < (start + time)) {
			yield return null;
		}

	}

}
