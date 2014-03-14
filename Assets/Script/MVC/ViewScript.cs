using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// The Class is the View of the MVC pattern. It is used to display the PlayerModel info and choose the PlayerModel on the MenuScreen. The Script is attached to the ViewDetector Object.       
/// </summary>

public class ViewScript : MonoBehaviour
{
    public List<GameObject> m_PlayerList;

    public Camera m_SliderCamera;
    private Plane[] m_Planes;

    public delegate void NextMove(Plane[] _planes, GameObject _object);
    public static event NextMove m_CheckNextMove;


    /// <summary>
    ///  Get the SliderCamera planes for checks
    /// </summary>
    void Start()
    {
        m_Planes = GeometryUtility.CalculateFrustumPlanes(m_SliderCamera);
    }

    /// <summary>
    /// Check which GameObject is seen by the SliderCamera and send a event to the Controller to update the others GameObjects
    /// </summary>
    void Update()
    {
        m_Planes = GeometryUtility.CalculateFrustumPlanes(m_SliderCamera);
        foreach (GameObject lelement in m_PlayerList)
        {

            if (GeometryUtility.TestPlanesAABB(m_Planes, lelement.renderer.bounds))
            {
                if (lelement.GetComponent<PlayerDisplay>()._moved)
                    lelement.GetComponent<PlayerDisplay>()._moved = false;
            }
            else
            {
                if (m_CheckNextMove != null)
                {
                    m_CheckNextMove(this.m_Planes, lelement);
                }
            };
        }
    }   

}
