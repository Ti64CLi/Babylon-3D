// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.actionManager.cs" company="">
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
    public partial class ActionEvent
    {
        /// <summary>
        /// </summary>
        public AbstractMesh meshUnderPointer;

        /// <summary>
        /// </summary>
        public double pointerX;

        /// <summary>
        /// </summary>
        public double pointerY;

        /// <summary>
        /// </summary>
        public AbstractMesh source;

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        /// <param name="pointerX">
        /// </param>
        /// <param name="pointerY">
        /// </param>
        /// <param name="meshUnderPointer">
        /// </param>
        public ActionEvent(AbstractMesh source, double pointerX, double pointerY, AbstractMesh meshUnderPointer)
        {
            this.meshUnderPointer = meshUnderPointer;
            this.source = source;
            this.pointerX = pointerX;
            this.pointerY = pointerY;
        }

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        /// <returns>
        /// </returns>
        public static ActionEvent CreateNew(AbstractMesh source)
        {
            var scene = source.getScene();
            return new ActionEvent(source, scene.pointerX, scene.pointerY, scene.meshUnderPointer);
        }
    }

    /// <summary>
    /// </summary>
    public partial class ActionManager
    {
        /// <summary>
        /// </summary>
        public Array<Action> actions = new Array<Action>();

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        public ActionManager(Scene scene)
        {
            this._scene = scene;
            scene._actionManagers.Add(this);
        }

        /// <summary>
        /// </summary>
        public virtual bool hasPickTriggers
        {
            get
            {
                for (var index = 0; index < this.actions.Length; index++)
                {
                    var action = this.actions[index];
                    if (action.trigger >= OnPickTrigger && action.trigger <= OnCenterPickTrigger)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// </summary>
        public virtual bool hasPointerTriggers
        {
            get
            {
                for (var index = 0; index < this.actions.Length; index++)
                {
                    var action = this.actions[index];
                    if (action.trigger >= OnPickTrigger && action.trigger <= OnPointerOutTrigger)
                    {
                        return true;
                    }
                }

                return false;
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
            var properties = propertyPath.Split('.');
            for (var index = 0; index < properties.Length - 1; index++)
            {
                target = target[properties[index]] as IAnimatable;
            }

            return target;
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyPath">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual string _getProperty(string propertyPath)
        {
            var properties = propertyPath.Split('.');
            return properties[properties.Length - 1];
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            var index = this._scene._actionManagers.IndexOf(this);
            if (index > -1)
            {
                this._scene._actionManagers.RemoveAt(index);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Scene getScene()
        {
            return this._scene;
        }

        /// <summary>
        /// </summary>
        /// <param name="triggers">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool hasSpecificTriggers(Array<int> triggers)
        {
            for (var index = 0; index < this.actions.Length; index++)
            {
                var action = this.actions[index];
                if (triggers.IndexOf(action.trigger) > -1)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="trigger">
        /// </param>
        /// <param name="evt">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="action">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Action registerAction(Action action)
        {
            if (action.trigger == OnEveryFrameTrigger)
            {
                if (this.getScene().actionManager != this)
                {
                    Tools.Warn("OnEveryFrameTrigger can only be used with scene.actionManager");
                    return null;
                }
            }

            this.actions.Add(action);
            action._actionManager = this;
            action._prepare();
            return action;
        }

        /// <summary>
        /// </summary>
        public const int NothingTrigger = 0;

        /// <summary>
        /// </summary>
        public const int OnPickTrigger = 1;

        /// <summary>
        /// </summary>
        public const int OnLeftPickTrigger = 2;

        /// <summary>
        /// </summary>
        public const int OnRightPickTrigger = 3;

        /// <summary>
        /// </summary>
        public const int OnCenterPickTrigger = 4;

        /// <summary>
        /// </summary>
        public const int OnPointerOverTrigger = 5;

        /// <summary>
        /// </summary>
        public const int OnPointerOutTrigger = 6;

        /// <summary>
        /// </summary>
        public const int OnEveryFrameTrigger = 7;

        /// <summary>
        /// </summary>
        public const int OnIntersectionEnterTrigger = 8;

        /// <summary>
        /// </summary>
        public const int OnIntersectionExitTrigger = 9;
    }
}