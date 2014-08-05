using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class ActionEvent
    {
        public AbstractMesh source;
        public double pointerX;
        public double pointerY;
        public AbstractMesh meshUnderPointer;
        public ActionEvent(AbstractMesh source, double pointerX, double pointerY, AbstractMesh meshUnderPointer)
        {
            this.source = source;
            this.pointerX = pointerX;
            this.pointerY = pointerY;
        }
        public static ActionEvent CreateNew(AbstractMesh source)
        {
            var scene = source.getScene();
            return new ActionEvent(source, scene.pointerX, scene.pointerY, scene.meshUnderPointer);
        }
    }
    public partial class ActionManager
    {
        public const int NothingTrigger = 0;
        public const int OnPickTrigger = 1;
        public const int OnLeftPickTrigger = 2;
        public const int OnRightPickTrigger = 3;
        public const int OnCenterPickTrigger = 4;
        public const int OnPointerOverTrigger = 5;
        public const int OnPointerOutTrigger = 6;
        public const int OnEveryFrameTrigger = 7;
        public const int OnIntersectionEnterTrigger = 8;
        public const int OnIntersectionExitTrigger = 9;
        public Array<Action> actions = new Array<Action>();
        private Scene _scene;
        public ActionManager(Scene scene)
        {
            this._scene = scene;
            scene._actionManagers.push(this);
        }
        public virtual void dispose()
        {
            var index = this._scene._actionManagers.indexOf(this);
            if (index > -1)
            {
                this._scene._actionManagers.RemoveAt(index);
            }
        }
        public virtual Scene getScene()
        {
            return this._scene;
        }
        public virtual bool hasSpecificTriggers(Array<int> triggers)
        {
            for (var index = 0; index < this.actions.Length; index++)
            {
                var action = this.actions[index];
                if (triggers.indexOf(action.trigger) > -1)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool hasPointerTriggers
        {
            get
            {
                for (var index = 0; index < this.actions.Length; index++)
                {
                    var action = this.actions[index];
                    if (action.trigger >= ActionManager.OnPickTrigger && action.trigger <= ActionManager.OnPointerOutTrigger)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public virtual bool hasPickTriggers
        {
            get
            {
                for (var index = 0; index < this.actions.Length; index++)
                {
                    var action = this.actions[index];
                    if (action.trigger >= ActionManager.OnPickTrigger && action.trigger <= ActionManager.OnCenterPickTrigger)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public virtual Action registerAction(Action action)
        {
            if (action.trigger == ActionManager.OnEveryFrameTrigger)
            {
                if (this.getScene().actionManager != this)
                {
                    Tools.Warn("OnEveryFrameTrigger can only be used with scene.actionManager");
                    return null;
                }
            }
            this.actions.push(action);
            action._actionManager = this;
            action._prepare();
            return action;
        }
        public virtual void processTrigger(double trigger, ActionEvent evt)
        {
            for (var index = 0; index < this.actions.Length; index++)
            {
                var action = this.actions[index];
                if (action.trigger == trigger)
                {
                    action._executeCurrent(evt);
                }
            }
        }
        public virtual IAnimatable _getEffectiveTarget(IAnimatable target, string propertyPath)
        {
            var properties = propertyPath.Split('.');
            for (var index = 0; index < properties.Length - 1; index++)
            {
                target = target[properties[index]].value as IAnimatable;
            }
            return target;
        }
        public virtual string _getProperty(string propertyPath)
        {
            var properties = propertyPath.Split('.');
            return properties[properties.Length - 1];
        }
    }
}