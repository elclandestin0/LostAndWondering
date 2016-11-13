using UnityEngine;
using System.Collections;

public class sc_north_halo : MonoBehaviour {

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
			transform.position = r.a.bat.transform.position;
			transform.Translate (Vector3.forward * 200f);
		}
	}
}
