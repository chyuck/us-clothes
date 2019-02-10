using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;


namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class CategoryMockFactory
    {
        public static DataAccess.Category Children
        {
            get
            {
                return CacheHelper.Get(ref _children,
                    () =>
                        new DataAccess.Category
                        {
                            Id = 1,
                            Name = "Дети",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Category _children;

        public static DataAccess.Category Men
        {
            get
            {
                return CacheHelper.Get(ref _men,
                    () =>
                        new DataAccess.Category
                        {
                            Id = 2,
                            Name = "Мужчины",
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Category _men;

        public static DataAccess.Category Women
        {
            get
            {
                return CacheHelper.Get(ref _women,
                    () =>
                        new DataAccess.Category
                        {
                            Id = 3,
                            Name = "Женщины",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Category _women;

        public static IDbSet<DataAccess.Category> Categories
        {
            get
            {
                return CacheHelper.Get(ref _categories,
                    () =>
                    {
                        var categories =
                            new[]
                            {
                                Children, 
                                Men, 
                                Women
                            };

                        return new DbSetMock<DataAccess.Category>(categories);
                    });
            }
        }
        private static IDbSet<DataAccess.Category> _categories;

        public static void Reset()
        {
            _children = null;
            _men = null;
            _women = null;
            _categories = null;
        }

        public static void InitializeRelations()
        {
            Children.CreateUserId = UserMockFactory.Andrey.Id;
            Children.CreatedBy = UserMockFactory.Andrey;
            Children.ChangeUserId = UserMockFactory.Andrey.Id;
            Children.ChangedBy = UserMockFactory.Andrey;

            Men.CreateUserId = UserMockFactory.Andrey.Id;
            Men.CreatedBy = UserMockFactory.Andrey;
            Men.ChangeUserId = UserMockFactory.Jenya.Id;
            Men.ChangedBy = UserMockFactory.Jenya;

            Women.CreateUserId = UserMockFactory.Andrey.Id;
            Women.CreatedBy = UserMockFactory.Andrey;
            Women.ChangeUserId = UserMockFactory.Andrey.Id;
            Women.ChangedBy = UserMockFactory.Andrey;
        }

        public static void InitializeCollections()
        {
            foreach (var category in Categories)
            {
                category.SubCategories =
                    SubCategoryMockFactory.SubCategories
                        .Where(sc => sc.Category == category)
                        .ToArray();
            }
        }
    }
}
