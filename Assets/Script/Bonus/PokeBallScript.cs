using UnityEngine;
using System.Collections;

public class PokeBallScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallScript>().SpeedReset();
            Destroy(gameObject);
        }
    }
}
