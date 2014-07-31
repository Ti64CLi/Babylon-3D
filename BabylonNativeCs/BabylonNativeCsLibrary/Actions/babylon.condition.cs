using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Condition {
        public ActionManager _actionManager;
        public double _evaluationId;
        public bool _currentResult;
        public Condition(ActionManager actionManager) {
            this._actionManager = actionManager;
        }
        public virtual bool isValid() {
            return true;
        }
        public virtual string _getProperty(string propertyPath) {
            return this._actionManager._getProperty(propertyPath);
        }
        public virtual object _getEffectiveTarget(object target, string propertyPath) {
            return this._actionManager._getEffectiveTarget(target, propertyPath);
        }
    }
    public partial class ValueCondition: Condition {
        private static double _IsEqual = 0;
        private static double _IsDifferent = 1;
        private static double _IsGreater = 2;
        private static double _IsLesser = 3;
        public static int IsEqual {
            get {
                return ValueCondition._IsEqual;
            }
        }
        public static int IsDifferent {
            get {
                return ValueCondition._IsDifferent;
            }
        }
        public static int IsGreater {
            get {
                return ValueCondition._IsGreater;
            }
        }
        public static int IsLesser {
            get {
                return ValueCondition._IsLesser;
            }
        }
        public ActionManager _actionManager;
        private object _target;
        private string _property;
        public string propertyPath;
        public object value;
        public double _operator;
        public ValueCondition(ActionManager actionManager, object target, string propertyPath, object value, double _operator = ValueCondition.IsEqual): base(actionManager) {
            this._target = this._getEffectiveTarget(target, this.propertyPath);
            this._property = this._getProperty(this.propertyPath);
        }
        public virtual bool isValid() {
            switch (this._operator) {
                case ValueCondition.IsGreater:
                    return this._target[this._property] > this.value;
                case ValueCondition.IsLesser:
                    return this._target[this._property] < this.value;
                case ValueCondition.IsEqual:
                case ValueCondition.IsDifferent:
                    var check;
                    if (this.value.equals) {
                        check = this.value.equals(this._target[this._property]);
                    } else {
                        check = this.value == this._target[this._property];
                    }
                    return (this._operator == ValueCondition.IsEqual) ? check : !check;
            }
            return false;
        }
    }
    public partial class PredicateCondition: Condition {
        public ActionManager _actionManager;
        public System.Func predicate;
        public PredicateCondition(ActionManager actionManager, System.Func predicate): base(actionManager) {}
        public virtual bool isValid() {
            return this.predicate();
        }
    }
    public partial class StateCondition: Condition {
        public ActionManager _actionManager;
        private object _target;
        public string value;
        public StateCondition(ActionManager actionManager, object target, string value): base(actionManager) {
            this._target = target;
        }
        public virtual bool isValid() {
            return this._target.state == this.value;
        }
    }
}