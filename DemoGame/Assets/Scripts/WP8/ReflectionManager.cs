using UnityEngine;
using System.Reflection;
using System;

public class ReflectionManager : MonoBehaviour {

    // Use this for initialization
    void Start () {

        // Available:
        Assembly assem = Assembly.GetExecutingAssembly();
        string assemName = assem.FullName;
        Debug.Log(assemName);

        // Error when building for WP8
        // Error building Player: Exception: Error: method `System.Reflection.Assembly System.Reflection.Assembly::GetAssembly(System.Type)` doesn't exist in target framework. It is referenced from Assembly-CSharp.dll at System.Void ReflectionManager::Start().
        //Int32 Integer1 = new Int32();
        //Assembly sampleAssembly = Assembly.GetAssembly(Integer1.GetType());
        //Debug.Log(sampleAssembly.FullName);
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}

