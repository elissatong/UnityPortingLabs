using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {

    public Texture2D normalButton = null;
    public Texture2D hoverButton = null;

	private Rect m_ScreenRectangle;
    private Rect m_ScreenRectangle2;

    private string m_ProductName;
    private string m_Message = "";

    private GUIStyle m_GUIStyle;
    private GUIStyle m_GUIStyleBtn;


    private float XOFFSET = 25;
    private float YOFFSETBTN = 120;
    private float YOFFSETMSG = 70;
    private float YOFFSETNAME = 40;

    private string mButtonText = "Buy ";

    private string TILE_PRODUCTLIST = "List of products: ";
    private string mBuyProductId = "";
    private string mBuyProductName = "";
    private const int TESTPRODUCTINDEX = 0;

	// Use this for initialization
	void Start () {

        UnityPlugins.StoreManager.AppInit();
		UnityPlugins.StoreManager.GetListingInfo();

        m_ScreenRectangle = new Rect(XOFFSET, Screen.height - YOFFSETNAME, Screen.width, Screen.height);
        m_ScreenRectangle2 = new Rect(XOFFSET, Screen.height - YOFFSETMSG, Screen.width, Screen.height);

        int count = UnityPlugins.StoreManager.GetCount();
        m_ProductName = TILE_PRODUCTLIST;
        if (count == 0)
        {
            m_ProductName += "none";
        }
        else
        {
            for (int i = 0; i < count; ++i)
            {
                m_ProductName += UnityPlugins.StoreManager.GetProductName(i) + " ";
            }

            mBuyProductName = UnityPlugins.StoreManager.GetProductName(TESTPRODUCTINDEX);
            mButtonText += mBuyProductName;
            mBuyProductId = UnityPlugins.StoreManager.GetProductId(TESTPRODUCTINDEX);
        }
            
        m_GUIStyle = new GUIStyle();
        m_GUIStyle.fontSize = 20;
        m_GUIStyle.fontStyle = FontStyle.Bold;

        m_GUIStyleBtn = new GUIStyle();
        m_GUIStyleBtn.fontSize = 20;
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
        // Display the buy button if a product at index 0 is available
        if (string.IsNullOrEmpty(mBuyProductId) == false)
        {
            if (GUI.Button(new Rect(XOFFSET, Screen.height - YOFFSETBTN, 160, 40), mButtonText, m_GUIStyleBtn))
            {
                bool isSuccess = UnityPlugins.StoreManager.BuyProduct(mBuyProductId);
                if (isSuccess)
                {
                    m_Message = "Successly bought: " + mBuyProductName;
                }
                else
                {
                    m_Message = "Failed to buy: " + mBuyProductName + ", please try again later.";
                }
            }
        }
        GUI.Label(m_ScreenRectangle, m_Message, m_GUIStyle);
        GUI.Label(m_ScreenRectangle2, m_ProductName, m_GUIStyle);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
