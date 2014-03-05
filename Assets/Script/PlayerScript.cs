using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private int m_Score = 0;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    Debug.Log("Score" + this.m_Score);
	}

    public void AddPoint()
    {
        ++this.m_Score;
    }

}
