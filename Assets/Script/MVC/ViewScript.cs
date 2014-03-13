using UnityEngine;
using System.Collections;


/// <summary>
/// The Class is the View of the MVC pattern. It is used to display the PlayerModel info and choose the PlayerModel on the MenuScreen. The Script is attached to the MainScript.       
/// </summary>

public class ViewScript : MonoBehaviour
{
    /// <enum name="PlayerIndex">It's used to choose which Player would be dislay in the Left/Middle/Right Label on the screen  </param>
    public enum PlayerIndex { Left, Middle, Right };


    /// <summary>
    /// This delegate is used to get the PlayerModel to display, see ControllerScript       
    /// </summary>
    public delegate PlayerModel GetPlayerModel(PlayerIndex _index);
    public static event GetPlayerModel m_GetPlayerModel;


    /// <summary>
    /// This delegate is used to start an event when the button on the GUi are pressed, it causes the ControllerScript to move the index of the ModelData.        
    /// </summary>
    public delegate void ClickAction();
    public static event ClickAction m_ClickRightButton;
    public static event ClickAction m_ClickLeftButton;

    private GUIContent m_LeftPlayerContent;
    private GUIContent m_MiddlePlayerContent;
    private GUIContent m_RightPlayerContent;

    /// <summary>
    /// Get the first PlayerModels to display, they depends on the m_index of the ModelData         
    /// </summary>
    void Start()
    {
        /*
        if (m_GetPlayerModel != null)
        {
            this.m_LeftPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Left).m_SpriteModel.texture);
            this.m_MiddlePlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Middle).m_SpriteModel.texture);
            this.m_RightPlayerContent = new GUIContent(m_GetPlayerModel(PlayerIndex.Right).m_SpriteModel.texture);
        }
         * */
    }

    void OnGUI()
    {
     /*
        GUI.Box(new Rect(Screen.width / 2 - 300,Screen.height / 2 - 100, 550, 150), "Menu");


        /// <summary>
        ///  Move the index of the ModelDataScript (Using the ControllerScript's methods)         
        /// </summary>
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
      */
    }


}
