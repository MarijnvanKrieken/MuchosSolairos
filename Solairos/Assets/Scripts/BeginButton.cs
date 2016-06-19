using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BeginButton : MonoBehaviour {

    [SerializeField]
    fixedPlace KeyHole;

	// Use this for initialization
	void Start () {
	
	}

    public void ActivateButton()
    {
        Camera.main.transform.DOMoveY(1.7f, 6.0f);

        bool win = false;

        KeyHole.CheckWinningObject(out win);

        if (win)
            Camera.main.transform.DOMoveY(1.7f, 6.0f);

    }
	
	
}
