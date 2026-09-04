namespace ShelfLife.Models
{
    public enum ReadingStatus
    {
        WantToRead,
        CurrentlyReading,
        FinishedReading,
        DidNotFinish
    }
    public class ReadingRecord
    {
        public int ReadingRecordId { get; set; }
        public string? Review { get; set; }
        public int? Rating { get; set; } // Rating from 1 to 10
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
        public ReadingStatus Status { get; set; }
        public int BookId { get; set; }

        // Navigation property 
        public required Book Book { get; set; } 

    }
}
