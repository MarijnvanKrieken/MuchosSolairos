using UnityEngine;

public class RuneSound: MonoBehaviour
{
	private RaycastHit hit;
	private CustomDebug debug;

	void Start()
	{
		debug = Object.FindObjectOfType<CustomDebug>();
		debug.Clear();
	}


}
