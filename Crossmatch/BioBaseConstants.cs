namespace Crossmatch
{
    public class BioBaseConstants
    {
        #region XML generals
        public const string XMLNS = "xmlns:xsi";
        public const string XMLNS_URL = "http://www.w3.org/2001/XMLSchema-instance";
        public const string XML_SCHEMA = "xsi:noNamespaceSchemaLocation";
        public const string XML_SCHEMA_NAME = "BioBase.xsd";
        public const string XML_ROOT = "BioBase";
        public const string XML_ROOT_INTERFACE_VERSION = "Version";
        public const string XML_ROOT_INTERFACE_VERSION_NUMBER = "4.0";
        #endregion

        #region DeviceProperties - prefix: DEV_ID_
        public const string DEV_ID_DEVICE_ID_LIST = "DeviceIdentifierList";
        public const string DEV_ID_DEVICE = "Device";
        public const string DEV_ID_MODEL_NAME = "ModelName";
        public const string DEV_ID_SERIAL_NUMBER = "SerNum";
        public const string DEV_ID_INTERFACE = "Interface";
        public const string DEV_ID_DEVICE_ID = "DeviceId";
        public const string DEV_ID_MODALITY_TYPE = "Modality";
        #endregion

        #region ApiProperties - prefix: API_PROP_
        public const string API_PROP_API_PROPERTIES = "ApiProperties";
        public const string API_PROP_API = "Api";
        public const string API_PROP_API_LSCAN_ESSENTIALS = "LSE";
        public const string API_PROP_API_MOBILE_ESSENTIALS = "ME";
        public const string API_PROP_API_VERIFIER_ESSENTIALS = "VE";
        public const string API_PROP_API_ISCAN_ESSENTIALS = "ISE";
        public const string API_PROP_API_MUGSHOT_ESSENTIALS = "MSE";
        public const string API_PROP_API_FSCAN_ESSENTIALS = "FSE";
        public const string API_PROP_FILE = "File";
        public const string API_PROP_PRODUCT = "Product";
        #endregion

        #region DeviceProperties - prefix: DEV_PROP_
        public const string DEV_PROP_DEVICE_PROPERTIES = "DeviceProperties";
        public const string DEV_PROP_PROPERTY = "Property";
        public const string DEV_PROP_LISTPROPERTY = "ListProperty";
        public const string DEV_PROP_NAME = "Name";
        public const string DEV_PROP_READONLY = "ReadOnly";
        public const string DEV_PROP_VALUE = "Value";
        #endregion

        #region DeviceProperties - values
        public const string DEV_PROP_TRUE = "TRUE";
        public const string DEV_PROP_FALSE = "FALSE";
        public const string DEV_PROP_NOT_SET = "NotSet";
        #endregion

        #region Interface Type
        public const string DEV_PROP_FIREWIRE = "Firewire";
        public const string DEV_PROP_USB = "USB";
        public const string DEV_PROP_WIFI = "WiFi";
        public const string DEV_PROP_BLUETOOTH = "BlueTooth";
        public const string DEV_PROP_URI = "URI";
        #endregion

        #region Illumination Modes
        public const string DEV_PROP_ILLUMINATION_AUTO = "IlluminationAuto";
        public const string DEV_PROP_ILLUMINATION_OFF = "IlluminationOff";
        public const string DEV_PROP_ILLUMINATION_TORCH = "IlluminationTorch";
        #endregion

        #region Color Space
        public const string DEV_PROP_RGB24 = "RGBColor24";
        public const string DEV_PROP_GRAY_SCALE = "GrayScale";
        #endregion

        #region Image Impression Types:
        public const string DEV_PROP_IMPR_TYPE_UNKNOWN = "ImpressionUnknown";
        public const string DEV_PROP_IMPR_TYPE_FINGERPRINT_ROLL = "FingerprintRoll";
        public const string DEV_PROP_IMPR_TYPE_FINGERPRINT_FLAT = "FingerprintFlat";
        public const string DEV_PROP_IMPR_TYPE_FINGERPRINT_ROLL_VERTICAL = "FingerprintRollVertical";
        public const string DEV_PROP_IMPR_TYPE_FINGERPRINT_UNKNOWN = "UnknownFinger";
        public const string DEV_PROP_IMPR_TYPE_IRIS_REGULAR = "IrisRegular";
        public const string DEV_PROP_IMPR_TYPE_IRIS_ATA_DIST = "IrisAtaDistance";
        public const string DEV_PROP_IMPR_TYPE_IRIS_UNKNOWN = "UnknownIris";
        public const string DEV_PROP_IMPR_TYPE_FACE_STATIC_PHOTO_UNKNOWN_SOURCE = "FaceStaticPhotoUnknownSource";
        public const string DEV_PROP_IMPR_TYPE_FACE_STATIC_PHOTO_STILL_CAM = "FaceStaticPhotoStillCamera";
        public const string DEV_PROP_IMPR_TYPE_FACE_STATIC_PHOTO_SCANNER = "FaceStaticPhotoScanner";
        public const string DEV_PROP_IMPR_TYPE_FACE_SINGLE_VIDEO_UNKNOWN_SOURCE = "FaceSingleVideoUnknownSource";
        public const string DEV_PROP_IMPR_TYPE_FACE_SINGLE_VIDEO_DIGITAL_VIDEO_CAM = "FaceSingleVideoDigitalVideoCamera";
        public const string DEV_PROP_IMPR_TYPE_FACE_UNKNOWN = "UnknownFace";
        public const string DEV_PROP_IMPR_TYPE_RESERVED = "ImpressionReserved";
        #endregion

        #region Image Position Types:
        public const string DEV_PROP_POS_TYPE_UNKNOWN = "PositionUnknown";
        public const string DEV_PROP_POS_TYPE_RIGHT_THUMB = "RightThumb";
        public const string DEV_PROP_POS_TYPE_RIGHT_INDEX = "RightIndex";
        public const string DEV_PROP_POS_TYPE_RIGHT_MIDDLE = "RightMiddle";
        public const string DEV_PROP_POS_TYPE_RIGHT_RING = "RightRing";
        public const string DEV_PROP_POS_TYPE_RIGHT_LITTLE = "RightLittle";
        public const string DEV_PROP_POS_TYPE_LEFT_THUMB = "LeftThumb";
        public const string DEV_PROP_POS_TYPE_LEFT_INDEX = "LeftIndex";
        public const string DEV_PROP_POS_TYPE_LEFT_MIDDLE = "LeftMiddle";
        public const string DEV_PROP_POS_TYPE_LEFT_RING = "LeftRing";
        public const string DEV_PROP_POS_TYPE_LEFT_LITTLE = "LeftLittle";
        public const string DEV_PROP_POS_TYPE_RIGHT_FOUR_FINGERS = "RightFour";    //<  right 4 fingers
        public const string DEV_PROP_POS_TYPE_LEFT_FOUR_FINGERS = "LeftFour";      //<  left 4 fingers
        public const string DEV_PROP_POS_TYPE_BOTH_THUMBS = "BothThumbs";          //<  both thumbs

        public const string DEV_PROP_POS_TYPE_BOTH_INDEXES_AND_MIDDLES = "LeftMiddleAndIndexAndRightIndexAndMiddle";

        public const string DEV_PROP_POS_TYPE_TWO_FINGERS = "TwoFingers";
        public const string DEV_PROP_POS_TYPE_RIGHT_FULL_PALM = "RightFullPalm";
        public const string DEV_PROP_POS_TYPE_RIGHT_WRITERS_PALM = "RightWritersPalm";
        public const string DEV_PROP_POS_TYPE_LEFT_FULL_PALM = "LeftFullPalm";
        public const string DEV_PROP_POS_TYPE_LEFT_WRITERS_PALM = "LeftWritersPalm";
        public const string DEV_PROP_POS_TYPE_RIGHT_LOWER_PALM = "RightLowerPalm";
        public const string DEV_PROP_POS_TYPE_RIGHT_UPPER_PALM = "RightUpperPalm";
        public const string DEV_PROP_POS_TYPE_LEFT_LOWER_PALM = "LeftLowerPalm";
        public const string DEV_PROP_POS_TYPE_LEFT_UPPER_PALM = "LeftUpperPalm";
        public const string DEV_PROP_POS_TYPE_FINGERPRINT_UNKNOWN = "UnknownFinger";
        public const string DEV_PROP_POS_TYPE_RIGHT_INDEX_AND_MIDDLE = "RightIndexAndMiddle";
        public const string DEV_PROP_POS_TYPE_RIGHT_RING_AND_LITTLE = "RightRingAndLittle";
        public const string DEV_PROP_POS_TYPE_LEFT_INDEX_AND_MIDDLE = "LeftIndexAndMiddle";
        public const string DEV_PROP_POS_TYPE_LEFT_RING_AND_LITTLE = "LeftRingAndLittle";


        public const string DEV_PROP_POS_TYPE_LEFT_IRIS = "LeftIris";
        public const string DEV_PROP_POS_TYPE_RIGHT_IRIS = "RightIris";
        public const string DEV_PROP_POS_TYPE_BOTH_IRIS = "BothIris";
        public const string DEV_PROP_POS_TYPE_IRIS_UNKNOWN = "UnknownIris";

        public const string DEV_PROP_POS_TYPE_FRONTAL = "FrontalFace";
        public const string DEV_PROP_POS_TYPE_FULL_FRONTAL = "FullFrontalFace";
        public const string DEV_PROP_POS_TYPE_TOKEN_FRONTAL = "TokenFrontalFace";
        public const string DEV_PROP_POS_TYPE_RIGHT_PROFILE = "RightProfileFace";
        public const string DEV_PROP_POS_TYPE_LEFT_PROFILE = "LeftProfileFace";
        public const string DEV_PROP_POS_TYPE_RIGHT_ANGLED = "RightAngledFace";
        public const string DEV_PROP_POS_TYPE_LEFT_ANGLED = "LeftAngledFace";
        public const string DEV_PROP_POS_TYPE_FACE_UNKNOWN = "UnknownFace";
        #endregion

        #region Image Modality Types:
        public const string DEV_PROP_MODALITY_UNKNOWN = "ModalityUnknown";
        public const string DEV_PROP_MODALITY_FINGERPRINT = "Finger";
        public const string DEV_PROP_MODALITY_IRIS = "Iris";
        public const string DEV_PROP_MODALITY_FACE = "Face";
        #endregion

        #region Encoding Types:
        public const string DEV_PROP_ENCODING_JTC1_19794_4_2005 = "JTC1_19794_4:2005";
        public const string DEV_PROP_ENCODING_INCITS_381_2004 = "INCITS_381-2004";
        public const string DEV_PROP_ENCODING_JTC1_19794_5_2005 = "JTC1_19794_5:2005";
        public const string DEV_PROP_ENCODING_INCITS_385_2004 = "INCITS_385-2004";
        public const string DEV_PROP_ENCODING_JTC1_19794_6_2005 = "JTC1_19794_6:2005";
        public const string DEV_PROP_ENCODING_BMP = "BMP";
        public const string DEV_PROP_ENCODING_JPG = "JPG";
        #endregion

        #region Preview image levels
        public const string DEV_PROP_PREVIEW_LEVEL_LOW = "Low";
        public const string DEV_PROP_PREVIEW_LEVEL_MEDIUM = "Medium";
        public const string DEV_PROP_PREVIEW_LEVEL_HIGH = "High";
        #endregion

        #region Property Names
        public const string DEV_PROP_HORIZONTAL_TRANSFORM = "HORIZONTAL_TRANSFORM";
        public const string DEV_PROP_VERTICAL_TRANSFORM = "VERTICAL_TRANSFORM";
        public const string DEV_PROP_INVERT_TRANSFORM = "INVERT_TRANSFORM";
        public const string DEV_PROP_ROTATE_TRANSFORM = "ROTATE_TRANSFORM";

        public const string DEV_PROP_IN_QUEUE_CNT = "IN_COMING_QUEUE_COUNT";
        public const string DEV_PROP_OUT_QUEUE_CNT = "OUT_GOING_QUEUE_COUNT";
        public const string DEV_PROP_IN_QUEUE_DELETE = "IN_COMING_QUEUE_DELETE";
        public const string DEV_PROP_OUT_QUEUE_DELETE = "OUT_GOING_QUEUE_DELETE";

        // BioBase 4 replaces image width and height with image dimension
        public const string DEV_PROP_IMAGE_BUFFER_SIZE = "IMAGE_BUFFER_SIZE";

        public const string DEV_PROP_IMAGE_ACQUISITIONS = "IMAGE_ACQUISITIONS";    //< count of images taken with device
        public const string DEV_PROP_IMAGE_RESOLUTION = "IMAGE_RESOLUTION";        //< currently used image resolution

        public const string DEV_PROP_AVAILABLE_IMAGE_DIMENSIONS = "AVAILABLE_IMAGE_DIMENSIONS";
        public const string DEV_PROP_IMAGE_DIMENSION = "IMAGE_DIMENSION";

        public const string DEV_PROP_OBJECT_QUALITY_FOLLOWS_PHYSICAL_LOCATION = "OBJECT_QUALITY_FOLLOWS_PHYSICAL_LOCATION";

        public const string DEV_PROP_AUTOCAPTURE_ALLOW_OBJECT_ON_BORDER = "AUTOCAPTURE_ALLOW_OBJECT_ON_BORDER";    //< allow AutoCapture to trigger even if finger/hand is at platen border
        public const string DEV_PROP_AUTOCAPTURE_NUM_RQD_OBJECTS = "AUTOCAPTURE_NUM_RQD_OBJECTS";                  //< count of finger objects required for successful AutoCapture 
        public const string DEV_PROP_AUTOCAPTURE_ON = "AUTOCAPTURE_ON";                                            //< use AutoCapture for result image acquisition trigger
        public const string DEV_PROP_AUTOCAPTURE_OVERRIDE_ON = "AUTOCAPTURE_OVERRIDE_ON";                          //< allow AutoCapture to alternatively trigger (a.k.a. override) on insufficient conditions
        public const string DEV_PROP_AUTOCAPTURE_OVERRIDE_TIME = "AUTOCAPTURE_OVERRIDE_TIME";                      //< AutoCapture delay for trigger on insufficient conditions (@ref DEV_PROP_AUTOCAPTURE_OVERRIDE_ON needs to be set)
        public const string DEV_PROP_AUTOCAPTURE_PROFILE = "AUTOCAPTURE_PROFILE";                                  //< index of AutoCapture profile to read and use from LScanEssentials.ini file
        public const string DEV_PROP_AUTOCAPTURE_TRACKING_TIME = "AUTOCAPTURE_TRACKING_TIME";
        public const string DEV_PROP_AUTOCAPTURE_OVERRIDE_MODE = "AUTOCAPTURE_OVERRIDE_MODE";
        public const string DEV_PROP_AUTOCAPTURE_THRESHOLD = "AUTOCAPTURE_THRESHOLD";
        #endregion

        #region! AutoCapture override modes
        public const string DEV_PROP_ON_INSUFFICIENT_COUNT = "OnInsufficientCount";        //< triggers AutoCapture on insufficient object count
        public const string DEV_PROP_ON_INSUFFICIENT_QUALITY = "OnInsufficientQuality";    //< triggers AutoCapture on insufficient object quality

        public const string DEV_PROP_AUTOCONTRAST_ON = "AUTOCONTRAST_ON";                  //<  perform an automatic contrast optimization prior to image capture
        public const string DEV_PROP_AUTOCONTRAST_WAIT_TIME = "AUTOCONTRAST_WAIT_TIME";    //< time for automatic contrast optimization to start after finger placement

        public const string DEV_PROP_BACKGROUND_STREAMING = "BACKGROUND_STREAMING";        //< keep internal video stream active to minimize delay on next acquisition start 
        public const string DEV_PROP_DEVICE_AUTO_ADJUSTMENT = "DEVICE_AUTO_ADJUSTMENT";    //< automatic device readjustment in predefined intervals
        public const string DEV_PROP_DEVICE_AUTOCAPTURE_SUPPORTED = "DEVICE_AUTOCAPTURE_SUPPORTED";//< AutoCapture is supported/licensed
        public const string DEV_PROP_SPOOF_DETECTION_ON = "SPOOF_DETECTION_ON";                                            //< use spoof detection for result image analysis
        public const string DEV_PROP_DEVICE_SPOOF_DETECTION_SUPPORTED = "DEVICE_SPOOF_DETECTION_SUPPORTED";                //< spoof detection is supported/licensed
        public const string DEV_PROP_DEVICE_SPOOF_DETECTION_CONFIDENCE_LEVEL = "DEVICE_SPOOF_DETECTION_CONFIDENCE_LEVEL";  //< level of confidence for spoof detection
        public const string DEV_PROP_DEVICE_AVAILABLE_IMAGE_RESOLUTIONS = "DEVICE_AVAILABLE_IMAGE_RESOLUTIONS";    //< list of all supported image resolutions
        public const string DEV_PROP_DEVICE_AVAILABLE_IMPRESSION_TYPES = "DEVICE_AVAILABLE_IMPRESSION_TYPES";      //< list of all supported impression types
        public const string DEV_PROP_DEVICE_AVAILABLE_VIS_MODES = "DEVICE_AVAILABLE_VIS_MODES";
        public const string DEV_PROP_DEVICE_AVAILABLE_KEYS = "DEVICE_AVAILABLE_KEYS";  //< list of all supported keys
        public const string DEV_PROP_DEVICE_AVAILABLE_LEDS = "DEVICE_AVAILABLE_LEDS";  //< list of all supported LEDs
        public const string DEV_PROP_DEVICE_AVAILABLE_POSITION_TYPES = "DEVICE_AVAILABLE_POSITION_TYPES";  //< list of all supported position types
        public const string DEV_PROP_DEVICE_AVAILABLE_MODALITY_TYPES = "DEVICE_AVAILABLE_MODALITY";        //< list of all supported modality types
        public const string DEV_PROP_DEVICE_CERTIFICATION_LEVEL = "DEVICE_CERTIFICATION_LEVEL";
        public const string DEV_PROP_DEVICE_CONTRAST_VALUE = "DEVICE_CONTRAST_VALUE";      //< current image contrast value (0 .. DEV_PROP_DEVICE_MAX_CONTRAST) 
        public const string DEV_PROP_DEVICE_FIRMWARE = "DEVICE_FIRMWARE";                  //< firmware version of device
        public const string DEV_PROP_DEVICE_HEATER_BOOST_MODE = "DEVICE_HEATER_BOOST_MODE";
        public const string DEV_PROP_DEVICE_INFIELD_TEST_SUPPORTED = "DEVICE_INFIELD_TEST_SUPPORTED";
        public const string DEV_PROP_DEVICE_INTERFACE_TYPE = "DEVICE_INTERFACE_TYPE";
        public const string DEV_PROP_DEVICE_ADDRESS = "DEVICE_ADDRESS";
        public const string DEV_PROP_DEVICE_KEYPAD_TYPE = "DEVICE_KEYPAD_TYPE";
        public const string DEV_PROP_DEVICE_LED_TYPE = "DEVICE_LED_TYPE";
        public const string DEV_PROP_DEVICE_BEEPER_TYPE = "DEVICE_BEEPER_TYPE";
        public const string DEV_PROP_DEVICE_MAX_CONTRAST = "DEVICE_MAX_CONTRAST_VALUE";
        public const string DEV_PROP_DEVICE_NAME = "DEVICE_NAME";
        public const string DEV_PROP_DEVICE_POWER_ON_TIME = "DEVICE_POWER_ON_TIME";
        public const string DEV_PROP_DEVICE_PREVIEW_IMAGES_SUPPORTED = "DEVICE_PREVIEW_IMAGES_SUPPORTED";
        public const string DEV_PROP_DEVICE_PRODUCTION_DATE = "DEVICE_PRODUCTION_DATE";
        public const string DEV_PROP_DEVICE_RESETS = "DEVICE_RESETS";
        public const string DEV_PROP_DEVICE_REVISION_NUMBER = "DEVICE_REVISION_NUMBER"; //< revision version of device
        public const string DEV_PROP_DEVICE_SERIAL_NUMBER = "DEVICE_SERIAL_NUMBER";     //< serial number of device
        public const string DEV_PROP_DEVICE_SERVICE_DATE = "DEVICE_SERVICE_DATE";       //< date of last service
        public const string DEV_PROP_DEVICE_SILICONE_PAD = "DEVICE_SILICONE_MEMBRANE";  //< device is equipped with a silicone membrane
        public const string DEV_PROP_DEVICE_STANDBY_TIME = "DEVICE_STANDBY_TIME";       //< device standby time in seconds

        public const string DEV_PROP_SILICONE_MEMBRANE_REPLACE = "DEVICE_SILICONE_MEMBRANE_REPLACE";   //< A new silicone membrane has been installed on the device.

        public const string DEV_PROP_SILICONE_MEMBRANE_MAX_LIFE_DAYS = "SILICONE_MEMBRANE_MAX_LIFE_DAYS";      //< device silicone membrane's maximum life in number of days
        public const string DEV_PROP_SILICONE_MEMBRANE_MAX_USAGE_COUNT = "SILICONE_MEMBRANE_MAX_USAGE_COUNT";  //< device silicone membrane's maximum life in count of usages
        public const string DEV_PROP_SILICONE_MEMBRANE_CURRENT_USAGE_COUNT = "SILICONE_MEMBRANE_CURRENT_USAGE_COUNT";  //< device silicone membrane's current count of usages
        public const string DEV_PROP_SILICONE_MEMBRANE_REPLACEMENT_DATE = "SILICONE_MEMBRANE_REPLACEMENT_DATE";        //< device silicone membrane's replacement date

        public const string DEV_PROP_DEVICE_CLEANLINESS_LEVEL = "DEVICE_CLEANLINESS_LEVEL";                    //< [get] Last result of surface cleanliness check 


        public const string DEV_PROP_IBIA_DEVICE_ID = "IBIA_DEVICE_ID";
        public const string DEV_PROP_IBIA_VENDOR_ID = "IBIA_VENDOR_ID";
        public const string DEV_PROP_IBIA_VERSION = "IBIA_VERSION";

        public const string DEV_PROP_ILLUMINATION_MODE = "ILLUMINATION_MODE";
        public const string DEV_PROP_COLOR_SPACE = "COLOR_SPACE";

        public const string DEV_PROP_ENCODING_FORMAT = "ENCODING_FORMAT";
        public const string DEV_PROP_ENCODING_FORMATS_SUPPORTED = "ENCODING_FORMATS_SUPPORTED";
        #endregion

        #region 19794-5 standard properties
        public const string DEV_PROP_FACE_GENDER = "FACE_GENDER";
        public const string DEV_PROP_FACE_EYE_COLOR = "FACE_EYE_COLOR";
        public const string DEV_PROP_FACE_HAIR_COLOR = "FACE_HAIR_COLOR";
        public const string DEV_PROP_FACE_PROPERTY_MASK = "FACE_PROPERTY_MASK";
        public const string DEV_PROP_FACE_EXPRESSION = "FACE_EXPRESSION";
        #endregion

        #region new generic properties for preview
        public const string DEV_PROP_PREVIEW_IMAGE_FORMAT = "PREVIEW_IMAGE_FORMAT";
        public const string DEV_PROP_DEVICE_PREVIEW_FRAME_RATE = "DEVICE_FRAME_RATE";
        public const string DEV_PROP_PREVIEW_LEVEL = "PREVIEW_LEVEL";  //< quality level (size/resolution) of images delivered by preview callbacks
        public const string DEV_PROP_AVAILABLE_PREVIEW_LEVELS = "AVAILABLE_PREVIEW_LEVELS";
        #endregion

        #region Fingerprint Specific Properties
        public const string DEV_PROP_DEVICE_FINGERPRINT_ROLLING_SUPPORTED = "DEVICE_FINGERPRINT_ROLLING_SUPPORTED";  //< finger print rolling is supported/licensed
        public const string DEV_PROP_ROLL_ALLOW_RESTART = "ROLL_ALLOW_RESTART";    //< roll distance to trigger roll start detection if option @ref DEV_PROP_AUTOCAPTURE_ON is used for finger print rolling
        public const string DEV_PROP_ROLL_MIN_DISTANCE = "ROLL_MIN_DISTANCE";      //< defines the threshold for automatic recapture if option @ref DEV_PROP_AUTOCAPTURE_ON is used
        public const string DEV_PROP_ROLL_MIN_WIDTH = "ROLL_MIN_WIDTH";            //< defines the threshold for automatic recapture if option @ref DEV_PROP_AUTOCAPTURE_ON is used
        public const string DEV_PROP_ROLL_PROFILE = "ROLL_PROFILE";                //< index of predefined roll profile to use for fingerprint rolling
        public const string DEV_PROP_ROLL_START_DISTANCE = "ROLL_START_DISTANCE";  //< roll distance to trigger roll start detection if option @ref DEV_PROP_AUTOCAPTURE_ON is used for finger print rolling
        public const string DEV_PROP_ROLL_TIMEOUT_LIFT = "ROLL_TIMEOUT_LIFT";      //< time to wait for finger re-placement to recapture a rolled fingerprint after finger is lifted
        #endregion

        #region OutputData - prefix: OUT_DATA_
        public const string OUT_DATA_OUTPUTDATA = "OutputData";

        public const string OUT_DATA_BEEPER = "Beeper";
        public const string OUT_DATA_BEEP_PATTERN = "Pattern";
        public const string OUT_DATA_BEEP_VOLUME = "Volume";

        public const string OUT_DATA_STATUSLEDS = "StatusLeds";
        public const string OUT_DATA_LED = "Led";
        public const string OUT_DATA_LED_NONE = "NONE";

        public const string OUT_DATA_ACTIVEBUTTONS = "ActiveDeviceButtons";
        public const string OUT_DATA_KEY = "Key";
        public const string OUT_DATA_KEY_NONE = "NONE";
        public const string OUT_DATA_KEY_OK = "OK";
        public const string OUT_DATA_KEY_CANCEL = "CANCEL";
        public const string OUT_DATA_KEY_UP = "UP";
        public const string OUT_DATA_KEY_RIGHT = "RIGHT";
        public const string OUT_DATA_KEY_DOWN = "DOWN";
        public const string OUT_DATA_KEY_LEFT = "LEFT";
        public const string OUT_DATA_KEY_FOOTSWITCH = "FOOTSWITCH";
        public const string OUT_DATA_KEY_TOUCH_DISPLAY = "TOUCH_DISPLAY";

        public const string OUT_DATA_OVERLAY = "VisualizationOverlay";
        public const string OUT_DATA_OVERLAY_TEXT = "Text";
        public const string OUT_DATA_OVERLAY_TEXT_POSX = "PosX";
        public const string OUT_DATA_OVERLAY_TEXT_POSY = "PosY";
        public const string OUT_DATA_OVERLAY_TEXT_COLOR = "Color";
        public const string OUT_DATA_OVERLAY_TEXT_FONT_NAME = "FontName";
        public const string OUT_DATA_OVERLAY_TEXT_FONT_SIZE = "FontSize";
        public const string OUT_DATA_OVERLAY_TEXT_BELONGS_TO_IMAGE = "BelongsToImage";
        public const string OUT_DATA_OVERLAY_TEXT_VALUE = "Value";
        public const string OUT_DATA_OVERLAY_LINE = "Line";
        public const string OUT_DATA_OVERLAY_LINE_X1 = "X1";
        public const string OUT_DATA_OVERLAY_LINE_Y1 = "Y1";
        public const string OUT_DATA_OVERLAY_LINE_X2 = "X2";
        public const string OUT_DATA_OVERLAY_LINE_Y2 = "Y2";
        public const string OUT_DATA_OVERLAY_LINE_COLOR = "Color";
        public const string OUT_DATA_OVERLAY_LINE_LINE_WIDTH = "LineWidth";
        public const string OUT_DATA_OVERLAY_LINE_BELONGS_TO_IMAGE = "BelongsToImage";
        public const string OUT_DATA_OVERLAY_QUADRANGLE = "Quadrangle";
        public const string OUT_DATA_OVERLAY_QUAD_X1 = "X1";
        public const string OUT_DATA_OVERLAY_QUAD_Y1 = "Y1";
        public const string OUT_DATA_OVERLAY_QUAD_X2 = "X2";
        public const string OUT_DATA_OVERLAY_QUAD_Y2 = "Y2";
        public const string OUT_DATA_OVERLAY_QUAD_X3 = "X3";
        public const string OUT_DATA_OVERLAY_QUAD_Y3 = "Y3";
        public const string OUT_DATA_OVERLAY_QUAD_X4 = "X4";
        public const string OUT_DATA_OVERLAY_QUAD_Y4 = "Y4";
        public const string OUT_DATA_OVERLAY_QUAD_COLOR = "Color";
        public const string OUT_DATA_OVERLAY_QUAD_LINE_WIDTH = "LineWidth";
        public const string OUT_DATA_OVERLAY_QUAD_BELONGS_TO_IMAGE = "BelongsToImage";
        #endregion

        #region Touchscreen defines
        public const string OUT_DATA_TOUCHDISPLAY = "TouchDisplay";
        public const string OUT_DATA_TOUCHDISPLAY_DESIGNTEMPLATE = "DesignTemplate";
        public const string OUT_DATA_TOUCHDISPLAY_URI = "URI";
        public const string OUT_DATA_TOUCHDISPLAY_EXTERNAL_PARAMETER = "ExternalParameter";
        public const string OUT_DATA_TOUCHDISPLAY_EXTERNAL_PARAMETER_KEY = "Key";
        public const string OUT_DATA_TOUCHDISPLAY_EXTERNAL_PARAMETER_VALUE = "Value";
        public const string IN_DATA_PRESSED_ITEM_ID = "PressedItemId";
        #endregion

        #region  InputData - prefix: IN_DATA_
        public const string IN_DATA_INPUTDATA = "InputData";
        public const string IN_DATA_PRESSED_BUTTONS = "PressedDeviceButtons";
        public const string IN_DATA_PRESSED_KEY = "Key";
        #endregion

        #region Parameter values for BioB_AdjustAcquisitionProcess()
        public const string PROC_ADJUST_TYPE_UNKNOWN = "PROCESS_ADJUST_TYPE_UNKNOWN";
        public const string PROC_ADJUST_TYPE_OPTIMIZE_CONTRAST = "PROCESS_ADJUST_TYPE_OPTIMIZE_CONTRAST";
        #endregion

        #region Specific LSE FROM Biob defs common
        public const string DEV_ID_VISUALIZERS = "Visualizers";
        public const string DEV_ID_VIS_FINGER_WND = "FingerWnd";
        public const string DEV_ID_VIS_RIGHT_EYE_WND = "RightEyeWnd";
        public const string DEV_ID_VIS_LEFT_EYE_WND = "LeftEyeWnd";
        #endregion

        #region Device Specific LSE data
        public static string DEV_PROP_RESOLUTION_500 = "500";   ///< 500 pixels per inch
        public static string DEV_PROP_RESOLUTION_508 = "508";   ///< 508 pixels per inch
        public static string DEV_PROP_RESOLUTION_1000 = "1000"; ///< 1000 pixels per inch
        public static string DEV_PROP_DEFAULT_BK_COLOR = "255 255 255";       ///< default background color
        public static string DEV_PROP_DEFAULT_ACTIVE_AREA = "0 0 3200 3000";  ///< default active area

        public const string DEV_PROP_KEYPAD_2_KEYS = "KEYPAD_2_KEYS";  ///< 2 keys: OK, Cancel
        public const string DEV_PROP_KEYPAD_4_KEYS = "KEYPAD_4_KEYS";  ///< 4 keys
        public const string DEV_PROP_KEYPAD_5_KEYS = "KEYPAD_5_KEYS";  ///< 5 keys
        public const string DEV_PROP_KEYPAD_TOUCH_DISPLAY = "KEYPAD_TOUCH_DISPLAY";  ///< touchscreen
        public const string DEV_PROP_KEYPAD_NONE = "KEYPAD_NONE";      ///< no keys

        public const string DEV_PROP_LED_TYPE_STATUS = "LED_TYPE_STATUS";
        public const string DEV_PROP_LED_TYPE_LSCAN = "LED_TYPE_LSCAN";   ///< 8 LEDs (LSCAN Guardian)
        public const string DEV_PROP_LED_TYPE_LSCAN_DISPLAY_EMULATION = "LED_TYPE_LSCAN_DISPLAY_EMULATION"; ///< LScan TFT display with 500dpi
        public const string DEV_PROP_LED_TYPE_LSCAN_DISPLAY_EMULATION_1000PPI = "LED_TYPE_LSCAN_DISPLAY_EMULATION_1000PPI"; ///< LScan TFT display with 1000dpi
        public const string DEV_PROP_LED_TYPE_NONE = "LED_TYPE_NONE";     ///< no LEDs

        public const string DEV_PROP_BEEPER_NONE = "BEEPER_NONE";                             ///< No sound making beeper
        public const string DEV_PROP_BEEPER_GENERIC = "BEEPER_GENERIC";                       ///< Generic beeper (8 patterns)
        public const string DEV_PROP_BEEPER_GENERIC_VOLUME_4 = "BEEPER_GENERIC_VOLUME_4";     ///< generic beeper (8 patterns, volume setting)
        public const string DEV_PROP_BEEPER_GENERIC_VOLUME_64 = "BEEPER_GENERIC_VOLUME_64";   ///< generic beeper (8 patterns, volume setting)
        public const string DEV_PROP_BEEPER_GENERIC_VOLUME_256 = "BEEPER_GENERIC_VOLUME_256"; ///< generic beeper (8 patterns, volume setting)

        public const string DEV_PROP_PERFECTIMAGE_ON = "PERFECTIMAGE_ON";   ///< enables "PerfectImage" enhancement: if "TRUE" then image is automatically corrected for effects resulting from condensate and dirt on the platen
        #endregion

        #region visualization
        public const string DEV_PROP_VISUALIZATION_MODE = "VISUALIZATION_MODE";    ///<  LSE specific visualization mode to control visualization behavior
        public const string DEV_PROP_VISMODE_PREVIEW_ONLY = "PreviewOnly";         ///< show preview images only
        public const string DEV_PROP_VISMODE_RESULT = "Result";                    ///< show result images only
        public const string DEV_PROP_VISMODE_ALWAYS = "Always";                    ///< show preview and result images
        public const string DEV_PROP_VIS_NONE = "None";                            ///< do not show images

        public const string DEV_PROP_VISUALIZATION_BK_COLOR = "VISUALIZATION_BK_COLOR"; ///< list of RGB values of vis background
        public const string DEV_PROP_VISUALIZATION_FULLIMAGE_ON = "VISUALIZATION_FULLIMAGE_ON"; ///< scale images to fully fit into visualization area
        #endregion

        #region Device Specific LSE data for status LEDs
        public static string OUT_DATA_LED_OK_GREEN_B1 = "OK_GREEN_B1";   ///< Large right emulated LED Green slow blink for LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_OK_GREEN_B2 = "OK_GREEN_B2";   ///< Large right emulated LED Green fast flash LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_OK_GREEN = "OK_GREEN";         ///< Large right emulated LED Green on LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_OK_YELLOW_B1 = "OK_YELLOW_B1"; ///< Small right emulated LED Yellow slow blink LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_OK_YELLOW_B2 = "OK_YELLOW_B2"; ///< Small right emulated LED Yellow fast flash LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_OK_YELLOW = "OK_YELLOW";       ///< Small right emulated LED Yellow on LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_CANCEL_B1 = "CANCEL_B1";       ///< Small left emulated LED Red slow blink LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_CANCEL_B2 = "CANCEL_B2";       ///< Small left emulated LED Red fast flash LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public static string OUT_DATA_LED_CANCEL = "CANCEL";             ///< Small left emulated LED Red on LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500

        public static string OUT_DATA_LED_I1_RED_B1 = "I1_RED_B1";      ///< Left hand slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I1_RED_B2 = "I1_RED_B2";      ///< Left hand fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I2_RED_B1 = "I2_RED_B1";      ///< Left thumb slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I2_RED_B2 = "I2_RED_B2";      ///< Left thumb fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I3_RED_B1 = "I3_RED_B1";      ///< Right hand slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I3_RED_B2 = "I3_RED_B2";      ///< Right hand fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I4_RED_B1 = "I4_RED_B1";      ///< Right thumb slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I4_RED_B2 = "I4_RED_B2";      ///< Right thumb fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols

        public static string OUT_DATA_LED_I1_GREEN_B1 = "I1_GREEN_B1";  ///< Left hand slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I1_GREEN_B2 = "I1_GREEN_B2";  ///< Left hand fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I2_GREEN_B1 = "I2_GREEN_B1";  ///< Left thumb slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I2_GREEN_B2 = "I2_GREEN_B2";  ///< Left thumb fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I3_GREEN_B1 = "I3_GREEN_B1";  ///< Right hand slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I3_GREEN_B2 = "I3_GREEN_B2";  ///< Right hand fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I4_GREEN_B1 = "I4_GREEN_B1";  ///< Right thumb slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_I4_GREEN_B2 = "I4_GREEN_B2";  ///< Right thumb fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols

        public static string OUT_DATA_LED_S1_RED_B1 = "S1_RED_B1";      ///< position 1 status slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S1_RED_B2 = "S1_RED_B2";      ///< position 1 status fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S2_RED_B1 = "S2_RED_B1";      ///< position 2 status slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S2_RED_B2 = "S2_RED_B2";      ///< position 2 status fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S3_RED_B1 = "S3_RED_B1";      ///< position 3 status slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S3_RED_B2 = "S3_RED_B2";      ///< position 3 status fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S4_RED_B1 = "S4_RED_B1";      ///< position 4 status slow blink red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S4_RED_B2 = "S4_RED_B2";      ///< position 4 status fast flash red LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S1_GREEN_B1 = "S1_GREEN_B1";  ///< position 1 status slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S1_GREEN_B2 = "S1_GREEN_B2";  ///< position 1 status fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S2_GREEN_B1 = "S2_GREEN_B1";  ///< position 2 status slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S2_GREEN_B2 = "S2_GREEN_B2";  ///< position 2 status fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S3_GREEN_B1 = "S3_GREEN_B1";  ///< position 3 status slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S3_GREEN_B2 = "S3_GREEN_B2";  ///< position 3 status fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S4_GREEN_B1 = "S4_GREEN_B1";  ///< position 4 status slow blink green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols
        public static string OUT_DATA_LED_S4_GREEN_B2 = "S4_GREEN_B2";  ///< position 4 status fast flash green LED for Guardian USB, Guardian F, Guardian L, Guardian R Guardian R2 and Patrols

        #endregion

        #region Specific LSE TFT
        public const string OUT_DATA_TFT = "Tft";
        public const string OUT_DATA_TFT_LOG_SCREEN = "LogoScreen";   ///< Show logo screen on TFT display for LScan 1000P, LScan 1000T, LScan 500P, LScan 1000PX, LScan 1000 and LScan 500
        public const string OUT_DATA_TFT_LOG_SCR_OPTION = "Option";                    ///< starting XML element for logo screen options on TFT display
        public const string OUT_DATA_TFT_LOG_SCR_ERASE = "ERASE";                      ///< erase option area on logo screen on TFT display
        public const string OUT_DATA_TFT_LOG_SCR_SHOW_FW_VERSION = "SHOW_FW_VERSION";  ///< show firmware version on bottom of logo screen on TFT display
        public const string OUT_DATA_TFT_LOG_SCR_LEAVE_UNCHANGED = "LEAVE_UNCHANGED";  ///< do not modify item on logo screen on TFT display
        public const string OUT_DATA_TFT_LOG_SCR_PROGRESS = "ProgressBarPercent";      ///< Show ProgressBar on logo screen on TFT display

        public const string OUT_DATA_TFT_MOD_SCREEN = "ModeSelectionScreen";    ///< Display mode selection options for operator to select  on TFT display
        public const string OUT_DATA_TFT_FIN_SCREEN = "FingerSelectionScreen";  ///< Display 500/1000dpi resolution options for operator to select on TFT display
        public const string OUT_DATA_TFT_CAP_SCREEN = "CaptureProgressScreen";  ///< Display fingers being capture with annotaion icons as with LSCAN_Controls_DisplayShowFingerSelectionScreen()
        public const string OUT_DATA_TFT_RES_SCREEN = "ResolutionSelectScreen"; ///< Display fingers being capture with progress and errors as with LSCAN_Controls_DisplayShowCaptureProgressScreen()

        public const string OUT_DATA_TFT_CTRL_LEFT = "LeftButton";          ///< XML elmement for left button when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_CTRL_RIGHT = "RightButton";        ///< XML elmement for right button when using @OUT_DATA_TFT_CAP_SCREEN

        public const string OUT_DATA_TFT_STAT_TOP = "StatTop";              ///< XML elmement for top status when using @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_STAT_BOTTOM = "StatBottom";        ///< XML elmement for bottom status when using @OUT_DATA_TFT_CAP_SCREEN

        public const string OUT_DATA_TFT_L_PALM = "ColorLeftPalm";          ///< XML element for left main palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_THENAR = "ColorLeftThenar";      ///< XML element for left writer palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_LOWERT = "ColorLeftLowerThenar"; ///< XML element for left lower palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_INTER = "ColorLeftInterDigital"; ///< XML element for left upper palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_THUMB = "ColorLeftThumb";        ///< XML element for left thumb display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_INDEX = "ColorLeftIndex";        ///< XML element for left index finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_MIDDLE = "ColorLeftMiddle";      ///< XML element for left middle finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_RING = "ColorLeftRing";          ///< XML element for left ring finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_L_SMALL = "ColorLeftSmall";        ///< XML element for left little finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN

        public const string OUT_DATA_TFT_R_PALM = "ColorRightPalm";          ///< XML element for right main palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_THENAR = "ColorRightThenar";      ///< XML element for right writer palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_LOWERT = "ColorRightLowerThenar"; ///< XML element for right lower palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_INTER = "ColorRightInterDigital"; ///< XML element for right upper palm display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_THUMB = "ColorRightThumb";        ///< XML element for right thumb display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_INDEX = "ColorRightIndex";        ///< XML element for right index finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_MIDDLE = "ColorRightMiddle";      ///< XML element for right middle finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_RING = "ColorRightRing";          ///< XML element for right ring finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_TFT_R_SMALL = "ColorRightSmall";        ///< XML element for right little finger display segment when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN
        #endregion

        #region Device Specific LSE TFT DISPLAY values
        //! OUT_DATA_DISPLAY_SELECTION Finger annotation icons are valid for left button when using @OUT_DATA_TFT_FIN_SCREEN
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_ERASE = "ERASE";                          ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - remove icon
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_OBJECT_OK = "OBJECT_OK";                  ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - finger OK icon
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_OBJECT_BANDAGED = "OBJECT_BANDAGED";      ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - bandaged finger icon
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_OBJECT_MISSING = "OBJECT_MISSING";        ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - missing/amputated finger icon
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_OBJECT_RESTRICTED = "OBJECT_RESTRICTED";  ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - difficult to capture finger icon
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_REPEAT_YELLOW = "REPEAT_YELLOW";          ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - yellow repeat capture icon
        public const string OUT_DATA_DISPLAY_SELECTION_CTRL_LEAVE_UNCHANGED = "LEAVE_UNCHANGED";      ///< XML text for TFT display Left button element on @OUT_DATA_TFT_FIN_SCREEN - keep existing icon

        //! OUT_DATA_DISPLAY_COMMON button icons are valid for right button when using @OUT_DATA_TFT_FIN_SCREEN
        //! OUT_DATA_DISPLAY_COMMON button icons are valid for left and right button when using @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_ERASE = "ERASE";                           ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - remove icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_YELLOW_OK = "YELLOW_OK";                   ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - yellow Start/Capture/OK icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_YELLOW_OVERRIDE = "YELLOW_OVERRIDE";       ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - yelllow overrided icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_YELLOW_CONTRAST = "YELLOW_CONTRAST";       ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - yellow adjust contrast icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_YELLOW_REPEAT = "YELLOW_REPEAT";           ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - yellow repeat capture icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_GREEN_OK = "GREEN_OK";                     ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - green Start/Capture/OK icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_GREEN_OVERRIDE = "GREEN_OVERRIDE";         ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - green overrided icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_GREEN_CONTRAST = "GREEN_CONTRAST";         ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - green adjust contrast icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_GREEN_REPEAT = "GREEN_REPEAT";             ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - green repeat capture icon
        public const string OUT_DATA_DISPLAY_COMMON_CTRL_LEAVE_UNCHANGED = "LEAVE_UNCHANGED";       ///< XML text for TFT display button element on @OUT_DATA_TFT_FIN_SCREEN and @OUT_DATA_TFT_CAP_SCREEN - keep existing icon

        public const string OUT_DATA_DISPLAY_OBJECT_MISSING = "MISSING";                            ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element is not displayed (background color)
        public const string OUT_DATA_DISPLAY_OBJECT_CURRENT_SELECTION = "CURRENT_SELECTION";        ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element in orange
        public const string OUT_DATA_DISPLAY_OBJECT_ACTIVE = "ACTIVE";                              ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element in light blue
        public const string OUT_DATA_DISPLAY_OBJECT_RESTRICTED = "RESTRICTED";                      ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element in magenta
        public const string OUT_DATA_DISPLAY_OBJECT_INACTIVE = "INACTIVE";                          ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element in dark gray
        public const string OUT_DATA_DISPLAY_OBJECT_AUTOCAPTURE_OK = "AUTOCAPTURE_OK";              ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element changes between green, red and orange during capture controled by LSE
        public const string OUT_DATA_DISPLAY_OBJECT_LEAVE_UNCHANGED = "LEAVE_UNCHANGED";            ///< XML text for segment element of TFT display when using @OUT_DATA_TFT_FIN_SCREEN or @OUT_DATA_TFT_CAP_SCREEN - display element keeps the existing color

        //! OUT_DATA_DISPLAY_DISPLAY_STAT_TOP capture mode icons are valid for top status when using @OUT_DATA_TFT_CAP_SCREEN
        public const string OUT_DATA_DISPLAY_STAT_TOP_ERASE = "ERASE";                                 ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - remove icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_ROLL_HORIZONTAL = "ROLL_HORIZONTAL";             ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - horizontal roll icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_ROLL_HORIZONTAL_LEFT = "ROLL_HORIZONTAL_LEFT";   ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - horizontal roll left icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_ROLL_HORIZONTAL_RIGHT = "ROLL_HORIZONTAL_RIGHT"; ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - horizontal roll right icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_CAPTURE_FLAT = "CAPTURE_FLAT";                   ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - flat capture icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_LEAVE_UNCHANGED = "LEAVE_UNCHANGED";             ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - keep existing icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_ROLL_VERTICAL = "ROLL_VERTICAL";                 ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - vertical roll icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_ROLL_VERTICAL_UP = "ROLL_VERTICAL_UP";           ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - vertical roll up icon
        public const string OUT_DATA_DISPLAY_STAT_TOP_ROLL_VERTICAL_DOWN = "ROLL_VERTICAL_DOWN";       ///< TFT display top status on @OUT_DATA_TFT_CAP_SCREEN - vertical roll down icon

        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ERASE = "ERASE";                                   ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - remove icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_OK = "OK";                                         ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - green OK checkmark icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_OK_ALT_1 = "OK_ALT_1";                             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white OK checkmark icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_CLEAN_SURFACE = "CLEAN_SURFACE";                   ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red clean the platen surface warning icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_CLEAN_SURFACE_ALT_1 = "CLEAN_SURFACE_ALT_1";       ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white clean the platen surface warning icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_SURFACE_IS_DIRTY = "SURFACE_IS_DIRTY";             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red clean the silicone membrane warning icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_SURFACE_IS_DIRTY_ALT_1 = "SURFACE_IS_DIRTY_ALT_1"; ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white clean the silicone membrane warning icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_COMMON_ERROR = "COMMON_ERROR";                     ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red circle with white X general error icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_CAPTURE_ERROR = "CAPTURE_ERROR";                   ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red camera capture error icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_CAPTURE_ERROR_ALT_1 = "CAPTURE_ERROR_ALT_1";       ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red "C" capture error icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_QUALITY_CHECK_ERROR = "QUALITY_CHECK_ERROR";       ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red "Q" quality check error (NOTE: LSE API does not support NFIQ quality checks)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ROLL_ERROR = "ROLL_ERROR";                         ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red finger with arrows roll capture error
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ROLL_ERROR_ALT_1 = "ROLL_ERROR_ALT_1";             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red "R" roll capture error
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ROLL_ERROR_ALT_2 = "ROLL_ERROR_ALT_2";             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red round arrows roll capture error
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ROLL_ERROR_ALT_3 = "ROLL_ERROR_ALT_3";             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red shifting finger roll capture error
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_SEQUENCE_CHECK_ERROR = "SEQUENCE_CHECK_ERROR";     ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red crossed fingers sequence error (NOTE: LSE API does not support sequence checks)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_SEQUENCE_CHECK_ERROR_ALT_1 = "SEQUENCE_CHECK_ERROR_ALT_1"; ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red "S" sequence error (NOTE: LSE API does not support sequence checks)

        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_UP = "POSITION_UP";                       ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white up arrow icon indicating a finger is too low (BIOB_OBJECT_POSITION_TOO_LOW)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_UP_RIGHT = "POSITION_UP_RIGHT";           ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white up-right arrow icon indicating a finger is too low and too far left
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_RIGHT = "POSITION_RIGHT";                 ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white right arrow icon indicating a finger is too far left (BIOB_OBJECT_POSITION_TOO_LEFT)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_DOWN_RIGHT = "POSITION_DOWN_RIGHT";       ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white down-right arrow icon indicating a finger is too high and too far left
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_DOWN = "POSITION_DOWN";                   ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white down arrow icon indicating a finger is too high (BIOB_OBJECT_POSITION_TOO_HIGH)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_DOWN_LEFT = "POSITION_DOWN_LEFT";         ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white down-left arrow icon indicating a finger is too high and too far right
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_LEFT = "POSITION_LEFT";                   ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white left arrow icon indicating a finger is too far right (BIOB_OBJECT_POSITION_TOO_RIGHT)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_UP_LEFT = "POSITION_UP_LEFT";             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white up-left arrow icon indicating a finger is too low and too far right
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_DOWN_LEFT_RIGHT_UP = "POSITION_DOWN_LEFT_RIGHT_UP"; ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white centering arrows icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_POSITION_LEFT_RIGHT = "POSITION_LEFT_RIGHT";       ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white opposed arrows icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_HOURGLASS_STATIC = "HOURGLASS_STATIC";             ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white static hour glass wait icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_HOURGLASS_ANIMATED = "HOURGLASS_ANIMATED";         ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white animated hour glass wait icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_CAPTURING_ANIMATED = "CAPTURING_ANIMATED";         ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - white animated concentric circles flat capturing icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ROLLING_LEFT_ANIMATED = "ROLLING_LEFT_ANIMATED";   ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - animated rolling left round arrows icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_ROLLING_RIGHT_ANIMATED = "ROLLING_RIGHT_ANIMATED"; ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - animated rolling right round arrows icon
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_LEAVE_UNCHANGED = "LEAVE_UNCHANGED";               ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - keep existing icon

        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_COMPRESSION_ERROR = "COMPRESSION_ERROR";           ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red compression error icon (NOTE: LSE API does not support compression)
        public const string OUT_DATA_DISPLAY_STAT_BOTTOM_SEGMENTATION_ERROR = "SEGMENTATION_ERROR";         ///< TFT display bottom status on @OUT_DATA_TFT_CAP_SCREEN - red segmenation error icon (NOTE: LSE API does not support segmenation)
        #endregion

        #region other stuff
        public const string DEV_PROP_ACTIVE_AREA = "ACTIVE_AREA";      //< left, top position and width, height of Active Area
        public const string DEV_PROP_ROLL_FLEXIBLE = "ROLL_FLEXIBLE";  //< enables/disables to start rolling from any horizontal position of the full-width capture area

        public const string OUT_DATA_TOUCH_EVENT = "TouchEvent";
        public const string OUT_DATA_TOUCH_EVENT_POSX = "PosX";
        public const string OUT_DATA_TOUCH_EVENT_POSY = "PosY";

        public const string PROC_ADJUST_TYPE_CHECK_CLEANLINESS = "PROCESS_ADJUST_TYPE_CHECK_CLEANLINESS";
        public const string PROC_ADJUST_TYPE_FORCE_READJUSTMENT = "PROCESS_ADJUST_TYPE_FORCE_READJUSTMENT";

        public const string DEV_PROP_IMAGE_WIDTH = "IMAGE_WIDTH";      //< [get] capture result image width.
        public const string DEV_PROP_IMAGE_HEIGHT = "IMAGE_HEIGHT";    //< [get] capture result image height.
        public const string DEV_PROP_MAXIMUM_FINAL_IMAGE_DIMENSION = "MAXIMUM_FINAL_IMAGE_DIMENSION";  //< [get] maximum final capture image dimension.
        public const string DEV_PROP_MINIMUM_FINAL_IMAGE_DIMENSION = "MINIMUM_FINAL_IMAGE_DIMENSION";  //< [get] minimum final capture image dimension.

        public const string DEV_PAD_STRUCT_NAME = "BioBPADData";  // name string used for the BioBPADData structure as found in the BioBData.pStructName member

        public static char[] trimArray = new char[] { ' ', '\r', '\n', '\t' };

        #endregion
    }
}
