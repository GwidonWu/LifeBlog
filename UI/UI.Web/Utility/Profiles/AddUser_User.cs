using AutoMapper;
using DAL.Entity.Entities;
using UI.Web.Areas.Admin.Models;

namespace UI.Web.Utility.Profiles
{
    public class AddUser_User : Profile
    {

        protected override void Configure()
        {
            var map = Mapper.CreateMap<UserViewModel, User>();
            map.ConstructUsing(s => new User
            {
                Name = s.Name,
                Username = s.Username,
                Sex = s.Sex,
                Email = s.Email,
                //Password = Security.SHA256(s.Password),

                //  RegTime=DateTime.Now,
                RoleID = s.RoleID,


            });
        }
    }
}