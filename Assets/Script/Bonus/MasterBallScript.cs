using UnityEngine;
using System.Collections;

public class MasterBallScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallScript>().SpeedUp();
            Destroy(gameObject);
        }
    }
}
