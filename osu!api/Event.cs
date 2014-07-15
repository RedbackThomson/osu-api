using System;

namespace osu_api
{
    public class Event
    {
        public string display_html { get; set; }
        public int beatmap_id { get; set; }
        public int beatmapset_id { get; set; }
        public DateTime date { get; set; }
        public int epicfactor { get; set; }
    }
}