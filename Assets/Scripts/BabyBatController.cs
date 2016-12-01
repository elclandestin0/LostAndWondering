using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public Text babystatusHUD;
    private AudioSource _suspenceSound;
    private float _winCounter;

    void Start()
    {
        _target = GameObject.FindWithTag("player").transform;
        _cave = GameObject.FindWithTag("cave").transform;
        _spawnPosition = transform.position;
        _spawnRotation = transform.rotation;
        batFlapController = BabyBat.GetComponent<BatFlapController>();
        _follow = "";
        _suspenceSound = gameObject.GetComponent<AudioSource>();
        babystatusHUD.text = "Baby Status: Lost";
        _winCounter = 0.0f;
    }


    void Update()
    {
        Move();
        BatHome();
    }

    void FollowParent()
    {
        if (_follow.Equals("bat"))
        {
            if(Vector3.Distance(transform.position, _target.transform.position) > 4f)
            {
                if (GameObject.Find("Terrain").GetComponents<AudioSource>()[1].isPlaying)
                {
                    GameObject.Find("Terrain").GetComponents<AudioSource>()[1].Pause();
                    _suspenceSound.Play();
                }

                //rotate to look at the player
                transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(_target.position - transform.position), rotationSpeed * Time.deltaTime);
                
                //move towards the player
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
                babystatusHUD.text = "Baby Status: Following";
            }
            else
            {
                if (_suspenceSound.isPlaying)
                {
                    GameObject.Find("Terrain").GetComponents<AudioSource>()[1].Play();
                    _suspenceSound.Stop();
                }
            }

            batFlapController.FlapWings();
        }
        //Only set it the first time
        else if (Vector3.Distance(transform.position, _target.position) <= followParentDistance)
        {

            transform.Find("Bat_morph/Bat_Anim0").gameObject.SetActive(false);
            _follow = "bat";
            babystatusHUD.text = "Baby Status: Lost";
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
            babystatusHUD.text = "Baby Status: Cave"; 
        }
        //Only set it the first time
        else if(Vector3.Distance(transform.position, _cave.position) <= followParentDistance && !_follow.Equals("home"))
        {
            _follow = "cave";
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "cave")
        {
            babystatusHUD.text = "Baby Status: Home";
            _follow = "home";
        }
    }

    void Move()
    {
        EnterCave();
        if (!_follow.Equals("cave") && !_follow.Equals("home"))
        {
            FollowParent();
        }
    }

    public void Respawn()
    {
        transform.position = _spawnPosition;
        transform.rotation = _spawnRotation;
    }

    void BatHome()
    {
        if (_follow.Equals("home"))
        {
            _winCounter += Time.deltaTime;
            if(_winCounter > 2.0f)
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
