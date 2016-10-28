using UnityEngine;
using System.Collections;

public class LightTest : MonoBehaviour {

	public float repeatTime = 1f;

	float timer = 0f;
	bool toggle = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Debug.Log (timer);
		if (timer >= repeatTime) {
			timer = 0f;
			if(toggle)
				GetComponent<Light> ().intensity = 10f;
			else
				GetComponent<Light> ().intensity = 0f;
			toggle = !toggle;
		}
		
	}
}
