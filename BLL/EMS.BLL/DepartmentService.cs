using EMS.IBLL;
using EMS.IDAL;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL
{
    public partial class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private IDepartmentDAL dal = DALContainer.Container.Resolve<IDepartmentDAL>();
        public override void SetDal()
        {
            Dal = dal;
        }
    }
}
