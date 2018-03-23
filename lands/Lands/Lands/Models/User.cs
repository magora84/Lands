﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    public class User {

        
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string ImagePath { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public byte[] ImageArray { get; set; }
        public string Password { get; set; }


        public string ImageFullPath {
            get {
                if (string.IsNullOrEmpty(ImagePath)) {
                    return "noimage";
                }

                return string.Format(
                    "http://landsapi1.azurewebsites.net/{0}",
                    ImagePath.Substring(1));
            }
        }

     
        public string FullName {
            get {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
