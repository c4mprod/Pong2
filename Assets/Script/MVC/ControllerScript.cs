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

    public delegate GameObject GetPlayer(GameObject _object);
    public static event GetPlayer m_GetLeftPlayer;

    public delegate Sprite GetModelIndex();
    public static event GetModelIndex m_getSpriteModel;

    public delegate float GetDragDirection();
    public static event GetDragDirection m_getMouseDrag;

    void OnEnable()
    {
        ViewScript.m_CheckNextMove += CheckNextMove;
    }

    void OnDisable()
    {
        ViewScript.m_CheckNextMove -= CheckNextMove;
    }

    /// <summary>
    /// This methodes update the m_index in the ModelData       
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
        Debug.Log("Drag" + lDrag);
        if (lDrag <= 0)
        {
            if (m_GetLeftPlayer != null)
                lNewObject = m_GetLeftPlayer(_object);
            if (GeometryUtility.TestPlanesAABB(_planes, lNewObject.renderer.bounds) && _object.GetComponent<PlayerDisplay>()._moved == false)
            {
                _object.transform.position = new Vector3(lNewObject.transform.position.x + 3, lNewObject.transform.position.y, 0);
                this.UpdateIndexRight();
                if (m_getSpriteModel != null)
                    lSprite = m_getSpriteModel();
                _object.GetComponent<SpriteRenderer>().sprite = lSprite;
                _object.GetComponent<PlayerDisplay>()._moved = true;
            }
        }
    }
}
