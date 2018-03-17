using RiotSharp.Misc;

namespace lol.Models.Player
{
    public class SelectPlayerViewModel
    {
        public string Username { get; set; }
        public Region Region { get; set; } = Region.na;
    }
}