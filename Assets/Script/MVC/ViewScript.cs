using UnityEngine;
using System.Collections;

public class ViewScript : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 300,Screen.height / 2 - 100, 450, 150), "Menu");
        
        if (GUI.Button(new Rect(Screen.width / 2 - 290, Screen.height / 2 - 90, 50, 130), "Last\nPlayer"))
        {
            Debug.Log("Left");
        }

        if (GUI.Button(new Rect(Screen.width / 2 + 90, Screen.height / 2 - 90, 50, 130), "Next\nPlayer"))
        {
            Debug.Log("Right");
        }
    }
}
