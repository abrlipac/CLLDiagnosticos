﻿namespace WebClientCore.Models
{
    public class AccessTokenUserInformation
    {
        public string nameid { get; set; }
        public string email { get; set; }
        public string unique_name { get; set; }
        public string family_name { get; set; }
        public int exp { get; set; }
        public string role { get; set; }
    }
}