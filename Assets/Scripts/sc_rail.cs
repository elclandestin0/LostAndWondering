using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class sc_rail : MonoBehaviour {

	public ArrayList l;
  float forwardDrawDistance = 3f;
  float upRightDrawDistance = 3f;
  int childCount = 0;

  public class Waipoint{
    public Vector3 pos;
    public Quaternion rot;
    public float interval;

  }

  public void scanWps() {
    l = new ArrayList();
    for(int i=0; i < transform.childCount; i++) {
      Transform t = transform.GetChild(i);
      if(t.tag == "waipoint"){
        l.Add(t);
      }
    }
  }

  void Awake() {
    scanWps();
  }

  void Update() {
    if(Time.time == 0f)//autoscan in edit mode
      scanWps();

    if(l != null) {
      for(int i=0; i < l.Count; i++) {
        Transform current = (Transform)l[i];
        //show direction
        Quaternion dir = current.rotation;
        Debug.DrawLine(current.position,
          current.position + dir*Vector3.forward * forwardDrawDistance,
          Color.blue);
        Debug.DrawLine(current.position,
          current.position + dir*Vector3.right * upRightDrawDistance,
          Color.red);
        Debug.DrawLine(current.position,
          current.position + dir*Vector3.up * upRightDrawDistance,
          Color.green);

        //connect waipoints
        if (i >= 1) {
          Transform prev = (Transform)l[i-1];
          Debug.DrawLine(prev.position, current.position, Color.yellow);
        }
      }
    }
  }

  public ArrayList getTransforms() {
    return l;
  }

  public ArrayList getPositions() {
    ArrayList path = new ArrayList();
    for(int i=0; i < l.Count; i++) {
      Transform current = (Transform)l[i];
      path.Add(current.position);
    }
    return path;
  }
}