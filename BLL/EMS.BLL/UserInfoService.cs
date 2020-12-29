using EMS.IBLL;
using EMS.IDAL;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL
{
    public partial class UserInfoService: BaseService<UserInfo>,IUserInfoService
    {
        private IUserInfoDAL dal = DALContainer.Container.Resolve<IUserInfoDAL>();
        public override void SetDal()
        {
            Dal = dal;
        }
    }
}
