using UnityEngine;
using System.Collections;

public class HawkController : MonoBehaviour {

    private Transform _target;
    public float moveSpeed; 
    private int rotationSpeed = 3;


    void Start()
    {
        _target = GameObject.FindWithTag("player").transform;
    }


    void FixedUpdate()
    {
        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(_target.position - transform.position), rotationSpeed * Time.deltaTime);

        //move towards the player
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
    }
}
