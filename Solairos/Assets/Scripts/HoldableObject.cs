using UnityEngine;
using DG.Tweening;
using System.Collections;

public class HoldableObject : MonoBehaviour {

    Tween toHold;
    Tween toNew;

	// Use this for initialization
	void Start () {
        if (!GetComponent<Rigidbody>())
            Debug.LogWarning("Holdable Object has no rigidbody");
	}

    public void SendToHold()
    {
        toNew.Kill();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        toHold = transform.DOLocalMove(Vector3.zero, 2.0f);

        transform.DOLocalRotate(Vector3.zero, 1.5f);
    }

    public void SendBack(Vector3 endPos)
    {
        Vector3[] pathNodes = new Vector3[2];

        pathNodes[0] = endPos * (endPos.magnitude - GetComponent<Renderer>().bounds.min.z / endPos.magnitude);
        pathNodes[1] = pathNodes[0] * 0.5f;

        toHold.Kill();
        //toNew = transform.DOMove(endPos, 2.0f);
        toNew = transform.DOPath(pathNodes, 2.0f);
        toNew.OnKill(() => GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None);
        toNew.OnComplete(() =>GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
