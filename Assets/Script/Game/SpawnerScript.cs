using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    public GameObject m_Ball;
    
    /// <summary>
    /// Create an Orientation in order to choose the velocity's range of the ball
    /// </summary>
    enum Orientation {Left, Right};
    private Orientation m_Orientation;

    void Awake()
    {
        if (this.transform.position.x < 0)
            this.m_Orientation = Orientation.Left;
        else
            this.m_Orientation = Orientation.Right;
    }

    /// <summary>
    /// Spawn the ball and randomly set it's velocity
    /// </summary>
    public void Spawn()
    {
        float lVelocityX;
        BallScript lBall = this.m_Ball.GetComponent<BallScript>();
        
        //Orientate the Ball when it spawn in order to aim at the last scoring Player
     
        if (this.m_Orientation == Orientation.Left)
            lVelocityX = -lBall.m_minVelocity;
        else
            lVelocityX = lBall.m_minVelocity;

        this.m_Ball.transform.position = this.transform.position;
        this.m_Ball.rigidbody2D.velocity = new Vector2(lVelocityX, Random.Range(-lBall.m_minVelocity, lBall.m_minVelocity));
    }
}
