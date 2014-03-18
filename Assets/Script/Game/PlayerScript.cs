using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private int m_Score = 0;
    public float m_Speed = 20.0f;
    public int m_Id;

    /// <summary>
    /// Get The PlayerModel chosen by the Player in the second Scene
    /// </summary>
    public delegate Sprite GetChosenSprite();
    public static event GetChosenSprite m_getSprite;

    #region "Event"

    void Awake()
    {
        if (m_getSprite != null)
        {
            if (m_getSprite != null)
                this.gameObject.GetComponent<SpriteRenderer>().sprite = m_getSprite();
        }
    }

    /// <summary>
    /// Players are differenciated by thier ID
    /// </summary>
    void OnEnable()
    {
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
    #endregion

    #region "Events Methods"

    /// <summary>
    /// Thoses methods are used to move the player
    /// </summary>
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
    #endregion

    public void AddPoint()
    {
        ++this.m_Score;
        if (this.m_Score >= 10)
            MainScript.m_Instance.EndGame();

    }

    public int getScore()
    {
        return this.m_Score;
    }
}
