using UnityEngine;
using System.Collections;

public class ScoreDisplayScript : MonoBehaviour {

    public PlayerScript m_Player;

    //Gets the Player's score and displays it
	void Update ()
    {
        this.guiText.text = "Score : " + m_Player.getScore();
	}
}
