using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfUnityInterception.Service
{
    public interface IDataAccessor
    {
        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
