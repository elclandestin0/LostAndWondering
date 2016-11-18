using UnityEngine;
using System.Collections;

public class BabyBatController : MonoBehaviour {

    private Transform _target;
    private Transform _cave;
    public float moveSpeed;
    private int rotationSpeed = 50;
    private BatFlapController batFlapController;
    public GameObject BabyBat;
    private string _follow;
    public float followParentDistance;

    void Start()
    {
        _target = GameObject.FindWithTag("player").transform;
        _cave = GameObject.FindWithTag("cave").transform;
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
            //rotate to look at the player
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(_target.position - transform.position), rotationSpeed * Time.deltaTime);

            //move towards the player
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
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
}
