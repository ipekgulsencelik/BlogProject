﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlogProject.PresentationLayer.Models
{
    public class CaptchaResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}