using CORE.Models;

namespace CORE.Dto
{
    public class PlantIssueDto
    {
        public long PlantId { get; set; }
        public Plant Plant { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
