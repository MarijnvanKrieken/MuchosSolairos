using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.UI;

public class VRManager : MonoBehaviour
{
	public GvrViewer gvrViewer;
	public GvrHead gvrHead;
	public GameObject leftEye;
	public GameObject rightEye;
	public GameObject leftUIEye;
	public GameObject rightUIEye;
	public Button cardboardButton;
	public Camera mainCam;
	public Camera mainUICam;

	private bool stereoscopic = false;
	private static VRManager instance;

	public static Camera MainCam
	{
		get { return instance.mainCam; }
	}

	void Awake()
	{
		instance = this;
	}

	void Start ()
	{
		if (VRSettings.enabled)
		{
			gvrViewer.enabled = false;
			gvrHead.enabled = false;
			cardboardButton.enabled = false;
		}
		else
		{
			gvrViewer.enabled = true;
			gvrHead.enabled = true;
			cardboardButton.enabled = true;
		}
	}

	public void CardboardSwitch()
	{
		stereoscopic = !stereoscopic;
		mainCam.enabled = stereoscopic;
		mainUICam.enabled = stereoscopic;
		leftEye.SetActive(!stereoscopic);
		rightEye.SetActive(!stereoscopic);
		leftUIEye.SetActive(!stereoscopic);
		rightUIEye.SetActive(!stereoscopic);
	}
}
