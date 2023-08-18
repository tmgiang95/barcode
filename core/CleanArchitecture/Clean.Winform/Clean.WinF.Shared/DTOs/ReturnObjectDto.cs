using Clean.WinF.Shared.Enums;
using Newtonsoft.Json;
using System;

namespace Clean.WinF.Shared.DTOs
{
    public class ReturnObjectDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public DateTime Timestamp { get; set; }
        public string Code { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);

        public void SetError(string code, string message)
        {
            Status = nameof(MessageReturnType.Error);
            Code = code;
            Message = message;
        }
    }
}
