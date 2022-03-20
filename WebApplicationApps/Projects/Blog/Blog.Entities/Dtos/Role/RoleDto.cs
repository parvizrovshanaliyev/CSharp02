using System.Collections.Generic;

namespace Blog.Entities.Dtos.Role
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleAssignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAssigned { get; set; }
    }

    public class UserRoleAssignDto
    {
        public UserRoleAssignDto()
        {
            Roles = new List<RoleAssignDto>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<RoleAssignDto> Roles { get; set; }
    }
}
