﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public  class LoginDAL
    {

        private static LoginDAL instance;

        public static LoginDAL Instance {
            get
            {
                if(instance == null)
                {
                    instance = new LoginDAL();
                }
                return instance;
            }
            private set => instance = value; 
        }
        public LoginDAL() { }
        public bool Login(string username, string password,int role)
        {
            string s = "select * from dbo.Account where UserName = N'" + username + "' and PassWord = '" + password + "' and Type = '" + role + "'";
            DataTable  d =  DataProvider.Instance.GetRecords(s);
            return d.Rows.Count > 0 ;
        }
    }
}
