namespace Sweatbox.SharedKernel.Tests;

/// <summary>
/// Contains unit tests for the <c>SchemaTable</c> class.
/// </summary>
public sealed class SchemaTableTests
{
    private const string TestTable = "Links";
    private static readonly SchemaName TestSchema = new("linkvault");

    /// <summary>
    /// Verifies that the <c>Schema</c> property returns the value provided via the constructor.
    /// </summary>
    [Fact]
    public void Schema_WhenSetViaConstructor_ShouldReturnCorrectValue()
    {
        // Arrange.
        var expected = TestSchema;

        // Act.
        var table = new SchemaTable(TestSchema, TestTable);

        // Assert.
        table.Schema.ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that the <c>Table</c> property returns the value provided via the constructor.
    /// </summary>
    [Fact]
    public void Constructor_WhenSetViaConstructor_ShouldReturnCorrectValue()
    {
        // Arrange.
        var expected = TestTable;

        // Act.
        var table = new SchemaTable(TestSchema, TestTable);

        // Assert.
        table.Table.ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that the <c>QualifiedName</c> property returns the expected value.
    /// </summary>
    [Fact]
    public void QualifiedName_ShouldCombinesSchemaAndTableWithDotSeparator()
    {
        // Arrange.
        var expected = $"{TestSchema}.{TestTable}";

        // Act.
        var table = new SchemaTable(TestSchema, TestTable);

        // Assert.
        table.QualifiedName.ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that the <c>ToString</c> method returns the expected value.
    /// </summary>
    [Fact]
    public void ToString_ShouldReturnQualifiedName()
    {
        // Arrange.
        var expected = $"{TestSchema}.{TestTable}";

        // Act.
        var table = new SchemaTable(TestSchema, TestTable);

        // Assert.
        table.ToString().ShouldBe(expected);
    }

    /// <summary>
    /// Verifies that when two entities have the same schema and table
    /// the equality operator returns <see langword="true"/>.
    /// </summary>
    [Fact]
    public void Equality_WhenSameSchemaAndTable_ShouldReturnTrue()
    {
        // Arrange.
        // Act.
        var a = new SchemaTable(TestSchema, TestTable);
        var b = new SchemaTable(TestSchema, TestTable);

        // Assert.
        a.ShouldBe(b);
    }

    /// <summary>
    /// Verifies that when two entities have the same schema but different table
    /// the equality operator returns <see langword="false"/>.
    /// </summary>
    [Fact]
    public void Equality_WhenSameSchemaButDifferentTable_ShouldReturnFalse()
    {
        // Arrange.
        // Act.
        var a = new SchemaTable(TestSchema, TestTable);
        var b = new SchemaTable(TestSchema, $"{TestTable}Audits");
        
        // Assert.
        a.ShouldNotBe(b);
    }

    /// <summary>
    /// Verifies that when two entities have the same table but different schema
    /// the equality operator returns <see langword="false"/>.
    /// </summary>
    [Fact]
    public void Equality_WhenSameTableButDifferentSchema_ShouldReturnFalse()
    {
        // Arrange.
        // Act.
        var a = new SchemaTable(TestSchema, TestTable);
        var b = new SchemaTable(new SchemaName("dbo"), TestTable);

        // Assert.
        a.ShouldNotBe(b);
    }

    /// <summary>
    /// Verifies that when two entities have the same schema and table
    /// but one produced via factory and one produced via constructor,
    /// the equality operator returns <see langword="true"/>.
    /// </summary>
    [Fact]
    public void SchemaTable_WhenProducedBySchemaName_ShouldMatchDirectConstruction()
    {
        // Arrange.
        // Act.
        var factory = TestSchema.Table(TestTable);
        var constructor = new SchemaTable(TestSchema, TestTable);
        
        // Assert.
        factory.ShouldBe(constructor);
    }
}
