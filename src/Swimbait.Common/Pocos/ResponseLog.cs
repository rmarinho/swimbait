﻿using System;

namespace Swimbait.Common
{
    public class ResponseLog
    {
        public Uri RequestUri { get; set; }

        public string RequestBody { get; set; }

        public string RequestMethod { get; set; }

        public string ResponseBody { get; set; }

        public byte[] ResponseBytes { get; set; }
    }
}