using app.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<List> List { get; set; }
        #endregion

        #region ViewModel
        public ListViewModel listViewModel { get; set; }

        private List<List> listList;

        public List<List> ListList => listList;

        internal void SetListList(List<List> value)
        {
            listList = value;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.listViewModel = new ListViewModel();
        }
        #endregion

        #region singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()

        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion
    }
}
