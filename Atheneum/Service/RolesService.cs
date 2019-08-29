﻿using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Service
{
    public class RolesService : IRolesService 
    {
        private ApplicationContext db;

        public RolesService(ApplicationContext context)
        {
            db = context;
        }
        public RolesService()
        {
            //db = new ApplicationContext();
        }

        public async Task<string> Test()
        {
            return await str();
            
        }

        public async Task<string> str()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return "kyky";
        }

        /////////////////////////////////////////////////////
        public async Task<IEnumerable<Role>> GetRoles()
        {
            IEnumerable<Role> Roles = db.Roles;
            return Roles;
        }

        public async Task<IEnumerable<Role>> GetUserRoles(Guid UserId)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return new List<Role>();
            
        }

        public async Task<Role> AddRole(string roleName)
        {
            Role role = new Role() {
                Id = new Guid(),
                RoleName = roleName
            };
            await db.Roles.AddAsync(role);
            await db.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            if(await db.Roles.AnyAsync(r => r.Id == role.Id)
                && !string.IsNullOrWhiteSpace(role.RoleName))
            {
                db.Roles.Update(role);
                await db.SaveChangesAsync();
                return role;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteRole(Guid roleId)
        {
            if (await db.Roles.AnyAsync(r => r.Id == roleId))
            {
                Role role = await db.Roles.FindAsync(roleId);
                db.Roles.Remove(role);
                await db.SaveChangesAsync();
            }
        }
    }
}
