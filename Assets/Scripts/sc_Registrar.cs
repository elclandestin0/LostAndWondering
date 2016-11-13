using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sc_Registrar : MonoBehaviour {

	/**

	bool going = false;
	sc_Registrar r;
	void Awake(){
		r = GameObject.Find ("_Registrar").GetComponent<sc_Registrar>();
	}
		
	public void go(){
		//going = true;

	}

	void Start(){
		//going = true;
		
	}

	void FixedUpdate () {
		if(going){
		
		}
	}

	**/

	[System.NonSerialized] public bool reset = false;
	[System.NonSerialized] public float resetTime;

	public GameObject _Dynamic;

	[System.Serializable]
	public class Prefabs{
		//public Gameobject name;
		public GameObject mark;
		public GameObject hawk;
		public GameObject splat;
		public GameObject buildingSeed;
		public GameObject buildingFloor;
	}
	public Prefabs p = new Prefabs();

	[System.Serializable]
	public class Scripts{
		//public Gameobject name;
		public sc_Sequencer sequencer;
		public sc_s1 s1;
	}
	public Scripts sc = new Scripts(); 

	[System.Serializable]
	public class Actors{
		//public Gameobject name;
		public GameObject all;
		public GameObject bat;
		public GameObject mouseTracker;
		public GameObject farCamera;
		public GameObject closeCamera;
		public GameObject enemies;
		public GameObject boundaryBox;
	}
	public Actors a = new Actors();

	[System.Serializable]
	public class MarkMaterials{
		//public Gameobject name;
		public Material world;
		public Material concrete;
		public Material glass;
	}
	public MarkMaterials markMat = new MarkMaterials();

	[System.Serializable]
	public class UIElements{
		//public Gameobject name;
		public Text statusText;
	}
	public UIElements ui = new UIElements();


	public void resetInSec(float sec){
		if (!reset) { 
			reset = true;
			resetTime = Time.time + sec;
		}
	}

	void FixedUpdate(){
		if (reset) {
			if (Time.time >= resetTime) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}
