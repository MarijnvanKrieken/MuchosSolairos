using UnityEngine;
using DG.Tweening;
using System.Collections;

public class HoldableObject : MonoBehaviour {

    public int objectType = 0;

    Tween toHold;
    Tween toNew;
    Tween rotate;

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
        toHold.SetEase(Ease.OutElastic);

        rotate.Kill();
        rotate = transform.DOLocalRotate(Vector3.zero, 1.0f);
    }

    public void SendBack(Vector3 endPos, bool stay = false)
    {
        Vector3[] pathNodes = new Vector3[2];

        pathNodes[1] = endPos * ((endPos.magnitude - Mathf.Abs(GetComponent<Renderer>().bounds.min.z) / 1.7f) / endPos.magnitude);
        pathNodes[0] = pathNodes[1] * 0.8f;

        toHold.Kill();
        
        toNew = transform.DOPath(pathNodes, 2.0f);
        toNew.SetEase(Ease.InOutQuint);
        

        if (!stay)        
            toNew.OnComplete(() =>GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None);
        else
            toNew.OnComplete(() => GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll);

        rotate.Kill();
        rotate = transform.DOLocalRotate(Vector3.up * transform.rotation.eulerAngles.y, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
