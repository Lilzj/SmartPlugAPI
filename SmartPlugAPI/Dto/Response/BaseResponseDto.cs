using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlugAPI.Dto.Response
{
    public class BaseResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
