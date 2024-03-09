using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using ProductApi.Models;

using ProductApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Models.Dto;

namespace ProductApi.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Get_Returns_Products_Successfully()
        {
            // Arrange
            var products = new List<Product>
            {
                 new Product("test1","Test1", "test1","test1","test1","test1","test1","test1",2000,100,0),
                new Product("test2","Test2", "test2","test2","test2","test2","test2","test2",2500,100,0)
            };

            var repositoryMock = new Mock<IRepository<Product>>();
            repositoryMock.Setup(repo => repo.GetAll()).Returns(products);

            var controller = new ProductController(repositoryMock.Object);

            // Act
            var result = controller.Get() ;

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ResponseDto>(result);
            Assert.True(response.IsSuccess);
            Assert.Equal(products, response.Result);
            Assert.Null(response.Message); // Assuming Message is null for successful requests
            //Assert.NotNull(result);
            //Assert.Equal(200, result.StatusCode);
            //Assert.Equal(products, result.Value);
        }

        [Fact]
        public void Get_Returns_InternalServerError_When_Exception_Occurs()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Product>>();
            repositoryMock.Setup(repo => repo.GetAll()).Throws(new Exception("Test Exception"));

            var controller = new ProductController(repositoryMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ResponseDto>(result);
            Assert.False(response.IsSuccess);
            Assert.Equal("Test Exception", response.Message);
            Assert.Null(response.Result); // Assuming Result is null for error responses
        }
    }
}
