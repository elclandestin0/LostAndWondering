using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HawkTerritory : MonoBehaviour {
    public Text hawksFollowingHUD;
    private AudioSource heartbeat; 

    // Use this for initialization
    void Start () {
        hawksFollowingHUD.text = "Hawks Following : NO";
        heartbeat = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            heartbeat.Play(); 
            hawksFollowingHUD.text = "Hawks Following : YES";
            transform.Find("Hawk").GetComponent<HawkController>().attackingBat = true;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (heartbeat.isPlaying)
            {
                heartbeat.Stop(); 
            }
            hawksFollowingHUD.text = "Hawks Following : NO";
            transform.Find("Hawk").GetComponent<HawkController>().attackingBat = false;
        }
    }

}
