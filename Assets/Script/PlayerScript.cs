using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private int m_Score = 0;
	
	void Update () 
    {
	}

    public void AddPoint()
    {
        ++this.m_Score;
    }

    public int getScore()
    {
     return this.m_Score;
    }
}
