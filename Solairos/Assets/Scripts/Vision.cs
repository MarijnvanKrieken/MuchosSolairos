using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Vision: MonoBehaviour
{
	private List<GameObject> visionObjects = new List<GameObject>();
	private List<MeshRenderer> visionRenderers = new List<MeshRenderer>();
	private float alphas = -0.5f;
	private CustomDebug debug;
	// Use this for initialization
	void Start()
	{
		debug = Object.FindObjectOfType<CustomDebug>();
		visionObjects = GameObject.FindGameObjectsWithTag("Vision").ToList();
		foreach(GameObject vobj in visionObjects)
		{
			visionRenderers.Add(vobj.GetComponent<MeshRenderer>());
		}
		//debug.AddDebug("vision renderers: " + visionRenderers.Count.ToString());
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			alphas += 1f * Time.deltaTime;
			//debug.AddDebug("Increasing alpha");
		}
		alphas -= 0.5f * Time.deltaTime;
		alphas = Mathf.Min(alphas, 1f);
		alphas = Mathf.Max(alphas, -0.5f);
		foreach(MeshRenderer rend in visionRenderers)
		{
			rend.material.SetFloat("_Alpha", alphas);
		}
	}
}
