using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private int m_Score = 0;
    public float m_Speed = 20.0f;

	void FixedUpdate () 
    {
        float lInput = Input.GetAxis("Vertical");
        this.rigidbody2D.velocity = new Vector2(0, lInput * this.m_Speed);
	}

    public void AddPoint()
    {
        ++this.m_Score;
        if (this.m_Score == 10)
            MainScript.m_Instance.EndGame();

    }

    public int getScore()
    {
     return this.m_Score;
    }
}
