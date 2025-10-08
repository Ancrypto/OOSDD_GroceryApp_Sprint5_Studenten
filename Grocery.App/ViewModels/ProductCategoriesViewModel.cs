using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "CategoryId")]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;

        private int categoryId;
        public int CategoryId
        {
            get => categoryId;
            set
            {
                SetProperty(ref categoryId, value);
                Category = _categoryService.Get(categoryId);
            }
        }


        [ObservableProperty]
        private Category category;

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, ICategoryService categoryService)
        {
            _productCategoryService = productCategoryService;
            _categoryService = categoryService;
        }
    }
}