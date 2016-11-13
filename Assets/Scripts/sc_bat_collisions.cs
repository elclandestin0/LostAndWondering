using UnityEngine;
using System.Collections;

public class sc_bat_collisions : MonoBehaviour {

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

	void OnTriggerEnter(Collider other) {
		if(going){
			//Debug.Log ("Collision with: " + other.tag);
			if (other.tag == "enemy" || other.tag == "world" || other.tag == "worldConcrete" || other.tag == "worldGlass") {
				Instantiate (r.p.splat,
					transform.position,
					Quaternion.identity,
					r._Dynamic.transform);

				r.resetInSec (4f);
			}
		}
	}
}
