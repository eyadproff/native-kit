namespace SignalRHost.Utilities
{
    public class Constant
    {
        public const string CANON_STREAM = "canonStream";
        public const string CANON_IMAGE = "canonImage";
        public const string LSCAN_IMAGE = "lscanImage";
        public const string LSCAN_STREAM = "lscanStream";
        public const string NK_STATUS = "nkStatus";
        public const string CANON_CASE_ONE = "Camera not connected. Please connect physically AND/OR Turn ON SWITCH.";
        public const string CANON_CASE_TWO = "Session is closed. Please fire 'startCapturing' method to open camera session.";
        public const string CANON_CASE_THREE = "Please reconnect to Hub.";
        public const string LSCAN_CASE_ONE = "Please select the correct capture type.";
        public const string LSCAN_CASE_TWO = "Error while initializing device, please reconnect.";
    }
} 