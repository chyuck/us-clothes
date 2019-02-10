using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Helpers
{
    public static class TrackableDtoListFormHelper
    {
        public static DataGridViewColumn[] Columns
        {
            get
            {
                return
                    new DataGridViewColumn[]
                        {
                            new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Создан", 
                                Width = 120, 
                                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                            },
                            new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Создал", 
                                Width = 120, 
                                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                            },
                            new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Изменен", 
                                Width = 120, 
                                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                            },
                            new DataGridViewTextBoxColumn
                            {
                                HeaderText = "Изменил", 
                                Width = 120, 
                                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                            }
                        };
            }
        }
        
        public static object[] GetValues(ITrackableDto dto)
        {
            CheckHelper.ArgumentNotNull(dto, "dto");

            return 
                new object[]
                {
                    dto.CreateDate.ToLocalTime().ToString("G"),
                    dto.CreateUser,
                    dto.ChangeDate.ToLocalTime().ToString("G"),
                    dto.ChangeUser
                };
        }
    }
}
