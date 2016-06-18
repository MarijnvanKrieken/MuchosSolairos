using UnityEngine;
using System.Collections;

public class fixedPlace : MonoBehaviour {

    [SerializeField]
    int[] allowedObjectTypes;

    [SerializeField]
    GameObject winningObject;

    [SerializeField]
    Vector3 placeForAllowedObjects;

    [SerializeField]
    Vector3 placeForDeniedObjects;

	
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

    public void CheckWinningObject(out bool inPlace)
    {
        //inPlace = true;
        
        if ( Vector3.Distance( winningObject.transform.position, placeForAllowedObjects) < 0.11f)
            inPlace = true;
        else
            inPlace = false;
    }
}
