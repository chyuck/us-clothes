using System.Linq;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Dictionary;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public class SubCategoryReferenceEditor : ReferenceEditor<SubCategory>
    {
        protected override SubCategory[] GetDtos()
        {
            var dictionaryService = IoCContainer.Get<IDictionaryService>();
            var subCategories = dictionaryService.GetSubCategories(null);

            return subCategories.OrderBy(b => b.Name).ToArray();
        }
    }
}
