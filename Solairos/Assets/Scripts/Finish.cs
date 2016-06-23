using UnityEngine;
using UnityEngine.UI;

public class Finish: MonoBehaviour
{
	[SerializeField]
	Image White;

	CustomDebug debug;

	//Color lerpColor = Color.clear;

	bool mouth = false;
	bool eyes = false;
	bool ears = false;

	bool done = false;

	// Use this for initialization
	void Start()
	{
		White.color = new Color(1f, 1f, 1f, 0f);
		debug = FindObjectOfType<CustomDebug>();
	}

	void CheckBools()
	{
		if(mouth == false || eyes == false || ears == false)
			return;

		done = true;
		//debug.AddDebug("all done");
	}

	public void MouthDone()
	{
		mouth = true;
		CheckBools();
		//debug.AddDebug("mouth done");
	}

	public void EyesDone()
	{
		eyes = true;
		CheckBools();
		//debug.AddDebug("eyes done");
	}

	public void EarsDone()
	{
		ears = true;
		CheckBools();
		//debug.AddDebug("ears done");
	}

	// Update is called once per frame
	void Update()
	{
		if(!done)
			return;

		White.color = White.color + new Color(0f, 0f, 0f, Time.deltaTime);
		//White.enabled = true;
		//White.color = Color.white;
		//lerpColor = Color.Lerp(Color.clear, Color.gray, Time.deltaTime);

		//White.color = lerpColor;
	}
}
