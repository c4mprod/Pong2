using UnityEngine;
using System.Collections;

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
