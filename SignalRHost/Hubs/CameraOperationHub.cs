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
using System.Transactions;

namespace SignalRHost.Hubs
{
    public class CameraOperationHub : Hub
    {

        //EOS Canon
        //ManualResetEvent canonWaitHandle = new ManualResetEvent(false);
        CanonAPI canonApi;
        Camera camera;

        private readonly ILogger<CameraOperationHub> _logger;

        public CameraOperationHub(ILogger<CameraOperationHub> logger)
        {
            _logger = logger;
        }

        public bool InitCameraAndSDK()
        {
            bool result = false;
            try
            {
                canonApi = new CanonAPI();

                if (canonApi.GetCameraList().Count == 1)
                {
                    camera = canonApi.GetCameraList()[0];
                    result = true;
                }
                else
                {
                    Clients.All.SendAsync(Constant.NK_STATUS, Constant.CANON_CASE_ONE);
                }
            }
            catch (Exception e) {
                LogUtitlity.LogException(_logger, e);
                Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(e));
            }

            return result;
        }
        
        void RegisterCameraEvents() {
            try
            {
                camera.LiveViewUpdated += Camera_LiveViewUpdated;
                camera.StateChanged += Camera_StateChanged;
                camera.DownloadReady += Camera_DownloadReady;
                camera.CameraHasShutdown += Camera_Disconnected;
            }
            catch (Exception e) {
                LogUtitlity.LogException(_logger, e);
                
                Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(e));
            }
        }

        ~CameraOperationHub() {
            try {
                camera?.CloseSession();
                camera?.Dispose();
            }
            catch (Exception e)
            {
                LogUtitlity.LogException(_logger, e);
                
                Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(e));
            }

        }

        [HubMethodName("startCapturing")]
        public async Task StartCapturing(CapturingInfo capturingInfo)
        {
            await Task.Run(() =>
            {
                try
                {
                    camera.OpenSession();
                    
                    // Added settings to override biokit settings (after biokit connects to the camera, live view doesnt work anymore..)
                    camera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Camera);
                    camera.SetSetting(PropertyID.Evf_AFMode, (int)EvfAFMode.LiveFace);
                    camera.SetSetting(PropertyID.Evf_Mode, 1); // 1- enable live view, 0- disable live view
                    camera.SetSetting(PropertyID.Evf_OutputDevice, (int)EvfOutputDevice.PC);
                    camera.SetSetting(PropertyID.ImageQuality, (int)ImageQuality.Small1JpegFine);

                    
                    
                    camera.SetCapacity(4096, int.MaxValue);
                    
                    camera.StartLiveView();

                    Clients.All.SendAsync(Constant.NK_STATUS, "Start live view");
                }
                catch (Exception ex)
                {
                    LogUtitlity.LogException(_logger, ex);
                    
                    Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(ex));

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
                    camera.StopLiveView();
                    Clients.All.SendAsync(Constant.NK_STATUS, "Stop live view");
                }
                catch (Exception ex)
                {
                    LogUtitlity.LogException(_logger, ex);
                    Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(ex));
                }
            });
        }

        [HubMethodName("capture")]
        public async Task Capture()
        {
            
           Task.Run(() =>
            {
                //Console.WriteLine("capture");
                try
                {
                    if (camera.SessionOpen)
                    {
                        camera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                        camera.SetCapacity(4096, int.MaxValue);
                        camera.TakePhoto();
                        //TODO:Test this if af fails 
                        Clients.All.SendAsync(Constant.NK_STATUS, "Captured photo");
                    }
                    else
                    {
                        Clients.All.SendAsync(Constant.NK_STATUS, Constant.CANON_CASE_TWO);
                    }
                }
                catch (Exception ex)
                {
                    LogUtitlity.LogException(_logger, ex);
                    Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(ex));
                }
            });
        }

        #region Canon EOS

        private void Camera_LiveViewUpdated(Camera sender, Stream stream)
        {
            try
            {
                SendCanonLiveViewStream(new Bitmap(stream));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private async Task SendCanonLiveViewStream(Bitmap image)
        {
            var imageBytes = ImageUtitlity.ConvertBitmapToArray(image);

            var imageStr = ImageUtitlity.ConvertImageToBase64String(imageBytes);

            var imageDto = new CapturedImage
            {
                DeviceName = "",
                Base64String = imageStr
            };
            
            try
            {
                await Clients.All.SendAsync(Constant.CANON_STREAM, imageDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private void Camera_StateChanged(Camera sender, StateEventID eventID, int parameter)
        {
            try
            {
                if (eventID == StateEventID.Shutdown)
                    camera.CloseSession();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private void Camera_DownloadReady(Camera sender, DownloadInfo Info)
        {
            try
            {
                var stream = sender.DownloadFile(Info);

                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();

                    var imageStr = ImageUtitlity.ConvertImageToBase64String(imageBytes);

                    var imageDto = new CapturedImage
                    {
                        DeviceName = "Canon EOS 1200D Digital Camera",
                        Base64String = imageStr
                    };

                    Clients.All.SendAsync(Constant.CANON_IMAGE, imageDto).Wait();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        
        private void Camera_Disconnected(Camera sender)
        {
            try
            {
                Clients.All.SendAsync(Constant.NK_STATUS, Constant.CANON_CASE_ONE);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        #endregion
        public override Task OnConnectedAsync() {
           return Task.Run(() =>
            {
                if (InitCameraAndSDK()) {
                    RegisterCameraEvents();
                }
            });
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return Task.Run(() =>
            {
                //Console.WriteLine(">>>>>>>>>> in OnDisconnectedAsync");
                try
                {
                    camera?.CloseSession();
                    camera?.Dispose();
                }
                catch (Exception e)
                {
                    LogUtitlity.LogException(_logger, e);
                    Clients.All.SendAsync(Constant.NK_STATUS, HubClientNotifier.GetExceptionClientNotification(e));
                }
            });
        }
    }


}
