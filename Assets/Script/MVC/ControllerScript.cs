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
        GameObject lRightObject = null;

        if (m_GetLeftPlayer != null)
            lRightObject = m_GetLeftPlayer(_object);
        if (GeometryUtility.TestPlanesAABB(_planes, lRightObject.renderer.bounds) && _object.GetComponent<PlayerDisplay>()._moved == false)
        {
            _object.transform.position = new Vector3(lRightObject.transform.position.x + 3, lRightObject.transform.position.y, 0);
            _object.GetComponent<PlayerDisplay>()._moved = true;
        }

    }
}
