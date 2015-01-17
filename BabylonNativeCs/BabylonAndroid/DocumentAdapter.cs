namespace BabylonAndroid
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    using BABYLON;

    public class DocumentAdapter : Web.HTMLDocument
    {
        private Web.HTMLCanvasElement canvasAdapter;
        private Map<string, Web.EventListener> listeners;

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public extern static unsafe long AAsset_getLength(void* fileAsset);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public extern static unsafe void* AAsset_getBuffer(void* fileAsset);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public extern static unsafe void* AAssetManager_open(void* assetManager, byte* file, int mode);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public extern static unsafe void AAsset_close(void* fileAsset);

        private IntPtr _assetManager;

        public DocumentAdapter(Web.HTMLCanvasElement canvasAdapter, IntPtr assetManager)
        {
            this.parentWindow = new WindowAdapter();
            this.canvasAdapter = canvasAdapter;

            this.listeners = new Map<string, Web.EventListener>();

            this._assetManager = assetManager;
        }

        public Web.HTMLElement documentElement
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.MSCompatibleInfoCollection compatible
        {
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

        public Web.DOMImplementation implementation
        {
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

        public Web.HTMLCollection scripts
        {
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

        public string charset
        {
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

        public string vlinkColor
        {
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

        public string security
        {
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

        public Web.MSNamespaceInfoCollection namespaces
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string defaultCharset
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.HTMLCollection embeds
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.StyleSheetList styleSheets
        {
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

        public Web.HTMLCollection forms
        {
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

        public string designMode
        {
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

        public Web.MSScriptHost Script
        {
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

        public string URLUnencoded
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.Window defaultView
        {
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

        public string inputEncoding
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.Element activeElement
        {
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

        public Web.HTMLCollection links
        {
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

        public string URL
        {
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

        public Web.HTMLHeadElement head
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string cookie
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string xmlEncoding
        {
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

        public int documentMode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string characterSet
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.HTMLCollection anchors
        {
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

        public Web.HTMLCollection plugins
        {
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

        public Web.SVGSVGElement rootElement
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string readyState
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string referrer
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string alinkColor
        {
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

        public Web.Window parentWindow
        {
            get;
            set;
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

        public Func<Web.MSSiteModeEvent, object> onmsthumbnailclick
        {
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

        public string xmlVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool msCapsLockWarningOff
        {
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

        public Web.DocumentType doctype
        {
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

        public string bgColor
        {
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

        public string linkColor
        {
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

        public Func<Web.Event, object> onstop
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Func<Web.MSSiteModeEvent, object> onmssitemodejumplistitemremoved
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.HTMLCollection applets
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.HTMLElement body
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string domain
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool xmlStandalone
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.MSSelection selection
        {
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

        public string media
        {
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

        public Web.HTMLCollection images
        {
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

        public Func<Web.Event, object> onselectionchange
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Func<Web.StorageEvent, object> onstoragecommit
        {
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

        public string lastModified
        {
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

        public string fgColor
        {
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

        public string compatMode
        {
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

        public bool msHidden
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string msVisibilityState
        {
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

        public string visibilityState
        {
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

        public bool msCSSOMElementFloatMetrics
        {
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

        public bool hidden
        {
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

        public bool msFullscreenEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Func<object, object> onmsfullscreenerror
        {
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

        public Web.Element msFullscreenElement
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Func<object, object> onmsfullscreenchange
        {
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

        public Web.HTMLElement getElementById(string elementId)
        {
            throw new NotImplementedException();
        }

        public string queryCommandValue(string commandId)
        {
            throw new NotImplementedException();
        }

        public Web.Node adoptNode(Web.Node source)
        {
            throw new NotImplementedException();
        }

        public bool queryCommandIndeterm(string commandId)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByTagNameNS(string namespaceURI, string localName)
        {
            throw new NotImplementedException();
        }

        public Web.ProcessingInstruction createProcessingInstruction(string target, string data)
        {
            throw new NotImplementedException();
        }

        public bool execCommand(string commandId, bool showUI = false, object value = null)
        {
            throw new NotImplementedException();
        }

        public Web.Element elementFromPoint(double x, double y)
        {
            throw new NotImplementedException();
        }

        public Web.CDATASection createCDATASection(string data)
        {
            throw new NotImplementedException();
        }

        public string queryCommandText(string commandId)
        {
            throw new NotImplementedException();
        }

        public void write(params object[] content)
        {
            throw new NotImplementedException();
        }

        public void updateSettings()
        {
            throw new NotImplementedException();
        }

        public Web.HTMLElement createElement(string tagName)
        {
            if (tagName == "canvas")
            {
                return this.canvasAdapter;
            }

            throw new NotImplementedException();
        }

        public void releaseCapture()
        {
            throw new NotImplementedException();
        }

        public void writeln(params object[] content)
        {
            throw new NotImplementedException();
        }

        public Web.Element createElementNS(string namespaceURI, string qualifiedName)
        {
            throw new NotImplementedException();
        }

        public object open(string url = null, string name = null, string features = null, bool replace = false)
        {
            throw new NotImplementedException();
        }

        public bool queryCommandSupported(string commandId)
        {
            throw new NotImplementedException();
        }

        public Web.TreeWalker createTreeWalker(Web.Node root, double whatToShow, Web.NodeFilter filter, bool entityReferenceExpansion)
        {
            throw new NotImplementedException();
        }

        public Web.Attr createAttributeNS(string namespaceURI, string qualifiedName)
        {
            throw new NotImplementedException();
        }

        public bool queryCommandEnabled(string commandId)
        {
            throw new NotImplementedException();
        }

        public void focus()
        {
            throw new NotImplementedException();
        }

        public void close()
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByClassName(string classNames)
        {
            throw new NotImplementedException();
        }

        public Web.Node importNode(Web.Node importedNode, bool deep)
        {
            throw new NotImplementedException();
        }

        public Web.Range createRange()
        {
            throw new NotImplementedException();
        }

        public bool fireEvent(string eventName, object eventObj = null)
        {
            throw new NotImplementedException();
        }

        public Web.Comment createComment(string data)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByTagName(string name)
        {
            throw new NotImplementedException();
        }

        public Web.DocumentFragment createDocumentFragment()
        {
            throw new NotImplementedException();
        }

        public Web.CSSStyleSheet createStyleSheet(string href = null, int index = 0)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList getElementsByName(string elementName)
        {
            throw new NotImplementedException();
        }

        public bool queryCommandState(string commandId)
        {
            throw new NotImplementedException();
        }

        public bool hasFocus()
        {
            throw new NotImplementedException();
        }

        public bool execCommandShowHelp(string commandId)
        {
            throw new NotImplementedException();
        }

        public Web.Attr createAttribute(string name)
        {
            throw new NotImplementedException();
        }

        public Web.Text createTextNode(string data)
        {
            throw new NotImplementedException();
        }

        public Web.NodeIterator createNodeIterator(Web.Node root, double whatToShow, Web.NodeFilter filter, bool entityReferenceExpansion)
        {
            throw new NotImplementedException();
        }

        public Web.MSEventObj createEventObject(object eventObj = null)
        {
            throw new NotImplementedException();
        }

        public Web.Selection getSelection()
        {
            throw new NotImplementedException();
        }

        public Web.NodeList msElementsFromPoint(double x, double y)
        {
            throw new NotImplementedException();
        }

        public Web.NodeList msElementsFromRect(int left, int top, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public void msExitFullscreen()
        {
            throw new NotImplementedException();
        }

        public void addEventListener(string type, Web.EventListener listener, bool useCapture = false)
        {
            this.listeners[type] = listener;
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

        public bool attachEvent(string _event, Web.EventListener listener)
        {
            throw new NotImplementedException();
        }

        public void detachEvent(string _event, Web.EventListener listener)
        {
            throw new NotImplementedException();
        }

        public Web.Event createEvent(string eventInterface)
        {
            throw new NotImplementedException();
        }

        public string protocol
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string fileSize
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string fileUpdatedDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string nameProp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string fileCreatedDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string fileModifiedDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string mimeType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public void captureEvents()
        {
            throw new NotImplementedException();
        }

        public void releaseEvents()
        {
            throw new NotImplementedException();
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

        public void loadFile(string fileName, Action<string> callback, System.Action<int, int> progressCallBack)
        {
            if (callback != null)
            {
                var text = ReadAllText(fileName);
                callback(text);
            }
        }

        public void loadFile(string fileName, Action<byte[]> callback, System.Action<int, int> progressCallBack)
        {
            if (callback != null)
            {
                var bytes = ReadAllBytes(fileName);
                callback(bytes);
            }
        }

        private byte[] ReadAllBytes(string url)
        {
            byte[] data;

            int AASSET_MODE_BUFFER = 3;

#if _DEBUG
            Tools.Log(string.Format("(ASSET)loading data from file {0}", url));
#endif
            unsafe
            {
                void* fileAsset;

                fixed (byte* file = Encoding.ASCII.GetBytes(url))
                {
                    void* assetManager = null;
                    fileAsset = AAssetManager_open(_assetManager.ToPointer(), file, AASSET_MODE_BUFFER);
                    void* fileData = AAsset_getBuffer(fileAsset);
                    long fileLen = AAsset_getLength(fileAsset);

                    data = new byte[fileLen];
                    Memcpy(data, 0, (byte*)fileData, 0, (int)fileLen);

                    if (fileAsset != null)
                    {
                        AAsset_close(fileAsset);
                    }
                }
            }

#if _DEBUG
            Tools.Log(string.Format("(ASSET)returning {0}", data.Length));
#endif

            return data;
        }

        private string ReadAllText(string url)
        {
            string data;

            int AASSET_MODE_BUFFER = 3;

#if _DEBUG
            Tools.Log(string.Format("(ASSET)loading data from file {0}", url));
#endif
            unsafe
            {
                void* fileAsset;

                fixed (byte* file = Encoding.ASCII.GetBytes(url))
                {
                    void* assetManager = null;
                    fileAsset = AAssetManager_open(_assetManager.ToPointer(), file, AASSET_MODE_BUFFER);
                    void* fileData = AAsset_getBuffer(fileAsset);
                    long fileLen = AAsset_getLength(fileAsset);

                    data = new String((byte*)fileData, 0, (int)fileLen);
                    if (fileAsset != null)
                    {
                        AAsset_close(fileAsset);
                    }
                }
            }

#if _DEBUG
            Tools.Log(string.Format("(ASSET)returning {0}", data.Length));
#endif

            return data;
        }

        internal unsafe static void Memcpy(byte[] dest, int destIndex, byte* src, int srcIndex, int len)
        {
            // If dest has 0 elements, the fixed statement will throw an 
            // IndexOutOfRangeException.  Special-case 0-byte copies.
            if (len == 0)
                return;

            fixed (byte* pDest = dest)
            {
                Memcpy(pDest + destIndex, src + srcIndex, len);
            }
        }

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        internal extern unsafe static void llvm_memcpy_p0i8_p0i8_i32(byte* dst, byte* src, int len, int align, bool isVolotile);

        internal unsafe static void Memcpy(byte* dest, byte* src, int len)
        {
            llvm_memcpy_p0i8_p0i8_i32(dest, src, len, 4, false);
        }
    }
}
