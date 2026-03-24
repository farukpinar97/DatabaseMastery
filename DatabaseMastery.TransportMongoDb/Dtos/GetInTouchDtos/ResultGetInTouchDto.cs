namespace DatabaseMastery.TransportMongoDb.Dtos.GetInTouchDtos
{
    public class ResultGetInTouchDto
    {
        public string GetInTouchId { get; set; }

        public string BadgeTitle { get; set; }          // Get in touch
        public string MainTitle { get; set; }           // Proud to Deliver Excellence Every Time
        public string Description { get; set; }         // Paragraf

        public string Feature1Title { get; set; }       // Boost your sale
        public string Feature1Description { get; set; }

        public string Feature2Title { get; set; }       // Introducing New Features
        public string Feature2Description { get; set; }

        public string ImageUrl { get; set; }            // Sağdaki görsel
        public bool Status { get; set; }
    }
}
