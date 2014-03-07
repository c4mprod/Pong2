using UnityEngine;
using System.Collections;

public class MasterBallScript : MonoBehaviour {

    public delegate void CatchMasterBall(PlayerScript _Player);
    public static event CatchMasterBall m_PLayerLeftCatchMasterBall;
    public static event CatchMasterBall m_PLayerRightCatchMasterBall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            PlayerScript lPlayer;

            lPlayer = other.gameObject.GetComponent<BallScript>().GetLastPlayer();

            if (lPlayer.m_Id == 1)
            {
                if (m_PLayerRightCatchMasterBall != null)
                    m_PLayerRightCatchMasterBall(lPlayer);
            }
            else
            {
                if (m_PLayerLeftCatchMasterBall != null)
                    m_PLayerLeftCatchMasterBall(lPlayer);
            }
            Destroy(gameObject);
        }
    }
}
