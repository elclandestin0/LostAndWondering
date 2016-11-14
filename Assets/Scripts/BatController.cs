using UnityEngine;


public class BatController : MonoBehaviour {
    private const float Y_Angle_MIN = -50.0f;
    private const float Y_Angle_MAX = 50.0f;
    
    private float sensitivity = 2.0f;
    private float smoothing = 1.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private Vector2 _mouseLook;
    private Vector2 _smoothV;
    public float batSpeed;
    public GameObject Bat;
    private BatFlapController batFlapController;
    private Quaternion _batRotation;

	// Use this for initialization
	void Start () {
        

        batFlapController = Bat.GetComponent<BatFlapController>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        /*var right = transform.right;
        var up = transform.up;
        currentX = Input.GetAxis("Mouse X") * sensitivity;
        currentY = Input.GetAxis("Mouse Y") * sensitivity;
        
        var md = new Vector2(currentX, currentY);
        md = Vector2.Scale(md, new Vector2(smoothing, smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, md.x, 1f / smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, md.y, 1f / smoothing);
        _mouseLook += _smoothV;

        _mouseLook.y = Mathf.Clamp(_mouseLook.y, Y_Angle_MIN, Y_Angle_MAX);
        //_mouseLook.x = Mathf.Clamp(_mouseLook.x, -25, 25);

        Debug.Log(_mouseLook);
        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, right);
        transform.localRotation *= Quaternion.AngleAxis(_mouseLook.x, up);

        */
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(_batRotation.eulerAngles), Time.deltaTime * 10f);


        batFlapController.FlapWings();

    }

    void FixedUpdate()
    {

        Move();
    }   


    void Move()
    {
        float translation = Input.GetAxis("Vertical") * batSpeed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * batSpeed * Time.deltaTime;
        //transform.Translate(straffe, 0, translation);
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(straffe, 0, translation));

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ;
    }

}
