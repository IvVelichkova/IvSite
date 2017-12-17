namespace IvSite.Services.User.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using IvSite.Data;
    using IvSite.Services.User.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserService:IUserService
    {
        private readonly IvSiteDbContext db;
        private readonly IRoomService rooms;

        public UserService(IvSiteDbContext db, IRoomService rooms)
        {
            this.db = db;
            this.rooms = rooms;
        }

       


    }
}
