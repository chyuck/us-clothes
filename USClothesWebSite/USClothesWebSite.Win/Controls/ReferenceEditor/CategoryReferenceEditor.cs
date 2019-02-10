using System.Linq;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Dictionary;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public class CategoryReferenceEditor : ReferenceEditor<Category>
    {
        protected override Category[] GetDtos()
        {
            var dictionaryService = IoCContainer.Get<IDictionaryService>();
            var categories = dictionaryService.GetCategories(null);

            return categories.OrderBy(b => b.Name).ToArray();
        }
    }
}
