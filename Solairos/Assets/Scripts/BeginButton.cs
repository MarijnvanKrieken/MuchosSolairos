using DG.Tweening;
using UnityEngine;

public class BeginButton: MonoBehaviour
{
	public Transform elevator;

	[SerializeField]
	fixedPlace KeyHole;
	private CustomDebug customDebug;

	// Use this for initialization
	void Start()
	{
		customDebug = FindObjectOfType<CustomDebug>();
	}

	public void ActivateButton()
	{
		bool win = false;

		KeyHole.CheckWinningObject(out win);
		//customDebug.AddDebug("ActivateButton, win: " + win.ToString());
		if(win)
		{
			elevator.DOMoveY(0f, 20.0f);
			//customDebug.AddDebug("Should move");
		}

	}


}
