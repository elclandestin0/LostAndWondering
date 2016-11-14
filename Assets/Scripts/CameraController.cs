using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private const float Y_Angle_MIN = -45.0f;
    private const float Y_Angle_MAX = 50.0f;
  
    public GameObject lookAt;

    private Transform lookAtTransform;
    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivity = 4.0f;
    private Vector3 _direction;
    private Quaternion _rotation;

    // Use this for initialization
    void Start () {
        lookAtTransform = lookAt.GetComponent<Transform>();
        
    }
	
	// Update is called once per frame
	void Update () {
        currentX = Input.GetAxis("Mouse X") * sensitivity;
        currentY = Input.GetAxis("Mouse Y") * sensitivity;

        currentY = Mathf.Clamp(currentY, Y_Angle_MIN, Y_Angle_MAX);

    }

    void LateUpdate()
    {
        _direction = new Vector3(0, 0, -distance);
        _rotation = Quaternion.Euler(currentX, currentY, 0);
        Debug.Log(_rotation);
        transform.position = lookAtTransform.position + _rotation * _direction;
        transform.LookAt(lookAtTransform.position);

    }
}
