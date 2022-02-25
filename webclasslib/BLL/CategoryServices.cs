using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;
using ViewModels;

namespace BLL 
{
    public class CategoryServices 
    {
        private readonly Context Context;
        public CategoryServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        public List<SelectionList> ListCategories()
        {
            List<SelectionList> info = 
				Context.Categories
				.Select(x => new SelectionList
				{
					ValueField = x.CategoryId,
					DisplayField = x.Description
				})
				.OrderBy(x => x.DisplayField)
				.ToList();
			return info;
        }

        #region QUERY


        #endregion
    }
}