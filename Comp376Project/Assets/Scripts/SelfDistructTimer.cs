using UnityEngine;
using System.Collections;

public class SelfDistructTimer : MonoBehaviour {

	public float selfDistructTime = 10f;

	float timer = 0f;
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= selfDistructTime) {
			Destroy (gameObject);
		}
	}
}
