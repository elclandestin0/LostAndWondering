using UnityEngine;
using System.Collections;

public class BabyBatController : MonoBehaviour {

    private Transform _target;
    private Transform _cave;
    public float moveSpeed;
    private int rotationSpeed = 50;
    private BatFlapController batFlapController;
    public GameObject BabyBat;
    public static string _follow;
    public float followParentDistance;
    private Vector3 _spawnPosition;
    private Quaternion _spawnRotation;

    void Start()
    {
        _target = GameObject.FindWithTag("player").transform;
        _cave = GameObject.FindWithTag("cave").transform;
        _spawnPosition = transform.position;
        _spawnRotation = transform.rotation;
        batFlapController = BabyBat.GetComponent<BatFlapController>();
        _follow = "";
    }


    void Update()
    {
        Move();
    }

    void FollowParent()
    {
        if (_follow.Equals("bat"))
        {
            if(Vector3.Distance(transform.position, _target.transform.position) > 4f)
            {
                //rotate to look at the player
                transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(_target.position - transform.position), rotationSpeed * Time.deltaTime);

                //move towards the player
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
            }
            batFlapController.FlapWings();
        }
        //Only set it the first time
        else if (Vector3.Distance(transform.position, _target.position) <= followParentDistance)
        {
            transform.Find("Bat_morph/Bat_Anim0").gameObject.SetActive(false);
            _follow = "bat";
        }
    }

    void EnterCave()
    {
        if (_follow.Equals("cave"))
        {
            //rotate to look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(_cave.position - transform.position), rotationSpeed * Time.deltaTime);

            //move towards the player
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
            batFlapController.FlapWings();
        }
        //Only set it the first time
        else if(Vector3.Distance(transform.position, _cave.position) <= followParentDistance)
        {
            _follow = "cave";
        }
    }

    void Move()
    {
        EnterCave();
        if (!_follow.Equals("cave"))
        {
            FollowParent();
        }
    }

    public void Respawn()
    {
        transform.position = _spawnPosition;
        transform.rotation = _spawnRotation;
    }
}
