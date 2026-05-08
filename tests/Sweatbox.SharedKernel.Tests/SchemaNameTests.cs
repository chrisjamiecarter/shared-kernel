namespace Sweatbox.SharedKernel.Tests;

/// <summary>
/// Contains unit tests for the <c>SchemaName</c> class.
/// </summary>
public sealed class SchemaNameTests
{
    private const string TestSchema = "linkvault";
    private const string TestTable = "Links";

    /// <summary>
    /// Verifies that the <c>Value</c> property returns the value provided via the constructor.
    /// </summary>
    [Fact]
    public void Value_WhenSetViaConstructor_ShouldReturnCorrectValue()
    {
        // Arrange.
        var expected = TestSchema;

        // Act.
        var schema = new SchemaName(expected);

        // Assert.
        schema.Value.ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that the <c>Schema</c> property returns the value provided via the constructor.
    /// </summary>
    [Fact]
    public void Schema_WhenSetViaConstructor_ShouldReturnCorrectValue()
    {
        // Arrange.
        var expected = new SchemaName(TestSchema);
        
        // Act.
        var table = expected.Table(TestTable);
        
        // Assert.
        table.Schema.ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that the <c>Table</c> property returns the value provided via the constructor.
    /// </summary>
    [Fact]
    public void Table_WhenSetViaFactory_ShouldReturnCorrectValue()
    {
        // Arrange.
        var expected = TestTable;

        // Act.
        var schema = new SchemaName(TestSchema);
        var table = schema.Table(TestTable);

        // Assert.
        table.Table.ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that the <c>ToString</c> method returns the expected value.
    /// </summary>
    [Fact]
    public void ToString_ShouldReturnValue()
    {
        // Arrange.
        var expected = TestSchema;

        // Act.
        var schema = new SchemaName(TestSchema);

        // Assert.
        schema.ToString().ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that when two entities have the same schema values
    /// the equality operator returns <see langword="true"/>.
    /// </summary>
    [Fact]
    public void Equality_WhenSameValue_ShouldReturnTrue()
    {
        // Arrange.
        // Act.
        var a = new SchemaName(TestSchema);
        var b = new SchemaName(TestSchema);

        // Assert.
        a.ShouldBe(b);
    }

    /// <summary>
    /// Verifies that when two entities have different schema values
    /// the equality operator returns <see langword="false"/>.
    /// </summary>
    [Fact]
    public void Equality_FalseForDifferentValue()
    {
        // Arrange.
        // Act.
        var a = new SchemaName(TestSchema);
        var b = new SchemaName("dbo");
        
        // Assert.
        a.ShouldNotBe(b);
    }
}
