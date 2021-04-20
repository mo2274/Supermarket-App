using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataBaseAccess
    {

        #region Product Methods

        public static List<DisplayType> GetProducts()
        {
            using (var db = new Supermarket())
            {
                return db.Products.Include("Category")
                    .Select(p => new DisplayType() { Id = p.Id, Name = p.Name, Quantity = p.Quantity, Price = p.Price, Category = p.Category.Name })
                    .ToList();
            }
        }

        public static List<DisplayType> GetProductsByCategory(string CategoryName)
        {
            using (var db = new Supermarket())
            {
                return db.Products.Include("Category").Where(p => p.Category.Name == CategoryName)
                    .Select(p => new DisplayType() { Id = p.Id, Name = p.Name, Quantity = p.Quantity, Price = p.Price, Category = p.Category.Name })
                    .ToList();
            }
        }

        public static bool AddProduct(string name, int quantity, double price, Category category)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var product = new Product()
                    {
                        Name = name,
                        Quantity = quantity,
                        Price = price,
                        CategoryId = category.Id,
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool EditProduct(int id, string name, int quantity, double price, Category category)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var product = db.Products.Find(id);
                    if (product == null)
                        return false;
                    product.Name = name;
                    product.Quantity = quantity;
                    product.Price = price;
                    product.CategoryId = category.Id;                   
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteProduct(int id)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var product = db.Products.Find(id);
                    if (product == null)
                        return false;
                    db.Products.Remove(product);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion
        #region Seller Methods
        public static bool EditSeller(int id, string name, int age, string phone, string password, string emailAddress)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var seller = db.Sellers.Find(id);
                    if (seller == null)
                        return false;
                    seller.Name = name;
                    seller.Age = age;
                    seller.Phone = phone;
                    seller.Password = password;
                    seller.EmailAddress = emailAddress;
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteSeller(int id)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var seller = db.Sellers.Find(id);
                    if (seller == null)
                        return false;
                    db.Sellers.Remove(seller);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool CheckIfSellerExists(string userName, string password)
        {
            using (var db = new Supermarket())
            {
                var sellerData = db.Sellers.FirstOrDefault(s => s.Name == userName);
                if (sellerData == null)
                    return false;
                if (sellerData.Password != password)
                    return false;
            }
            return true;
        }

        public static List<Seller> GetSellers()
        {
            using (var db = new Supermarket())
            {
                return db.Sellers.ToList();
            }
        }

        public static bool AddSeller(string name, int age, string phone, string password, string emailAddress)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var seller = new Seller()
                    {
                        Name = name,
                        Age = age,
                        Phone = phone,
                        Password = password,
                        EmailAddress = emailAddress
                    };
                    db.Sellers.Add(seller);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion
        #region Category Methods
        public static Category GetCategoryByName(string categoryName)
        {
            using (var db = new Supermarket())
            {
                var category = db.Categories.Where(c => c.Name == categoryName).First();
                return category;
            }
        }

        public static List<CategoryDisplay> GetCategories()
        {
            using (var db = new Supermarket())
            {
                return db.Categories.Select(c => new CategoryDisplay{ Id = c.Id, Name = c.Name, Description = c.Description}).ToList();
            }
        }

        public static bool AddCategory(string name, string description)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var category = new Category() { Name = name, Description = description};
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool EditCategory(int id, string name, string description)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var category = db.Categories.Find(id);
                    if (category == null)
                        return false;
                    category.Name = name;
                    category.Description = description;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteCategory(int id)
        {
            try
            {
                using (var db = new Supermarket())
                {
                    var category = db.Categories.Find(id);
                    if (category == null)
                        return false;
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion 
    }
}
