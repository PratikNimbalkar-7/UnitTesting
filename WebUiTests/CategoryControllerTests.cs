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
using WEB.Controllers;
using Xunit;

namespace WebUiTests
{
    public class CategoryControllerTests
    {

        //[Fact]
        //public void Index_Method_Positive()
        //{
        //    // Arrenge 

        //    ApplicationDBContext db = new ApplicationDBContext();
        //    ICategoryRepository categoryRepository = new CategoryRepository(db);
        //    IcategoryService categoryService = new CategoryService(categoryRepository);
        //    CategoryController categoryController = new CategoryController(categoryService);
        //    List<Category> categories = new List<Category>()
        //    {
        //        new Category(){Name = "Mens Were",Rating = 5},
        //        new Category(){Name = "Kids Were",Rating = 4}
        //    };

        //    // Act 

        //    ActionResult result = categoryController.Index();
        //    ViewResult view = (ViewResult)result;
        //    List<Category> list = view.Model as List<Category>;

        //    // Assert

        //    Assert.Equal(categories.Count,list.Count);
        //}
        [Fact]
        public void Index_ReturnViewResult_WithCategory()
        {
            // Arrenge
            Mock<IcategoryService> mock = new Mock<IcategoryService>();
            CategoryController categoryController = new CategoryController(mock.Object);

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

            Assert.Equal(2,model.Count());

        }

        [Fact]
        public void Create_Returns_ViewResult()
        {
            // Arrenge
            Mock<IcategoryService> mock = new Mock<IcategoryService>();
            CategoryController controller = new CategoryController(mock.Object);

            // Act
            var result = controller.Create() as ViewResult;

            // Arrenge

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal("Create", result.ViewName);
        }

        [Fact]
        public void Create_ReturnRedirectToIndex()
        {
            // Arrenge 

            Mock<IcategoryService> mock = new Mock<IcategoryService>();
            CategoryController categoryController = new CategoryController(mock.Object);

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

    }
}
