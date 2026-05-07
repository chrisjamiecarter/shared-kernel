namespace SharedKernel.Tests;

/// <summary>
/// Contains unit tests for the <c>EntityBase&lt;TId&gt;</c> class.
/// </summary>
public class EntityBaseTests
{
    private sealed class TestEntity(int id) : EntityBase<int>(id);
    private sealed class OtherEntity(int id) : EntityBase<int>(id);

    /// <summary>
    /// Verifies that the <c>Id</c> property returns the value provided via the constructor.
    /// </summary>
    [Fact]
    public void Id_WhenSetViaConstructor_ShouldReturnCorrectValue()
    {
        var entity = new TestEntity(42);

        entity.Id.ShouldBe(42);
    }

    /// <summary>
    /// Verifies that the <c>Sequence</c> property defaults to zero for a newly created entity.
    /// </summary>
    [Fact]
    public void Sequence_WhenNewlyCreated_ShouldDefaultToZero()
    {
        var entity = new TestEntity(1);

        entity.Sequence.ShouldBe(0);
    }

    /// <summary>
    /// Verifies that equality returns <see langword="true"/> when comparing the same object reference.
    /// </summary>
    [Fact]
    public void Equals_WhenSameReference_ShouldReturnTrue()
    {
        var entity = new TestEntity(1);

        entity.Equals((object)entity).ShouldBeTrue();
    }

    /// <summary>
    /// Verifies that equality returns <see langword="true"/> when two entities
    /// have the same type and identifier.
    /// </summary>
    [Fact]
    public void Equals_WhenSameTypeAndSameId_ShouldReturnTrue()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        a.Equals((object)b).ShouldBeTrue();
    }

    /// <summary>
    /// Verifies that equality returns <see langword="false"/> when two entities
    /// have the same type but different identifiers.
    /// </summary>
    [Fact]
    public void Equals_WhenSameTypeAndDifferentId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        a.Equals((object)b).ShouldBeFalse();
    }

    /// <summary>
    /// Verifies that equality returns <see langword="false"/> when two entities
    /// have different types, even if their identifiers are the same.
    /// </summary>
    [Fact]
    public void Equals_WhenDifferentTypeAndSameId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new OtherEntity(1);

        a.Equals((object)b).ShouldBeFalse();
    }

    /// <summary>
    /// Verifies that equality returns <see langword="false"/> when comparing against <see langword="null"/>.
    /// </summary>
    [Fact]
    public void Equals_WhenNull_ShouldReturnFalse()
    {
        var entity = new TestEntity(1);

        entity.Equals((object?)null).ShouldBeFalse();
    }

    /// <summary>
    /// Verifies that the strongly typed equality overload returns <see langword="true"/>
    /// when two entities have the same type and identifier.
    /// </summary>
    [Fact]
    public void Equals_WhenSameTypeAndSameId_ShouldReturnTrue_TypedOverload()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        a.Equals(b).ShouldBeTrue();
    }

    /// <summary>
    /// Verifies that the strongly typed equality overload returns <see langword="false"/>
    /// when comparing against <see langword="null"/>.
    /// </summary>
    [Fact]
    public void Equals_WhenTypedNull_ShouldReturnFalse()
    {
        var entity = new TestEntity(1);

        entity.Equals((EntityBase<int>?)null).ShouldBeFalse();
    }

    /// <summary>
    /// Verifies that entities with the same identifier produce the same hash code.
    /// </summary>
    [Fact]
    public void GetHashCode_WhenSameId_ShouldReturnSameHash()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        a.GetHashCode().ShouldBe(b.GetHashCode());
    }

    /// <summary>
    /// Verifies that entities with different identifiers produce different hash codes.
    /// </summary>
    [Fact]
    public void GetHashCode_WhenDifferentId_ShouldReturnDifferentHash()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        a.GetHashCode().ShouldNotBe(b.GetHashCode());
    }

    /// <summary>
    /// Verifies that repeated calls to <c>GetHashCode</c> return a consistent value.
    /// </summary>
    [Fact]
    public void GetHashCode_WhenCalledMultipleTimes_ShouldBeConsistent()
    {
        var entity = new TestEntity(1);

        var first = entity.GetHashCode();
        var second = entity.GetHashCode();

        first.ShouldBe(second);
    }

    /// <summary>
    /// Verifies that the equality operator returns <see langword="true"/>
    /// when two entities have the same type and identifier.
    /// </summary>
    [Fact]
    public void EqualityOperator_WhenSameTypeAndSameId_ShouldReturnTrue()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        (a == b).ShouldBeTrue();
    }

    /// <summary>
    /// Verifies that the equality operator returns <see langword="false"/>
    /// when two entities have the same type but different identifiers.
    /// </summary>
    [Fact]
    public void EqualityOperator_WhenSameTypeAndDifferentId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        (a == b).ShouldBeFalse();
    }

    /// <summary>
    /// Verifies that the inequality operator returns <see langword="true"/>
    /// when two entities have the same type but different identifiers.
    /// </summary>
    [Fact]
    public void InequalityOperator_WhenSameTypeAndDifferentId_ShouldReturnTrue()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        (a != b).ShouldBeTrue();
    }

    /// <summary>
    /// Verifies that the inequality operator returns <see langword="false"/>
    /// when two entities have the same type and identifier.
    /// </summary>
    [Fact]
    public void InequalityOperator_WhenSameTypeAndSameId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        (a != b).ShouldBeFalse();
    }

    /// <summary>
    /// Verifies that the equality operator returns <see langword="true"/>
    /// when both operands are <see langword="null"/>.
    /// </summary>
    [Fact]
    public void EqualityOperator_WhenBothNull_ShouldReturnTrue()
    {
        TestEntity? a = null;
        TestEntity? b = null;

        (a == b).ShouldBeTrue();
    }

    /// <summary>
    /// Verifies that the equality operator returns <see langword="false"/>
    /// when one operand is <see langword="null"/>.
    /// </summary>
    [Fact]
    public void EqualityOperator_WhenOneNull_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        TestEntity? b = null;

        (a == b).ShouldBeFalse();
    }
}
