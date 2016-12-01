using UnityEngine;
using System.Collections;

public class callBackCameraCinematic : MonoBehaviour {

    private Cinematics cinematicScriptCallBack; 

    public void callBack()
    {
        cinematicScriptCallBack = GameObject.Find("Camera").GetComponent<Cinematics>();
        cinematicScriptCallBack.switchCamera(); 
    }
}
