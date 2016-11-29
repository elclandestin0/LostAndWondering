using UnityEngine;
using System.Collections;

public class HawkController : MonoBehaviour {

    private GameObject _target;
    public float moveSpeed; 
    private int rotationSpeed = 3;
    public float degreesPerSecond = -65.0f;
    private int _indexToFollow;
    private ArrayList _pathToFollow;
    public bool attackingBat;

    void Start()
    {
        _target = GameObject.FindWithTag("player");
        _pathToFollow = PathToFollow();
        _indexToFollow = Random.Range(1, _pathToFollow.Count);
        attackingBat = false;
    }

    void Update()
    {
        AttackBat();
    }


    void FixedUpdate()
    {
        FollowPath();
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        if (attackingBat)
        {
            //rotate to look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(_target.transform.position - transform.position), rotationSpeed * Time.deltaTime);

            //move towards the player
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
        }
    }

    void AttackBat()
    {
        if(Vector3.Distance(transform.position, _target.transform.position) <= 4f)
        {
            _target.transform.parent.GetComponent<BatController>().Respawn();
        }
    }

    void FollowPath()
    {
        if (!attackingBat)
        {
            if(Vector3.Distance(transform.position, (Vector3)_pathToFollow[_indexToFollow]) >= 1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation((Vector3)_pathToFollow[_indexToFollow] - transform.position), rotationSpeed * Time.deltaTime);

                //move towards the player
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                _indexToFollow = ++_indexToFollow % _pathToFollow.Count;
            }
        }
    }

    ArrayList PathToFollow()
    {
        ArrayList path = new ArrayList();
        Vector3 center = transform.parent.GetComponent<Collider>().bounds.center;
        Vector3 boxBounds = transform.parent.GetComponent<Collider>().bounds.extents;
        path.Add(center);
        path.Add(center + new Vector3(boxBounds.x, 0 ,0));
        path.Add(center + new Vector3(boxBounds.x, 0, boxBounds.z));
        path.Add(center + new Vector3(-boxBounds.x, 0, boxBounds.z));
        path.Add(center + new Vector3(-boxBounds.x, 0, -boxBounds.z));
        path.Add(center + new Vector3(boxBounds.x, 0, -boxBounds.z));

        return path;
    }

}
