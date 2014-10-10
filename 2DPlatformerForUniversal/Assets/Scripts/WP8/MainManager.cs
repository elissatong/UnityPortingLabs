using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{

    // Play button style, position, & background textures
    public Texture2D texPlayNormal = null;
    public Texture2D texPlayHover = null;
    private GUIStyle mGUIStyleBtnPlay = null;
    private float OFFSET = 10;
    private float BUTTON_SIZE = 200;
    private float xPos, yPos = 0;

    // Register input buttons

    #region LOGIN KEYBOARD
    public enum LoginState
    {
        Default,
        LoginAndCancel
    };

    private LoginState mLoginState = LoginState.Default;

    private string INPUT_BTN_LOGIN = "登录";
    private string INPUT_BTN_CONFIRM = "确认";
    private string INPUT_BTN_CANCEL = "取消";
    private float INPUT_OFFSET = 20;
    private float INPUT_WIDTH = 132;
    private float INPUT_HEIGHT = 72;
    private float WELCOME_LABEL_WIDTH = 150;
    private float TEXTFIELD_WIDTH = 300;
    private int LABEL_FONT_SIZE = 32;
    private float xLoginBtn, xCancelBtn, xTextField = 0;

    private GUIStyle mGUIStyleBtnInput;
    private GUIStyle mGUIStyleLabel;
    public Texture2D bkgdTextField = null;
    TouchScreenKeyboard mKeyboard = null;

    string mInputUserName = "";
    GUIStyle mGUIStyleTextField = null;

    public Texture2D texInputNormal = null;
    public Texture2D texInputHover = null;


    // Flag to prevent the multiple calls to Input.GetMouseButtonDown that keeps opening & closing the keyboard
    bool isMouseDownOnInputField = false;

    // Return from the database if the username login is correct
    private bool isLoginSuccess = false;

    // Display a message to a GUI.Label on the screen
    private string successMessage = "";

    // Store the Username Input Field to a Rect which is used for collision detection if mouse clicked on it
    Rect mRectTextField;

    #endregion // LOGIN KEYBOARD


    private void SetGuiStyleTextField()
    {
        if (mGUIStyleTextField == null)
        {
            mGUIStyleTextField = new GUIStyle();
            mGUIStyleTextField.fontSize = LABEL_FONT_SIZE;
            mGUIStyleTextField.alignment = TextAnchor.MiddleLeft;
            mGUIStyleTextField.padding.left = 10;
            mGUIStyleTextField.padding.right = 10;

            GUIStyleState style = new GUIStyleState();
            style.background = bkgdTextField;
            mGUIStyleTextField.normal = style;
        }
    }

    private void SetGuiStyles(ref GUIStyle guiStyle, Texture2D normal, Texture2D hover)
    {
        if (guiStyle == null)
        {
            guiStyle = new GUIStyle();
            guiStyle.fontSize = LABEL_FONT_SIZE;
            guiStyle.fontStyle = FontStyle.Bold;

            GUIStyleState styleNormal = new GUIStyleState();
            styleNormal.background = normal;

            GUIStyleState styleHover = new GUIStyleState();
            styleHover.background = hover;

            guiStyle.normal = styleNormal;
            guiStyle.hover = styleHover;
            guiStyle.alignment = TextAnchor.MiddleCenter;
        }
    }

    private void SetGuiLabel(ref GUIStyle guiStyle)
    {
        if (guiStyle == null)
        {
            guiStyle = new GUIStyle();
            guiStyle.fontSize = LABEL_FONT_SIZE;
            guiStyle.fontStyle = FontStyle.Bold;
            guiStyle.normal.textColor = new Color(0.3f, 0.3f, 0.3f); // dark gray
            guiStyle.alignment = TextAnchor.MiddleLeft;
        }
    }


    void SetupKeyboard()
    {
        #region LOGIN KEYBOARD
        // Setup Input Buttons
        isLoginSuccess = false;
        xLoginBtn = INPUT_OFFSET;
        xCancelBtn = xLoginBtn + INPUT_WIDTH + INPUT_OFFSET;
        xTextField = xCancelBtn + INPUT_OFFSET + INPUT_WIDTH;

        mInputUserName = "";
        mRectTextField = new Rect(xTextField, INPUT_OFFSET, TEXTFIELD_WIDTH, INPUT_HEIGHT);
        SetGuiStyleTextField();
        SetGuiStyles(ref mGUIStyleBtnInput, texInputNormal, texInputHover);
        SetGuiLabel(ref mGUIStyleLabel);
        #endregion //LOGIN KEYBOARD
    }

    void OnGUI()
    {
        #region LOGIN KEYBOARD
        if (mLoginState == LoginState.Default)
        {
            // Only show the Login Success message when LoginState.Default mode.
            if (isLoginSuccess)
            {
                GUI.Label(new Rect(xCancelBtn, INPUT_OFFSET, WELCOME_LABEL_WIDTH, INPUT_HEIGHT), successMessage, mGUIStyleLabel);
            }

            if (GUI.Button(new Rect(xLoginBtn, INPUT_OFFSET, INPUT_WIDTH, INPUT_HEIGHT), INPUT_BTN_LOGIN, mGUIStyleBtnInput))
            {
                mLoginState = LoginState.LoginAndCancel;
                if (mKeyboard == null)
                {
                    mKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false, false);
                    mKeyboard.active = true;
                }
                else if (!mKeyboard.active)
                {
                    mInputUserName = "";
                    mKeyboard.active = true;
                }
            }
        }
        else if (mLoginState == LoginState.LoginAndCancel)
        {
            //mInputUserName = GUI.TextField(new Rect(xTextField, INPUT_OFFSET, TEXTFIELD_WIDTH, INPUT_HEIGHT), mInputUserName, 16, mGUIStyleTextField);

            GUI.Label(mRectTextField, mInputUserName, mGUIStyleTextField);
            if (!isMouseDownOnInputField && !mKeyboard.active && mRectTextField.Contains(Event.current.mousePosition) && Input.GetMouseButtonDown(0))
            {
                isMouseDownOnInputField = true;
            }

            if (GUI.Button(new Rect(xLoginBtn, INPUT_OFFSET, INPUT_WIDTH, INPUT_HEIGHT), INPUT_BTN_CONFIRM, mGUIStyleBtnInput))
            {
                // TODO: Check database for login information. 


                // RETURN: When user confirms login, check login information is correct
                isLoginSuccess = true;
                successMessage = "Welcome, " + mInputUserName + "!";
                mLoginState = LoginState.Default;
            }

            if (GUI.Button(new Rect(xCancelBtn, INPUT_OFFSET, INPUT_WIDTH, INPUT_HEIGHT), INPUT_BTN_CANCEL, mGUIStyleBtnInput))
            {
                mLoginState = LoginState.Default;
            }
        }
        #endregion // LOGIN KEYBOARD

        if (GUI.Button(new Rect(xPos, yPos, BUTTON_SIZE, BUTTON_SIZE), "", mGUIStyleBtnPlay))
        {
            WindowsGateway.OnClickPlay();
            Application.LoadLevel("Level");
        }
    }



    void Start()
    {
        // Setup Play Button
        xPos = Screen.width - OFFSET - BUTTON_SIZE;
        yPos = Screen.height - OFFSET - BUTTON_SIZE;
        SetGuiStyles(ref mGUIStyleBtnPlay, texPlayNormal, texPlayHover);

        SetupKeyboard();

    }


    // Update is called once per frame
    void Update()
    {

        #region LOGIN KEYBOARD
        if (mKeyboard != null)
        {
            if (mKeyboard.active)
            {
                if (!string.IsNullOrEmpty(Input.inputString))
                {
                    mInputUserName += Input.inputString;
                }
            }
        }


        if (isMouseDownOnInputField)
        {
            if (Input.GetMouseButtonUp(0))
            {
                mKeyboard.active = true;
                isMouseDownOnInputField = false;
            }
        }
        #endregion // LOGIN KEYBOARD


#region BACKBUTTON
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE Input key down");
            Application.Quit();
        }
#endregion // BACKBUTTON

    }

}
