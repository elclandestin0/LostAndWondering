using UnityEngine;
using System.Collections;

public class sc_light : MonoBehaviour {
    private Light spotLight;
    public float startingAngle;
    public float lightAngleModifier;
    public float lightIntensityModifier;
    private float initialIntensity;
    public float lightAngleLimit;
	// Use this for initialization
	void Start () {
        spotLight = GetComponent<Light>();
        initialIntensity = spotLight.intensity;

    }
	
	// Update is called once per frame
	void Update () {
	    if (spotLight.spotAngle >= lightAngleLimit)
        {
            spotLight.spotAngle = startingAngle;
            spotLight.intensity = initialIntensity;


        }
        else
        {
            spotLight.spotAngle += Time.deltaTime * lightAngleModifier;
            spotLight.intensity -= Time.deltaTime * lightIntensityModifier;
        }
	}
}
