using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApps.WinFormsIntro.Models;

namespace WindowsFormsApps.WinFormsIntro.Context
{
    internal class VirtualDatabase
    {
        public static List<User> dataList = new List<User>();

        static VirtualDatabase()
        {
            dataList.AddRange(new List<User>
            {
                new User{Id = 1,Username = "user1",Password = "1234",Name = "user1",Surname = "user1",Desc = "1ci user"},
                new User{Id = 2,Username = "user2",Password = "12345",Name = "user2",Surname = "user2",Desc = "2ci user"},
                new User{Id = 3,Username = "user3",Password = "123456",Name = "user3",Surname = "user3",Desc = "3ci user"}
            });
        }

    }
}
