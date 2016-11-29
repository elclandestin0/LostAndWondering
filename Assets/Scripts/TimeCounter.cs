using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {
    public Text timeUI;
    float startTime;
    float ellapsedTime;
    bool startCounter;
    int Minutes;
    int Seconds;
	// Use this for initialization
	void Start () {
        startCounter = true;
        timeUI = GetComponent<Text> ();
	}
	public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }
    public void StopTimeCounter()
    {
        startCounter = false;
    }
	// Update is called once per frame
	void Update () {
	if (startCounter)
        {
            ellapsedTime = Time.time - startTime;
            Minutes = (int)ellapsedTime / 60; //casting
            Seconds = (int)ellapsedTime % 60; //casting
            timeUI.text = "Time : " + string.Format(" {0:00}:{1:00}", Minutes, Seconds); //dont change this
        }
	}
}
