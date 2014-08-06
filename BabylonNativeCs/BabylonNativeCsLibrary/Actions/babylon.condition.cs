// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.condition.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class Condition
    {
        /// <summary>
        /// </summary>
        public ActionManager _actionManager;

        /// <summary>
        /// </summary>
        public bool _currentResult;

        /// <summary>
        /// </summary>
        public double _evaluationId;

        /// <summary>
        /// </summary>
        /// <param name="actionManager">
        /// </param>
        public Condition(ActionManager actionManager)
        {
            this._actionManager = actionManager;
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        /// <param name="propertyPath">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual object _getEffectiveTarget(IAnimatable target, string propertyPath)
        {
            return this._actionManager._getEffectiveTarget(target, propertyPath);
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyPath">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual string _getProperty(string propertyPath)
        {
            return this._actionManager._getProperty(propertyPath);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isValid()
        {
            return true;
        }
    }

    /*
    public partial class ValueCondition : Condition
    {
        public const int IsEqual = 0;
        public const int IsDifferent = 1;
        public const int IsGreater = 2;
        public const int IsLesser = 3;
        public ActionManager _actionManager;
        private object _target;
        private string _property;
        public string propertyPath;
        public object value;
        public int _operator;
        public ValueCondition(ActionManager actionManager, object target, string propertyPath, object value, int _operator = ValueCondition.IsEqual)
            : base(actionManager)
        {
            this._target = this._getEffectiveTarget(target, this.propertyPath);
            this._property = this._getProperty(this.propertyPath);
        }
        public virtual bool isValid()
        {
            switch (this._operator)
            {
                case ValueCondition.IsGreater:
                    return this._target[this._property] > this.value;
                case ValueCondition.IsLesser:
                    return this._target[this._property] < this.value;
                case ValueCondition.IsEqual:
                case ValueCondition.IsDifferent:
                    var check;
                    if (this.value.equals)
                    {
                        check = this.value.equals(this._target[this._property]);
                    }
                    else
                    {
                        check = this.value == this._target[this._property];
                    }
                    return (this._operator == ValueCondition.IsEqual) ? check : !check;
            }
            return false;
        }
    }
    public partial class PredicateCondition : Condition
    {
        public ActionManager _actionManager;
        public System.Func<bool> predicate;
        public PredicateCondition(ActionManager actionManager, System.Func<bool> predicate) : base(actionManager) { }
        public virtual bool isValid()
        {
            return this.predicate();
        }
    }
    public partial class StateCondition : Condition
    {
        public ActionManager _actionManager;
        private object _target;
        public string value;
        public StateCondition(ActionManager actionManager, object target, string value)
            : base(actionManager)
        {
            this._target = target;
        }
        public virtual bool isValid()
        {
            return this._target.state == this.value;
        }
    }
     */
}