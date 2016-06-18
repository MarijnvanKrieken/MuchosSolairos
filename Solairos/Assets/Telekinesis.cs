using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Telekinesis : MonoBehaviour {

    [SerializeField]
    Image cursor;

    GameObject holdingObject = null;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hitInfo1;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitInfo1, 200.0f))
        {

            if (hitInfo1.collider.GetComponent<Rigidbody>() != null)
                cursor.color = Color.black;
            else
                cursor.color = Color.white;
        }
        else
            cursor.color = Color.white;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitInfo, 200.0f))
            {
                if (hitInfo.collider.GetComponent<HoldableObject>() && holdingObject == null)
                {
                    holdingObject = hitInfo.collider.GetComponent<HoldableObject>().gameObject;
                    holdingObject.transform.parent = transform.GetChild(0).transform;

                    holdingObject.GetComponent<HoldableObject>().SendToHold();
                    
                }
                else if (holdingObject && hitInfo.collider.gameObject != holdingObject)
                {
                    holdingObject.transform.parent = null;
                    holdingObject.GetComponent<HoldableObject>().SendBack(hitInfo.point);
                    holdingObject = null;
                }
            }


        }
	
	}


    
}
