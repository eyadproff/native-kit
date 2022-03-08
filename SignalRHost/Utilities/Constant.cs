using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace SignalRHost.Utilities
{
    public class Constant
    {
        
        public const string NK_STATUS = "nkStatus";
        
        #region Logs Constant
        private static string CreateUniqueFileName()
        {
            return $"{Dns.GetHostName()}-{GetMacAddress()}";
        }
        private static string GetMacAddress()
        {
            var macAddr = (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();

            return macAddr;
        }
        public static readonly string NKM_ZIP_PATH = @$"C:\NativeKit\NKM\{CreateUniqueFileName()}_NKM_logs.zip";


        public static readonly string NK_ZIP_PATH = @$"C:\NativeKit\NativeApp\{CreateUniqueFileName()}_NK_logs.zip";
        public const string TARGET_PATH = @"C:\NativeKit\logexport";
        public const string NKM_LOGS_PATH = @"C:\NativeKit\NKM\logs";
        public const string NK_LOGS_PATH = @"C:\NativeKit\NativeApp\logs";
        public const string SERVER_URL = @"http://10.0.73.50:8219/api/NativeKit/upload";
        public const string USER_NAME = "test";
        public const string PASSWORD = "test";
        
        #endregion Logs Constant

        #region Canon Constant
        
        public const string CANON_STREAM = "canonStream";
        public const string CANON_IMAGE = "canonImage";
        
        public const string CANON_CASE_ONE = "Camera not connected. Please connect physically AND/OR Turn ON SWITCH.";
        public const string CANON_CASE_TWO = "Session is closed. Please fire 'startCapturing' method to open camera session.";
        public const string CANON_CASE_THREE = "Please reconnect to Hub.";
        
        #endregion Canon Constant
        
        #region Lscan Constant
        
        public const string LSCAN_IMAGE = "lscanImage";
        public const string LSCAN_STREAM = "lscanStream";
        
        public const string LSCAN_CASE_ONE = "Please select the correct capture type.";
        public const string LSCAN_CASE_TWO = "Error while initializing device, please reconnect.";
        
        #endregion Lscan Constant
    }
} 