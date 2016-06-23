using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager: MonoBehaviour
{
	public List<GameObject> melody;
	public List<GameObject> allNotes;
	[HideInInspector]
	public List<GameObject> clickedNotes;
	public GameObject stoneDrag;
	public GameObject stoneHit;
	public Finish finish;

	public Rigidbody ear1;
	public Rigidbody ear2;

	[SerializeField]
	AudioSource MonkeySound;

	//[SerializeField]

	//private RaycastHit hit;
	private CustomDebug debug;
	private float rotationSpeed = 0f;
	//private int rightUntil = 0;

	// Use this for initialization
	void Start()
	{
		debug = Object.FindObjectOfType<CustomDebug>();
		debug.Clear();
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if(Physics.Raycast(VRManager.MainCam.transform.position, VRManager.MainCam.transform.forward, out hit, 20.0f))
			{
				if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Runes") && rotationSpeed == 0f)
				{
					AudioSource runeSound = hit.transform.GetComponent<AudioSource>();
					Invoke(hit.transform.name, 0f); //function is named to the game object name
					runeSound.Play();
				}
				if(hit.transform.tag == "Bell")
				{
					AudioSource bellSound = hit.transform.GetComponent<AudioSource>();
					bellSound.Play();
					DOVirtual.DelayedCall(1.0f, () =>
					{
						MonkeySound.Play();
						ear1.constraints = RigidbodyConstraints.None;
						ear2.constraints = RigidbodyConstraints.None;
					});
					DOVirtual.DelayedCall(2.0f, () =>
					{
						finish.EarsDone();
					});
					//debug.AddDebug("Bell sound played");
				}
			}
		}
	}

	void CheckNotes()
	{
		//debug.AddDebug("Check notes, clicked count: " + clickedNotes.Count.ToString());
		if(clickedNotes[clickedNotes.Count - 1] != melody[clickedNotes.Count - 1])
		{
			StartCoroutine("PlayStartNote");
		}
		else if(clickedNotes.Count == 5)
		{
			StartCoroutine("PlayLastFive");
			rotationSpeed = 100f;
			transform.parent.DOMoveY(-3.5f, 10f);
		}

		/*int i;
		for(i = 0; i < clickedNotes.Count; i++)
		{
			if(clickedNotes[i] != melody[i]) //if notes clicked are wrong
			{
				//debug.AddDebug("clicked melody is wrong, reseting...");
				//clear clicked notes and play reset and start sound
				StartCoroutine("PlayStartNote");
			}
			else if(clickedNotes.Count == 5 && clickedNotes[4] == melody[4]) //notes are clicked right and 5 notes met
			{
				StartCoroutine("PlayLastFive");
				rotationSpeed = 100f;
				//debug.AddDebug("Puzzle complete!");
			}
			else if(clickedNotes[4] != melody[4])
			{
				StartCoroutine("PlayStartNote");
			}
		}*/
	}

	/*
		if(clickedNotes[i] == melody[i]) //if last note is good
		{
			if(i == 5) //if at last required note
			{
				rotationSpeed = 100f;
				StartCoroutine("PlayRemainder");
				debug.AddDebug("Puzzle complete!");
			}
			else
			{
				rightUntil = i;
				debug.AddDebug("melody right up until this point, play melody including next note");
				StartCoroutine("PlayUntil", i + 2);
			}
		}*/
	/*else if(rightUntil == 5)
	{
		rotationSpeed = 100f;
		StartCoroutine("PlayRemainder");
	}
	else if(i == clickedNotes.Count - 1 && i >= rightUntil && rotationSpeed == 0f) //notes clicked right and last note
	{
		rightUntil = i;
		debug.AddDebug("melody right up until this point, play melody including next note");
		StartCoroutine("PlayUntil", i + 2);
	}
	//debug.AddDebug("right until " + rightUntil.ToString());
	/*
	if(clickedNotes[i] != melody[i])
	{
		StartCoroutine("PlayStartNote");
	}
	else if(i == 4)
	{
		rotationSpeed = 100f;
		StartCoroutine("PlayRemainder");
	}
	else if(i == clickedNotes.Count - 1)
	{
		StartCoroutine("PlayNoteDelayed", melody[i + 1]);
	}*/

	/*IEnumerator PlayUntil(int until)
	{
		yield return new WaitForSeconds(1);
		for(int i = 0; i < until; i++)
		{
			yield return new WaitForSeconds(0.5f);
			melody[i].GetComponent<AudioSource>().Play();
		}
		clickedNotes.Clear();
		//debug.AddDebug("Right until: " + rightUntil.ToString());
		yield return null;
	}*/

	IEnumerator PlayStartNote()
	{
		clickedNotes.Clear();
		stoneDrag.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.5f);
		stoneHit.GetComponent<AudioSource>().Play();
		//melody[0].GetComponent<AudioSource>().Play();
		//rightUntil = 0;
		yield return null;
	}
	/*
	IEnumerator PlayNoteDelayed(GameObject noteObject)
	{
		yield return new WaitForSeconds(1f);
		noteObject.GetComponent<AudioSource>().Play();
		yield return null;
	}*/

	IEnumerator PlayFirstFive()
	{
		for(int i = 0; i < 5; i++)
		{
			melody[i].GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.5f);
		}
		StartCoroutine("PlayStartNote");
		yield return null;
	}

	IEnumerator PlayLastFive()
	{
		yield return new WaitForSeconds(0.5f);
		for(int i = 5; i < 10; i++)
		{
			yield return new WaitForSeconds(0.5f);
			melody[i].GetComponent<AudioSource>().Play();
		}
		yield return null;
	}

	/*IEnumerator PlayRemainder()
	{
		for(int i = 5; i < 10; i++)
		{
			yield return new WaitForSeconds(0.5f);
			melody[i].GetComponent<AudioSource>().Play();
		}
		yield return null;
	}*/

	//old runes
	public void RuneG()
	{
		clickedNotes.Add(allNotes[0]);
		CheckNotes();
	}

	public void RuneBb()
	{
		clickedNotes.Add(allNotes[1]);
		CheckNotes();
	}

	public void RuneC()
	{
		clickedNotes.Add(allNotes[2]);
		CheckNotes();
	}

	public void RuneE()
	{
		clickedNotes.Add(allNotes[3]);
		CheckNotes();
	}

	public void RuneF()
	{
		clickedNotes.Add(allNotes[4]);
		CheckNotes();
	}

	public void RuneMid()
	{
		StartCoroutine("PlayFirstFive");
	}

	//new runes
	public void SimonSaysPuzzle_SunDial_Shield()
	{
		clickedNotes.Add(allNotes[0]);
		CheckNotes();
	}

	public void SimonSaysPuzzle_VaseDial_Vase()
	{
		clickedNotes.Add(allNotes[1]);
		CheckNotes();
	}

	public void SimonSaysPuzzle_KeyDial_Shield()
	{
		clickedNotes.Add(allNotes[2]);
		CheckNotes();
	}

	public void SimonSaysPuzzle_LeafDial_Shield()
	{
		clickedNotes.Add(allNotes[3]);
		CheckNotes();
	}

	public void SimonSaysPuzzle_ArrowDial_Bow()
	{
		clickedNotes.Add(allNotes[4]);
		CheckNotes();
	}

	public void SimonSaysPuzzle_CenterDial_Bell()
	{
		StartCoroutine("PlayFirstFive");
	}
}
