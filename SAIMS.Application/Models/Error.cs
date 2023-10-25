
using System.Text.Json;

namespace SAIMS.Application.Model;
 
 public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }   