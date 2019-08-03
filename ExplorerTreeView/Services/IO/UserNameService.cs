using System;

namespace ExplorerTreeView.Services
{
    public class UserNameService 
        : IUserNameService
    {
        public string LoggedUser => Environment.UserName;
    }
}
