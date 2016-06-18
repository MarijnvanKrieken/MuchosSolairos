using UnityEngine;
using UnityEngine.UI;

public class Telekinesis: MonoBehaviour
{

	[SerializeField]
	Image cursor;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		RaycastHit hitInfo1;

		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitInfo1, 20.0f))
		{

			if(hitInfo1.collider.GetComponent<Rigidbody>() != null)
				cursor.color = Color.black;
			else
				cursor.color = Color.white;
		}
		else
			cursor.color = Color.white;

		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;

			if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hitInfo, 20.0f))
			{
				if(hitInfo.collider.GetComponent<Rigidbody>())
					hitInfo.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * 3000);
			}


		}

	}



}
