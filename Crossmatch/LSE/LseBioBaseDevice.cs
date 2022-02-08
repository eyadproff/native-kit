using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;

namespace Crossmatch.LSE
{
    public class LseBioBaseDevice : IBioBaseDevice
    {
        private delegate void PreviewHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr ptrData);
        private PreviewHandler previewHandler = null;
        public event EventHandler<BioBasePreviewEventArgs> Preview;

        private delegate void AcquisitionStartHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr pContext, IntPtr reserved);
        private AcquisitionStartHandler acquisitionStartHandler = null;
        public event EventHandler<BioBaseAcquisitionStartEventArgs> AcquisitionStart;

        private delegate void AcquisitionCompleteHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr reserved);
        private AcquisitionCompleteHandler acquisitionCompleteHandler = null;
        public event EventHandler<BioBaseAcquisitionCompleteEventArgs> AcquisitionComplete;

        private delegate void DataAvailableHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr pContext, int dataStatus, IntPtr pdata, int detectedObjects);
        private DataAvailableHandler dataAvailableHandler = null;
       
        public event EventHandler<BioBaseDataAvailableEventArgs> DataAvailable;

        private delegate void ObjectQualityHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr ptrData, int qltyStateCount);
        private ObjectQualityHandler objectQualityHandler = null;
        public event EventHandler<BioBaseObjectQualityEventArgs> ObjectQuality;

        private delegate void DetectedObjectHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr pContext, BioBDeviceDectionAreaState state);
        private DetectedObjectHandler detectedObjectHandler = null;
        public event EventHandler<BioBaseDetectObjectEventArgs> DetectedObject;

        private delegate void ObjectCountHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, BioBObjectCountState objectsCount);
        private ObjectCountHandler objectCountHandler = null;
        public event EventHandler<BioBaseObjectCountEventArgs> ObjectCount;

        private delegate void UserInputHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, [MarshalAs(UnmanagedType.LPStr)] string deviceInput);
        private UserInputHandler userInputHandler = null;
        public event EventHandler<BioBaseUserInputEventArgs> ScannerUserInput;

        private delegate void UserOutputHandler([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr ptrOutputData);
        private UserOutputHandler userOutputHandler = null;
        public event EventHandler<BioBaseUserOutputEventArgs> ScannerUserOutput;
             
        public GuidanceType DeviceGuidanceType { get; private set; }

        public InputType DeviceInputType { get; private set; }

        public string CurrentPosition { get; set; }

        public string CurrentImpression { get; set; }

        public BioBObjectQualityState[] CurrentQualities { get; set; }

        public ActiveKeys CurrentActivetKey { get; set; }
             
        protected LseBioBaseInterop LseInterop { get; private set; }

        public BioBaseDeviceInfo DeviceInfo { get; private set; }               

        public BioBaseDevicePropertyDictionary Properties => LseInterop.GetProperties(DeviceInfo.DeviceId);

      
        public LseBioBaseDevice(BioBaseDeviceInfo deviceInfo, LseBioBaseInterop lseInterop)
        {
            DeviceInfo = deviceInfo;
            LseInterop = lseInterop;                     

            previewHandler = new PreviewHandler(OnPreview);
            acquisitionStartHandler = new AcquisitionStartHandler(OnAcquisitionStart);
            acquisitionCompleteHandler = new AcquisitionCompleteHandler(OnAcquisitionComplete);
            dataAvailableHandler = new DataAvailableHandler(OnDataAvailable);
           
            objectQualityHandler = new ObjectQualityHandler(OnObjectQuality);
            //detectedObjectHandler = new DetectedObjectHandler(OnDetectObject);
            //objectCountHandler = new ObjectCountHandler(OnObjectCount);
            //userInputHandler = new UserInputHandler(OnUserInput);
            //userOutputHandler = new UserOutputHandler(OnUserOutput);
        }
           
        public virtual void Initialize()
        {
            if (!LseInterop.IsDeviceOpen(DeviceInfo.DeviceId))
            {
                RegisterCallbacks(DeviceInfo.DeviceId);
                try
                {
                    LseInterop.OpenDevice(DeviceInfo.DeviceId, false);
                    GetDeviceElements();
                }
                catch (BioBaseException ex)
                {
                    if (ex.ReturnCode >= BioBErrorCode.BIOB_SUCCESS)
                        GetDeviceElements();
                    throw new BioBaseException($"Unable to initilize device due {ex.Message}");
                }
            }
        }

        private void RegisterCallbacks(string deviceId)
        {
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_PREVIEW, previewHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_OBJECT_QUALITY, objectQualityHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_OBJECT_COUNT, objectCountHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_SCANNER_USERINPUT, userInputHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_SCANNER_USEROUTPUT, userOutputHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_ACQUISITION_STARTED, acquisitionStartHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_ACQUISITION_COMPLETED, acquisitionCompleteHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_DATA_AVAILABLE, dataAvailableHandler);
            LseInterop.RegisterDeviceCallback(deviceId, BioBEvents.BIOB_OBJECT_DETECTED, detectedObjectHandler);
        }

        private void GetDeviceElements()
        {
            string ledType = GetProperty(BioBaseConstants.DEV_PROP_DEVICE_LED_TYPE);
            string keyType = GetProperty(BioBaseConstants.DEV_PROP_DEVICE_KEYPAD_TYPE);

            if (ledType == BioBaseConstants.DEV_PROP_LED_TYPE_LSCAN)
                DeviceGuidanceType = GuidanceType.GuidanceTypeLScan;
            else if (ledType == BioBaseConstants.DEV_PROP_LED_TYPE_STATUS)
                DeviceGuidanceType = GuidanceType.GuidanceTypeStatusLED;
            else if (ledType == BioBaseConstants.DEV_PROP_LED_TYPE_LSCAN_DISPLAY_EMULATION)
                DeviceGuidanceType = GuidanceType.GuidanceTypeTFT;
            else if (ledType == BioBaseConstants.DEV_PROP_LED_TYPE_LSCAN_DISPLAY_EMULATION_1000PPI)
                DeviceGuidanceType = GuidanceType.GuidanceTypeTFT_1000;
            else
            {
                if ((DeviceInfo.ModelName == "GUARDIAN Module") ||
                   (DeviceInfo.ModelName == "GUARDIAN 100") ||
                   (DeviceInfo.ModelName == "GUARDIAN 200") ||
                   (DeviceInfo.ModelName == "GUARDIAN 300") ||
                   (DeviceInfo.ModelName == "GUARDIAN"))
                    DeviceGuidanceType = GuidanceType.GuidanceTypeTouchDisplay;
                else
                    DeviceGuidanceType = GuidanceType.GuidanceTypeNone;
            }

            if (keyType == BioBaseConstants.DEV_PROP_KEYPAD_2_KEYS)
                DeviceInputType = InputType.InputType2Key;
            else if (keyType == BioBaseConstants.DEV_PROP_KEYPAD_4_KEYS)
                DeviceInputType = InputType.InputType4Key;
            else if (keyType == BioBaseConstants.DEV_PROP_KEYPAD_5_KEYS)
                DeviceInputType = InputType.InputType5Key;
            else if (keyType == BioBaseConstants.DEV_PROP_KEYPAD_TOUCH_DISPLAY)
                DeviceInputType = InputType.InputTypeTouchKey;
            else
                DeviceInputType = InputType.InputTypeNone;
        }
                 
        public bool IsDeviceReady()
        {
            return LseInterop.IsDeviceReady(DeviceInfo.DeviceId);
        }

        public bool IsDeviceOpen()
        {
            return LseInterop.IsDeviceOpen(DeviceInfo.DeviceId);
        }

        public bool IsDeviceAcquiring()
        {
            return LseInterop.IsDeviceAcquiring(DeviceInfo.DeviceId);
        }

        public string GetBioBaseProperties()
        {
            return LseInterop.GetPropertiesBasic(DeviceInfo.DeviceId);
        }

        public string GetProperty(string propertyName)
        {
            return LseInterop.GetProperty(DeviceInfo.DeviceId, propertyName);
        }

        public void SetProperty(string propertyName, string propertyValue)
        {
            LseInterop.SetProperty(DeviceInfo.DeviceId, propertyName, propertyValue);
        }

        public void AdjustAcquisitionProcess(string type, string value)
        {
            LseInterop.AdjustAcquisitionProcess(DeviceInfo.DeviceId, type, value);
        }

        public void BeginAcquisitionProcess()
        {
            LseInterop.BeginAcquisitionProcess(DeviceInfo.DeviceId, CurrentPosition, CurrentImpression);
        }

        public void CancelAcquisition()
        {
            LseInterop.CancelAcquisition(DeviceInfo.DeviceId);
        }

        public void RequestAcquisitionOverride()
        {
            LseInterop.RequestAcquisitionOverride(DeviceInfo.DeviceId);
        }

        public void SetOutputData(BioBSetOutputData outputData)
        {
            LseInterop.SetOutputData(DeviceInfo.DeviceId, outputData);
        }

        public void SetVisualizationWindow(IntPtr window, string visualizerType, BioBOsType os)
        {
            LseInterop.SetVisualizationWindow(DeviceInfo.DeviceId, window, visualizerType, os);
        }

        private void OnPreview([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr ptrData)
        {
            if (Preview != null)
            {
                if (ptrData != IntPtr.Zero)
                {
                    BioBasePreviewEventArgs args = new BioBasePreviewEventArgs(deviceId, ptrData);
                    Preview.Invoke(this, args);
                }
            }
        }

        private void OnAcquisitionStart([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr reserved)
        {
            if (AcquisitionStart != null)
            {
                BioBaseAcquisitionStartEventArgs args = new BioBaseAcquisitionStartEventArgs(deviceId);
                AcquisitionStart.Invoke(this, args);
            }
        }

        private void OnAcquisitionComplete([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr pContext, IntPtr reserved)
        {
            if (AcquisitionComplete != null)
            {
                BioBaseAcquisitionCompleteEventArgs args = new BioBaseAcquisitionCompleteEventArgs(deviceId);
                AcquisitionComplete.Invoke(this, args);
            }
        }

        private void OnDataAvailable([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, int dataStatus, IntPtr ptrData, int detectedObjects)
        {
            if (DataAvailable != null)
            {
                if ((dataStatus >= (int)BioBErrorCode.BIOB_SUCCESS) && (ptrData != IntPtr.Zero))
                {
                    BioBaseDataAvailableEventArgs args = new BioBaseDataAvailableEventArgs(deviceId, dataStatus, ptrData, detectedObjects);
                    DataAvailable.Invoke(this, args);
                }

            }
        }

        private void OnObjectQuality([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr ptrQltyStateArray, int qltyStateCount)
        {
            if (ObjectQuality != null)
            {
                int[] temp = new int[qltyStateCount];
                Marshal.Copy(ptrQltyStateArray, temp, 0, qltyStateCount);

                BioBObjectQualityState[] qualities = new BioBObjectQualityState[qltyStateCount];
                for (int i = 0; i < qltyStateCount; i++)
                {
                    qualities[i] = (BioBObjectQualityState)temp[i];
                }

                BioBaseObjectQualityEventArgs args = new BioBaseObjectQualityEventArgs(deviceId, qualities, qltyStateCount);
                ObjectQuality.Invoke(this, args);
            }
        }

        private void OnDetectObject([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, BioBDeviceDectionAreaState areastate)
        {
            if (DetectedObject != null)
            {
                BioBaseDetectObjectEventArgs args = new BioBaseDetectObjectEventArgs(deviceId, areastate);
                DetectedObject.Invoke(this, args);
            }
        }

        private void OnObjectCount([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, BioBObjectCountState countState)
        {
            if (ObjectCount != null)
            {
                BioBaseObjectCountEventArgs args = new BioBaseObjectCountEventArgs(deviceId, countState);
                ObjectCount.Invoke(this, args);
            }
        }

        private void OnUserInput([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, [MarshalAs(UnmanagedType.LPStr)] string deviceInput)
        {
            if (ScannerUserInput != null)
            {
                string PressedKeys = "";
                string DevProps = deviceInput;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(DevProps);

                XmlNodeList elem = xmlDoc.GetElementsByTagName(BioBaseConstants.IN_DATA_INPUTDATA);
                if (elem != null)
                {
                    XmlNodeList propertyNodes = elem[0].ChildNodes;
                    foreach (XmlNode node in propertyNodes)
                    {
                        if (node.NodeType == XmlNodeType.Element)
                        {
                            if (node.Name == BioBaseConstants.IN_DATA_PRESSED_ITEM_ID)
                            {
                                PressedKeys = node.InnerText;
                                break;
                            }

                            if (node.Name == BioBaseConstants.IN_DATA_PRESSED_BUTTONS)
                            {
                                PressedKeys = node.InnerText;
                                break;
                            }
                        }
                    }
                }

                BioBaseUserInputEventArgs args = new BioBaseUserInputEventArgs(deviceId, PressedKeys);
                ScannerUserInput.Invoke(this, args);
            }
        }

        private void OnUserOutput([MarshalAs(UnmanagedType.LPStr)] string deviceId, IntPtr ptrContext, IntPtr ptrOutputData)
        {
            if (ScannerUserOutput != null)
            {
                BioBaseUserOutputEventArgs args = new BioBaseUserOutputEventArgs(deviceId, ptrOutputData);
                ScannerUserOutput.Invoke(this, args);
            }
        }

        ~LseBioBaseDevice()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (DeviceInfo != null)
            {

                UnregisterDeviceSpecificCallbacks(DeviceInfo.DeviceId);
                Thread.Sleep(500);
                LseInterop.CloseDevice(DeviceInfo.DeviceId, false);
                DeviceInfo = null;
                LseInterop = null;
            }
        }

        private void UnregisterDeviceSpecificCallbacks(string DeviceID)
        {
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_INIT_PROGRESS, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_PREVIEW, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_OBJECT_QUALITY, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_OBJECT_COUNT, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_SCANNER_USERINPUT, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_SCANNER_USEROUTPUT, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_ACQUISITION_STARTED, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_ACQUISITION_COMPLETED, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_DATA_AVAILABLE, null);
            LseInterop.RegisterDeviceCallback(DeviceID, BioBEvents.BIOB_OBJECT_DETECTED, null);
        }
    }
}
