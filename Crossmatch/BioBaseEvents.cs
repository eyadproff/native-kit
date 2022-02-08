using CmtFingerLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Crossmatch
{
    /// <summary>
    /// Event triggered when a preview image available. Note that this event is typically triggered at 10 to 30 times per second.
    /// <param name="deviceId">The device ID for this event</param>
    /// <param name="bioBaseData">Identifies data for the preview image.</param>
    /// </summary>
    public class BioBasePreviewEventArgs : EventArgs
    {
        public string DeviceID { get; private set; }
        public Bitmap ImageData { get; set; } 

        public BioBasePreviewEventArgs(string deviceId, IntPtr bioBaseData)
        {
            DeviceID = deviceId;

            // decode image from BioBData object - Marshal pointer and 
            BioBData imgData = (BioBData)Marshal.PtrToStructure(bioBaseData, typeof(BioBData));

            if (imgData.Buffer != IntPtr.Zero && imgData.BufferSize > 0)
            {
                if (imgData.FormatType == BioBDataFormat.BIOB_FIR)
                {
                    // make managed copy of BioBData
                    byte[] Buffer = new byte[imgData.BufferSize];
                    Marshal.Copy(imgData.Buffer, Buffer, 0, Buffer.Length);

                    // Decode ISO record
                    CmtFingerTranscoder finger = new CmtFingerTranscoder(Buffer);

                    // Get list of images in BioBData object
                    finger.GetView();       //finger.QueryView();

                    // Get bitmap
                    finger.GetImages();
                    ImageData = finger.imageData[0].Image;

                }
                else if (imgData.FormatType == BioBDataFormat.BIOB_BMP)
                {
                    byte[] bytes = new byte[imgData.BufferSize];
                    Marshal.Copy(imgData.Buffer, bytes, 0, bytes.Length);
                    System.IO.Stream s = new System.IO.MemoryStream(bytes);
                    ImageData = new Bitmap(s);
                }
            }
        }
        
    }

    /// <summary>
    /// Event triggered when the quality state of a detected object (finger on plate) changes during capture.
    /// <param name="deviceId">The device ID for this event</param>
    /// <param name="qualStateArray">array of values indicating the quality of a detected object.</param>
    /// <param name="qualStateCount">number of entries in the QualStateArray array.</param>
    /// </summary>
    public class BioBaseObjectQualityEventArgs : EventArgs
    {
        public BioBaseObjectQualityEventArgs(string deviceId, BioBObjectQualityState[] qualStateArray, Int32 qualStateCount)
        {
            DeviceID = deviceId;
            QualStateArray = qualStateArray;
            QualStateCount = qualStateCount;
        }
        public string DeviceID { get; private set; }
        public BioBObjectQualityState[] QualStateArray { get; private set; }
        public Int32 QualStateCount { get; private set; }
    }

    /// <summary>
    /// Biometric object count (\ref BIOB_OBJECT_COUNT), indicating the status of the number
    /// of sub-objects segments that have been found. 
    /// For example, if configured for a slap with 4 finger but only 3 are detected,
    /// the objectCountState would be set to \ref BIOB_TOO_FEW_OBJECTS.
    /// <param name="pDevId">The device ID for this event</param>
    /// <param name="objectCountState">  enum indicating if the count is acceptable or not.</param>
    /// </summary>
    public class BioBaseObjectCountEventArgs : EventArgs
    {
        public BioBaseObjectCountEventArgs(string deviceId, BioBObjectCountState objectCountState)
        {
            DeviceID = deviceId;
            ObjectCountState = objectCountState;
        }
        public string DeviceID { get; private set; }
        public BioBObjectCountState ObjectCountState { get; private set; }
    }

    /// <summary>
    /// This callback corresponds to a user input on the device (\ref BIOB_SCANNER_USERINPUT). 
    /// This is for biometric devices that have user inputs such as a button. 
    /// When the operator presses the button, the event would fire.
    /// <param name="pDevId">The device ID for this event</param>
    /// <param name="pressedKeys">pointer to char that contains the button input status.</param>
    /// </summary>
    public class BioBaseUserInputEventArgs : EventArgs
    {
        public BioBaseUserInputEventArgs(string deviceId, string pressedKeys)
        {
            DeviceID = deviceId;
            PressedKeys = pressedKeys;
        }
        public string DeviceID { get; private set; }
        public string PressedKeys { get; private set; }
    }

    /// <summary>
    /// Event triggered when output to the biometric device is acknowledged
    /// <param name="deviceId">The device ID for this event</param>
    /// <param name="setOutputData">Acknowledgement data from device.</param>
    /// </summary>
    public class BioBaseUserOutputEventArgs : EventArgs
    {
        public BioBaseUserOutputEventArgs(string deviceId, IntPtr setOutputData)
        {
            DeviceID = deviceId;

            // decode image from BioBSetOutputData object - Marshal pointer and 
            BioBSetOutputData OutputData = (BioBSetOutputData)Marshal.PtrToStructure(setOutputData, typeof(BioBSetOutputData));
            byte[] bytes = new byte[OutputData.BufferSize];
            Marshal.Copy(OutputData.Buffer, bytes, 0, bytes.Length);
            SetOutputData = bytes;
            FormatType = OutputData.FormatType;
            TransactionID = OutputData.TransactionID;
        }
        public string DeviceID { get; private set; }
        public byte[] SetOutputData { get; private set; }
        public BioBOutputDataFormat FormatType { get; private set; }
        public Int32 TransactionID { get; private set; }
    }


    /// <summary>
    /// Event triggered when the device is starting the acquisition.
    /// <param name="deviceId">The device ID for this event</param>
    /// </summary>
    public class BioBaseAcquisitionStartEventArgs : EventArgs
    {
        public BioBaseAcquisitionStartEventArgs(string deviceId)
        {
            DeviceID = deviceId;
        }
        public string DeviceID { get; private set; }
    }


    /// <summary>
    /// Event triggered when acquisition complete on this device.
    /// <param name="deviceId">The device ID for this event</param>
    /// </summary>
    public class BioBaseAcquisitionCompleteEventArgs : EventArgs
    {
        public BioBaseAcquisitionCompleteEventArgs(string deviceId)
        {
            DeviceID = deviceId;
        }
        public string DeviceID { get; private set; }
    }


    /// <summary>
    /// Event triggered when the final acquired data is available.
    /// <param name="deviceId">The device ID for this event</param>
    /// <param name="dataStatus">The BioBReturnCode status of the final captured data. BIOB_SUCCESS is returned normally.</param>
    /// <param name="bioBaseData">Identifies data for the final acquired image.</param>
    /// <param name="detectedObjects">number of objects/fingers detected in final captured image.  Detected objects 
    ///  can be used to help segment images with more than one object (finger) </param>
    /// </summary>
    public class BioBaseDataAvailableEventArgs : EventArgs
    {
        public BioBaseDataAvailableEventArgs(string deviceId, Int32 dataStatus, IntPtr bioBaseData, Int32 detectedObjects)
        {
            DeviceID = deviceId;
            DataStatus = dataStatus;
            DetectedObjects = detectedObjects;

            // decode image from BioBData object - Marshal pointer and 
            BioBData imgData = (BioBData)Marshal.PtrToStructure(bioBaseData, typeof(BioBData));
            if (imgData.Buffer != IntPtr.Zero && imgData.BufferSize > 0)
            {
                if (imgData.FormatType == BioBDataFormat.BIOB_FIR)
                {
                    IsFinal = imgData.IsFinal;

                    // make managed copy of BioBData
                    byte[] Buffer = new byte[imgData.BufferSize];
                    Marshal.Copy(imgData.Buffer, Buffer, 0, Buffer.Length);

                    // Decode ISO record
                    CmtFingerTranscoder finger = new CmtFingerTranscoder(Buffer);

                    // Get list of all images in BioBData object
                    finger.GetView();       //finger.QueryView();

                    // Get first bitmap in FIR
                    //TODO: expand class to support multiple images in FIR
                    finger.GetImages();
                    ImageData = finger.imageData[0].Image;
                    
                }
                else if (imgData.FormatType == BioBDataFormat.BIOB_BMP)
                {
                    byte[] bytes = new byte[imgData.BufferSize];
                    Marshal.Copy(imgData.Buffer, bytes, 0, bytes.Length);
                    System.IO.Stream s = new System.IO.MemoryStream(bytes);
                    ImageData = new Bitmap(s);
                }
            }

            // Marshal the PAD (spoof) score if data is valid
            IsPADScoresValid = false;
            if (imgData.pStructName != IntPtr.Zero)
            {
                string structName = Marshal.PtrToStringAnsi(imgData.pStructName);
                if (structName == BioBaseConstants.DEV_PAD_STRUCT_NAME)
                {
                    if (imgData.pExtStruct != IntPtr.Zero)
                    {
                        BioBPADData PADinfo = new BioBPADData();
                        PADinfo = (BioBPADData)Marshal.PtrToStructure(imgData.pExtStruct, typeof(BioBPADData));

                        IsPADScoresValid = true;
                        PADScoreInvalid = PADinfo.PADScoreInvalid;
                        PADScoreMinimum = PADinfo.PADScoreMinimum;
                        PADScoreMaximum = PADinfo.PADScoreMaximum;
                        PADThresold = PADinfo.PADThresold;

                        //copy PADinfo.pPADScoreArray
                        double[] dst = null;
                        dst = new double[DetectedObjects];
                        Marshal.Copy(PADinfo.pPADScoreArray, dst, 0, dst.Length);
                        PADScore = new List<double>(dst);
                    }
                }
            }
        }
        public string DeviceID { get; private set; }
        public Int32 DataStatus { get; private set; }
        public Int32 DetectedObjects { get; private set; }
        public Bitmap ImageData { get; private set; }
        public Boolean IsFinal { get; private set; }

        public Boolean IsPADScoresValid { get; private set; }
        public double PADScoreInvalid { get; private set; }
        public double PADScoreMinimum { get; private set; }
        public double PADScoreMaximum { get; private set; }
        public double PADThresold { get; private set; }
        public List<double> PADScore { get; private set; }
    }


    /// <summary>
    /// Event triggered when the device have been disconnected.
    /// <param name="deviceId">The device ID for this event</param>
    /// </summary>
    public class BioBaseDisconnectEventArgs : EventArgs
    {
        public BioBaseDisconnectEventArgs(string deviceId)
        {
            DeviceID = deviceId;
        }
        public string DeviceID { get; private set; }
    }


    /// <summary>
    /// Event triggered when the device have been connected.
    /// <param name="deviceId">The device ID for this event</param>
    /// </summary>
    public class BioBaseConnectEventArgs : EventArgs
    {
        public string DeviceID { get; private set; }

        public BioBaseConnectEventArgs(string deviceId)
        {
            DeviceID = deviceId;
        }
    }
    
    
    /// <summary>
    /// Event triggered while the device is being initialized.
    /// <param name="deviceId">The device ID for this event</param>
    /// <param name="initType">Identifies state of device initialization.</param>
    /// <param name="progressValue">Identifies progress of device initialization.</param>
    /// </summary>
    public class BioBaseInitProgressEventArgs : EventArgs
    {
        public BioBaseInitProgressEventArgs(string deviceId, BioBInitializationType initType, float progressValue)
        {
            DeviceID = deviceId;
            InitType = initType;
            ProgressValue = progressValue;
        }
        public string DeviceID { get; private set; }
        public BioBInitializationType InitType { get; private set; }
        public float ProgressValue { get; private set; }
    }


    /// <summary>
    /// Event triggered when object detected on teh platen
    /// <param name="deviceId">The device ID for this event</param>
    /// <param name="detectionAreaState">Identifies state of object on the "detection surface" before starting aquisition.</param>
    /// </summary>
    public class BioBaseDetectObjectEventArgs : EventArgs
    {
        public BioBaseDetectObjectEventArgs(string deviceId, BioBDeviceDectionAreaState detectionAreaState)
        {
            DeviceID = deviceId;
            DetectionAreaState = detectionAreaState;
        }
        public string DeviceID { get; private set; }
        public BioBDeviceDectionAreaState DetectionAreaState { get; private set; }
    }


    /// <summary>
    /// Event triggered when a device is attached or removed from the computer
    /// <param name="deviceCount">number of supported devices attached to the computer</param>
    /// </summary>
    public class BioBaseDeviceCountEventArgs : EventArgs
    {
        public BioBaseDeviceCountEventArgs(Int32 deviceCount)
        {
            DeviceCount = deviceCount;
        }
        public Int32 DeviceCount { get; private set; }
    }
}
