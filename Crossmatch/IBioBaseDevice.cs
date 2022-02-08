using System;

namespace Crossmatch
{
    public interface IBioBaseDevice : IDisposable
    {  
        BioBaseDeviceInfo DeviceInfo { get; }

        BioBaseDevicePropertyDictionary Properties { get; }

        GuidanceType DeviceGuidanceType { get; }

        InputType DeviceInputType { get; }

        string CurrentPosition { get; set; }

        string CurrentImpression { get; set; }

        ActiveKeys CurrentActivetKey { get; set; }

        BioBObjectQualityState[] CurrentQualities { get; set; }
          
        bool IsDeviceReady();

        bool IsDeviceOpen();

        bool IsDeviceAcquiring();

        string GetBioBaseProperties();

        string GetProperty(string propertyName);

        void SetProperty(string propertyName, string value);
              
        void BeginAcquisitionProcess();

        void CancelAcquisition();

        void RequestAcquisitionOverride();

        void AdjustAcquisitionProcess(string type, string value);

        void SetOutputData(BioBSetOutputData outputData);

        void SetVisualizationWindow(IntPtr window, string visualizer, BioBOsType os);

        event EventHandler<BioBasePreviewEventArgs> Preview;

        event EventHandler<BioBaseAcquisitionStartEventArgs> AcquisitionStart;

        event EventHandler<BioBaseAcquisitionCompleteEventArgs> AcquisitionComplete;

        event EventHandler<BioBaseDataAvailableEventArgs> DataAvailable;

        event EventHandler<BioBaseObjectQualityEventArgs> ObjectQuality;

        event EventHandler<BioBaseObjectCountEventArgs> ObjectCount;

        event EventHandler<BioBaseUserInputEventArgs> ScannerUserInput;

        event EventHandler<BioBaseUserOutputEventArgs> ScannerUserOutput;

        event EventHandler<BioBaseDetectObjectEventArgs> DetectedObject;
            
    }
}
