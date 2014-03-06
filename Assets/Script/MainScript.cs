using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

    public static MainScript m_Instance { get; private set; }

    private bool m_paused = false;

    public delegate void InputAction();
    public static event InputAction m_KeyPressedPlayerLeftUp;
    public static event InputAction m_KeyPressedPlayerLeftDown;
    public static event InputAction m_KeyPressedPlayerRightUp;
    public static event InputAction m_KeyPressedPlayerRightDown;
    public static event InputAction m_StopPlayer;


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

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
            if (m_KeyPressedPlayerLeftUp != null)
                m_KeyPressedPlayerLeftUp();
        if (Input.GetKeyUp(KeyCode.Z))
            if (m_StopPlayer != null)
                m_StopPlayer();


        if (Input.GetKey(KeyCode.S))
            if (m_KeyPressedPlayerLeftDown != null)
                m_KeyPressedPlayerLeftDown();
        if (Input.GetKeyUp(KeyCode.S))
            if (m_StopPlayer != null)
                m_StopPlayer();
        
        
        if (Input.GetKey(KeyCode.UpArrow))
            if (m_KeyPressedPlayerRightUp != null)
                m_KeyPressedPlayerRightUp();
        if (Input.GetKeyUp(KeyCode.UpArrow))
            if (m_StopPlayer != null)
                m_StopPlayer();
        
        
        if (Input.GetKey(KeyCode.DownArrow))
            if (m_KeyPressedPlayerRightDown != null)
                m_KeyPressedPlayerRightDown();
        if (Input.GetKeyUp(KeyCode.DownArrow))
            if (m_StopPlayer != null)
                m_StopPlayer();
    }
}
