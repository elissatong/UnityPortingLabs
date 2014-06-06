using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {

    public Texture2D normalButton = null;
    public Texture2D hoverButton = null;

	private Rect m_ScreenRectangle;
    private string m_ProductName;
    private GUIStyle m_GUIStyle;
    
    private GUIStyle m_GUIStyleBtn;


    private float XOFFSET = 25;
    private float YOFFSETNAME = 100;
    private float YOFFSETBTN = 170;

    private string TILE_PRODUCTLIST = "List of products: ";
	// Use this for initialization
	void Start () {

        UnityPlugins.StoreManager.AppInit();
		UnityPlugins.StoreManager.GetListingInfo();

        m_ScreenRectangle = new Rect(XOFFSET, YOFFSETNAME, Screen.width, Screen.height);
        m_ProductName = UnityPlugins.StoreManager.GetProductName(0);
        m_GUIStyle = new GUIStyle();
        m_GUIStyle.fontSize = 24;
        m_GUIStyle.fontStyle = FontStyle.Bold;

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

    void OnGUI()
    {
        GUI.Label(m_ScreenRectangle, TILE_PRODUCTLIST + UnityPlugins.StoreManager.GetProductName(0), m_GUIStyle);

        if (GUI.Button(new Rect(XOFFSET, YOFFSETBTN, 200, 50), "Buy Product A", m_GUIStyleBtn))
        {
            UnityPlugins.StoreManager.BuyProduct("productA");
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
