using UnityEngine;
using System.Collections;

public class ScoreDisplayScript : MonoBehaviour {

    public PlayerScript m_Player;
    private UILabel m_ScoreDisplay;

    /// <summary>
    /// Gets the Player's score and displays it
    /// </summary>
    void Start()
    {
        m_ScoreDisplay = GetComponent<UILabel>();
    }

    void Update ()
    {
        m_ScoreDisplay.text = "Score : " + m_Player.getScore();
	}
}
