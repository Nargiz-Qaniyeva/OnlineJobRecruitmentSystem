namespace Jobbply__Final_Project.Models
{
    public class PosterTimes
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TimersId { get; set; }
        public Posts Posts { get; set; }
        public Timers Timers { get; set; }
    }
}
