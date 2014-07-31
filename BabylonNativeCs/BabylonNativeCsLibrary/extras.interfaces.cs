using System;

namespace BABYLON
{
    public interface IAnimatableTarget
    {
        IAnimatableProperty this[string propertyName] { get; set; }

        Array<Animation> animations { get; set; }

        Array<IAnimatableTarget> getAnimatables();

        void markAsDirty(string propertyName);
    }

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
