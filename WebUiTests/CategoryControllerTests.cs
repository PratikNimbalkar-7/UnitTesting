using BLL;
using DAL;
using Moq;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.XPath;
using WEB.Controllers;
using Xunit;

namespace WebUiTests
{
    public class CategoryControllerTests
    {
        Mock<IcategoryService> mock;
        CategoryController categoryController;
        public CategoryControllerTests()
        {
            mock = new Mock<IcategoryService>();
            categoryController = new CategoryController(mock.Object);
        }

        [Fact]
        public void Index_ReturnViewResult_WithCategory()
        {
            // Arrenge
            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController categoryController = new CategoryController(mock.Object);

            var categories = new List<Category>()
            {
                new Category() { Id = 1,Name="Electronics",Rating=4 },
                new Category() { Id = 2,Name="Laptops",Rating=5 }
            };

            mock.Setup(s => s.GetAll()).Returns(categories);

            // Act 
            var result = categoryController.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);

            Assert.IsType<ViewResult>(result);

            Assert.IsAssignableFrom<IEnumerable<Category>>(result.Model);

            var model = result.Model as IEnumerable<Category>;

            Assert.Equal(2, model.Count());

        }

        [Fact]
        public void Create_Returns_ViewResult()
        {
            // Arrenge
            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = categoryController.Create() as ViewResult;

            // Arrenge

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal("Create", result.ViewName);
        }

        [Fact]
        public void Create_ViewModel_ReturnRedirectToIndex()
        {
            // Arrenge 

            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController categoryController = new CategoryController(mock.Object);

            Category category = new Category()
            {
                Id = 1,
                Name = "HomeApplicence",
                Rating = 5
            };

            categoryController.ModelState.Clear();

            // Act
            var result = categoryController.Create(category) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);

            Assert.Equal("Index", result.RouteValues["action"]);

        }

        [Fact]
        public void Create_InValidModel_ReturnResultWithModel()
        {
            // Arrenge 

            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController categoryController = new CategoryController(mock.Object);

            Category category = new Category();

            categoryController.ModelState.AddModelError("Name", "Name is Required");

            // Act
            var result = categoryController.Create(category) as ViewResult;

            // Assert
            Assert.NotNull(result);

            Assert.Equal(category, result.Model);

        }

        [Fact]
        public void Details_ZeroId_ReturnRedirectToIndex()
        {
            // Arrenge 

            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController controller = new CategoryController(mock.Object);

            // Act 
            var result = categoryController.Details(0) as RedirectToRouteResult;

            // Assert

            Assert.NotNull(result);

            Assert.Equal("Index", result.RouteValues["Action"]);
        }


        [Fact]
        public void Details_ValidExestingId_ReturnViewWithModel()
        {
            // Arrenge 

            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController controller = new CategoryController(mock.Object);

            Category category = new Category()
            {
                Id = 1,
                Name = "Mobile",
                Rating = 4
            };

            mock.Setup(s => s.GetById(1)).Returns(category);

            // Act 
            var result = categoryController.Details(1) as ViewResult;

            // Assert

            Assert.NotNull(result);

            var model = result.Model as Category;

            Assert.Equal("Mobile", model.Name);
        }

        [Fact]
        public void Details_NotExistingId_ReturnNotFoundHttp()
        {
            // Arrenge 

            //Mock<IcategoryService> mock = new Mock<IcategoryService>();
            //CategoryController controller = new CategoryController(mock.Object);

            Category category = null;

            mock.Setup(s => s.GetById(1)).Returns(category);

            // Act 
            var result = categoryController.Details(1) as HttpNotFoundResult;

            // Assert

            Assert.NotNull(result);

            Assert.IsType<HttpNotFoundResult>(result);
        }

    }
}
