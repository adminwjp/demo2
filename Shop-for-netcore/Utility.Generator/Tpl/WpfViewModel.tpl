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
using {.dto_namespace};
namespace {.namespace}
{
    [AutoMap(typeof(Create{.class}Input),typeof(Update{.class}Input),typeof(Query{.class}Input),typeof(Query{.class}Output))]
    public class {.class}ViewModel : {.class_dto}, ICleanViewModel,IIsSelectedViewModel
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

    public class {.class}ResultViewModel : DataListViewModel<{.class}ViewModel,long?>
    {
        public {.class}ResultViewModel()
        {
            this.Query = new {.class}ViewModel();
            this.Form = new {.class}ViewModel();
            this.TableForm = new {.class}ViewModel();
        }
        private ItemViewModel items;
        public virtual ItemViewModel Items { get => items; set => SetProperty(ref items, value); }

    }


}



