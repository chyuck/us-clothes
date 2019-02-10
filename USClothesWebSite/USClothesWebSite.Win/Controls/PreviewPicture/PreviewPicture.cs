using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Async;
using USClothesWebSite.Win.Logic.Image;

namespace USClothesWebSite.Win.Controls.PreviewPicture
{
    public partial class PreviewPicture : UserControl
    {
        #region Constructors

        public PreviewPicture()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public new bool Enabled
        {
            get { return _loadButton.Enabled; }
            set { _loadButton.Enabled = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Picture Picture 
        {
            get
            {
                if (_picture == null)
                    return null;

                return (Picture)_picture.Clone();
            }
            set
            {
                _picture = value;
                UpdatePictureBox();
            }
        }
        private Picture _picture;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PreviewPictureURL
        {
            get
            {
                var picture = Picture;

                if (picture == null)
                    return null;

                return picture.PreviewPictureURL;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FullPictureURL
        {
            get
            {
                var picture = Picture;

                if (picture == null)
                    return null;

                return picture.FullPictureURL;
            }
        }

        #endregion
        

        #region Methods

        public void SetURLs(string previewPictureURL, string fullPictureURL)
        {
            
            if (string.IsNullOrEmpty(previewPictureURL) || string.IsNullOrWhiteSpace(fullPictureURL))
                return;

            Picture =
                new Picture
                {
                    PreviewPictureURL = previewPictureURL,
                    FullPictureURL = fullPictureURL
                };
        }

        public void Clear()
        {
            _pictureBox.ImageLocation = null;
        }

        private async Task<Picture> UploadPictureAsync(string path)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(path, "path");

            var container = IoC.Container;
            var imageService = container.Get<IImageService>();
            var asyncService = container.Get<IAsyncService>();

            return await asyncService.DoAsync(() => imageService.UploadPicture(path));
        }

        private async Task DeletePictureAsync(Picture picture)
        {
            CheckHelper.ArgumentNotNull(picture, "picture");

            var container = IoC.Container;
            var imageService = container.Get<IImageService>();
            var asyncService = container.Get<IAsyncService>();

            await asyncService.DoAsync(() => imageService.DeletePicture(picture));
        }

        private void UpdatePictureBox()
        {
            if (_picture != null)
                _pictureBox.ImageLocation = _picture.PreviewPictureURL;
        }

        #endregion


        #region Event Handlers

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            var picture = Picture;

            if (picture == null)
                return;

            var form = new FullPictureViewForm(picture.FullPictureURL);
            form.ShowDialog(ParentForm);
        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            if (_openImageDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                var imagePath = _openImageDialog.FileName;

                try
                {
                    _loadButton.Enabled = false;

                    var picture = await UploadPictureAsync(imagePath);

                    var oldPicture = Picture;
                    Picture = picture;

                    if (oldPicture != null)
                        await DeletePictureAsync(oldPicture);
                }
                finally 
                {
                    _loadButton.Enabled = true;
                }
            }
        }

        #endregion
    }
}
