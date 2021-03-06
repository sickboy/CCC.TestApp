﻿using System;

namespace CCC.TestApp.UI.Desktop.Models
{
    public class UserModel : ModelBase
    {
        string _password;
        string _userName;

        public Guid Id { get; set; }

        public string UserName {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}