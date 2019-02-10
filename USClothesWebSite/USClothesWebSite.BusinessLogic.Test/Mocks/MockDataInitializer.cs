namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class MockDataInitializer
    {
        public static void Reset()
        {
            RoleMockFactory.Reset();
            UserMockFactory.Reset();
            UserRoleMockFactory.Reset();

            CategoryMockFactory.Reset();
            SubCategoryMockFactory.Reset();
            BrandMockFactory.Reset();
            SizeMockFactory.Reset();

            ActionLogTypeMockFactory.Reset();
            ActionLogMockFactory.Reset();

            ProductMockFactory.Reset();
            ProductSizeMockFactory.Reset();

            SettingsMockFactory.Reset();

            ParcelMockFactory.Reset();
            OrderMockFactory.Reset();
            OrderItemMockFactory.Reset();

            DistributorTransferMockFactory.Reset();
        }

        public static void InitializeRelations()
        {
            RoleMockFactory.InitializeRelations();
            UserMockFactory.InitializeRelations();
            UserRoleMockFactory.InitializeRelations();

            CategoryMockFactory.InitializeRelations();
            SubCategoryMockFactory.InitializeRelations();
            BrandMockFactory.InitializeRelations();
            SizeMockFactory.InitializeRelations();

            ActionLogTypeMockFactory.InitializeRelations();
            ActionLogMockFactory.InitializeRelations();

            ProductMockFactory.InitializeRelations();
            ProductSizeMockFactory.InitializeRelations();

            SettingsMockFactory.InitializeRelations();

            ParcelMockFactory.InitializeRelations();
            OrderMockFactory.InitializeRelations();
            OrderItemMockFactory.InitializeRelations();

            DistributorTransferMockFactory.InitializeRelations();
        }

        public static void InitializeCollections()
        {
            RoleMockFactory.InitializeCollections();
            UserMockFactory.InitializeCollections();
            UserRoleMockFactory.InitializeCollections();

            CategoryMockFactory.InitializeCollections();
            SubCategoryMockFactory.InitializeCollections();
            BrandMockFactory.InitializeCollections();
            SizeMockFactory.InitializeCollections();

            ActionLogTypeMockFactory.InitializeCollections();
            ActionLogMockFactory.InitializeCollections();

            ProductMockFactory.InitializeCollections();
            ProductSizeMockFactory.InitializeCollections();

            SettingsMockFactory.InitializeCollections();

            ParcelMockFactory.InitializeCollections();
            OrderMockFactory.InitializeCollections();
            OrderItemMockFactory.InitializeCollections();

            DistributorTransferMockFactory.InitializeCollections();
        }
    }
}
