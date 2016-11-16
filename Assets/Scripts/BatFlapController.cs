using UnityEngine;
using System.Collections;

public class BatFlapController : MonoBehaviour {
    private float _batFlapTimer;
    private const float FLAPTIMER = 0.1f;
    private int _flapAnimation;
    // Use this for initialization
    void Start () {
        _batFlapTimer = 0.4f;
        _flapAnimation = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void FlapWings()
    {
        if (_batFlapTimer >= FLAPTIMER)
        {
            _batFlapTimer = 0.0f;
            transform.Find("Bat_Anim" + _flapAnimation).gameObject.SetActive(false);
            _flapAnimation = (_flapAnimation + 1) % 7;
            transform.Find("Bat_Anim" + _flapAnimation).gameObject.SetActive(true);

        }
        else
        {
            _batFlapTimer += Time.deltaTime;
        }
    }
}
