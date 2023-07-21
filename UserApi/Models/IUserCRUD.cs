using System;
namespace UserApi.Models
{
	public interface IUserCRUD
	{
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public void CreateUser(User model);
        public void UpdateUser(int id, User model);
        public void DeleteUser(int id);
    }
}

