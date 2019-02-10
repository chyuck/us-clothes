using System.Windows.Forms;

namespace USClothesWebSite.Win.Controls
{
    public partial class FilterControl : UserControl
    {
        public FilterControl()
        {
            InitializeComponent();
        }

        public string FilterText
        {
            get
            {
                return _filterWatermarkedTextBox.Text;
            }
            set
            {
                _filterWatermarkedTextBox.Text = value;
            }
        }

        private void ClearFilterButton_Click(object sender, System.EventArgs e)
        {
            _filterWatermarkedTextBox.Clear();
        }
    }
}
