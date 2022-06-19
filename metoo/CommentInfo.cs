using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace metoo
{
    class CommentInfo
    {
        public CommentInfo(int ID, int CreatorID, string CommentCreator, string Text, string Datetime, ImageSource CommentPhoto)
        {
            this.ID = ID;
            this.CreatorID = CreatorID;
            this.CommentCreator = CommentCreator;
            this.Text = Text;
            this.Datetime = Datetime;
            this.CommentPhoto = CommentPhoto;

        }
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string CommentCreator { get; set; }
        public string Text { get; set; }
        public string Datetime { get; set; }
        public ImageSource CommentPhoto { get; set; }
    }
}
