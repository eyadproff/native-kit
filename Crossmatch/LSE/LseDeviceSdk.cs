using System;
using System.Runtime.InteropServices;

namespace Crossmatch.LSE
{
    public  class LseDeviceSdk: LseBioBaseInterop
    {
        private const string dllName = @"C:\Nativekit\NativeApp\bin\Release\lib\crossmatch\LScanEssentialsBioBase4.dll";//@"C:\NativeKit\lib\crossmatch\LScanEssentialsBioBase4.dll";//
        public LseDeviceSdk()
        {
            NativeOpenApiDelegate = NativeOpen;
            NativeCloseApiDelegate = NativeClose;
            NativeGetAPIPropertiesDelegate = NativeGetAPIProperties;
            NativeGetDeviceCountDelegate = NativeGetDeviceCount;
            NativeGetDevicesInfoDelegate = NativeGetDevicesInfo;
            NativeOpenDeviceDelegate = NativeOpenDevice;
            NativeCloseDeviceDelegate = NativeCloseDevice;
            NativeRegisterDeviceCallbackDelegate = NativeRegisterDeviceCallback;
            NativeGetPropertiesDelegate = NativeGetProperties;
            NativeSetPropertiesDelegate = NativeSetProperties;
            NativeGetPropertyDelegate = NativeGetProperty;
            NativeSetPropertyDelegate = NativeSetProperty;
            NativeCancelAcquisitionDelegate = NativeCancelAcquisition;
            NativeBeginAcquisitionProcessDelegate = NativeBeginAcquisitionProcess;
            NativeRequestAcquisitionOverrideDelegate = NativeRequestAcquisitionOverride;
            NativeFreeDelegate = NativeFree;
            NativeIsDeviceAcquiringDelegate = NativeIsDeviceAcquiring;
            NativeIsDeviceOpenedDelegate = NativeIsDeviceOpened;
            NativeIsDeviceReadyDelegate = NativeIsDeviceReady;
            NativeSetOutputDataDelegate = NativeSetOutputData;
            NativeAdjustAcquisitionProcessDelegate = NativeAdjustAcquisitionProcess;
            NativeSetVisualizationWindowDelegate = NativeSetVisualizationWindow;
            
            
        }


        /// <summary>
        ///  Open performs a count of all connected biometric devices, and obtains the 
        ///  serial number, the model number, and the interface type (e.g.USB, Firewire)
        ///  for the device.Open does this for every connected device.Its primary
        ///  job is to populate the internal "matrix" of Biometric info used by BioBase, in
        ///  order to keep track of Biometric devices.Each device is assigned a Device Instance
        ///  ID.This is used by BioBase to uniquely identify devices.
        /// </summary>
        /// <returns>
        ///  BioBErrorCode standard BioBase enum (BIOB_SUCCESS 0, BIOB_FAILURE -1, errors < 0, warnings > 0)
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_Open", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeOpen(out BioBErrorCode retCode);


        /// <summary>
        /// Close deletes all information from the internal matrix of Biometric devices.
        /// </summary>
        /// <returns>
        /// BioBErrorCode standard BioBase enum (BIOB_SUCCESS 0, BIOB_FAILURE -1, errors < 0, warnings > 0)
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_Close", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeClose(out BioBErrorCode retCode);


        /// <summary>
        /// This function returns a properly formatted UTF-8 character string.
        /// The parameter can be set to NULL and the pointer will be deallocated by BioB_FreeXML().
        /// The xml will identify the product version and file version of ALL the APIs used.
        ///   For example if LSE is used, and USBSDK is used, product version, and file version information
        ///   for each API is returned.
        /// </summary>
        /// <param name="ptrXml">
        /// **WcXml double pointer to char, set to NULL, allocated internally, deallocated
        /// by BioB_Free function.Contains properly formed XML.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_GetAPIProperties", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern IntPtr NativeGetAPIProperties(out BioBErrorCode retCode);


        /// <summary>
        /// This function simply returns the count of Biometric devices connected to the host computer. 
        ///This function does not require a specific device to be opened(BioB_OpenDevice)
        ///  but it does require BioB_Open to be called.
        /// </summary>
        /// <param name="devices">*devices count of total Biometric devices.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_GetDeviceCount", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern Int32 NativeGetDeviceCount(out BioBErrorCode retCode);


