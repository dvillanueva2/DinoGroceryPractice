using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Additional namespaces
using BLL;
using Entities;
using ViewModels;

namespace MyApp.Namespace
{
    public class QueryCrudModel : PageModel
    {
        private readonly OtherServices Services;
		private readonly ProductServices ProductServices;
		private readonly CategoryServices CategoryServices;

        public QueryCrudModel(OtherServices services,
                            ProductServices productservices,
                            CategoryServices categoryservices)
		{
			Services = services;
			ProductServices = productservices;
			CategoryServices = categoryservices;
		}

        public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
        public List<Exception> Errors { get; set; } = new();
        [BindProperty]
		public string ButtonPressed { get; set; }
        [BindProperty]
		public string FilterType { get; set;}
        [BindProperty]
		public string PartialProductName { get ;set;}
		[BindProperty]
		public int? SelectedCategoryId  {get; set;}
        [BindProperty]
		public List<ProductList> SearchedProducts { get; set; }
        [BindProperty]
		public ProductItem Product { get; set; } = new();
        [BindProperty]
		public string Taxable { get; set; }
        [BindProperty]
		//public List<Category> SelectListOfCatagories {get;set;}
		public List<SelectionList> SelectListOfCategories { get; set; }

        public IActionResult OnGet()
		{
			try
			{
				Console.WriteLine("QueryModel: OnGet");
				PopulateSelectLists();
				GetProducts(FilterType);
				return Page();
			}
			catch (Exception ex)
			{
				GetInnerException(ex);
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			try
			{
				Console.WriteLine("QueryModel: OnPost"); 

				if (ButtonPressed == "SearchByPartialProductName") // shows results using partial string
				{
					FilterType = "PartialString";
				}
				else if (ButtonPressed == "SearchByCategory") // shows results using the category name
				{
					FilterType = "DropDown";
				}
				else if (ButtonPressed == "Add") // Add feature will be added later.
				{
					if (Taxable == "on")
						Product.Taxable = true;
					else
						Product.Taxable = false;
					FormatValidation();
					//Product.ProductId = ProductServices.Add(Product);
					SuccessMessage = "Update Successful";
				}
				if(Product.ProductId != 0)
				{
						Product = ProductServices.Retrieve(Product.ProductId);
						SuccessMessage = "Product Retrieve Successful";
				}
				else 
				{
					ErrorMessage = "Danger: At the end of our ropes!";
				}
			}
			catch (AggregateException ex)
			{
				ErrorMessage = ex.Message;
			}
			catch (Exception ex)
			{
				ErrorMessage = GetInnerException(ex);
			}
			PopulateSelectLists();
			GetProducts(FilterType);
			return Page();
		}

        
        private void PopulateSelectLists()
        {
            try
            {
                Console.WriteLine("Querymodel: PopulateSelectLists");
                SelectListOfCategories = CategoryServices.ListCategories();
            }
            catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
        }

		private void GetProducts(string filterType)
		{
			try
			{
				Console.WriteLine($"QueryCrudModel: GetProducts:filtertype= {filterType}");
				if(filterType == "PartialString")
					SearchedProducts = ProductServices.FindProductsByPartialName(PartialProductName);
				else if(filterType == "DropDown")
					SearchedProducts = ProductServices.FindProductsByCategory(SelectedCategoryId);
			}
			catch (Exception ex)
			{ 
				ErrorMessage = GetInnerException(ex);
			}
		}

		private void FormatValidation()
        {
			if(string.IsNullOrEmpty(Product.ProductName))
				Errors.Add(new Exception("ProductName"));
			// if(Product.SupplierId == 0)
			// 	Errors.Add(new Exception("SupplierId"));
			if(Product.CategoryId == 0)
				Errors.Add(new Exception("CategoryId"));
			if(string.IsNullOrEmpty(Product.UnitSize))
				Errors.Add(new Exception("UnitSize"));
			
			if (Errors.Count() > 0)
					throw new AggregateException("Invalid Data: ", Errors);
		}

        public string GetInnerException(Exception e)
		{
			Exception rootCause = e;
			while (rootCause.InnerException != null)
					rootCause = rootCause.InnerException;
			return rootCause.Message;
		}
    }
}
