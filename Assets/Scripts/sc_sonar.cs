using UnityEngine;
using System.Collections;

public class sc_sonar : MonoBehaviour {

	bool going = false;
	float sonarPingingInterval = .5f;
	int PingsPerPinging = 1000;
	float lastPinged = 0f;

	AudioSource sonarChirp;

	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}

	public void Start(){
		going = true;
		sonarChirp = gameObject.GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if(going){
			transform.LookAt (r.a.mouseTracker.transform.position);

			float now = Time.time;
			if (now - lastPinged >= sonarPingingInterval) {
				sonarChirp.Play();
				lastPinged = now;
				for (int i = 0; i < PingsPerPinging; i++) {
					sonarPing (Random.Range (0f, 360f), Random.Range (0f, 90f), 1000f);
				}
			}
		}
	}

	void sonarPing(float rot, float deviate, float maxDist){
		RaycastHit hitInfo;
		Vector3 focus = transform.forward;
		Vector3 pseudoUp = transform.up;
		pseudoUp = Quaternion.AngleAxis (rot, focus) * pseudoUp;
		focus = Quaternion.AngleAxis (deviate, pseudoUp) * focus;

		if (Physics.Raycast (transform.position, focus, out hitInfo, maxDist)) {
			if (hitInfo.collider.tag == "world") {
				//create mark
				GameObject mark = (GameObject)Instantiate (r.p.mark,
					                  hitInfo.point + (hitInfo.normal.normalized * 0.1f),
					                  Quaternion.LookRotation (hitInfo.normal * -1f),
					                  r._Dynamic.transform);
				mark.GetComponent<Renderer> ().material = r.markMat.world;
			} else if (hitInfo.collider.tag == "worldConcrete") {
				//create mark
				GameObject mark = (GameObject)Instantiate (r.p.mark,
					                  hitInfo.point + (hitInfo.normal.normalized * 0.1f),
					                  Quaternion.LookRotation (hitInfo.normal * -1f),
					                  r._Dynamic.transform);
				mark.GetComponent<Renderer> ().material = r.markMat.concrete;
			}else if (hitInfo.collider.tag == "worldGlass") {
				//create mark
				GameObject mark = (GameObject)Instantiate (r.p.mark,
					hitInfo.point + (hitInfo.normal.normalized * 0.1f),
					Quaternion.LookRotation (hitInfo.normal * -1f),
					r._Dynamic.transform);
				mark.GetComponent<Renderer> ().material = r.markMat.glass;
			}
		}
	}
}
