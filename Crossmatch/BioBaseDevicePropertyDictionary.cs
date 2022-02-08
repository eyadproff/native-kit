using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Crossmatch
{
    [Serializable]
    public class BioBaseDevicePropertyDictionary : Dictionary<string, string>
    {
        public BioBaseDevicePropertyDictionary()
        {
        }

        protected BioBaseDevicePropertyDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public bool AutoCaptureSupported
        {
            get
            {
                string prop = BioBaseConstants.DEV_PROP_DEVICE_AUTOCAPTURE_SUPPORTED;
                if (ContainsKey(prop) && this[prop].ToUpper(CultureInfo.InvariantCulture) == "TRUE")
                {
                    return true;
                }
                return false;
            }
        }

        public bool AutoCaptureEnabled
        {
            get
            {
                string prop = BioBaseConstants.DEV_PROP_AUTOCAPTURE_ON;
                if (ContainsKey(prop) && this[prop].ToUpper(CultureInfo.InvariantCulture) == "TRUE")
                {
                    return true;
                }
                return false;
            }
        }

        public int PixelPerInch
        {
            get
            {
                if (ContainsKey(BioBaseConstants.DEV_PROP_IMAGE_RESOLUTION))
                {
                    return int.Parse(this[BioBaseConstants.DEV_PROP_IMAGE_RESOLUTION], CultureInfo.InvariantCulture);
                }
                return 0;
            }
        }
    }

}
