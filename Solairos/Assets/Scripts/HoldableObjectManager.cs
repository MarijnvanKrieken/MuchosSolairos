using UnityEngine;
using System.Collections;

public class HoldableObjectManager : MonoBehaviour {

    public delegate void OnArrived();
    public static event OnArrived Arrived;

    public void DoArrived()
    {
        Arrived();
    }
}
