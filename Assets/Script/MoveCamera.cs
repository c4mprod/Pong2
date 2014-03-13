using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    public float hspeed = 30.0f;
    public Vector3 dragOrigin;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * hspeed * Time.deltaTime, 0);
        transform.Translate(move, Space.World);  
	}
}
