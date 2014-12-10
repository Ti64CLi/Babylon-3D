namespace BABYLON
{
    using System;

    public class PointerEventAdapter : MouseEventAdapter, Web.PointerEvent
    {
        public PointerEventAdapter(int pointerId, int x, int y) : base(-1, x, y)
        {
            this.pointerId = pointerId;
        }

        public object currentPoint
        {
            get
            { 
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int height
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int hwTimestamp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object intermediatePoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool isPrimary
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int pointerId
        {
            get;
            set;
        }

        public object pointerType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int pressure
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int rotation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int tiltX
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int tiltY
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int width
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void getCurrentPoint(Web.Element element)
        {
            throw new NotImplementedException();
        }

        public void getIntermediatePoints(Web.Element element)
        {
            throw new NotImplementedException();
        }

        public void initPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Web.Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg, Web.EventTarget relatedTargetArg, int offsetXArg, int offsetYArg, double widthArg, int heightArg, int pressure, int rotation, int tiltX, int tiltY, int pointerIdArg, object pointerType, int hwTimestampArg, bool isPrimary)
        {
            throw new NotImplementedException();
        }
    }
}
