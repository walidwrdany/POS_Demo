using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS_Demo
{
    public class IdentityManager
    {
        // Swap ApplicationRole for IdentityRole:
        RoleManager<Role, int> _roleManager = new RoleManager<Role, int>(
            new RoleStore(new ApplicationDbContext()));

        UserManager<ApplicationUser, int> _userManager = new UserManager<ApplicationUser, int>(
            new UserStore(new ApplicationDbContext()));

        ApplicationDbContext _db = new ApplicationDbContext();
        

        public ApplicationUser GetCurrentUser()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId<int>();
            return _userManager.FindById(userId);
        }

        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            // Swap ApplicationRole for IdentityRole:
            var idResult = _roleManager.Create(new Role(name));
            return idResult.Succeeded;
        }


        public bool CreateUser(ApplicationUser user, string password)
        {
            var idResult = _userManager.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(int userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }


        public void ClearUserRoles(int userId)
        {
            var user = _userManager.FindById(userId);
            var currentRoles = new List<UserRole>();

            currentRoles.AddRange(user.Roles);
            foreach (UserRole role in currentRoles)
            {
                _userManager.RemoveFromRole(userId, role.Role.Name);
            }

        }


        public void RemoveFromRole(int userId, string roleName)
        {
            _userManager.RemoveFromRole(userId, roleName);
        }


        public void DeleteRole(int roleId)
        {
            var roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId));
            var role = _db.Roles.Find(roleId);

            foreach (ApplicationUser user in roleUsers)
            {
                this.RemoveFromRole(user.Id, role.Name);
            }

            _db.Roles.Remove(role);
            _db.SaveChanges();
        }



        //public void CreateGroup(string groupName)
        //{
        //    if (GroupNameExists(groupName))
        //    {
        //        throw new GroupExistsException(
        //            "A group by that name already exists in the database. Please choose another name.");
        //    }

        //    var newGroup = new Group(groupName);
        //    _db.Groups.Add(newGroup);
        //    _db.SaveChanges();
        //}

        //public bool GroupNameExists(string groupName)
        //{
        //    return _db.Groups.Any(gr => gr.Name == groupName);
        //}


        //public void ClearUserGroups(int userId)
        //{
        //    ClearUserRoles(userId);
        //    ApplicationUser user = _db.Users.Find(userId);
        //    user.Groups.Clear();
        //    _db.SaveChanges();
        //}

        //public void AddUserToGroup(int userId, int groupId)
        //{
        //    Group group = _db.Groups.Find(groupId);
        //    ApplicationUser user = _db.Users.Find(userId);

        //    var userGroup = new UserGroup
        //    {
        //        Group = group,
        //        GroupId = group.Id,
        //        User = user,
        //        UserId = user.Id
        //    };

        //    foreach (RoleGroup role in group.Roles)
        //    {
        //        _userManager.AddToRole(userId, role.Role.Name);
        //    }
        //    user.Groups.Add(userGroup);
        //    _db.SaveChanges();
        //}

        //public void ClearGroupRoles(int groupId)
        //{
        //    Group group = _db.Groups.Find(groupId);
        //    IQueryable<ApplicationUser> groupUsers = _db.Users.Where(u => u.Groups.Any(g => g.GroupId == group.Id));

        //    foreach (RoleGroup role in group.Roles)
        //    {
        //        int currentRoleId = role.RoleId;
        //        foreach (ApplicationUser user in groupUsers)
        //        {
        //            // Is the user a member of any other groups with this role?
        //            int groupsWithRole = user.Groups.Count(g => g.Group.Roles.Any(r => r.RoleId == currentRoleId));

        //            // This will be 1 if the current group is the only one:
        //            if (groupsWithRole == 1)
        //            {
        //                RemoveFromRole(user.Id, role.Role.Name);
        //            }
        //        }
        //    }
        //    group.Roles.Clear();
        //    _db.SaveChanges();
        //}

        //public void AddRoleToGroup(int groupId, string roleName)
        //{
        //    Group group = _db.Groups.Find(groupId);
        //    Role role = _db.Roles.First(r => r.Name == roleName);

        //    var newgroupRole = new RoleGroup
        //    {
        //        GroupId = group.Id,
        //        Group = group,
        //        RoleId = role.Id,
        //        Role = role
        //    };

        //    // make sure the groupRole is not already present
        //    if (!group.Roles.Contains(newgroupRole))
        //    {
        //        group.Roles.Add(newgroupRole);
        //        _db.SaveChanges();
        //    }

        //    // Add all of the users in this group to the new role:
        //    IQueryable<ApplicationUser> groupUsers = _db.Users.Where(u => u.Groups.Any(g => g.GroupId == group.Id));
        //    foreach (ApplicationUser user in groupUsers)
        //    {
        //        if (!(_userManager.IsInRole(user.Id, roleName)))
        //        {
        //            AddUserToRole(user.Id, role.Name);
        //        }
        //    }
        //}

        //public void DeleteGroup(int groupId)
        //{
        //    Group group = _db.Groups.Find(groupId);

        //    // Clear the roles from the group:
        //    ClearGroupRoles(groupId);
        //    _db.Groups.Remove(group);
        //    _db.SaveChanges();
        //}
    }

}
