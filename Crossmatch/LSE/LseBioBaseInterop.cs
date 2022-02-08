using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace Crossmatch.LSE
{
    public class LseBioBaseInterop
    {
        public string Api { get; private set; }
        public string Product { get; private set; }

        private static object synchLock = new object();

        private IntPtr ptrContext;

        protected delegate void OpenApiDelegate(out BioBErrorCode retCode);
        protected OpenApiDelegate NativeOpenApiDelegate = null;

        protected delegate void CloseApiDelegate(out BioBErrorCode retCode);
        protected CloseApiDelegate NativeCloseApiDelegate = null;

        protected delegate IntPtr GetAPIPropertiesDelegate(out BioBErrorCode retCode);
        protected GetAPIPropertiesDelegate NativeGetAPIPropertiesDelegate = null;

        protected delegate Int32 GetDeviceCountDelegate(out BioBErrorCode retCode);
        protected GetDeviceCountDelegate NativeGetDeviceCountDelegate = null;

        protected delegate IntPtr GetDevicesInfoDelegate(out BioBErrorCode retCode);
        protected GetDevicesInfoDelegate NativeGetDevicesInfoDelegate = null;

        protected delegate void OpenDeviceDelegate(string deviceId, bool reset, out BioBErrorCode retCode);
        protected OpenDeviceDelegate NativeOpenDeviceDelegate = null;

        protected delegate void CloseDeviceDelegate(string deviceId, bool sendToStandby, out BioBErrorCode retCode);
        protected CloseDeviceDelegate NativeCloseDeviceDelegate = null;

        protected delegate void RegisterDeviceCallbackDelegate(string deviceId, IntPtr ptrContext, BioBEvents events, IntPtr ptrCallback, out BioBErrorCode retCode);
        protected RegisterDeviceCallbackDelegate NativeRegisterDeviceCallbackDelegate = null;

        protected delegate IntPtr GetPropertiesDelegate(string deviceId, out BioBErrorCode retCode);
        protected GetPropertiesDelegate NativeGetPropertiesDelegate = null;

        protected delegate void SetPropertiesDelegate(string deviceId, string xml, out BioBErrorCode retCode);
        protected SetPropertiesDelegate NativeSetPropertiesDelegate = null;

        protected delegate IntPtr GetPropertyDelegate(string deviceId, string propertyName, out BioBErrorCode retCode);
        protected GetPropertyDelegate NativeGetPropertyDelegate = null;

        protected delegate void SetPropertyDelegate(string deviceId, string propertyName, string value, out BioBErrorCode retCode);
        protected SetPropertyDelegate NativeSetPropertyDelegate = null;

        protected delegate void CancelAcquisitionDelegate(string deviceId, out BioBErrorCode retCode);
        protected CancelAcquisitionDelegate NativeCancelAcquisitionDelegate = null;

        protected delegate void BeginAcquisitionProcessDelegate(string deviceId, string posType, string impType, out BioBErrorCode retCode);
        protected BeginAcquisitionProcessDelegate NativeBeginAcquisitionProcessDelegate = null;

        protected delegate void RequestAcquisitionOverrideDelegate(string deviceId, out BioBErrorCode retCode);
        protected RequestAcquisitionOverrideDelegate NativeRequestAcquisitionOverrideDelegate = null;

        protected delegate void FreeDelegate(IntPtr pString, out BioBErrorCode retCode);
        protected FreeDelegate NativeFreeDelegate = null;

        protected delegate bool IsDeviceAcquiringDelegate(string deviceId, out BioBErrorCode retCode);
        protected IsDeviceAcquiringDelegate NativeIsDeviceAcquiringDelegate = null;

        protected delegate bool IsDeviceOpenedDelegate(string deviceId, out BioBErrorCode retCode);
        protected IsDeviceOpenedDelegate NativeIsDeviceOpenedDelegate = null;

        protected delegate bool IsDeviceReadyDelegate(string deviceId, out BioBErrorCode retCode);
        protected IsDeviceReadyDelegate NativeIsDeviceReadyDelegate = null;

        protected delegate void SetOutputDataDelegate(string deviceId, ref BioBSetOutputData Data, out BioBErrorCode retCode);
        protected SetOutputDataDelegate NativeSetOutputDataDelegate = null;

        protected delegate void AdjustAcquisitionProcessDelegate(string deviceId, string type, string value, out BioBErrorCode retCode);
        protected AdjustAcquisitionProcessDelegate NativeAdjustAcquisitionProcessDelegate = null;

        protected delegate void SetVisualizationWindowDelegate(string deviceId, IntPtr window, string visualizer, BioBOsType osType, out BioBErrorCode retCode);
        protected SetVisualizationWindowDelegate NativeSetVisualizationWindowDelegate = null;
              
        public LseBioBaseInterop()
        {
            ptrContext = IntPtr.Zero;
            if (synchLock == null)
            {
                synchLock = new object();
            }
        }

        public void Open()
        {
            BioBErrorCode retCode;

            NativeOpenApiDelegate(out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            IntPtr ptr = IntPtr.Zero;
            string strXml = string.Empty;

            ptr = NativeGetAPIPropertiesDelegate(out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            try
            {
                strXml = Marshal.PtrToStringAnsi((IntPtr)ptr);
            }
            catch (ArgumentNullException ex)
            {
                throw new BioBaseException("GetAPIProperties not able to Marshal XML data", ex);
            }
            finally
            {
                NativeFreeDelegate(ptr, out retCode);
                if (retCode != BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
            }

            if (string.IsNullOrEmpty(strXml))
                throw new BioBaseException("GetAPIProperties no XML data");

            XmlDocument devicesDoc = new XmlDocument();
            try
            {
                devicesDoc.LoadXml(strXml);
            }
            catch (XmlException ex)
            {
                throw new BioBaseException("GetAPIProperties XML bad format", ex);
            }

            string deviceId = string.Empty;
            XmlNodeList deviceNodes = devicesDoc.SelectNodes("//ApiProperties");
            foreach (XmlNode node in deviceNodes)
            {
                XmlNode deviceIdNode = node.SelectSingleNode("Api");
                if (deviceIdNode != null)
                {
                    Api = deviceIdNode.InnerText;
                }
                deviceIdNode = node.SelectSingleNode("Product");
                if (deviceIdNode != null)
                {
                    Product = deviceIdNode.InnerText;
                }
            }
        }

        public void Close()
        {
            BioBErrorCode retCode;
            NativeCloseApiDelegate(out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public BioBaseApiProperties ApiProperties
        {
            get
            {
                BioBErrorCode retCode;

                IntPtr ptr = IntPtr.Zero;
                string strXml = string.Empty;

                ptr = NativeGetAPIPropertiesDelegate(out retCode);

                if (retCode != BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);

                try
                {
                    strXml = Marshal.PtrToStringAnsi((IntPtr)ptr);
                }
                catch (ArgumentNullException ex)
                {
                    throw new BioBaseException("GetDeviceInfo not able to Marshal XML data", ex);
                }
                finally
                {
                    NativeFreeDelegate(ptr, out retCode);

                    if (retCode != BioBErrorCode.BIOB_SUCCESS)
                        throw new BioBaseException(retCode);
                }

                return BioBaseXmlParsers.ParseApiPropertiesXml(strXml);
            }
        }

        public int GetDeviceCount()
        {
            BioBErrorCode retCode;
            int count;
            count = NativeGetDeviceCountDelegate(out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            return count;
        }

        public BioBaseDeviceInfo[] GetDevicesInfo()
        {
            BioBErrorCode retCode;
            IntPtr ptr = IntPtr.Zero;

            ptr = NativeGetDevicesInfoDelegate(out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            BioBaseDeviceInfo[] deviceInfo;
            try
            {
                string xmlString = Marshal.PtrToStringAnsi((IntPtr)ptr);
                deviceInfo = BioBaseXmlParsers.ParseDeviceInfoXml(ref xmlString);
            }
            catch (ArgumentNullException ex)
            {
                throw new BioBaseException("GetDeviceInfo not able to Marshal XML data", ex);
            }
            finally
            {
                NativeFreeDelegate(ptr, out retCode);
                if (retCode != BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
            }
            return deviceInfo;
        }
              
        public void OpenDevice(string deviceId, bool reset)
        {
            lock (synchLock)
            {
                BioBErrorCode retCode;

                NativeOpenDeviceDelegate(deviceId, reset, out retCode);

                if (retCode > BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
                else if (retCode < BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
            }
        }

        public void CloseDevice(string deviceId, bool sendToStandby)
        {
            lock (synchLock)
            {
                BioBErrorCode retCode;

                if (IsDeviceOpen(deviceId) == true)
                {
                    NativeCloseDeviceDelegate(deviceId, sendToStandby, out retCode);

                    if (retCode == BioBErrorCode.BIOB_NOTINITIALIZED)
                        return;

                    if (retCode != BioBErrorCode.BIOB_SUCCESS)
                        throw new Exception();
                }
            }
        }

        public void RegisterCallback(BioBEvents evt, Delegate callback)
        {
            IntPtr fctPtr = IntPtr.Zero;
            if (callback != null)
            {
                fctPtr = Marshal.GetFunctionPointerForDelegate(callback);
            }
            BioBErrorCode retCode;
            NativeRegisterDeviceCallbackDelegate(null, ptrContext, evt, fctPtr, out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public void RegisterDeviceCallback(string deviceId, BioBEvents evt, Delegate callback)
        {
            IntPtr fctPtr = IntPtr.Zero;
            if (callback != null)
            {
                fctPtr = Marshal.GetFunctionPointerForDelegate(callback);
            }

            BioBErrorCode retCode;
            NativeRegisterDeviceCallbackDelegate(deviceId, ptrContext, evt, fctPtr, out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
            {
                string errmsg = string.Format("Error {0} BioB_RegisterDeviceCallback with event {1} and  delegate {2}", retCode, evt, fctPtr);
                throw new BioBaseException(errmsg);
            }
        }

        public BioBaseDevicePropertyDictionary GetProperties(string deviceId)
        {
            BioBErrorCode retCode;
            IntPtr ptr = IntPtr.Zero;

            ptr = NativeGetPropertiesDelegate(deviceId, out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            string XMLDeviceProperties = string.Empty;
            try
            {
                XMLDeviceProperties = Marshal.PtrToStringAnsi(ptr);
            }
            catch (ArgumentNullException ex)
            {
                throw new BioBaseException("GetProperties not able to Marshal XML data", ex);
            }
            finally
            {
                NativeFreeDelegate(ptr, out retCode);
                if (retCode != BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
            }
            return BioBaseXmlParsers.ParseDevicePropertiesXml(XMLDeviceProperties);
        }

        public string GetPropertiesBasic(string deviceId)
        {
            BioBErrorCode retCode;
            IntPtr ptr = IntPtr.Zero;

            NativeGetPropertiesDelegate(deviceId, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            string XMLDeviceProperties = string.Empty;
            try
            {
                XMLDeviceProperties = Marshal.PtrToStringAnsi((IntPtr)ptr);
            }
            catch (ArgumentNullException ex)
            {
                throw new BioBaseException("GetProperties not able to Marshal XML data", ex);
            }
            finally
            {
                NativeFreeDelegate(ptr, out retCode);
                if (retCode != BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
            }
            return XMLDeviceProperties;
        }

        public string GetProperty(string deviceId, string name)
        {
            BioBErrorCode retCode;
            IntPtr ptr = IntPtr.Zero;
            ptr = NativeGetPropertyDelegate(deviceId, name, out retCode);

            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);

            string DeviceProperty = string.Empty;
            try
            {
                DeviceProperty = Marshal.PtrToStringAnsi((IntPtr)ptr);
            }
            catch (ArgumentNullException ex)
            {
                throw new BioBaseException("GetProperty not able to Marshal XML data", ex);
            }
            finally
            {
                NativeFreeDelegate(ptr, out retCode);
                if (retCode != BioBErrorCode.BIOB_SUCCESS)
                    throw new BioBaseException(retCode);
            }
            return DeviceProperty;
        }

        public void SetProperty(string deviceId, string name, string value)
        {
            BioBErrorCode retCode;
            NativeSetPropertyDelegate(deviceId, name, value, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public void BeginAcquisitionProcess(string deviceId, string posType, string impType)
        {
            BioBErrorCode retCode;
            NativeBeginAcquisitionProcessDelegate(deviceId, posType, impType, out retCode);
            if (retCode > BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
            else if (retCode < BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public void RequestAcquisitionOverride(string deviceId)
        {
            BioBErrorCode retCode;
            NativeRequestAcquisitionOverrideDelegate(deviceId, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public bool IsDeviceAcquiring(string deviceId)
        {
            BioBErrorCode retCode;
            bool isAcquiring = NativeIsDeviceAcquiringDelegate(deviceId, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
            return isAcquiring;
        }

        public bool IsDeviceOpen(string deviceId)
        {
            BioBErrorCode retCode;
            bool isOpen = NativeIsDeviceOpenedDelegate(deviceId, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                isOpen = false;
            return isOpen;
        }

        public bool IsDeviceReady(string deviceId)
        {
            BioBErrorCode retCode;
            bool isReady = NativeIsDeviceReadyDelegate(deviceId, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                isReady = false;
            return isReady;
        }

        public void CancelAcquisition(string deviceId)
        {
            BioBErrorCode retCode;
            NativeCancelAcquisitionDelegate(deviceId, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public void SetOutputData(string deviceId, BioBSetOutputData data)
        {
            BioBErrorCode retCode;
            NativeSetOutputDataDelegate(deviceId, ref data, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public void AdjustAcquisitionProcess(string deviceId, string type, string value)
        {
            BioBErrorCode retCode;
            NativeAdjustAcquisitionProcessDelegate(deviceId, type, value, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        public void SetVisualizationWindow(string deviceId, IntPtr window, string visualizer, BioBOsType osType)
        {
            BioBErrorCode retCode;
            NativeSetVisualizationWindowDelegate(deviceId, window, visualizer, osType, out retCode);
            if (retCode != BioBErrorCode.BIOB_SUCCESS)
                throw new BioBaseException(retCode);
        }

        ~LseBioBaseInterop()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

    }
}
