namespace SharedKernel.Tests;

public class EntityBaseTests
{
    private sealed class TestEntity(int id) : EntityBase<int>(id);
    private sealed class OtherEntity(int id) : EntityBase<int>(id);

    [Fact]
    public void Id_WhenSetViaConstructor_ShouldReturnCorrectValue()
    {
        var entity = new TestEntity(42);

        entity.Id.ShouldBe(42);
    }

    [Fact]
    public void Sequence_WhenNewlyCreated_ShouldDefaultToZero()
    {
        var entity = new TestEntity(1);

        entity.Sequence.ShouldBe(0);
    }
    [Fact]
    public void Equals_WhenSameReference_ShouldReturnTrue()
    {
        var entity = new TestEntity(1);

        entity.Equals((object)entity).ShouldBeTrue();
    }

    [Fact]
    public void Equals_WhenSameTypeAndSameId_ShouldReturnTrue()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        a.Equals((object)b).ShouldBeTrue();
    }

    [Fact]
    public void Equals_WhenSameTypeAndDifferentId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        a.Equals((object)b).ShouldBeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentTypeAndSameId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new OtherEntity(1);

        a.Equals((object)b).ShouldBeFalse();
    }

    [Fact]
    public void Equals_WhenNull_ShouldReturnFalse()
    {
        var entity = new TestEntity(1);

        entity.Equals((object?)null).ShouldBeFalse();
    }

    [Fact]
    public void Equals_WhenSameTypeAndSameId_ShouldReturnTrue_TypedOverload()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        a.Equals(b).ShouldBeTrue();
    }

    [Fact]
    public void Equals_WhenTypedNull_ShouldReturnFalse()
    {
        var entity = new TestEntity(1);

        entity.Equals((EntityBase<int>?)null).ShouldBeFalse();
    }

    [Fact]
    public void GetHashCode_WhenSameId_ShouldReturnSameHash()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        a.GetHashCode().ShouldBe(b.GetHashCode());
    }

    [Fact]
    public void GetHashCode_WhenDifferentId_ShouldReturnDifferentHash()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        a.GetHashCode().ShouldNotBe(b.GetHashCode());
    }

    [Fact]
    public void GetHashCode_WhenCalledMultipleTimes_ShouldBeConsistent()
    {
        var entity = new TestEntity(1);

        var first = entity.GetHashCode();
        var second = entity.GetHashCode();

        first.ShouldBe(second);
    }

    // -------------------------------------------------------------------------
    // == and != operators
    // -------------------------------------------------------------------------

    [Fact]
    public void EqualityOperator_WhenSameTypeAndSameId_ShouldReturnTrue()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        (a == b).ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_WhenSameTypeAndDifferentId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        (a == b).ShouldBeFalse();
    }

    [Fact]
    public void InequalityOperator_WhenSameTypeAndDifferentId_ShouldReturnTrue()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(2);

        (a != b).ShouldBeTrue();
    }

    [Fact]
    public void InequalityOperator_WhenSameTypeAndSameId_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        var b = new TestEntity(1);

        (a != b).ShouldBeFalse();
    }

    [Fact]
    public void EqualityOperator_WhenBothNull_ShouldReturnTrue()
    {
        TestEntity? a = null;
        TestEntity? b = null;

        (a == b).ShouldBeTrue();
    }

    [Fact]
    public void EqualityOperator_WhenOneNull_ShouldReturnFalse()
    {
        var a = new TestEntity(1);
        TestEntity? b = null;

        (a == b).ShouldBeFalse();
    }
}
