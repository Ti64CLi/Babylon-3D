// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.action.cs" company="">
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
    public partial class Action
    {
        /// <summary>
        /// </summary>
        public ActionManager _actionManager;

        /// <summary>
        /// </summary>
        public int trigger;

        /// <summary>
        /// </summary>
        public object triggerOptions;

        /// <summary>
        /// </summary>
        private Action _child;

        /// <summary>
        /// </summary>
        private readonly Condition _condition;

        /// <summary>
        /// </summary>
        private Action _nextActiveAction;

        /// <summary>
        /// </summary>
        private readonly AbstractMesh _triggerParameter;

        /// <summary>
        /// </summary>
        /// <param name="triggerOptions">
        /// </param>
        /// <param name="condition">
        /// </param>
        public Action(int triggerOptions, Condition condition = null)
        {
            this.trigger = triggerOptions;
            this._nextActiveAction = this;
            this._condition = condition;
        }

        /// <summary>
        /// </summary>
        /// <param name="triggerOptions">
        /// </param>
        /// <param name="condition">
        /// </param>
        public Action(TriggerOptions triggerOptions, Condition condition = null)
        {
            this.trigger = triggerOptions.trigger;
            this._triggerParameter = triggerOptions.parameter;
            this._nextActiveAction = this;
            this._condition = condition;
        }

        /// <summary>
        /// </summary>
        /// <param name="evt">
        /// </param>
        public virtual void _executeCurrent(ActionEvent evt)
        {
            if (this._condition != null)
            {
                var currentRenderId = this._actionManager.getScene().getRenderId();
                if (this._condition._evaluationId == currentRenderId)
                {
                    if (!this._condition._currentResult)
                    {
                        return;
                    }
                }
                else
                {
                    this._condition._evaluationId = currentRenderId;
                    if (!this._condition.isValid())
                    {
                        this._condition._currentResult = false;
                        return;
                    }

                    this._condition._currentResult = true;
                }
            }

            this._nextActiveAction.execute(evt);
            if (this._nextActiveAction._child != null)
            {
                this._nextActiveAction = this._nextActiveAction._child;
            }
            else
            {
                this._nextActiveAction = this;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        /// <param name="propertyPath">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual IAnimatable _getEffectiveTarget(IAnimatable target, string propertyPath)
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
        public virtual void _prepare()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="evt">
        /// </param>
        public virtual void execute(ActionEvent evt)
        {
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual AbstractMesh getTriggerParameter()
        {
            return this._triggerParameter;
        }

        /// <summary>
        /// </summary>
        /// <param name="action">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Action then(Action action)
        {
            this._child = action;
            action._actionManager = this._actionManager;
            action._prepare();
            return action;
        }
    }
}