using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;

public class PlacingPuzzleManager : MonoBehaviour {

    [Serializable]
    public class MyEventType : UnityEvent { }
    public MyEventType OnPuzzleFinished;

    [SerializeField]
    fixedPlace[] puzzlePlaces;


    void OnEnable()
    {
        HoldableObjectManager.Arrived += HoldableObjectManager_Arrived;
    }


    //PLEASE REMOVE
    public void WinConditionWeird(Transform t)
    {
        t.position += Vector3.up * 0.5f;
    }

    private void HoldableObjectManager_Arrived()
    {
        //OnPuzzleFinished.Invoke();

        bool isInPlace = false;

        for (int i = 0; i < puzzlePlaces.Length; i++)
        {
            puzzlePlaces[i].CheckWinningObject(out isInPlace);

            if (isInPlace == false)
                return;


        }


        OnPuzzleFinished.Invoke();

    }


    void OnDisable()
    {
        HoldableObjectManager.Arrived -= HoldableObjectManager_Arrived;
    }
}
