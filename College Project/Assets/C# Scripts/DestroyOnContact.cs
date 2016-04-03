using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (this.gameObject);
		if(other.gameObject == GameObject.Find("Player")) {
			Destroy (other.gameObject);
		}
	}
}
