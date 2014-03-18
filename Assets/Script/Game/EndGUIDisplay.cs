using UnityEngine;
using System.Collections;

/// <summary>
/// This Class is used to Display the Final Menu
/// </summary>
public class EndGUIDisplay : MonoBehaviour
{
    public UISprite m_EndGameMenu;

	void OnEnable() 
	{
        MainScript.m_EndGame += this.ActivateGUI;
        this.m_EndGameMenu.active = false;
    }

    void OnDisable()
    {
        MainScript.m_EndGame -= this.ActivateGUI;
    }

    /// <summary>
    /// Active the EndMenu at the end of the Game
    /// </summary>
    public void ActivateGUI()
    {
        this.m_EndGameMenu.active = true;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        StopCoroutine("Appearence");
        Application.LoadLevel("PonKemon");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
