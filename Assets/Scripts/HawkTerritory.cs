using UnityEngine;
using System.Collections;

public class HawkTerritory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            transform.Find("Hawk").GetComponent<HawkController>().attackingBat = true;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            transform.Find("Hawk").GetComponent<HawkController>().attackingBat = false;
        }
    }
}
