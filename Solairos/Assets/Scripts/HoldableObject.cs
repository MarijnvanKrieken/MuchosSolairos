using UnityEngine;
using DG.Tweening;
using System.Collections;

public class HoldableObject : MonoBehaviour {

    public int objectType = 0;

    [SerializeField]
    AnimationCurve grabCurve;

    HoldableObjectManager Mgr;

    Tween toHold;
    Tween toNew;
    Tween rotate;

	// Use this for initialization
	void Start () {
        if (!GetComponent<Rigidbody>())
            Debug.LogWarning("Holdable Object has no rigidbody");

        if (!GetComponentInParent<HoldableObjectManager>())
            Debug.LogWarning("Holdable Object is not in HoldableObjectManager");
        else
            Mgr = GetComponentInParent<HoldableObjectManager>();
    }

    public void SendToHold()
    {
        toNew.Kill();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        


        toHold = transform.DOLocalMove(Vector3.zero, 2.0f);
        toHold.SetEase(grabCurve);

        rotate.Kill();
        rotate = transform.DOLocalRotate(Vector3.zero, 1.0f);
    }


    public void SendBack(Vector3 endPos, bool stay = false)
    {
        Vector3[] pathNodes = new Vector3[2];

        //pathNodes[1] = endPos * ((endPos.magnitude - Mathf.Abs(GetComponent<Renderer>().bounds.min.z) / 1.7f) / endPos.magnitude);
        pathNodes[1] = endPos * ((endPos.magnitude - 0.09f) / endPos.magnitude); 
        pathNodes[0] = pathNodes[1] * 0.8f;

        toHold.Kill();
        
        toNew = transform.DOPath(pathNodes, 2.0f);
        toNew.SetEase(Ease.InOutQuint);


        if (!stay)
            toNew.OnComplete(() => GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None);
        else
        {
            toNew.OnComplete(() =>
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                Mgr.DoArrived();
            });

        }

        rotate.Kill();
        rotate = transform.DOLocalRotate(Vector3.up * transform.rotation.eulerAngles.y, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
