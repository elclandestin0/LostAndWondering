using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {

    public float _batSpeed;
    private float _batFlapTimer;
    private const float FLAPTIMER = 0.1f;
    private int _flapAnimation;
    private Quaternion _batRotation;

	// Use this for initialization
	void Start () {
        _batFlapTimer = 0.4f;
        _flapAnimation = 1;
        _batRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        FlapWings();
	}

    void FixedUpdate()
    {
        Move();
    }   

    void FlapWings()
    {
        if(_batFlapTimer >= FLAPTIMER)
        {
            _batFlapTimer = 0.0f;
            transform.Find("Bat_Anim" + _flapAnimation).gameObject.SetActive(false);
            _flapAnimation = (_flapAnimation + 1) % 7;
            transform.Find("Bat_Anim" + _flapAnimation).gameObject.SetActive(true);
            //if(_flapAnimation == 1 && ((int)(_flapAnimation/7)) % 2 == 0)
            //{
            //    GetComponent<Rigidbody>().AddForce(0f, _flapStrength, 0f);
            //}
        }
        else
        {
            _batFlapTimer += Time.deltaTime;
        }
    }

    void Move()
    {
        Vector3 moveHorizontal = transform.right * Input.GetAxis("Horizontal");
        Vector3 moveVertical = transform.forward * Input.GetAxis("Vertical");

        Vector3 v3Rot = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 v3Pos = Input.mousePosition;
        v3Pos.z = 0f;
        v3Pos = Camera.main.ScreenToViewportPoint(v3Pos);

        if (v3Pos.x < 0.4)
            transform.Rotate(-v3Rot);
        else if (v3Pos.x > 0.6)
            transform.Rotate(v3Rot);
        
        GetComponent<Rigidbody>().AddForce((moveHorizontal + moveVertical - (transform.up * 10f)) * Time.deltaTime * _batSpeed);
        if (GetComponent<Rigidbody>().velocity.x > _batSpeed/10)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(_batSpeed / 10, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        if (GetComponent<Rigidbody>().velocity.y > _batSpeed / 10)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, _batSpeed / 10, GetComponent<Rigidbody>().velocity.z);
        }
        if (GetComponent<Rigidbody>().velocity.z > _batSpeed / 10)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, _batSpeed / 10);
        }
    }
}
