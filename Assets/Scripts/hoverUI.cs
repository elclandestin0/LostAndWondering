using UnityEngine;
using System.Collections;

public class hoverUI : MonoBehaviour {

    private AudioSource hover;

    void Start()
    {
        hover = gameObject.GetComponent<AudioSource>(); 
    }

    public void playHoverSound(){ 
        hover.Play(); 
    }
    public void stopHoverSound()
    {
        if (hover.isPlaying)
        {
            hover.Stop(); 
        }
    }
	

}
