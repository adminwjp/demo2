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
    [AutoMap(typeof(CreateSellerCouponSettsingInput),typeof(UpdateSellerCouponSettsingInput),typeof(QuerySellerCouponSettsingInput),typeof(QuerySellerCouponSettsingOutput))]
    public class SellerCouponSettsingViewModel : QuerySellerCouponSettsingOutput, ICleanViewModel,IIsSelectedViewModel
    {
               
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<IIsSelectedViewModel> AllSelectEvent;

        public virtual void Clean()
        {
         
        }
        public event PropertyChangedEventHandler PropertyChanged;


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SellerCouponSettsingResultViewModel : DataListViewModel<SellerCouponSettsingViewModel,long>
    {
        public SellerCouponSettsingResultViewModel()
        {
            this.Query = new SellerCouponSettsingViewModel();
            this.Form = new SellerCouponSettsingViewModel();
            this.TableForm = new SellerCouponSettsingViewModel();
        }
        private ItemViewModel items;
        public virtual ItemViewModel Items { get => items; set => SetProperty(ref items, value); }

    }


}



