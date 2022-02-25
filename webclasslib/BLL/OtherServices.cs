using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;

namespace BLL 
{
    public class OtherServices 
    {
        private readonly Context Context;
        public  OtherServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        #region QUERY
        
        
        #endregion
    }
}