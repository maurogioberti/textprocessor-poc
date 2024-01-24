using AutoFixture;
using Moq;
using NUnit.Framework;
using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.CrossCutting.Enums;
using Poc.TextProcessor.CrossCutting.Exceptions;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;

namespace Poc.TextProcessor.Business.Logic.Tests
{
    public class TextSortLogicTests
    {
        private class TextSortLogicBuilder
        {
            private Mock<ITextSortRepository>? _textSortRepositoryMock;
            public Mock<ITextSortRepository> TextSortRepositoryMock => _textSortRepositoryMock ??= new Mock<ITextSortRepository>();
            private TextSortMapper? _textSortMapper;
            public ITextSortMapper TextSortMapper => _textSortMapper ??= new TextSortMapper();

            public ITextSortLogic Build() =>
                new TextSortLogic(TextSortRepositoryMock.Object, TextSortMapper);
        }

        private readonly Fixture _fixture = new();

        [Test]
        public void List_When_Called_Should_Return_Non_Empty_Sort_Options()
        {
            // Arrange
            var builder = new TextSortLogicBuilder();

            var sortResults = _fixture.CreateMany<ResourceAccess.Domains.TextSort>();
            builder
                .TextSortRepositoryMock
                .Setup(repo => repo.List())
                .Returns(sortResults);

            // Act
            var result = builder
                            .Build()
                            .List();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Items, Is.Not.Empty);
            Assert.That(result.Items.Count, Is.GreaterThan(1));
        }

        [Test]
        public void Sort_When_Sort_Option_Does_Not_Exists_Should_Throw_SortingException()
        {
            // Arrange
            var builder = new TextSortLogicBuilder();
            var textContent = _fixture.Create<string>();

            // Act
            // Assert
            Assert.Throws<SortingException>(() => builder.Build().Sort(textContent, (SortOption)999));
        }

        [TestCase("Hello world apple", SortOption.AlphabeticAsc, "apple Hello world")]
        [TestCase("Hello world apple", SortOption.AlphabeticDesc, "world Hello apple")]
        [TestCase("Hello world apple", SortOption.LengthAsc, "apple Hello world")]
        [TestCase("Hello wor ap", SortOption.LengthAsc, "ap wor Hello")]
        public void Sort_When_Valid_Input_Should_Sort_With_Given_Option(string textContent, SortOption orderOption, string expectedResult)
        {
            // Arrange
            var builder = new TextSortLogicBuilder();

            // Act
            var result = builder.Build().Sort(textContent, orderOption);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

}