using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppV2.Model;
using BankAppV2.View;
using BankAppV2.Windows;

namespace BankAppV2.Presenter
{
    class PresenterRequest
    {

        IViewRequest view;
        ModelRequest mr;
        public PresenterRequest(IViewRequest view)
        {
            this.view = view;
            mr = new ModelRequest();
        }

        /// <summary>
        /// Открывает окно с запросом
        /// </summary>
        public void Open()
        {
            mr.Open(view);
        }
    }
}
