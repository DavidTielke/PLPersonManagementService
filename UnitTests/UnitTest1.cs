using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceClient.Services;
using ServiceClient.Validators;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private PersonManager _manager;
        private Mock<IPersonRepository> _repoMock;
        private Mock<IPersonAddValidator> _validatorMock;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IPersonRepository>();
            _validatorMock = new Mock<IPersonAddValidator>();
            _manager = new PersonManager(_repoMock.Object, _validatorMock.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            _repoMock.Setup(m => m.Load()).Returns(new List<Person>
            {
                new Person(1, "Test", 23)
            }.AsQueryable());

            var actualCount = _manager.Load().Count();

            actualCount.Should().Be(1, "one person is in database");
        }

        [TestMethod]
        public void TestMethod2()
        {
            _repoMock.Setup(m => m.Insert(It.IsAny<Person>())).Throws<DataStoreException>();

            Action action = () => { _manager.Add(new Person()); };

            action.Should().Throw<PersonProcessException>();
        }
    }
}
