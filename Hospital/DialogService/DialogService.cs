using System;
using Hospital.View;
using System.Windows;

namespace Hospital.DialogService
{
    public class DialogService : IDialogService
    {
        private Window window; 

        public bool? ShowWindow(object view,object dataContext)
        {
            window = view as Window;
            window.DataContext = dataContext;
            return window.ShowDialog();
        }

        public void CloseWindow()
        {
            window.Close();
        }
    }
}
