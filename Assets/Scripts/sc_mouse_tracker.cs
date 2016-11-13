using UnityEngine;
using System.Collections;

public class sc_mouse_tracker : MonoBehaviour {

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

	void Update () {
		if(going){
			float forwardDisp = 50f;
			float multiplierX = 200f;
			float multiplierY = 200f;
			float affsetY = -0.05f;

			//Vector3 mouseInView = Camera.main.ScreenToViewportPoint (Input.mousePosition);
			float mouseXFrac = Input.mousePosition.x / Screen.width - 0.5f;
			float mouseYFrac = Input.mousePosition.y / Screen.height - 0.5f;

			transform.position = r.a.bat.transform.position;
			transform.rotation = r.a.bat.transform.rotation;
			transform.Translate (transform.forward * forwardDisp, Space.World);
			transform.Translate (transform.right * mouseXFrac * multiplierX, Space.World);
			transform.Translate (transform.up * (mouseYFrac + affsetY) * multiplierY, Space.World);
			//Debug.Log ("" + Input.mousePosition.x + ", " + Input.mousePosition.y );
		}
	}
}
