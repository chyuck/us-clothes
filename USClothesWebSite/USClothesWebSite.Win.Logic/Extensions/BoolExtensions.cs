using System.Windows.Forms;

namespace USClothesWebSite.Win.Logic.Extensions
{
    public static class BoolExtensions
    {
        public static CheckState ToCheckState(this bool b)
        {
            return b ? CheckState.Checked : CheckState.Unchecked;
        }

        public static string ToYesNo(this bool b)
        {
            return b ? "Да" : "Нет";
        }
    }
}
