using System;

namespace BABYLON
{
    interface IAnimatableTarget
    {
        IAnimatableProperty this[string propertyName] { get; set; }

        Array<Animation> animations { get; set; }

        Array<IAnimatableTarget> getAnimatables();

        void markAsDirty(string propertyName);
    }

    interface IAnimatableProperty
    {
        IAnimatableProperty this[string subPropertyName] { get; set; }

        object value { get; set; }
    }

    interface ICloneable
    {
        object clone();
    }
}
