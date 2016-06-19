using DG.Tweening;
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

	public Transform LeftHand;
	public Transform RightHand;

	public Transform eyeLightSource;

	private bool finished = false;

	void OnEnable()
	{
		HoldableObjectManager.Arrived += HoldableObjectManager_Arrived;
	}

	void Start()
	{
		lightBeam1.SetActive(false);
		lightBeam2.SetActive(false);
	}

	public void WinConditionWeird()
	{
		//t.position += Vector3.up * 0.5f;

		eyeLightSource.DOMoveZ(-0.1f, 1f);
		DOVirtual.DelayedCall(1f, () =>
		{
			lightBeam1.SetActive(true);
			lightBeam2.SetActive(true);
		});
		DOVirtual.DelayedCall(2f, () =>
		 {
			 LeftHand.DORotate(Vector3.zero, 2f);
			 LeftHand.DOMoveX(-0.5f, 2f);
			 RightHand.DORotate(new Vector3(0, -180, 0), 2f);
			 RightHand.DOMoveX(0.5f, 2f);
		 });
	}

	private void HoldableObjectManager_Arrived()
	{
		//OnPuzzleFinished.Invoke();
		if(finished)
			return;

		bool isInPlace = false;

		for(int i = 0; i < puzzlePlaces.Length; i++)
		{
			puzzlePlaces[i].CheckWinningObject(out isInPlace);

			if(isInPlace == false)
				return;


		}


		OnPuzzleFinished.Invoke();

		for(int i = 0; i < puzzlePlaces.Length; i++)
		{
			puzzlePlaces[i].enabled = false;
		}

		finished = true;
	}

	void OnDisable()
	{
		HoldableObjectManager.Arrived -= HoldableObjectManager_Arrived;
	}
}
