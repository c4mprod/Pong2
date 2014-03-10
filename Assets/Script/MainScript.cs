using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour
{

    public static MainScript m_Instance { get; private set; }

    // List of the BonusBall which can be instanciate in the game
    public List<GameObject> m_BallList;
    private float m_TimeSinceLastBonusBall = 0;
    [Range(1.5f, 3.0f)]
    public float ShowTime = 1.5F;
    private SpriteRenderer _renderer;
    private Color _color = new Color(0.1F, 0.1F, 0.1F, 0.1F);
    private GameObject m_CurrentBonusBall;

    private bool m_StartGame = true;
    private bool m_EndGame = false;

    // Booleans which are used to deal with the inputs and the movements of the players
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
    }

    // Pause the game 
    public void EndGame()
    {
        this.m_EndGame = true;
        Time.timeScale = 0;
    }

    #region "IEnumerator"
    // Is used to give the BonusBall a nice effect when they come into play and activate their collider when it's done
    IEnumerator Appearence()
    {
        for (float t = 0; t < ShowTime; t += Time.deltaTime)
        {
            yield return null;
            this._color.r = 0.1F + t / ShowTime;
            this._color.g = 0.1F + t / ShowTime;
            this._color.b = 0.1F + t / ShowTime;
            this._color.a = 0.1F + t / ShowTime;
            this._renderer.color = this._color;
        }
        this.m_CurrentBonusBall.collider2D.enabled = true;
    }
    #endregion

    #region "GUI"
    void OnGUI()
    {
        // Start Game Button
        if (this.m_StartGame)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 + 300, 200, 100), "Click To Play"))
            {
                Application.LoadLevel("PonKemon");
                DontDestroyOnLoad(gameObject);
                this.m_StartGame = false;
            }
        }

        //End Game button
        if (this.m_EndGame == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 55, Screen.height / 2 - 200, 160, 200), "Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 150, 50), "Restart"))
            {
                this.m_EndGame = false;
                Time.timeScale = 1;
                Application.LoadLevel("PonKemon");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 75, 150, 50), "Quit"))
            {
                Application.Quit();
            }
        }
    }

    #endregion


    #region "Update and fixedUpdate"
    //Get the inputs and change booleans, methods related to the movement are called in the fixed update.
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

        //create a random Bonusball at random position every 5 seconds
        this.m_TimeSinceLastBonusBall += Time.deltaTime;

        if (this.m_TimeSinceLastBonusBall >= 5.0 && this.m_StartGame == false)
        {
            m_TimeSinceLastBonusBall = 0;

            int lRandomBonusBall;

            lRandomBonusBall = Random.Range(0, this.m_BallList.Count);
            this.m_CurrentBonusBall = (GameObject)Instantiate(this.m_BallList[lRandomBonusBall], new Vector3(Random.Range(-35, 35), Random.Range(-15, 24), 1), Quaternion.Euler(new Vector3(0, 0, 0)));
            this.m_CurrentBonusBall.collider2D.enabled = false;
            this._renderer = this.m_CurrentBonusBall.GetComponent<SpriteRenderer>();
            this._renderer.color = new Color(0.1F, 0.1F, 0.1F, 0.1F);
            this.StartCoroutine(Appearence());
        }

    }

    //call methods related to movement
    void FixedUpdate()
    {
        if (this.m_LeftPlayerUp)
        {
            if (m_KeyPressedPlayerLeftUp != null)
                m_KeyPressedPlayerLeftUp();
            this.m_LeftPlayerUp = false;
        }

        if (this.m_Released)
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
        }

        if (this.m_LeftPlayerDown)
        {
            if (m_KeyPressedPlayerLeftDown != null)
                m_KeyPressedPlayerLeftDown();
            this.m_LeftPlayerDown = false;
        }

        if (this.m_Released)
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
        }

        if (this.m_RightPlayerUp)
        {
            if (m_KeyPressedPlayerRightUp != null)
                m_KeyPressedPlayerRightUp();
            this.m_RightPlayerUp = false;
        }

        if (this.m_Released)
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
        }

        if (this.m_RightPlayerDown)
        {
            if (m_KeyPressedPlayerRightDown != null)
                m_KeyPressedPlayerRightDown();
            this.m_RightPlayerDown = false;
        }

        if (this.m_Released)
        {
            if (m_StopPlayer != null)
                m_StopPlayer();
            this.m_Released = false;
        }
    }
    #endregion
}
