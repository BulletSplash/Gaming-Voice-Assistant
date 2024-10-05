using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gaming_Voice_Assistant.Models
{
    public class Command
    {
        public int ID { get; set; }

        public string CMD { get; set; } = null!;

        public string? RESPONSE { get; set; }

        public string? EXECPATH { get; set; }
    }
}
