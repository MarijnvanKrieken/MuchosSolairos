using UnityEngine;
using System.Collections;

public class fixedPlace : MonoBehaviour {

    [SerializeField]
    int[] allowedObjectTypes;

    [SerializeField]
    Vector3 placeForAllowedObjects;

    [SerializeField]
    Vector3 placeForDeniedObjects;

	// Use this for initialization
	void Start () {
	
	}

    public void ReturnGoToPlace(int objectType, out Vector3 placeToGoTo, out bool stuck)
    {
        for (int i = 0; i < allowedObjectTypes.Length; i++)
        {
            if (objectType == allowedObjectTypes[i])
            {
                placeToGoTo = placeForAllowedObjects;
                stuck = true;
                return;
            }
        }

        stuck = false;
        placeToGoTo = placeForDeniedObjects;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
