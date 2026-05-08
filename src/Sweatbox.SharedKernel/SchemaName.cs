namespace Sweatbox.SharedKernel;

/// <summary>
/// Represents a database schema name and acts as a factory for <see cref="SchemaTable"/> instances.
/// </summary>
/// <param name="Value">The raw schema name, e.g. <c>linkvault</c> or <c>dbo</c>.</param>
public sealed record class SchemaName(string Value)
{
    /// <summary>
    /// Creates a <see cref="SchemaTable"/> belonging to this schema.
    /// </summary>
    /// <param name="table">The unqualified table name, e.g. <c>Links</c>.</param>
    /// <returns>A <see cref="SchemaTable"/> that pairs this schema with <paramref name="table"/>.</returns>
    public SchemaTable Table(string table) => new(this, table);

    /// <summary>
    /// Returns the raw schema name, e.g. <c>linkvault</c>.
    /// </summary>
    /// <returns>The value of <see cref="Value"/>.</returns>
    public override string ToString() => Value;
}
