using System;
namespace JikanAPI.Models
{
    public class Watch
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public WatchType Type { get; set; }

        public Watch(Watch that)
        {
        }
    }
}
