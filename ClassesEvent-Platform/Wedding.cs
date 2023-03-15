namespace ClassesEvent_Platform
{
    public class Wedding : Event
    {
        public int NumberOfGuests { get; set; }
        public DateTime WeddingDate { get; set; }
        public string Venue { get; set; }

        public Wedding()
        {
        }

        public Wedding(int id, string title, string description, string imageUrl, int numberOfGuests, DateTime weddingDate, string venue)
            : base(id, title, description, imageUrl)
        {
            NumberOfGuests = numberOfGuests;
            WeddingDate = weddingDate;
            Venue = venue;
        }

        public string GetInvitationMessage()
        {
            return $"You are cordially invited to the wedding of {Title} on {WeddingDate.ToShortDateString()} at {Venue}.";
        }
    }
}