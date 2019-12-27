namespace appAddress.ViewModels
{
    using app.Models;
    using app.Services;
    using app.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class BookViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<List> lists;
        #endregion

        #region Properties
        public ObservableCollection<List>List  
        {
            get { return this.lists; }
            set { SetValue(ref this.lists, value); }
        }
        #endregion

        #region Constructor
        public BookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadBooks();

        }
        #endregion

        #region Method
        private async void LoadBooks()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error en Internet",
                    connection.Message,
                    "Accept"
                    );

                return;
            }
            var response = await apiService.GetList<List>(
             "http://localhost:49910/",
             "api/",
             "Books"
             );
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Service Book Error",
                    response.Message,
                    "Acept"
                    );
                return;
            }
            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.SetListList((List<List>)response.Result);

            this.lists = new ObservableCollection<List>(this.ToListCollect());
        }

        private IEnumerable<List> ToListCollect()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<List> ToBookCollect()
        {
            ObservableCollection<List> collect = new ObservableCollection<List>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.List)
            {
                List list  = new List();
                list.listID = lista.listID;
                list.Name = lista.Name;
                list.Type = lista.Type;
                list.contact = lista.contact;
                collect.Add(list);

            }
            return (collect);
        }
        #endregion

    }
}
