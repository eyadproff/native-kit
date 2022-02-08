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
    public class CameraOperationHub : Hub
    {

        //EOS Canon
        ManualResetEvent canonWaitHandle = new ManualResetEvent(false);
        CanonAPI canonApi;
        Camera camera;

        private readonly ILogger<CameraOperationHub> _logger;

        public CameraOperationHub(ILogger<CameraOperationHub> logger)
        {
            _logger = logger;
        }

        void InitCameraAndSDK() {
            try
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> InitCameraAndSDK...");
                canonApi = new CanonAPI();
                camera = canonApi.GetCameraList()[0];
            }
            catch (Exception e) {
                LogUtitlity.LogException(_logger, e);
            }
        }
        
        void RegisterCameraEvents() {
            try
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> RegisterCameraEvents...");
                camera.LiveViewUpdated += Camera_LiveViewUpdated;
                camera.StateChanged += Camera_StateChanged;
                camera.DownloadReady += Camera_DownloadReady;
            }
            catch (Exception e) {
                LogUtitlity.LogException(_logger, e);
            }
        }

        ~CameraOperationHub() {
            try {
                camera?.CloseSession();
                camera?.Dispose();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> in Destructor...");
            }
            catch (Exception e)
            {
                LogUtitlity.LogException(_logger, e);
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
                    camera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                    camera.SetCapacity(4096, int.MaxValue);
                    camera.StartLiveView();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($">>>>>>>>>>>> in StartCapturing......... ::ex::{ex.StackTrace}");
                    LogUtitlity.LogException(_logger, ex);
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
                }
                catch (Exception ex)
                {
                    LogUtitlity.LogException(_logger, ex);
                }
            });
        }

        [HubMethodName("capture")]
        public async Task Capture()
        {
            
           Task.Run(() =>
            {
                Console.WriteLine("capture");
                try
                {
                    if (camera.SessionOpen)
                    {
                        camera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                        camera.SetCapacity(4096, int.MaxValue);
                        camera.TakePhoto();
                    }
                    else
                    {
                        //TODO: handle capture without live stream session is closed 
                       
                    }


                }
                catch (Exception ex)
                {
                    LogUtitlity.LogException(_logger, ex);
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
                await Clients.All.SendAsync("sendCanonStreamImage", imageDto);
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

                    Clients.All.SendAsync("sendCanonCapImage", imageDto).Wait();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            finally
            {
                canonWaitHandle.Set();
            }
        }

        #endregion
        public override Task OnConnectedAsync() {
           return Task.Run(() =>
            {
                Console.WriteLine(">>>>>>>>>> in OnConnectedAsync");
                InitCameraAndSDK();
                RegisterCameraEvents();
            });
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(">>>>>>>>>> in OnDisconnectedAsync");
                try
                {
                    camera?.CloseSession();
                    camera?.Dispose();
                }
                catch (Exception e)
                {
                    LogUtitlity.LogException(_logger, e);
                }
            });
        }
    }


}
