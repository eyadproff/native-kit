using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CmtFingerLib
{
    /// <summary>
    /// Class CmtFingerInterop wraps the cmtfinger ISO record transcoder.
    /// Class extracts informormation and image data from ISO Fingerprint Image Record (FIR)
    /// </summary>
    public class CmtFingerTranscoder : CmtFingerNativeMethods
    {
        private IntPtr ptrFingerRecord = IntPtr.Zero;
        public List<Cmt_finger_viewspec> imageView;
        public List<BioBaseImageData> imageData;

        /// <summary>Empty Constructor</summary>
        /* public CmtFingerTranscoder()
        {
            cmtfinger_error err = NativeCmtFingerCreate(out fingerRecord);
            if (err != cmtfinger_error.CMTFIR_ERROR_OK)
                throw new CmtFingerException((int)err);
        }
        */
        /// <summary> 
        /// Constructor creates and decodes FIR data
        /// </summary>
        public CmtFingerTranscoder(byte[] buffer)
        {
            imageData = new List<BioBaseImageData>();
            imageView = new List<Cmt_finger_viewspec>();

            Cmtfinger_error err = NativeCmtFingerCreate(out ptrFingerRecord);

            if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                throw new CmtFingerException((int)err);

            if (buffer == null)
                throw new ArgumentNullException("invalid null argument!");

            err = NativeCmtFingerDecode(ptrFingerRecord, buffer, buffer.Length);

            if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
            {
                NativeCmtFingerFree(ptrFingerRecord);
                throw new CmtFingerException((int)err);
            }
        }

        /// <summary>Destructor</summary>
        ~CmtFingerTranscoder()
        {
            NativeCmtFingerFree(ptrFingerRecord);
            ptrFingerRecord = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// GetView returns List/array of all images contained in the FIR
        ///     This method is quicker than QueryView as it doesn't require the for loops
        ///      query with position set to CMTFIR_POSITION_UNSPECIFIED and impression set to CMTFIR_IMPRESSION_UNKNOWN returns all images
        /// Create List containing the position, impression and quality for each image
        /// Current method only returns information about images with the live plain and roll impression type
        /// TODO: To complete the class, the code needs to check all impression types.
        /// </summary>
        /// <returns></returns>
        public void GetView()
        {
            if (ptrFingerRecord == IntPtr.Zero)
                throw new CmtFingerException((int)Cmtfinger_error.CMTFIR_ERROR_BAD_INPUTS);

            imageView.Clear();

            // query for unspecified position will return all known positions. No need to loop
            Cmt_finger_viewspec query = new Cmt_finger_viewspec();
            query.position = Cmtfinger_position.CMTFIR_POSITION_UNSPECIFIED;
            query.impression = Cmtfinger_impression.CMTFIR_IMPRESSION_UNKNOWN;

            // pass in IntPtr.Zero to return image count in numresults
            int numResults = 0;
            Cmtfinger_error err = NativeCmtFingerQuery(ptrFingerRecord, query, IntPtr.Zero, ref numResults);
            if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                throw new CmtFingerException((int)err);

            if (numResults > 0)
            {
                // Allocate memory required to get FIR results. Requires IntPtr to memory for native C call.
                IntPtr ptrResults;
                int size = Marshal.SizeOf(typeof(Cmt_finger_viewspec));
                ptrResults = Marshal.AllocHGlobal(numResults * size);

                // Get array of results from fingerRecord
                err = NativeCmtFingerQuery(ptrFingerRecord, query, ptrResults, ref numResults);
                if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                {
                    if (ptrResults != IntPtr.Zero)
                        Marshal.FreeHGlobal(ptrResults);
                    throw new CmtFingerException((int)err);
                }

                //string Version = GetVersion();  // get file version and major file version from native cmtfinger library.
                //int FileMajorPart = Convert.ToInt32(Version.Substring(0, Version.IndexOf('.')));
                //// Marshal native results to managed object and then add it to the List
                ///
                for (int i = 0; i < numResults; i++)
                {
                    Cmt_finger_viewspec result = (Cmt_finger_viewspec)Marshal.PtrToStructure(ptrResults, typeof(Cmt_finger_viewspec));
                    imageView.Add(result);

                    //if (FileMajorPart <= 3)    // must be at least version "4, 0, 0, 0") for data in results
                    //{   // Bug in cmtfinger.dll vesion 3.0.0.0 and older. Older versions puts result data put in the query parameter by mistake.
                    //    imageView.Add(query);
                    //}
                    //else
                    //{
                    //    // Marshal each results for cases with FIR contianing multiple images
                    //    IntPtr PtrRes = new IntPtr((int)results + i * size);
                    //    Cmt_finger_viewspec result = (Cmt_finger_viewspec)Marshal.PtrToStructure(PtrRes, typeof(Cmt_finger_viewspec));
                    //    imageView.Add(result);
                    //}
                }

                if (ptrResults != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptrResults);
            }
        }

        /// <summary>
        /// QueryView returns List/array of all images contained in the FIR
        ///   loops checks for images for each and every impression and position
        /// Create List containing the position, impression and quality for each image
        /// Current method only returns information about images with the live plain and roll impression type
        /// TODO: To complete the class, the code needs to check all impression types.
        /// </summary>
        /// <returns></returns>
        public void QueryView()
        {
            if (ptrFingerRecord == IntPtr.Zero)
                throw new CmtFingerException((int)Cmtfinger_error.CMTFIR_ERROR_BAD_INPUTS);

            imageView.Clear();

            // Start with first impression and first position
            Cmt_finger_viewspec query = new Cmt_finger_viewspec();

            // Check for flat/plain and roll impressions
            for (query.impression = Cmtfinger_impression.CMTFIR_IMPRESSION_LIVE_PLAIN; query.impression <= Cmtfinger_impression.CMTFIR_IMPRESSION_LIVE_ROLL; query.impression++)
            {
                // Check each possible position
                for (query.position = Cmtfinger_position.CMTFIR_POSITION_R_THUMB; query.position <= Cmtfinger_position.CMTFIR_POSITION_LAST; query.position++)
                {
                    // get number of images of each position type in FIR 
                    // passing in query type looking for
                    // pass in IntPtr.Zero to return image count in numresults
                    int numResults = 0;
                    Cmtfinger_error err = NativeCmtFingerQuery(ptrFingerRecord, query, IntPtr.Zero, ref numResults);
                    if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                        throw new CmtFingerException((int)err);

                    if (numResults > 0)
                    {
                        // Allocate memory required to get FIR results. Requires IntPtr to memory for native C call.
                        IntPtr results;
                        int size = Marshal.SizeOf(typeof(Cmt_finger_viewspec));
                        results = Marshal.AllocHGlobal(numResults * size);

                        // Get array of results from fingerRecord
                        err = NativeCmtFingerQuery(ptrFingerRecord, query, results, ref numResults);
                        if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                        {
                            if (results != IntPtr.Zero)
                                Marshal.FreeHGlobal(results);
                            throw new CmtFingerException((int)err);
                        }

                        // Marshal native results to managed object and then add it to the List
                        for (int i = 0; i < numResults; i++)
                        {
                            IntPtr PtrRes = new IntPtr((int)results + i * size);
                            Cmt_finger_viewspec result = (Cmt_finger_viewspec)Marshal.PtrToStructure(PtrRes, typeof(Cmt_finger_viewspec));
                            imageView.Add(result);
                        }
                        if (results != IntPtr.Zero)
                            Marshal.FreeHGlobal(results);
                    }

                }// end positions
            }// end impressions
        }

        /// <summary>
        /// GetImages extract a bitmap image from the FIR
        /// </summary>
        /// <returns></returns>
        public void GetImages()
        {
            if (ptrFingerRecord == IntPtr.Zero)
                throw new CmtFingerException((int)Cmtfinger_error.CMTFIR_ERROR_BAD_INPUTS);

            imageData.Clear();

            if (imageView.Count == 0)
                GetView();
            if (imageView.Count == 0)
                return;

            for (int i = 0; i < imageView.Count; i++)
            {

                int bitmapInfoLen = 0;
                Cmt_finger_viewspec cfvs = new Cmt_finger_viewspec();
                cfvs.position = imageView[i].position;
                cfvs.impression = imageView[i].impression;

                // pass in null to request image size
                Cmtfinger_error err = NativeCmtFingerEncodeToBmp(ptrFingerRecord, cfvs, null, ref bitmapInfoLen);
                if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                    throw new CmtFingerException((int)err);
                if (bitmapInfoLen == 0)
                    throw new CmtFingerException((int)err);


                // Allocate memory for image
                byte[] imgBuf = new byte[bitmapInfoLen];
                // Get image into imgBuf
                err = NativeCmtFingerEncodeToBmp(ptrFingerRecord, cfvs, imgBuf, ref bitmapInfoLen);
                if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
                    throw new CmtFingerException((int)err);


                //Create Bitmap object
                Stream s = new MemoryStream(imgBuf);
                Bitmap bmp = new System.Drawing.Bitmap(s);

                // Unfortunately, System Drawing does properly set resolution so we need to get it again... (painful)
                // copy image resolution from imgBuf[38] and [42]
                byte[] x_rbuf = new byte[4];
                byte[] y_rbuf = new byte[4];

                Buffer.BlockCopy(imgBuf, 38, x_rbuf, 0, 4);
                Buffer.BlockCopy(imgBuf, 42, y_rbuf, 0, 4);

                if (!System.BitConverter.IsLittleEndian)
                {
                    // reverse the array to little endian for bmp format
                    Array.Reverse(x_rbuf);
                    Array.Reverse(y_rbuf);
                }

                // 19685 pixels per meter
                int x_res = (500 * System.BitConverter.ToInt32(x_rbuf, 0) + 250) / 19685;
                int y_res = (500 * System.BitConverter.ToInt32(y_rbuf, 0) + 250) / 19685;
                bmp.SetResolution((float)x_res, (float)y_res);


                BioBaseImageData imgdata = new BioBaseImageData(imageView[i].position.ToString(), imageView[i].impression.ToString(), imageView[i].quality, bmp);
                imageData.Add(imgdata);
            }
        }



        /// <summary>
        /// GetRaster extract a raster with width, height and resolution from the FIR
        /// </summary>
        /// <param name="vs"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="ResX"></param>
        /// <param name="ResY"></param>
        /// <returns></returns>
        public byte[] GetRaster(Cmt_finger_viewspec vs, out int width, out int height, out int ResX, out int ResY)
        {
            if (ptrFingerRecord == IntPtr.Zero)
                throw new CmtFingerException((int)Cmtfinger_error.CMTFIR_ERROR_BAD_INPUTS);

            Int32 imgWidth = 0;
            Int32 imgHeight = 0;
            Int32 imgResX = 0;
            Int32 imgResY = 0;

            // pass in null to request image width and height
            Cmtfinger_error err = NativeCmtFingerGetRaster(ptrFingerRecord, vs, ref imgWidth, ref imgHeight, null);
            if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
            {
                NativeCmtFingerFree(ptrFingerRecord);
                throw new CmtFingerException((int)err);
            }
            // get image resolution
            err = NativeCmtFingerGetProperty(ptrFingerRecord, Cmtfinger_property.CMTFIR_PROP_HORIZONTAL_IMAGE_PPI, ref imgResX);
            err = NativeCmtFingerGetProperty(ptrFingerRecord, Cmtfinger_property.CMTFIR_PROP_VERTICAL_IMAGE_PPI, ref imgResY);

            // allocate image memory
            byte[] raster = new byte[imgWidth * imgHeight];
            // Get image into raster
            err = NativeCmtFingerGetRaster(ptrFingerRecord, vs, ref imgWidth, ref imgHeight, raster);
            if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
            {
                NativeCmtFingerFree(ptrFingerRecord);
                throw new CmtFingerException((int)err);
            }

            // return image data
            width = imgWidth;
            height = imgHeight;
            ResX = imgResX;
            ResY = imgResY;
            return raster;
        }

        /// <summary>
        /// GetVersion returns version of the native cmtfinger.dll in a string
        /// throws exception on any error.
        /// </summary>
        /// <returns>string containing the vesion</returns>
        public string GetVersion()
        {
            //System.Diagnostics.FileVersionInfo versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(".\\cmtfinger.dll");
            //System.Diagnostics.Debug.WriteLine("versioninfo:{0}", versionInfo.FileVersion);

            byte[] version = new byte[256];
            Cmtfinger_error err = NativeCmtFingerGetVersion(version, version.Length);
            if (err != Cmtfinger_error.CMTFIR_ERROR_OK)
            {
                throw new CmtFingerException((int)err);
            }

            string retValue = string.Empty;
            for (int index = 0; index < version.Length; index++)
            {
                if (version[index] == 0)
                {
                    retValue = ASCIIEncoding.ASCII.GetString(version, 0, index);
                    break;
                }
            }
            // Return string with only numbers. remove leading "version" string
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            return retValue.Substring(retValue.IndexOfAny(numbers));
        }


    }

    /// <summary>
    /// Image helper class to save image as Bitmap object.
    /// <param name="position">position of the captured image</param>
    /// <param name="impression">impression type of the captured image</param>
    /// <param name="quality">quality of the captured image</param>
    /// <param name="image">.Net Bitmap object of the captured image</param>
    /// </summary>    
    public class BioBaseImageData
    {
        public BioBaseImageData(string position, string impression, Int32 quality, Bitmap image)
        {
            Position = position;
            Impression = impression;
            Quality = quality;
            Image = image;
        }

        public string Position { get; private set; }
        public string Impression { get; private set; }
        public Int32 Quality { get; private set; }
        public Bitmap Image { get; private set; }
    }

}