        /// <summary>
        /// This function returns, in a UTF-8 XML properly formatted string, the serial numbers, 
        ///hardware interface, the dev ID, and one or multiple visualizers for each connected device.
        ///The devices do not need to be opened(BioB_OpenDevice) for this function to perform its duty.
        /// </summary>
        /// <param name="ptrXml">
        /// **WcXml double pointer to char, set to NULL, allocated internally, deallocated
        ///by BioB_Free function.Contains properly formed XML.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_GetDevicesInfo", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern IntPtr NativeGetDevicesInfo(out BioBErrorCode retCode);


        /// <summary>
        /// This function performs the initialization on a specific device, identified by deviceId.
        /// deviceId is obtained by calling GetDevicesInfo. deviceId is the model name, serial number
        /// combination that uniquely identifies the device.
        /// Note that a single physical device may support multiple logical devices, such that only
        /// one of the logical devices is functional at a time.  If an application tries to acquire
        /// a subsequent logical device, then that device would return a BIOB_DEVICE_BUSY.
        /// Applications can register for the DeviceAvailable callback instead of polling 
        /// OpenDevice for success.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="reset">
        /// when set to TRUE, a device reset is performed prior to initialization.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_OpenDevice", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeOpenDevice(string deviceId, [MarshalAs(UnmanagedType.Bool)] bool reset, out BioBErrorCode retCode);


        /// <summary>
        /// This function performs the uninitialize for a specific device.
        /// If the device wasn't opened, a BIOB_DEVICE_ALREADY_CLOSED warning will be returned.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="sendToStandby">
        /// when set to TRUE, device will be sent into standby mode.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_CloseDevice", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeCloseDevice(string deviceId, [MarshalAs(UnmanagedType.Bool)] bool sendToStandby, out BioBErrorCode retCode);


        /// <summary>
        /// This function registers a BioBase call back. All callbacks are named by enum BioBEvents.
        /// The enum name matches that BioB_CallBk function name, therefore, when the BioBEvents is passed in, 
        ///  it must be prefixed(BioBEvents::). The ptrContext is usually the "this" pointer of the class that will
        ///  receive the callback.This is usually shown in the C++ demo applications.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="pContext">
        /// pointer usually used to pass the "this" pointer, since the callbacks are
        /// implemented as static functions.This enables the user to update a GUI.
        /// If this pointer is NULL the callback will still fire. Obviously, care
        /// should be taken when assigning this void
        /// </param>
        /// <param name="bioEvent">
        /// Event enum that identifies the callback prefix with (BioBEvents::).
        /// </param>
        /// <param name="pCallback">
        /// one of the callbacks with the function prototype defined by the typedefs in the BioB_defs.h file.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_RegisterDeviceCallback", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeRegisterDeviceCallback(string deviceId, IntPtr ptrContext, BioBEvents events, IntPtr func, out BioBErrorCode retCode);


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_GetProperties", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern IntPtr NativeGetProperties(string deviceId, out BioBErrorCode error);


        /// <summary>
        /// This function is intended to set properties for the 
        /// device using a well formed XML input string.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="valueXml">
        /// well formed XML obeying the BioBase XML Schema.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_SetProperties", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeSetProperties(string deviceId, string xml, out BioBErrorCode retCode);


        /// <summary>
        /// This function is intended to obtain the value belonging to a certain property. 
        /// ptrXml is the returned string representing the value of that property.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="propName">
        /// text representing the property to get a value for. For a complete (XML)
        /// list of properties supported by a device, call BioB_GetDeviceProperties.
        /// There will soon be made available XML property schemas for certain devices as well.
        /// </param>
        /// <param name="ptrXml">
        /// string representation of the value returned.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_GetProperty", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern IntPtr NativeGetProperty(string deviceId, string propertyName, out BioBErrorCode retCode);


        /// <summary>
        /// this function's purpose is to set individual properties.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="propName">
        /// text representing the property to set a value for. For a complete (XML)
        /// list of properties supported by a device, call BioB_GetDeviceProperties.
        /// There will soon be made available XML property schemata for certain devices as well.
        /// </param>
        /// <param name="propValue">
        /// string representation of the value to set. see BioB_GetDeviceProperties
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_SetProperty", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeSetProperty(string deviceId, string propertyName, string value, out BioBErrorCode retCode);


        /// <summary>
        /// CancelAcqusition is valid during live mode when the device is capturing. Its purpose
        /// essentially is to abruptly end acquisition.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_CancelAcquisition", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeCancelAcquisition(string deviceId, out BioBErrorCode retCode);


