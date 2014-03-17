using UnityEngine;
using System.Collections;

/// <summary>
/// This Class is used to Display the Final Menu
/// </summary>
public class EndGUIDisplay : MonoBehaviour
{
    public UIRoot m_EndGameMenu;

	void OnEnable() 
	{
        MainScript.m_EndGame += this.ActivateGUI;
        this.m_EndGameMenu.active = false;

    }

    void OnDisable()
    {
        MainScript.m_EndGame -= this.ActivateGUI;
    }


    public void ActivateGUI()
    {
        this.m_EndGameMenu.active = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel("PonKemon");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
