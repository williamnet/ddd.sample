using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Application.Models
{
    /// <summary>
    /// 返回对象
    /// </summary>
    public class Result
    {
        public Result()
        {

        }
        public Result(ResultStatus status, String message = "")
        {
            this.ResultStatus = status;
            this.Message = message;
        }
        /// <summary>
        /// 返回状态
        /// </summary>
        [JsonProperty]
        public ResultStatus ResultStatus
        {
            get;
            private set;
        }
        /// <summary>
        /// 返回的消息 
        /// </summary>
        [JsonProperty]
        public String Message
        {
            get;
            private set;
        }
    }
    public class ResultWithData<T> : Result
    {
        public ResultWithData()
        {

        }
        public ResultWithData(ResultStatus status, T dataBody, String message = "")
            : base(status, message)
        {
            this.DataBody = dataBody;
        }
        /// <summary>
        /// 返回的数据信息
        /// </summary>
        [JsonProperty]
        public T DataBody
        {
            get;
            private set;
        }
    }
    public enum ResultStatus
    {
        Ok = 200,
        Error = 500
    }
}
