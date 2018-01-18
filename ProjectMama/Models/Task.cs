namespace ProjectMama
{
    public class Task
    {
        public uint id { get; set; }
        public uint author_id { get; set; }

        public string name { get; set; }
        public string description { get; set; }

        public enum State { todo, inprogress, done };
        public State state { get; set; }
    }
}
