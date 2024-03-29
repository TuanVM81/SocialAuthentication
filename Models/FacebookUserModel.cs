﻿namespace SocialAuthentication.Models
{
    public class PictureData
    {
        public int height { get; set; }
        public bool is_silhouette { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Picture
    {
        public PictureData data { get; set; }
    }

    public class FacebookUserModel
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public Picture picture { get; set; }
    }
}
