using System;

namespace osu_api
{
    public class Beatmap
    {
        public string approved { get; set; }
        public DateTime approved_date { get; set; }
        public DateTime last_update { get; set; }
        public string artist { get; set; }
        public int beatmap_id { get; set; }
        public int beatmapset_id { get; set; }
        public int bpm { get; set; }
        public string creator { get; set; }
        public double difficultyrating { get; set; }
        public int diff_size { get; set; }
        public int diff_overall { get; set; }
        public int diff_approach { get; set; }
        public int diff_drain { get; set; }
        public int hit_length { get; set; }
        public string source { get; set; }
        public string title { get; set; }
        public int total_length { get; set; }
        public string version { get; set; }
        public int mode { get; set; }
    }
}