using System;
namespace metoo
{
    class EventInfo
    {
        public EventInfo(int ID, int CreatorID, string EventName, string DateTime, string Details, string Tags)
        {
            this.ID = ID;
            User user = App.Database.GetItem(CreatorID);
            CreatorName = user.Name;
            CreatorAge = user.Age;
            this.EventName = EventName;
            this.DateTime = DateTime;
            this.Details = Details;
            this.Tags = Tags;
        }
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string CreatorName { get; set; }
        public int CreatorAge { get; set; }
        public string EventName { get; set; }
        public string DateTime { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }
    }
}
