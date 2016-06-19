using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    [SerializeField]
    Image White;

    Color lerpColor = Color.clear;

    bool mouth = false;
    bool eyes = false;
    bool ears = false;

    bool done = false;

	// Use this for initialization
	void Start () {
        White.enabled = false;
	}

    void CheckBools()
    {
        if (mouth == false || eyes == false || ears == false)
            return;

        done = true;

    }



    public void MouthDone()
    {
        mouth = true;
        CheckBools();
    }

    public void EyesDone()
    {
        eyes = true;
        CheckBools();
    }

    public void EarsDone()
    {
        ears = true;
        CheckBools();
    }
	
	// Update is called once per frame
	void Update () {

        if (!done)
            return;

        White.enabled = true;
        //White.color = Color.white;
        //lerpColor = Color.Lerp(Color.clear, Color.gray, Time.deltaTime);

        //White.color = lerpColor;
	
	}
}
