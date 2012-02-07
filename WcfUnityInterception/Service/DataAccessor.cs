using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FizzWare.NBuilder;

namespace WcfUnityInterception.Service
{
    public class DataAccessor : IDataAccessor
    {
        public LiquidsDataContract GetLiquidsLevel(int tankId)
        {
            if(tankId < 100)
                return Builder<LiquidsDataContract>.CreateNew().Build();
            throw new ArgumentException("Tank Id Out of Bounds");
        }

        public ReallyLongDataContract ReallyLongDataPull(int wellNumber, int rowCount)
        {
            return new ReallyLongDataContract { Data = Builder<LiquidsDataContract>.CreateListOfSize(rowCount)
                .All().With(x=>x.Name = "Oil Tank " + x.Level).Build() };
        }

        public void StartTransaction()
        {
            //Start Trans
        }

        public void CommitTransaction()
        {
            //Commit Trans
        }

        public void RollbackTransaction()
        {
            //Rollback Trans
        }
    }
}