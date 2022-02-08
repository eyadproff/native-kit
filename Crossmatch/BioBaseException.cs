using System;
using System.Runtime.Serialization;

namespace Crossmatch
{
    [Serializable]
    public class BioBaseException : Exception
    {
        public BioBErrorCode ReturnCode { get; private set; }

        public string XmlData { get; private set; }
               
        public BioBaseException()
          : base("BioBase Unknown Error")
        {
        }
        public BioBaseException(string errorMsg)
          : base(errorMsg)
        {
        }
        public BioBaseException(string errorMsg, Exception innerException)
          : base(errorMsg, innerException)
        {
        }
        public BioBaseException(BioBErrorCode returnCode)
          : base("BioBase Return code '" + returnCode.ToString("D") + "'")
        {
            ReturnCode = returnCode;
        }
        protected BioBaseException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
        }
        public BioBaseException(Exception innerException, string xmlData)
          : base("Error parsing XML", innerException)
        {
            XmlData = xmlData;
        }
               
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
