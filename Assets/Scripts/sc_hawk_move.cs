using UnityEngine;
using System.Collections;

public class sc_hawk_move : MonoBehaviour {

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
		transform.rotation = Quaternion.AngleAxis (Random.Range (0f, 360f), transform.up);

	}

	void FixedUpdate () {
		if(going){
			float speedRot = 1f;

			//move
			float speedforward = 120f;
			transform.Translate (transform.forward * speedforward * Time.deltaTime, Space.World);

			//rotate to target
			Vector3 targetPos = r.a.bat.transform.position;
			targetPos.y = 0f;
			Vector3 currPos = transform.position;
			currPos.y = 0;

			Vector3 targetDir = targetPos - currPos;
			float step = speedRot * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0f);
			transform.rotation = Quaternion.LookRotation (newDir);

			float speedY = 50f;
			if (transform.position.y > r.a.bat.transform.position.y) {
				speedY = -speedY;
			}
			transform.Translate (transform.up * speedY * Time.deltaTime, Space.World);

		}
	}
}
