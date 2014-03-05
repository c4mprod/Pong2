using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddPoint()
    {
        ++score;
    }

}