        /// <summary>
        /// In addition to the pwDevID, this function accepts a Biometric modality (ModeTYpe).
        /// The reason this is necessary, is because the potential exists for compound biometric device.
        /// One example of this would be a biometric device that captures both Iris and Fingerprints.
        /// This function kicks off the acquisition, and if successful, initiates "live mode" for the scanner.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="bioBPositionType">
        /// PosType identifies the biometric "position".
        /// </param>
        /// <param name="bioBImpressionType">
        /// ImpType identifies the biometric "impression".
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_BeginAcquisitionProcess", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeBeginAcquisitionProcess(string deviceId, string posType, string impType, out BioBErrorCode retCode);


        /// <summary>
        /// This function allows the client of BioBase to manually capture a biometric sample during
        ///  "live mode", allowing the user to prematurely end the autocapture, and retrieve preview images.
        ///  This might happen due to the user examining preview images and selecting a button
        ///  or this might occur due to a client provided autocapture implementation.
        ///  This function must be called only if autocapture is not set using Biobase.
        ///  This function will result in a callback being fired(Acquisition Completed).
        ///  After the data is processed, the callback for data available  will be fired.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_RequestAcquisitionOverride", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeRequestAcquisitionOverride(string deviceId, out BioBErrorCode retCode);


        /// <summary>
        /// This function sets the "visualizer" or the windows for biometric image displays.
        /// The window handle is mapped to the standard one on Windows, for platform independence,       
        /// however, it is defined as a void* in the biob.h file.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="hWindow">
        /// window typically on windows operating systems, this is a HWND.
        /// </param>
        /// <param name="modalType">
        /// string representing the window type, this is obtained from the list of
        /// visualizers when BioB_GetDevicesInfo is called.
        /// </param>
        /// <param name="osType">
        /// os enum of operating system window displaying image see BioB_GetDevicesInfo
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_SetVisualizationWindow", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        internal static extern void NativeSetVisualizationWindow(string deviceId, IntPtr window, string visualizer, BioBOsType osType, out BioBErrorCode retCode);


        /// <summary>
        /// This function will free the xml data allocated on the internal heap of the library.
        /// </summary>
        /// <param name="deviceId">
        /// pointer to buffer allocated for XML data.
        /// This is usually obtained by a call to BioB_GetDevicesInfo, 
        /// BioB_GetAPIProperties, BioB_GetDeviceProperties and BioB_GetProperty.
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_Free", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeFree(IntPtr pString, out BioBErrorCode retCode);


        /// <summary>
        /// This function determines if a device is Acquiring images. Acquiring happens in the time
        /// window between the times that callbacks AcquisitionStart and AcquisitionComplete fire.
        /// This device will return a boolean true if the device is "live", i.e.acquiring images.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="isLive">
        /// boolean indicating device is live (true).
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_IsDeviceAcquiring", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern bool NativeIsDeviceAcquiring(string deviceId, out BioBErrorCode retCode);


        /// <summary>
        /// This is an informational function used to determine if a device has been Opened.
        /// It is possible that BioB_OpenDevice could fail, or that the device could have
        ///  been physically disconnected from the computer.In which case, bOpen would be false.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="isOpen">
        /// boolean indicating device is open (true) or device closed (false).
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_IsDeviceOpened", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern bool NativeIsDeviceOpened(string deviceId, out BioBErrorCode retCode);


        /// <summary>
        /// This is an informational function used to determine if a device ready to be Opened.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="isReady">
        /// boolean indicating device is ready (true) or device closed (false).
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_IsDeviceReady", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern bool NativeIsDeviceReady(string deviceId, out BioBErrorCode retCode);


        /// <summary>
        /// This function is reserved for sending data down to the device, some biometric devices support this.
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="outputData">
        /// pointer to BioBSetOutputData that contains data that will be passed back to a device. see BioBSetOutputData
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_SetOutputData", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        protected static extern void NativeSetOutputData(string deviceId, ref BioBSetOutputData Data, out BioBErrorCode retCode);


        /// <summary>
        /// Perform adjustment of parameters useful for running acquisition process (e.g. contrast optimization).
        /// </summary>
        /// <param name="deviceId">
        /// device instance ID, consists of model name, and serial number.
        /// This is usually obtained by a call to BioB_GetDevicesInfo.
        /// </param>
        /// <param name="type">
        /// type of adjustment to execute, given as string
        /// </param>
        /// <param name="value">
        /// value for adjustment, given as string
        /// </param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Do not use code securit to achieve higher performance")]
        [DllImport(dllName, EntryPoint = "BioB_AdjustAcquisitionProcess", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        internal static extern void NativeAdjustAcquisitionProcess(string deviceId, string type, string value, out BioBErrorCode retCode);

    }
}
