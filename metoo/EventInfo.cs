using System;
using System.IO;
using Xamarin.Forms;
namespace metoo
{
    class EventInfo
    {
        public EventInfo(int ID, string CreatorName, int CreatorAge, string EventName, string DateTime, string Details, string Tags, byte[] Photo)
        {
            this.ID = ID;
            this.CreatorName = CreatorName;
            this.CreatorAge = CreatorAge;
            this.EventName = EventName;
            this.DateTime = DateTime;
            this.Details = Details;
            this.Tags = Tags;
            if (Photo != null)
            {
                Stream ms = new MemoryStream(Photo);
                this.Photo = ImageSource.FromStream(() => ms);
            }
            else { this.Photo = ImageSource.FromFile("add_photo.png"); }
        }
        public int ID { get; set; }
        public string CreatorName { get; set; }
        public int CreatorAge { get; set; }
        public string EventName { get; set; }
        public string DateTime { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }
        public ImageSource Photo { get; set; }
    }
}
