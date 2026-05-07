namespace SharedKernel;

/// <summary>
/// A base clase for entities.
/// Entities are objects that have an identity and are mutable.
/// They are typically used to represent domain objects.
/// </summary>
/// /// <remarks>
/// Equality is based on the entity's <see cref="Id"/> and concrete type,
/// meaning two entities of different types with the same Id are not considered equal.
/// </remarks>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class EntityBase<TId>
  : IEquatable<EntityBase<TId>>
  where TId : notnull
{
    /// <summary>
    /// Gets the unique identifier for this entity.
    /// </summary>
    /// <remarks>
    /// Initialised to <c>default!</c> to satisfy the compiler; the ORM sets this
    /// immediately after construction during hydration.
    /// </remarks>
    public TId Id { get; protected set; } = default!;

    /// <summary>
    /// Gets the database-assigned sequential number for this entity.
    /// </summary>
    /// <remarks>
    /// Populated by the ORM via reflection; not intended to be set in application code.
    /// Used for keyset pagination, since some key types (e.g. <see cref="Guid"/>) are
    /// non-sequential and cannot be used as a reliable sort key for cursor-based pagination.
    /// </remarks>
    public long Sequence { get; private set; }

    /// <summary>
    /// Initialises a new instance of <see cref="EntityBase{TId}"/>.
    /// </summary>
    /// <remarks>
    /// Required for ORM hydration. Not intended for direct use in application code.
    /// </remarks>
    protected EntityBase() { }

    /// <summary>
    /// Initialises a new instance of <see cref="EntityBase{TId}"/> with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier for this entity.</param>
    protected EntityBase(TId id) => Id = id;

    /// <summary>
    /// Determines whether this entity is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with this entity.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="obj"/> is an <see cref="EntityBase{TId}"/> of the same
    /// concrete type with the same <see cref="Id"/>; otherwise <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj) =>
        obj is EntityBase<TId> other && Equals(other);

    /// <summary>
    /// Determines whether this entity is equal to another <see cref="EntityBase{TId}"/>.
    /// </summary>
    /// <param name="other">The entity to compare with this entity.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="other"/> is of the same concrete type and has the
    /// same <see cref="Id"/>; otherwise <c>false</c>.
    /// </returns>
    public bool Equals(EntityBase<TId>? other) =>
        other is not null
        && GetType() == other.GetType()
        && EqualityComparer<TId>.Default.Equals(Id, other.Id);

    /// <summary>
    /// Returns a hash code for this entity based on its <see cref="Id"/>.
    /// </summary>
    /// <returns>A hash code derived from the entity's <see cref="Id"/>.</returns>
    public override int GetHashCode() =>
        EqualityComparer<TId>.Default.GetHashCode(Id);

    /// <summary>
    /// Determines whether two entities are equal.
    /// </summary>
    /// <param name="left">The left-hand entity.</param>
    /// <param name="right">The right-hand entity.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="left"/> and <paramref name="right"/> are equal;
    /// otherwise <c>false</c>.
    /// </returns>
    public static bool operator ==(EntityBase<TId>? left, EntityBase<TId>? right) =>
        Equals(left, right);

    /// <summary>
    /// Determines whether two entities are not equal.
    /// </summary>
    /// <param name="left">The left-hand entity.</param>
    /// <param name="right">The right-hand entity.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="left"/> and <paramref name="right"/> are not equal;
    /// otherwise <c>false</c>.
    /// </returns>
    public static bool operator !=(EntityBase<TId>? left, EntityBase<TId>? right) =>
        !Equals(left, right);
}
