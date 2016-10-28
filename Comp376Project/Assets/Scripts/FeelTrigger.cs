using UnityEngine;
using System.Collections;

public class FeelTrigger : MonoBehaviour {

	public LayerMask whatIsWorld;
	public GameObject feelTracePrefab;
	public float traceInterval = 0.1f; //in seconds

	float timer = 0.0f;
	SphereCollider sc;

	void Start(){
		sc = gameObject.GetComponent<SphereCollider> ();
		sc.enabled = false;

	}

	// Use this for initialization
	void FixedUpdate () {
		timer += Time.deltaTime;
		if(timer >= traceInterval){
			sc.enabled = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		timer = 0;
		sc.enabled = false;
		Debug.Log ("Touch ");
		GameObject feelTrace = (GameObject)Instantiate(feelTracePrefab);
		feelTrace.transform.position = transform.position;
	}
}
