using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiskManager: MonoBehaviour
{
	public GameObject innerDisk;
	public GameObject midDisk;
	public GameObject outerDisk;
	public GameObject gear1;
	public GameObject gear2;
	public GameObject gear3;
	public Vector3 gear1Move;
	public Vector3 gear2Move;
	public Vector3 gear3Move;
	public Image cursor;
	public AudioSource stonesound;

	private Tween gear1Tween;
	private Tween gear2Tween;
	private Tween gear3Tween;
	private CustomDebug customDebug;
	private bool completed = false;
	private bool canRotate = true;
	private float rotateTime = 1f;

	// Use this for initialization
	void Start()
	{
		innerDisk.transform.Rotate(0f, Random.Range(1, 7) * 45f, 0f);
		midDisk.transform.Rotate(0f, Random.Range(1, 7) * 45f, 0f);
		outerDisk.transform.Rotate(0f, Random.Range(1, 7) * 45f, 0f);
		customDebug = FindObjectOfType<CustomDebug>();
		//customDebug.AddDebug("Start");
	}

	IEnumerator canRotateTrue()
	{
		yield return new WaitForSeconds(rotateTime);
		canRotate = true;
		//customDebug.AddDebug("canRotate set to true");
		yield return null;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20.0f))
			{
				//customDebug.AddDebug("ray cast");
				if(canRotate)
				{
					canRotate = false;
					stonesound.Play();
					//customDebug.AddDebug("rotate");
					if(hit.transform.gameObject.name == gear1.name)
					{
						gear1Tween = innerDisk.transform.DORotate(new Vector3(0f, gear1Move.x * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear2Tween = midDisk.transform.DORotate(new Vector3(0f, gear1Move.y * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear3Tween = outerDisk.transform.DORotate(new Vector3(0f, gear1Move.z * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
					}
					else if(hit.transform.gameObject.name == gear2.name)
					{
						gear1Tween = innerDisk.transform.DORotate(new Vector3(0f, gear2Move.x * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear2Tween = midDisk.transform.DORotate(new Vector3(0f, gear2Move.y * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear3Tween = outerDisk.transform.DORotate(new Vector3(0f, gear2Move.z * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
					}
					else if(hit.transform.gameObject.name == gear3.name)
					{
						gear1Tween = innerDisk.transform.DORotate(new Vector3(0f, gear3Move.x * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear2Tween = midDisk.transform.DORotate(new Vector3(0f, gear3Move.y * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear3Tween = outerDisk.transform.DORotate(new Vector3(0f, gear3Move.z * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
					}
					StartCoroutine("canRotateTrue");
				}
			}
		}

		if(innerDisk.transform.rotation.eulerAngles.y == 0f && midDisk.transform.rotation.eulerAngles.y == 0f && outerDisk.transform.rotation.eulerAngles.y == 0f && completed == false)
		{
			customDebug.AddDebug("Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! ");
			completed = true;
		}
	}
}
