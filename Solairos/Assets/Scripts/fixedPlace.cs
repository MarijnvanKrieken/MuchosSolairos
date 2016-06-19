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

       // Debug.Log("length of objectTypes is " + allowedObjectTypes.Length);
        for (int i = 0; i < allowedObjectTypes.Length; i++)
        {
          //  Debug.Log(objectType + " > " + allowedObjectTypes[i]);
            if (objectType == allowedObjectTypes[i])
            {
              //  Debug.Log("found same objectTypeS");
                placeToGoTo = placeForAllowedObjects;
                stuck = true;
                return;
            }
        }

        stuck = true;
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
