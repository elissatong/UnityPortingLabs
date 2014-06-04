using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {

	public GUIText debugMsg = null;

	

	// Use this for initialization
	void Start () {

        UnityPlugins.StoreManager.AppInit();
		UnityPlugins.StoreManager.GetListingInfo();
		debugMsg.text = UnityPlugins.StoreManager.GetProductName(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
