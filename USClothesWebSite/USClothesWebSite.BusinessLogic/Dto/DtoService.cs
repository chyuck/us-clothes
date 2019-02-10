using System;
using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.DTO;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Dto
{
    internal class DtoService : BaseService, IDtoService
    {
        #region Fields

        private readonly IDtoCache _dtoCache;

        #endregion


        #region Constructors

        [Inject]
        public DtoService(IReadOnlyContainer container)
            : base(container)
        {
            _dtoCache = Container.Get<IDtoCache>();
        }

        #endregion


        #region Methods

        private static void CopyTrackableFields(ITrackableDto target, ITrackableEntity source)
        {
            CheckHelper.ArgumentNotNull(target, "target");
            CheckHelper.ArgumentNotNull(source, "source");

            target.CreateDate = source.CreateDate;
            target.CreateUser = source.CreatedBy.GetFullName();

            target.ChangeDate = source.ChangeDate;
            target.ChangeUser = source.ChangedBy.GetFullName();
        }

        #endregion


        #region IDtoService

        public DTO.Category CreateCategory(DataAccess.Category category, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(category, "category");
            CheckHelper.ArgumentWithinCondition(!category.IsNew(), "!category.IsNew()");

            return
                _dtoCache.Get(
                    category,
                    c =>
                    {
                        var result =
                            new DTO.Category
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Active = c.Active
                            };

                        CopyTrackableFields(result, c);

                        return result;
                    },
                    (cDto, c) =>
                        cDto.SubCategories =
                            c.SubCategories
                                .Where(sc => sc.Active || !includeOnlyActive)
                                .OrderBy(sc => sc.Name)
                                .Select(sc => CreateSubCategory(sc, includeOnlyActive))
                                .ToArray());
        }

        public DTO.SubCategory CreateSubCategory(DataAccess.SubCategory subCategory, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.ArgumentWithinCondition(!subCategory.IsNew(), "!subCategory.IsNew()");

            return
                _dtoCache.Get(
                    subCategory,
                    sc =>
                    {
                        var result =
                            new DTO.SubCategory
                            {
                                Id = sc.Id,
                                Name = sc.Name,
                                Active = sc.Active
                            };

                        CopyTrackableFields(result, sc);

                        return result;
                    },
                    (scDto, sc) =>
                        scDto.Category = CreateCategory(sc.Category, includeOnlyActive));
        }

        public DTO.User CreateUser(DataAccess.User user, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.ArgumentWithinCondition(!user.IsNew(), "!user.IsNew()");

            return
                _dtoCache.Get(
                    user, 
                    u =>
                    {
                        var result =
                            new DTO.User
                            {
                                Id = u.Id,
                                Login = user.Login,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                Active = u.Active
                            };

                        CopyTrackableFields(result, u);

                        return result;
                    },
                    (uDto, u) =>
                        uDto.Roles = 
                            u.UserRoles
                                .Where(ur => ur.Active || !includeOnlyActive)
                                .Select(ur => ur.Role)
                                .OrderBy(r => r.Name)
                                .Select(r => CreateRole(r, includeOnlyActive))
                                .ToArray());
        }

        public DTO.Role CreateRole(DataAccess.Role role, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(role, "role");
            CheckHelper.ArgumentWithinCondition(!role.IsNew(), "!role.IsNew()");

            return
                _dtoCache.Get(
                    role,
                    r =>
                        new DTO.Role
                        {
                            Id = r.Id,
                            Name = r.Name
                        });
        }

        public DTO.Size CreateSize(DataAccess.Size size, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(size, "size");
            CheckHelper.ArgumentWithinCondition(!size.IsNew(), "!size.IsNew()");

            return
                _dtoCache.Get(
                    size,
                    s =>
                    {
                        var result =
                            new DTO.Size
                            {
                                Id = s.Id,
                                Name = s.Name,
                                Height = s.Height,
                                Weight = s.Weight,
                                Active = s.Active
                            };

                        CopyTrackableFields(result, s);

                        return result;
                    },
                    (sDto, s) =>
                        {
                            sDto.Brand = CreateBrand(s.Brand, includeOnlyActive);
                            sDto.SubCategory = CreateSubCategory(s.SubCategory, includeOnlyActive);
                        });
        }

        public DTO.Brand CreateBrand(DataAccess.Brand brand, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(brand, "brand");
            CheckHelper.ArgumentWithinCondition(!brand.IsNew(), "!brand.IsNew()");

            return
                _dtoCache.Get(
                    brand,
                    b =>
                    {
                        var result =
                            new DTO.Brand
                            {
                                Id = b.Id,
                                Name = b.Name,
                                Active = b.Active
                            };

                        CopyTrackableFields(result, b);

                        return result;
                    });
        }

        public DTO.Product CreateProduct(DataAccess.Product product, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(product, "product");
            CheckHelper.ArgumentWithinCondition(!product.IsNew(), "!product.IsNew()");

            return
                _dtoCache.Get(
                    product,
                    p =>
                    {
                        var httpService = Container.Get<IHttpService>();

                        var result =
                            new DTO.Product
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                PreviewPictureURL = httpService.GetAbsoluteURLFromRelativeURL(p.PreviewPictureURL),
                                FullPictureURL = httpService.GetAbsoluteURLFromRelativeURL(p.FullPictureURL),
                                VendorShopURL = p.VendorShopURL,
                                Active = p.Active
                            };

                        CopyTrackableFields(result, p);

                        return result;
                    },
                    (pDto, p) =>
                    {
                        pDto.Brand = CreateBrand(p.Brand, includeOnlyActive);
                        pDto.SubCategory = CreateSubCategory(p.SubCategory, includeOnlyActive);
                        pDto.ProductSizes =
                            p.ProductSizes
                                .Where(ps => ps.Active || !includeOnlyActive)
                                .OrderBy(ps => ps.Size.Name)
                                .Select(ps => CreateProductSize(ps, includeOnlyActive))
                                .ToArray();
                    });
        }

        public DTO.ProductSize CreateProductSize(DataAccess.ProductSize productSize, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(productSize, "productSize");
            CheckHelper.ArgumentWithinCondition(!productSize.IsNew(), "!productSize.IsNew()");

            return
                _dtoCache.Get(
                    productSize,
                    ps =>
                    {
                        var result =
                            new DTO.ProductSize
                            {
                                Id = ps.Id,
                                Price = ps.Price,
                                Active = ps.Active
                            };

                        CopyTrackableFields(result, ps);

                        return result;
                    },
                    (psDto, ps) =>
                    {
                        psDto.Size = CreateSize(ps.Size, includeOnlyActive);
                        psDto.Product = CreateProduct(ps.Product, includeOnlyActive);
                    });
        }

        public DTO.Parcel CreateParcel(DataAccess.Parcel parcel, bool includeOnlyActive = false, Func<DataAccess.Order, bool> predicate = null)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");
            CheckHelper.ArgumentWithinCondition(!parcel.IsNew(), "!parcel.IsNew()");

            return
                _dtoCache.Get(
                    parcel,
                    p =>
                    {
                        var result =
                            new DTO.Parcel
                            {
                                Id = p.Id,
                                Comments = p.Comments,
                                RublesPerDollar = p.RublesPerDollar,
                                PurchaserSpentOnDelivery = p.PurchaserSpentOnDelivery,
                                SentDate = p.SentDate,
                                ReceivedDate = p.ReceivedDate,
                                TrackingNumber = p.TrackingNumber,
                                CreateUserId = p.CreateUserId
                            };

                        CopyTrackableFields(result, p);

                        return result;
                    },
                    (pDto, p) =>
                    {
                        pDto.Distributor = p.Distributor != null ? CreateUser(p.Distributor) : null;

                        predicate = predicate ?? (o => true);
                        pDto.Orders =
                            p.Orders
                                .Where(o => o.Active || !includeOnlyActive)
                                .Where(predicate)
                                .OrderBy(o => o.Id)
                                .Select(o => CreateOrder(o, includeOnlyActive))
                                .ToArray();
                    });
        }

        public DTO.Order CreateOrder(DataAccess.Order order, bool includeOnlyActive = false, Func<DataAccess.Order, bool> predicate = null)
        {
            CheckHelper.ArgumentNotNull(order, "order");
            CheckHelper.ArgumentWithinCondition(!order.IsNew(), "!order.IsNew()");

            return
                _dtoCache.Get(
                    order,
                    o =>
                    {
                        var result =
                            new DTO.Order
                            {
                                Id = o.Id,
                                OrderDate = o.OrderDate,
                                CustomerFirstName = o.CustomerFirstName,
                                CustomerLastName = o.CustomerLastName,
                                CustomerAddress = o.CustomerAddress,
                                CustomerCity = o.CustomerCity,
                                CustomerCountry = o.CustomerCountry,
                                CustomerPostalCode = o.CustomerPostalCode,
                                CustomerPhoneNumber = o.CustomerPhoneNumber,
                                CustomerEmail = o.CustomerEmail,
                                Active = o.Active,
                                Comments = o.Comments,
                                RublesPerDollar = o.RublesPerDollar,
                                CustomerPaid = o.CustomerPaid,
                                CustomerPrepaid = o.CustomerPrepaid,
                                DistributorSpentOnDelivery = o.DistributorSpentOnDelivery,
                                TrackingNumber = o.TrackingNumber,
                                CreateUserId = o.CreateUserId
                            };

                        CopyTrackableFields(result, o);

                        return result;
                    },
                    (oDto, o) =>
                    {
                        oDto.Parcel = o.Parcel != null ? CreateParcel(o.Parcel, includeOnlyActive, predicate) : null;
                        oDto.OrderItems =
                            o.OrderItems
                                .Where(oi => oi.Active || !includeOnlyActive)
                                .OrderBy(oi => oi.ProductSize.Product.Name)
                                .ThenBy(oi => oi.ProductSize.Size.Name)
                                .Select(oi => CreateOrderItem(oi, includeOnlyActive))
                                .ToArray();
                    });
        }

        public DTO.OrderItem CreateOrderItem(DataAccess.OrderItem orderItem, bool includeOnlyActive = false, Func<DataAccess.Order, bool> predicate = null)
        {
            CheckHelper.ArgumentNotNull(orderItem, "orderItem");
            CheckHelper.ArgumentWithinCondition(!orderItem.IsNew(), "!orderItem.IsNew()");

            return
                _dtoCache.Get(
                    orderItem,
                    oi =>
                    {
                        var result =
                            new DTO.OrderItem
                            {
                                Id = oi.Id,
                                Quantity = oi.Quantity,
                                Active = oi.Active,
                                Price = oi.Price,
                                PurchaserPaid = oi.PurchaserPaid,
                                CreateUserId = oi.CreateUserId
                            };

                        CopyTrackableFields(result, oi);

                        return result;
                    },
                    (oiDto, oi) =>
                    {
                        oiDto.Order = CreateOrder(oi.Order, includeOnlyActive, predicate);
                        oiDto.ProductSize = CreateProductSize(oi.ProductSize);
                    });
        }

        public DTO.Session CreateSession(DataAccess.Session session, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(session, "session");
            CheckHelper.ArgumentWithinCondition(!session.IsNew(), "!session.IsNew()");

            return
                _dtoCache.Get(
                    session,
                    s =>
                        new DTO.Session
                        {
                            Id = s.Id,
                            CreateDate = s.CreateDate,
                            Key = s.Key
                        });
        }

        public DTO.ShoppingCart CreateShoppingCart(DataAccess.ShoppingCart shoppingCart, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(shoppingCart, "shoppingCart");
            CheckHelper.ArgumentWithinCondition(!shoppingCart.IsNew(), "!shoppingCart.IsNew()");

            return
                _dtoCache.Get(
                    shoppingCart,
                    sc =>
                        new DTO.ShoppingCart
                        {
                            Id = sc.Id, 
                            Quantity = sc.Quantity,
                            TotalPrice = sc.TotalPrice
                        },
                    (scDto, sc) =>
                    {
                        scDto.Session = CreateSession(sc.Session, includeOnlyActive);
                        scDto.ProductSize = CreateProductSize(sc.ProductSize, includeOnlyActive);
                    });
        }

        public DTO.DistributorTransfer CreateDistributorTransfer(DataAccess.DistributorTransfer distributorTransfer, bool includeOnlyActive = true)
        {
            CheckHelper.ArgumentNotNull(distributorTransfer, "distributorTransfer");
            CheckHelper.ArgumentWithinCondition(!distributorTransfer.IsNew(), "!distributorTransfer.IsNew()");

            return
                _dtoCache.Get(
                    distributorTransfer,
                    dt =>
                    {
                        var result =
                            new DTO.DistributorTransfer
                            {
                                Id = dt.Id,
                                Amount = dt.Amount,
                                Date = dt.Date,
                                Active = dt.Active,
                                RublesPerDollar = dt.RublesPerDollar
                            };

                        CopyTrackableFields(result, dt);

                        return result;
                    });
        }

        public DTO.ActionLogType CreateActionLogType(DataAccess.ActionLogType actionLogType)
        {
            CheckHelper.ArgumentNotNull(actionLogType, "actionLogType");
            CheckHelper.ArgumentWithinCondition(!actionLogType.IsNew(), "!actionLogType.IsNew()");

            return 
                _dtoCache.Get(
                        actionLogType,
                        alt =>
                            new DTO.ActionLogType
                            {
                                Id = alt.Id,
                                Name = alt.Name
                            });
        }

        public DTO.ActionLog CreateActionLog(DataAccess.ActionLog actionLog)
        {
            CheckHelper.ArgumentNotNull(actionLog, "actionLog");
            CheckHelper.ArgumentWithinCondition(!actionLog.IsNew(), "!actionLog.IsNew()");

            return
                _dtoCache.Get(
                    actionLog,
                    al =>
                        new DTO.ActionLog
                        {
                            Id = al.Id,
                            Text = al.Text,
                            DocumentId = al.DocumentId,
                            CreateDate = al.CreateDate,
                            CreateUser = al.CreateUser.GetFullName()
                        },
                    (alDto, al) =>
                    {
                        alDto.ActionLogType = CreateActionLogType(al.ActionLogType);
                    });
        }

        public DTO.Settings CreateSettings(DataAccess.Settings settings)
        {
            CheckHelper.ArgumentNotNull(settings, "settings");
            CheckHelper.ArgumentWithinCondition(!settings.IsNew(), "!settings.IsNew()");

            return
                _dtoCache.Get(
                    settings,
                    s =>
                    {
                        var result =
                            new DTO.Settings
                            {
                                Id = s.Id,
                                RublesPerDollar =s.RublesPerDollar
                            };

                        CopyTrackableFields(result, s);

                        return result;
                    });
        }

        #endregion
    }
}
