using System;
using UnityEngine;
using UnityEngine.Events;

public class PlacingPuzzleManager: MonoBehaviour
{

	[Serializable]
	public class MyEventType: UnityEvent { }
	public MyEventType OnPuzzleFinished;

	[SerializeField]
	fixedPlace[] puzzlePlaces;

	public GameObject lightBeam1;
	public GameObject lightBeam2;

	void OnEnable()
	{
		HoldableObjectManager.Arrived += HoldableObjectManager_Arrived;
	}

	void Start()
	{
		lightBeam1.SetActive(false);
		lightBeam2.SetActive(false);
	}

	//PLEASE REMOVE, is changed
	public void WinConditionWeird(Transform t)
	{
		//t.position += Vector3.up * 0.5f;
		lightBeam1.SetActive(true);
		lightBeam2.SetActive(true);
	}

	private void HoldableObjectManager_Arrived()
	{
		//OnPuzzleFinished.Invoke();

		bool isInPlace = false;

		for(int i = 0; i < puzzlePlaces.Length; i++)
		{
			puzzlePlaces[i].CheckWinningObject(out isInPlace);

			if(isInPlace == false)
				return;


		}


		OnPuzzleFinished.Invoke();

	}


	void OnDisable()
	{
		HoldableObjectManager.Arrived -= HoldableObjectManager_Arrived;
	}
}
