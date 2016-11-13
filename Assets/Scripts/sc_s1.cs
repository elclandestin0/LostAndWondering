using UnityEngine;
using System.Collections;

public class sc_s1 : MonoBehaviour {
	
	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}
		
	public void go(){	

		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				GameObject bSeed = (GameObject)Instantiate (r.p.buildingSeed,
					new Vector3 (400f * ((float)i), 0f, 400f * ((float)j)),
					Quaternion.identity,
					r._Dynamic.transform);

				bSeed.GetComponent<sc_building_seed> ().go (Random.Range (15, 30));
			}
		}
	}

	void FixedUpdate () {
	
	}
		
}
