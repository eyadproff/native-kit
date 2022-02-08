using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Crossmatch
{   

    /*!
   * ROI definition for detected biometric objects.
   * This is used by the Clbk_Preview() callback and structure BioBScene.
   */
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct BioBROI
    {
        Int32 X;          //< Detected object x-coordinate relative to the upper-left corner
        Int32 Y;          //< Detected object y-coordinate relative to the upper-left corner
        Int32 Width;      //< Image width
        Int32 Height;     //< Image height
    };

    /*!
   * Definitions for extended structure within structure BioBData.
   * This is used by the Clbk_Preview() callback.
   */
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct BioBScene
    {
        IntPtr Raster;               //< unsigned byte pointer to image data
        Int32  Width;                 //< Image width
        Int32  Height;                //< Image height
        Int32  SceneIndex;            //< Frame number
        Int32  NumDetected;           //< Number of BioBROIs within this BioBScene
        IntPtr BiometricObjects;     //< BioBROI pointer for the detected biometric objects
    };

    /*!
   * BioBData struct is used by
   * the Clbk_DataAvailable() and Clbk_Preview() callbacks.
   */
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct BioBData
    {
        public IntPtr Buffer;                       //< Pointer to data buffer
        public Int32 BufferSize;                    //< Size of data buffer in bytes
        public BioBDataFormat FormatType;           //< Biometric data Format type
        public bool IsFinal;                        //< Marks the image as finally processed. A value of "FALSE" disqualifies image for further processing. (e.g. interim or preprocessed result images)
        public IntPtr pExtStruct;                   //< Pointer to Extensible struct that may be used.
        public IntPtr pStructName;                  //< char pointer Identifier for the struct.
    };

    /*!
   * BioBSetOutputData struct is used by
   * the Clbk_UserOutput() callback and the BioB_SetOutputData() function.
   */
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct BioBSetOutputData
    {
        public IntPtr Buffer;                       //< Pointer to data buffer.
        public Int32 BufferSize;                    //< Size of data buffer in bytes.
        public BioBOutputDataFormat FormatType;     //< Type of data in Buffer.
        public IntPtr pExtStruct;                   //< Pointer to Extensible struct that may be used.
        public string pStructName;                  //< char pointer Identifier for the struct.
        public Int32 TransactionID;                 //< Unique ID set by application, sent to SetOutputData and returned Clbk_UserOutput.
    };

    /*!
  * PADData struct that defines the PAD (spoof) scores for each finger
  * This is used by the BClbk_DataAvailable() callback and is accessed via the BioBData.pExtStruct member.
  */
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct BioBPADData
    {
        public IntPtr pPADScoreArray;      ///< pointer to an array of PAD scores. Array size is determined by detectedObjects
        public double PADScoreInvalid;      ///< value of an invalid PAD Score. PADScoreArray will have this value if not able to calculate PAD Score for a fingerprint
        public double PADScoreMinimum;      ///< PADScoreMinimum PAD score minimum value
        public double PADScoreMaximum;      ///< PADScoreMaximum PAD score maximum value
        public double PADThresold;          ///< internal PAD score threshold used to evaluate spoof scores. This is not the SpoofDetectionConfidenceLevel
    };

}
