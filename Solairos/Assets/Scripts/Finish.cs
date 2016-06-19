using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {


    bool mouth = false;
    bool eyes = false;
    bool ears = false;

	// Use this for initialization
	void Start () {
	
	}

    void CheckBools()
    {
        if (mouth == false || eyes == false || ears == false)
            return;

        
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
	
	}
}
