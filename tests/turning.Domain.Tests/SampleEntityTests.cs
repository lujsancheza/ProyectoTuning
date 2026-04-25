using FluentAssertions;
using Turning.Domain.Entities;
using Xunit;

namespace Turning.Domain.Tests;

/// <summary>
/// Pruebas unitarias para la entidad SampleEntity.
/// </summary>
public class SampleEntityTests
{
    [Fact]
    public void Create_WithValidInput_ShouldCreateEntity()
    {
        // Arrange
        string name = "Test Entity";
        string? description = "A test entity";

        // Act
        var entity = SampleEntity.Create(name, description);

        // Assert
        entity.Should().NotBeNull();
        entity.Name.Should().Be(name);
        entity.Description.Should().Be(description);
        entity.IsActive.Should().BeTrue();
        entity.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Create_WithWhitespaceName_ShouldThrowArgumentException()
    {
        // Arrange
        string name = "   ";

        // Act
        Action act = () => SampleEntity.Create(name);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*El nombre no puede estar vacío*");
    }

    [Fact]
    public void UpdateName_WithValidInput_ShouldUpdateName()
    {
        // Arrange
        var entity = SampleEntity.Create("Original Name");
        string newName = "Updated Name";

        // Act
        entity.UpdateName(newName);

        // Assert
        entity.Name.Should().Be(newName);
        entity.UpdatedAt.Should().NotBeNull();
    }

    [Fact]
    public void Deactivate_WhenActive_ShouldDeactivate()
    {
        // Arrange
        var entity = SampleEntity.Create("Test");

        // Act
        entity.Deactivate();

        // Assert
        entity.IsActive.Should().BeFalse();
    }
}
