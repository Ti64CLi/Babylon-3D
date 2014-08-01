using System;

namespace BABYLON
{
    public interface IAnimatableProperty
    {
        IAnimatableProperty this[string subPropertyName] { get; set; }

        object value { get; set; }
    }

    public interface ICloneable
    {
        object clone();
    }
}
