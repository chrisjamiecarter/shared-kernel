namespace Sweatbox.SharedKernel;

/// <summary>
/// Represents a fully qualified database table, combining a <see cref="SchemaName"/> with a table name.
/// </summary>
/// <param name="Schema">The schema that owns this table.</param>
/// <param name="Table">The unqualified table name, e.g. <c>Links</c>.</param>
public sealed record class SchemaTable(SchemaName Schema, string Table)
{
    /// <summary>
    /// Gets the dot-delimited qualified table name, e.g. <c>linkvault.Links</c>.
    /// </summary>
    public string QualifiedName => $"{Schema.Value}.{Table}";

    /// <summary>
    /// Returns the fully qualified table name via <see cref="QualifiedName"/>, e.g. <c>linkvault.Links</c>.
    /// </summary>
    /// <returns>The value of <see cref="QualifiedName"/>.</returns>
    public override string ToString() => QualifiedName;
}
