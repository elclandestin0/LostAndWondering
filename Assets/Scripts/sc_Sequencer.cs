using UnityEngine;
using System.Collections;

public class sc_Sequencer : MonoBehaviour {

	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}
		
	void Start(){
		//starting sequence
		r.sc.s1.go();
	}

	void FixedUpdate () {
	
	}
		
}
