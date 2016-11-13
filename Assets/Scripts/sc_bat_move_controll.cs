using UnityEngine;
using System.Collections;

public class sc_bat_move_controll : MonoBehaviour {

	bool going = false;
	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}
		
	void Start(){
		going = true;
	}

	void FixedUpdate () {
		if(going && !r.reset){
			//Debug.Log (transform.position);

			float speedRot = 150f;
			//float rotHoriz = Input.GetAxis ("Rotate");
			float rotHoriz = Input.mousePosition.x / Screen.width - 0.5f;
			//Debug.Log ("" + rotHoriz);
			r.a.bat.transform.Rotate (Vector3.up * rotHoriz * speedRot * Time.deltaTime, Space.World);

			float speedforward = 100f;
			if (Input.GetKey ("tab"))
				speedforward *= 10f; 
			transform.position = Vector3.MoveTowards (transform.position,
				r.a.mouseTracker.transform.position,
				speedforward * Time.deltaTime);
		}
	}


}
