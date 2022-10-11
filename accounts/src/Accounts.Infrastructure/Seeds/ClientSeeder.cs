using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Core.Entities;
using Accounts.Core.Enums;
using Accounts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastructure.Seeds
{
    public class ClientSeeder
    {
        public static void Seed(AccountsContext context)
        {
            var listDb = context.Clients.ToList();
            
            foreach(var item in list){
                var itemDb = listDb.FirstOrDefault(s => s.Id == item.Id);
                if(itemDb == null)
                {
                    context.Clients.Add(item);
                }
                else
                {
                    itemDb.Name = item.Name;
                    itemDb.SecretKey = item.SecretKey;
                    itemDb.IsAppAuthentication = item.IsAppAuthentication;
                    itemDb.AppId = item.AppId;
                    itemDb.Status = item.Status;
                    itemDb.UpdatedAt = DateTime.UtcNow;
                    context.Entry(itemDb).State = EntityState.Modified;
                }
            }

            foreach(var item in listDb.Where(s => !list.Select(s => s.Id).Contains(s.Id)))
                context.Clients.Remove(item);


            context.SaveChanges();
        }
        
        private static List<ClientEntity> list = new List<ClientEntity>
        {
            new ClientEntity { 
                Id = new Guid("bef292cf-f1b7-4370-b0a3-e00ff099daa3"), 
                Name = "Principal", 
                SecretKey =  new Guid("f67f982d-c99d-4fc0-9d54-535f0788ca09").ToString(),
                IsAppAuthentication = true,
                AppId = new Guid("264454c9-691d-4c36-8540-1db1c46e198c"),
                Status = StatusEnum.Active,
                CreatedAt = DateTime.UtcNow
            },
            new ClientEntity { 
                Id = new Guid("be8b6fba-1c5e-4513-915d-bf02cf2ef18b"), 
                Name = "Principal", 
                SecretKey =  new Guid("3f068b21-baa4-45ff-8a76-48a23fee665c").ToString(),
                IsAppAuthentication = true,
                AppId = new Guid("d582144d-ee4f-4249-be65-38d8836c1036"),
                Status = StatusEnum.Active,
                CreatedAt = DateTime.UtcNow
            },
        };
        
    }

    
}