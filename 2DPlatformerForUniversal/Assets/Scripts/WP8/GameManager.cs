using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{

#region Instance
    private static readonly GameManager instance = new GameManager();
    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Accessible variables
    
    public static bool isMainMenu = true;
#endregion

#region PAUSE_MENU_BUTTONS // Continue & Quit

    public Texture2D normalButton = null;
    public Texture2D hoverButton = null;

    private GUIStyle mGUIStyleBtn;

    private float OFFSET = 25;
    private float BUTTON_SIZE_WIDTH = 200;
    private float BUTTON_SIZE_HEIGHT = 50;
    private float xPos, yPos = 0;

    private void SetGuiStyles()
    {
        float halfButtonWidth = BUTTON_SIZE_WIDTH * 0.5f;
        xPos = Screen.width * 0.5f - halfButtonWidth;
        yPos = Screen.height * 0.5f - halfButtonWidth;

        mGUIStyleBtn = new GUIStyle();
        mGUIStyleBtn.fontSize = 24;
        mGUIStyleBtn.fontStyle = FontStyle.Bold;

        GUIStyleState styleNormal = new GUIStyleState();
        styleNormal.background = normalButton;

        GUIStyleState styleHover = new GUIStyleState();
        styleHover.background = hoverButton;

        mGUIStyleBtn.normal = styleNormal;
        mGUIStyleBtn.hover = styleHover;
        mGUIStyleBtn.alignment = TextAnchor.MiddleCenter;
    }

#endregion // PAUSE_MENU_BUTTONS

#region PAUSE BUTTON

    public bool isPaused = false;

    public Texture2D pauseButton = null;
    private GUIStyle mGUIStylePause = null;
    private float BUTTON_SIZE_PAUSE = 120;
    private float xPosPause = 0.0f;
    private float yPosPause = 0.0f;
    private void SetGuiStylesPause()
    {
        float halfButtonWidth = BUTTON_SIZE_WIDTH * 0.5f;
        xPosPause = Screen.width - halfButtonWidth;
        yPosPause = 0.0f;

        mGUIStylePause = new GUIStyle();
        mGUIStylePause.fontSize = 24;
        mGUIStylePause.fontStyle = FontStyle.Bold;

        GUIStyleState styleNormal = new GUIStyleState();
        styleNormal.background = pauseButton;

        mGUIStylePause.normal = styleNormal;
        mGUIStylePause.alignment = TextAnchor.MiddleCenter;
    }

#endregion // PAUSE BUTTON

#region PLUGINS_MEMORY_LABEL
    private GUIStyle mGUIStyleLabel;

    private void SetGuiLabelStyles()
    {
        mGUIStyleLabel = new GUIStyle();
        mGUIStyleLabel.fontSize = 24;
        mGUIStyleLabel.fontStyle = FontStyle.Bold;
        mGUIStyleLabel.alignment = TextAnchor.MiddleLeft;
    }

#endregion // PLUGINS_MEMORY_LABEL

    void OnGUI()
    {
        GUI.Label(new Rect(40, 20, 250, 50), UnityPlugins.Class1.GetMemoryCurrentUsage, mGUIStyleLabel);
        GUI.Label(new Rect(40, 50, 250, 50), UnityPlugins.Class1.GetMemoryUsageLimit, mGUIStyleLabel);

        if (GUI.Button(new Rect(xPosPause, yPosPause, BUTTON_SIZE_PAUSE, BUTTON_SIZE_PAUSE), "", mGUIStylePause))
        {
            isPaused = true;
        }

        if (isPaused)
        {
            if (GUI.Button(new Rect(xPos, yPos, BUTTON_SIZE_WIDTH, BUTTON_SIZE_HEIGHT), "Continue", mGUIStyleBtn))
            {
                isPaused = false;
            }
            if (GUI.Button(new Rect(xPos, yPos + OFFSET + BUTTON_SIZE_HEIGHT, BUTTON_SIZE_WIDTH, BUTTON_SIZE_HEIGHT), "Quit", mGUIStyleBtn))
            {
                Application.LoadLevel("MainMenu");
            }
        }
    }
    

    // Use this for initialization
    void Start()
    {
        SetGuiLabelStyles();
        SetGuiStyles();
        SetGuiStylesPause();
    }
        
	// Update is called once per frame
	void Update () {
        
        
	}



}
