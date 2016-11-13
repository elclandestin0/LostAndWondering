using UnityEngine;
using System.Collections;

public class sc_enemies_manager : MonoBehaviour {
	int level = 0;

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
			Transform[] children = gameObject.GetComponentsInChildren<Transform> ();
			int enemiesLeft = (children.Length - 1);

			r.ui.statusText.text = "Level: " + level + ",                  Enemies Left: " + (children.Length-1);

			if (enemiesLeft == 0) {//next level

				level++;

				//telport bat to random spot
				r.a.bat.transform.position = new Vector3(-1000f,
					400f,
					-1000f);

				transform.position = new Vector3 (r.a.bat.transform.position.x,
					r.a.bat.transform.position.y + 300f,
					r.a.bat.transform.position.z);

				for (int i = 0; i < level; i++) {
					Instantiate (r.p.hawk,
						r.a.hawkGroup.transform.position,
						Quaternion.identity,
						r.a.hawkGroup.transform);
				}
			}
		}
	}
}
