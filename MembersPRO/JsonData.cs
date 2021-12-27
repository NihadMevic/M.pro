namespace MembersPRO
{
    public class JsonData
    {
        public string version { get; set; }
        public int time { get; set; }
        public List<Block> blocks { get; set; }
    }
    public class Block
    {
        public string id { get; set; }
        public string type { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public int level { get; set; }
        public string text { get; set; }
        public string alignment { get; set; }
        public string caption { get; set; }
        public bool? stretched { get; set; }
        public bool? withBackground { get; set; }
        public bool? withBorder { get; set; }
        public File file { get; set; }
        public string style { get; set; }
        public List<string> items { get; set; }
        public string embed { get; set; }
        public string source { get; set; }
        public string service { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
    }
    public class File
    {
        public string url { get; set; }
    }
}