using UnityEngine;
using System.Collections;

/// <summary>
/// This Class is used by the SpeedBallBonus to speed up the ball
/// </summary>
public class SpeedBallScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallScript>().SpeedUp();
            Destroy(gameObject);
        }
    }
}
