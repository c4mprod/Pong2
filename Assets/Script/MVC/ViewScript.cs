using UnityEngine;
using System.Collections;

public class ViewScript : MonoBehaviour
{
    public enum PlayerIndex { Left, Middle, Right };

    public delegate PlayerModel GetPlayerModel(PlayerIndex _index);
    public static event GetPlayerModel m_GetPlayerModel;

    public delegate void ClickAction();
    public static event ClickAction m_ClickRightButton;
    public static event ClickAction m_ClickLeftButton;

    private GUIContent m_LeftPlayerContent;
    private GUIContent m_MiddlePlayerContent;
    private GUIContent m_RightPlayerContent;

    void Start()
    {
        if (m_GetPlayerModel != null)
        {
            this.m_LeftPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Left).m_SpriteModel.texture);
            this.m_MiddlePlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Middle).m_SpriteModel.texture);
            this.m_RightPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Right).m_SpriteModel.texture);
        }
    }

    void OnGUI()
    {
        Debug.Log("GUI");
        GUI.Box(new Rect(Screen.width / 2 - 300,Screen.height / 2 - 100, 550, 150), "Menu");
        
        if (GUI.Button(new Rect(Screen.width / 2 - 290, Screen.height / 2 - 90, 50, 130), "Last\nPlayer"))
        {
            if (m_ClickLeftButton != null)
                m_ClickLeftButton();
            if (m_GetPlayerModel != null)
            {
                this.m_LeftPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Left).m_SpriteModel.texture);
                this.m_MiddlePlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Middle).m_SpriteModel.texture);
                this.m_RightPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Right).m_SpriteModel.texture);
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 + 190, Screen.height / 2 - 90, 50, 130), "Next\nPlayer"))
        {
            if (m_ClickRightButton != null)
                m_ClickRightButton(); if (m_GetPlayerModel != null)
            {
                this.m_LeftPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Left).m_SpriteModel.texture);
                this.m_MiddlePlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Middle).m_SpriteModel.texture);
                this.m_RightPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Right).m_SpriteModel.texture);
            }
        }

        
       GUI.Label(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 90 , 130, 200), this.m_LeftPlayerContent);
       GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 90, 130, 200), this.m_MiddlePlayerContent);
       GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 90, 130, 200), this.m_RightPlayerContent);
    }


}
