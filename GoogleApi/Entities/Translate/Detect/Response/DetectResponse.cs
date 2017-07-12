﻿using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Translate.Detect.Response
{
    /// <summary>
    /// Detect Response.
    /// </summary>
    [DataContract]
    public class DetectResponse : BaseResponse
    {
        /// <summary>
        /// Container for the detected results.
        /// </summary>
        [DataMember(Name = "data")]
        public virtual Data Data { get; set; }
    }
}