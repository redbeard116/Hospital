using System;

namespace Hospital.DialogService
{
    public interface IDialogService
    {
        bool? ShowWindow(object view, object dataContext);

        void CloseWindow();
    }
}
