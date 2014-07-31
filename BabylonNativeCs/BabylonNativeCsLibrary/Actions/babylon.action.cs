using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Action {
        public int trigger;
        public ActionManager _actionManager;
        private Action _nextActiveAction;
        private Action _child;
        private Condition _condition;
        private object _triggerParameter;
        public object triggerOptions;
        public Action(object triggerOptions, Condition condition = null) {
            if (triggerOptions.parameter) {
                this.trigger = triggerOptions.trigger;
                this._triggerParameter = triggerOptions.parameter;
            } else {
                this.trigger = triggerOptions;
            }
            this._nextActiveAction = this;
            this._condition = condition;
        }
        public virtual void _prepare() {}
        public virtual object getTriggerParameter() {
            return this._triggerParameter;
        }
        public virtual void _executeCurrent(ActionEvent evt) {
            if (this._condition) {
                var currentRenderId = this._actionManager.getScene().getRenderId();
                if (this._condition._evaluationId == currentRenderId) {
                    if (!this._condition._currentResult) {
                        return;
                    }
                } else {
                    this._condition._evaluationId = currentRenderId;
                    if (!this._condition.isValid()) {
                        this._condition._currentResult = false;
                        return;
                    }
                    this._condition._currentResult = true;
                }
            }
            this._nextActiveAction.execute(evt);
            if (this._nextActiveAction._child) {
                this._nextActiveAction = this._nextActiveAction._child;
            } else {
                this._nextActiveAction = this;
            }
        }
        public virtual void execute(ActionEvent evt) {}
        public virtual Action then(Action action) {
            this._child = action;
            action._actionManager = this._actionManager;
            action._prepare();
            return action;
        }
        public virtual string _getProperty(string propertyPath) {
            return this._actionManager._getProperty(propertyPath);
        }
        public virtual object _getEffectiveTarget(object target, string propertyPath) {
            return this._actionManager._getEffectiveTarget(target, propertyPath);
        }
    }
}