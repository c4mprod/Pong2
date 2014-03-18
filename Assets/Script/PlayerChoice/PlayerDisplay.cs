using UnityEngine;
using System.Collections;


/// <summary>
/// This Class detect the mouse Inputs and which gameObject the Player Clicked
/// </summary>
public class PlayerDisplay : MonoBehaviour
{
    public bool _moved = false;

    public delegate void IsClicked(GameObject _ClickedObject);
    public static event IsClicked m_Click;

    void OnMouseOver()
    {
       if (Input.GetMouseButtonUp(0))
       {
           if (m_Click != null)
           {
               m_Click(this.gameObject);
           }
       }
    }
}