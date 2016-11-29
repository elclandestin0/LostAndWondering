using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HawkTerritory : MonoBehaviour {
    public Text hawksFollowingHUD;
    // Use this for initialization
    void Start () {
        hawksFollowingHUD.text = "Hawks Following : NO";
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            transform.Find("Hawk").GetComponent<HawkController>().attackingBat = true;
            hawksFollowingHUD.text = "Hawks Following : YES";
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            transform.Find("Hawk").GetComponent<HawkController>().attackingBat = false;
            hawksFollowingHUD.text = "Hawks Following : NO";
        }
    }
}
