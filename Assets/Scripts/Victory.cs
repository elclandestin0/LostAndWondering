using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour {

    private float _sceneCounter;

	// Use this for initialization
	void Start () {
        _sceneCounter = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        _sceneCounter += Time.deltaTime;
	    if (_sceneCounter > 4.0f)
        {
            SceneManager.LoadScene("Menu");
        }
	}
}
