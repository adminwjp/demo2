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
    [AutoMap(typeof(CreateSellerIntegralSettingInput),typeof(UpdateSellerIntegralSettingInput),typeof(QuerySellerIntegralSettingInput),typeof(QuerySellerIntegralSettingOutput))]
    public class SellerIntegralSettingViewModel : QuerySellerIntegralSettingOutput, ICleanViewModel,IIsSelectedViewModel
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

    public class SellerIntegralSettingResultViewModel : DataListViewModel<SellerIntegralSettingViewModel,long>
    {
        public SellerIntegralSettingResultViewModel()
        {
            this.Query = new SellerIntegralSettingViewModel();
            this.Form = new SellerIntegralSettingViewModel();
            this.TableForm = new SellerIntegralSettingViewModel();
        }
        private ItemViewModel items;
        public virtual ItemViewModel Items { get => items; set => SetProperty(ref items, value); }

    }


}



