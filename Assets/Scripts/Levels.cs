using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {

	public void StartScene(string name)
    {
        Application.LoadLevel(name);
        
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
