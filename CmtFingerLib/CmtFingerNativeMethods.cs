using System;
using System.Runtime.InteropServices;

namespace CmtFingerLib
{
    public class CmtFingerNativeMethods
    {
        /// <summary>
        /// Native cmtfinger ISO record transcoder methods and enums
        /// </summary>
#if DEBUG
        //    private const string library = "cmtfingerD.dll";
        private const string library = @"C:\BioKitSdks\cmtfinger.dll";
#else
    private const string library = "cmtfinger.dll";
#endif
        public CmtFingerNativeMethods()
        {
        }

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_create(CMT_FINGER_RECORD* rcfir);
        /// \brief Creates an opaque Finger Image object
        /// \param[out] rcfir the pointer to the opaque object to be created
        /// \return an error code
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_create", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerCreate(out IntPtr rcfir);

        /// <summary>
        /// \fn void STDCALL cmtfinger_free(CMT_FINGER_RECORD cfir)
        /// \brief Frees an opaque Finger Image object
        /// \param[in] cfir the opaque object to be freed
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_free", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern void NativeCmtFingerFree(IntPtr cfir);


        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_encode(CMT_FINGER_RECORD cfir, cmtfinger_encoding_format encoding_format, unsigned char* encoded_finger_record, int* enc_length)
        /// \brief Encodes an opaque Finger Image object into a standards based finger image record
        /// \param[in] cfir the opaque object to be encoded
        /// \param[in] encoding_format the encoding format to use
        /// \param[out] encoded_finger_record the client allocated buffer to be filled with the encoded FIR
        /// \param[out] enc_length the length of the FIR record generated
        /// \return an error code
        /// \remark if encoding is null, then the return length will still be provided
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_encode", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerEncode(IntPtr cfir, Cmtfinger_encoding_format encoding_format, IntPtr encoded_finger_record, ref int enc_length);

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_decode(CMT_FINGER_RECORD cfir, unsigned char* encoded_finger_record, int enc_length)
        /// \brief Decodes a standards based finger image record into an already allocated opaque Finger Image object
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in] encoded_finger_record the encoded FIR to be decoded
        /// \param[in] enc_length the length of the FIR record
        /// \return an error code
        /// \remark the library detects encoding format auto-magically
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_decode", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerDecode(IntPtr cfir, byte[] encoded_finger_record, int enc_length);


        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_get_property(CMT_FINGER_RECORD cfir, cmtfinger_property property, int* pval)
        /// \brief Gets a property of an opaque Finger Image object
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in] property the property to get
        /// \param[out] pval the value of the property
        /// \return an error code
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_get_property", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerGetProperty(IntPtr cfir, Cmtfinger_property property, ref int enc_length);

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_set_property(CMT_FINGER_RECORD cfir, cmtfinger_property property, int* pval)
        /// \brief Sets a property of an opaque Finger Image object
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in] property the property to set
        /// \param[in] pval the value of the property
        /// \return an error code
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_set_property", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerSetProperty(IntPtr cfir, Cmtfinger_property property, int pval);


        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_query(CMT_FINGER_RECORD cfir, cmt_finger_viewspec* query, cmt_finger_viewspec* results, int* numresults)
        /// \brief Queries the opaque Finger Image object for particular fingers by position and/or impression
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in] query the viewspec with position and/or impression to look for.  Don't care for a field is established with CMTFIR_QUERY_WILDCARD
        /// \param[in,out] results the array of viewspecs allocated by the client to be filled in by the query. If null, then the numresults provides information about required memory allocation.
        /// \param[in,out] numresults contains number allocated on input, and number matched on output.
        /// \return an error code
        /// \remark if results is null, then the numresults will provided information on how much memory allocation is required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_query", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerQuery(IntPtr cfir, Cmt_finger_viewspec query, IntPtr results, ref int numresults);

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_decode_from_bmp(CMT_FINGER_RECORD cfir, cmt_finger_viewspec* vs, unsigned char* bmp, int bmp_length)
        /// \brief reads in a bitmap buffer to establish/add it to a particular finger image
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in] vs selects the position and impression to asscocoate with the bitmap
        /// \param[in] bmp the buffer containing the windows bitmap byte steam
        /// \param[in] bmp_length the length of the bitmap byte stream
        /// \return an error code
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_decode_from_bmp", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerDecodeFromBmp(IntPtr cfir, Cmt_finger_viewspec vs, byte[] bmp, int bmp_length);

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_encode_to_bmp(CMT_FINGER_RECORD cfir, cmt_finger_viewspec* vs, unsigned char* bmp, int* bmp_length)
        /// \brief generates outputs of a bitmap buffer from a particular finger image
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in,out] vs selects the position and impression to generate to the bitmap, returns the quality of the selected view
        /// \param[out] bmp the buffer that will be filled in with the windows bitmap byte steam. If null, 
        /// then the bmp_length provides information about required memory allocation.
        /// \param[out] bmp_length the returned length of the bitmap bytestream
        /// \return an error code
        /// \remark if bmp is null, then the bmp_length will provided information on how much memory allocation is required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_encode_to_bmp", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerEncodeToBmp(IntPtr cfir, Cmt_finger_viewspec vs, byte[] bmp, ref int bmpLength);

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_set_raster(CMT_FINGER_RECORD cfir, cmt_finger_viewspec* vs, int width, int height, unsigned char* raster)
        /// \brief reads in a raster to establish/add it to a particular finger image
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in] vs selects the position and impression to asscocoate with the raster
        /// \param[in] width the width of raster
        /// \param[in] height the height of raster
        /// \param[in] raster the raster
        /// \return an error code
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_set_raster", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerSetRaster(IntPtr cfir, Cmt_finger_viewspec vs, int width, int height, IntPtr raster);

        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_get_raster(CMT_FINGER_RECORD cfir, cmt_finger_viewspec* vs, int* width, int* height, unsigned char* raster)
        /// \brief generates a raster output from a particular finger image
        /// \param[in] cfir the opaque object to be established by the FIR encoding
        /// \param[in,out] vs selects the position and impression to generate to the raster, returns the quality of the selected view
        /// \param[out] width the width of returned raster
        /// \param[out] height the height of returned raster
        /// \param[out] raster the buffer to be filled in with the raster. If null, then the width and height provides information about required memory allocation.
        /// \return an error code
        /// \remark if raster is null, then the width and height will provided information on how much memory allocation is required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_get_raster", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerGetRaster(IntPtr cfir, Cmt_finger_viewspec vs, ref int width, ref int height, byte[] raster);


        /// <summary>
        /// \fn cmtfinger_error STDCALL cmtfinger_get_version(char* vstring, int buflen)
        /// \brief gets version of transcoder
        /// \param[in] vstring the buffer allocated by client and filled in by transcoder
        /// \param[in] buflen the length of buffer that is allowed to be used by the transcoder
        /// \return an error code
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage")]
        [DllImport(library, EntryPoint = "cmtfinger_get_version", SetLastError = true, CharSet = CharSet.Unicode)]
        protected static extern Cmtfinger_error NativeCmtFingerGetVersion(byte[] buffer, int buflen);

    }


    /// <summary>
    /// This is the enumeration for the error code output from the cmtfinger library
    /// </summary>
    public enum Cmtfinger_error
    {
        CMTFIR_ERROR_OK = 0,
        CMTFIR_ERROR_BAD_INPUTS,
        CMTFIR_ERROR_MALLOC,
        CMTFIR_ERROR_NOT_CMT_IMAGE
    }

    /// <summary>
    /// This is the enumeration for Finger Position
    /// </summary>
    public enum Cmtfinger_position
    {
        CMTFIR_POSITION_UNSPECIFIED = -1,   /// <summary>to be used when position is not relevant</summary>
        CMTFIR_POSITION_UNKNOWN = 0,        /// <summary>to be used when position is not known</summary>

        CMTFIR_POSITION_R_THUMB = 1,        /// <summary>to be used for Right Thumb</summary>
        CMTFIR_POSITION_R_INDEX,            /// <summary>to be used for Right Index</summary>
        CMTFIR_POSITION_R_MIDDLE,           /// <summary>to be used for Right Middle</summary>
        CMTFIR_POSITION_R_RING,             /// <summary>to be used for Right Ring</summary>
        CMTFIR_POSITION_R_LITTLE,           /// <summary>to be used for Right Little</summary>
        CMTFIR_POSITION_L_THUMB = 6,        /// <summary>to be used for Left Thumb</summary>
        CMTFIR_POSITION_L_INDEX,
        CMTFIR_POSITION_L_MIDDLE,
        CMTFIR_POSITION_L_RING,
        CMTFIR_POSITION_L_LITTLE,

        CMTFIR_POSITION_R_FOURSLAP = 13,    /// <summary>to be used for Right Hand</summary>
        CMTFIR_POSITION_L_FOURSLAP,         /// <summary>to be used for Left Hand</summary>
        CMTFIR_POSITION_BOTHTHUMBS,

        CMTFIR_POSITION_PALM_UNKNOWN = 20,
        CMTFIR_POSITION_PALM_RIGHT_FULL,
        CMTFIR_POSITION_PALM_RIGHT_WRITER,
        CMTFIR_POSITION_PALM_LEFT_FULL,
        CMTFIR_POSITION_PALM_LEFT_WRITER,
        CMTFIR_POSITION_PALM_RIGHT_LOWER,
        CMTFIR_POSITION_PALM_RIGHT_UPPER,
        CMTFIR_POSITION_PALM_LEFT_LOWER,
        CMTFIR_POSITION_PALM_LEFT_UPPER,
        CMTFIR_POSITION_PALM_RIGHT_OTHER,
        CMTFIR_POSITION_PALM_LEFT_OTHER,
        CMTFIR_POSITION_PALM_RIGHT_INTERDIGITAL,
        CMTFIR_POSITION_PALM_RIGHT_THENAR,
        CMTFIR_POSITION_PALM_RIGHT_HYPOTHENAR,
        CMTFIR_POSITION_PALM_LEFT_INTERDIGITAL,
        CMTFIR_POSITION_PALM_LEFT_THENAR,
        CMTFIR_POSITION_PALM_LEFT_HYPOTHENAR,

        CMTFIR_POSITION_2FINGER_R_IM = 40,
        CMTFIR_POSITION_2FINGER_R_MR,
        CMTFIR_POSITION_2FINGER_R_RL,
        CMTFIR_POSITION_2FINGER_L_IM,
        CMTFIR_POSITION_2FINGER_L_MR,
        CMTFIR_POSITION_2FINGER_L_RL,
        CMTFIR_POSITION_BOTHINDEXES,
        CMTFIR_POSITION_3FINGER_R_IMR,
        CMTFIR_POSITION_3FINGER_R_MRL,
        CMTFIR_POSITION_3FINGER_L_IMR,
        CMTFIR_POSITION_3FINGER_L_MRL,
        CMTFIR_POSITION_4FINGER_L_MI_R_IM = 55,
        CMTFIR_POSITION_LAST = 55
    }

    /// <summary>
    /// This is the enumeration for Finger Impression
    /// </summary>
    public enum Cmtfinger_impression
    {
        CMTFIR_IMPRESSION_UNSPECIFIED = -2,     /// <summary>to be used when impression is not relevant</summary>
        CMTFIR_IMPRESSION_UNKNOWN = -1,         /// <summary>to be used when impression is not known</summary>
        CMTFIR_IMPRESSION_LIVE_PLAIN = 0,       /// <summary>to be used for Livescan Slap Images</summary>
        CMTFIR_IMPRESSION_LIVE_ROLL,            /// <summary>to be used for Livescan Roll Images</summary>
        CMTFIR_IMPRESSION_NONLIVE_PLAIN,        /// <summary>to be used for NonLive (Scanned) Slap Images</summary>
        CMTFIR_IMPRESSION_NONLIVE_ROLL,         /// <summary>to be used for NonLive (Scanned) Roll Images</summary>
        CMTFIR_IMPRESSION_LATENT,               /// <summary>to be used for Latent Finger Images</summary>
        CMTFIR_IMPRESSION_SWIPE,                /// <summary>to be used for Swipe Finger Images</summary>
        CMTFIR_IMPRESSION_LIVE_CONTACTLESS,     /// <summary>to be used for Contactless Finger Images</summary>
    }

    /// <summary>
    /// This is the enumeration for the encoding formats supported
    /// </summary>
    public enum Cmtfinger_encoding_format
    {
        CMTFIR_ENCODING_JTC1_19794_4 = 1,
        CMTFIR_ENCODING_INCITS_381,
        CMTFIR_ENCODING_CBEFF_NONE = 0 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
        CMTFIR_ENCODING_CBEFF_19785_9 = 1 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
        CMTFIR_ENCODING_CBEFF_19785_8 = 2 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
        CMTFIR_ENCODING_CBEFF_19785_7 = 3 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
        CMTFIR_ENCODING_CBEFF_BIOAPI_2 = 4 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
        CMTFIR_ENCODING_CBEFF_BIOAPI_1 = 5 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
        CMTFIR_ENCODING_CBEFF_398 = 6 << CmtFingerConstants.CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET,
    }

    public enum Cmtfinger_scale_units
    {
        CMTFIR_ENCODING_PIXELS_PER_INCH = 1,
        CMTFIR_ENCODING_PIXELS_PER_CM = 2,
    }

    /// <summary>
    /// This is the enumeration for the properties that may be set for a opaque CMT_FINGER_RECORD
    /// </summary>
    public enum Cmtfinger_property
    {
        CMTFIR_PROP_IBIA_FORMAT_OWNER = 0,
        CMTFIR_PROP_IBIA_FORMAT_VERSION,
        CMTFIR_PROP_SCANNERID,
        CMTFIR_PROP_IMAGE_ACQUISITION_LEVEL,
        CMTFIR_PROP_SCALE_UNITS,
        CMTFIR_PROP_HORIZONTAL_SCAN_PPI,
        CMTFIR_PROP_VERTICAL_SCAN_PPI,
        CMTFIR_PROP_HORIZONTAL_IMAGE_PPI,
        CMTFIR_PROP_VERTICAL_IMAGE_PPI,
    }


    /// <summary>
    /// This is the structure used to select a particular fingerprint from a collection, or used to set properties for a print to be added to a collection
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class Cmt_finger_viewspec
    {
        public Cmtfinger_position position;
        public Cmtfinger_impression impression;
        public Int32 quality;
    }

    public class CmtFingerConstants
    {
        public const int CMTFIR_ENCODING_BDB_FORMAT_OFFSET = 0;
        public const int CMTFIR_ENCODING_BDB_FORMAT_MASK = 0xF;
        public const int CMTFIR_ENCODING_CBEFF_FORMAT_OFFSET = 4;
        public const int CMTFIR_ENCODING_CBEFF_FORMAT_MASK = 0x01F0;
        public const int CMTFIR_QUERY_WILDCARD = -1;
    }

}
