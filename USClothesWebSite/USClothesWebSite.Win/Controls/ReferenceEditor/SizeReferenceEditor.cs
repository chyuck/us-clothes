using System.Linq;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Dictionary;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public class SizeReferenceEditor : ReferenceEditor<Size>
    {
        protected override Size[] GetDtos()
        {
            var dictionaryService = IoCContainer.Get<IDictionaryService>();
            var sizes = dictionaryService.GetSizes(null);

            return sizes.OrderBy(b => b.Name).ToArray();
        }
    }
}
