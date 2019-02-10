using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Controls.PreviewPicture;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public partial class BaseDtoEditForm : BaseEditForm
    {
        #region Fields

        private readonly IDto _dto;

        #endregion
        

        #region Constructors

        public BaseDtoEditForm()
        {
            InitializeComponent();
        }

        public BaseDtoEditForm(EditFormMode mode, IDto dto)
            : this()
        {
            CheckHelper.ArgumentWithinCondition(
                mode == EditFormMode.Create
                ||
                dto != null && dto.Id > 0 && mode != EditFormMode.Create,
                "Invalid usage");

            _dto = dto;
            Mode = mode;
        }

        #endregion


        #region Properties

        public EditFormMode Mode { get; private set; }

        protected virtual IEnumerable<Control> EditControls
        {
            get { return new Control[] { }; }
        }

        protected override string InitialMessage
        {
            get
            {
                if (Mode == EditFormMode.View)
                    return string.Empty;

                return base.InitialMessage;
            }
        }

        #endregion


        #region Methods
        
        protected virtual void CustomizeControls()
        {
            EditControls
                .ForEach(
                    c =>
                    {
                        var textBox = c as TextBox;
                        if (textBox != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(textBox, Mode);
                            return;
                        }

                        var numericUpDown = c as NumericUpDown;
                        if (numericUpDown != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(numericUpDown, Mode);
                            return;
                        }

                        var dateTimePicker = c as DateTimePicker;
                        if (dateTimePicker != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(dateTimePicker, Mode);
                            return;
                        }

                        var button = c as Button;
                        if (button != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(button, Mode);
                            return;
                        }

                        var checkBox = c as CheckBox;
                        if (checkBox != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(checkBox, Mode);
                            return;
                        }

                        var checkedListBox = c as CheckedListBox;
                        if (checkedListBox != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(checkedListBox, Mode);
                            return;
                        }

                        var referenceEditor = c as ReferenceEditor;
                        if (referenceEditor != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(referenceEditor, Mode);
                            return;
                        }

                        var previewPicture = c as PreviewPicture;
                        if (previewPicture != null)
                        {
                            ControlCustomizeHelper.CustomizeControl(previewPicture, Mode);
                            return;
                        }

                        throw new NotSupportedException(c.GetType().ToString());
                    });

            SaveButton.Visible =
            SaveButton.Enabled =
                Mode != EditFormMode.View;
        }
        
        protected override void OnLoad()
        {
            base.OnLoad();

            CustomizeControls();

            SetDataToControls();
        }

        protected virtual void SetDataToControls()
        {
            if (_dto != null && _dto.Id > 0)
            {
                IdTextBox.Text = _dto.Id.ToString();
            }
        }
        
        #endregion
    }
}
