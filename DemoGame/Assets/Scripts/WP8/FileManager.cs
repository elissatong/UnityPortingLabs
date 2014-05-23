using UnityEngine;
using System.Collections;

public class FileManager : MonoBehaviour
{
    
    IEnumerator Start()
    {
        WWW wwwBinary = new WWW("http://unityportinglab.azurewebsites.net/images/smallicon.png");
        yield return wwwBinary;

        if (wwwBinary.isDone)
        {
            UnityPlugins.Directory.CreateFolder("Test");
            UnityPlugins.Directory.CreateFolder("Test/Test1/Test2");

            byte[] fileBytes = wwwBinary.bytes;
            UnityPlugins.File.CreateFile("test.png", fileBytes, "Test");
            
        }

        WWW wwwText = new WWW("http://unityportinglab.azurewebsites.net/tilestemplateshort.xml");
        yield return wwwText;
        if (wwwText.isDone)
        {
            UnityPlugins.File.CreateFile("test.txt", wwwText.text, "Test/Test1");
        }

    }

    
}
