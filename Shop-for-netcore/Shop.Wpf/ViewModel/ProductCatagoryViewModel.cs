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
namespace Shop.Wpf.ViewModel
{
   // [AutoMap(typeof(CreateProductCatagoryInput),typeof(UpdateProductCatagoryInput),typeof(QueryProductCatagoryInput),typeof(QueryProductCatagoryOutput))]
    public class ProductCatagoryViewModel :  ICleanViewModel,IIsSelectedViewModel
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

    public class ProductCatagoryResultViewModel : DataListViewModel<ProductCatagoryViewModel,long>
    {
        public ProductCatagoryResultViewModel()
        {
            this.Query = new ProductCatagoryViewModel();
            this.Form = new ProductCatagoryViewModel();
            this.TableForm = new ProductCatagoryViewModel();
        }
        private ItemViewModel items;
        public virtual ItemViewModel Items { get => items; set => SetProperty(ref items, value); }

    }


}



