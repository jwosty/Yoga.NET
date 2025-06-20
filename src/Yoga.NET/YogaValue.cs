using System;
using JetBrains.Annotations;
using Yoga.NET.Interop;

namespace Yoga.NET;

[PublicAPI]
public struct YogaValue : IEquatable<YogaValue>
{
    public float Value { get; init; }
    public YogaUnit Unit { get; init; }

    private YogaValue(float value, YogaUnit unit)
    {
        this.Value = value;
        this.Unit = unit;
    }

    // ReSharper disable CompareOfFloatsByEqualityOperator
    public bool Equals(YogaValue other)
    {
        if (this.Unit != other.Unit)
        {
            return false;
        }

        return this.Unit switch
        {
            YogaUnit.Undefined or YogaUnit.Auto => true,
            YogaUnit.Point or YogaUnit.Percent => this.Value == other.Value,
            _ => false
        };
    }
    // ReSharper restore CompareOfFloatsByEqualityOperator

    public override bool Equals(object? obj) => obj is YogaValue other && this.Equals(other);

    public override int GetHashCode() => HashCode.Combine(this.Value, (int)this.Unit);

    public static bool operator ==(YogaValue left, YogaValue right) => left.Equals(right);

    public static bool operator !=(YogaValue left, YogaValue right) => !left.Equals(right);

    public static YogaValue Point(float value) => new YogaValue(value, float.IsNaN(value) ? YogaUnit.Undefined : YogaUnit.Point);

    public static YogaValue Undefined() => new YogaValue(float.NaN, YogaUnit.Undefined);

    public static YogaValue Auto() => new YogaValue(0.0f, YogaUnit.Auto);

    public static YogaValue Percent(float value) => new YogaValue(value, float.IsNaN(value) ? YogaUnit.Undefined : YogaUnit.Percent);

    public static implicit operator YGValue(YogaValue ygValue) => new YGValue { value = ygValue.Value, unit = ygValue.Unit };
    public static implicit operator YogaValue(YGValue ygValue) => new YogaValue(ygValue.value, ygValue.unit);
    public static implicit operator YogaValue(float pointValue) => YogaValue.Point(pointValue);
}
