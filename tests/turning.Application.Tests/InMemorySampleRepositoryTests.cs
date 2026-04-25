using FluentAssertions;
using Turning.Domain.Entities;
using Turning.Infrastructure.Repositories;
using Xunit;

namespace Turning.Application.Tests;

/// <summary>
/// Pruebas para el repositorio en memoria de Sample.
/// </summary>
public class InMemorySampleRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        // Arrange
        var repository = new InMemorySampleRepository();
        var entity = SampleEntity.Create("Test Entity");

        // Act
        await repository.AddAsync(entity);

        // Assert
        var result = await repository.GetByIdAsync(entity.Id);
        result.Should().NotBeNull();
        result?.Name.Should().Be("Test Entity");
    }

    [Fact]
    public async Task GetByIdAsync_WithValidId_ShouldReturnEntity()
    {
        // Arrange
        var repository = new InMemorySampleRepository();
        var entity = SampleEntity.Create("Test Entity");
        await repository.AddAsync(entity);

        // Act
        var result = await repository.GetByIdAsync(entity.Id);

        // Assert
        result.Should().NotBeNull();
        result?.Id.Should().Be(entity.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        // Arrange
        var repository = new InMemorySampleRepository();
        var entity1 = SampleEntity.Create("Entity 1");
        var entity2 = SampleEntity.Create("Entity 2");
        await repository.AddAsync(entity1);
        await repository.AddAsync(entity2);

        // Act
        var results = await repository.GetAllAsync();

        // Assert
        results.Should().HaveCount(2);
    }
}
