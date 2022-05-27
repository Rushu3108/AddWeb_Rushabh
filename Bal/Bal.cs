using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Dal;

namespace Bal
{
    public class ClientBal
    {
        Dalcls objdal = new Dalcls();
        public List<HomeModel> GetClientData(string strSearch = "")
        {
            return objdal.GetClientData(strSearch);
        }

        public int InsertClientData(HomeModel objHomeModel)
        {
            return objdal.InsertClientData(objHomeModel);
        }

    }
}