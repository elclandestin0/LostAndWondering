using UnityEngine;
using System.Collections;

public class sc_building_seed : MonoBehaviour {

	bool going = false;
	public int floors = 10;
	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}

	public void go(int floors){
		going = true;
		this.floors = floors;
		transform.position = new Vector3 (transform.position.x, 0f, transform.position.z);
		for (int i = 0; i < floors; i++) {
			GameObject floor = (GameObject)Instantiate (r.p.buildingFloor,
				transform.position + new Vector3(0f, ((float)i) *  r.p.buildingFloor.transform.localScale.y, 0f),
				Quaternion.identity,
				transform);

			//floor.transform.localScale = r.p.buildingFloor.transform.localScale;
		}
	}

	void Start(){
		//going = true;

	}

	void FixedUpdate () {
		if(going){

		}
	}
}
