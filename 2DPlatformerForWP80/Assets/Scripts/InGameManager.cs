using UnityEngine;
using System.Collections;

public class InGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPE Input key down");
            Application.LoadLevel("Main");
        }
    }
}
