using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    public class ClientePrincipal : CosmosBase
    {
        public ClientePrincipal() : base(CosmosType.Principal)
        {
        }

        public string UserId { get; set; }
        public string IdentityProvider { get; set; }
        public string UserDetails { get; set; }
        public string[] UserRoles { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        public bool Blocked { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
            UserId = IdLoggedUser;
        }
    }
}