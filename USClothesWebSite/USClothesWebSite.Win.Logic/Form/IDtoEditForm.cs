using System;
using System.Windows.Forms;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Form
{
    public interface IDtoEditForm<out TDto>
        where TDto : class, IDto, ICloneable, new()
    {
        EditFormMode Mode { get; }
        TDto Dto { get; }

        DialogResult ShowDialog(IWin32Window owner);
    }
}
