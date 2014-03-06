using UnityEngine;
using System.Collections;

public class ScoringBorderScript : MonoBehaviour
{

    public PlayerScript m_Player;
    public SpawnerScript m_Spawner;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            this.m_Player.AddPoint();
            this.m_Spawner.Spawn();
        }
    }
}
