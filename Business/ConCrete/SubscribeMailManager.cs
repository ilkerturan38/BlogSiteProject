using DataAccess.ConCrete;
using Entity.ConCrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ConCrete
{
    public class SubscribeMailManager
    {
        GenericRepository<SubscribeMail> repoSubscribeMail = new GenericRepository<SubscribeMail>();

        public void businessLayerAdd(SubscribeMail p)
        {
             repoSubscribeMail.Insert(p);
        }

    }
}
