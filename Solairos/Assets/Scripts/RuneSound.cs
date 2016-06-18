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

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;

			if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20.0f))
			{
				if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Runes"))
				{
					AudioSource runeSound = hit.transform.GetComponent<AudioSource>();
					runeSound.Play();
					debug.AddDebug("sound played");
				}
			}
		}
	}
}
