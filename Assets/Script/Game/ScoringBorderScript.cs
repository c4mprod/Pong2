using UnityEngine;
using System.Collections;

public class ScoringBorderScript : MonoBehaviour
{
    public PlayerScript m_Player;
    public SpawnerScript m_Spawner;
    public int m_SpawnerId;


    #region "Events Initialisation"

    /// <summary>
    /// The two differents events are used to know what spawner (depending on its ID) should release the ball once the MasterBall Bonus has been captured
    /// </summary>
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

    #endregion

    #region "Event Methods"
    public void MasterBallCatchedByPlayer(PlayerScript _Player)
    {
        _Player.AddPoint();
        this.m_Spawner.Spawn();
    }
    #endregion

    /// <summary>
    /// When the ball comes in, raise the score of the player and spawn the ball again
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            this.m_Player.AddPoint();
            this.m_Spawner.Spawn();
        }
    }
}
