using System;

namespace Crossmatch
{
    public interface IBioBase: IDisposable
    {
        event EventHandler<BioBaseDeviceCountEventArgs> DeviceCountChanged;

        event EventHandler<BioBaseInitProgressEventArgs> InitProgressChanged;
             
        BioBaseDeviceInfo[] ConnectedDevices { get; }
               
        int NumberOfDevices { get; }

        void OpenDevice(BioBaseDeviceInfo dev, out IBioBaseDevice Device);
           
    }
}
