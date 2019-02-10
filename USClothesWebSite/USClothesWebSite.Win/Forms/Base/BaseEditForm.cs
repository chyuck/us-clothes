using System;
using System.Drawing;
using System.Windows.Forms;
using DepIC;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Async;

namespace USClothesWebSite.Win.Forms.Base
{
    public partial class BaseEditForm : Form
    {
        #region Fields

        private bool _isSaved;

        #endregion


        #region Constructors

        public BaseEditForm()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        protected IReadOnlyContainer IoCContainer
        {
            get { return IoC.Container; }
        }

        protected virtual string SavingMessage
        {
            get { return "Выполняется сохранение..."; }
        }

        protected virtual string InitialMessage
        {
            get { return @"Заполните поля и нажмите ""Сохранить"""; }
        }

        #endregion


        #region Methods

        protected virtual void SetMessage(string message)
        {
            ErrorMessageTextBox.ScrollBars = ScrollBars.None;
            ErrorMessageTextBox.Text = message;
            ErrorMessageTextBox.ForeColor = SystemColors.ControlText;
        }

        protected virtual void SetError(string message)
        {
            ErrorMessageTextBox.Text = message;
            ErrorMessageTextBox.ForeColor = Color.Red;

            ErrorMessageTextBox.ScrollBars =
                ErrorMessageTextBox.Lines.Length <= 3
                    ? ScrollBars.None
                    : ScrollBars.Vertical;
        }

        protected virtual void OnLoad()
        {
            SetMessage(InitialMessage);
        }

        protected virtual void OnBeforeSave()
        {
            SetMessage(SavingMessage);

            Enabled = false;
        }

        protected virtual string OnSave()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnAfterSave()
        {
            Enabled = true;
        }
        
        protected virtual void OnException()
        {
            SetMessage(InitialMessage);
        }

        protected virtual void OnClose()
        {
            Owner = null;
        }

        #endregion


        #region Event Handlers

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                OnLoad();
        }
        
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                OnBeforeSave();
                
                var asyncService = IoCContainer.Get<IAsyncService>();
                var errorMessage = await asyncService.DoAsync<string>(OnSave);

                if (errorMessage != null)
                {
                    SetError(errorMessage);
                    
                    _isSaved = false;
                    return;
                }

                _isSaved = true;
                Close();
            }
            catch (Exception)
            {
                OnException();
                throw;
            }
            finally
            {
                OnAfterSave();
            }
        }

        private void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (DialogResult == DialogResult.Cancel)
                e.Cancel = false;

            if (_isSaved)
                DialogResult = DialogResult.OK;
        }

        private void BaseEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClose();
        }

        #endregion
    }
}
