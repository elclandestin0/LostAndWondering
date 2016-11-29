using UnityEngine;
using System.Collections;

public class sc_death_by_time : MonoBehaviour {

	public float lifeTime;
	float birthTime;
	
	void Start(){
		birthTime = Time.time;
	}

	void FixedUpdate () {
		if (Time.time - birthTime >= lifeTime)
			Destroy (gameObject);
	}

	void Update(){
		//transform.LookAt (Camera.main.transform.position, Vector3.up);
	}
}
