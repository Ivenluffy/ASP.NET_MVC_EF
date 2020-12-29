using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public partial class Department
    {
        public Department()
        {
            Children = new HashSet<Department>();
            UserInfo = new HashSet<UserInfo>();
        }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Department Parent { get; set; }
        public virtual ICollection<UserInfo> UserInfo{ get; set; }
        public virtual ICollection<Department> Children { get; set; }
    }
}
