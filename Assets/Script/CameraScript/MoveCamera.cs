using UnityEngine;
using System.Collections;


/// <summary>
/// This Class should be attached to a Camera in order to make it move when someone drag the screen
/// </summary>
public class MoveCamera : MonoBehaviour
{
    public float hspeed = 95.0f;
    private Vector3 dragOrigin;

    void OnEnable()
    {
        ControllerScript.m_getMouseDrag += this.GetDrag;
    }

    void OnDisable()
    {
        ControllerScript.m_getMouseDrag -= this.GetDrag;
    }

    private Vector3 m_pos = new Vector3(0, 0, 0);


    /// <summary>
    ///  In Update, the drag is detected and the camera's position is updated
    /// </summary>
    void Update()
    {
        float lh;

        if (Input.GetMouseButton(0))
        {
            lh = Input.GetAxis("Mouse X");
            m_pos = Camera.main.ScreenToViewportPoint(new Vector3(lh, 0 ,0));
            Vector3 move = new Vector3(-m_pos.x * hspeed, 0);
            transform.Translate(move);
        }

    }
    /// <summary>
    ///  Return the position of the drag, in order to know where the camero is dragged to
    /// </summary>
    public float GetDrag()
    {
        return this.m_pos.x;
    }
}
