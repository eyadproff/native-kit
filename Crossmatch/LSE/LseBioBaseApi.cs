using System;
using System.Threading;

namespace Crossmatch.LSE
{
    public class LseBioBaseApi : IBioBase
    {
        //events     
        private delegate void DeviceCountChangedHandler(int deviceCount, IntPtr context);

        private delegate void InitProgressHandler(string deviceId, IntPtr context, BioBInitializationType initType, float progress);

        public event EventHandler<BioBaseDeviceCountEventArgs> DeviceCountChanged;

        public event EventHandler<BioBaseInitProgressEventArgs> InitProgressChanged;

        //properties

        protected LseBioBaseInterop lseInterop = null;

        public LseBioBaseApi()
        {
            lseInterop = new LseDeviceSdk();
        }

        public BioBaseDeviceInfo[] ConnectedDevices => lseInterop.GetDevicesInfo();

        public int NumberOfDevices => lseInterop.GetDeviceCount();

        public void Open()
        {
            try
            {
                var deviceCountChangedHandler = new DeviceCountChangedHandler(OnDeviceCountChanged);

                Thread.Sleep(500);

                lseInterop.RegisterCallback(BioBEvents.BIOB_DEVICE_COUNT_CHANGED, deviceCountChangedHandler);

                lseInterop.Open();
            }
            catch (Exception ex)
            {
                throw new BioBaseException(ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                if (lseInterop != null)
                {
                    lseInterop.RegisterCallback(BioBEvents.BIOB_DEVICE_COUNT_CHANGED, null);
                    lseInterop.Close();
                }
            }
            catch (Exception ex)
            {
                throw new BioBaseException(ex.Message);
            }
        }

        public void OpenDevice(BioBaseDeviceInfo dev, out IBioBaseDevice device)
        {
            try
            {
                if (dev != null)
                {
                    var lseDevice = new LseBioBaseDevice(dev, lseInterop);
                    device = lseDevice;

                    var initProgressHandler = new InitProgressHandler(OnInitProgress);
                    lseInterop.RegisterDeviceCallback(dev.DeviceId, BioBEvents.BIOB_INIT_PROGRESS, initProgressHandler);

                    lseDevice.Initialize();
                }
                else
                    device = null;
            }
            catch (Exception ex)
            {
                device = null;
                throw new BioBaseException(ex.Message);
            }
        }

        protected virtual void OnDeviceCountChanged(int deviceCount, IntPtr pReserved)
        {
            try
            {
                if (DeviceCountChanged == null)
                {
                    return;
                }
                BioBaseDeviceCountEventArgs args = new BioBaseDeviceCountEventArgs(deviceCount);
                DeviceCountChanged.Invoke(this, args);
            }
            catch (Exception ex)
            {
                throw new BioBaseException(ex.Message);
            }
        }

        protected virtual void OnInitProgress(string deviceId, IntPtr pContext, BioBInitializationType scantype, float progressValue)
        {
            try
            {
                if (InitProgressChanged != null)
                {
                    BioBaseInitProgressEventArgs args = new BioBaseInitProgressEventArgs(deviceId, scantype, (progressValue * 100F));
                    InitProgressChanged.Invoke(this, args);
                }
            }
            catch (Exception ex)
            {
                throw new BioBaseException(ex.Message);
            }
        }

        ~LseBioBaseApi()
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
            try
            {
                lseInterop.RegisterCallback(BioBEvents.BIOB_DEVICE_COUNT_CHANGED, null);
                if (disposing)
                {
                    lseInterop.Close();
                    DeviceCountChanged = delegate { };
                    InitProgressChanged = delegate { };
                }
            }
            catch (DllNotFoundException ex)
            {
                throw new BioBaseException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BioBaseException(ex.Message);
            }
        }

    }
}
