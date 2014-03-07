using UnityEngine;
using System.Collections;

public class ScoringBorderScript : MonoBehaviour
{
    public PlayerScript m_Player;
    public SpawnerScript m_Spawner;
    public int m_SpawnerId;


    void OnEnable()
    {
        if (this.m_SpawnerId == 1)
        {
            MasterBallScript.m_PLayerLeftCatchMasterBall += MasterBallCatchedByPlayer;
        }

        if (this.m_SpawnerId == 2)
        {
            MasterBallScript.m_PLayerRightCatchMasterBall += MasterBallCatchedByPlayer;
        }
    }

    void OnDisable()
    {
        if (this.m_SpawnerId == 1)
        {
            MasterBallScript.m_PLayerLeftCatchMasterBall -= MasterBallCatchedByPlayer; ;
        }

        if (this.m_SpawnerId == 2)
        {
            MasterBallScript.m_PLayerRightCatchMasterBall -= MasterBallCatchedByPlayer;
        }
    }


    public void MasterBallCatchedByPlayer(PlayerScript _Player)
    {
        _Player.AddPoint();
        this.m_Spawner.Spawn();
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
