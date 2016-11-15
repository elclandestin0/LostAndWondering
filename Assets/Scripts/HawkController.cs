using UnityEngine;
using System.Collections;

public class HawkController : MonoBehaviour {

    private GameObject _target;
    public float moveSpeed; 
    private int rotationSpeed = 3;


    void Start()
    {
        _target = GameObject.FindWithTag("player");
    }

    void Update()
    {
        AttackBat();
    }


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(_target.transform.position - transform.position), rotationSpeed * Time.deltaTime);

        //move towards the player
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
    }

    void AttackBat()
    {
        if(Vector3.Distance(transform.position, _target.transform.position) <= 4f)
        {
            _target.transform.parent.GetComponent<BatController>().Respawn();
        }
    }
}
