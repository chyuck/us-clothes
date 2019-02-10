using System;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Dictionary
{
    public partial class SizeListForm : BaseSizeListForm
    {
        public SizeListForm(ListFormMode mode, DTO.Size size)
            : this(mode, size, null)
        {
        }

        public SizeListForm(ListFormMode mode, DTO.Size size, Func<DTO.Size, bool> filter)
            : base(mode, size, filter)
        {
            InitializeComponent();
        }

        protected override DataGridViewColumn[] DtoColumns
        {
            get
            {
                var columns =
                    new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Название", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Активный", 
                            Width = 70, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Подкатегория", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Бренд", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Рост", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Вес", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        }
                    };

                return
                    columns
                        .Concat(TrackableDtoListFormHelper.Columns)
                        .ToArray();
            }
        }

        protected override DTO.Size[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IDictionaryService>().GetSizes(filter);
        }

        protected override object[] GetDtoValues(DTO.Size size)
        {
            var values =
                new object[]
                {
                    size.Name,
                    size.Active.ToYesNo(),
                    size.SubCategory.ToString(),
                    size.Brand.ToString(),
                    size.Height,
                    size.Weight
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(size))
                    .ToArray();
        }

        private void СopyButton_Click(object sender, EventArgs e)
        {
            var selectedDto = GetSelectedDto();

            if (selectedDto == null)
                return;

            var sizePrototype =
                new DTO.Size
                {
                    Name = selectedDto.Name,
                    Active = selectedDto.Active,
                    SubCategory = selectedDto.SubCategory,
                    Brand = selectedDto.Brand,
                    Height = selectedDto.Height,
                    Weight = selectedDto.Weight
                };

            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<DTO.Size>(EditFormMode.Create, sizePrototype);

            if (form.ShowDialog(this) == DialogResult.OK)
                RefreshAndSelect(form.Dto);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            _copyButton.Enabled = false;
        }

        protected override void OnSelect()
        {
            base.OnSelect();

            var size = GetSelectedDto();

            _copyButton.Enabled = (size != null);
        }
    }
    
    public class BaseSizeListForm : BaseDtoListForm<DTO.Size>
    {
        protected BaseSizeListForm() { }

        protected BaseSizeListForm(ListFormMode mode, DTO.Size size)
            : base(mode, size)
        {
        }

        protected BaseSizeListForm(ListFormMode mode, DTO.Size size, Func<DTO.Size, bool> filter)
            : base(mode, size, filter)
        {
        }
    }
}
