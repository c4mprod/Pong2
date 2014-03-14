using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// The Class is the "Controller" of the MVC pattern, it can update the ModelData, get infos from The MOdelData and transfert them to the View       
/// </summary>
/// 
public class ControllerScript : MonoBehaviour
{
    /// <summary>
    /// This delegate is used to update the index in the ModelData       
    /// </summary>
    public delegate void MoveIndex();
    public static event MoveIndex m_MoveIndexRight;
    public static event MoveIndex m_MoveIndexLeft;

    /// <summary>
    /// This delegate is used to reset all the boolean m_moved in PlayerDisplay
    /// </summary>
    public delegate void ResetMovement();
    public static event ResetMovement m_Reset;

    /// <summary>
    /// This delegate is used to update the chosen player in ModelData
    /// </summary>
    /// <param name="_object"> the object on which the player clicked </param>
    public delegate void SetSelectedPlayer(GameObject _object);
    public static event SetSelectedPlayer m_Select;

    /// <summary>
    /// This delegate is used to Get the previous/next player of teh _object in order to know if the _object should be moved or not.
    /// </summary>
    /// <param name="_object"> The current object out of the view </param>

    public delegate GameObject GetPlayer(GameObject _object);
    public static event GetPlayer m_GetLeftPlayer;
    public static event GetPlayer m_GetRightPlayer;

    public delegate Sprite GetModelIndex();
    public static event GetModelIndex m_getSpriteModelLeft;
    public static event GetModelIndex m_getSpriteModelRight;

    public delegate float GetDragDirection();
    public static event GetDragDirection m_getMouseDrag;

    private bool m_moveleft = false;
    private bool m_moveright = false;

    void OnEnable()
    {
        ViewScript.m_CheckNextMove += CheckNextMove;
        PlayerDisplay.m_Click += this.ChooseSelectedPlayer; 
    }

    void OnDisable()
    {
        ViewScript.m_CheckNextMove -= CheckNextMove;
        PlayerDisplay.m_Click -= this.ChooseSelectedPlayer;
    }

    /// <summary>
    /// This methodes update the m_RightIndex and m_LeftIndex in the ModelData       
    /// </summary>
    public void UpdateIndexRight()
    {
        if (m_MoveIndexRight != null)
            m_MoveIndexRight();
    }

    public void UpdateIndexLeft()
    {
        if (m_MoveIndexLeft != null)
            m_MoveIndexLeft();
    }


    void CheckNextMove(Plane[] _planes, GameObject _object)
    {
        GameObject lNewObject = null;
        Sprite lSprite = null;
        float lDrag = 0;

        if (m_getMouseDrag != null)
            lDrag = m_getMouseDrag();
       
        
        if (lDrag < 0) /// Drag the screen to the Right
        {
            /// <summary>
            /// Detect if last movement was "to the left" and in case reset all booleans in PlayerDisplay       
            /// </summary>
            m_moveright = true;
            if (m_moveleft == true)
            {
                if (m_Reset != null)
                    m_Reset();
                m_moveleft = false;
            }

            /// <summary>
            /// Update the GameObject to display, their position and sprite       
            /// </summary>
            if (m_GetRightPlayer != null)
                lNewObject = m_GetRightPlayer(_object);
            if (GeometryUtility.TestPlanesAABB(_planes, lNewObject.renderer.bounds) && _object.GetComponent<PlayerDisplay>()._moved == false)
            {
                _object.transform.position = new Vector3(lNewObject.transform.position.x + 3, lNewObject.transform.position.y, 0);
                this.UpdateIndexRight();
                if (m_getSpriteModelRight != null)
                    lSprite = m_getSpriteModelRight();
                _object.GetComponent<SpriteRenderer>().sprite = lSprite;
                _object.GetComponent<PlayerDisplay>()._moved = true;
            }
        }


        else if (lDrag > 0) /// Drag the screen to the left
        {

            /// <summary>
            /// Detect if last movement was "to the Right" and in case reset all booleans in PlayerDisplay       
            /// </summary>
            m_moveleft = true;
            if (m_moveright == true)
            {
                if (m_Reset != null)
                    m_Reset();
                m_moveright = false;
            }

            /// <summary>
            /// Update the GameObject to display, their position and sprite       
            /// </summary>
            if (m_GetLeftPlayer != null)
                lNewObject = m_GetLeftPlayer(_object);
            if (GeometryUtility.TestPlanesAABB(_planes, lNewObject.renderer.bounds) && _object.GetComponent<PlayerDisplay>()._moved == false)
            {
                _object.transform.position = new Vector3(lNewObject.transform.position.x - 3, lNewObject.transform.position.y, 0);
                this.UpdateIndexLeft();
                if (m_getSpriteModelLeft != null)
                    lSprite = m_getSpriteModelLeft();
                _object.GetComponent<SpriteRenderer>().sprite = lSprite;
                _object.GetComponent<PlayerDisplay>()._moved = true;
            }
        }
    }

    public void ChooseSelectedPlayer(GameObject _object)
    {
        if (m_Select != null)
            m_Select(_object);
    }
}
