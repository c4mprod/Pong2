using UnityEngine;
using System.Collections;

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
