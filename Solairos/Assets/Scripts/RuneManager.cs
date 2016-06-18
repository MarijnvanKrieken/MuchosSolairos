using System.Collections.Generic;
using UnityEngine;

public class RuneManager: MonoBehaviour
{
	public List<GameObject> melody;
	public List<GameObject> allNotes;

	private List<GameObject> clickedNotes;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RuneG()
	{
		clickedNotes.Add(allNotes[0]);
	}

	public void RuneBb()
	{
		clickedNotes.Add(allNotes[0]);
	}

	public void RuneC()
	{
		clickedNotes.Add(allNotes[0]);
	}

	public void RuneE()
	{
		clickedNotes.Add(allNotes[0]);
	}

	public void RuneF()
	{
		clickedNotes.Add(allNotes[0]);
	}
}
