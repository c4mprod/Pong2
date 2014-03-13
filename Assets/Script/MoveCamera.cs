using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public float hspeed = 30.0f;
    public Vector3 dragOrigin;

    void OnEnable()
    {
       ControllerScript.m_getMouseDrag += this.GetDrag;
    }

    void OnDisable()
    {
        ControllerScript.m_getMouseDrag -= this.GetDrag;
    }

    private Vector3 m_pos = new Vector3(0, 0, 0);
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
        if (!Input.GetMouseButton(0)) return;

        m_pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(-m_pos.x * hspeed * Time.deltaTime, 0);
        transform.Translate(move, Space.World);  
	}

    public float GetDrag()
    {
        return this.m_pos.x;
    }
}
