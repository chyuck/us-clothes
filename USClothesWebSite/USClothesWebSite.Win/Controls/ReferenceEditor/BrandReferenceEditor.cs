using System.Linq;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Dictionary;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public class BrandReferenceEditor : ReferenceEditor<Brand>
    {
        protected override Brand[] GetDtos()
        {
            var dictionaryService = IoCContainer.Get<IDictionaryService>();
            var brands = dictionaryService.GetBrands(null);

            return brands.OrderBy(b => b.Name).ToArray();
        }
    }
}
