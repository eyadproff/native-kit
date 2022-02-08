namespace Crossmatch
{
    public enum BioBErrorCode
    {
        BIOB_SUCCESS = 0x00,        //< Function completed successfully

        BIOB_FAILURE = -1,          //< Function failed
        BIOB_GENERAL_FAIL = -2,     //< General failure
        BIOB_INVALID_PARAM_VALUE = -3, //< Invalid parameter value
        BIOB_MEM_ALLOC = -4,        //< Insufficient memory
        BIOB_NOT_SUPPORTED = -5,    //< Requested functionality isn't supported
        BIOB_FILE_OPEN = -6,        //< File open failed
        BIOB_FILE_READ = -7,        //< File read failed
        BIOB_RESOURCE_LOCKED = -8,  //< Failure due to a locked resource
        BIOB_NULL_POINTER = -9,     //< Null pointer
        BIOB_INVALID_PROPNAME = -10,     //< Invalid property name
        BIOB_INVALID_PROPVALUE = -11,    //< Invalid property value
        BIOB_INVALID_PROPCATEGORY = -12, //< Invalid property category
        BIOB_THREAD_CREATION_FAIL = -13, //< Thread creation failure
        BIOB_DATA_NOT_READY = -14,       //< Data not ready
        BIOB_RESOURCE_MISSING = -15,     //< Failure due to a missing resource (e.g. DLL file)

        BIOB_VISUALIZATION_FAIL = -50,   //< Visualization failure (e.g. DirectDraw not available)

        BIOB_DEVICE_FAIL = -101,        //< Device failure
        BIOB_DEVICEIO = -102,           //< Device communication failed
        BIOB_COMNDFAILED = -103,        //< Command execution failed
        BIOB_COMNDTIMEOUT = -104,       //< Command execution timed out
        BIOB_NODEVICE = -105,           //< No device is detected/active
        BIOB_NOMATCHINGDEV = -106,      //< No matching device is detected
        BIOB_DEVICEACTIVE = -107,       //< Device active
        BIOB_NOTINITIALIZED = -108,     //< Device needs to be initialized  
        BIOB_DEVICEINITIALIZED = -109,  //< Device is initialized
        BIOB_DEVICEINVALIDSTATE = -110, //< Device state is invalid; reinitialization required (Exit + Init)
        BIOB_DEVICEBUSY = -111,         //< Another thread is currently using device functions
        BIOB_NOHWSUPPORT = -112,        //< No hardware support for requested function 
        BIOB_DEVICEREADPARAM = -113,    //< Device parameters can't be read
        BIOB_DEVICEWRITEPARAM = -114,   //< Parameter write to device failed
        BIOB_DEVICEINVALIDPARAM = -115, //< Parameter read from device is invalid
        BIOB_DEVICENOMEMORY = -116,     //< No memory available for specified action (exceeded size)
        BIOB_DEVICEWRONGOPERMODE = -117,//< Device operation mode is incorrect
        BIOB_MULTIDEVICESNOTSUPPORTED = -118, //< Function is only supported for single device configuration
        BIOB_INVALIDLICENSEFILE = -119,       //< The license file given is invalid or does not match to the device
        BIOB_DEVICEINCOMPATIBLEWITHOS = -120, //< Device is incompatible with OS
        BIOB_INAPPROPRIATEPHYSICALINTERFACE = -121, //< Device is connected to an USB full speed port but high speed is required

        BIOB_ACQUISITION_FAIL = -201,   //< Acquisition failure
        BIOB_NOCHANNEL = -202,          //< No acquisition channel found  
        BIOB_NOMATCHINGCHNL = -203,     //< No matching acquisition channel found  
        BIOB_CHNLNOTINITIALIZED = -204, //< Acquisition channel not initialized  
        BIOB_CHNLNOTACTIVE = -205,      //< The acquisition channel is not active  
        BIOB_CHNLBUSY = -206,           //< Channel is currently busy
        BIOB_CAPTUREINPROGRESS = -207,  //< A capture is still running
        BIOB_NOTCAPTURING = -208,       //< No capture is running
        BIOB_CAPTURE = -209,            //< Image acquisition failed  
        BIOB_CAPTURETIMEOUT = -210,     //< Timeout during capturing
        BIOB_STOPCAPTURE = -211,        //< Stop capture failed  
        BIOB_CAPTUREBUFFERFULL = -212,  //< Ring buffer overflow
        BIOB_CHNLALREADYINITIALIZED = -213, //< Channel is already initialized
        BIOB_CHNLALREADYACTIVE = -214,      //< Channel is already active
        BIOB_CHNLINVALIDCAPTUREMODE = -215, //< Capture mode is not valid or not supported
        BIOB_CHNLNOSHUTTER = -216,          //< Shutter functionality is not available
        BIOB_CHNLNOLUT = -217,              //< LUT functionality is not available
        BIOB_CHNLNOCAMERASETTINGS = -218,   //< Camera settings functionality is not available
        BIOB_CHNLNOILLUMINATION = -219,     //< Illumination functionality is not available
        BIOB_CHNLNOHEATER = -220,           //< Heater functionality is not available
        BIOB_CHNLINVALIDIMAGEDATA = -221,   //< Image data is not valid
        BIOB_CHNLNOSCANTABLE = -222,        //< Scan table is not available
        BIOB_CHNLINVALIDSCANTABLE = -223,   //< Scan table data is not valid
        BIOB_CHNLSCANNERNOTADJUSTED = -224, //< Micro scanner is not adjusted
        BIOB_CHNLNOTSCANNING = -225,        //< Capture mode does not support scanning
        BIOB_CHNLNOCALIBRATIONRECTS = -226, //< No calibration RECTs are stored

        BIOB_IMAGEPROCESSING_FAIL = -301,   //< Image processing failure
        BIOB_IMGPROCESSING = -302,          //< Generic image processing failure
        BIOB_NOHANDFINGER = -303,           //< No finger/hand object detected
        BIOB_ROLLPROC = -304,               //< Image processing failure at rolled finger print processing
        BIOB_ROLLTIMEOUT = -305,            //< No roll start detected within a defined timeout period
        BIOB_ROLLWRONGORIENT = -306,        //< Finger didn't start to roll using the expected orientation
        BIOB_ROLLWRONGBOUNDS = -307,        //< Bounding box of a finger has an unusual size
        BIOB_ROLLWRONGINTERSECT = -308,     //< Intersection box of 2 successive fingerprint images has unusual size
        BIOB_ROLLMERGEPATHOUTSIDE = -309,   //< Merging path has left the intersection contour
        BIOB_INCORRECTWIDTH = -310,         //< Incorrect width

        BIOB_AUTOCAPTURE_FAIL = -401,       //< Auto capture failure
        BIOB_AUTOCAPTURE_NOT_INITIALIZED = -402,    //< Module needs to be initialized  
        BIOB_AUTOCAPTURE_IS_INITIALIZED = -403,     //< Module is (already) initialized
        BIOB_AUTOCAPTURE_IMG_NOT_ALLOCATED = -404,  //< Image is not allocated
        BIOB_AUTOCAPTURE_SEQ_NOT_ALLOCATED = -405,  //< Sequence is not allocated
        BIOB_AUTOCAPTURE_UNKNOWN_IMAGE_ID = -406,   //< Image identifier is unknown
        BIOB_AUTOCAPTURE_IMAGE_ID_NOT_IN_RANGE = -407,  //< Image identifier is not in initialized range
        BIOB_AUTOCAPTURE_UNKNOWN_FINGER_ID = -408,      //< Finger identifier is unknown
        BIOB_AUTOCAPTURE_MAX_IMAGES_IN_QUEUE_IS_UNKNOWN = -409, //< LS_AutoCapture_SetMaxNumberOfImagesInQueue() was not called
        BIOB_AUTOCAPTURE_HANDLE_NOT_AVAILABLE = -410,   //< Auto capture handle is not available
        BIOB_AUTOCAPTURE_DLL_PATH_IS_MISSING = -411,    //< DLL path is unknown

        BIOB_XML_FAIL = -501,           //< XML fail
        BIOB_XML_PARSE_NOHEADER = -502, //< XML parse no header found
        BIOB_XML_PARSE_FAIL = -503,     //< XML parse fail
        BIOB_XML_INTEGRITY = -504,      //< XML integrity
        BIOB_XML_GENERAL = -505,        //< XML general

        BIOB_INFIELDTEST_FAIL = -601,           //< The test suite has an invalid version
        BIOB_INFIELDTEST_LOADPARMSFAIL = -602,  //< The test suite has an invalid device type

        BIOB_FACE_DETECTION_FAIL = -701,            //< Face detection failure
        BIOB_FACE_DETECTION_NO_FACE = -702,         //< Face detection no face found
        BIOB_FACE_DETECTION_TOO_MANY_FACES = -703,  //< Face detection too many faces found
        BIOB_FACE_DETECTION_NO_DETECTOR = -704,     //< Face detection no detector

        BIOB_LAYOUTRENDERER_FAILED = -900,                  //< LayoutRenderer failed
        BIOB_LAYOUTRENDERER_PARAMS_EMPTY_KEY = -901,        //< LayoutRenderer external params with empty key
        BIOB_LAYOUTRENDERER_PARAMS_DUPLICATE_KEY = -902,    //< LayoutRenderer external params with duplicate key
        BIOB_LAYOUTRENDERER_PARAMS_INTERNAL_KEY_USED = -903,//< LayoutRenderer external params use internal key
                                                            // END ERRORS.

        // START WARNINGS.
        BIOB_OUTDATED_FIRMWARE = 101,       //< Device firmware version outdated
        BIOB_OPTICS_SURFACE_DIRTY = 102,    //< Optics surface should be cleaned
        BIOB_ALREADY_INITIALIZED = 103,     //< Device/component has already been initialized and is ready to be used
        BIOB_NO_OBJECT = 104,               //< No finger/hand detected
        BIOB_BAD_SCAN = 105,                //< Finger/hand was moved during image scan
        BIOB_NOT_OPENED = 106,              //< Not open

        BIOB_AUTOCAPTURE_SEGMENTATION = 107, //< Auto capture segmentation
        BIOB_INFIELD_TEST_WRONG_VER = 108,  //< The test suite has an invalid version
        BIOB_INFIELD_TEST_WRONG_DEV = 109,  //< The test suite has an invalid device type
        BIOB_DEVICE_ALREADY_CLOSED = 110,   //< Device already closed
        BIOB_ZERO_DEVICES_DETECTED = 111,   //< No device detected
        BIOB_RESERVED = 112,                //< Reserved
        BIOB_PROPERTIES_ALL_READONLY = 113, //< Properties read only
        BIOB_NO_DEVICE_NAME = 114,          //< No device name
        BIOB_NO_SERIAL_NUMBER = 115,        //< No serial number
        BIOB_DEVICE_NOT_CONNECTED_SUGGEST_REOPEN = 116, //< Device not connected, reopen device
        BIOB_SPOOF_DETECTED = 123,      //< One or more objects in the result image are spoofs
        BIOB_NO_CAPTURE_ACTIVE = 124,   //< Warning in segmentation code
        BIOB_SPOOF_DETECTOR_FAIL = 125, //< Spoof detector execution failed -- no liveness/spoof information available for image
        BIOB_METHOD_DEPRECATED = 126,   //< Function Deprecated - please see documentation
        BIOB_USAGE_DEPRECATED = 127,    //< Usage of Function in the current BIOBASE State is Deprecated - please see documentation
        BIOB_REPLACE_PAD = 128,         //< Silicone membrane needs to be replaced

        // BEGIN ROLL WARNINGS.
        BIOB_ROLL_BASE = 256,                               //< Fingerprint rolling related warning codes base
        BIOB_ROLL_SHIFTED_HORIZONTALLY = BIOB_ROLL_BASE + 1,//< Finger was shifted horizontally
        BIOB_ROLL_SHIFTED_VERTICALLY = BIOB_ROLL_BASE + 2,  //< Finger was shifted vertically
        BIOB_ROLL_LIFTED_TIP = BIOB_ROLL_BASE + 4,          //< Finger tip was lifted
        BIOB_ROLL_ON_BORDER = BIOB_ROLL_BASE + 8,           //< Finger was rolled to border
        BIOB_ROLL_PAUSED = BIOB_ROLL_BASE + 16,             //< Finger was kept still during roll
        BIOB_ROLL_FINGER_TOO_NARROW = BIOB_ROLL_BASE + 32,  //< Finger too narrow

        BIOB_ROLL_MASK = BIOB_ROLL_BASE + 255,              //< Fingerprint rolling related warning codes mask
        BIOB_ROLL_LAST = BIOB_ROLL_MASK,                    //< biggest value of possible Fingerprint rolling related warning code combinations
                                                            // END WARNINGS.
    }

    public enum BioBEvents
    {
        BIOB_INIT_PROGRESS = 0,          //< Identifies device being initialized process callback.
        BIOB_PREVIEW,                    //< Identifies preview image available callback.
        BIOB_OBJECT_QUALITY,             //< Identifies object quality during capture callback.
        BIOB_OBJECT_COUNT,               //< Identifies object count during capture callback.
        BIOB_SCANNER_USERINPUT,          //< Identifies user input on the device callback.
        BIOB_SCANNER_USEROUTPUT,         //< Identifies acknowledgement of outputs callback.
        BIOB_ACQUISITION_STARTED,        //< Identifies device is starting acquisition callback.
        BIOB_ACQUISITION_COMPLETED,      //< Identifies acquisition complete callback.
        BIOB_DATA_AVAILABLE,             //< Identifies acquired data available callback.
        BIOB_SCANNER_DISCONNECTED,       //< Identifies device is disconnected callback.

        BIOB_DEPRECATED_1,               //< Was used for connect callback.
        BIOB_OBJECT_DETECTED,            //< Identifies object on the "detection surface" before going live callback.
        BIOB_DEVICE_COUNT_CHANGED,       //< Identifies number of supported devices detected callback.
    }

    public enum BioBDataFormat
    {
        BIOB_IIR,       //< Iris Image Record.
        BIOB_FIR,       //< Fingerprint Image Record.
        BIOB_FACE_IR,   //< Face Image Record.
        BIOB_BMP,       //< BMP - only to be used for non-standard outputs (e.g. documents, scenes,tattoos)
        BIOB_JPG,       //< JPG - only to be used for non-standard outputs (e.g. documents, scenes) and only when recompression must be avoided
        BIOB_FORMAT_NULL = 999
    }

    public enum BioBOsType
    {
        BIOB_WIN32OS,
        BIOB_VISTAOS,
        BIOB_LINUXOS,
        BIOB_SOLARISOS,
    }

    public enum BioBOutputDataFormat
    {
        BIOB_OUT_IIR,           //< Iris Image Record.
        BIOB_OUT_FIR,           //< Fingerprint Image Record.
        BIOB_BITMAP_OUT_INFO,   //< Bitmap info.
        BIOB_OUT_BMP,           //< Bitmap image.
        BIOB_OUT_JPG,           //< JPEG compressed image.
        BIOB_OUT_PNG,           //< Portable Network Graphics lossless compressed image.
        BIOB_OUT_WAV,           //< Audio wave file.
        BIOB_OUT_XML            //< Extensible Markup Language data.
    }

    public enum BioBObjectQualityState
    {
        BIOB_OBJECT_NOT_PRESENT,              //< Object not detected
        BIOB_OBJECT_GOOD,                     //< Object tracking OK
        BIOB_OBJECT_TOO_LIGHT,                //< Object contrast too low
        BIOB_OBJECT_TOO_DARK,                 //< Object contrast too dark
        BIOB_OBJECT_BAD_SHAPE,                //< Object shape not OK
        BIOB_OBJECT_POSITION_NOT_OK,          //< Object position not within tracking area
        BIOB_OBJECT_CORE_NOT_PRESENT,         //< Object core not found
        BIOB_OBJECT_TRACKING_NOT_OK,          //< Required tracking time has not been reached yet
        BIOB_OBJECT_POSITION_TOO_HIGH,        //< Object position not within tracking area
        BIOB_OBJECT_POSITION_TOO_LEFT,        //< Object position not within tracking area
        BIOB_OBJECT_POSITION_TOO_RIGHT,       //< Object position not within tracking area
        BIOB_OBJECT_POSITION_TOO_LOW,         //< Object position not within tracking area
        BIOB_OBJECT_FLEX_POSITION_TOO_HIGH,   //< Flex Flats Mode only: Object position not within active area
        BIOB_OBJECT_FLEX_POSITION_TOO_LEFT,   //< Flex Flats Mode only: Object position not within active area
        BIOB_OBJECT_FLEX_POSITION_TOO_RIGHT,  //< Flex Flats Mode only: Object position not within active area
        BIOB_OBJECT_FLEX_POSITION_TOO_LOW,    //< Flex Flats Mode only: Object position not within active area
        BIOB_OBJECT_TOO_CLOSE,                //< Position too close (for focus)
        BIOB_OBJECT_TOO_FAR,                  //< Position too far away (for focus)
        BIOB_OBJECT_NOT_FOCUSED,              //< Object not in depth of field of camera
        BIOB_OBJECT_NOT_STILL,                //< For when object/camera introduces motion blur (related to integration time)
        BIOB_OBJECT_NOT_ALIGNED,              //< For when face/iris is not in harmony with expected capture pose (not frontal, or gaze problem)
        BIOB_OBJECT_OCCLUSION,                //< Object is partially blocked
        BIOB_OBJECT_CONFUSION,                //< Wrong object given (on flat left/right fingers), or too many objects (on two thumbs)
        BIOB_OBJECT_ROTATED_CLOCKWISE,        //< Object is rotated too much in a clockwise orientation
        BIOB_OBJECT_ROTATED_COUNTERCLOCKWISE  //< Object is rotated too much in a counter-clockwise orientation
    }

    public enum BioBObjectCountState
    {
        BIOB_OBJECT_COUNT_OK,    //< Number of detected objects is correct.
        BIOB_TOO_MANY_OBJECTS,   //< Too many detected objects.
        BIOB_TOO_FEW_OBJECTS     //< Too few detected objects.
    }

    public enum BioBInitializationType
    {
        BIOB_INIT_UNDEFINED = 0,
        BIOB_INIT_HARDWARE_INIT,
        BIOB_INIT_INFIELD_TEST,
    }

    public enum BioBEncodingTypes
    {
        BIOB_ENCODING_JTC1_19794_4_2005 = 401,  //< FIR DEV_PROP_ENCODING_JTC1_19794_4_2005
        BIOB_ENCODING_INCITS_381_2004,          //< FIR DEV_PROP_ENCODING_INCITS_381_2004
        BIOB_ENCODING_JTC1_19794_5_2005 = 501,  //< FAC DEV_PROP_ENCODING_JTC1_19794_5_2005
        BIOB_ENCODING_INCITS_385_2004,          //< FAC DEV_PROP_ENCODING_INCITS_385_2004
        BIOB_ENCODING_JTC1_19794_6_2005 = 601,  //< IIR DEV_PROP_ENCODING_JTC1_19794_6_2005
    }

    public enum BioBDeviceDectionAreaState
    {
        BIOB_CLEAR_OBJECT_FROM_DETECTION_AREA,  //< Objects are detected at the beginning of a auto capture sequence
                                                //< but objects should be removed from the detection area (e.g. fingers on platen).
        BIOB_DETECTION_AREA_CLEAR               //< Detection area has been cleared.
    }

    public enum GuidanceType
    {
        GuidanceTypeNone = 0,      // Unknown type of capture device
        GuidanceTypeLScan,         // capture device has LScan LEDs such as LScan 1000P and LScan 1000T
        GuidanceTypeStatusLED,     // Capture device has Status LEDs such as LScan Guardian USB, Guardian F, Guardian L, Guardian R2, Patrol, Patrol ID, etc.
        GuidanceTypeTFT,           // Capture device has TFT LCD display with LED OK and Cancel buttons such as LScan 500P, LScan 500, etc
        GuidanceTypeTFT_1000,      // Capture device has TFT LCD display with LED OK and Cancel buttons such as LScan 1000PX, LScan 1000, LScan 500, etc
        GuidanceTypeTouchDisplay   // Capture device has Touch Screen display or LED display dispaly such as Guardian, Guardian 300, Guardain 200 and Guardian 100
    };

    public enum InputType
    {
        InputTypeNone = 0,   // Unknown type of capture device
        InputType5Key,      // Capture device has 5 buttons such as LScan 1000P 
        InputType4Key,      // Capture device has 4 buttons such as LScan 500PJ
        InputType2Key,      // Capture device has 2 buttons such as LScan Guardian T, LScan 500P, LScan 1000PX, LScan 1000, LScan 500, LScan 1000T and newer LScan 1000P
        InputTypeTouchKey   // Capture device has Touch Screen display such as Guardian and Guardian 300
    };

    public enum ActiveKeys
    {
        KEYS_NONE,                                        ///< No keys
        KEYS_OK_CONTRAST,                                 ///< 'OK' and 'Optimize Contrast' buttons 
        KEYS_ACCEPT_RECAPTURE                             ///< 'Accept' and 'Recapture'
    };

    //public enum BioBImageResolutions
    //{
    //    Res500ppi = 500,
    //    Res1000ppi = 1000
    //}

    //public enum TouchScreenFingerStatusType
    //{
    //    None = 0,
    //    Captured = 1,
    //    Active = 2,
    //    Error = 3
    //}

    //public enum BioBModalityOffsetsTypes
    //{
    //    BIOB_FINGERPRINT_RANGE_START = 0,        // Fingerprint biometric
    //    BIOB_FINGERPRINT_RANGE_END = 499,

    //    BIOB_IRIS_RANGE_START = 500,      // Iris biometric
    //    BIOB_IRIS_RANGE_END = 999,

    //    BIOB_FACE_RANGE_START = 1000,     // Face geometry
    //    BIOB_FACE_RANGE_END = 2999,

    //    BIOB_EAR_RANGE_START = 3000,     // Ear biometric
    //    BIOB_EAR_RANGE_END = 3999,

    //    BIOB_FACE_THERMO_RANGE_START = 4000,     // Face thermoGram
    //    BIOB_FACE_THERMO_RANGE_END = 4999,

    //    BIOB_HAND_THERMO_RANGE_START = 5000,     // Hand thermoGram
    //    BIOB_HAND_THERMO_RANGE_END = 5999,

    //    BIOB_HAND_VEIN_RANGE_START = 6000,     // Hand vein pattern
    //    BIOB_HAND_VEIN_RANGE_END = 6999,

    //    BIOB_HAND_GEOM_RANGE_START = 7000,     // Hand geometry
    //    BIOB_HAND_GEOM_RANGE_END = 7999,

    //    BIOB_RETINA_RANGE_START = 8000,     // Retina
    //    BIOB_RETINA_RANGE_END = 8999,

    //    BIOB_SIGNATURE_RANGE_START = 9000,     // Written signature
    //    BIOB_SIGNATURE_RANGE_END = 9999,

    //    BIOB_VOICE_RANGE_START = 10000,    // Voice pattern
    //    BIOB_VOICE_RANGE_END = 10999
    //}

    //public enum BioBPositionTypes
    //{
    //    BIOB_POSITION_UNKNOWN = 0,    // Position not known.

    //    BIOB_FINGERPRINT_UNKNOWN = BioBModalityOffsetsTypes.BIOB_FINGERPRINT_RANGE_START,

    //    BIOB_FINGERPRINT_RIGHT_THUMB,
    //    BIOB_FINGERPRINT_RIGHT_INDEX,
    //    BIOB_FINGERPRINT_RIGHT_MIDDLE,
    //    BIOB_FINGERPRINT_RIGHT_RING,
    //    BIOB_FINGERPRINT_RIGHT_LITTLE,
    //    BIOB_FINGERPRINT_LEFT_THUMB,
    //    BIOB_FINGERPRINT_LEFT_INDEX,
    //    BIOB_FINGERPRINT_LEFT_MIDDLE,
    //    BIOB_FINGERPRINT_LEFT_RING,
    //    BIOB_FINGERPRINT_LEFT_LITTLE,
    //    BIOB_FINGERPRINT_RIGHT_FOUR_FINGERS = 13,

    //    BIOB_FINGERPRINT_LEFT_FOUR_FINGERS,
    //    BIOB_FINGERPRINT_BOTH_THUMBS,
    //    BIOB_FINGERPRINT_TWO_FINGERS,
    //    BIOB_FINGERPRINT_UNKNOWN_PALM = 20,

    //    BIOB_FINGERPRINT_RIGHT_FULL_PALM,
    //    BIOB_FINGERPRINT_RIGHT_WRITERS_PALM,
    //    BIOB_FINGERPRINT_LEFT_FULL_PALM,
    //    BIOB_FINGERPRINT_LEFT_WRITERS_PALM,
    //    BIOB_FINGERPRINT_RIGHT_LOWER_PALM,
    //    BIOB_FINGERPRINT_RIGHT_UPPER_PALM,
    //    BIOB_FINGERPRINT_LEFT_LOWER_PALM,
    //    BIOB_FINGERPRINT_LEFT_UPPER_PALM,
    //    BIOB_FINGERPRINT_RIGHT_INDEX_AND_MIDDLE = 40,

    //    BIOB_FINGERPRINT_RIGHT_MIDDLE_AND_RING,
    //    BIOB_FINGERPRINT_RIGHT_RING_AND_LITTLE,
    //    BIOB_FINGERPRINT_LEFT_INDEX_AND_MIDDLE,
    //    BIOB_FINGERPRINT_LEFT_MIDDLE_AND_RING,
    //    BIOB_FINGERPRINT_LEFT_RING_AND_LITTLE,
    //    BIOB_FINGERPRINT_BOTH_INDEXES,
    //    BIOB_FINGERPRINT_RIGHT_INDEX_AND_MIDDLE_AND_RING = 47,

    //    BIOB_FINGERPRINT_RIGHT_MIDDLE_AND_RING_AND_LITTLE,
    //    BIOB_FINGERPRINT_LEFT_INDEX_AND_MIDDLE_AND_RING,
    //    BIOB_FINGERPRINT_LEFT_MIDDLE_AND_RING_AND_LITTLE,
    //    BIOB_FINGERPRINT_RESERVED = BioBModalityOffsetsTypes.BIOB_FINGERPRINT_RANGE_END,

    //    BIOB_IRIS_UNKNOWN = BioBModalityOffsetsTypes.BIOB_IRIS_RANGE_START,

    //    BIOB_IRIS_LEFT,
    //    BIOB_IRIS_RIGHT,
    //    BIOB_IRIS_BOTH,
    //    BIOB_IRIS_RESERVED = BioBModalityOffsetsTypes.BIOB_IRIS_RANGE_END,

    //    BioB_FACE_UNKNOWN = BioBModalityOffsetsTypes.BIOB_FACE_RANGE_START,
    //    BIOB_FACE_RESERVED = BioBModalityOffsetsTypes.BIOB_FACE_RANGE_END,

    //    BioB_EAR_UNKNOWN = BioBModalityOffsetsTypes.BIOB_EAR_RANGE_START,
    //    BIOB_EAR_RESERVED = BioBModalityOffsetsTypes.BIOB_EAR_RANGE_END,

    //    BioB_FACE_THERMO_UNKNOWN = BioBModalityOffsetsTypes.BIOB_FACE_THERMO_RANGE_START,
    //    BioB_FACE_THERMO_RESERVED = BioBModalityOffsetsTypes.BIOB_FACE_THERMO_RANGE_END,

    //    BIOB_HAND_THERMO_UNKNOWN = BioBModalityOffsetsTypes.BIOB_HAND_THERMO_RANGE_START,
    //    BIOB_HAND_THERMO_RESERVED = BioBModalityOffsetsTypes.BIOB_HAND_THERMO_RANGE_END,

    //    BIOB_HAND_VEIN_UNKNOWN = BioBModalityOffsetsTypes.BIOB_HAND_VEIN_RANGE_START,
    //    BIOB_HAND_VEIN_RESERVED = BioBModalityOffsetsTypes.BIOB_HAND_VEIN_RANGE_END,

    //    BIOB_HAND_GEOM_UNKNOWN = BioBModalityOffsetsTypes.BIOB_HAND_GEOM_RANGE_START,
    //    BIOB_HAND_GEOM_RESERVED = BioBModalityOffsetsTypes.BIOB_HAND_GEOM_RANGE_END,

    //    BIOB_RETINA_UNKNOWN = BioBModalityOffsetsTypes.BIOB_RETINA_RANGE_START,
    //    BIOB_RETINA_RESERVED = BioBModalityOffsetsTypes.BIOB_RETINA_RANGE_END,

    //    BIOB_SIGNATURE_UNKNOWN = BioBModalityOffsetsTypes.BIOB_SIGNATURE_RANGE_START,
    //    BIOB_SIGNATURE_RESERVED = BioBModalityOffsetsTypes.BIOB_SIGNATURE_RANGE_END,

    //    BIOB_VOICE_UNKNOWN = BioBModalityOffsetsTypes.BIOB_VOICE_RANGE_START,
    //    BIOB_VOICE_RESERVED = BioBModalityOffsetsTypes.BIOB_VOICE_RANGE_END
    //}

    //public enum BioBImpressionTypes
    //{
    //    BIOB_IMPRESSION_UNKNOWN = 0,    // Impression not known

    //    BIOB_FINGERPRINT_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_FINGERPRINT_RANGE_START,
    //    BIOB_FINGERPRINT_IMP_ROLL,
    //    BIOB_FINGERPRINT_IMP_FLAT,
    //    BIOB_FINGERPRINT_IMP_ROLL_VERTICAL,
    //    BIOB_FINGERPRINT_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_FINGERPRINT_RANGE_END,

    //    BIOB_IRIS_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_IRIS_RANGE_START,
    //    BIOB_IRIS_IMP_REGULAR,
    //    BIOB_IRIS_IMP_ATADISTANCE,
    //    BIOB_IRIS_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_IRIS_RANGE_END,

    //    BIOB_FACE_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_FACE_RANGE_START,
    //    BIOB_FACE_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_FACE_RANGE_END,

    //    BIOB_EAR_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_EAR_RANGE_START,
    //    BIOB_EAR_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_EAR_RANGE_END,

    //    BIOB_FACE_THERMO_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_FACE_THERMO_RANGE_START,
    //    BIOB_FACE_THERMO_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_FACE_THERMO_RANGE_END,

    //    BIOB_HAND_THERMO_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_HAND_THERMO_RANGE_START,
    //    BIOB_HAND_THERMO_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_HAND_THERMO_RANGE_END,

    //    BIOB_HAND_VEIN_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_HAND_VEIN_RANGE_START,
    //    BIOB_HAND_VEIN_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_HAND_VEIN_RANGE_END,

    //    BIOB_HAND_GEOM_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_HAND_GEOM_RANGE_START,
    //    BIOB_HAND_GEOM_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_HAND_GEOM_RANGE_END,

    //    BIOB_RETINA_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_RETINA_RANGE_START,
    //    BIOB_RETINA_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_RETINA_RANGE_END,

    //    BIOB_SIGNATURE_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_SIGNATURE_RANGE_START,
    //    BIOB_SIGNATURE_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_SIGNATURE_RANGE_END,

    //    BIOB_VOICE_IMP_UNKNOWN = BioBModalityOffsetsTypes.BIOB_VOICE_RANGE_START,
    //    BIOB_VOICE_IMP_RESERVED = BioBModalityOffsetsTypes.BIOB_VOICE_RANGE_END
    //}

    //public enum BioBVisualizers
    //{
    //    None,
    //    FingerWnd,
    //    RightEyeWnd,
    //    LeftEyeWnd,
    //    FaceCenterWnd,
    //    FaceRightWnd,
    //    FaceLeftWnd
    //}

}
