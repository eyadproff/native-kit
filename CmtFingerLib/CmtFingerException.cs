using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CmtFingerLib
{
    [Serializable]
    /// <summary>
    /// CmtFingerException object are created when there is a error with the image decoding.
    /// </summary>
    public class CmtFingerException : Exception
    {
        // CMT Finger transcoder of ISO 19794_4 FIR records error codes;
        // BIOB_SUCCESS = 0
        // There are three *positive* CMT Finger transcoder errors
        public CmtFingerException()
          : base("cmtfinger Unknown Error")
        {
        }
        public CmtFingerException(string errorMsg)
          : base(errorMsg)
        {
        }
        public CmtFingerException(string errorMsg, Exception innerException)
          : base(errorMsg, innerException)
        {
        }
        public CmtFingerException(int errorCode)
          : base("cmtfinger Error '" + errorCode.ToString("D", CultureInfo.InvariantCulture) + "'")
        {
            ErrorCode = (int)errorCode;
        }
        protected CmtFingerException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
        }
        public int ErrorCode { get; private set; }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
