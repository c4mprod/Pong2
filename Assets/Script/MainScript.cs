using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

    public static MainScript m_Instance { get; private set; }
    //public BallScript m_Ball;
    private bool m_paused = false;
    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }

        Application.LoadLevel("PonKemon");
        DontDestroyOnLoad(gameObject);
    }


    public void EndGame()
    {
        this.m_paused = true;
        Time.timeScale = 0;
    }


    void OnGUI()
    {
        if (this.m_paused == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 55, Screen.height / 2 - 200, 160, 300), "Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 150, 50), "Restart"))
            {
                this.m_paused = false;
                Time.timeScale = 1;
                Application.LoadLevel("PonKemon");
            }
        }
    }
}
