using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {


	public Texture2D normalButton = null;
	public Texture2D hoverButton = null;

	private GUIStyle mGUIStyleBtn;

	private float OFFSET = 10;
	private float BUTTON_SIZE = 200;
	private float xPos, yPos = 0;

	private void SetGuiStyles()
	{
		xPos = Screen.width - OFFSET - BUTTON_SIZE;
        yPos = Screen.height - OFFSET - BUTTON_SIZE;

		mGUIStyleBtn = new GUIStyle();
		mGUIStyleBtn.fontSize = 24;
		mGUIStyleBtn.fontStyle = FontStyle.Bold;

		GUIStyleState styleNormal = new GUIStyleState();
		styleNormal.background = normalButton;

		GUIStyleState styleHover = new GUIStyleState();
		styleHover.background = hoverButton;

		mGUIStyleBtn.normal = styleNormal;
		mGUIStyleBtn.hover = styleHover;
		mGUIStyleBtn.alignment = TextAnchor.MiddleLeft;
	}

	void OnGUI()
	{
		
		if (GUI.Button(new Rect(xPos, yPos, BUTTON_SIZE, BUTTON_SIZE), "", mGUIStyleBtn))
		{
            WindowsGateway.OnClickPlay();
            Application.LoadLevel("Level");		
		}
	}
	
    void Start()
    {
        SetGuiStyles();
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE Input key down");
            Application.Quit();
        }
	}
}
