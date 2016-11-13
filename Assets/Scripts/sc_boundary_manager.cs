using UnityEngine;
using System.Collections;

public class sc_boundary_manager : MonoBehaviour {

	int cellEast = 0;
	int cellNorth = 0;

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

	void FixedUpdate(){
		if (going) {
			float top = r.a.boundaryBox.transform.position.y + r.a.boundaryBox.transform.localScale.y / 2f;
			GameObject target = r.a.bat;
			if (getY(target) >= top) {//bump from top
				changeY(target, top - 10f);
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if(going){
			float west = r.a.boundaryBox.transform.position.x - r.a.boundaryBox.transform.localScale.x / 2f;
			float east = r.a.boundaryBox.transform.position.x + r.a.boundaryBox.transform.localScale.x / 2f;
			float north = r.a.boundaryBox.transform.position.z + r.a.boundaryBox.transform.localScale.z / 2f;
			float south = r.a.boundaryBox.transform.position.z - r.a.boundaryBox.transform.localScale.z / 2f;
			float spanEW = east - west;
			float spanNS = north - south;

			GameObject target = r.a.bat;
			bool reloadCell = false;
			if (getX(target) <= west) {//bump from west
				changeX(target, getX(target) + spanEW);
				cellEast--;
				reloadCell = true;
			}
			if (getX(target) >= east) {//bump from east
				changeX(target, getX(target) - spanEW);
				cellEast++;
				reloadCell = true;
			}
			if (getZ(target) <= south) {//bump from south
				changeZ(target, getZ(target) + spanNS);
				cellNorth--;
				reloadCell = true;
			}
			if (getZ(target) >= north) {//bump from north
				changeZ(target, getZ(target) - spanNS);
				cellNorth++;
				reloadCell = true;
			}
			if (reloadCell) {
				//TODO
				Debug.Log("Cell: cellEast" + cellEast + ", cellNorth=" + cellNorth);
			}
		}
	}

	float getX(GameObject target){
		return target.transform.position.x;
	}

	float getY(GameObject target){
		return target.transform.position.y;
	}

	float getZ(GameObject target){
		return target.transform.position.z;
	}
	void changeX(GameObject target, float newVal){
		target.transform.position = new Vector3 (newVal, 
			target.transform.position.y,
			target.transform.position.z);
	}

	void changeY(GameObject target, float newVal){
		target.transform.position = new Vector3 (target.transform.position.x, 
			newVal,
			target.transform.position.z);
	}

	void changeZ(GameObject target, float newVal){
		target.transform.position = new Vector3 (target.transform.position.x, 
			target.transform.position.y,
			newVal);
	}
}
