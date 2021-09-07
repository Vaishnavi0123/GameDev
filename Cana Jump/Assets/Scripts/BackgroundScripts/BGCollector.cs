using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
	    if(target.tag=="Background"){
			// Debug.Log("collected");
            target.gameObject.SetActive(false);
		}
	}
}
