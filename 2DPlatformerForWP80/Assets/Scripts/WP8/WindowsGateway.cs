using UnityEngine;
using System.Collections;
using System.IO;

using System;

/// <summary>
/// Windows specific and interop between Unity and Windows Store or Windows Phone 8
/// </summary>
public static class WindowsGateway
{

    static WindowsGateway()
    {
        // create blank implementations to avoid errors within editor
        UnityLoaded = delegate { };

        //
        OnClickPlay = delegate { };

    }

    /// <summary>
    /// Called from Unity when the app is responsive and ready for play
    /// </summary>
    public static Action UnityLoaded;

    //called when we want to Share a high score
    public static Action OnClickPlay;

}