using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Abp.AutoMapper;
using System.Threading.Tasks;
using Utility.Wpf.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Shop.Application.Services.Dtos;
using Product.Application.Services.Products;

namespace Shop.Wpf.ViewModel
{
   // [AutoMap(typeof(CreateProductInput),typeof(UpdateProductInput),typeof(QueryProductInput),typeof(QueryProductOutput))]
    public class ProductViewModel :  ICleanViewModel,IIsSelectedViewModel
    {
               
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<IIsSelectedViewModel> AllSelectEvent;

        public virtual void Clean()
        {
         
        }
        public event PropertyChangedEventHandler PropertyChanged;


        protected  void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProductResultViewModel : DataListViewModel<ProductViewModel,long>
    {
        public ProductResultViewModel()
        {
            this.Query = new ProductViewModel();
            this.Form = new ProductViewModel();
            this.TableForm = new ProductViewModel();
        }
        private ItemViewModel items;
        public virtual ItemViewModel Items { get => items; set => SetProperty(ref items, value); }

    }


}



