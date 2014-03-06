using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour
{

    public static MainScript m_Instance { get; private set; }

    private bool m_EndGame = false;

    private bool m_LeftPlayerUp = false;
    private bool m_LeftPlayerDown = false;
    private bool m_RightPlayerUp = false;
    private bool m_RightPlayerDown = false;
    private bool m_Released = false;

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
        this.m_EndGame = true;
        Time.timeScale = 0;
    }


    void OnGUI()
    {
        if (this.m_EndGame == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 55, Screen.height / 2 - 200, 160, 300), "Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 150, 50), "Restart"))
            {
                this.m_EndGame = false;
                Time.timeScale = 1;
                Application.LoadLevel("PonKemon");
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            this.m_LeftPlayerUp = true;

        if (Input.GetKeyUp(KeyCode.Z))
        {
            this.m_Released = true;
            this.m_LeftPlayerUp = false;
        }
        if (Input.GetKey(KeyCode.S))
            this.m_LeftPlayerDown = true;

        if (Input.GetKeyUp(KeyCode.S))
        {
            this.m_Released = true;
            this.m_LeftPlayerDown = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
            this.m_RightPlayerUp = true;

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.m_Released = true;
            this.m_RightPlayerUp = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
            this.m_RightPlayerDown = true;

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.m_Released = true;
            this.m_RightPlayerDown = false;
        }


    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (m_KeyPressedPlayerLeftUp != null)
                m_KeyPressedPlayerLeftUp();
            this.m_LeftPlayerUp = false;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
            this.m_LeftPlayerUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (m_KeyPressedPlayerLeftDown != null)
                m_KeyPressedPlayerLeftDown();
            this.m_LeftPlayerDown = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
            this.m_LeftPlayerDown = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (m_KeyPressedPlayerRightUp != null)
                m_KeyPressedPlayerRightUp();
            this.m_RightPlayerUp = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
            this.m_RightPlayerUp = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (m_KeyPressedPlayerRightDown != null)
                m_KeyPressedPlayerRightDown();
            this.m_RightPlayerDown = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
            this.m_RightPlayerDown = false;
        }
    }
}
