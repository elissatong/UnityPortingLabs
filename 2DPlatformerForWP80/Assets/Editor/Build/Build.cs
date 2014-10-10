using UnityEngine;
using UnityEditor;
using System.Collections;

public class CommandBuild
{
    [MenuItem("Build/Build Windows Phone8")]
    public static void BuildWindowsPhone8()
    {
        ArrayList sceneList = new ArrayList();

        foreach (var scene in EditorBuildSettings.scenes)
        {
            sceneList.Add(scene.path);
        }

        string[] levels = (string[])sceneList.ToArray(typeof(string));
        BuildPipeline.BuildPlayer(levels, "WP8", BuildTarget.WP8Player, BuildOptions.None);
    }
}
