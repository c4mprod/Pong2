using UnityEngine;
using System.Collections;

public class Resize : MonoBehaviour
{
    /// <summary>
    /// This Class resize the Camera at the beginning of the game in order to scale with the resolution
    /// </summary>
    void Start()
    {
        float ltargetaspect = 16.0f / 9.0f;

        float lwindowaspect = (float)Screen.width / (float)Screen.height;

        float lscaleheight = lwindowaspect / ltargetaspect;

        Camera lcamera = GetComponent<Camera>();

        if (lscaleheight < 1.0f)
        {
            Rect rect = lcamera.rect;

            rect.width = 1.0f;
            rect.height = lscaleheight;
            rect.x = 0;
            rect.y = (1.0f - lscaleheight) / 2.0f;

            lcamera.rect = rect;
        }
        else 
        {
            float scalewidth = 1.0f / lscaleheight;

            Rect rect = lcamera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            lcamera.rect = rect;
        }
    }
}
