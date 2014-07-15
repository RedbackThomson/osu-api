using System;

namespace osu_api
{
    public class Score
    {
        public int score { get; set; }
        public string username { get; set; }
        public int count300 { get; set; }
        public int count100 { get; set; }
        public int count50 { get; set; }
        public int countmiss { get; set; }
        public int maxcombo { get; set; }
        public int countkatu { get; set; }
        public int countgeki { get; set; }
        public int perfect { get; set; }
        public int enabled_mods { get; set; }
        public int user_id { get; set; }
        public DateTime date { get; set; }
        public string rank { get; set; }
        public double pp { get; set; }
    }
}
