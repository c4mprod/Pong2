using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private int m_Score = 0;
    public float m_Speed = 20.0f;
    public int m_Id;

    void OnEnable()
    {
        // Allow to differenciate the player

        if (this.m_Id == 1)
        {
            MainScript.m_KeyPressedPlayerRightUp += this.MoveUp;
            MainScript.m_KeyPressedPlayerRightDown += this.MoveDown;
            MainScript.m_StopPlayer += this.StopMovement;
        }

        if (this.m_Id == 2)
        {
            MainScript.m_KeyPressedPlayerLeftUp += this.MoveUp;
            MainScript.m_KeyPressedPlayerLeftDown += this.MoveDown;
            MainScript.m_StopPlayer += this.StopMovement;
        }
    }

    void OnDisable()
    {
        if (this.m_Id == 1)
        {
            MainScript.m_KeyPressedPlayerRightUp -= this.MoveUp;
            MainScript.m_KeyPressedPlayerRightDown -= this.MoveDown;
            MainScript.m_StopPlayer -= this.StopMovement;
        }

        if (this.m_Id == 2)
        {
            MainScript.m_KeyPressedPlayerLeftUp -= this.MoveUp;
            MainScript.m_KeyPressedPlayerLeftDown -= this.MoveDown;
            MainScript.m_StopPlayer -= this.StopMovement;
        }
    }

    public void AddPoint()
    {
        ++this.m_Score;
        if (this.m_Score == 10)
            MainScript.m_Instance.EndGame();

    }

    public int getScore()
    {
     return this.m_Score;
    }

    void MoveDown()
    {
        this.rigidbody2D.velocity = new Vector2(0, -1 * this.m_Speed);
    }

    void MoveUp()
    {
        this.rigidbody2D.velocity = new Vector2(0, 1 * this.m_Speed);
    }

    void StopMovement()
    {
        this.rigidbody2D.velocity = new Vector2(0, 0);
    }
}
