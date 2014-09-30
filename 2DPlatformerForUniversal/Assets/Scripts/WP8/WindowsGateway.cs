using UnityEngine;
using System.Collections;
using System;

/// Windows specific and interop between Unity and Windows Store or Windows Phone 8
public static class WindowsGateway
{
    static WindowsGateway()
    {
        UnityLoaded = delegate { };
        OnClickPlay = delegate { };
        OnScoreUpdate = delegate { };
        OnClickBuy = delegate { };
    }

    public static Action UnityLoaded;
    public static Action OnClickPlay;
    public static Action OnScoreUpdate;
    public static Action OnClickBuy;
}