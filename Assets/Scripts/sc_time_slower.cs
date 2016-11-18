using UnityEngine;
using System.Collections;

public class sc_time_slower : MonoBehaviour {

	bool going = false;
	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}

	public void go(){
		//going = true;

	}

	void Start(){
		going = true;

	}

	void FixedUpdate () {
		if(going){
			if (Input.GetButton ("Slow Time")) {
				Time.timeScale = 0.5f;
				r.a.farCamera.SetActive (false);
				r.a.closeCamera.SetActive (true);
			} else {
				Time.timeScale = 1f;
				r.a.closeCamera.SetActive (false);
				r.a.farCamera.SetActive (true);
			}
		}
	}
}
