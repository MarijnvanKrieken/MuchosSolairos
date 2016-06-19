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
    public GameObject Banana;

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
        Banana.SetActive(false);
		customDebug = FindObjectOfType<CustomDebug>();
		//customDebug.AddDebug("start disks rotations: " + innerDisk.transform.localRotation.eulerAngles.y.ToString() + "," + midDisk.transform.localRotation.eulerAngles.y.ToString() + "," + outerDisk.transform.localRotation.eulerAngles.y.ToString());
		while(innerDisk.transform.localRotation.eulerAngles.y == 0f)
			innerDisk.transform.localRotation = Quaternion.Euler(0f, Random.Range(0, 7) * 45f, 0f);
		while(midDisk.transform.localRotation.eulerAngles.y == 0f)
			midDisk.transform.localRotation = Quaternion.Euler(0f, Random.Range(0, 7) * 45f, 0f);
		while(outerDisk.transform.localRotation.eulerAngles.y == 0f)
			outerDisk.transform.localRotation = Quaternion.Euler(0f, Random.Range(0, 7) * 45f, 0f);
		//customDebug.AddDebug("initialized disks rotations: " + innerDisk.transform.localRotation.eulerAngles.y.ToString() + "," + midDisk.transform.localRotation.eulerAngles.y.ToString() + "," + outerDisk.transform.localRotation.eulerAngles.y.ToString());
		//customDebug.AddDebug("Start");
	}

	IEnumerator canRotateTrue()
	{
		yield return new WaitForSeconds(rotateTime);
		canRotate = true;
		innerDisk.transform.localRotation = Quaternion.Euler(innerDisk.transform.localRotation.eulerAngles.x, Mathf.Round(innerDisk.transform.localRotation.eulerAngles.y), innerDisk.transform.localRotation.eulerAngles.z);
		midDisk.transform.localRotation = Quaternion.Euler(midDisk.transform.localRotation.eulerAngles.x, Mathf.Round(midDisk.transform.localRotation.eulerAngles.y), midDisk.transform.localRotation.eulerAngles.z);
		outerDisk.transform.localRotation = Quaternion.Euler(outerDisk.transform.localRotation.eulerAngles.x, Mathf.Round(outerDisk.transform.localRotation.eulerAngles.y), outerDisk.transform.localRotation.eulerAngles.z);
		//customDebug.AddDebug("new disks rotations: " + innerDisk.transform.localRotation.eulerAngles.y.ToString() + "," + midDisk.transform.localRotation.eulerAngles.y.ToString() + "," + outerDisk.transform.localRotation.eulerAngles.y.ToString());
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
					bool startCanRotate = false;
					//customDebug.AddDebug("rotate");
					if(hit.transform.gameObject.name == gear1.name)
					{
						gear1.transform.DORotate(new Vector3(321f, 0f, 0f), rotateTime * 0.8f, RotateMode.LocalAxisAdd);

						gear1Tween = innerDisk.transform.DORotate(new Vector3(0f, gear1Move.x * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear2Tween = midDisk.transform.DORotate(new Vector3(0f, gear1Move.y * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear3Tween = outerDisk.transform.DORotate(new Vector3(0f, gear1Move.z * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						startCanRotate = true;
					}
					else if(hit.transform.gameObject.name == gear2.name)
					{
						gear2.transform.DORotate(new Vector3(297f, 0f, 0f), rotateTime * 0.8f, RotateMode.LocalAxisAdd);

						gear1Tween = innerDisk.transform.DORotate(new Vector3(0f, gear2Move.x * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear2Tween = midDisk.transform.DORotate(new Vector3(0f, gear2Move.y * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear3Tween = outerDisk.transform.DORotate(new Vector3(0f, gear2Move.z * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						startCanRotate = true;
					}
					else if(hit.transform.gameObject.name == gear3.name)
					{
						gear3.transform.DORotate(new Vector3(382f, 0f, 0f), rotateTime * 0.8f, RotateMode.LocalAxisAdd);

						gear1Tween = innerDisk.transform.DORotate(new Vector3(0f, gear3Move.x * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear2Tween = midDisk.transform.DORotate(new Vector3(0f, gear3Move.y * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						gear3Tween = outerDisk.transform.DORotate(new Vector3(0f, gear3Move.z * 45f, 0f), rotateTime, RotateMode.LocalAxisAdd);
						startCanRotate = true;
					}
					if(startCanRotate)
					{
						StartCoroutine("canRotateTrue");
						stonesound.Play();
						canRotate = false;
					}
				}
			}
		}

		if(innerDisk.transform.localRotation.eulerAngles.y == 0f && midDisk.transform.localRotation.eulerAngles.y == 0f && outerDisk.transform.localRotation.eulerAngles.y == 0f && completed == false)
		{
            Banana.SetActive(true);
            //customDebug.AddDebug("Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! Gears complete! ");
			completed = true;
		}
	}
}
