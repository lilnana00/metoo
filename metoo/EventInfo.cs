using System;
namespace metoo
{
    class EventInfo
    {
        public EventInfo(int ID, string CreatorName, int CreatorAge, string EventName, string DateTime, string Details, string Tags)
        {
            this.ID = ID;
            this.CreatorName = CreatorName;
            this.CreatorAge = CreatorAge;
            this.EventName = EventName;
            this.DateTime = DateTime;
            this.Details = Details;
            this.Tags = Tags;
        }
        public int ID { get; set; }
        public string CreatorName { get; set; }
        public int CreatorAge { get; set; }
        public string EventName { get; set; }
        public string DateTime { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }
    }
}
