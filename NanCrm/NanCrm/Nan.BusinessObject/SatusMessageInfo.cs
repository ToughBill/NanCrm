using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public enum MessageType
    {
        Info,
        Warming,
        Error
    }

    public enum MessageCode
    {
        None=0,
        EntryExist,
        RefenenceError
    }
    public class SatusMessageInfo
    {
        public MessageCode Code { get; set; }
        public object BO { get; set; }
        public string Message { get; set; }
        public MessageType MsgType { get; set; }

        public SatusMessageInfo()
        {
            this.Code = MessageCode.None;
            this.BO = null;
            this.Message = string.Empty;
            this.MsgType = MessageType.Error;
        }
        public SatusMessageInfo(MessageType type, MessageCode code, object bo, string msg)
        {
            this.MsgType = type;
            this.Code = code;
            this.BO = bo;
            this.Message = msg;
        }
    }
    public delegate void DeleBoErrorHandler(SatusMessageInfo err);
}
