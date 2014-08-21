namespace BabylonWpf
{
    using System;
    using BABYLON;

    public class WindowAdapter : Web.Window
    {
        private Map<string, Web.EventListener> listeners;

        public WindowAdapter()
        {
            this.listeners = new Map<string, Web.EventListener>();
            this.console = new ConsoleAdapter();
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

        public Func<Web.MouseEvent, object> onmouseup
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

        public int screenX
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

        public Web.History history
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

        public int pageXOffset
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

        public string name
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

        public Func<Web.Event, object> onafterprint
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

        public Func<Web.Event, object> onbeforeprint
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

        public Web.Window top
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

        public Web.Window opener
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

        public int innerHeight
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

        public Func<Web.Event, object> ononline
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

        public Web.Window frames
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

        public int outerWidth
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int innerWidth
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

        public Func<Web.Event, object> onoffline
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

        public int Length
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

        public Web.Screen screen
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

        public Func<Web.BeforeUnloadEvent, object> onbeforeunload
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

        public Func<Web.StorageEvent, object> onstorage
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

        public Web.Window self
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public int pageYOffset
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

        public Web.ErrorEventHandler onerror
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

        public Web.Window parent
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

        public Web.Location location
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

        public int outerHeight
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

        public Web.Element frameElement
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

        public Web.Window window
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

        public Func<Web.MessageEvent, object> onmessage
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

        public Web.Navigator navigator
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

        public Web.StyleMedia styleMedia
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

        public Func<Web.Event, object> onhashchange
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

        public Func<Web.Event, object> onunload
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

        public int screenY
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

        public Web.Performance performance
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

        public int animationStartTime
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

        public int msAnimationStartTime
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

        public Web.ApplicationCache applicationCache
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

        public Func<Web.PopStateEvent, object> onpopstate
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

        public Func<Web.PageTransitionEvent, object> onpageshow
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

        public Func<Web.DeviceMotionEvent, object> ondevicemotion
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

        public int devicePixelRatio
        {
            get
            {
                return 1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.Crypto msCrypto
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

        public Func<Web.DeviceOrientationEvent, object> ondeviceorientation
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

        public string doNotTrack
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

        public Func<Web.PageTransitionEvent, object> onpagehide
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

        public void alert(object message = null)
        {
            throw new NotImplementedException();
        }

        public void scroll(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public void focus()
        {
            throw new NotImplementedException();
        }

        public void scrollTo(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public string prompt(string message = null, string _default = null)
        {
            throw new NotImplementedException();
        }

        public Web.Window open(string url = null, string target = null, string features = null, bool replace = false)
        {
            throw new NotImplementedException();
        }

        public void scrollBy(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public bool confirm(string message = null)
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            throw new NotImplementedException();
        }

        public void postMessage(object message, string targetOrigin, object ports = null)
        {
            throw new NotImplementedException();
        }

        public object showModalDialog(string url = null, object argument = null, object options = null)
        {
            throw new NotImplementedException();
        }

        public void blur()
        {
            throw new NotImplementedException();
        }

        public Web.Selection getSelection()
        {
            throw new NotImplementedException();
        }

        public Web.CSSStyleDeclaration getComputedStyle(Web.Element elt, string pseudoElt = null)
        {
            throw new NotImplementedException();
        }

        public void msCancelRequestAnimationFrame(int handle)
        {
            throw new NotImplementedException();
        }

        public Web.MediaQueryList matchMedia(string mediaQuery)
        {
            throw new NotImplementedException();
        }

        public void cancelAnimationFrame(int handle)
        {
            throw new NotImplementedException();
        }

        public bool msIsStaticHTML(string html)
        {
            throw new NotImplementedException();
        }

        public Web.MediaQueryList msMatchMedia(string mediaQuery)
        {
            throw new NotImplementedException();
        }

        public int requestAnimationFrame(Web.FrameRequestCallback callback)
        {
            throw new NotImplementedException();
        }

        public int msRequestAnimationFrame(Web.FrameRequestCallback callback)
        {
            throw new NotImplementedException();
        }

        public void addEventListener(string type, Web.EventListener listener, bool useCapture = false)
        {
            this.listeners[type] = listener;
        }

        public void removeEventListener(string type, Web.EventListener listener, bool useCapture = false)
        {
            throw new NotImplementedException();
        }

        public bool dispatchEvent(Web.Event evt)
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

        public Web.Storage localStorage
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

        public string status
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

        public int screenLeft
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

        public object offscreenBuffering
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

        public int maxConnectionsPerServer
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

        public Web.DataTransfer clipboardData
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

        public string defaultStatus
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

        public Web.Navigator clientInformation
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

        public bool closed
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

        public Web.External external
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

        public Web.MSEventObj _event
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

        public int screenTop
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

        public Web.Window showModelessDialog(string url = null, object argument = null, object options = null)
        {
            throw new NotImplementedException();
        }

        public void navigate(string url)
        {
            throw new NotImplementedException();
        }

        public void resizeBy(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public object item(object index)
        {
            throw new NotImplementedException();
        }

        public void resizeTo(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public Web.MSPopupWindow createPopup(object arguments = null)
        {
            throw new NotImplementedException();
        }

        public string toStaticHTML(string html)
        {
            throw new NotImplementedException();
        }

        public object execScript(string code, string language = null)
        {
            throw new NotImplementedException();
        }

        public void msWriteProfilerMark(string profilerMarkName)
        {
            throw new NotImplementedException();
        }

        public void moveTo(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public void moveBy(double x = 0, double y = 0)
        {
            throw new NotImplementedException();
        }

        public void showHelp(string url, object helpArg = null, string features = null)
        {
            throw new NotImplementedException();
        }

        public void captureEvents()
        {
            throw new NotImplementedException();
        }

        public void releaseEvents()
        {
            throw new NotImplementedException();
        }

        public Web.Storage sessionStorage
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

        public void clearTimeout(int handle)
        {
            throw new NotImplementedException();
        }

        public int setTimeout(object handler, object timeout = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void clearInterval(int handle)
        {
            throw new NotImplementedException();
        }

        public int setInterval(object handler, object timeout = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        public int msSetImmediate(object expression, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void clearImmediate(int handle)
        {
            throw new NotImplementedException();
        }

        public void msClearImmediate(int handle)
        {
            throw new NotImplementedException();
        }

        public int setImmediate(object expression, params object[] args)
        {
            throw new NotImplementedException();
        }

        public string btoa(string rawString)
        {
            throw new NotImplementedException();
        }

        public string atob(string encodedString)
        {
            throw new NotImplementedException();
        }

        public Web.IDBFactory msIndexedDB
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

        public Web.IDBFactory indexedDB
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

        public Web.Console console
        {
            get;
            set;
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Func<Web.PointerEvent, object> onpointerup
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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
    }
}
