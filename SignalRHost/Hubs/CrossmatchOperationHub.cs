using Crossmatch;
using Crossmatch.LSE;
using EOSDigital.API;
using EOSDigital.SDK;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRHost.Models;
using SignalRHost.Utilities;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRHost.Hubs
{
    public class CrossmatchOperationHub : Hub
    {
        private static string deviceType;
        //crossmatch lscan
        ManualResetEvent lscanWaitHandle = new ManualResetEvent(false);
        LseBioBaseApi biobApi = null;
        IBioBaseDevice biobDevice;
        private static int initProgress;

        private readonly ILogger<CameraOperationHub> _logger;

        public CrossmatchOperationHub(ILogger<CameraOperationHub> logger)
        {
            _logger = logger;
        }
        ~CrossmatchOperationHub()
        {
            lscanWaitHandle.Reset();
            biobDevice?.Dispose();
            biobApi.Dispose();
        }
        public override Task OnConnectedAsync()
        {
            return Task.Run(() =>
            {
                Console.WriteLine(">>>>>>>>>> in OnConnectedAsync");
                
            });
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(">>>>>>>>>> in OnDisconnectedAsync");
                try
                {
                    lscanWaitHandle.Reset();
                    biobDevice?.Dispose();
                    biobApi.Dispose();
                }
                catch (Exception e)
                {
                    LogUtitlity.LogException(_logger, e);
                }
            });
        }
        [HubMethodName("startCapturing")]
        public async Task StartCapturing(CapturingInfo capturingInfo)
        {
            deviceType = capturingInfo.DeviceType;
            await Task.Run(() =>
            {
                try
                    {
                        if (InitializeDevice(capturingInfo.CaptureType, "FingerprintFlat", capturingInfo.AutoCapture))
                        {
                            //SendInfoImageForLscan();
                            Thread.Sleep(1000);
                            biobDevice.BeginAcquisitionProcess();
                            lscanWaitHandle.WaitOne(2000);
                        }
                        else
                        {
                            lscanWaitHandle.Set();
                            _logger.LogInformation("Error while initializing device");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }

                });
        }

        [HubMethodName("stopCapturing")]
        public async Task StopCapturing()
        {
            await Task.Run(() =>
            {
                try
                {
                    if (deviceType == "LScan")
                    {
                        biobDevice.CancelAcquisition();
                        lscanWaitHandle.Set();
                    }
                  
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            });
        }

        [HubMethodName("capture")]
        public async Task Capture()
        {
            await Task.Run(() =>
            {
                try
                {
                    //SendCapImageForLscan();
                    biobDevice.RequestAcquisitionOverride();
                    biobDevice.CancelAcquisition();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            });
        }

        #region lscan

        private bool InitializeDevice(string positionType, string impressionType, bool autoCapture)
        {
            var isDeviceInitialized = false;

            try
            {
                biobApi = new LseBioBaseApi();
                biobApi.Open();

                var devicesInfo = biobApi.ConnectedDevices;

                biobApi.InitProgressChanged += BiobApi_InitProgressChanged;

                biobApi.OpenDevice(devicesInfo[0], out biobDevice);

                do
                {
                    Thread.Sleep(500);
                }
                while (initProgress != 100);

                if (biobDevice != null)
                {
                    biobDevice.Preview += BiobDevice_Preview;
                    biobDevice.AcquisitionStart += BiobDevice_AcquisitionStart;
                    biobDevice.AcquisitionComplete += BiobDevice_AcquisitionComplete;
                    biobDevice.DataAvailable += BiobDevice_DataAvailable;
                    //biobDevice.ObjectQuality += BiobDevice_Quality;
                    
                    if (autoCapture)
                        biobDevice.SetProperty(BioBaseConstants.DEV_PROP_AUTOCAPTURE_ON, BioBaseConstants.DEV_PROP_TRUE);
                    else
                        biobDevice.SetProperty(BioBaseConstants.DEV_PROP_AUTOCAPTURE_ON, BioBaseConstants.DEV_PROP_FALSE);

                    biobDevice.SetProperty(BioBaseConstants.DEV_PROP_AUTOCONTRAST_ON, BioBaseConstants.DEV_PROP_TRUE);

                    var spoofDetection = biobDevice.GetProperty(BioBaseConstants.DEV_PROP_DEVICE_SPOOF_DETECTION_SUPPORTED);

                    if (spoofDetection == "TRUE")
                        biobDevice.SetProperty(BioBaseConstants.DEV_PROP_SPOOF_DETECTION_ON, BioBaseConstants.DEV_PROP_TRUE);
                    else
                        biobDevice.SetProperty(BioBaseConstants.DEV_PROP_SPOOF_DETECTION_ON, BioBaseConstants.DEV_PROP_FALSE);

                    biobDevice.SetProperty(BioBaseConstants.DEV_PROP_AUTOCAPTURE_NUM_RQD_OBJECTS, "1");

                    biobDevice.SetProperty(BioBaseConstants.DEV_PROP_IMAGE_RESOLUTION, BioBaseConstants.DEV_PROP_RESOLUTION_500);

                    biobDevice.SetProperty(BioBaseConstants.DEV_PROP_ACTIVE_AREA, "0 0 0 0");

                    biobDevice.CurrentPosition = positionType;

                    biobDevice.CurrentImpression = impressionType;

                    biobDevice.SetVisualizationWindow(IntPtr.Zero, BioBaseConstants.DEV_ID_VIS_FINGER_WND, BioBOsType.BIOB_WIN32OS);

                    isDeviceInitialized = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return isDeviceInitialized;
        }

        private void BiobApi_InitProgressChanged(object sender, BioBaseInitProgressEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                initProgress = (int)e.ProgressValue;
                _logger.LogInformation($"Initializing.... {e.ProgressValue}");
            });
        }

        private void BiobDevice_Preview(object sender, BioBasePreviewEventArgs e)
        {
            try
            {
                var imageBytes = ImageUtitlity.ConvertBitmapToArray(e.ImageData);

                var imageStr = ImageUtitlity.ConvertImageToBase64String(imageBytes);

                var imageDto = new CapturedImage
                {
                    DeviceName = "Lscan",
                    Base64String = imageStr
                };

                Clients.All.SendAsync(Constant.LSCAN_STREAM, imageDto).Wait();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private void SendInfoImageForLscan()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;
            var imagePath = Path.Combine(dirPath, "images/place.png");
            var bmp = new Bitmap(imagePath);
            var imageBytes = ImageUtitlity.ConvertBitmapToArray(bmp);

            var imageStr = ImageUtitlity.ConvertImageToBase64String(imageBytes);

            var imageDto = new CapturedImage
            {
                DeviceName = "",
                Base64String = imageStr
            };

            Clients.All.SendAsync(Constant.LSCAN_IMAGE, imageDto).Wait();
        }

        private void BiobDevice_AcquisitionComplete(object sender, BioBaseAcquisitionCompleteEventArgs e)
        {
            _logger.LogInformation("Acquisition completed.");
        }

        private void BiobDevice_AcquisitionStart(object sender, BioBaseAcquisitionStartEventArgs e)
        {
            _logger.LogInformation("Acquisition Started.");
        }

        private void BiobDevice_DataAvailable(object sender, BioBaseDataAvailableEventArgs e)
        {
            try
            {
                var imageBytes = ImageUtitlity.ConvertBitmapToArray(e.ImageData);
                
                var imageStr = ImageUtitlity.ConvertImageToBase64String(imageBytes);

                var imageDto = new CapturedImage
                {
                    DeviceName = "",
                    Base64String = imageStr
                };
                Clients.All.SendAsync(Constant.LSCAN_IMAGE, imageDto).Wait();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
                lscanWaitHandle.Set();
            }
        }

      /*  private void BiobDevice_Quality(object sender, BioBaseObjectQualityEventArgs e)
        {
            try
            {
                Clients.All.SendAsync("sendLscanQuality", imageDto).Wait();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
                lscanWaitHandle.Set();
            }
        }
*/
        private void SendCapImageForLscan()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;
            var imagePath = Path.Combine(dirPath, "images/place.png");
            var bmp = new Bitmap(imagePath);
            var imageBytes = ImageUtitlity.ConvertBitmapToArray(bmp);

            var imageStr = ImageUtitlity.ConvertImageToBase64String(imageBytes);

            var imageDto = new CapturedImage
            {
                DeviceName = "",
                Base64String = imageStr
            };

            Clients.All.SendAsync(Constant.LSCAN_IMAGE, imageDto).Wait();
        }
        #endregion

    }
}
