using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewDetector : MonoBehaviour
{
    public List<GameObject> m_PlayerList;
    public Camera m_SliderCamera;
    private Plane[] m_Planes;

    void Start()
    {
        m_Planes = GeometryUtility.CalculateFrustumPlanes(m_SliderCamera);
    }

    void Update()
    {
        m_Planes = GeometryUtility.CalculateFrustumPlanes(m_SliderCamera);
        foreach (GameObject lelement in m_PlayerList)
        {
            if (GeometryUtility.TestPlanesAABB(m_Planes, lelement.renderer.bounds))
            {
                Debug.Log(lelement.name + " has been detected!");
            }
            else
                Debug.Log("Nothing has been detected");
        }
    }   
}
