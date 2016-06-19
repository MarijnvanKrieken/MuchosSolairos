using UnityEngine;
using UnityEngine.UI;

public class Telekinesis: MonoBehaviour
{

	[SerializeField]
	Image cursor;

	GameObject holdingObject = null;



	// Use this for initialization
	void Start()
	{

	}

	void CursorColor()
	{
		//cursor
		RaycastHit hitInfo1;

		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitInfo1, 200.0f))
		{
			//when not holding object
			if(holdingObject == null)
			{
				if(hitInfo1.transform.tag == "Gear")
				{
					cursor.color = Color.black;
					return;
				}

				if(hitInfo1.transform.tag == "Rune")
				{
					cursor.color = Color.black;
					return;
				}
				if(hitInfo1.collider.GetComponent<HoldableObject>() != null)
				{
					cursor.color = Color.black;

					return;
				}

			}
			else //when holding object
			{
				if(hitInfo1.collider.gameObject != holdingObject)
				{
					cursor.color = Color.blue;
					return;
				}

			}

		}

		//else
		cursor.color = Color.white;
	}

	// Update is called once per frame
	void Update()
	{


		CursorColor();


		//on tap
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;


            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitInfo, 200.0f))
			{
				if(hitInfo.collider.GetComponent<HoldableObject>() && holdingObject == null)
				{
					holdingObject = hitInfo.collider.GetComponent<HoldableObject>().gameObject;
					holdingObject.transform.parent = Camera.main.transform.GetChild(0).transform;

					holdingObject.GetComponent<HoldableObject>().SendToHold();

				}
                else if(holdingObject != null)
				{

                    if (hitInfo.collider.gameObject == holdingObject)
						return;


                    holdingObject.transform.parent = null;

					Vector3 sendToPlace = Vector3.zero;
					bool stayAfter = false;

                    if (hitInfo.collider.GetComponent<fixedPlace>())
                    {
                        hitInfo.collider.GetComponent<fixedPlace>().ReturnGoToPlace(holdingObject.GetComponent<HoldableObject>().objectType, out sendToPlace, out stayAfter);
                    }
                    else
                    {
                        sendToPlace = hitInfo.point;

                        Debug.Log(hitInfo.collider.name);
                        Debug.Log("does it get here?");
                    }


					holdingObject.GetComponent<HoldableObject>().SendBack(sendToPlace, stayAfter);
					holdingObject = null;
				}

			}


		}

	}



}
