namespace LeafLight_API.Models
{
    public class PlantIssue
    {
        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public int IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
