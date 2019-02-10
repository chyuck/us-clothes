using System.Windows.Forms;

namespace USClothesWebSite.Win.Logic.Menu
{
    public interface IMenuHolder
    {
        ToolStripMenuItem DictionariesMenuItem { get; }
        ToolStripMenuItem BrandsMenuItem { get; }
        ToolStripMenuItem CategoriesMenuItem { get; }
        ToolStripMenuItem SizesMenuItem { get; }
        ToolStripMenuItem ProductsMenuItem { get; }

        ToolStripMenuItem DocumentsMenuItem { get; }
        ToolStripMenuItem OrdersMenuItem { get; }
        ToolStripMenuItem ParcelsMenuItem { get; }
        ToolStripMenuItem DistributorTransfersMenuItem { get; }

        ToolStripMenuItem ReportsMenuItem { get; }
        ToolStripMenuItem ParcelReportMenuItem { get; }
        ToolStripMenuItem DistributorReportMenuItem { get; }

        ToolStripMenuItem SecurityMenuItem { get; }
        ToolStripMenuItem CurrentUserMenuItem { get; }
        ToolStripMenuItem ChangePasswordMenuItem { get; }
        ToolStripMenuItem UsersMenuItem { get; }

        ToolStripMenuItem AdministrationMenuItem { get; }
        ToolStripMenuItem LogsMenuItem { get; }
        ToolStripMenuItem SettingsMenuItem { get; }
    }
}
