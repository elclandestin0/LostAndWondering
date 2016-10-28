using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// speed is the rate at which the object will rotate
	public float horizRotSpeed = 1000f;
	public float vertRotSpeed = 50f;
	public float horizRotHitbox = 0.2f;
	public float vertRotHitbox = 0.2f;
	public float moveSpeed = 5f;
    private Vector3 moveDirection = Vector3.zero;
   
    bool didPressButton; 

	public Camera cam;

	bool actForward = false;

	void Start()
    {
      
	

	}

	void Update ()
	{
       // OnGazeTriggerStart(cam);
        MoveForwardWithClick();
       
	}


	void MoveForwardWithClick ()
	{
		if (GvrViewer.Instance.Triggered) {
            actForward = true; 
		} else if (Input.GetButtonUp ("Fire1")) {
			actForward = false;
		}
        if (actForward == true)
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
     
	}
    /*
	void RotateScreenWithMouse()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 rotPlayer = new Vector3 (0f, 0f, 0f);
		Vector3 rotCamera = new Vector3 (0f, 0f, 0f);

		if (mousePos.x < Screen.width * horizRotHitbox) {//turn left
			rotPlayer.y = -1f;
		} else if (mousePos.x > Screen.width * (1 - horizRotHitbox)) {//turn right
			rotPlayer.y = 1f;
		}
		if (mousePos.y < Screen.height * vertRotHitbox) {//turn Down ... (fo what.. tum tum! tut'tum! tum...)
			rotCamera.x = 1f;
		} else if (mousePos.y > Screen.height * (1 - vertRotHitbox)) {//turn Up
			rotCamera.x = -1f;
		}

		transform.Rotate (rotPlayer * Time.deltaTime * horizRotSpeed);  
		cam.transform.Rotate (rotCamera * Time.deltaTime * vertRotSpeed); 

	}

    */

    void TriggerPulled()
    {
        cam.transform.Translate(Vector3.forward * Time.deltaTime * 20);
        Debug.Log("Meemz");
    }
}
