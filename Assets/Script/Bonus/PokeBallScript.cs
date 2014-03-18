using UnityEngine;
using System.Collections;

/// <summary>
/// This Class is used by the Pokeball Bonus to reset the speed of the Ball
/// </summary>
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
