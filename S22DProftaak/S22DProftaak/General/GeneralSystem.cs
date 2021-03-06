﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S22DProftaak.General
{
    class GeneralSystem
    {
        public static User LoggedUser;
        private Database.DatabaseConnection db = new Database.DatabaseConnection();
        private string _error = "";
        public User GetLoggedUser { get { return LoggedUser; } }
        public string Error { get { return _error; } }
        public GeneralSystem()
        {
            
        }

        public bool Login(string userName, string Password)
        {
            return (!db.Login(out LoggedUser, userName, Password, out _error));
        }
        public bool GetTrainLoggedUser(out Train tram, out string error)
        {
            List<Train> trainlist=new List<Train>();
            tram = null;
            error = "";
            if (LoggedUser.Type != UserTypeEnum.Driver)
            {
                error = "User is not a driver.";
                return false;
            }
            // TODO: GetTrains implementation. bool gettrains(list<Train>, string) from database
            // -- if (!db.GetTrains(trainlist, error)) return false;
            foreach (Train t in trainlist)
            {
                if (t.TrainUser.UserName == LoggedUser.UserName)
                {
                    tram = t;
                    return true;
                }
            }
            error = "Tram not found.";
            return false;
        }
    }
}
