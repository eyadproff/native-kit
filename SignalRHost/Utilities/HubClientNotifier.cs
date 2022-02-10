using System;
using EOSDigital.API;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHost.Utilities
{
    public class HubClientNotifier
    {
        public static string GetExceptionClientNotification(Exception e)
        {
            return e switch
            {
                SDKStateException => Constant.CANON_CASE_ONE,
                CameraSessionException => Constant.CANON_CASE_TWO,
                ObjectDisposedException => Constant.CANON_CASE_THREE,
                _ => Constant.CANON_CASE_ONE
            };
        }
    }
}