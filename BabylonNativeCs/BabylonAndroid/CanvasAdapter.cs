namespace BabylonAndroid
{
    using System;
    using Babylon;
    using BABYLON;

    public class CanvasAdapter : Web.HTMLCanvasElement
    {
        private int maxWidth;
        private int maxHeight;

        public CanvasAdapter(int width, int height, int maxWidth, int maxHeight)
        {
            this.width = width;
            this.height = height;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;

            this.document = new DocumentAdapter(this);
        }

        public int width
        {
            get;
            set;
        }

        public int height
        {
            get;
            set;
        }

        public object getContext(string contextId, params object[] args)
        {
            if (contextId == "webgl")
            {
                return new GlRenderingContextAdapter();
            }

            if (contextId == "2d")
            {
                return new CanvasRenderingContext2DAdapter();
            }

            throw new NotImplementedException();
        }

        public string toDataURL(string type = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Web.Blob msToBlob()
        {
            throw new NotImplementedException();
        }

        public object hidden
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

        public object readyState
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

        public Func<Web.MouseEvent, object> onmouseleave
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

        public Func<Web.DragEvent, object> onbeforecut
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

        public Func<Web.KeyboardEvent, object> onkeydown
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

        public Func<Web.MSEventObj, object> onmove
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

        public Func<Web.KeyboardEvent, object> onkeyup
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

        public Func<Web.Event, object> onreset
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

        public Func<Web.Event, object> onhelp
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

        public Func<Web.DragEvent, object> ondragleave
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

        public string className
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

        public Func<Web.FocusEvent, object> onfocusin
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

        public Func<Web.Event, object> onseeked
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

        public object recordNumber
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

        public string title
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

        public Web.Element parentTextEdit
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

        public string outerHTML
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

        public Func<Web.Event, object> ondurationchange
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

        public int offsetHeight
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

        public Web.HTMLCollection all
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

        public Func<Web.FocusEvent, object> onblur
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

        public string dir
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

        public Func<Web.Event, object> onemptied
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

        public Func<Web.Event, object> onseeking
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

        public Func<Web.Event, object> oncanplay
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

        public Func<Web.UIEvent, object> ondeactivate
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

        public Func<Web.MSEventObj, object> ondatasetchanged
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

        public Func<Web.MSEventObj, object> onrowsdelete
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

        public int sourceIndex
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

        public Func<Web.Event, object> onloadstart
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

        public Func<Web.MSEventObj, object> onlosecapture
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

        public Func<Web.DragEvent, object> ondragenter
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

        public Func<Web.MSEventObj, object> oncontrolselect
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

        public Func<Web.Event, object> onsubmit
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

        public Web.MSBehaviorUrnsCollection behaviorUrns
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

        public string scopeName
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

        public Func<Web.Event, object> onchange
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

        public string id
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

        public Func<Web.MSEventObj, object> onlayoutcomplete
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

        public string uniqueID
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

        public Func<Web.UIEvent, object> onbeforeactivate
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

        public Func<Web.Event, object> oncanplaythrough
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

        public Func<Web.MSEventObj, object> onbeforeupdate
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

        public Func<Web.MSEventObj, object> onfilterchange
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

        public Web.Element offsetParent
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

        public Func<Web.MSEventObj, object> ondatasetcomplete
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

        public Func<Web.Event, object> onsuspend
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

        public Func<Web.MouseEvent, object> onmouseenter
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

        public string innerText
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

        public Func<Web.MSEventObj, object> onerrorupdate
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

        public Func<Web.MouseEvent, object> onmouseout
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

        public Web.HTMLElement parentElement
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

        public Func<Web.MouseWheelEvent, object> onmousewheel
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

        public Func<Web.Event, object> onvolumechange
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

        public Func<Web.MSEventObj, object> oncellchange
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

        public Func<Web.MSEventObj, object> onrowexit
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

        public Func<Web.MSEventObj, object> onrowsinserted
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

        public Func<Web.MSEventObj, object> onpropertychange
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

        public object filters
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

        public Web.HTMLCollection children
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

        public Func<Web.DragEvent, object> ondragend
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

        public Func<Web.DragEvent, object> onbeforepaste
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

        public Func<Web.DragEvent, object> ondragover
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

        public int offsetTop
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

        public Func<Web.MouseEvent, object> onmouseup
        {
            get;
            set;
        }

        public Func<Web.DragEvent, object> ondragstart
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

        public Func<Web.DragEvent, object> onbeforecopy
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

        public Func<Web.DragEvent, object> ondrag
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

        public string innerHTML
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

        public Func<Web.MouseEvent, object> onmouseover
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

        public string lang
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

        public int uniqueNumber
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

        public Func<Web.Event, object> onpause
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

        public string tagUrn
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

        public Func<Web.MouseEvent, object> onmousedown
        {
            get;
            set;
        }

        public Func<Web.MouseEvent, object> onclick
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

        public Func<Web.Event, object> onwaiting
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

        public Func<Web.MSEventObj, object> onresizestart
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

        public int offsetLeft
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

        public bool isTextEdit
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

        public bool isDisabled
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

        public Func<Web.DragEvent, object> onpaste
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

        public bool canHaveHTML
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

        public Func<Web.MSEventObj, object> onmoveend
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

        public string language
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

        public Func<Web.Event, object> onstalled
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

        public Func<Web.MouseEvent, object> onmousemove
        {
            get;
            set;
        }

        public Web.MSStyleCSSProperties style
        {
            get;
            set;
        }

        public bool isContentEditable
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

        public Func<Web.MSEventObj, object> onbeforeeditfocus
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

        public Func<Web.Event, object> onratechange
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

        public string contentEditable
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

        public int tabIndex
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

        public Web.Document document
        {
            get;
            set;
        }

        public Func<Web.ProgressEvent, object> onprogress
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

        public Func<Web.MouseEvent, object> ondblclick
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

        public Func<Web.MouseEvent, object> oncontextmenu
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

        public Func<Web.Event, object> onloadedmetadata
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

        public Func<Web.MSEventObj, object> onafterupdate
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

        public Func<Web.ErrorEvent, object> onerror
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

        public Func<Web.Event, object> onplay
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

        public Func<Web.MSEventObj, object> onresizeend
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

        public Func<Web.Event, object> onplaying
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

        public bool isMultiLine
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

        public Func<Web.FocusEvent, object> onfocusout
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

        public Func<Web.UIEvent, object> onabort
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

        public Func<Web.MSEventObj, object> ondataavailable
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

        public bool hideFocus
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

        public Func<Web.Event, object> onreadystatechange
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

        public Func<Web.KeyboardEvent, object> onkeypress
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

        public Func<Web.Event, object> onloadeddata
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

        public Func<Web.UIEvent, object> onbeforedeactivate
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

        public string outerText
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

        public bool disabled
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

        public Func<Web.UIEvent, object> onactivate
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

        public string accessKey
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

        public Func<Web.MSEventObj, object> onmovestart
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

        public Func<Web.Event, object> onselectstart
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

        public Func<Web.FocusEvent, object> onfocus
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

        public Func<Web.Event, object> ontimeupdate
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

        public Func<Web.UIEvent, object> onresize
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

        public Func<Web.DragEvent, object> oncut
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

        public Func<Web.UIEvent, object> onselect
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

        public Func<Web.DragEvent, object> ondrop
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

        public int offsetWidth
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

        public Func<Web.DragEvent, object> oncopy
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

        public Func<Web.Event, object> onended
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

        public Func<Web.UIEvent, object> onscroll
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

        public Func<Web.MSEventObj, object> onrowenter
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

        public Func<Web.Event, object> onload
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

        public bool canHaveChildren
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

        public Func<Web.Event, object> oninput
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

        public Func<Web.MSEventObj, object> onmscontentzoom
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

        public Func<Web.Event, object> oncuechange
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

        public bool spellcheck
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

        public Web.DOMTokenList classList
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

        public Func<object, object> onmsmanipulationstatechanged
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

        public bool draggable
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

        public Web.DOMStringMap dataset
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

        public bool dragDrop()
        {
            throw new NotImplementedException();
        }

        public void scrollIntoView(bool top = false)
        {
            throw new NotImplementedException();
        }

        public void addFilter(object filter)
        {
            throw new NotImplementedException();
        }

        public void setCapture(bool containerCapture = false)
        {
            throw new NotImplementedException();
        }

        public void focus()
        {
            throw new NotImplementedException();
        }

        public string getAdjacentText(string where)
        {
            throw new NotImplementedException();
        }

        public void insertAdjacentText(string where, string text)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByClassName(string classNames)
        {
            throw new NotImplementedException();
        }

        public void setActive()
        {
            throw new NotImplementedException();
        }

        public void removeFilter(object filter)
        {
            throw new NotImplementedException();
        }

        public void blur()
        {
            throw new NotImplementedException();
        }

        public void clearAttributes()
        {
            throw new NotImplementedException();
        }

        public void releaseCapture()
        {
            throw new NotImplementedException();
        }

        public Web.ControlRangeCollection createControlRange()
        {
            throw new NotImplementedException();
        }

        public bool removeBehavior(int cookie)
        {
            throw new NotImplementedException();
        }

        public bool contains(Web.HTMLElement child)
        {
            throw new NotImplementedException();
        }

        public void click()
        {
            throw new NotImplementedException();
        }

        public Web.Element insertAdjacentElement(string position, Web.Element insertedElement)
        {
            throw new NotImplementedException();
        }

        public void mergeAttributes(Web.HTMLElement source, bool preserveIdentity = false)
        {
            throw new NotImplementedException();
        }

        public string replaceAdjacentText(string where, string newText)
        {
            throw new NotImplementedException();
        }

        public Web.Element applyElement(Web.Element apply, string where = null)
        {
            throw new NotImplementedException();
        }

        public int addBehavior(string bstrUrl, object factory = null)
        {
            throw new NotImplementedException();
        }

        public void insertAdjacentHTML(string where, string html)
        {
            throw new NotImplementedException();
        }

        public Web.MSInputMethodContext msGetInputContext()
        {
            throw new NotImplementedException();
        }

        public void addEventListener(string type, Web.EventListener listener, bool useCapture = false)
        {
            Log.Info(string.Format("addEventListener - {0}", type));

            switch (type)
            {
                case "mousemove":
                    this.onmousemove = (e) => { listener(e); return null; };
                    break;
                case "mouseup":
                    this.onmouseup = (e) => { listener(e); return null; };
                    break;
                case "mousedown":
                    this.onmousedown = (e) => { listener(e); return null; };
                    break;
                case "pointermove":
                    this.onpointermove = (e) => { listener(e); return null; };
                    break;
                case "pointerup":
                    this.onpointerup = (e) => { listener(e); return null; };
                    break;
                case "pointerdown":
                    this.onpointerdown = (e) => { listener(e); return null; };
                    break;
            }
        }

        public int scrollTop
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

        public int clientLeft
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

        public int scrollLeft
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

        public string tagName
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

        public int clientWidth
        {
            get
            {
                return this.width;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int scrollWidth
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

        public int clientHeight
        {
            get
            {
                return this.height;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int clientTop
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

        public int scrollHeight
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

        public string msRegionOverflow
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

        public Func<object, object> onmspointerdown
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

        public Func<object, object> onmsgotpointercapture
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

        public Func<object, object> onmsgesturedoubletap
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

        public Func<object, object> onmspointerhover
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

        public Func<object, object> onmsgesturehold
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

        public Func<object, object> onmspointermove
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

        public Func<object, object> onmsgesturechange
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

        public Func<object, object> onmsgesturestart
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

        public Func<object, object> onmspointercancel
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

        public Func<object, object> onmsgestureend
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

        public Func<object, object> onmsgesturetap
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

        public Func<object, object> onmspointerout
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

        public Func<object, object> onmsinertiastart
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

        public Func<object, object> onmslostpointercapture
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

        public Func<object, object> onmspointerover
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

        public int msContentZoomFactor
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

        public Func<object, object> onmspointerup
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

        public Func<Web.PointerEvent, object> onlostpointercapture
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

        public Func<object, object> onmspointerenter
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

        public Func<Web.PointerEvent, object> ongotpointercapture
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

        public Func<object, object> onmspointerleave
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

        public string getAttribute(string name = null)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByTagNameNS(string namespaceURI, string localName)
        {
            throw new NotImplementedException();
        }

        public bool hasAttributeNS(string namespaceURI, string localName)
        {
            throw new NotImplementedException();
        }

        public Web.ClientRect getBoundingClientRect()
        {
            return new ClientRectAdapter(0, 0, width, height);
        }

        public string getAttributeNS(string namespaceURI, string localName)
        {
            throw new NotImplementedException();
        }

        public Web.Attr getAttributeNodeNS(string namespaceURI, string localName)
        {
            throw new NotImplementedException();
        }

        public Web.Attr setAttributeNodeNS(Web.Attr newAttr)
        {
            throw new NotImplementedException();
        }

        public bool msMatchesSelector(string selectors)
        {
            throw new NotImplementedException();
        }

        public bool hasAttribute(string name)
        {
            throw new NotImplementedException();
        }

        public void removeAttribute(string name = null)
        {
            throw new NotImplementedException();
        }

        public void setAttributeNS(string namespaceURI, string qualifiedName, string value)
        {
            throw new NotImplementedException();
        }

        public Web.Attr getAttributeNode(string name)
        {
            throw new NotImplementedException();
        }

        public bool fireEvent(string eventName, object eventObj = null)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByTagName(string name)
        {
            throw new NotImplementedException();
        }

        public Web.ClientRectList getClientRects()
        {
            throw new NotImplementedException();
        }

        public Web.Attr setAttributeNode(Web.Attr newAttr)
        {
            throw new NotImplementedException();
        }

        public Web.Attr removeAttributeNode(Web.Attr oldAttr)
        {
            throw new NotImplementedException();
        }

        public void setAttribute(string name = null, string value = null)
        {
            throw new NotImplementedException();
        }

        public void removeAttributeNS(string namespaceURI, string localName)
        {
            throw new NotImplementedException();
        }

        public Web.MSRangeCollection msGetRegionContent()
        {
            throw new NotImplementedException();
        }

        public void msReleasePointerCapture(int pointerId)
        {
            throw new NotImplementedException();
        }

        public void msSetPointerCapture(int pointerId)
        {
            throw new NotImplementedException();
        }

        public void msZoomTo(Web.MsZoomToOptions args)
        {
            throw new NotImplementedException();
        }

        public void setPointerCapture(int pointerId)
        {
            throw new NotImplementedException();
        }

        public Web.ClientRect msGetUntransformedBounds()
        {
            throw new NotImplementedException();
        }

        public void releasePointerCapture(int pointerId)
        {
            throw new NotImplementedException();
        }

        public void msRequestFullscreen()
        {
            throw new NotImplementedException();
        }

        public int nodeType
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

        public Web.Node previousSibling
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

        public string localName
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

        public string namespaceURI
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

        public string textContent
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

        public Web.Node parentNode
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

        public Web.Node nextSibling
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

        public string nodeValue
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

        public Web.Node lastChild
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

        public Web.NodeList childNodes
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

        public string nodeName
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

        public Web.Document ownerDocument
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

        public Web.NamedNodeMap attributes
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

        public Web.Node firstChild
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

        public string prefix
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

        public Web.Node removeChild(Web.Node oldChild)
        {
            throw new NotImplementedException();
        }

        public Web.Node appendChild(Web.Node newChild)
        {
            throw new NotImplementedException();
        }

        public bool isSupported(string feature, string version)
        {
            throw new NotImplementedException();
        }

        public bool isEqualNode(Web.Node arg)
        {
            throw new NotImplementedException();
        }

        public string lookupPrefix(string namespaceURI)
        {
            throw new NotImplementedException();
        }

        public bool isDefaultNamespace(string namespaceURI)
        {
            throw new NotImplementedException();
        }

        public int compareDocumentPosition(Web.Node other)
        {
            throw new NotImplementedException();
        }

        public void normalize()
        {
            throw new NotImplementedException();
        }

        public bool isSameNode(Web.Node other)
        {
            throw new NotImplementedException();
        }

        public bool hasAttributes()
        {
            throw new NotImplementedException();
        }

        public string lookupNamespaceURI(string prefix)
        {
            throw new NotImplementedException();
        }

        public Web.Node cloneNode(bool deep = false)
        {
            throw new NotImplementedException();
        }

        public bool hasChildNodes()
        {
            throw new NotImplementedException();
        }

        public Web.Node replaceChild(Web.Node newChild, Web.Node oldChild)
        {
            throw new NotImplementedException();
        }

        public Web.Node insertBefore(Web.Node newChild, Web.Node refChild = null)
        {
            throw new NotImplementedException();
        }

        public int ENTITY_REFERENCE_NODE
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

        public int ATTRIBUTE_NODE
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

        public int DOCUMENT_FRAGMENT_NODE
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

        public int TEXT_NODE
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

        public int ELEMENT_NODE
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

        public int COMMENT_NODE
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

        public int DOCUMENT_POSITION_DISCONNECTED
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

        public int DOCUMENT_POSITION_CONTAINED_BY
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

        public int DOCUMENT_POSITION_CONTAINS
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

        public int DOCUMENT_TYPE_NODE
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

        public int DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC
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

        public int DOCUMENT_NODE
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

        public int ENTITY_NODE
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

        public int PROCESSING_INSTRUCTION_NODE
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

        public int CDATA_SECTION_NODE
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

        public int NOTATION_NODE
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

        public int DOCUMENT_POSITION_FOLLOWING
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

        public int DOCUMENT_POSITION_PRECEDING
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

        public void removeEventListener(string type, Web.EventListener listener, bool useCapture = false)
        {
            throw new NotImplementedException();
        }

        public bool dispatchEvent(Web.Event evt)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList querySelectorAll(string selectors)
        {
            throw new NotImplementedException();
        }

        public Web.Element querySelector(string selectors)
        {
            throw new NotImplementedException();
        }

        public int childElementCount
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

        public Web.Element previousElementSibling
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

        public Web.Element lastElementChild
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

        public Web.Element nextElementSibling
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

        public Web.Element firstElementChild
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

        public Func<Web.PointerEvent, object> onpointerenter
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

        public Func<Web.PointerEvent, object> onpointerout
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

        public Func<Web.PointerEvent, object> onpointerdown
        {
            get;
            set;
        }

        public Func<Web.PointerEvent, object> onpointerup
        {
            get;
            set;
        }

        public Func<Web.PointerEvent, object> onpointercancel
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

        public Func<Web.PointerEvent, object> onpointerover
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

        public Func<Web.PointerEvent, object> onpointermove
        {
            get;
            set;
        }

        public Func<Web.PointerEvent, object> onpointerleave
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

        public Web.MSStyleCSSProperties runtimeStyle
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

        public Web.MSCurrentStyleCSSProperties currentStyle
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

        public void doScroll(object component = null)
        {
            throw new NotImplementedException();
        }

        public string componentFromPoint(double x, double y)
        {
            throw new NotImplementedException();
        }

        public bool attachEvent(string _event, Web.EventListener listener)
        {
            throw new NotImplementedException();
        }

        public void detachEvent(string _event, Web.EventListener listener)
        {
            throw new NotImplementedException();
        }

        public Web.Node swapNode(Web.Node otherNode)
        {
            throw new NotImplementedException();
        }

        public Web.Node removeNode(bool deep = false)
        {
            throw new NotImplementedException();
        }

        public Web.Node replaceNode(Web.Node replacement)
        {
            throw new NotImplementedException();
        }

        public void loadImage(string url, Action<Web.ImageData> onload, Action<Web.ImageData, object> onerror)
        {
            // load file from Asset Manager
            var imageDataAdapter = FreeImageWrapper.LoadFromMemory(new IntPtr(0), 0);
            if (imageDataAdapter != null)
            {
                onload(imageDataAdapter);
            }
            else
            {
                onerror(null, null);
            }
        }
    }
}
