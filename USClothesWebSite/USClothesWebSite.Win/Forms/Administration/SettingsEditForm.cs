using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Administration;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Administration
{
    public partial class SettingsEditForm : BaseSettingsEditForm
    {
        public SettingsEditForm(EditFormMode mode, Settings settings)
            : base(mode, settings)
        {
            InitializeComponent();
        }
        
        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _rublesPerDollarNumericUpDown
                    };
            }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            base.OnLoad();
        }

        protected override void SetDtoToControls(Settings settings)
        {
            _rublesPerDollarNumericUpDown.Value = settings.RublesPerDollar;
        }

        protected override void SetControlsToDto(Settings settings)
        {
            settings.RublesPerDollar = _rublesPerDollarNumericUpDown.Value;
        }

        protected override string OnUpdate(Settings settings)
        {
            return IoCContainer.Get<IAdministrationService>().UpdateSettings(settings);
        }
    }

    public class BaseSettingsEditForm : BaseDtoEditForm<Settings>
    {
        protected BaseSettingsEditForm() { }

        protected BaseSettingsEditForm(EditFormMode mode, Settings settings)
            : base(mode, settings)
        {
        }
    }
}
