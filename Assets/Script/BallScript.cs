using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float m_maxVelocity = 100;
    [Range(15.0f, 50.0f)]
    public float m_minVelocity = 15;
    private float m_StartMagnitude;
    private PlayerScript m_LastPlayer;

    void Awake()
    {
        this.rigidbody2D.velocity = new Vector2(m_minVelocity, m_minVelocity);
        this.m_StartMagnitude = this.rigidbody2D.velocity.magnitude;
    }

	void Update () 
    {
        float lCurrentVelocity = this.rigidbody2D.velocity.magnitude;
        float lCorrectionVelocity;

        //Checking if the current Velocity is between m_maxVelocity and m_minVelocity
        //Scale the velocity if it needs to be
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
        if (rigidbody2D.velocity.x == 0)
        {
            rigidbody2D.velocity.Set(rigidbody2D.velocity.x + 1, rigidbody2D.velocity.y);
        }
	}

    public PlayerScript GetLastPlayer()
    { 
        return this.m_LastPlayer;
    }

    //Save the last player who touches the ball for the MasterBallScript
    void OnCollisionEnter2D(Collision2D other)
    {
        this.audio.Play();
        if (other.gameObject.tag == "Player")
        {
            this.m_LastPlayer = other.gameObject.GetComponent<PlayerScript>();
        }
    }

    #region "BonusBall Methods"
    public void SpeedUp()
    {
        this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x * 2, this.rigidbody2D.velocity.y * 2);
    }

    public void SpeedDown()
    {
        this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x / 2, this.rigidbody2D.velocity.y / 2);
    }

    public void SpeedReset()
    {
        this.rigidbody2D.velocity = Vector2.ClampMagnitude(this.rigidbody2D.velocity, this.m_StartMagnitude);
    }
    #endregion
}