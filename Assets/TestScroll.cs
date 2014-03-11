using UnityEngine;
using System.Collections;

public class TestScroll : MonoBehaviour
{
    private Rect scrollViewRect = new Rect(50, 50, 500, 200);

    private Rect gridRect = new Rect(51, 51, 900, 100);

    private Vector2 scrollPos;

    private string[] gridStrings = { "toto", "titi", "tata", "tuile", "test", "test2", "tes3" };

    private int selected = 0;

    private int gridWidth = 10;



    void OnGUI()
    {

        scrollPos = GUI.BeginScrollView(scrollViewRect, scrollPos, gridRect);

        selected = GUI.SelectionGrid(gridRect, selected, gridStrings, gridWidth);

        GUI.EndScrollView();

    }
}
