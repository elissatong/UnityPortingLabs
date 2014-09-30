using UnityEngine;
using UnityEditor;
using System.Collections;

public class CommandBuild
{
    [MenuItem("Build/Universal Apps 8.1 %U")]
    public static void BuildUniversalApps()
    {
        ArrayList sceneList = new ArrayList();

        foreach (var scene in EditorBuildSettings.scenes)
        {
            sceneList.Add(scene.path);
        }

        string[] levels = (string[])sceneList.ToArray(typeof(string));
        BuildPipeline.BuildPlayer(levels, "Builds/UniversalApps", BuildTarget.MetroPlayer, BuildOptions.ShowBuiltPlayer);
    }

    [MenuItem("Build/Windows Phone 8.0 %W")]
    public static void BuildWindowsPhone8()
    {
        ArrayList sceneList = new ArrayList();

        foreach (var scene in EditorBuildSettings.scenes)
        {
            sceneList.Add(scene.path);
        }

        string[] levels = (string[])sceneList.ToArray(typeof(string));
        BuildPipeline.BuildPlayer(levels, "Build/WP8", BuildTarget.WP8Player, BuildOptions.ShowBuiltPlayer);
    }
}
