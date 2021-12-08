using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProAgil.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        // utilizando datanotation para definir mais um campo com 150 caracteres 
        [Column(TypeName = "nvarchar(150)")]
        // Aqui eu crio um campo FullName na minha tabela user que será gerada automática pelo aspnet.core
        public string FullName {get; set; }
        public List<UserRole> UserRoles { get; set; }
            
    
    }
}