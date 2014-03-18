using UnityEngine;
using System.Collections;


/// <summary>
/// This Class is used by the Chronoball Bonus to slow down the Ball
/// </summary>
public class ChronoBallScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallScript>().SpeedDown();
            Destroy(gameObject);
        }
    }
}
