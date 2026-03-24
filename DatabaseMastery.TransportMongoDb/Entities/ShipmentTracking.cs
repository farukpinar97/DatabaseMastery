namespace DatabaseMastery.TransportMongoDb.Entities
{
    public class ShipmentTracking
    {
        public string TrackingId { get; set; } = Guid.NewGuid().ToString();
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TrackingStatus { get; set; }
    }
}
