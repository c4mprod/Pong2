using UnityEngine;
using System.Collections;

public class ScoreDisplayScript : MonoBehaviour {

    public PlayerScript m_Player;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        this.guiText.text = "Score : " + m_Player.getScore();
	}
}
