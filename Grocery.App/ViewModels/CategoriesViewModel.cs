using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<Category> Categories { get; set; } = new();

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = [];
            foreach (Category p in _categoryService.GetAll()) Categories.Add(p);
        }

        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            System.Diagnostics.Debug.WriteLine("Clicked on category");
            try
            {
                await Shell.Current.GoToAsync($"ProductCategoriesView?CategoryId={category.Id}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation Exception: {ex}");
                // Optionally, show an alert to the user
            }
        }
    }
}
