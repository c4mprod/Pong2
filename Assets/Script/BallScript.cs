using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float m_maxVelocity = 100;
    [Range(15.0f, 50.0f)]
    public float m_minVelocity = 15;
	// Use this for initialization
	void Start () 
    {
        this.rigidbody2D.velocity = new Vector2(m_minVelocity, m_minVelocity);
	}
	
	// Update is called once per frame
	void Update () 
    {
        float lCurrentVelocity = this.rigidbody2D.velocity.magnitude;
        float lCorrectionVelocity;
        //Checking if the current Velocity is between m_maxVelocity and m_minVelocity
        if (lCurrentVelocity > m_maxVelocity)
        {
            lCorrectionVelocity = lCurrentVelocity / m_maxVelocity;
            rigidbody2D.velocity /= lCorrectionVelocity;
        }

        if (lCurrentVelocity < m_minVelocity)
        {
            lCorrectionVelocity = lCurrentVelocity / m_minVelocity;
            rigidbody2D.velocity /= lCorrectionVelocity;
        }
	}
}
