using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewEmptyWebProject.Models.Identity
{
    public class ApplicationRole:IdentityRole //IdentityUserdan sonra yaptık.
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string name, string description) //normalde sadece 1 paramtere yani yuakrdıaki constructor ama biz 2.consturcutor açıklamalı yaptık
        {
            this.Name = name;
            this.Description = description;
        }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
