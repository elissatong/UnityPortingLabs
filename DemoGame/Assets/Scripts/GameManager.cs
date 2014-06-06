using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Texture2D normalButton = null;
    public Texture2D hoverButton = null;

    private float OFFSET = 25;
    private float BUTTON_SIZE = 100;
    private float xPos, yPos = 0;

    private GUIStyle m_GUIStyleBtn;
		
		
	// Use this for initialization
	void Start () {

        yPos = Screen.height - BUTTON_SIZE - OFFSET;
        xPos = Screen.width - BUTTON_SIZE - OFFSET;


        m_GUIStyleBtn = new GUIStyle();
        m_GUIStyleBtn.fontSize = 24;
        m_GUIStyleBtn.fontStyle = FontStyle.Bold;

        GUIStyleState styleNormal = new GUIStyleState();
        styleNormal.background = normalButton;

        GUIStyleState styleHover = new GUIStyleState();
        styleHover.background = hoverButton;

        m_GUIStyleBtn.normal = styleNormal;
        m_GUIStyleBtn.hover = styleHover;
        m_GUIStyleBtn.alignment = TextAnchor.MiddleCenter;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(xPos, yPos, BUTTON_SIZE, BUTTON_SIZE), "", m_GUIStyleBtn))
        {
            Debug.Log("Press Play");
            Application.LoadLevel("Level");
        }
    }
}
