using System;
using System.Windows.Forms;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Form
{
    public interface IDtoListForm<out TDto>
        where TDto : class, IDto, ICloneable, new()
    {
        ListFormMode Mode { get; }
        TDto Dto { get; }

        System.Windows.Forms.Form MdiParent { get; set; }
        System.Windows.Forms.Form Owner { get; set; }
        FormStartPosition StartPosition { get; set; }

        void Show();
        DialogResult ShowDialog(IWin32Window owner);
        DialogResult ShowDialog();
    }
}
