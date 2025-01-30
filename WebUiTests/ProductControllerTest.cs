using BLL;
using DAL;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WEB.Controllers;
using Xunit;

namespace WebUiTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Index_ReturnViewResult_WithCategory()
        {
            // Arrenge
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);

            var product = new List<Product>()
            {
                new Product() { Id = 1,ProductName="Iphone",Rating=4 },
                new Product() { Id = 2, ProductName = "Samsung", Rating = 5 }
            };

            mock.Setup(s => s.GetAll()).Returns(product);

            // Act 
            var result = productController.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);

            Assert.IsType<ViewResult>(result);

            Assert.IsAssignableFrom<IEnumerable<Product>>(result.Model);

            var model = result.Model as IEnumerable<Product>;

            Assert.Equal(2, model.Count());

        }

        [Fact]
        public void Create_Returns_ViewResult()
        {
            // Arrenge
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);

            // Act
            var result = productController.Create() as ViewResult;

            // Arrenge

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal("Create", result.ViewName);
        }

        [Fact]
        public void Create_ViewModel_ReturnRedirectToIndex()
        {
            //Arrenge

            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);

            Product product = new Product()
            {
                Id = 1,
                ProductName = "Iphone",
                Rating = 5
            };

            productController.ModelState.Clear();

            // Act

            var result = productController.Create(product) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);

            Assert.Equal("Index",result.RouteValues["action"]);
        }

        [Fact]
        public void Create_InvalidModel_ReturnResultWithModel()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);

            Product product = new Product();

            productController.ModelState.AddModelError("Name", "Name is Required");

            var result = productController.Create(product) as ViewResult;

            Assert.NotNull(result);

            Assert.Equal(product, result.Model);
        }

        [Fact]
        public void Details_ZeroId_ReturnRedirectToIndex()
        {
            // Arrenge 
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);


            // Act
            var result = productController.GetById(0) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);

            Assert.Equal("Index", result.RouteValues["action"]);
        }

        [Fact]
        public void Details_ValidExestingId_ReturnViewWithModel()
        {
            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);

            Product product = new Product()
            {
                Id = 1,
                ProductName = "Mobile",
                Rating = 5
            };

            mock.Setup(s => s.GetById(1)).Returns(product);

            var result = productController.GetById(1) as ViewResult;

            Assert.NotNull(result);

            var model = result.Model as Product;

            Assert.Equal("Mobile", model.ProductName);
        }

        [Fact]
        public void Details_NotExistingId_ReturnNotFoundHttp()
        {
            // Arrenge 

            Mock<IProductService> mock = new Mock<IProductService>();
            ProductController productController = new ProductController(mock.Object);

            Product product = null;

            mock.Setup(s => s.GetById(1)).Returns(product);

            // Act 
            var result = productController.GetById(1) as HttpNotFoundResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<HttpNotFoundResult>(result);
        }
    }
}
