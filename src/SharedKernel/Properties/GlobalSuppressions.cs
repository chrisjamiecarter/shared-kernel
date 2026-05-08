// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Setter is used via reflection for ORM hydration.", Scope = "member", Target = "~P:Sweatbox.SharedKernel.EntityBase`1.Sequence")]
[assembly: SuppressMessage("Major Code Smell", "S4035:Classes implementing \"IEquatable<T>\" should be sealed", Justification = "Abstract base class; GetType() check in Equals() ensures derived types are never equal across type boundaries.", Scope = "type", Target = "~T:Sweatbox.SharedKernel.EntityBase`1")]
