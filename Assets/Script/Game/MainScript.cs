using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This Class is the GameControler. It's used to deal with the inputs, to generate bonus balls, to start and end the game.It's also a singleton which don't destroy itself on load.       
/// </summary>
public class MainScript : MonoBehaviour
{

    public static MainScript m_Instance { get; private set; }
    public Sprite m_ChosenPlayer;
    public int m_ScreenWidth = Screen.width;

    /// <List name=" m_BallList"> List of the BonusBall which can be instanciate in the game </param>
    public List<GameObject> m_BallList;
    private float m_TimeSinceLastBonusBall = 0;
    
    [Range(1.5f, 3.0f)]
    public float ShowTime = 1.5F;
    private SpriteRenderer _renderer;
    private Color _color = new Color(0.1F, 0.1F, 0.1F, 0.1F);
    private GameObject m_CurrentBonusBall;

    /// <summary>
    /// Booleans which are used to deal with the inputs and the movements of the players
    /// </summary>
    private bool m_LeftPlayerUp = false;
    private bool m_LeftPlayerDown = false;
    private bool m_RightPlayerUp = false;
    private bool m_RightPlayerDown = false;
    private bool m_Released = false;

    /// <summary>
    /// Delegates that deals with the inputs, see PlayerScript
    /// </summary>
    public delegate void InputAction();
    public static event InputAction m_KeyPressedPlayerLeftUp;
    public static event InputAction m_KeyPressedPlayerLeftDown;
    public static event InputAction m_KeyPressedPlayerRightUp;
    public static event InputAction m_KeyPressedPlayerRightDown;
    public static event InputAction m_StopPlayer;
    
    /// <summary>
    /// This delegates are used to start the menu at the end of the game
    /// </summary>
    public delegate void GUIEndGame();
    public static event GUIEndGame m_EndGame;

    public delegate Sprite GetPlayerInModel();
    public static event GetPlayerInModel m_GetPlayerInModel;

    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
    }


    void OnEnable()
    {
        PlayerScript.m_getSprite += this.GetChosenSprite;
    }


    void OnDisable()
    { 
        PlayerScript.m_getSprite -= this.GetChosenSprite;
    }

    /// <summary>
    /// pause the Game
    /// </summary>
    public void EndGame()
    {
        if (m_EndGame != null)
        {
            StopCoroutine("Appearence");
            m_EndGame();
            Time.timeScale = 0;
        }
    }


    #region "IEnumerator"
    /// <summary>
    /// Is used to give the BonusBall a nice effect when they come into play and activate their collider when it's done
    /// </summary> 
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

    public void LoadSelectionPlayerScene()
    {
        Application.LoadLevel("PlayerLoader");
        DontDestroyOnLoad(gameObject);
    }


    #region "Update and fixedUpdate"
   /// <summary>
   /// Get the inputs and change booleans, methods related to the movement are called in the fixed update.
   /// </summary>
    void Update()
    {

        Debug.Log("Resolution : " + Screen.height + " " + Screen.width);

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


        if (Application.loadedLevel == 1)
        {
            if (m_GetPlayerInModel != null)
                this.m_ChosenPlayer = m_GetPlayerInModel();
        }
     
        /// <summary>
        /// create a random Bonusball at random position every 5 seconds
        /// </summary>
        if (Application.loadedLevel == 2)
        {
            this.m_TimeSinceLastBonusBall += Time.deltaTime;

            if (this.m_TimeSinceLastBonusBall >= 5.0)
            {
                m_TimeSinceLastBonusBall = 0;

                int lRandomBonusBall;

                lRandomBonusBall = Random.Range(0, this.m_BallList.Count);
                this.m_CurrentBonusBall = (GameObject)Instantiate(this.m_BallList[lRandomBonusBall], new Vector3(Random.Range(-35, 35), Random.Range(-15, 24), 1), Quaternion.Euler(new Vector3(0, 0, 0)));
                this.m_CurrentBonusBall.collider2D.enabled = false;
                this._renderer = this.m_CurrentBonusBall.GetComponent<SpriteRenderer>();
                this._renderer.color = new Color(0.1F, 0.1F, 0.1F, 0.1F);
                this.StartCoroutine("Appearence");
            }
        }
    }
        
    /// <summary>
    /// call methods related to movement
    /// </summary>
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


    public Sprite GetChosenSprite()
    {
        return this.m_ChosenPlayer;
    }
}
