using System.Text.Json;

namespace OrderProject.Dtos
{
    public class ErrorDto
    {
        public int StastusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
