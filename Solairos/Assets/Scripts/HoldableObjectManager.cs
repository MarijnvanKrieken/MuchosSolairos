using UnityEngine;
using System.Collections;

public class HoldableObjectManager : MonoBehaviour {

    public delegate void OnArrived(Vector3 nextPosition, Vector3 nextLookAt, bool isPositionRelavtive, int id = 0);
    public static event OnArrived Arrived;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
