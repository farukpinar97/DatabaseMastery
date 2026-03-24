namespace DatabaseMastery.TransportMongoDb.Dtos.ShipmentTrackingDtos
{
    public class ResultShipmentTrackingDto
    {
        public string TrackingId { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TrackingStatus { get; set; }
    }
}
