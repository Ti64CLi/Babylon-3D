using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class SwitchBooleanAction: Action {
        private object _target;
        private string _property;
        public string propertyPath;
        public SwitchBooleanAction(object triggerOptions, object target, string propertyPath, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
        }
        public virtual void _prepare() {
            this._target = this._getEffectiveTarget(this._target, this.propertyPath);
            this._property = this._getProperty(this.propertyPath);
        }
        public virtual void execute() {
            this._target[this._property] = !this._target[this._property];
        }
    }
    public partial class SetStateAction: Action {
        private object _target;
        public string value;
        public SetStateAction(object triggerOptions, object target, string value, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
        }
        public virtual void execute() {
            this._target.state = this.value;
        }
    }
    public partial class SetValueAction: Action {
        private object _target;
        private string _property;
        public string propertyPath;
        public object value;
        public SetValueAction(object triggerOptions, object target, string propertyPath, object value, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
        }
        public virtual void _prepare() {
            this._target = this._getEffectiveTarget(this._target, this.propertyPath);
            this._property = this._getProperty(this.propertyPath);
        }
        public virtual void execute() {
            this._target[this._property] = this.value;
        }
    }
    public partial class IncrementValueAction: Action {
        private object _target;
        private string _property;
        public string propertyPath;
        public object value;
        public IncrementValueAction(object triggerOptions, object target, string propertyPath, object value, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
        }
        public virtual void _prepare() {
            this._target = this._getEffectiveTarget(this._target, this.propertyPath);
            this._property = this._getProperty(this.propertyPath);
            if (typeof(this._target[this._property]) != "number") {
                Tools.Warn("Warning: IncrementValueAction can only be used with number values");
            }
        }
        public virtual void execute() {
            this._target[this._property] += this.value;
        }
    }
    public partial class PlayAnimationAction: Action {
        private object _target;
        public double from;
        public double to;
        public bool loop;
        public PlayAnimationAction(object triggerOptions, object target, double from, double to, bool loop = false, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
        }
        public virtual void _prepare() {}
        public virtual void execute() {
            var scene = this._actionManager.getScene();
            scene.beginAnimation(this._target, this.from, this.to, this.loop);
        }
    }
    public partial class StopAnimationAction: Action {
        private object _target;
        public StopAnimationAction(object triggerOptions, object target, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
        }
        public virtual void _prepare() {}
        public virtual void execute() {
            var scene = this._actionManager.getScene();
            scene.stopAnimation(this._target);
        }
    }
    public partial class DoNothingAction: Action {
        public DoNothingAction(object triggerOptions = ActionManager.NothingTrigger, Condition condition = null): base(triggerOptions, condition) {}
        public virtual void execute() {}
    }
    public partial class CombineAction: Action {
        public Array < Action > children;
        public CombineAction(object triggerOptions, Array < Action > children, Condition condition = null): base(triggerOptions, condition) {}
        public virtual void _prepare() {
            for (var index = 0; index < this.children.Length; index++) {
                this.children[index]._actionManager = this._actionManager;
                this.children[index]._prepare();
            }
        }
        public virtual void execute(ActionEvent evt) {
            for (var index = 0; index < this.children.Length; index++) {
                this.children[index].execute(evt);
            }
        }
    }
    public partial class ExecuteCodeAction: Action {
        public System.Action < ActionEvent > func;
        public ExecuteCodeAction(object triggerOptions, System.Action < ActionEvent > func, Condition condition = null): base(triggerOptions, condition) {}
        public virtual void execute(ActionEvent evt) {
            this.func(evt);
        }
    }
    public partial class SetParentAction: Action {
        private object _parent;
        private object _target;
        public SetParentAction(object triggerOptions, object target, object parent, Condition condition = null): base(triggerOptions, condition) {
            this._target = target;
            this._parent = parent;
        }
        public virtual void _prepare() {}
        public virtual void execute() {
            if (this._target.parent == this._parent) {
                return;
            }
            var invertParentWorldMatrix = this._parent.getWorldMatrix().clone();
            invertParentWorldMatrix.invert();
            this._target.position = BABYLON.Vector3.TransformCoordinates(this._target.position, invertParentWorldMatrix);
            this._target.parent = this._parent;
        }
    }
}