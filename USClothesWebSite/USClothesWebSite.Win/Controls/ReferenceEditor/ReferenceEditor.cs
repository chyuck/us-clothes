using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DepIC;
using USClothesWebSite.Win.Logic;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public partial class ReferenceEditor : UserControl
    {
        #region Constructors

        public ReferenceEditor()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        protected IReadOnlyContainer IoCContainer
        {
            get { return IoC.Container; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if (_readOnly != value)
                {
                    _readOnly = value;
                    UpdateAppearance();
                }
            }
        }
        private bool _readOnly;

        public ReferenceEditorMode Mode
        {
            get { return _mode; }
            set
            {
                if (_mode != value)
                {
                    _mode = value;
                    UpdateAppearance();
                }
            }
        }
        private ReferenceEditorMode _mode;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {
                return _value;
            }
            protected set
            {
                if (_value != value)
                {
                    _value = value;
                    UpdateAppearance();

                    if (ValueChanged != null)
                        ValueChanged(this, EventArgs.Empty);
                }
            }
        }
        private object _value;

        public bool CanBeCleared
        {
            get
            {
                return _canBeCleared;
            }
            set
            {
                if (_canBeCleared != value)
                {
                    _canBeCleared = value;
                    UpdateAppearance();
                }
            }
        }
        private bool _canBeCleared = true;

        protected bool IsComboBoxAppearance
        {
            get { return _mode == ReferenceEditorMode.ComboBox && !_readOnly; }
        }

        protected object[] Values
        {
            get
            {
                if (!IsComboBoxAppearance)
                    return null;

                return _descriptionComboBox.Items.Cast<object>().ToArray();
            }
            set
            {
                if (!IsComboBoxAppearance)
                    return;

                _descriptionComboBox.Items.Clear();

                if (value != null)
                {
                    _descriptionComboBox.Items.AddRange(value);
                    _descriptionComboBox.SelectedItem = _value;
                }

                if (_descriptionComboBox.SelectedItem == null)
                    _value = null;
            }
        }

        #endregion


        #region Methods

        private void UpdateAppearance()
        {
            _descriptionTextBox.Visible = !IsComboBoxAppearance;
            _descriptionComboBox.Visible = IsComboBoxAppearance;

            var buttonHeight = IsComboBoxAppearance ? 21 : 20;

            _selectButton.Height = buttonHeight;
            _clearButton.Height = buttonHeight;

            _selectButton.Enabled = !_readOnly;
            _clearButton.Enabled = _canBeCleared && !_readOnly;

            if (!IsComboBoxAppearance)
            {
                _descriptionTextBox.Text = _value != null ? _value.ToString() : string.Empty;
                _descriptionComboBox.Items.Clear();
            }
            else
            {
                _descriptionComboBox.SelectedItem = _value;
                _descriptionTextBox.Text = string.Empty;
            }
        }

        protected virtual void OnSelect()
        {
        }

        protected virtual void OnDispose()
        {
            ValueChanged = null;
        }

        protected virtual void OnParentChanged()
        {
        }

        #endregion
        

        #region Event Handlers

        private void ReferenceEditor_Load(object sender, EventArgs e)
        {
            UpdateAppearance();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            OnSelect();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Value = null;
        }

        private void DescriptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value = _descriptionComboBox.SelectedItem;
        }
        
        private void ReferenceEditor_ParentChanged(object sender, EventArgs e)
        {
            OnParentChanged();
        }

        #endregion


        #region Events

        public event EventHandler ValueChanged;

        #endregion
    }
}
