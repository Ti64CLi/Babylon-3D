using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BABYLON;
using Web;
namespace Web
{
    public partial interface ArrayBuffer
    {
        double byteLength
        {
            get;
            set;
        }
    }
    public partial interface ArrayBufferView
    {
        ArrayBuffer buffer
        {
            get;
            set;
        }
        double byteOffset
        {
            get;
            set;
        }
        double byteLength
        {
            get;
            set;
        }
    }
    public partial interface Int8Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Int8Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Int8Array subarray(double begin, double end = 0.0);
    }
    public partial interface Uint8Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Uint8Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Uint8Array subarray(double begin, double end = 0.0);
    }
    public partial interface Int16Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Int16Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Int16Array subarray(double begin, double end = 0.0);
    }
    public partial interface Uint16Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Uint16Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Uint16Array subarray(double begin, double end = 0.0);
    }
    public partial interface Int32Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Int32Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Int32Array subarray(double begin, double end = 0.0);
    }
    public partial interface Uint32Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Uint32Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Uint32Array subarray(double begin, double end = 0.0);
    }
    public partial interface Float32Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Float32Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Float32Array subarray(double begin, double end = 0.0);
    }
    public partial interface Float64Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double this[double index]
        {
            get;
            set;
        }
        double get(double index);
        void set(double index, double value);
        void set(Float64Array array, double offset = 0.0);
        void set(Array<double> array, double offset = 0.0);
        Float64Array subarray(double begin, double end = 0.0);
    }
    public partial interface DataView : ArrayBufferView
    {
        double getInt8(double byteOffset);
        double getUint8(double byteOffset);
        double getInt16(double byteOffset, bool littleEndian = false);
        double getUint16(double byteOffset, bool littleEndian = false);
        double getInt32(double byteOffset, bool littleEndian = false);
        double getUint32(double byteOffset, bool littleEndian = false);
        double getFloat32(double byteOffset, bool littleEndian = false);
        double getFloat64(double byteOffset, bool littleEndian = false);
        void setInt8(double byteOffset, double value);
        void setUint8(double byteOffset, double value);
        void setInt16(double byteOffset, double value, bool littleEndian = false);
        void setUint16(double byteOffset, double value, bool littleEndian = false);
        void setInt32(double byteOffset, double value, bool littleEndian = false);
        void setUint32(double byteOffset, double value, bool littleEndian = false);
        void setFloat32(double byteOffset, double value, bool littleEndian = false);
        void setFloat64(double byteOffset, double value, bool littleEndian = false);
    }
    public partial interface Map<K, V>
    {
        void clear();
        bool delete(K key);
        void forEach(System.Action<V, K, Map<K, V>> callbackfn, object thisArg = null);
        V get(K key);
        bool has(K key);
        Map<K, V> set(K key, V value);
        double size
        {
            get;
            set;
        }
    }
    public partial interface WeakMap<K, V>
    {
        void clear();
        bool delete(K key);
        V get(K key);
        bool has(K key);
        WeakMap<K, V> set(K key, V value);
    }
    public partial interface Set<T>
    {
        Set<T> add(T value);
        void clear();
        bool delete(T value);
        void forEach(System.Action<T, T, Set<T>> callbackfn, object thisArg = null);
        bool has(T value);
        double size
        {
            get;
            set;
        }
    }
    public partial interface String
    {
        double localeCompare(string that, Array<string> locales, Intl.CollatorOptions options = null);
        double localeCompare(string that, string locale, Intl.CollatorOptions options = null);
    }
    public partial interface Number
    {
        string toLocaleString(Array<string> locales = null, Intl.NumberFormatOptions options = null);
        string toLocaleString(string locale = null, Intl.NumberFormatOptions options = null);
    }
    public partial interface Date
    {
        string toLocaleString(Array<string> locales = null, Intl.DateTimeFormatOptions options = null);
        string toLocaleString(string locale = null, Intl.DateTimeFormatOptions options = null);
    }
    public partial interface PositionOptions
    {
        bool enableHighAccuracy
        {
            get;
            set;
        }
        double timeout
        {
            get;
            set;
        }
        double maximumAge
        {
            get;
            set;
        }
    }
    public partial interface ObjectURLOptions
    {
        bool oneTimeOnly
        {
            get;
            set;
        }
    }
    public partial interface StoreExceptionsInformation : ExceptionInformation
    {
        string siteName
        {
            get;
            set;
        }
        string explanationString
        {
            get;
            set;
        }
        string detailURI
        {
            get;
            set;
        }
    }
    public partial interface StoreSiteSpecificExceptionsInformation : StoreExceptionsInformation
    {
        Array<string> arrayOfDomainStrings
        {
            get;
            set;
        }
    }
    public partial interface ConfirmSiteSpecificExceptionsInformation : ExceptionInformation
    {
        Array<string> arrayOfDomainStrings
        {
            get;
            set;
        }
    }
    public partial interface AlgorithmParameters { }
    public partial interface MutationObserverInit
    {
        bool childList
        {
            get;
            set;
        }
        bool attributes
        {
            get;
            set;
        }
        bool characterData
        {
            get;
            set;
        }
        bool subtree
        {
            get;
            set;
        }
        bool attributeOldValue
        {
            get;
            set;
        }
        bool characterDataOldValue
        {
            get;
            set;
        }
        Array<string> attributeFilter
        {
            get;
            set;
        }
    }
    public partial interface PointerEventInit : MouseEventInit
    {
        double pointerId
        {
            get;
            set;
        }
        double width
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        double pressure
        {
            get;
            set;
        }
        double tiltX
        {
            get;
            set;
        }
        double tiltY
        {
            get;
            set;
        }
        string pointerType
        {
            get;
            set;
        }
        bool isPrimary
        {
            get;
            set;
        }
    }
    public partial interface ExceptionInformation
    {
        string domain
        {
            get;
            set;
        }
    }
    public partial interface DeviceAccelerationDict
    {
        double x
        {
            get;
            set;
        }
        double y
        {
            get;
            set;
        }
        double z
        {
            get;
            set;
        }
    }
    public partial interface MsZoomToOptions
    {
        double contentX
        {
            get;
            set;
        }
        double contentY
        {
            get;
            set;
        }
        string viewportX
        {
            get;
            set;
        }
        string viewportY
        {
            get;
            set;
        }
        double scaleFactor
        {
            get;
            set;
        }
        string animate
        {
            get;
            set;
        }
    }
    public partial interface DeviceRotationRateDict
    {
        double alpha
        {
            get;
            set;
        }
        double beta
        {
            get;
            set;
        }
        double gamma
        {
            get;
            set;
        }
    }
    public partial interface Algorithm
    {
        string name
        {
            get;
            set;
        }
        AlgorithmParameters _params
        {
            get;
            set;
        }
    }
    public partial interface MouseEventInit
    {
        bool bubbles
        {
            get;
            set;
        }
        bool cancelable
        {
            get;
            set;
        }
        Window view
        {
            get;
            set;
        }
        double detail
        {
            get;
            set;
        }
        double screenX
        {
            get;
            set;
        }
        double screenY
        {
            get;
            set;
        }
        double clientX
        {
            get;
            set;
        }
        double clientY
        {
            get;
            set;
        }
        bool ctrlKey
        {
            get;
            set;
        }
        bool shiftKey
        {
            get;
            set;
        }
        bool altKey
        {
            get;
            set;
        }
        bool metaKey
        {
            get;
            set;
        }
        double button
        {
            get;
            set;
        }
        double buttons
        {
            get;
            set;
        }
        EventTarget relatedTarget
        {
            get;
            set;
        }
    }
    public partial interface WebGLContextAttributes
    {
        bool alpha
        {
            get;
            set;
        }
        bool depth
        {
            get;
            set;
        }
        bool stencil
        {
            get;
            set;
        }
        bool antialias
        {
            get;
            set;
        }
        bool premultipliedAlpha
        {
            get;
            set;
        }
        bool preserveDrawingBuffer
        {
            get;
            set;
        }
    }
    public partial interface NodeListOf<TNode> : NodeList
    {
        double Length
        {
            get;
            set;
        }
        TNode item(double index);
        TNode this[double index]
        {
            get;
            set;
        }
    }
    public partial interface HTMLElement : Element, ElementCSSInlineStyle, MSEventAttachmentTarget, MSNodeExtensions
    {
        object hidden
        {
            get;
            set;
        }
        object readyState
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseleave
        {
            get;
            set;
        }
        System.Func<DragEvent, object> onbeforecut
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeydown
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onmove
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeyup
        {
            get;
            set;
        }
        System.Func<Event, object> onreset
        {
            get;
            set;
        }
        System.Func<Event, object> onhelp
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragleave
        {
            get;
            set;
        }
        string className
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusin
        {
            get;
            set;
        }
        System.Func<Event, object> onseeked
        {
            get;
            set;
        }
        object recordNumber
        {
            get;
            set;
        }
        string title
        {
            get;
            set;
        }
        Element parentTextEdit
        {
            get;
            set;
        }
        string outerHTML
        {
            get;
            set;
        }
        System.Func<Event, object> ondurationchange
        {
            get;
            set;
        }
        double offsetHeight
        {
            get;
            set;
        }
        HTMLCollection all
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onblur
        {
            get;
            set;
        }
        string dir
        {
            get;
            set;
        }
        System.Func<Event, object> onemptied
        {
            get;
            set;
        }
        System.Func<Event, object> onseeking
        {
            get;
            set;
        }
        System.Func<Event, object> oncanplay
        {
            get;
            set;
        }
        System.Func<UIEvent, object> ondeactivate
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> ondatasetchanged
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowsdelete
        {
            get;
            set;
        }
        double sourceIndex
        {
            get;
            set;
        }
        System.Func<Event, object> onloadstart
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onlosecapture
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragenter
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> oncontrolselect
        {
            get;
            set;
        }
        System.Func<Event, object> onsubmit
        {
            get;
            set;
        }
        MSBehaviorUrnsCollection behaviorUrns
        {
            get;
            set;
        }
        string scopeName
        {
            get;
            set;
        }
        System.Func<Event, object> onchange
        {
            get;
            set;
        }
        string id
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onlayoutcomplete
        {
            get;
            set;
        }
        string uniqueID
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onbeforeactivate
        {
            get;
            set;
        }
        System.Func<Event, object> oncanplaythrough
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onbeforeupdate
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onfilterchange
        {
            get;
            set;
        }
        Element offsetParent
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> ondatasetcomplete
        {
            get;
            set;
        }
        System.Func<Event, object> onsuspend
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseenter
        {
            get;
            set;
        }
        string innerText
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onerrorupdate
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseout
        {
            get;
            set;
        }
        HTMLElement parentElement
        {
            get;
            set;
        }
        System.Func<MouseWheelEvent, object> onmousewheel
        {
            get;
            set;
        }
        System.Func<Event, object> onvolumechange
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> oncellchange
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowexit
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowsinserted
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onpropertychange
        {
            get;
            set;
        }
        object filters
        {
            get;
            set;
        }
        HTMLCollection children
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragend
        {
            get;
            set;
        }
        System.Func<DragEvent, object> onbeforepaste
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragover
        {
            get;
            set;
        }
        double offsetTop
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseup
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragstart
        {
            get;
            set;
        }
        System.Func<DragEvent, object> onbeforecopy
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondrag
        {
            get;
            set;
        }
        string innerHTML
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseover
        {
            get;
            set;
        }
        string lang
        {
            get;
            set;
        }
        double uniqueNumber
        {
            get;
            set;
        }
        System.Func<Event, object> onpause
        {
            get;
            set;
        }
        string tagUrn
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousedown
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onclick
        {
            get;
            set;
        }
        System.Func<Event, object> onwaiting
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onresizestart
        {
            get;
            set;
        }
        double offsetLeft
        {
            get;
            set;
        }
        bool isTextEdit
        {
            get;
            set;
        }
        bool isDisabled
        {
            get;
            set;
        }
        System.Func<DragEvent, object> onpaste
        {
            get;
            set;
        }
        bool canHaveHTML
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onmoveend
        {
            get;
            set;
        }
        string language
        {
            get;
            set;
        }
        System.Func<Event, object> onstalled
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousemove
        {
            get;
            set;
        }
        MSStyleCSSProperties style
        {
            get;
            set;
        }
        bool isContentEditable
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onbeforeeditfocus
        {
            get;
            set;
        }
        System.Func<Event, object> onratechange
        {
            get;
            set;
        }
        string contentEditable
        {
            get;
            set;
        }
        double tabIndex
        {
            get;
            set;
        }
        Document document
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> ondblclick
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> oncontextmenu
        {
            get;
            set;
        }
        System.Func<Event, object> onloadedmetadata
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onafterupdate
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onplay
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onresizeend
        {
            get;
            set;
        }
        System.Func<Event, object> onplaying
        {
            get;
            set;
        }
        bool isMultiLine
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusout
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> ondataavailable
        {
            get;
            set;
        }
        bool hideFocus
        {
            get;
            set;
        }
        System.Func<Event, object> onreadystatechange
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeypress
        {
            get;
            set;
        }
        System.Func<Event, object> onloadeddata
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onbeforedeactivate
        {
            get;
            set;
        }
        string outerText
        {
            get;
            set;
        }
        bool disabled
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onactivate
        {
            get;
            set;
        }
        string accessKey
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onmovestart
        {
            get;
            set;
        }
        System.Func<Event, object> onselectstart
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocus
        {
            get;
            set;
        }
        System.Func<Event, object> ontimeupdate
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onresize
        {
            get;
            set;
        }
        System.Func<DragEvent, object> oncut
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onselect
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondrop
        {
            get;
            set;
        }
        double offsetWidth
        {
            get;
            set;
        }
        System.Func<DragEvent, object> oncopy
        {
            get;
            set;
        }
        System.Func<Event, object> onended
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onscroll
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowenter
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        bool canHaveChildren
        {
            get;
            set;
        }
        System.Func<Event, object> oninput
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onmscontentzoom
        {
            get;
            set;
        }
        System.Func<Event, object> oncuechange
        {
            get;
            set;
        }
        bool spellcheck
        {
            get;
            set;
        }
        DOMTokenList classList
        {
            get;
            set;
        }
        System.Func<object, object> onmsmanipulationstatechanged
        {
            get;
            set;
        }
        bool draggable
        {
            get;
            set;
        }
        DOMStringMap dataset
        {
            get;
            set;
        }
        bool dragDrop();
        void scrollIntoView(bool top = false);
        void addFilter(object filter);
        void setCapture(bool containerCapture = false);
        void focus();
        string getAdjacentText(string where);
        void insertAdjacentText(string where, string text);
        NodeList getElementsByClassName(string classNames);
        void setActive();
        void removeFilter(object filter);
        void blur();
        void clearAttributes();
        void releaseCapture();
        ControlRangeCollection createControlRange();
        bool removeBehavior(double cookie);
        bool contains(HTMLElement child);
        void click();
        Element insertAdjacentElement(string position, Element insertedElement);
        void mergeAttributes(HTMLElement source, bool preserveIdentity = false);
        string replaceAdjacentText(string where, string newText);
        Element applyElement(Element apply, string where = null);
        double addBehavior(string bstrUrl, object factory = null);
        void insertAdjacentHTML(string where, string html);
        MSInputMethodContext msGetInputContext();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface Document : Node, NodeSelector, MSEventAttachmentTarget, DocumentEvent, MSResourceMetadata, MSNodeExtensions, MSDocumentExtensions, GlobalEventHandlers
    {
        HTMLElement documentElement
        {
            get;
            set;
        }
        MSCompatibleInfoCollection compatible
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeydown
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeyup
        {
            get;
            set;
        }
        DOMImplementation implementation
        {
            get;
            set;
        }
        System.Func<Event, object> onreset
        {
            get;
            set;
        }
        HTMLCollection scripts
        {
            get;
            set;
        }
        System.Func<Event, object> onhelp
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragleave
        {
            get;
            set;
        }
        string charset
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusin
        {
            get;
            set;
        }
        string vlinkColor
        {
            get;
            set;
        }
        System.Func<Event, object> onseeked
        {
            get;
            set;
        }
        string security
        {
            get;
            set;
        }
        string title
        {
            get;
            set;
        }
        MSNamespaceInfoCollection namespaces
        {
            get;
            set;
        }
        string defaultCharset
        {
            get;
            set;
        }
        HTMLCollection embeds
        {
            get;
            set;
        }
        StyleSheetList styleSheets
        {
            get;
            set;
        }
        Window frames
        {
            get;
            set;
        }
        System.Func<Event, object> ondurationchange
        {
            get;
            set;
        }
        HTMLCollection all
        {
            get;
            set;
        }
        HTMLCollection forms
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onblur
        {
            get;
            set;
        }
        string dir
        {
            get;
            set;
        }
        System.Func<Event, object> onemptied
        {
            get;
            set;
        }
        string designMode
        {
            get;
            set;
        }
        System.Func<Event, object> onseeking
        {
            get;
            set;
        }
        System.Func<UIEvent, object> ondeactivate
        {
            get;
            set;
        }
        System.Func<Event, object> oncanplay
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> ondatasetchanged
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowsdelete
        {
            get;
            set;
        }
        MSScriptHost Script
        {
            get;
            set;
        }
        System.Func<Event, object> onloadstart
        {
            get;
            set;
        }
        string URLUnencoded
        {
            get;
            set;
        }
        Window defaultView
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> oncontrolselect
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragenter
        {
            get;
            set;
        }
        System.Func<Event, object> onsubmit
        {
            get;
            set;
        }
        string inputEncoding
        {
            get;
            set;
        }
        Element activeElement
        {
            get;
            set;
        }
        System.Func<Event, object> onchange
        {
            get;
            set;
        }
        HTMLCollection links
        {
            get;
            set;
        }
        string uniqueID
        {
            get;
            set;
        }
        string URL
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onbeforeactivate
        {
            get;
            set;
        }
        HTMLHeadElement head
        {
            get;
            set;
        }
        string cookie
        {
            get;
            set;
        }
        string xmlEncoding
        {
            get;
            set;
        }
        System.Func<Event, object> oncanplaythrough
        {
            get;
            set;
        }
        double documentMode
        {
            get;
            set;
        }
        string characterSet
        {
            get;
            set;
        }
        HTMLCollection anchors
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onbeforeupdate
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> ondatasetcomplete
        {
            get;
            set;
        }
        HTMLCollection plugins
        {
            get;
            set;
        }
        System.Func<Event, object> onsuspend
        {
            get;
            set;
        }
        SVGSVGElement rootElement
        {
            get;
            set;
        }
        string readyState
        {
            get;
            set;
        }
        string referrer
        {
            get;
            set;
        }
        string alinkColor
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onerrorupdate
        {
            get;
            set;
        }
        Window parentWindow
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseout
        {
            get;
            set;
        }
        System.Func<MSSiteModeEvent, object> onmsthumbnailclick
        {
            get;
            set;
        }
        System.Func<MouseWheelEvent, object> onmousewheel
        {
            get;
            set;
        }
        System.Func<Event, object> onvolumechange
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> oncellchange
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowexit
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowsinserted
        {
            get;
            set;
        }
        string xmlVersion
        {
            get;
            set;
        }
        bool msCapsLockWarningOff
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onpropertychange
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragend
        {
            get;
            set;
        }
        DocumentType doctype
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragover
        {
            get;
            set;
        }
        string bgColor
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragstart
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseup
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondrag
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseover
        {
            get;
            set;
        }
        string linkColor
        {
            get;
            set;
        }
        System.Func<Event, object> onpause
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousedown
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onclick
        {
            get;
            set;
        }
        System.Func<Event, object> onwaiting
        {
            get;
            set;
        }
        System.Func<Event, object> onstop
        {
            get;
            set;
        }
        System.Func<MSSiteModeEvent, object> onmssitemodejumplistitemremoved
        {
            get;
            set;
        }
        HTMLCollection applets
        {
            get;
            set;
        }
        HTMLElement body
        {
            get;
            set;
        }
        string domain
        {
            get;
            set;
        }
        bool xmlStandalone
        {
            get;
            set;
        }
        MSSelection selection
        {
            get;
            set;
        }
        System.Func<Event, object> onstalled
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousemove
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onbeforeeditfocus
        {
            get;
            set;
        }
        System.Func<Event, object> onratechange
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> ondblclick
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> oncontextmenu
        {
            get;
            set;
        }
        System.Func<Event, object> onloadedmetadata
        {
            get;
            set;
        }
        string media
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onplay
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onafterupdate
        {
            get;
            set;
        }
        System.Func<Event, object> onplaying
        {
            get;
            set;
        }
        HTMLCollection images
        {
            get;
            set;
        }
        Location location
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusout
        {
            get;
            set;
        }
        System.Func<Event, object> onselectionchange
        {
            get;
            set;
        }
        System.Func<StorageEvent, object> onstoragecommit
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> ondataavailable
        {
            get;
            set;
        }
        System.Func<Event, object> onreadystatechange
        {
            get;
            set;
        }
        string lastModified
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeypress
        {
            get;
            set;
        }
        System.Func<Event, object> onloadeddata
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onbeforedeactivate
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onactivate
        {
            get;
            set;
        }
        System.Func<Event, object> onselectstart
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocus
        {
            get;
            set;
        }
        string fgColor
        {
            get;
            set;
        }
        System.Func<Event, object> ontimeupdate
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onselect
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondrop
        {
            get;
            set;
        }
        System.Func<Event, object> onended
        {
            get;
            set;
        }
        string compatMode
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onscroll
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onrowenter
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<Event, object> oninput
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerdown
        {
            get;
            set;
        }
        bool msHidden
        {
            get;
            set;
        }
        string msVisibilityState
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturedoubletap
        {
            get;
            set;
        }
        string visibilityState
        {
            get;
            set;
        }
        System.Func<object, object> onmsmanipulationstatechanged
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerhover
        {
            get;
            set;
        }
        System.Func<MSEventObj, object> onmscontentzoom
        {
            get;
            set;
        }
        System.Func<object, object> onmspointermove
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturehold
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturechange
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturestart
        {
            get;
            set;
        }
        System.Func<object, object> onmspointercancel
        {
            get;
            set;
        }
        System.Func<object, object> onmsgestureend
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturetap
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerout
        {
            get;
            set;
        }
        System.Func<object, object> onmsinertiastart
        {
            get;
            set;
        }
        bool msCSSOMElementFloatMetrics
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerover
        {
            get;
            set;
        }
        bool hidden
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerup
        {
            get;
            set;
        }
        bool msFullscreenEnabled
        {
            get;
            set;
        }
        System.Func<object, object> onmsfullscreenerror
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerenter
        {
            get;
            set;
        }
        Element msFullscreenElement
        {
            get;
            set;
        }
        System.Func<object, object> onmsfullscreenchange
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerleave
        {
            get;
            set;
        }
        HTMLElement getElementById(string elementId);
        string queryCommandValue(string commandId);
        Node adoptNode(Node source);
        bool queryCommandIndeterm(string commandId);
        NodeList getElementsByTagNameNS(string namespaceURI, string localName);
        ProcessingInstruction createProcessingInstruction(string target, string data);
        bool execCommand(string commandId, bool showUI = false, object value = null);
        Element elementFromPoint(double x, double y);
        CDATASection createCDATASection(string data);
        string queryCommandText(string commandId);
        void write(params object[] content);
        void updateSettings();
        HTMLElement createElement(string tagName);
        void releaseCapture();
        void writeln(params object[] content);
        Element createElementNS(string namespaceURI, string qualifiedName);
        object open(string url = null, string name = null, string features = null, bool replace = false);
        bool queryCommandSupported(string commandId);
        TreeWalker createTreeWalker(Node root, double whatToShow, NodeFilter filter, bool entityReferenceExpansion);
        Attr createAttributeNS(string namespaceURI, string qualifiedName);
        bool queryCommandEnabled(string commandId);
        void focus();
        void close();
        NodeList getElementsByClassName(string classNames);
        Node importNode(Node importedNode, bool deep);
        Range createRange();
        bool fireEvent(string eventName, object eventObj = null);
        Comment createComment(string data);
        NodeList getElementsByTagName(string name);
        DocumentFragment createDocumentFragment();
        CSSStyleSheet createStyleSheet(string href = null, double index = 0.0);
        NodeList getElementsByName(string elementName);
        bool queryCommandState(string commandId);
        bool hasFocus();
        bool execCommandShowHelp(string commandId);
        Attr createAttribute(string name);
        Text createTextNode(string data);
        NodeIterator createNodeIterator(Node root, double whatToShow, NodeFilter filter, bool entityReferenceExpansion);
        MSEventObj createEventObject(object eventObj = null);
        Selection getSelection();
        NodeList msElementsFromPoint(double x, double y);
        NodeList msElementsFromRect(double left, double top, double width, double height);
        void clear();
        void msExitFullscreen();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface Console
    {
        void info(object message = null, params object[] optionalParams);
        void warn(object message = null, params object[] optionalParams);
        void error(object message = null, params object[] optionalParams);
        void log(object message = null, params object[] optionalParams);
        void profile(string reportName = null);
        void assert(bool test = false, string message = null, params object[] optionalParams);
        bool msIsIndependentlyComposed(Element element);
        void clear();
        void dir(object value = null, params object[] optionalParams);
        void profileEnd();
        void count(string countTitle = null);
        void groupEnd();
        void time(string timerName = null);
        void timeEnd(string timerName = null);
        void trace();
        void group(string groupTitle = null);
        void dirxml(object value);
        void debug(string message = null, params object[] optionalParams);
        void groupCollapsed(string groupTitle = null);
        void select(Element element);
    }
    public partial interface MSEventObj : Event
    {
        string nextPage
        {
            get;
            set;
        }
        double keyCode
        {
            get;
            set;
        }
        Element toElement
        {
            get;
            set;
        }
        object returnValue
        {
            get;
            set;
        }
        string dataFld
        {
            get;
            set;
        }
        double y
        {
            get;
            set;
        }
        DataTransfer dataTransfer
        {
            get;
            set;
        }
        string propertyName
        {
            get;
            set;
        }
        string url
        {
            get;
            set;
        }
        double offsetX
        {
            get;
            set;
        }
        object recordset
        {
            get;
            set;
        }
        double screenX
        {
            get;
            set;
        }
        double buttonID
        {
            get;
            set;
        }
        double wheelDelta
        {
            get;
            set;
        }
        double reason
        {
            get;
            set;
        }
        string origin
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
        object srcFilter
        {
            get;
            set;
        }
        HTMLCollection boundElements
        {
            get;
            set;
        }
        bool cancelBubble
        {
            get;
            set;
        }
        bool altLeft
        {
            get;
            set;
        }
        double behaviorCookie
        {
            get;
            set;
        }
        BookmarkCollection bookmarks
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        bool repeat
        {
            get;
            set;
        }
        Element srcElement
        {
            get;
            set;
        }
        Window source
        {
            get;
            set;
        }
        Element fromElement
        {
            get;
            set;
        }
        double offsetY
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double behaviorPart
        {
            get;
            set;
        }
        string qualifier
        {
            get;
            set;
        }
        bool altKey
        {
            get;
            set;
        }
        bool ctrlKey
        {
            get;
            set;
        }
        double clientY
        {
            get;
            set;
        }
        bool shiftKey
        {
            get;
            set;
        }
        bool shiftLeft
        {
            get;
            set;
        }
        bool contentOverflow
        {
            get;
            set;
        }
        double screenY
        {
            get;
            set;
        }
        bool ctrlLeft
        {
            get;
            set;
        }
        double button
        {
            get;
            set;
        }
        string srcUrn
        {
            get;
            set;
        }
        double clientX
        {
            get;
            set;
        }
        string actionURL
        {
            get;
            set;
        }
        object getAttribute(string strAttributeName, double lFlags = 0.0);
        void setAttribute(string strAttributeName, object AttributeValue, double lFlags = 0.0);
        bool removeAttribute(string strAttributeName, double lFlags = 0.0);
    }
    public partial interface HTMLCanvasElement : HTMLElement
    {
        double width
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        object getContext(string contextId, params object[] args);
        string toDataURL(string type = null, params object[] args);
        Blob msToBlob();
    }
    public partial interface Window : EventTarget, MSEventAttachmentTarget, WindowLocalStorage, MSWindowExtensions, WindowSessionStorage, WindowTimers, WindowBase64, IDBEnvironment, WindowConsole, GlobalEventHandlers
    {
        System.Func<DragEvent, object> ondragend
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeydown
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragover
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeyup
        {
            get;
            set;
        }
        System.Func<Event, object> onreset
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseup
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragstart
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondrag
        {
            get;
            set;
        }
        double screenX
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseover
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragleave
        {
            get;
            set;
        }
        History history
        {
            get;
            set;
        }
        double pageXOffset
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        System.Func<Event, object> onafterprint
        {
            get;
            set;
        }
        System.Func<Event, object> onpause
        {
            get;
            set;
        }
        System.Func<Event, object> onbeforeprint
        {
            get;
            set;
        }
        Window top
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousedown
        {
            get;
            set;
        }
        System.Func<Event, object> onseeked
        {
            get;
            set;
        }
        Window opener
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onclick
        {
            get;
            set;
        }
        double innerHeight
        {
            get;
            set;
        }
        System.Func<Event, object> onwaiting
        {
            get;
            set;
        }
        System.Func<Event, object> ononline
        {
            get;
            set;
        }
        System.Func<Event, object> ondurationchange
        {
            get;
            set;
        }
        Window frames
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onblur
        {
            get;
            set;
        }
        System.Func<Event, object> onemptied
        {
            get;
            set;
        }
        System.Func<Event, object> onseeking
        {
            get;
            set;
        }
        System.Func<Event, object> oncanplay
        {
            get;
            set;
        }
        double outerWidth
        {
            get;
            set;
        }
        System.Func<Event, object> onstalled
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousemove
        {
            get;
            set;
        }
        double innerWidth
        {
            get;
            set;
        }
        System.Func<Event, object> onoffline
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        Screen screen
        {
            get;
            set;
        }
        System.Func<BeforeUnloadEvent, object> onbeforeunload
        {
            get;
            set;
        }
        System.Func<Event, object> onratechange
        {
            get;
            set;
        }
        System.Func<StorageEvent, object> onstorage
        {
            get;
            set;
        }
        System.Func<Event, object> onloadstart
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondragenter
        {
            get;
            set;
        }
        System.Func<Event, object> onsubmit
        {
            get;
            set;
        }
        Window self
        {
            get;
            set;
        }
        Document document
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> ondblclick
        {
            get;
            set;
        }
        double pageYOffset
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> oncontextmenu
        {
            get;
            set;
        }
        System.Func<Event, object> onchange
        {
            get;
            set;
        }
        System.Func<Event, object> onloadedmetadata
        {
            get;
            set;
        }
        System.Func<Event, object> onplay
        {
            get;
            set;
        }
        ErrorEventHandler onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onplaying
        {
            get;
            set;
        }
        Window parent
        {
            get;
            set;
        }
        Location location
        {
            get;
            set;
        }
        System.Func<Event, object> oncanplaythrough
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        System.Func<Event, object> onreadystatechange
        {
            get;
            set;
        }
        double outerHeight
        {
            get;
            set;
        }
        System.Func<KeyboardEvent, object> onkeypress
        {
            get;
            set;
        }
        Element frameElement
        {
            get;
            set;
        }
        System.Func<Event, object> onloadeddata
        {
            get;
            set;
        }
        System.Func<Event, object> onsuspend
        {
            get;
            set;
        }
        Window window
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocus
        {
            get;
            set;
        }
        System.Func<MessageEvent, object> onmessage
        {
            get;
            set;
        }
        System.Func<Event, object> ontimeupdate
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onresize
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onselect
        {
            get;
            set;
        }
        Navigator navigator
        {
            get;
            set;
        }
        StyleMedia styleMedia
        {
            get;
            set;
        }
        System.Func<DragEvent, object> ondrop
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseout
        {
            get;
            set;
        }
        System.Func<Event, object> onended
        {
            get;
            set;
        }
        System.Func<Event, object> onhashchange
        {
            get;
            set;
        }
        System.Func<Event, object> onunload
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onscroll
        {
            get;
            set;
        }
        double screenY
        {
            get;
            set;
        }
        System.Func<MouseWheelEvent, object> onmousewheel
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<Event, object> onvolumechange
        {
            get;
            set;
        }
        System.Func<Event, object> oninput
        {
            get;
            set;
        }
        Performance performance
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerdown
        {
            get;
            set;
        }
        double animationStartTime
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturedoubletap
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerhover
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturehold
        {
            get;
            set;
        }
        System.Func<object, object> onmspointermove
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturechange
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturestart
        {
            get;
            set;
        }
        System.Func<object, object> onmspointercancel
        {
            get;
            set;
        }
        System.Func<object, object> onmsgestureend
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturetap
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerout
        {
            get;
            set;
        }
        double msAnimationStartTime
        {
            get;
            set;
        }
        ApplicationCache applicationCache
        {
            get;
            set;
        }
        System.Func<object, object> onmsinertiastart
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerover
        {
            get;
            set;
        }
        System.Func<PopStateEvent, object> onpopstate
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerup
        {
            get;
            set;
        }
        System.Func<PageTransitionEvent, object> onpageshow
        {
            get;
            set;
        }
        System.Func<DeviceMotionEvent, object> ondevicemotion
        {
            get;
            set;
        }
        double devicePixelRatio
        {
            get;
            set;
        }
        Crypto msCrypto
        {
            get;
            set;
        }
        System.Func<DeviceOrientationEvent, object> ondeviceorientation
        {
            get;
            set;
        }
        string doNotTrack
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerenter
        {
            get;
            set;
        }
        System.Func<PageTransitionEvent, object> onpagehide
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerleave
        {
            get;
            set;
        }
        void alert(object message = null);
        void scroll(double x = 0.0, double y = 0.0);
        void focus();
        void scrollTo(double x = 0.0, double y = 0.0);
        void print();
        string prompt(string message = null, string _default = null);
        string.ToString();
        Window open(string url = null, string target = null, string features = null, bool replace = false);
        void scrollBy(double x = 0.0, double y = 0.0);
        bool confirm(string message = null);
        void close();
        void postMessage(object message, string targetOrigin, object ports = null);
        object showModalDialog(string url = null, object argument = null, object options = null);
        void blur();
        Selection getSelection();
        CSSStyleDeclaration getComputedStyle(Element elt, string pseudoElt = null);
        void msCancelRequestAnimationFrame(double handle);
        MediaQueryList matchMedia(string mediaQuery);
        void cancelAnimationFrame(double handle);
        bool msIsStaticHTML(string html);
        MediaQueryList msMatchMedia(string mediaQuery);
        double requestAnimationFrame(FrameRequestCallback callback);
        double msRequestAnimationFrame(FrameRequestCallback callback);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface NavigatorID
    {
        string appVersion
        {
            get;
            set;
        }
        string appName
        {
            get;
            set;
        }
        string userAgent
        {
            get;
            set;
        }
        string platform
        {
            get;
            set;
        }
        string product
        {
            get;
            set;
        }
        string vendor
        {
            get;
            set;
        }
    }
    public partial interface HTMLTableElement : HTMLElement, MSDataBindingTableExtensions, MSDataBindingExtensions, DOML2DeprecatedBackgroundStyle, DOML2DeprecatedBackgroundColorStyle
    {
        string width
        {
            get;
            set;
        }
        object borderColorLight
        {
            get;
            set;
        }
        string cellSpacing
        {
            get;
            set;
        }
        HTMLTableSectionElement tFoot
        {
            get;
            set;
        }
        string frame
        {
            get;
            set;
        }
        object borderColor
        {
            get;
            set;
        }
        HTMLCollection rows
        {
            get;
            set;
        }
        string rules
        {
            get;
            set;
        }
        double cols
        {
            get;
            set;
        }
        string summary
        {
            get;
            set;
        }
        HTMLTableCaptionElement caption
        {
            get;
            set;
        }
        HTMLCollection tBodies
        {
            get;
            set;
        }
        HTMLTableSectionElement tHead
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        HTMLCollection cells
        {
            get;
            set;
        }
        object height
        {
            get;
            set;
        }
        string cellPadding
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        object borderColorDark
        {
            get;
            set;
        }
        void deleteRow(double index = 0.0);
        HTMLElement createTBody();
        void deleteCaption();
        HTMLElement insertRow(double index = 0.0);
        void deleteTFoot();
        HTMLElement createTHead();
        void deleteTHead();
        HTMLElement createCaption();
        object moveRow(double indexFrom = 0.0, double indexTo = 0.0);
        HTMLElement createTFoot();
    }
    public partial interface TreeWalker
    {
        double whatToShow
        {
            get;
            set;
        }
        NodeFilter filter
        {
            get;
            set;
        }
        Node root
        {
            get;
            set;
        }
        Node currentNode
        {
            get;
            set;
        }
        bool expandEntityReferences
        {
            get;
            set;
        }
        Node previousSibling();
        Node lastChild();
        Node nextSibling();
        Node nextNode();
        Node parentNode();
        Node firstChild();
        Node previousNode();
    }
    public partial interface GetSVGDocument
    {
        Document getSVGDocument();
    }
    public partial interface SVGPathSegCurvetoQuadraticRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double y1
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double x1
        {
            get;
            set;
        }
    }
    public partial interface Performance
    {
        PerformanceNavigation navigation
        {
            get;
            set;
        }
        PerformanceTiming timing
        {
            get;
            set;
        }
        object getEntriesByType(string entryType);
        object toJSON();
        object getMeasures(string measureName = null);
        void clearMarks(string markName = null);
        object getMarks(string markName = null);
        void clearResourceTimings();
        void mark(string markName);
        void measure(string measureName, string startMarkName = null, string endMarkName = null);
        object getEntriesByName(string name, string entryType = null);
        object getEntries();
        void clearMeasures(string measureName = null);
        void setResourceTimingBufferSize(double maxSize);
        double now();
    }
    public partial interface MSDataBindingTableExtensions
    {
        double dataPageSize
        {
            get;
            set;
        }
        void nextPage();
        void firstPage();
        void refresh();
        void previousPage();
        void lastPage();
    }
    public partial interface CompositionEvent : UIEvent
    {
        string data
        {
            get;
            set;
        }
        string locale
        {
            get;
            set;
        }
        void initCompositionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, string locale);
    }
    public partial interface WindowTimers : WindowTimersExtension
    {
        void clearTimeout(double handle);
        double setTimeout(object handler, object timeout = null, params object[] args);
        void clearInterval(double handle);
        double setInterval(object handler, object timeout = null, params object[] args);
    }
    public partial interface SVGMarkerElement : SVGElement, SVGStylable, SVGLangSpace, SVGFitToViewBox, SVGExternalResourcesRequired
    {
        SVGAnimatedEnumeration orientType
        {
            get;
            set;
        }
        SVGAnimatedEnumeration markerUnits
        {
            get;
            set;
        }
        SVGAnimatedLength markerWidth
        {
            get;
            set;
        }
        SVGAnimatedLength markerHeight
        {
            get;
            set;
        }
        SVGAnimatedAngle orientAngle
        {
            get;
            set;
        }
        SVGAnimatedLength refY
        {
            get;
            set;
        }
        SVGAnimatedLength refX
        {
            get;
            set;
        }
        void setOrientToAngle(SVGAngle angle);
        void setOrientToAuto();
        double SVG_MARKER_ORIENT_UNKNOWN
        {
            get;
            set;
        }
        double SVG_MARKER_ORIENT_ANGLE
        {
            get;
            set;
        }
        double SVG_MARKERUNITS_UNKNOWN
        {
            get;
            set;
        }
        double SVG_MARKERUNITS_STROKEWIDTH
        {
            get;
            set;
        }
        double SVG_MARKER_ORIENT_AUTO
        {
            get;
            set;
        }
        double SVG_MARKERUNITS_USERSPACEONUSE
        {
            get;
            set;
        }
    }
    public partial interface CSSStyleDeclaration
    {
        string backgroundAttachment
        {
            get;
            set;
        }
        string visibility
        {
            get;
            set;
        }
        string textAlignLast
        {
            get;
            set;
        }
        string borderRightStyle
        {
            get;
            set;
        }
        string counterIncrement
        {
            get;
            set;
        }
        string orphans
        {
            get;
            set;
        }
        string cssText
        {
            get;
            set;
        }
        string borderStyle
        {
            get;
            set;
        }
        string pointerEvents
        {
            get;
            set;
        }
        string borderTopColor
        {
            get;
            set;
        }
        string markerEnd
        {
            get;
            set;
        }
        string textIndent
        {
            get;
            set;
        }
        string listStyleImage
        {
            get;
            set;
        }
        string cursor
        {
            get;
            set;
        }
        string listStylePosition
        {
            get;
            set;
        }
        string wordWrap
        {
            get;
            set;
        }
        string borderTopStyle
        {
            get;
            set;
        }
        string alignmentBaseline
        {
            get;
            set;
        }
        string opacity
        {
            get;
            set;
        }
        string direction
        {
            get;
            set;
        }
        string strokeMiterlimit
        {
            get;
            set;
        }
        string maxWidth
        {
            get;
            set;
        }
        string color
        {
            get;
            set;
        }
        string clip
        {
            get;
            set;
        }
        string borderRightWidth
        {
            get;
            set;
        }
        string verticalAlign
        {
            get;
            set;
        }
        string overflow
        {
            get;
            set;
        }
        string mask
        {
            get;
            set;
        }
        string borderLeftStyle
        {
            get;
            set;
        }
        string emptyCells
        {
            get;
            set;
        }
        string stopOpacity
        {
            get;
            set;
        }
        string paddingRight
        {
            get;
            set;
        }
        CSSRule parentRule
        {
            get;
            set;
        }
        string background
        {
            get;
            set;
        }
        string boxSizing
        {
            get;
            set;
        }
        string textJustify
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        string paddingTop
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        string right
        {
            get;
            set;
        }
        string baselineShift
        {
            get;
            set;
        }
        string borderLeft
        {
            get;
            set;
        }
        string widows
        {
            get;
            set;
        }
        string lineHeight
        {
            get;
            set;
        }
        string left
        {
            get;
            set;
        }
        string textUnderlinePosition
        {
            get;
            set;
        }
        string glyphOrientationHorizontal
        {
            get;
            set;
        }
        string display
        {
            get;
            set;
        }
        string textAnchor
        {
            get;
            set;
        }
        string cssFloat
        {
            get;
            set;
        }
        string strokeDasharray
        {
            get;
            set;
        }
        string rubyAlign
        {
            get;
            set;
        }
        string fontSizeAdjust
        {
            get;
            set;
        }
        string borderLeftColor
        {
            get;
            set;
        }
        string backgroundImage
        {
            get;
            set;
        }
        string listStyleType
        {
            get;
            set;
        }
        string strokeWidth
        {
            get;
            set;
        }
        string textOverflow
        {
            get;
            set;
        }
        string fillRule
        {
            get;
            set;
        }
        string borderBottomColor
        {
            get;
            set;
        }
        string zIndex
        {
            get;
            set;
        }
        string position
        {
            get;
            set;
        }
        string listStyle
        {
            get;
            set;
        }
        string msTransformOrigin
        {
            get;
            set;
        }
        string dominantBaseline
        {
            get;
            set;
        }
        string overflowY
        {
            get;
            set;
        }
        string fill
        {
            get;
            set;
        }
        string captionSide
        {
            get;
            set;
        }
        string borderCollapse
        {
            get;
            set;
        }
        string boxShadow
        {
            get;
            set;
        }
        string quotes
        {
            get;
            set;
        }
        string tableLayout
        {
            get;
            set;
        }
        string unicodeBidi
        {
            get;
            set;
        }
        string borderBottomWidth
        {
            get;
            set;
        }
        string backgroundSize
        {
            get;
            set;
        }
        string textDecoration
        {
            get;
            set;
        }
        string strokeDashoffset
        {
            get;
            set;
        }
        string fontSize
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        string pageBreakBefore
        {
            get;
            set;
        }
        string borderTopRightRadius
        {
            get;
            set;
        }
        string msTransform
        {
            get;
            set;
        }
        string borderBottomLeftRadius
        {
            get;
            set;
        }
        string textTransform
        {
            get;
            set;
        }
        string rubyPosition
        {
            get;
            set;
        }
        string strokeLinejoin
        {
            get;
            set;
        }
        string clipPath
        {
            get;
            set;
        }
        string borderRightColor
        {
            get;
            set;
        }
        string fontFamily
        {
            get;
            set;
        }
        string clear
        {
            get;
            set;
        }
        string content
        {
            get;
            set;
        }
        string backgroundClip
        {
            get;
            set;
        }
        string marginBottom
        {
            get;
            set;
        }
        string counterReset
        {
            get;
            set;
        }
        string outlineWidth
        {
            get;
            set;
        }
        string marginRight
        {
            get;
            set;
        }
        string paddingLeft
        {
            get;
            set;
        }
        string borderBottom
        {
            get;
            set;
        }
        string wordBreak
        {
            get;
            set;
        }
        string marginTop
        {
            get;
            set;
        }
        string top
        {
            get;
            set;
        }
        string fontWeight
        {
            get;
            set;
        }
        string borderRight
        {
            get;
            set;
        }
        string width
        {
            get;
            set;
        }
        string kerning
        {
            get;
            set;
        }
        string pageBreakAfter
        {
            get;
            set;
        }
        string borderBottomStyle
        {
            get;
            set;
        }
        string fontStretch
        {
            get;
            set;
        }
        string padding
        {
            get;
            set;
        }
        string strokeOpacity
        {
            get;
            set;
        }
        string markerStart
        {
            get;
            set;
        }
        string bottom
        {
            get;
            set;
        }
        string borderLeftWidth
        {
            get;
            set;
        }
        string clipRule
        {
            get;
            set;
        }
        string backgroundPosition
        {
            get;
            set;
        }
        string backgroundColor
        {
            get;
            set;
        }
        string pageBreakInside
        {
            get;
            set;
        }
        string backgroundOrigin
        {
            get;
            set;
        }
        string strokeLinecap
        {
            get;
            set;
        }
        string borderTopWidth
        {
            get;
            set;
        }
        string outlineStyle
        {
            get;
            set;
        }
        string borderTop
        {
            get;
            set;
        }
        string outlineColor
        {
            get;
            set;
        }
        string paddingBottom
        {
            get;
            set;
        }
        string marginLeft
        {
            get;
            set;
        }
        string font
        {
            get;
            set;
        }
        string outline
        {
            get;
            set;
        }
        string wordSpacing
        {
            get;
            set;
        }
        string maxHeight
        {
            get;
            set;
        }
        string fillOpacity
        {
            get;
            set;
        }
        string letterSpacing
        {
            get;
            set;
        }
        string borderSpacing
        {
            get;
            set;
        }
        string backgroundRepeat
        {
            get;
            set;
        }
        string borderRadius
        {
            get;
            set;
        }
        string borderWidth
        {
            get;
            set;
        }
        string borderBottomRightRadius
        {
            get;
            set;
        }
        string whiteSpace
        {
            get;
            set;
        }
        string fontStyle
        {
            get;
            set;
        }
        string minWidth
        {
            get;
            set;
        }
        string stopColor
        {
            get;
            set;
        }
        string borderTopLeftRadius
        {
            get;
            set;
        }
        string borderColor
        {
            get;
            set;
        }
        string marker
        {
            get;
            set;
        }
        string glyphOrientationVertical
        {
            get;
            set;
        }
        string markerMid
        {
            get;
            set;
        }
        string fontVariant
        {
            get;
            set;
        }
        string minHeight
        {
            get;
            set;
        }
        string stroke
        {
            get;
            set;
        }
        string rubyOverhang
        {
            get;
            set;
        }
        string overflowX
        {
            get;
            set;
        }
        string textAlign
        {
            get;
            set;
        }
        string margin
        {
            get;
            set;
        }
        string animationFillMode
        {
            get;
            set;
        }
        string floodColor
        {
            get;
            set;
        }
        string animationIterationCount
        {
            get;
            set;
        }
        string textShadow
        {
            get;
            set;
        }
        string backfaceVisibility
        {
            get;
            set;
        }
        string msAnimationIterationCount
        {
            get;
            set;
        }
        string animationDelay
        {
            get;
            set;
        }
        string animationTimingFunction
        {
            get;
            set;
        }
        object columnWidth
        {
            get;
            set;
        }
        string msScrollSnapX
        {
            get;
            set;
        }
        object columnRuleColor
        {
            get;
            set;
        }
        object columnRuleWidth
        {
            get;
            set;
        }
        string transitionDelay
        {
            get;
            set;
        }
        string transition
        {
            get;
            set;
        }
        string msFlowFrom
        {
            get;
            set;
        }
        string msScrollSnapType
        {
            get;
            set;
        }
        string msContentZoomSnapType
        {
            get;
            set;
        }
        string msGridColumns
        {
            get;
            set;
        }
        string msAnimationName
        {
            get;
            set;
        }
        string msGridRowAlign
        {
            get;
            set;
        }
        string msContentZoomChaining
        {
            get;
            set;
        }
        object msGridColumn
        {
            get;
            set;
        }
        object msHyphenateLimitZone
        {
            get;
            set;
        }
        string msScrollRails
        {
            get;
            set;
        }
        string msAnimationDelay
        {
            get;
            set;
        }
        string enableBackground
        {
            get;
            set;
        }
        string msWrapThrough
        {
            get;
            set;
        }
        string columnRuleStyle
        {
            get;
            set;
        }
        string msAnimation
        {
            get;
            set;
        }
        string msFlexFlow
        {
            get;
            set;
        }
        string msScrollSnapY
        {
            get;
            set;
        }
        object msHyphenateLimitLines
        {
            get;
            set;
        }
        string msTouchAction
        {
            get;
            set;
        }
        string msScrollLimit
        {
            get;
            set;
        }
        string animation
        {
            get;
            set;
        }
        string transform
        {
            get;
            set;
        }
        string filter
        {
            get;
            set;
        }
        string colorInterpolationFilters
        {
            get;
            set;
        }
        string transitionTimingFunction
        {
            get;
            set;
        }
        string msBackfaceVisibility
        {
            get;
            set;
        }
        string animationPlayState
        {
            get;
            set;
        }
        string transformOrigin
        {
            get;
            set;
        }
        object msScrollLimitYMin
        {
            get;
            set;
        }
        string msFontFeatureSettings
        {
            get;
            set;
        }
        object msContentZoomLimitMin
        {
            get;
            set;
        }
        object columnGap
        {
            get;
            set;
        }
        string transitionProperty
        {
            get;
            set;
        }
        string msAnimationDuration
        {
            get;
            set;
        }
        string msAnimationFillMode
        {
            get;
            set;
        }
        string msFlexDirection
        {
            get;
            set;
        }
        string msTransitionDuration
        {
            get;
            set;
        }
        string fontFeatureSettings
        {
            get;
            set;
        }
        string breakBefore
        {
            get;
            set;
        }
        string msFlexWrap
        {
            get;
            set;
        }
        string perspective
        {
            get;
            set;
        }
        string msFlowInto
        {
            get;
            set;
        }
        string msTransformStyle
        {
            get;
            set;
        }
        string msScrollTranslation
        {
            get;
            set;
        }
        string msTransitionProperty
        {
            get;
            set;
        }
        string msUserSelect
        {
            get;
            set;
        }
        string msOverflowStyle
        {
            get;
            set;
        }
        string msScrollSnapPointsY
        {
            get;
            set;
        }
        string animationDirection
        {
            get;
            set;
        }
        string animationDuration
        {
            get;
            set;
        }
        string msFlex
        {
            get;
            set;
        }
        string msTransitionTimingFunction
        {
            get;
            set;
        }
        string animationName
        {
            get;
            set;
        }
        string columnRule
        {
            get;
            set;
        }
        object msGridColumnSpan
        {
            get;
            set;
        }
        string msFlexNegative
        {
            get;
            set;
        }
        string columnFill
        {
            get;
            set;
        }
        object msGridRow
        {
            get;
            set;
        }
        string msFlexOrder
        {
            get;
            set;
        }
        string msFlexItemAlign
        {
            get;
            set;
        }
        string msFlexPositive
        {
            get;
            set;
        }
        object msContentZoomLimitMax
        {
            get;
            set;
        }
        object msScrollLimitYMax
        {
            get;
            set;
        }
        string msGridColumnAlign
        {
            get;
            set;
        }
        string perspectiveOrigin
        {
            get;
            set;
        }
        string lightingColor
        {
            get;
            set;
        }
        string columns
        {
            get;
            set;
        }
        string msScrollChaining
        {
            get;
            set;
        }
        string msHyphenateLimitChars
        {
            get;
            set;
        }
        string msTouchSelect
        {
            get;
            set;
        }
        string floodOpacity
        {
            get;
            set;
        }
        string msAnimationDirection
        {
            get;
            set;
        }
        string msAnimationPlayState
        {
            get;
            set;
        }
        string columnSpan
        {
            get;
            set;
        }
        string msContentZooming
        {
            get;
            set;
        }
        string msPerspective
        {
            get;
            set;
        }
        string msFlexPack
        {
            get;
            set;
        }
        string msScrollSnapPointsX
        {
            get;
            set;
        }
        string msContentZoomSnapPoints
        {
            get;
            set;
        }
        object msGridRowSpan
        {
            get;
            set;
        }
        string msContentZoomSnap
        {
            get;
            set;
        }
        object msScrollLimitXMin
        {
            get;
            set;
        }
        string breakInside
        {
            get;
            set;
        }
        string msHighContrastAdjust
        {
            get;
            set;
        }
        string msFlexLinePack
        {
            get;
            set;
        }
        string msGridRows
        {
            get;
            set;
        }
        string transitionDuration
        {
            get;
            set;
        }
        string msHyphens
        {
            get;
            set;
        }
        string breakAfter
        {
            get;
            set;
        }
        string msTransition
        {
            get;
            set;
        }
        string msPerspectiveOrigin
        {
            get;
            set;
        }
        string msContentZoomLimit
        {
            get;
            set;
        }
        object msScrollLimitXMax
        {
            get;
            set;
        }
        string msFlexAlign
        {
            get;
            set;
        }
        object msWrapMargin
        {
            get;
            set;
        }
        object columnCount
        {
            get;
            set;
        }
        string msAnimationTimingFunction
        {
            get;
            set;
        }
        string msTransitionDelay
        {
            get;
            set;
        }
        string transformStyle
        {
            get;
            set;
        }
        string msWrapFlow
        {
            get;
            set;
        }
        string msFlexPreferredSize
        {
            get;
            set;
        }
        string alignItems
        {
            get;
            set;
        }
        string borderImageSource
        {
            get;
            set;
        }
        string flexBasis
        {
            get;
            set;
        }
        string borderImageWidth
        {
            get;
            set;
        }
        string borderImageRepeat
        {
            get;
            set;
        }
        string order
        {
            get;
            set;
        }
        string flex
        {
            get;
            set;
        }
        string alignContent
        {
            get;
            set;
        }
        string msImeAlign
        {
            get;
            set;
        }
        string flexShrink
        {
            get;
            set;
        }
        string flexGrow
        {
            get;
            set;
        }
        string borderImageSlice
        {
            get;
            set;
        }
        string flexWrap
        {
            get;
            set;
        }
        string borderImageOutset
        {
            get;
            set;
        }
        string flexDirection
        {
            get;
            set;
        }
        string touchAction
        {
            get;
            set;
        }
        string flexFlow
        {
            get;
            set;
        }
        string borderImage
        {
            get;
            set;
        }
        string justifyContent
        {
            get;
            set;
        }
        string alignSelf
        {
            get;
            set;
        }
        string msTextCombineHorizontal
        {
            get;
            set;
        }
        string getPropertyPriority(string propertyName);
        string getPropertyValue(string propertyName);
        string removeProperty(string propertyName);
        string item(double index);
        string this[double index]
        {
            get;
            set;
        }
        void setProperty(string propertyName, string value, string priority = null);
    }
    public partial interface SVGGElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired { }
    public partial interface MSStyleCSSProperties : MSCSSProperties
    {
        double pixelWidth
        {
            get;
            set;
        }
        double posHeight
        {
            get;
            set;
        }
        double posLeft
        {
            get;
            set;
        }
        double pixelTop
        {
            get;
            set;
        }
        double pixelBottom
        {
            get;
            set;
        }
        bool textDecorationNone
        {
            get;
            set;
        }
        double pixelLeft
        {
            get;
            set;
        }
        double posTop
        {
            get;
            set;
        }
        double posBottom
        {
            get;
            set;
        }
        bool textDecorationOverline
        {
            get;
            set;
        }
        double posWidth
        {
            get;
            set;
        }
        bool textDecorationLineThrough
        {
            get;
            set;
        }
        double pixelHeight
        {
            get;
            set;
        }
        bool textDecorationBlink
        {
            get;
            set;
        }
        double posRight
        {
            get;
            set;
        }
        double pixelRight
        {
            get;
            set;
        }
        bool textDecorationUnderline
        {
            get;
            set;
        }
    }
    public partial interface Navigator : NavigatorID, NavigatorOnLine, NavigatorContentUtils, MSNavigatorExtensions, NavigatorGeolocation, MSNavigatorDoNotTrack, NavigatorStorageUtils, MSFileSaver
    {
        double msMaxTouchPoints
        {
            get;
            set;
        }
        bool msPointerEnabled
        {
            get;
            set;
        }
        bool msManipulationViewsEnabled
        {
            get;
            set;
        }
        bool pointerEnabled
        {
            get;
            set;
        }
        double maxTouchPoints
        {
            get;
            set;
        }
        void msLaunchUri(string uri, MSLaunchUriCallback successCallback = null, MSLaunchUriCallback noHandlerCallback = null);
    }
    public partial interface SVGPathSegCurvetoCubicSmoothAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double y2
        {
            get;
            set;
        }
    }
    public partial interface SVGZoomEvent : UIEvent
    {
        SVGRect zoomRectScreen
        {
            get;
            set;
        }
        double previousScale
        {
            get;
            set;
        }
        double newScale
        {
            get;
            set;
        }
        SVGPoint previousTranslate
        {
            get;
            set;
        }
        SVGPoint newTranslate
        {
            get;
            set;
        }
    }
    public partial interface NodeSelector
    {
        NodeList querySelectorAll(string selectors);
        Element querySelector(string selectors);
    }
    public partial interface HTMLTableDataCellElement : HTMLTableCellElement { }
    public partial interface HTMLBaseElement : HTMLElement
    {
        string target
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
    }
    public partial interface ClientRect
    {
        double left
        {
            get;
            set;
        }
        double width
        {
            get;
            set;
        }
        double right
        {
            get;
            set;
        }
        double top
        {
            get;
            set;
        }
        double bottom
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
    }
    public delegate void PositionErrorCallback(PositionError error);
    public partial interface DOMImplementation
    {
        DocumentType createDocumentType(string qualifiedName, string publicId, string systemId);
        Document createDocument(string namespaceURI, string qualifiedName, DocumentType doctype);
        bool hasFeature(string feature, string version = null);
        Document createHTMLDocument(string title);
    }
    public partial interface SVGUnitTypes
    {
        double SVG_UNIT_TYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_UNIT_TYPE_OBJECTBOUNDINGBOX
        {
            get;
            set;
        }
        double SVG_UNIT_TYPE_USERSPACEONUSE
        {
            get;
            set;
        }
    }
    public partial interface Element : Node, NodeSelector, ElementTraversal, GlobalEventHandlers
    {
        double scrollTop
        {
            get;
            set;
        }
        double clientLeft
        {
            get;
            set;
        }
        double scrollLeft
        {
            get;
            set;
        }
        string tagName
        {
            get;
            set;
        }
        double clientWidth
        {
            get;
            set;
        }
        double scrollWidth
        {
            get;
            set;
        }
        double clientHeight
        {
            get;
            set;
        }
        double clientTop
        {
            get;
            set;
        }
        double scrollHeight
        {
            get;
            set;
        }
        string msRegionOverflow
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerdown
        {
            get;
            set;
        }
        System.Func<object, object> onmsgotpointercapture
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturedoubletap
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerhover
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturehold
        {
            get;
            set;
        }
        System.Func<object, object> onmspointermove
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturechange
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturestart
        {
            get;
            set;
        }
        System.Func<object, object> onmspointercancel
        {
            get;
            set;
        }
        System.Func<object, object> onmsgestureend
        {
            get;
            set;
        }
        System.Func<object, object> onmsgesturetap
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerout
        {
            get;
            set;
        }
        System.Func<object, object> onmsinertiastart
        {
            get;
            set;
        }
        System.Func<object, object> onmslostpointercapture
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerover
        {
            get;
            set;
        }
        double msContentZoomFactor
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerup
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onlostpointercapture
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerenter
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> ongotpointercapture
        {
            get;
            set;
        }
        System.Func<object, object> onmspointerleave
        {
            get;
            set;
        }
        string getAttribute(string name = null);
        NodeList getElementsByTagNameNS(string namespaceURI, string localName);
        bool hasAttributeNS(string namespaceURI, string localName);
        ClientRect getBoundingClientRect();
        string getAttributeNS(string namespaceURI, string localName);
        Attr getAttributeNodeNS(string namespaceURI, string localName);
        Attr setAttributeNodeNS(Attr newAttr);
        bool msMatchesSelector(string selectors);
        bool hasAttribute(string name);
        void removeAttribute(string name = null);
        void setAttributeNS(string namespaceURI, string qualifiedName, string value);
        Attr getAttributeNode(string name);
        bool fireEvent(string eventName, object eventObj = null);
        NodeList getElementsByTagName(string name);
        ClientRectList getClientRects();
        Attr setAttributeNode(Attr newAttr);
        Attr removeAttributeNode(Attr oldAttr);
        void setAttribute(string name = null, string value = null);
        void removeAttributeNS(string namespaceURI, string localName);
        MSRangeCollection msGetRegionContent();
        void msReleasePointerCapture(double pointerId);
        void msSetPointerCapture(double pointerId);
        void msZoomTo(MsZoomToOptions args);
        void setPointerCapture(double pointerId);
        ClientRect msGetUntransformedBounds();
        void releasePointerCapture(double pointerId);
        void msRequestFullscreen();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface HTMLNextIdElement : HTMLElement
    {
        string n
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegMovetoRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
    }
    public partial interface SVGLineElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength y1
        {
            get;
            set;
        }
        SVGAnimatedLength x2
        {
            get;
            set;
        }
        SVGAnimatedLength x1
        {
            get;
            set;
        }
        SVGAnimatedLength y2
        {
            get;
            set;
        }
    }
    public partial interface HTMLParagraphElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        string align
        {
            get;
            set;
        }
    }
    public partial interface HTMLAreasCollection : HTMLCollection
    {
        void remove(double index = 0.0);
        void add(HTMLElement element, object before = null);
    }
    public partial interface SVGDescElement : SVGElement, SVGStylable, SVGLangSpace { }
    public partial interface Node : EventTarget
    {
        double nodeType
        {
            get;
            set;
        }
        Node previousSibling
        {
            get;
            set;
        }
        string localName
        {
            get;
            set;
        }
        string namespaceURI
        {
            get;
            set;
        }
        string textContent
        {
            get;
            set;
        }
        Node parentNode
        {
            get;
            set;
        }
        Node nextSibling
        {
            get;
            set;
        }
        string nodeValue
        {
            get;
            set;
        }
        Node lastChild
        {
            get;
            set;
        }
        NodeList childNodes
        {
            get;
            set;
        }
        string nodeName
        {
            get;
            set;
        }
        Document ownerDocument
        {
            get;
            set;
        }
        NamedNodeMap attributes
        {
            get;
            set;
        }
        Node firstChild
        {
            get;
            set;
        }
        string prefix
        {
            get;
            set;
        }
        Node removeChild(Node oldChild);
        Node appendChild(Node newChild);
        bool isSupported(string feature, string version);
        bool isEqualNode(Node arg);
        string lookupPrefix(string namespaceURI);
        bool isDefaultNamespace(string namespaceURI);
        double compareDocumentPosition(Node other);
        void normalize();
        bool isSameNode(Node other);
        bool hasAttributes();
        string lookupNamespaceURI(string prefix);
        Node cloneNode(bool deep = false);
        bool hasChildNodes();
        Node replaceChild(Node newChild, Node oldChild);
        Node insertBefore(Node newChild, Node refChild = null);
        double ENTITY_REFERENCE_NODE
        {
            get;
            set;
        }
        double ATTRIBUTE_NODE
        {
            get;
            set;
        }
        double DOCUMENT_FRAGMENT_NODE
        {
            get;
            set;
        }
        double TEXT_NODE
        {
            get;
            set;
        }
        double ELEMENT_NODE
        {
            get;
            set;
        }
        double COMMENT_NODE
        {
            get;
            set;
        }
        double DOCUMENT_POSITION_DISCONNECTED
        {
            get;
            set;
        }
        double DOCUMENT_POSITION_CONTAINED_BY
        {
            get;
            set;
        }
        double DOCUMENT_POSITION_CONTAINS
        {
            get;
            set;
        }
        double DOCUMENT_TYPE_NODE
        {
            get;
            set;
        }
        double DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC
        {
            get;
            set;
        }
        double DOCUMENT_NODE
        {
            get;
            set;
        }
        double ENTITY_NODE
        {
            get;
            set;
        }
        double PROCESSING_INSTRUCTION_NODE
        {
            get;
            set;
        }
        double CDATA_SECTION_NODE
        {
            get;
            set;
        }
        double NOTATION_NODE
        {
            get;
            set;
        }
        double DOCUMENT_POSITION_FOLLOWING
        {
            get;
            set;
        }
        double DOCUMENT_POSITION_PRECEDING
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegCurvetoQuadraticSmoothRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedListSpaceReduction
    {
        bool compact
        {
            get;
            set;
        }
    }
    public partial interface MSScriptHost { }
    public partial interface SVGClipPathElement : SVGElement, SVGUnitTypes, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedEnumeration clipPathUnits
        {
            get;
            set;
        }
    }
    public partial interface MouseEvent : UIEvent
    {
        Element toElement
        {
            get;
            set;
        }
        double layerY
        {
            get;
            set;
        }
        Element fromElement
        {
            get;
            set;
        }
        double which
        {
            get;
            set;
        }
        double pageX
        {
            get;
            set;
        }
        double offsetY
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double y
        {
            get;
            set;
        }
        bool metaKey
        {
            get;
            set;
        }
        bool altKey
        {
            get;
            set;
        }
        bool ctrlKey
        {
            get;
            set;
        }
        double offsetX
        {
            get;
            set;
        }
        double screenX
        {
            get;
            set;
        }
        double clientY
        {
            get;
            set;
        }
        bool shiftKey
        {
            get;
            set;
        }
        double layerX
        {
            get;
            set;
        }
        double screenY
        {
            get;
            set;
        }
        EventTarget relatedTarget
        {
            get;
            set;
        }
        double button
        {
            get;
            set;
        }
        double pageY
        {
            get;
            set;
        }
        double buttons
        {
            get;
            set;
        }
        double clientX
        {
            get;
            set;
        }
        void initMouseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg);
        bool getModifierState(string keyArg);
    }
    public partial interface RangeException
    {
        double code
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string.ToString();
        double INVALID_NODE_TYPE_ERR
        {
            get;
            set;
        }
        double BAD_BOUNDARYPOINTS_ERR
        {
            get;
            set;
        }
    }
    public partial interface SVGTextPositioningElement : SVGTextContentElement
    {
        SVGAnimatedLengthList y
        {
            get;
            set;
        }
        SVGAnimatedNumberList rotate
        {
            get;
            set;
        }
        SVGAnimatedLengthList dy
        {
            get;
            set;
        }
        SVGAnimatedLengthList x
        {
            get;
            set;
        }
        SVGAnimatedLengthList dx
        {
            get;
            set;
        }
    }
    public partial interface HTMLAppletElement : HTMLElement, DOML2DeprecatedMarginStyle, DOML2DeprecatedBorderStyle, DOML2DeprecatedAlignmentStyle, MSDataBindingExtensions, MSDataBindingRecordSetExtensions
    {
        double width
        {
            get;
            set;
        }
        string codeType
        {
            get;
            set;
        }
        string _object
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string code
        {
            get;
            set;
        }
        string archive
        {
            get;
            set;
        }
        string alt
        {
            get;
            set;
        }
        string standby
        {
            get;
            set;
        }
        string classid
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string useMap
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        string altHtml
        {
            get;
            set;
        }
        Document contentDocument
        {
            get;
            set;
        }
        string codeBase
        {
            get;
            set;
        }
        bool declare
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string BaseHref
        {
            get;
            set;
        }
    }
    public partial interface TextMetrics
    {
        double width
        {
            get;
            set;
        }
    }
    public partial interface DocumentEvent
    {
        Event createEvent(string eventInterface);
    }
    public partial interface HTMLOListElement : HTMLElement, DOML2DeprecatedListSpaceReduction, DOML2DeprecatedListNumberingAndBulletStyle
    {
        double start
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegLinetoVerticalRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedString
    {
        string animVal
        {
            get;
            set;
        }
        string baseVal
        {
            get;
            set;
        }
    }
    public partial interface CDATASection : Text { }
    public partial interface StyleMedia
    {
        string type
        {
            get;
            set;
        }
        bool matchMedium(string mediaquery);
    }
    public partial interface HTMLSelectElement : HTMLElement, MSHTMLCollectionExtensions, MSDataBindingExtensions
    {
        HTMLSelectElement options
        {
            get;
            set;
        }
        string value
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        double size
        {
            get;
            set;
        }
        double Length
        {
            get;
            set;
        }
        double selectedIndex
        {
            get;
            set;
        }
        bool multiple
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string validationMessage
        {
            get;
            set;
        }
        bool autofocus
        {
            get;
            set;
        }
        ValidityState validity
        {
            get;
            set;
        }
        bool required
        {
            get;
            set;
        }
        bool willValidate
        {
            get;
            set;
        }
        void remove(double index = 0.0);
        void add(HTMLElement element, object before = null);
        object item(object name = null, object index = null);
        object namedItem(string name);
        object this[string name]
        {
            get;
            set;
        }
        bool checkValidity();
        void setCustomValidity(string error);
    }
    public partial interface TextRange
    {
        double boundingLeft
        {
            get;
            set;
        }
        string htmlText
        {
            get;
            set;
        }
        double offsetLeft
        {
            get;
            set;
        }
        double boundingWidth
        {
            get;
            set;
        }
        double boundingHeight
        {
            get;
            set;
        }
        double boundingTop
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        double offsetTop
        {
            get;
            set;
        }
        void moveToPoint(double x, double y);
        object queryCommandValue(string cmdID);
        string getBookmark();
        double move(string unit, double count = 0.0);
        bool queryCommandIndeterm(string cmdID);
        void scrollIntoView(bool fStart = false);
        bool findText(string _string, double count = 0.0, double flags = 0.0);
        bool execCommand(string cmdID, bool showUI = false, object value = null);
        ClientRect getBoundingClientRect();
        bool moveToBookmark(string bookmark);
        bool isEqual(TextRange range);
        TextRange duplicate();
        void collapse(bool start = false);
        string queryCommandText(string cmdID);
        void select();
        void pasteHTML(string html);
        bool inRange(TextRange range);
        double moveEnd(string unit, double count = 0.0);
        ClientRectList getClientRects();
        double moveStart(string unit, double count = 0.0);
        Element parentElement();
        bool queryCommandState(string cmdID);
        double compareEndPoints(string how, TextRange sourceRange);
        bool execCommandShowHelp(string cmdID);
        void moveToElementText(Element element);
        bool expand(string Unit);
        bool queryCommandSupported(string cmdID);
        void setEndPoint(string how, TextRange SourceRange);
        bool queryCommandEnabled(string cmdID);
    }
    public partial interface SVGTests
    {
        SVGStringList requiredFeatures
        {
            get;
            set;
        }
        SVGStringList requiredExtensions
        {
            get;
            set;
        }
        SVGStringList systemLanguage
        {
            get;
            set;
        }
        bool hasExtension(string extension);
    }
    public partial interface HTMLBlockElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        double width
        {
            get;
            set;
        }
        string cite
        {
            get;
            set;
        }
    }
    public partial interface CSSStyleSheet : StyleSheet
    {
        Element owningElement
        {
            get;
            set;
        }
        StyleSheetList imports
        {
            get;
            set;
        }
        bool isAlternate
        {
            get;
            set;
        }
        MSCSSRuleList rules
        {
            get;
            set;
        }
        bool isPrefAlternate
        {
            get;
            set;
        }
        bool readOnly
        {
            get;
            set;
        }
        string cssText
        {
            get;
            set;
        }
        CSSRule ownerRule
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        CSSRuleList cssRules
        {
            get;
            set;
        }
        string id
        {
            get;
            set;
        }
        StyleSheetPageList pages
        {
            get;
            set;
        }
        double addImport(string bstrURL, double lIndex = 0.0);
        double addPageRule(string bstrSelector, string bstrStyle, double lIndex = 0.0);
        double insertRule(string rule, double index = 0.0);
        void removeRule(double lIndex);
        void deleteRule(double index = 0.0);
        double addRule(string bstrSelector, string bstrStyle = null, double lIndex = 0.0);
        void removeImport(double lIndex);
    }
    public partial interface MSSelection
    {
        string type
        {
            get;
            set;
        }
        string typeDetail
        {
            get;
            set;
        }
        TextRange createRange();
        void clear();
        TextRangeCollection createRangeCollection();
        void empty();
    }
    public partial interface HTMLMetaElement : HTMLElement
    {
        string httpEquiv
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string content
        {
            get;
            set;
        }
        string url
        {
            get;
            set;
        }
        string scheme
        {
            get;
            set;
        }
        string charset
        {
            get;
            set;
        }
    }
    public partial interface SVGPatternElement : SVGElement, SVGUnitTypes, SVGStylable, SVGLangSpace, SVGTests, SVGFitToViewBox, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedEnumeration patternUnits
        {
            get;
            set;
        }
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedEnumeration patternContentUnits
        {
            get;
            set;
        }
        SVGAnimatedTransformList patternTransform
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedAngle
    {
        SVGAngle animVal
        {
            get;
            set;
        }
        SVGAngle baseVal
        {
            get;
            set;
        }
    }
    public partial interface Selection
    {
        bool isCollapsed
        {
            get;
            set;
        }
        Node anchorNode
        {
            get;
            set;
        }
        Node focusNode
        {
            get;
            set;
        }
        double anchorOffset
        {
            get;
            set;
        }
        double focusOffset
        {
            get;
            set;
        }
        double rangeCount
        {
            get;
            set;
        }
        void addRange(Range range);
        void collapseToEnd();
        string.ToString();
        void selectAllChildren(Node parentNode);
        Range getRangeAt(double index);
        void collapse(Node parentNode, double offset);
        void removeAllRanges();
        void collapseToStart();
        void deleteFromDocument();
        void removeRange(Range range);
    }
    public partial interface SVGScriptElement : SVGElement, SVGExternalResourcesRequired, SVGURIReference
    {
        string type
        {
            get;
            set;
        }
    }
    public partial interface HTMLDDElement : HTMLElement
    {
        bool noWrap
        {
            get;
            set;
        }
    }
    public partial interface MSDataBindingRecordSetReadonlyExtensions
    {
        object recordset
        {
            get;
            set;
        }
        object namedRecordset(string dataMember, object hierarchy = null);
    }
    public partial interface CSSStyleRule : CSSRule
    {
        string selectorText
        {
            get;
            set;
        }
        MSStyleCSSProperties style
        {
            get;
            set;
        }
        bool readOnly
        {
            get;
            set;
        }
    }
    public partial interface NodeIterator
    {
        double whatToShow
        {
            get;
            set;
        }
        NodeFilter filter
        {
            get;
            set;
        }
        Node root
        {
            get;
            set;
        }
        bool expandEntityReferences
        {
            get;
            set;
        }
        Node nextNode();
        void detach();
        Node previousNode();
    }
    public partial interface SVGViewElement : SVGElement, SVGZoomAndPan, SVGFitToViewBox, SVGExternalResourcesRequired
    {
        SVGStringList viewTarget
        {
            get;
            set;
        }
    }
    public partial interface HTMLLinkElement : HTMLElement, LinkStyle
    {
        string rel
        {
            get;
            set;
        }
        string target
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        string media
        {
            get;
            set;
        }
        string rev
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string charset
        {
            get;
            set;
        }
        string hreflang
        {
            get;
            set;
        }
    }
    public partial interface SVGLocatable
    {
        SVGElement farthestViewportElement
        {
            get;
            set;
        }
        SVGElement nearestViewportElement
        {
            get;
            set;
        }
        SVGRect getBBox();
        SVGMatrix getTransformToElement(SVGElement element);
        SVGMatrix getCTM();
        SVGMatrix getScreenCTM();
    }
    public partial interface HTMLFontElement : HTMLElement, DOML2DeprecatedColorProperty, DOML2DeprecatedSizeProperty
    {
        string face
        {
            get;
            set;
        }
    }
    public partial interface SVGTitleElement : SVGElement, SVGStylable, SVGLangSpace { }
    public partial interface ControlRangeCollection
    {
        double Length
        {
            get;
            set;
        }
        object queryCommandValue(string cmdID);
        void remove(double index);
        void add(Element item);
        bool queryCommandIndeterm(string cmdID);
        void scrollIntoView(object varargStart = null);
        Element item(double index);
        Element this[double index]
        {
            get;
            set;
        }
        bool execCommand(string cmdID, bool showUI = false, object value = null);
        void addElement(Element item);
        bool queryCommandState(string cmdID);
        bool queryCommandSupported(string cmdID);
        bool queryCommandEnabled(string cmdID);
        string queryCommandText(string cmdID);
        void select();
    }
    public partial interface MSNamespaceInfo : MSEventAttachmentTarget
    {
        string urn
        {
            get;
            set;
        }
        System.Func<Event, object> onreadystatechange
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string readyState
        {
            get;
            set;
        }
        void doImport(string implementationUrl);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface WindowSessionStorage
    {
        Storage sessionStorage
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedTransformList
    {
        SVGTransformList animVal
        {
            get;
            set;
        }
        SVGTransformList baseVal
        {
            get;
            set;
        }
    }
    public partial interface HTMLTableCaptionElement : HTMLElement
    {
        string align
        {
            get;
            set;
        }
        string vAlign
        {
            get;
            set;
        }
    }
    public partial interface HTMLOptionElement : HTMLElement, MSDataBindingExtensions
    {
        double index
        {
            get;
            set;
        }
        bool defaultSelected
        {
            get;
            set;
        }
        string value
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string label
        {
            get;
            set;
        }
        bool selected
        {
            get;
            set;
        }
    }
    public partial interface HTMLMapElement : HTMLElement
    {
        string name
        {
            get;
            set;
        }
        HTMLAreasCollection areas
        {
            get;
            set;
        }
    }
    public partial interface HTMLMenuElement : HTMLElement, DOML2DeprecatedListSpaceReduction
    {
        string type
        {
            get;
            set;
        }
    }
    public partial interface MouseWheelEvent : MouseEvent
    {
        double wheelDelta
        {
            get;
            set;
        }
        void initMouseWheelEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, double buttonArg, EventTarget relatedTargetArg, string modifiersListArg, double wheelDeltaArg);
    }
    public partial interface SVGFitToViewBox
    {
        SVGAnimatedRect viewBox
        {
            get;
            set;
        }
        SVGAnimatedPreserveAspectRatio preserveAspectRatio
        {
            get;
            set;
        }
    }
    public partial interface SVGPointList
    {
        double numberOfItems
        {
            get;
            set;
        }
        SVGPoint replaceItem(SVGPoint newItem, double index);
        SVGPoint getItem(double index);
        void clear();
        SVGPoint appendItem(SVGPoint newItem);
        SVGPoint initialize(SVGPoint newItem);
        SVGPoint removeItem(double index);
        SVGPoint insertItemBefore(SVGPoint newItem, double index);
    }
    public partial interface SVGAnimatedLengthList
    {
        SVGLengthList animVal
        {
            get;
            set;
        }
        SVGLengthList baseVal
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedPreserveAspectRatio
    {
        SVGPreserveAspectRatio animVal
        {
            get;
            set;
        }
        SVGPreserveAspectRatio baseVal
        {
            get;
            set;
        }
    }
    public partial interface MSSiteModeEvent : Event
    {
        double buttonID
        {
            get;
            set;
        }
        string actionURL
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedTextFlowControl
    {
        string clear
        {
            get;
            set;
        }
    }
    public partial interface StyleSheetPageList
    {
        double Length
        {
            get;
            set;
        }
        CSSPageRule item(double index);
        CSSPageRule this[double index]
        {
            get;
            set;
        }
    }
    public partial interface MSCSSProperties : CSSStyleDeclaration
    {
        string scrollbarShadowColor
        {
            get;
            set;
        }
        string scrollbarHighlightColor
        {
            get;
            set;
        }
        string layoutGridChar
        {
            get;
            set;
        }
        string layoutGridType
        {
            get;
            set;
        }
        string textAutospace
        {
            get;
            set;
        }
        string textKashidaSpace
        {
            get;
            set;
        }
        string writingMode
        {
            get;
            set;
        }
        string scrollbarFaceColor
        {
            get;
            set;
        }
        string backgroundPositionY
        {
            get;
            set;
        }
        string lineBreak
        {
            get;
            set;
        }
        string imeMode
        {
            get;
            set;
        }
        string msBlockProgression
        {
            get;
            set;
        }
        string layoutGridLine
        {
            get;
            set;
        }
        string scrollbarBaseColor
        {
            get;
            set;
        }
        string layoutGrid
        {
            get;
            set;
        }
        string layoutFlow
        {
            get;
            set;
        }
        string textKashida
        {
            get;
            set;
        }
        string filter
        {
            get;
            set;
        }
        string zoom
        {
            get;
            set;
        }
        string scrollbarArrowColor
        {
            get;
            set;
        }
        string behavior
        {
            get;
            set;
        }
        string backgroundPositionX
        {
            get;
            set;
        }
        string accelerator
        {
            get;
            set;
        }
        string layoutGridMode
        {
            get;
            set;
        }
        string textJustifyTrim
        {
            get;
            set;
        }
        string scrollbar3dLightColor
        {
            get;
            set;
        }
        string msInterpolationMode
        {
            get;
            set;
        }
        string scrollbarTrackColor
        {
            get;
            set;
        }
        string scrollbarDarkShadowColor
        {
            get;
            set;
        }
        string styleFloat
        {
            get;
            set;
        }
        object getAttribute(string attributeName, double flags = 0.0);
        void setAttribute(string attributeName, object AttributeValue, double flags = 0.0);
        bool removeAttribute(string attributeName, double flags = 0.0);
    }
    public partial interface HTMLCollection : MSHTMLCollectionExtensions
    {
        double Length
        {
            get;
            set;
        }
        Element item(object nameOrIndex = null, object optionalIndex = null);
        Element namedItem(string name);
    }
    public partial interface SVGExternalResourcesRequired
    {
        SVGAnimatedBoolean externalResourcesRequired
        {
            get;
            set;
        }
    }
    public partial interface HTMLImageElement : HTMLElement, MSImageResourceExtensions, MSDataBindingExtensions, MSResourceMetadata
    {
        double width
        {
            get;
            set;
        }
        double vspace
        {
            get;
            set;
        }
        double naturalHeight
        {
            get;
            set;
        }
        string alt
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string useMap
        {
            get;
            set;
        }
        double naturalWidth
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        double hspace
        {
            get;
            set;
        }
        string longDesc
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        bool isMap
        {
            get;
            set;
        }
        bool complete
        {
            get;
            set;
        }
        bool msPlayToPrimary
        {
            get;
            set;
        }
        bool msPlayToDisabled
        {
            get;
            set;
        }
        object msPlayToSource
        {
            get;
            set;
        }
        string crossOrigin
        {
            get;
            set;
        }
        string msPlayToPreferredSourceUri
        {
            get;
            set;
        }
    }
    public partial interface HTMLAreaElement : HTMLElement
    {
        string protocol
        {
            get;
            set;
        }
        string search
        {
            get;
            set;
        }
        string alt
        {
            get;
            set;
        }
        string coords
        {
            get;
            set;
        }
        string hostname
        {
            get;
            set;
        }
        string port
        {
            get;
            set;
        }
        string pathname
        {
            get;
            set;
        }
        string host
        {
            get;
            set;
        }
        string hash
        {
            get;
            set;
        }
        string target
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        bool noHref
        {
            get;
            set;
        }
        string shape
        {
            get;
            set;
        }
        string.ToString();
    }
    public partial interface EventTarget
    {
        void removeEventListener(string type, EventListener listener, bool useCapture = false);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
        bool dispatchEvent(Event evt);
    }
    public partial interface SVGAngle
    {
        string valueAsString
        {
            get;
            set;
        }
        double valueInSpecifiedUnits
        {
            get;
            set;
        }
        double value
        {
            get;
            set;
        }
        double unitType
        {
            get;
            set;
        }
        void newValueSpecifiedUnits(double unitType, double valueInSpecifiedUnits);
        void convertToSpecifiedUnits(double unitType);
        double SVG_ANGLETYPE_RAD
        {
            get;
            set;
        }
        double SVG_ANGLETYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_ANGLETYPE_UNSPECIFIED
        {
            get;
            set;
        }
        double SVG_ANGLETYPE_DEG
        {
            get;
            set;
        }
        double SVG_ANGLETYPE_GRAD
        {
            get;
            set;
        }
    }
    public partial interface HTMLButtonElement : HTMLElement, MSDataBindingExtensions
    {
        string value
        {
            get;
            set;
        }
        object status
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string validationMessage
        {
            get;
            set;
        }
        string formTarget
        {
            get;
            set;
        }
        bool willValidate
        {
            get;
            set;
        }
        string formAction
        {
            get;
            set;
        }
        bool autofocus
        {
            get;
            set;
        }
        ValidityState validity
        {
            get;
            set;
        }
        string formNoValidate
        {
            get;
            set;
        }
        string formEnctype
        {
            get;
            set;
        }
        string formMethod
        {
            get;
            set;
        }
        TextRange createTextRange();
        bool checkValidity();
        void setCustomValidity(string error);
    }
    public partial interface HTMLSourceElement : HTMLElement
    {
        string src
        {
            get;
            set;
        }
        string media
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string msKeySystem
        {
            get;
            set;
        }
    }
    public partial interface CanvasGradient
    {
        void addColorStop(double offset, string color);
    }
    public partial interface KeyboardEvent : UIEvent
    {
        double location
        {
            get;
            set;
        }
        double keyCode
        {
            get;
            set;
        }
        bool shiftKey
        {
            get;
            set;
        }
        double which
        {
            get;
            set;
        }
        string locale
        {
            get;
            set;
        }
        string key
        {
            get;
            set;
        }
        bool altKey
        {
            get;
            set;
        }
        bool metaKey
        {
            get;
            set;
        }
        string _char
        {
            get;
            set;
        }
        bool ctrlKey
        {
            get;
            set;
        }
        bool repeat
        {
            get;
            set;
        }
        double charCode
        {
            get;
            set;
        }
        bool getModifierState(string keyArg);
        void initKeyboardEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string keyArg, double locationArg, string modifiersListArg, bool repeat, string locale);
        double DOM_KEY_LOCATION_RIGHT
        {
            get;
            set;
        }
        double DOM_KEY_LOCATION_STANDARD
        {
            get;
            set;
        }
        double DOM_KEY_LOCATION_LEFT
        {
            get;
            set;
        }
        double DOM_KEY_LOCATION_NUMPAD
        {
            get;
            set;
        }
        double DOM_KEY_LOCATION_JOYSTICK
        {
            get;
            set;
        }
        double DOM_KEY_LOCATION_MOBILE
        {
            get;
            set;
        }
    }
    public partial interface MessageEvent : Event
    {
        Window source
        {
            get;
            set;
        }
        string origin
        {
            get;
            set;
        }
        object data
        {
            get;
            set;
        }
        object ports
        {
            get;
            set;
        }
        void initMessageEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object dataArg, string originArg, string lastEventIdArg, Window sourceArg);
    }
    public partial interface SVGElement : Element
    {
        System.Func<MouseEvent, object> onmouseover
        {
            get;
            set;
        }
        SVGElement viewportElement
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousemove
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseout
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> ondblclick
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusout
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusin
        {
            get;
            set;
        }
        string xmlbase
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmousedown
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseup
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onclick
        {
            get;
            set;
        }
        SVGSVGElement ownerSVGElement
        {
            get;
            set;
        }
        string id
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface HTMLScriptElement : HTMLElement
    {
        bool defer
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string htmlFor
        {
            get;
            set;
        }
        string charset
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string _event
        {
            get;
            set;
        }
        bool async
        {
            get;
            set;
        }
    }
    public partial interface HTMLTableRowElement : HTMLElement, HTMLTableAlignment, DOML2DeprecatedBackgroundColorStyle
    {
        double rowIndex
        {
            get;
            set;
        }
        HTMLCollection cells
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        object borderColorLight
        {
            get;
            set;
        }
        double sectionRowIndex
        {
            get;
            set;
        }
        object borderColor
        {
            get;
            set;
        }
        object height
        {
            get;
            set;
        }
        object borderColorDark
        {
            get;
            set;
        }
        void deleteCell(double index = 0.0);
        HTMLElement insertCell(double index = 0.0);
    }
    public partial interface CanvasRenderingContext2D
    {
        double miterLimit
        {
            get;
            set;
        }
        string font
        {
            get;
            set;
        }
        string globalCompositeOperation
        {
            get;
            set;
        }
        string msFillRule
        {
            get;
            set;
        }
        string lineCap
        {
            get;
            set;
        }
        bool msImageSmoothingEnabled
        {
            get;
            set;
        }
        double lineDashOffset
        {
            get;
            set;
        }
        string shadowColor
        {
            get;
            set;
        }
        string lineJoin
        {
            get;
            set;
        }
        double shadowOffsetX
        {
            get;
            set;
        }
        double lineWidth
        {
            get;
            set;
        }
        HTMLCanvasElement canvas
        {
            get;
            set;
        }
        object strokeStyle
        {
            get;
            set;
        }
        double globalAlpha
        {
            get;
            set;
        }
        double shadowOffsetY
        {
            get;
            set;
        }
        object fillStyle
        {
            get;
            set;
        }
        double shadowBlur
        {
            get;
            set;
        }
        string textAlign
        {
            get;
            set;
        }
        string textBaseline
        {
            get;
            set;
        }
        void restore();
        void setTransform(double m11, double m12, double m21, double m22, double dx, double dy);
        void save();
        void arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise = false);
        TextMetrics measureText(string text);
        bool isPointInPath(double x, double y, string fillRule = null);
        void quadraticCurveTo(double cpx, double cpy, double x, double y);
        void putImageData(ImageData imagedata, double dx, double dy, double dirtyX = 0.0, double dirtyY = 0.0, double dirtyWidth = 0.0, double dirtyHeight = 0.0);
        void rotate(double angle);
        void fillText(string text, double x, double y, double maxWidth = 0.0);
        void translate(double x, double y);
        void scale(double x, double y);
        CanvasGradient createRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1);
        void lineTo(double x, double y);
        Array<double> getLineDash();
        void fill(string fillRule = null);
        ImageData createImageData(object imageDataOrSw, double sh = 0.0);
        CanvasPattern createPattern(HTMLElement image, string repetition);
        void closePath();
        void rect(double x, double y, double w, double h);
        void clip(string fillRule = null);
        void clearRect(double x, double y, double w, double h);
        void moveTo(double x, double y);
        ImageData getImageData(double sx, double sy, double sw, double sh);
        void fillRect(double x, double y, double w, double h);
        void bezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y);
        void drawImage(HTMLElement image, double offsetX, double offsetY, double width = 0.0, double height = 0.0, double canvasOffsetX = 0.0, double canvasOffsetY = 0.0, double canvasImageWidth = 0.0, double canvasImageHeight = 0.0);
        void transform(double m11, double m12, double m21, double m22, double dx, double dy);
        void stroke();
        void strokeRect(double x, double y, double w, double h);
        void setLineDash(Array<double> segments);
        void strokeText(string text, double x, double y, double maxWidth = 0.0);
        void beginPath();
        void arcTo(double x1, double y1, double x2, double y2, double radius);
        CanvasGradient createLinearGradient(double x0, double y0, double x1, double y1);
    }
    public partial interface MSCSSRuleList
    {
        double Length
        {
            get;
            set;
        }
        CSSStyleRule item(double index = 0.0);
        CSSStyleRule this[double index]
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegLinetoHorizontalAbs : SVGPathSeg
    {
        double x
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegArcAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        bool sweepFlag
        {
            get;
            set;
        }
        double r2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double angle
        {
            get;
            set;
        }
        double r1
        {
            get;
            set;
        }
        bool largeArcFlag
        {
            get;
            set;
        }
    }
    public partial interface SVGTransformList
    {
        double numberOfItems
        {
            get;
            set;
        }
        SVGTransform getItem(double index);
        SVGTransform consolidate();
        void clear();
        SVGTransform appendItem(SVGTransform newItem);
        SVGTransform initialize(SVGTransform newItem);
        SVGTransform removeItem(double index);
        SVGTransform insertItemBefore(SVGTransform newItem, double index);
        SVGTransform replaceItem(SVGTransform newItem, double index);
        SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix);
    }
    public partial interface HTMLHtmlElement : HTMLElement
    {
        string version
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegClosePath : SVGPathSeg { }
    public partial interface HTMLFrameElement : HTMLElement, GetSVGDocument, MSDataBindingExtensions
    {
        object width
        {
            get;
            set;
        }
        string scrolling
        {
            get;
            set;
        }
        string marginHeight
        {
            get;
            set;
        }
        string marginWidth
        {
            get;
            set;
        }
        object borderColor
        {
            get;
            set;
        }
        object frameSpacing
        {
            get;
            set;
        }
        string frameBorder
        {
            get;
            set;
        }
        bool noResize
        {
            get;
            set;
        }
        Window contentWindow
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        object height
        {
            get;
            set;
        }
        Document contentDocument
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        string longDesc
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        object security
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface SVGAnimatedLength
    {
        SVGLength animVal
        {
            get;
            set;
        }
        SVGLength baseVal
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedPoints
    {
        SVGPointList points
        {
            get;
            set;
        }
        SVGPointList animatedPoints
        {
            get;
            set;
        }
    }
    public partial interface SVGDefsElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired { }
    public partial interface HTMLQuoteElement : HTMLElement
    {
        string dateTime
        {
            get;
            set;
        }
        string cite
        {
            get;
            set;
        }
    }
    public partial interface CSSMediaRule : CSSRule
    {
        MediaList media
        {
            get;
            set;
        }
        CSSRuleList cssRules
        {
            get;
            set;
        }
        double insertRule(string rule, double index = 0.0);
        void deleteRule(double index = 0.0);
    }
    public partial interface WindowModal
    {
        object dialogArguments
        {
            get;
            set;
        }
        object returnValue
        {
            get;
            set;
        }
    }
    public partial interface XMLHttpRequest : EventTarget
    {
        object responseBody
        {
            get;
            set;
        }
        double status
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        string responseText
        {
            get;
            set;
        }
        object responseXML
        {
            get;
            set;
        }
        System.Func<Event, object> ontimeout
        {
            get;
            set;
        }
        string statusText
        {
            get;
            set;
        }
        System.Func<Event, object> onreadystatechange
        {
            get;
            set;
        }
        double timeout
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        object response
        {
            get;
            set;
        }
        bool withCredentials
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        string responseType
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onloadend
        {
            get;
            set;
        }
        XMLHttpRequestEventTarget upload
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onloadstart
        {
            get;
            set;
        }
        string msCaching
        {
            get;
            set;
        }
        void open(string method, string url, bool async = false, string user = null, string password = null);
        void send(object data = null);
        void abort();
        string getAllResponseHeaders();
        void setRequestHeader(string header, string value);
        string getResponseHeader(string header);
        bool msCachingEnabled();
        void overrideMimeType(string mime);
        double LOADING
        {
            get;
            set;
        }
        double DONE
        {
            get;
            set;
        }
        double UNSENT
        {
            get;
            set;
        }
        double OPENED
        {
            get;
            set;
        }
        double HEADERS_RECEIVED
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface HTMLTableHeaderCellElement : HTMLTableCellElement
    {
        string scope
        {
            get;
            set;
        }
    }
    public partial interface HTMLDListElement : HTMLElement, DOML2DeprecatedListSpaceReduction { }
    public partial interface MSDataBindingExtensions
    {
        string dataSrc
        {
            get;
            set;
        }
        string dataFormatAs
        {
            get;
            set;
        }
        string dataFld
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegLinetoHorizontalRel : SVGPathSeg
    {
        double x
        {
            get;
            set;
        }
    }
    public partial interface SVGEllipseElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength ry
        {
            get;
            set;
        }
        SVGAnimatedLength cx
        {
            get;
            set;
        }
        SVGAnimatedLength rx
        {
            get;
            set;
        }
        SVGAnimatedLength cy
        {
            get;
            set;
        }
    }
    public partial interface SVGAElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedString target
        {
            get;
            set;
        }
    }
    public partial interface SVGStylable
    {
        SVGAnimatedString className
        {
            get;
            set;
        }
        CSSStyleDeclaration style
        {
            get;
            set;
        }
    }
    public partial interface SVGTransformable : SVGLocatable
    {
        SVGAnimatedTransformList transform
        {
            get;
            set;
        }
    }
    public partial interface HTMLFrameSetElement : HTMLElement
    {
        System.Func<Event, object> ononline
        {
            get;
            set;
        }
        object borderColor
        {
            get;
            set;
        }
        string rows
        {
            get;
            set;
        }
        string cols
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onblur
        {
            get;
            set;
        }
        object frameSpacing
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocus
        {
            get;
            set;
        }
        System.Func<MessageEvent, object> onmessage
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        string frameBorder
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onresize
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        System.Func<Event, object> onafterprint
        {
            get;
            set;
        }
        System.Func<Event, object> onbeforeprint
        {
            get;
            set;
        }
        System.Func<Event, object> onoffline
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        System.Func<Event, object> onunload
        {
            get;
            set;
        }
        System.Func<Event, object> onhashchange
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<BeforeUnloadEvent, object> onbeforeunload
        {
            get;
            set;
        }
        System.Func<StorageEvent, object> onstorage
        {
            get;
            set;
        }
        System.Func<PageTransitionEvent, object> onpageshow
        {
            get;
            set;
        }
        System.Func<PageTransitionEvent, object> onpagehide
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface Screen : EventTarget
    {
        double width
        {
            get;
            set;
        }
        double deviceXDPI
        {
            get;
            set;
        }
        bool fontSmoothingEnabled
        {
            get;
            set;
        }
        double bufferDepth
        {
            get;
            set;
        }
        double logicalXDPI
        {
            get;
            set;
        }
        double systemXDPI
        {
            get;
            set;
        }
        double availHeight
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        double logicalYDPI
        {
            get;
            set;
        }
        double systemYDPI
        {
            get;
            set;
        }
        double updateInterval
        {
            get;
            set;
        }
        double colorDepth
        {
            get;
            set;
        }
        double availWidth
        {
            get;
            set;
        }
        double deviceYDPI
        {
            get;
            set;
        }
        double pixelDepth
        {
            get;
            set;
        }
        string msOrientation
        {
            get;
            set;
        }
        System.Func<object, object> onmsorientationchange
        {
            get;
            set;
        }
        bool msLockOrientation(string orientation);
        bool msLockOrientation(Array<string> orientations);
        void msUnlockOrientation();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface Coordinates
    {
        double altitudeAccuracy
        {
            get;
            set;
        }
        double longitude
        {
            get;
            set;
        }
        double latitude
        {
            get;
            set;
        }
        double speed
        {
            get;
            set;
        }
        double heading
        {
            get;
            set;
        }
        double altitude
        {
            get;
            set;
        }
        double accuracy
        {
            get;
            set;
        }
    }
    public partial interface NavigatorGeolocation
    {
        Geolocation geolocation
        {
            get;
            set;
        }
    }
    public partial interface NavigatorContentUtils { }
    public delegate void EventListener(Event evt);
    public partial interface SVGLangSpace
    {
        string xmllang
        {
            get;
            set;
        }
        string xmlspace
        {
            get;
            set;
        }
    }
    public partial interface DataTransfer
    {
        string effectAllowed
        {
            get;
            set;
        }
        string dropEffect
        {
            get;
            set;
        }
        DOMStringList types
        {
            get;
            set;
        }
        FileList files
        {
            get;
            set;
        }
        bool clearData(string format = null);
        bool setData(string format, string data);
        string getData(string format);
    }
    public partial interface FocusEvent : UIEvent
    {
        EventTarget relatedTarget
        {
            get;
            set;
        }
        void initFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, EventTarget relatedTargetArg);
    }
    public partial interface Range
    {
        double startOffset
        {
            get;
            set;
        }
        bool collapsed
        {
            get;
            set;
        }
        double endOffset
        {
            get;
            set;
        }
        Node startContainer
        {
            get;
            set;
        }
        Node endContainer
        {
            get;
            set;
        }
        Node commonAncestorContainer
        {
            get;
            set;
        }
        void setStart(Node refNode, double offset);
        void setEndBefore(Node refNode);
        void setStartBefore(Node refNode);
        void selectNode(Node refNode);
        void detach();
        ClientRect getBoundingClientRect();
        string.ToString();
        double compareBoundaryPoints(double how, Range sourceRange);
        void insertNode(Node newNode);
        void collapse(bool toStart);
        void selectNodeContents(Node refNode);
        DocumentFragment cloneContents();
        void setEnd(Node refNode, double offset);
        Range cloneRange();
        ClientRectList getClientRects();
        void surroundContents(Node newParent);
        void deleteContents();
        void setStartAfter(Node refNode);
        DocumentFragment extractContents();
        void setEndAfter(Node refNode);
        DocumentFragment createContextualFragment(string fragment);
        double END_TO_END
        {
            get;
            set;
        }
        double START_TO_START
        {
            get;
            set;
        }
        double START_TO_END
        {
            get;
            set;
        }
        double END_TO_START
        {
            get;
            set;
        }
    }
    public partial interface SVGPoint
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        SVGPoint matrixTransform(SVGMatrix matrix);
    }
    public partial interface MSPluginsCollection
    {
        double Length
        {
            get;
            set;
        }
        void refresh(bool reload = false);
    }
    public partial interface SVGAnimatedNumberList
    {
        SVGNumberList animVal
        {
            get;
            set;
        }
        SVGNumberList baseVal
        {
            get;
            set;
        }
    }
    public partial interface SVGSVGElement : SVGElement, SVGStylable, SVGZoomAndPan, DocumentEvent, SVGLangSpace, SVGLocatable, SVGTests, SVGFitToViewBox, SVGExternalResourcesRequired
    {
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        string contentStyleType
        {
            get;
            set;
        }
        System.Func<object, object> onzoom
        {
            get;
            set;
        }
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGRect viewport
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        double pixelUnitToMillimeterY
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onresize
        {
            get;
            set;
        }
        double screenPixelToMillimeterY
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        string contentScriptType
        {
            get;
            set;
        }
        double pixelUnitToMillimeterX
        {
            get;
            set;
        }
        SVGPoint currentTranslate
        {
            get;
            set;
        }
        System.Func<Event, object> onunload
        {
            get;
            set;
        }
        double currentScale
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onscroll
        {
            get;
            set;
        }
        double screenPixelToMillimeterX
        {
            get;
            set;
        }
        void setCurrentTime(double seconds);
        SVGLength createSVGLength();
        NodeList getIntersectionList(SVGRect rect, SVGElement referenceElement);
        void unpauseAnimations();
        SVGRect createSVGRect();
        bool checkIntersection(SVGElement element, SVGRect rect);
        void unsuspendRedrawAll();
        void pauseAnimations();
        double suspendRedraw(double maxWaitMilliseconds);
        void deselectAll();
        SVGAngle createSVGAngle();
        NodeList getEnclosureList(SVGRect rect, SVGElement referenceElement);
        SVGTransform createSVGTransform();
        void unsuspendRedraw(double suspendHandleID);
        void forceRedraw();
        double getCurrentTime();
        bool checkEnclosure(SVGElement element, SVGRect rect);
        SVGMatrix createSVGMatrix();
        SVGPoint createSVGPoint();
        SVGNumber createSVGNumber();
        SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix);
        CSSStyleDeclaration getComputedStyle(Element elt, string pseudoElt = null);
        Element getElementById(string elementId);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface HTMLLabelElement : HTMLElement, MSDataBindingExtensions
    {
        string htmlFor
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
    }
    public partial interface MSResourceMetadata
    {
        string protocol
        {
            get;
            set;
        }
        string fileSize
        {
            get;
            set;
        }
        string fileUpdatedDate
        {
            get;
            set;
        }
        string nameProp
        {
            get;
            set;
        }
        string fileCreatedDate
        {
            get;
            set;
        }
        string fileModifiedDate
        {
            get;
            set;
        }
        string mimeType
        {
            get;
            set;
        }
    }
    public partial interface HTMLLegendElement : HTMLElement, MSDataBindingExtensions
    {
        string align
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
    }
    public partial interface HTMLDirectoryElement : HTMLElement, DOML2DeprecatedListSpaceReduction, DOML2DeprecatedListNumberingAndBulletStyle { }
    public partial interface SVGAnimatedInteger
    {
        double animVal
        {
            get;
            set;
        }
        double baseVal
        {
            get;
            set;
        }
    }
    public partial interface SVGTextElement : SVGTextPositioningElement, SVGTransformable { }
    public partial interface SVGTSpanElement : SVGTextPositioningElement { }
    public partial interface HTMLLIElement : HTMLElement, DOML2DeprecatedListNumberingAndBulletStyle
    {
        double value
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegLinetoVerticalAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
    }
    public partial interface MSStorageExtensions
    {
        double remainingSpace
        {
            get;
            set;
        }
    }
    public partial interface SVGStyleElement : SVGElement, SVGLangSpace
    {
        string media
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string title
        {
            get;
            set;
        }
    }
    public partial interface MSCurrentStyleCSSProperties : MSCSSProperties
    {
        string blockDirection
        {
            get;
            set;
        }
        string clipBottom
        {
            get;
            set;
        }
        string clipLeft
        {
            get;
            set;
        }
        string clipRight
        {
            get;
            set;
        }
        string clipTop
        {
            get;
            set;
        }
        string hasLayout
        {
            get;
            set;
        }
    }
    public partial interface MSHTMLCollectionExtensions
    {
        object urns(object urn);
        object tags(object tagName);
    }
    public partial interface Storage : MSStorageExtensions
    {
        double Length
        {
            get;
            set;
        }
        object getItem(string key);
        object this[string key]
        {
            get;
            set;
        }
        void setItem(string key, string data);
        void clear();
        void removeItem(string key);
        string key(double index);
        string this[double index]
        {
            get;
            set;
        }
    }
    public partial interface HTMLIFrameElement : HTMLElement, GetSVGDocument, MSDataBindingExtensions
    {
        string width
        {
            get;
            set;
        }
        string scrolling
        {
            get;
            set;
        }
        string marginHeight
        {
            get;
            set;
        }
        string marginWidth
        {
            get;
            set;
        }
        object frameSpacing
        {
            get;
            set;
        }
        string frameBorder
        {
            get;
            set;
        }
        bool noResize
        {
            get;
            set;
        }
        double vspace
        {
            get;
            set;
        }
        Window contentWindow
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        Document contentDocument
        {
            get;
            set;
        }
        double hspace
        {
            get;
            set;
        }
        string longDesc
        {
            get;
            set;
        }
        object security
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        DOMSettableTokenList sandbox
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface TextRangeCollection
    {
        double Length
        {
            get;
            set;
        }
        TextRange item(double index);
        TextRange this[double index]
        {
            get;
            set;
        }
    }
    public partial interface HTMLBodyElement : HTMLElement, DOML2DeprecatedBackgroundStyle, DOML2DeprecatedBackgroundColorStyle
    {
        string scroll
        {
            get;
            set;
        }
        System.Func<Event, object> ononline
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onblur
        {
            get;
            set;
        }
        bool noWrap
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocus
        {
            get;
            set;
        }
        System.Func<MessageEvent, object> onmessage
        {
            get;
            set;
        }
        object text
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        string bgProperties
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onresize
        {
            get;
            set;
        }
        object link
        {
            get;
            set;
        }
        object aLink
        {
            get;
            set;
        }
        object bottomMargin
        {
            get;
            set;
        }
        object topMargin
        {
            get;
            set;
        }
        System.Func<Event, object> onafterprint
        {
            get;
            set;
        }
        object vLink
        {
            get;
            set;
        }
        System.Func<Event, object> onbeforeprint
        {
            get;
            set;
        }
        System.Func<Event, object> onoffline
        {
            get;
            set;
        }
        System.Func<Event, object> onunload
        {
            get;
            set;
        }
        System.Func<Event, object> onhashchange
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        object rightMargin
        {
            get;
            set;
        }
        System.Func<BeforeUnloadEvent, object> onbeforeunload
        {
            get;
            set;
        }
        object leftMargin
        {
            get;
            set;
        }
        System.Func<StorageEvent, object> onstorage
        {
            get;
            set;
        }
        System.Func<PopStateEvent, object> onpopstate
        {
            get;
            set;
        }
        System.Func<PageTransitionEvent, object> onpageshow
        {
            get;
            set;
        }
        System.Func<PageTransitionEvent, object> onpagehide
        {
            get;
            set;
        }
        TextRange createTextRange();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface DocumentType : Node
    {
        string name
        {
            get;
            set;
        }
        NamedNodeMap notations
        {
            get;
            set;
        }
        string systemId
        {
            get;
            set;
        }
        string internalSubset
        {
            get;
            set;
        }
        NamedNodeMap entities
        {
            get;
            set;
        }
        string publicId
        {
            get;
            set;
        }
    }
    public partial interface SVGRadialGradientElement : SVGGradientElement
    {
        SVGAnimatedLength cx
        {
            get;
            set;
        }
        SVGAnimatedLength r
        {
            get;
            set;
        }
        SVGAnimatedLength cy
        {
            get;
            set;
        }
        SVGAnimatedLength fx
        {
            get;
            set;
        }
        SVGAnimatedLength fy
        {
            get;
            set;
        }
    }
    public partial interface MutationEvent : Event
    {
        string newValue
        {
            get;
            set;
        }
        double attrChange
        {
            get;
            set;
        }
        string attrName
        {
            get;
            set;
        }
        string prevValue
        {
            get;
            set;
        }
        Node relatedNode
        {
            get;
            set;
        }
        void initMutationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Node relatedNodeArg, string prevValueArg, string newValueArg, string attrNameArg, double attrChangeArg);
        double MODIFICATION
        {
            get;
            set;
        }
        double REMOVAL
        {
            get;
            set;
        }
        double ADDITION
        {
            get;
            set;
        }
    }
    public partial interface DragEvent : MouseEvent
    {
        DataTransfer dataTransfer
        {
            get;
            set;
        }
        void initDragEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, DataTransfer dataTransferArg);
        void msConvertURL(File file, string targetType, string targetURL = null);
    }
    public partial interface HTMLTableSectionElement : HTMLElement, HTMLTableAlignment, DOML2DeprecatedBackgroundColorStyle
    {
        string align
        {
            get;
            set;
        }
        HTMLCollection rows
        {
            get;
            set;
        }
        void deleteRow(double index = 0.0);
        object moveRow(double indexFrom = 0.0, double indexTo = 0.0);
        HTMLElement insertRow(double index = 0.0);
    }
    public partial interface DOML2DeprecatedListNumberingAndBulletStyle
    {
        string type
        {
            get;
            set;
        }
    }
    public partial interface HTMLInputElement : HTMLElement, MSDataBindingExtensions
    {
        string width
        {
            get;
            set;
        }
        bool status
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        double selectionStart
        {
            get;
            set;
        }
        bool indeterminate
        {
            get;
            set;
        }
        bool readOnly
        {
            get;
            set;
        }
        double size
        {
            get;
            set;
        }
        double loop
        {
            get;
            set;
        }
        double selectionEnd
        {
            get;
            set;
        }
        string vrml
        {
            get;
            set;
        }
        string lowsrc
        {
            get;
            set;
        }
        double vspace
        {
            get;
            set;
        }
        string accept
        {
            get;
            set;
        }
        string alt
        {
            get;
            set;
        }
        bool defaultChecked
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        string value
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string useMap
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        string dynsrc
        {
            get;
            set;
        }
        bool _checked
        {
            get;
            set;
        }
        double hspace
        {
            get;
            set;
        }
        double maxLength
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string defaultValue
        {
            get;
            set;
        }
        bool complete
        {
            get;
            set;
        }
        string start
        {
            get;
            set;
        }
        string validationMessage
        {
            get;
            set;
        }
        FileList files
        {
            get;
            set;
        }
        string Max
        {
            get;
            set;
        }
        string formTarget
        {
            get;
            set;
        }
        bool willValidate
        {
            get;
            set;
        }
        string step
        {
            get;
            set;
        }
        bool autofocus
        {
            get;
            set;
        }
        bool required
        {
            get;
            set;
        }
        string formEnctype
        {
            get;
            set;
        }
        double valueAsNumber
        {
            get;
            set;
        }
        string placeholder
        {
            get;
            set;
        }
        string formMethod
        {
            get;
            set;
        }
        HTMLElement list
        {
            get;
            set;
        }
        string autocomplete
        {
            get;
            set;
        }
        string min
        {
            get;
            set;
        }
        string formAction
        {
            get;
            set;
        }
        string pattern
        {
            get;
            set;
        }
        ValidityState validity
        {
            get;
            set;
        }
        string formNoValidate
        {
            get;
            set;
        }
        bool multiple
        {
            get;
            set;
        }
        TextRange createTextRange();
        void setSelectionRange(double start, double end);
        void select();
        bool checkValidity();
        void stepDown(double n = 0.0);
        void stepUp(double n = 0.0);
        void setCustomValidity(string error);
    }
    public partial interface HTMLAnchorElement : HTMLElement, MSDataBindingExtensions
    {
        string rel
        {
            get;
            set;
        }
        string protocol
        {
            get;
            set;
        }
        string search
        {
            get;
            set;
        }
        string coords
        {
            get;
            set;
        }
        string hostname
        {
            get;
            set;
        }
        string pathname
        {
            get;
            set;
        }
        string Methods
        {
            get;
            set;
        }
        string target
        {
            get;
            set;
        }
        string protocolLong
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string charset
        {
            get;
            set;
        }
        string hreflang
        {
            get;
            set;
        }
        string port
        {
            get;
            set;
        }
        string host
        {
            get;
            set;
        }
        string hash
        {
            get;
            set;
        }
        string nameProp
        {
            get;
            set;
        }
        string urn
        {
            get;
            set;
        }
        string rev
        {
            get;
            set;
        }
        string shape
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string mimeType
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        string.ToString();
    }
    public partial interface HTMLParamElement : HTMLElement
    {
        string value
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string valueType
        {
            get;
            set;
        }
    }
    public partial interface SVGImageElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedPreserveAspectRatio preserveAspectRatio
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedNumber
    {
        double animVal
        {
            get;
            set;
        }
        double baseVal
        {
            get;
            set;
        }
    }
    public partial interface PerformanceTiming
    {
        double redirectStart
        {
            get;
            set;
        }
        double domainLookupEnd
        {
            get;
            set;
        }
        double responseStart
        {
            get;
            set;
        }
        double domComplete
        {
            get;
            set;
        }
        double domainLookupStart
        {
            get;
            set;
        }
        double loadEventStart
        {
            get;
            set;
        }
        double msFirstPaint
        {
            get;
            set;
        }
        double unloadEventEnd
        {
            get;
            set;
        }
        double fetchStart
        {
            get;
            set;
        }
        double requestStart
        {
            get;
            set;
        }
        double domInteractive
        {
            get;
            set;
        }
        double navigationStart
        {
            get;
            set;
        }
        double connectEnd
        {
            get;
            set;
        }
        double loadEventEnd
        {
            get;
            set;
        }
        double connectStart
        {
            get;
            set;
        }
        double responseEnd
        {
            get;
            set;
        }
        double domLoading
        {
            get;
            set;
        }
        double redirectEnd
        {
            get;
            set;
        }
        double unloadEventStart
        {
            get;
            set;
        }
        double domContentLoadedEventStart
        {
            get;
            set;
        }
        double domContentLoadedEventEnd
        {
            get;
            set;
        }
        object toJSON();
    }
    public partial interface HTMLPreElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        double width
        {
            get;
            set;
        }
        string cite
        {
            get;
            set;
        }
    }
    public partial interface EventException
    {
        double code
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string.ToString();
        double DISPATCH_REQUEST_ERR
        {
            get;
            set;
        }
        double UNSPECIFIED_EVENT_TYPE_ERR
        {
            get;
            set;
        }
    }
    public partial interface MSNavigatorDoNotTrack
    {
        string msDoNotTrack
        {
            get;
            set;
        }
        void removeSiteSpecificTrackingException(ExceptionInformation args);
        void removeWebWideTrackingException(ExceptionInformation args);
        void storeWebWideTrackingException(StoreExceptionsInformation args);
        void storeSiteSpecificTrackingException(StoreSiteSpecificExceptionsInformation args);
        bool confirmSiteSpecificTrackingException(ConfirmSiteSpecificExceptionsInformation args);
        bool confirmWebWideTrackingException(ExceptionInformation args);
    }
    public partial interface NavigatorOnLine
    {
        bool onLine
        {
            get;
            set;
        }
    }
    public partial interface WindowLocalStorage
    {
        Storage localStorage
        {
            get;
            set;
        }
    }
    public partial interface SVGMetadataElement : SVGElement { }
    public partial interface SVGPathSegArcRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        bool sweepFlag
        {
            get;
            set;
        }
        double r2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double angle
        {
            get;
            set;
        }
        double r1
        {
            get;
            set;
        }
        bool largeArcFlag
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegMovetoAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
    }
    public partial interface SVGStringList
    {
        double numberOfItems
        {
            get;
            set;
        }
        string replaceItem(string newItem, double index);
        string getItem(double index);
        void clear();
        string appendItem(string newItem);
        string initialize(string newItem);
        string removeItem(double index);
        string insertItemBefore(string newItem, double index);
    }
    public partial interface XDomainRequest
    {
        double timeout
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<Event, object> ontimeout
        {
            get;
            set;
        }
        string responseText
        {
            get;
            set;
        }
        string contentType
        {
            get;
            set;
        }
        void open(string method, string url);
        void abort();
        void send(object data = null);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface DOML2DeprecatedBackgroundColorStyle
    {
        object bgColor
        {
            get;
            set;
        }
    }
    public partial interface ElementTraversal
    {
        double childElementCount
        {
            get;
            set;
        }
        Element previousElementSibling
        {
            get;
            set;
        }
        Element lastElementChild
        {
            get;
            set;
        }
        Element nextElementSibling
        {
            get;
            set;
        }
        Element firstElementChild
        {
            get;
            set;
        }
    }
    public partial interface SVGLength
    {
        string valueAsString
        {
            get;
            set;
        }
        double valueInSpecifiedUnits
        {
            get;
            set;
        }
        double value
        {
            get;
            set;
        }
        double unitType
        {
            get;
            set;
        }
        void newValueSpecifiedUnits(double unitType, double valueInSpecifiedUnits);
        void convertToSpecifiedUnits(double unitType);
        double SVG_LENGTHTYPE_NUMBER
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_CM
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_PC
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_PERCENTAGE
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_MM
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_PT
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_IN
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_EMS
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_PX
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_LENGTHTYPE_EXS
        {
            get;
            set;
        }
    }
    public partial interface SVGPolygonElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGAnimatedPoints, SVGTests, SVGExternalResourcesRequired { }
    public partial interface HTMLPhraseElement : HTMLElement
    {
        string dateTime
        {
            get;
            set;
        }
        string cite
        {
            get;
            set;
        }
    }
    public partial interface NavigatorStorageUtils { }
    public partial interface SVGPathSegCurvetoCubicRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double y1
        {
            get;
            set;
        }
        double x2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double x1
        {
            get;
            set;
        }
        double y2
        {
            get;
            set;
        }
    }
    public partial interface SVGTextContentElement : SVGElement, SVGStylable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength textLength
        {
            get;
            set;
        }
        SVGAnimatedEnumeration lengthAdjust
        {
            get;
            set;
        }
        double getCharNumAtPosition(SVGPoint point);
        SVGPoint getStartPositionOfChar(double charnum);
        SVGRect getExtentOfChar(double charnum);
        double getComputedTextLength();
        double getSubStringLength(double charnum, double nchars);
        void selectSubString(double charnum, double nchars);
        double getNumberOfChars();
        double getRotationOfChar(double charnum);
        SVGPoint getEndPositionOfChar(double charnum);
        double LENGTHADJUST_SPACING
        {
            get;
            set;
        }
        double LENGTHADJUST_SPACINGANDGLYPHS
        {
            get;
            set;
        }
        double LENGTHADJUST_UNKNOWN
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedColorProperty
    {
        string color
        {
            get;
            set;
        }
    }
    public partial interface Location
    {
        string hash
        {
            get;
            set;
        }
        string protocol
        {
            get;
            set;
        }
        string search
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        string hostname
        {
            get;
            set;
        }
        string port
        {
            get;
            set;
        }
        string pathname
        {
            get;
            set;
        }
        string host
        {
            get;
            set;
        }
        void reload(bool flag = false);
        void replace(string url);
        void assign(string url);
        string.ToString();
    }
    public partial interface HTMLTitleElement : HTMLElement
    {
        string text
        {
            get;
            set;
        }
    }
    public partial interface HTMLStyleElement : HTMLElement, LinkStyle
    {
        string media
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
    }
    public partial interface PerformanceEntry
    {
        string name
        {
            get;
            set;
        }
        double startTime
        {
            get;
            set;
        }
        double duration
        {
            get;
            set;
        }
        string entryType
        {
            get;
            set;
        }
    }
    public partial interface SVGTransform
    {
        double type
        {
            get;
            set;
        }
        double angle
        {
            get;
            set;
        }
        SVGMatrix matrix
        {
            get;
            set;
        }
        void setTranslate(double tx, double ty);
        void setScale(double sx, double sy);
        void setMatrix(SVGMatrix matrix);
        void setSkewY(double angle);
        void setRotate(double angle, double cx, double cy);
        void setSkewX(double angle);
        double SVG_TRANSFORM_SKEWX
        {
            get;
            set;
        }
        double SVG_TRANSFORM_UNKNOWN
        {
            get;
            set;
        }
        double SVG_TRANSFORM_SCALE
        {
            get;
            set;
        }
        double SVG_TRANSFORM_TRANSLATE
        {
            get;
            set;
        }
        double SVG_TRANSFORM_MATRIX
        {
            get;
            set;
        }
        double SVG_TRANSFORM_ROTATE
        {
            get;
            set;
        }
        double SVG_TRANSFORM_SKEWY
        {
            get;
            set;
        }
    }
    public partial interface UIEvent : Event
    {
        double detail
        {
            get;
            set;
        }
        Window view
        {
            get;
            set;
        }
        void initUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg);
    }
    public partial interface SVGURIReference
    {
        SVGAnimatedString href
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSeg
    {
        double pathSegType
        {
            get;
            set;
        }
        string pathSegTypeAsLetter
        {
            get;
            set;
        }
        double PATHSEG_MOVETO_REL
        {
            get;
            set;
        }
        double PATHSEG_LINETO_VERTICAL_REL
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_CUBIC_SMOOTH_ABS
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_QUADRATIC_REL
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_CUBIC_ABS
        {
            get;
            set;
        }
        double PATHSEG_LINETO_HORIZONTAL_ABS
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_QUADRATIC_ABS
        {
            get;
            set;
        }
        double PATHSEG_LINETO_ABS
        {
            get;
            set;
        }
        double PATHSEG_CLOSEPATH
        {
            get;
            set;
        }
        double PATHSEG_LINETO_HORIZONTAL_REL
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_CUBIC_SMOOTH_REL
        {
            get;
            set;
        }
        double PATHSEG_LINETO_REL
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_QUADRATIC_SMOOTH_ABS
        {
            get;
            set;
        }
        double PATHSEG_ARC_REL
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_CUBIC_REL
        {
            get;
            set;
        }
        double PATHSEG_UNKNOWN
        {
            get;
            set;
        }
        double PATHSEG_LINETO_VERTICAL_ABS
        {
            get;
            set;
        }
        double PATHSEG_ARC_ABS
        {
            get;
            set;
        }
        double PATHSEG_MOVETO_ABS
        {
            get;
            set;
        }
        double PATHSEG_CURVETO_QUADRATIC_SMOOTH_REL
        {
            get;
            set;
        }
    }
    public partial interface WheelEvent : MouseEvent
    {
        double deltaZ
        {
            get;
            set;
        }
        double deltaX
        {
            get;
            set;
        }
        double deltaMode
        {
            get;
            set;
        }
        double deltaY
        {
            get;
            set;
        }
        void initWheelEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, double buttonArg, EventTarget relatedTargetArg, string modifiersListArg, double deltaXArg, double deltaYArg, double deltaZArg, double deltaMode);
        void getCurrentPoint(Element element);
        double DOM_DELTA_PIXEL
        {
            get;
            set;
        }
        double DOM_DELTA_LINE
        {
            get;
            set;
        }
        double DOM_DELTA_PAGE
        {
            get;
            set;
        }
    }
    public partial interface MSEventAttachmentTarget
    {
        bool attachEvent(string _event, EventListener listener);
        void detachEvent(string _event, EventListener listener);
    }
    public partial interface SVGNumber
    {
        double value
        {
            get;
            set;
        }
    }
    public partial interface SVGPathElement : SVGElement, SVGStylable, SVGAnimatedPathData, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        double getPathSegAtLength(double distance);
        SVGPoint getPointAtLength(double distance);
        SVGPathSegCurvetoQuadraticAbs createSVGPathSegCurvetoQuadraticAbs(double x, double y, double x1, double y1);
        SVGPathSegLinetoRel createSVGPathSegLinetoRel(double x, double y);
        SVGPathSegCurvetoQuadraticRel createSVGPathSegCurvetoQuadraticRel(double x, double y, double x1, double y1);
        SVGPathSegCurvetoCubicAbs createSVGPathSegCurvetoCubicAbs(double x, double y, double x1, double y1, double x2, double y2);
        SVGPathSegLinetoAbs createSVGPathSegLinetoAbs(double x, double y);
        SVGPathSegClosePath createSVGPathSegClosePath();
        SVGPathSegCurvetoCubicRel createSVGPathSegCurvetoCubicRel(double x, double y, double x1, double y1, double x2, double y2);
        SVGPathSegCurvetoQuadraticSmoothRel createSVGPathSegCurvetoQuadraticSmoothRel(double x, double y);
        SVGPathSegMovetoRel createSVGPathSegMovetoRel(double x, double y);
        SVGPathSegCurvetoCubicSmoothAbs createSVGPathSegCurvetoCubicSmoothAbs(double x, double y, double x2, double y2);
        SVGPathSegMovetoAbs createSVGPathSegMovetoAbs(double x, double y);
        SVGPathSegLinetoVerticalRel createSVGPathSegLinetoVerticalRel(double y);
        SVGPathSegArcRel createSVGPathSegArcRel(double x, double y, double r1, double r2, double angle, bool largeArcFlag, bool sweepFlag);
        SVGPathSegCurvetoQuadraticSmoothAbs createSVGPathSegCurvetoQuadraticSmoothAbs(double x, double y);
        SVGPathSegLinetoHorizontalRel createSVGPathSegLinetoHorizontalRel(double x);
        double getTotalLength();
        SVGPathSegCurvetoCubicSmoothRel createSVGPathSegCurvetoCubicSmoothRel(double x, double y, double x2, double y2);
        SVGPathSegLinetoHorizontalAbs createSVGPathSegLinetoHorizontalAbs(double x);
        SVGPathSegLinetoVerticalAbs createSVGPathSegLinetoVerticalAbs(double y);
        SVGPathSegArcAbs createSVGPathSegArcAbs(double x, double y, double r1, double r2, double angle, bool largeArcFlag, bool sweepFlag);
    }
    public partial interface MSCompatibleInfo
    {
        string version
        {
            get;
            set;
        }
        string userAgent
        {
            get;
            set;
        }
    }
    public partial interface Text : CharacterData, MSNodeExtensions
    {
        string wholeText
        {
            get;
            set;
        }
        Text splitText(double offset);
        Text replaceWholeText(string content);
    }
    public partial interface SVGAnimatedRect
    {
        SVGRect animVal
        {
            get;
            set;
        }
        SVGRect baseVal
        {
            get;
            set;
        }
    }
    public partial interface CSSNamespaceRule : CSSRule
    {
        string namespaceURI
        {
            get;
            set;
        }
        string prefix
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegList
    {
        double numberOfItems
        {
            get;
            set;
        }
        SVGPathSeg replaceItem(SVGPathSeg newItem, double index);
        SVGPathSeg getItem(double index);
        void clear();
        SVGPathSeg appendItem(SVGPathSeg newItem);
        SVGPathSeg initialize(SVGPathSeg newItem);
        SVGPathSeg removeItem(double index);
        SVGPathSeg insertItemBefore(SVGPathSeg newItem, double index);
    }
    public partial interface HTMLUnknownElement : HTMLElement, MSDataBindingRecordSetReadonlyExtensions { }
    public partial interface HTMLAudioElement : HTMLMediaElement { }
    public partial interface MSImageResourceExtensions
    {
        string dynsrc
        {
            get;
            set;
        }
        string vrml
        {
            get;
            set;
        }
        string lowsrc
        {
            get;
            set;
        }
        string start
        {
            get;
            set;
        }
        double loop
        {
            get;
            set;
        }
    }
    public partial interface PositionError
    {
        double code
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        string.ToString();
        double POSITION_UNAVAILABLE
        {
            get;
            set;
        }
        double PERMISSION_DENIED
        {
            get;
            set;
        }
        double TIMEOUT
        {
            get;
            set;
        }
    }
    public partial interface HTMLTableCellElement : HTMLElement, HTMLTableAlignment, DOML2DeprecatedBackgroundStyle, DOML2DeprecatedBackgroundColorStyle
    {
        double width
        {
            get;
            set;
        }
        string headers
        {
            get;
            set;
        }
        double cellIndex
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        object borderColorLight
        {
            get;
            set;
        }
        double colSpan
        {
            get;
            set;
        }
        object borderColor
        {
            get;
            set;
        }
        string axis
        {
            get;
            set;
        }
        object height
        {
            get;
            set;
        }
        bool noWrap
        {
            get;
            set;
        }
        string abbr
        {
            get;
            set;
        }
        double rowSpan
        {
            get;
            set;
        }
        string scope
        {
            get;
            set;
        }
        object borderColorDark
        {
            get;
            set;
        }
    }
    public partial interface SVGElementInstance : EventTarget
    {
        SVGElementInstance previousSibling
        {
            get;
            set;
        }
        SVGElementInstance parentNode
        {
            get;
            set;
        }
        SVGElementInstance lastChild
        {
            get;
            set;
        }
        SVGElementInstance nextSibling
        {
            get;
            set;
        }
        SVGElementInstanceList childNodes
        {
            get;
            set;
        }
        SVGUseElement correspondingUseElement
        {
            get;
            set;
        }
        SVGElement correspondingElement
        {
            get;
            set;
        }
        SVGElementInstance firstChild
        {
            get;
            set;
        }
    }
    public partial interface MSNamespaceInfoCollection
    {
        double Length
        {
            get;
            set;
        }
        object add(string _namespace = null, string urn = null, object implementationUrl = null);
        object item(object index);
    }
    public partial interface SVGCircleElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength cx
        {
            get;
            set;
        }
        SVGAnimatedLength r
        {
            get;
            set;
        }
        SVGAnimatedLength cy
        {
            get;
            set;
        }
    }
    public partial interface StyleSheetList
    {
        double Length
        {
            get;
            set;
        }
        StyleSheet item(double index = 0.0);
        StyleSheet this[double index]
        {
            get;
            set;
        }
    }
    public partial interface CSSImportRule : CSSRule
    {
        CSSStyleSheet styleSheet
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        MediaList media
        {
            get;
            set;
        }
    }
    public partial interface CustomEvent : Event
    {
        object detail
        {
            get;
            set;
        }
        void initCustomEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object detailArg);
    }
    public partial interface HTMLBaseFontElement : HTMLElement, DOML2DeprecatedColorProperty
    {
        string face
        {
            get;
            set;
        }
        double size
        {
            get;
            set;
        }
    }
    public partial interface HTMLTextAreaElement : HTMLElement, MSDataBindingExtensions
    {
        string value
        {
            get;
            set;
        }
        object status
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        double selectionStart
        {
            get;
            set;
        }
        double rows
        {
            get;
            set;
        }
        double cols
        {
            get;
            set;
        }
        bool readOnly
        {
            get;
            set;
        }
        string wrap
        {
            get;
            set;
        }
        double selectionEnd
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string defaultValue
        {
            get;
            set;
        }
        string validationMessage
        {
            get;
            set;
        }
        bool autofocus
        {
            get;
            set;
        }
        ValidityState validity
        {
            get;
            set;
        }
        bool required
        {
            get;
            set;
        }
        double maxLength
        {
            get;
            set;
        }
        bool willValidate
        {
            get;
            set;
        }
        string placeholder
        {
            get;
            set;
        }
        TextRange createTextRange();
        void setSelectionRange(double start, double end);
        void select();
        bool checkValidity();
        void setCustomValidity(string error);
    }
    public partial interface Geolocation
    {
        void clearWatch(double watchId);
        void getCurrentPosition(PositionCallback successCallback, PositionErrorCallback errorCallback = null, PositionOptions options = null);
        double watchPosition(PositionCallback successCallback, PositionErrorCallback errorCallback = null, PositionOptions options = null);
    }
    public partial interface DOML2DeprecatedMarginStyle
    {
        double vspace
        {
            get;
            set;
        }
        double hspace
        {
            get;
            set;
        }
    }
    public partial interface MSWindowModeless
    {
        object dialogTop
        {
            get;
            set;
        }
        object dialogLeft
        {
            get;
            set;
        }
        object dialogWidth
        {
            get;
            set;
        }
        object dialogHeight
        {
            get;
            set;
        }
        object menuArguments
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedAlignmentStyle
    {
        string align
        {
            get;
            set;
        }
    }
    public partial interface HTMLMarqueeElement : HTMLElement, MSDataBindingExtensions, DOML2DeprecatedBackgroundColorStyle
    {
        string width
        {
            get;
            set;
        }
        System.Func<Event, object> onbounce
        {
            get;
            set;
        }
        double vspace
        {
            get;
            set;
        }
        bool trueSpeed
        {
            get;
            set;
        }
        double scrollAmount
        {
            get;
            set;
        }
        double scrollDelay
        {
            get;
            set;
        }
        string behavior
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        double loop
        {
            get;
            set;
        }
        string direction
        {
            get;
            set;
        }
        double hspace
        {
            get;
            set;
        }
        System.Func<Event, object> onstart
        {
            get;
            set;
        }
        System.Func<Event, object> onfinish
        {
            get;
            set;
        }
        void stop();
        void start();
    }
    public partial interface SVGRect
    {
        double y
        {
            get;
            set;
        }
        double width
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
    }
    public partial interface MSNodeExtensions
    {
        Node swapNode(Node otherNode);
        Node removeNode(bool deep = false);
        Node replaceNode(Node replacement);
    }
    public partial interface History
    {
        double Length
        {
            get;
            set;
        }
        object state
        {
            get;
            set;
        }
        void back(object distance = null);
        void forward(object distance = null);
        void go(object delta = null);
        void replaceState(object statedata, string title, string url = null);
        void pushState(object statedata, string title, string url = null);
    }
    public partial interface SVGPathSegCurvetoCubicAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double y1
        {
            get;
            set;
        }
        double x2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double x1
        {
            get;
            set;
        }
        double y2
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegCurvetoQuadraticAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double y1
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double x1
        {
            get;
            set;
        }
    }
    public partial interface TimeRanges
    {
        double Length
        {
            get;
            set;
        }
        double start(double index);
        double end(double index);
    }
    public partial interface CSSRule
    {
        string cssText
        {
            get;
            set;
        }
        CSSStyleSheet parentStyleSheet
        {
            get;
            set;
        }
        CSSRule parentRule
        {
            get;
            set;
        }
        double type
        {
            get;
            set;
        }
        double IMPORT_RULE
        {
            get;
            set;
        }
        double MEDIA_RULE
        {
            get;
            set;
        }
        double STYLE_RULE
        {
            get;
            set;
        }
        double NAMESPACE_RULE
        {
            get;
            set;
        }
        double PAGE_RULE
        {
            get;
            set;
        }
        double UNKNOWN_RULE
        {
            get;
            set;
        }
        double FONT_FACE_RULE
        {
            get;
            set;
        }
        double CHARSET_RULE
        {
            get;
            set;
        }
        double KEYFRAMES_RULE
        {
            get;
            set;
        }
        double KEYFRAME_RULE
        {
            get;
            set;
        }
        double VIEWPORT_RULE
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegLinetoAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
    }
    public partial interface HTMLModElement : HTMLElement
    {
        string dateTime
        {
            get;
            set;
        }
        string cite
        {
            get;
            set;
        }
    }
    public partial interface SVGMatrix
    {
        double e
        {
            get;
            set;
        }
        double c
        {
            get;
            set;
        }
        double a
        {
            get;
            set;
        }
        double b
        {
            get;
            set;
        }
        double d
        {
            get;
            set;
        }
        double f
        {
            get;
            set;
        }
        SVGMatrix multiply(SVGMatrix secondMatrix);
        SVGMatrix flipY();
        SVGMatrix skewY(double angle);
        SVGMatrix inverse();
        SVGMatrix scaleNonUniform(double scaleFactorX, double scaleFactorY);
        SVGMatrix rotate(double angle);
        SVGMatrix flipX();
        SVGMatrix translate(double x, double y);
        SVGMatrix scale(double scaleFactor);
        SVGMatrix rotateFromVector(double x, double y);
        SVGMatrix skewX(double angle);
    }
    public partial interface MSPopupWindow
    {
        Document document
        {
            get;
            set;
        }
        bool isOpen
        {
            get;
            set;
        }
        void show(double x, double y, double w, double h, object element = null);
        void hide();
    }
    public partial interface BeforeUnloadEvent : Event
    {
        string returnValue
        {
            get;
            set;
        }
    }
    public partial interface SVGUseElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGElementInstance animatedInstanceRoot
        {
            get;
            set;
        }
        SVGElementInstance instanceRoot
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
    }
    public partial interface Event
    {
        double timeStamp
        {
            get;
            set;
        }
        bool defaultPrevented
        {
            get;
            set;
        }
        bool isTrusted
        {
            get;
            set;
        }
        EventTarget currentTarget
        {
            get;
            set;
        }
        bool cancelBubble
        {
            get;
            set;
        }
        EventTarget target
        {
            get;
            set;
        }
        double eventPhase
        {
            get;
            set;
        }
        bool cancelable
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        Element srcElement
        {
            get;
            set;
        }
        bool bubbles
        {
            get;
            set;
        }
        void initEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg);
        void stopPropagation();
        void stopImmediatePropagation();
        void preventDefault();
        double CAPTURING_PHASE
        {
            get;
            set;
        }
        double AT_TARGET
        {
            get;
            set;
        }
        double BUBBLING_PHASE
        {
            get;
            set;
        }
    }
    public partial interface ImageData
    {
        double width
        {
            get;
            set;
        }
        Array<double> data
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
    }
    public partial interface HTMLTableColElement : HTMLElement, HTMLTableAlignment
    {
        object width
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        double span
        {
            get;
            set;
        }
    }
    public partial interface SVGException
    {
        double code
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string.ToString();
        double SVG_MATRIX_NOT_INVERTABLE
        {
            get;
            set;
        }
        double SVG_WRONG_TYPE_ERR
        {
            get;
            set;
        }
        double SVG_INVALID_VALUE_ERR
        {
            get;
            set;
        }
    }
    public partial interface SVGLinearGradientElement : SVGGradientElement
    {
        SVGAnimatedLength y1
        {
            get;
            set;
        }
        SVGAnimatedLength x2
        {
            get;
            set;
        }
        SVGAnimatedLength x1
        {
            get;
            set;
        }
        SVGAnimatedLength y2
        {
            get;
            set;
        }
    }
    public partial interface HTMLTableAlignment
    {
        string ch
        {
            get;
            set;
        }
        string vAlign
        {
            get;
            set;
        }
        string chOff
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedEnumeration
    {
        double animVal
        {
            get;
            set;
        }
        double baseVal
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedSizeProperty
    {
        double size
        {
            get;
            set;
        }
    }
    public partial interface HTMLUListElement : HTMLElement, DOML2DeprecatedListSpaceReduction, DOML2DeprecatedListNumberingAndBulletStyle { }
    public partial interface SVGRectElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedLength ry
        {
            get;
            set;
        }
        SVGAnimatedLength rx
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
    }
    public delegate void ErrorEventHandler(Event _event, string source, double fileno, double columnNumber);
    public partial interface HTMLDivElement : HTMLElement, MSDataBindingExtensions
    {
        string align
        {
            get;
            set;
        }
        bool noWrap
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedBorderStyle
    {
        string border
        {
            get;
            set;
        }
    }
    public partial interface NamedNodeMap
    {
        double Length
        {
            get;
            set;
        }
        Attr removeNamedItemNS(string namespaceURI, string localName);
        Attr item(double index);
        Attr this[double index]
        {
            get;
            set;
        }
        Attr removeNamedItem(string name);
        Attr getNamedItem(string name);
        Attr setNamedItem(Attr arg);
        Attr getNamedItemNS(string namespaceURI, string localName);
        Attr setNamedItemNS(Attr arg);
    }
    public partial interface MediaList
    {
        double Length
        {
            get;
            set;
        }
        string mediaText
        {
            get;
            set;
        }
        void deleteMedium(string oldMedium);
        void appendMedium(string newMedium);
        string item(double index);
        string this[double index]
        {
            get;
            set;
        }
        string.ToString();
    }
    public partial interface SVGPathSegCurvetoQuadraticSmoothAbs : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegCurvetoCubicSmoothRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double y2
        {
            get;
            set;
        }
    }
    public partial interface SVGLengthList
    {
        double numberOfItems
        {
            get;
            set;
        }
        SVGLength replaceItem(SVGLength newItem, double index);
        SVGLength getItem(double index);
        void clear();
        SVGLength appendItem(SVGLength newItem);
        SVGLength initialize(SVGLength newItem);
        SVGLength removeItem(double index);
        SVGLength insertItemBefore(SVGLength newItem, double index);
    }
    public partial interface ProcessingInstruction : Node
    {
        string target
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
    }
    public partial interface MSWindowExtensions
    {
        string status
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseleave
        {
            get;
            set;
        }
        double screenLeft
        {
            get;
            set;
        }
        object offscreenBuffering
        {
            get;
            set;
        }
        double maxConnectionsPerServer
        {
            get;
            set;
        }
        System.Func<MouseEvent, object> onmouseenter
        {
            get;
            set;
        }
        DataTransfer clipboardData
        {
            get;
            set;
        }
        string defaultStatus
        {
            get;
            set;
        }
        Navigator clientInformation
        {
            get;
            set;
        }
        bool closed
        {
            get;
            set;
        }
        System.Func<Event, object> onhelp
        {
            get;
            set;
        }
        External external
        {
            get;
            set;
        }
        MSEventObj _event
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusout
        {
            get;
            set;
        }
        double screenTop
        {
            get;
            set;
        }
        System.Func<FocusEvent, object> onfocusin
        {
            get;
            set;
        }
        Window showModelessDialog(string url = null, object argument = null, object options = null);
        void navigate(string url);
        void resizeBy(double x = 0.0, double y = 0.0);
        object item(object index);
        void resizeTo(double x = 0.0, double y = 0.0);
        MSPopupWindow createPopup(object arguments = null);
        string toStaticHTML(string html);
        object execScript(string code, string language = null);
        void msWriteProfilerMark(string profilerMarkName);
        void moveTo(double x = 0.0, double y = 0.0);
        void moveBy(double x = 0.0, double y = 0.0);
        void showHelp(string url, object helpArg = null, string features = null);
        void captureEvents();
        void releaseEvents();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface MSBehaviorUrnsCollection
    {
        double Length
        {
            get;
            set;
        }
        string item(double index);
    }
    public partial interface CSSFontFaceRule : CSSRule
    {
        CSSStyleDeclaration style
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedBackgroundStyle
    {
        string background
        {
            get;
            set;
        }
    }
    public partial interface TextEvent : UIEvent
    {
        double inputMethod
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
        string locale
        {
            get;
            set;
        }
        void initTextEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, double inputMethod, string locale);
        double DOM_INPUT_METHOD_KEYBOARD
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_DROP
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_IME
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_SCRIPT
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_VOICE
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_UNKNOWN
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_PASTE
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_HANDWRITING
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_OPTION
        {
            get;
            set;
        }
        double DOM_INPUT_METHOD_MULTIMODAL
        {
            get;
            set;
        }
    }
    public partial interface DocumentFragment : Node, NodeSelector, MSEventAttachmentTarget, MSNodeExtensions { }
    public partial interface SVGPolylineElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGAnimatedPoints, SVGTests, SVGExternalResourcesRequired { }
    public partial interface SVGAnimatedPathData
    {
        SVGPathSegList pathSegList
        {
            get;
            set;
        }
    }
    public partial interface Position
    {
        Date timestamp
        {
            get;
            set;
        }
        Coordinates coords
        {
            get;
            set;
        }
    }
    public partial interface BookmarkCollection
    {
        double Length
        {
            get;
            set;
        }
        object item(double index);
        object this[double index]
        {
            get;
            set;
        }
    }
    public partial interface PerformanceMark : PerformanceEntry { }
    public partial interface CSSPageRule : CSSRule
    {
        string pseudoClass
        {
            get;
            set;
        }
        string selectorText
        {
            get;
            set;
        }
        string selector
        {
            get;
            set;
        }
        CSSStyleDeclaration style
        {
            get;
            set;
        }
    }
    public partial interface HTMLBRElement : HTMLElement
    {
        string clear
        {
            get;
            set;
        }
    }
    public partial interface MSNavigatorExtensions
    {
        string userLanguage
        {
            get;
            set;
        }
        MSPluginsCollection plugins
        {
            get;
            set;
        }
        bool cookieEnabled
        {
            get;
            set;
        }
        string appCodeName
        {
            get;
            set;
        }
        string cpuClass
        {
            get;
            set;
        }
        string appMinorVersion
        {
            get;
            set;
        }
        double connectionSpeed
        {
            get;
            set;
        }
        string browserLanguage
        {
            get;
            set;
        }
        MSMimeTypesCollection mimeTypes
        {
            get;
            set;
        }
        string systemLanguage
        {
            get;
            set;
        }
        string language
        {
            get;
            set;
        }
        bool javaEnabled();
        bool taintEnabled();
    }
    public partial interface HTMLSpanElement : HTMLElement, MSDataBindingExtensions { }
    public partial interface HTMLHeadElement : HTMLElement
    {
        string profile
        {
            get;
            set;
        }
    }
    public partial interface HTMLHeadingElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        string align
        {
            get;
            set;
        }
    }
    public partial interface HTMLFormElement : HTMLElement, MSHTMLCollectionExtensions
    {
        double Length
        {
            get;
            set;
        }
        string target
        {
            get;
            set;
        }
        string acceptCharset
        {
            get;
            set;
        }
        string enctype
        {
            get;
            set;
        }
        HTMLCollection elements
        {
            get;
            set;
        }
        string action
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string method
        {
            get;
            set;
        }
        string encoding
        {
            get;
            set;
        }
        string autocomplete
        {
            get;
            set;
        }
        bool noValidate
        {
            get;
            set;
        }
        void reset();
        object item(object name = null, object index = null);
        void submit();
        object namedItem(string name);
        object this[string name]
        {
            get;
            set;
        }
        bool checkValidity();
    }
    public partial interface SVGZoomAndPan
    {
        double zoomAndPan
        {
            get;
            set;
        }
        double SVG_ZOOMANDPAN_MAGNIFY
        {
            get;
            set;
        }
        double SVG_ZOOMANDPAN_UNKNOWN
        {
            get;
            set;
        }
        double SVG_ZOOMANDPAN_DISABLE
        {
            get;
            set;
        }
    }
    public partial interface HTMLMediaElement : HTMLElement
    {
        double initialTime
        {
            get;
            set;
        }
        TimeRanges played
        {
            get;
            set;
        }
        string currentSrc
        {
            get;
            set;
        }
        object readyState
        {
            get;
            set;
        }
        bool autobuffer
        {
            get;
            set;
        }
        bool loop
        {
            get;
            set;
        }
        bool ended
        {
            get;
            set;
        }
        TimeRanges buffered
        {
            get;
            set;
        }
        MediaError error
        {
            get;
            set;
        }
        TimeRanges seekable
        {
            get;
            set;
        }
        bool autoplay
        {
            get;
            set;
        }
        bool controls
        {
            get;
            set;
        }
        double volume
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        double playbackRate
        {
            get;
            set;
        }
        double duration
        {
            get;
            set;
        }
        bool muted
        {
            get;
            set;
        }
        double defaultPlaybackRate
        {
            get;
            set;
        }
        bool paused
        {
            get;
            set;
        }
        bool seeking
        {
            get;
            set;
        }
        double currentTime
        {
            get;
            set;
        }
        string preload
        {
            get;
            set;
        }
        double networkState
        {
            get;
            set;
        }
        string msAudioCategory
        {
            get;
            set;
        }
        bool msRealTime
        {
            get;
            set;
        }
        bool msPlayToPrimary
        {
            get;
            set;
        }
        TextTrackList textTracks
        {
            get;
            set;
        }
        bool msPlayToDisabled
        {
            get;
            set;
        }
        AudioTrackList audioTracks
        {
            get;
            set;
        }
        object msPlayToSource
        {
            get;
            set;
        }
        string msAudioDeviceType
        {
            get;
            set;
        }
        string msPlayToPreferredSourceUri
        {
            get;
            set;
        }
        System.Func<MSMediaKeyNeededEvent, object> onmsneedkey
        {
            get;
            set;
        }
        MSMediaKeys msKeys
        {
            get;
            set;
        }
        MSGraphicsTrust msGraphicsTrustStatus
        {
            get;
            set;
        }
        void pause();
        void play();
        void load();
        string canPlayType(string type);
        void msClearEffects();
        void msSetMediaProtectionManager(object mediaProtectionManager = null);
        void msInsertAudioEffect(string activatableClassId, bool effectRequired, object config = null);
        void msSetMediaKeys(MSMediaKeys mediaKeys);
        TextTrack addTextTrack(string kind, string label = null, string language = null);
        double HAVE_METADATA
        {
            get;
            set;
        }
        double HAVE_CURRENT_DATA
        {
            get;
            set;
        }
        double HAVE_NOTHING
        {
            get;
            set;
        }
        double NETWORK_NO_SOURCE
        {
            get;
            set;
        }
        double HAVE_ENOUGH_DATA
        {
            get;
            set;
        }
        double NETWORK_EMPTY
        {
            get;
            set;
        }
        double NETWORK_LOADING
        {
            get;
            set;
        }
        double NETWORK_IDLE
        {
            get;
            set;
        }
        double HAVE_FUTURE_DATA
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface ElementCSSInlineStyle
    {
        MSStyleCSSProperties runtimeStyle
        {
            get;
            set;
        }
        MSCurrentStyleCSSProperties currentStyle
        {
            get;
            set;
        }
        void doScroll(object component = null);
        string componentFromPoint(double x, double y);
    }
    public partial interface DOMParser
    {
        Document parseFromString(string source, string mimeType);
    }
    public partial interface MSMimeTypesCollection
    {
        double Length
        {
            get;
            set;
        }
    }
    public partial interface StyleSheet
    {
        bool disabled
        {
            get;
            set;
        }
        Node ownerNode
        {
            get;
            set;
        }
        StyleSheet parentStyleSheet
        {
            get;
            set;
        }
        string href
        {
            get;
            set;
        }
        MediaList media
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string title
        {
            get;
            set;
        }
    }
    public partial interface SVGTextPathElement : SVGTextContentElement, SVGURIReference
    {
        SVGAnimatedLength startOffset
        {
            get;
            set;
        }
        SVGAnimatedEnumeration method
        {
            get;
            set;
        }
        SVGAnimatedEnumeration spacing
        {
            get;
            set;
        }
        double TEXTPATH_SPACINGTYPE_EXACT
        {
            get;
            set;
        }
        double TEXTPATH_METHODTYPE_STRETCH
        {
            get;
            set;
        }
        double TEXTPATH_SPACINGTYPE_AUTO
        {
            get;
            set;
        }
        double TEXTPATH_SPACINGTYPE_UNKNOWN
        {
            get;
            set;
        }
        double TEXTPATH_METHODTYPE_UNKNOWN
        {
            get;
            set;
        }
        double TEXTPATH_METHODTYPE_ALIGN
        {
            get;
            set;
        }
    }
    public partial interface HTMLDTElement : HTMLElement
    {
        bool noWrap
        {
            get;
            set;
        }
    }
    public partial interface NodeList
    {
        double Length
        {
            get;
            set;
        }
        Node item(double index);
        Node this[double index]
        {
            get;
            set;
        }
    }
    public partial interface XMLSerializer
    {
        string serializeToString(Node target);
    }
    public partial interface PerformanceMeasure : PerformanceEntry { }
    public partial interface SVGGradientElement : SVGElement, SVGUnitTypes, SVGStylable, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedEnumeration spreadMethod
        {
            get;
            set;
        }
        SVGAnimatedTransformList gradientTransform
        {
            get;
            set;
        }
        SVGAnimatedEnumeration gradientUnits
        {
            get;
            set;
        }
        double SVG_SPREADMETHOD_REFLECT
        {
            get;
            set;
        }
        double SVG_SPREADMETHOD_PAD
        {
            get;
            set;
        }
        double SVG_SPREADMETHOD_UNKNOWN
        {
            get;
            set;
        }
        double SVG_SPREADMETHOD_REPEAT
        {
            get;
            set;
        }
    }
    public partial interface NodeFilter
    {
        double acceptNode(Node n);
        double SHOW_ENTITY_REFERENCE
        {
            get;
            set;
        }
        double SHOW_NOTATION
        {
            get;
            set;
        }
        double SHOW_ENTITY
        {
            get;
            set;
        }
        double SHOW_DOCUMENT
        {
            get;
            set;
        }
        double SHOW_PROCESSING_INSTRUCTION
        {
            get;
            set;
        }
        double FILTER_REJECT
        {
            get;
            set;
        }
        double SHOW_CDATA_SECTION
        {
            get;
            set;
        }
        double FILTER_ACCEPT
        {
            get;
            set;
        }
        double SHOW_ALL
        {
            get;
            set;
        }
        double SHOW_DOCUMENT_TYPE
        {
            get;
            set;
        }
        double SHOW_TEXT
        {
            get;
            set;
        }
        double SHOW_ELEMENT
        {
            get;
            set;
        }
        double SHOW_COMMENT
        {
            get;
            set;
        }
        double FILTER_SKIP
        {
            get;
            set;
        }
        double SHOW_ATTRIBUTE
        {
            get;
            set;
        }
        double SHOW_DOCUMENT_FRAGMENT
        {
            get;
            set;
        }
    }
    public partial interface SVGNumberList
    {
        double numberOfItems
        {
            get;
            set;
        }
        SVGNumber replaceItem(SVGNumber newItem, double index);
        SVGNumber getItem(double index);
        void clear();
        SVGNumber appendItem(SVGNumber newItem);
        SVGNumber initialize(SVGNumber newItem);
        SVGNumber removeItem(double index);
        SVGNumber insertItemBefore(SVGNumber newItem, double index);
    }
    public partial interface MediaError
    {
        double code
        {
            get;
            set;
        }
        double msExtendedCode
        {
            get;
            set;
        }
        double MEDIA_ERR_ABORTED
        {
            get;
            set;
        }
        double MEDIA_ERR_NETWORK
        {
            get;
            set;
        }
        double MEDIA_ERR_SRC_NOT_SUPPORTED
        {
            get;
            set;
        }
        double MEDIA_ERR_DECODE
        {
            get;
            set;
        }
        double MS_MEDIA_ERR_ENCRYPTED
        {
            get;
            set;
        }
    }
    public partial interface HTMLFieldSetElement : HTMLElement
    {
        string align
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string validationMessage
        {
            get;
            set;
        }
        ValidityState validity
        {
            get;
            set;
        }
        bool willValidate
        {
            get;
            set;
        }
        bool checkValidity();
        void setCustomValidity(string error);
    }
    public partial interface HTMLBGSoundElement : HTMLElement
    {
        object balance
        {
            get;
            set;
        }
        object volume
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        double loop
        {
            get;
            set;
        }
    }
    public partial interface Comment : CharacterData
    {
        string text
        {
            get;
            set;
        }
    }
    public partial interface PerformanceResourceTiming : PerformanceEntry
    {
        double redirectStart
        {
            get;
            set;
        }
        double redirectEnd
        {
            get;
            set;
        }
        double domainLookupEnd
        {
            get;
            set;
        }
        double responseStart
        {
            get;
            set;
        }
        double domainLookupStart
        {
            get;
            set;
        }
        double fetchStart
        {
            get;
            set;
        }
        double requestStart
        {
            get;
            set;
        }
        double connectEnd
        {
            get;
            set;
        }
        double connectStart
        {
            get;
            set;
        }
        string initiatorType
        {
            get;
            set;
        }
        double responseEnd
        {
            get;
            set;
        }
    }
    public partial interface CanvasPattern { }
    public partial interface HTMLHRElement : HTMLElement, DOML2DeprecatedColorProperty, DOML2DeprecatedSizeProperty
    {
        double width
        {
            get;
            set;
        }
        string align
        {
            get;
            set;
        }
        bool noShade
        {
            get;
            set;
        }
    }
    public partial interface HTMLObjectElement : HTMLElement, GetSVGDocument, DOML2DeprecatedMarginStyle, DOML2DeprecatedBorderStyle, DOML2DeprecatedAlignmentStyle, MSDataBindingExtensions, MSDataBindingRecordSetExtensions
    {
        string width
        {
            get;
            set;
        }
        string codeType
        {
            get;
            set;
        }
        object _object
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string code
        {
            get;
            set;
        }
        string archive
        {
            get;
            set;
        }
        string standby
        {
            get;
            set;
        }
        string alt
        {
            get;
            set;
        }
        string classid
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string useMap
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        Document contentDocument
        {
            get;
            set;
        }
        string altHtml
        {
            get;
            set;
        }
        string codeBase
        {
            get;
            set;
        }
        bool declare
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string BaseHref
        {
            get;
            set;
        }
        string validationMessage
        {
            get;
            set;
        }
        ValidityState validity
        {
            get;
            set;
        }
        bool willValidate
        {
            get;
            set;
        }
        string msPlayToPreferredSourceUri
        {
            get;
            set;
        }
        bool msPlayToPrimary
        {
            get;
            set;
        }
        bool msPlayToDisabled
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        object msPlayToSource
        {
            get;
            set;
        }
        bool checkValidity();
        void setCustomValidity(string error);
    }
    public partial interface HTMLEmbedElement : HTMLElement, GetSVGDocument
    {
        string width
        {
            get;
            set;
        }
        string palette
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string hidden
        {
            get;
            set;
        }
        string pluginspage
        {
            get;
            set;
        }
        string height
        {
            get;
            set;
        }
        string units
        {
            get;
            set;
        }
        string msPlayToPreferredSourceUri
        {
            get;
            set;
        }
        bool msPlayToPrimary
        {
            get;
            set;
        }
        bool msPlayToDisabled
        {
            get;
            set;
        }
        string readyState
        {
            get;
            set;
        }
        object msPlayToSource
        {
            get;
            set;
        }
    }
    public partial interface StorageEvent : Event
    {
        object oldValue
        {
            get;
            set;
        }
        object newValue
        {
            get;
            set;
        }
        string url
        {
            get;
            set;
        }
        Storage storageArea
        {
            get;
            set;
        }
        string key
        {
            get;
            set;
        }
        void initStorageEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string keyArg, object oldValueArg, object newValueArg, string urlArg, Storage storageAreaArg);
    }
    public partial interface CharacterData : Node
    {
        double Length
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
        void deleteData(double offset, double count);
        void replaceData(double offset, double count, string arg);
        void appendData(string arg);
        void insertData(double offset, string arg);
        string substringData(double offset, double count);
    }
    public partial interface HTMLOptGroupElement : HTMLElement, MSDataBindingExtensions
    {
        double index
        {
            get;
            set;
        }
        bool defaultSelected
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        string value
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
        string label
        {
            get;
            set;
        }
        bool selected
        {
            get;
            set;
        }
    }
    public partial interface HTMLIsIndexElement : HTMLElement
    {
        HTMLFormElement form
        {
            get;
            set;
        }
        string action
        {
            get;
            set;
        }
        string prompt
        {
            get;
            set;
        }
    }
    public partial interface SVGPathSegLinetoRel : SVGPathSeg
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
    }
    public partial interface DOMException
    {
        double code
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string.ToString();
        double HIERARCHY_REQUEST_ERR
        {
            get;
            set;
        }
        double NO_MODIFICATION_ALLOWED_ERR
        {
            get;
            set;
        }
        double INVALID_MODIFICATION_ERR
        {
            get;
            set;
        }
        double NAMESPACE_ERR
        {
            get;
            set;
        }
        double INVALID_CHARACTER_ERR
        {
            get;
            set;
        }
        double TYPE_MISMATCH_ERR
        {
            get;
            set;
        }
        double ABORT_ERR
        {
            get;
            set;
        }
        double INVALID_STATE_ERR
        {
            get;
            set;
        }
        double SECURITY_ERR
        {
            get;
            set;
        }
        double NETWORK_ERR
        {
            get;
            set;
        }
        double WRONG_DOCUMENT_ERR
        {
            get;
            set;
        }
        double QUOTA_EXCEEDED_ERR
        {
            get;
            set;
        }
        double INDEX_SIZE_ERR
        {
            get;
            set;
        }
        double DOMSTRING_SIZE_ERR
        {
            get;
            set;
        }
        double SYNTAX_ERR
        {
            get;
            set;
        }
        double SERIALIZE_ERR
        {
            get;
            set;
        }
        double VALIDATION_ERR
        {
            get;
            set;
        }
        double NOT_FOUND_ERR
        {
            get;
            set;
        }
        double URL_MISMATCH_ERR
        {
            get;
            set;
        }
        double PARSE_ERR
        {
            get;
            set;
        }
        double NO_DATA_ALLOWED_ERR
        {
            get;
            set;
        }
        double NOT_SUPPORTED_ERR
        {
            get;
            set;
        }
        double INVALID_ACCESS_ERR
        {
            get;
            set;
        }
        double INUSE_ATTRIBUTE_ERR
        {
            get;
            set;
        }
        double INVALID_NODE_TYPE_ERR
        {
            get;
            set;
        }
        double DATA_CLONE_ERR
        {
            get;
            set;
        }
        double TIMEOUT_ERR
        {
            get;
            set;
        }
    }
    public partial interface SVGAnimatedBoolean
    {
        bool animVal
        {
            get;
            set;
        }
        bool baseVal
        {
            get;
            set;
        }
    }
    public partial interface MSCompatibleInfoCollection
    {
        double Length
        {
            get;
            set;
        }
        MSCompatibleInfo item(double index);
    }
    public partial interface SVGSwitchElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired { }
    public partial interface SVGPreserveAspectRatio
    {
        double align
        {
            get;
            set;
        }
        double meetOrSlice
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_NONE
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMINYMID
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMAXYMIN
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMINYMAX
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMAXYMAX
        {
            get;
            set;
        }
        double SVG_MEETORSLICE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMAXYMID
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMIDYMAX
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMINYMIN
        {
            get;
            set;
        }
        double SVG_MEETORSLICE_MEET
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMIDYMID
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_XMIDYMIN
        {
            get;
            set;
        }
        double SVG_MEETORSLICE_SLICE
        {
            get;
            set;
        }
        double SVG_PRESERVEASPECTRATIO_UNKNOWN
        {
            get;
            set;
        }
    }
    public partial interface Attr : Node
    {
        bool expando
        {
            get;
            set;
        }
        bool specified
        {
            get;
            set;
        }
        Element ownerElement
        {
            get;
            set;
        }
        string value
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
    }
    public partial interface PerformanceNavigation
    {
        double redirectCount
        {
            get;
            set;
        }
        double type
        {
            get;
            set;
        }
        object toJSON();
        double TYPE_RELOAD
        {
            get;
            set;
        }
        double TYPE_RESERVED
        {
            get;
            set;
        }
        double TYPE_BACK_FORWARD
        {
            get;
            set;
        }
        double TYPE_NAVIGATE
        {
            get;
            set;
        }
    }
    public partial interface SVGStopElement : SVGElement, SVGStylable
    {
        SVGAnimatedNumber offset
        {
            get;
            set;
        }
    }
    public delegate void PositionCallback(Position position);
    public partial interface SVGSymbolElement : SVGElement, SVGStylable, SVGLangSpace, SVGFitToViewBox, SVGExternalResourcesRequired { }
    public partial interface SVGElementInstanceList
    {
        double Length
        {
            get;
            set;
        }
        SVGElementInstance item(double index);
    }
    public partial interface CSSRuleList
    {
        double Length
        {
            get;
            set;
        }
        CSSRule item(double index);
        CSSRule this[double index]
        {
            get;
            set;
        }
    }
    public partial interface MSDataBindingRecordSetExtensions
    {
        object recordset
        {
            get;
            set;
        }
        object namedRecordset(string dataMember, object hierarchy = null);
    }
    public partial interface LinkStyle
    {
        StyleSheet styleSheet
        {
            get;
            set;
        }
        StyleSheet sheet
        {
            get;
            set;
        }
    }
    public partial interface HTMLVideoElement : HTMLMediaElement
    {
        double width
        {
            get;
            set;
        }
        double videoWidth
        {
            get;
            set;
        }
        double videoHeight
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        string poster
        {
            get;
            set;
        }
        bool msIsStereo3D
        {
            get;
            set;
        }
        string msStereo3DPackingMode
        {
            get;
            set;
        }
        System.Func<object, object> onMSVideoOptimalLayoutChanged
        {
            get;
            set;
        }
        System.Func<object, object> onMSVideoFrameStepCompleted
        {
            get;
            set;
        }
        string msStereo3DRenderMode
        {
            get;
            set;
        }
        bool msIsLayoutOptimalForPlayback
        {
            get;
            set;
        }
        bool msHorizontalMirror
        {
            get;
            set;
        }
        System.Func<object, object> onMSVideoFormatChanged
        {
            get;
            set;
        }
        bool msZoom
        {
            get;
            set;
        }
        void msInsertVideoEffect(string activatableClassId, bool effectRequired, object config = null);
        void msSetVideoRectangle(double left, double top, double right, double bottom);
        void msFrameStep(bool forward);
        VideoPlaybackQuality getVideoPlaybackQuality();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface ClientRectList
    {
        double Length
        {
            get;
            set;
        }
        ClientRect item(double index);
        ClientRect this[double index]
        {
            get;
            set;
        }
    }
    public partial interface SVGMaskElement : SVGElement, SVGUnitTypes, SVGStylable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedEnumeration maskUnits
        {
            get;
            set;
        }
        SVGAnimatedEnumeration maskContentUnits
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
    }
    public partial interface External { }
    public partial interface MSGestureEvent : UIEvent
    {
        double offsetY
        {
            get;
            set;
        }
        double translationY
        {
            get;
            set;
        }
        double velocityExpansion
        {
            get;
            set;
        }
        double velocityY
        {
            get;
            set;
        }
        double velocityAngular
        {
            get;
            set;
        }
        double translationX
        {
            get;
            set;
        }
        double velocityX
        {
            get;
            set;
        }
        double hwTimestamp
        {
            get;
            set;
        }
        double offsetX
        {
            get;
            set;
        }
        double screenX
        {
            get;
            set;
        }
        double rotation
        {
            get;
            set;
        }
        double expansion
        {
            get;
            set;
        }
        double clientY
        {
            get;
            set;
        }
        double screenY
        {
            get;
            set;
        }
        double scale
        {
            get;
            set;
        }
        object gestureObject
        {
            get;
            set;
        }
        double clientX
        {
            get;
            set;
        }
        void initGestureEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, double offsetXArg, double offsetYArg, double translationXArg, double translationYArg, double scaleArg, double expansionArg, double rotationArg, double velocityXArg, double velocityYArg, double velocityExpansionArg, double velocityAngularArg, double hwTimestampArg);
        double MSGESTURE_FLAG_BEGIN
        {
            get;
            set;
        }
        double MSGESTURE_FLAG_END
        {
            get;
            set;
        }
        double MSGESTURE_FLAG_CANCEL
        {
            get;
            set;
        }
        double MSGESTURE_FLAG_INERTIA
        {
            get;
            set;
        }
        double MSGESTURE_FLAG_NONE
        {
            get;
            set;
        }
    }
    public partial interface ErrorEvent : Event
    {
        double colno
        {
            get;
            set;
        }
        string filename
        {
            get;
            set;
        }
        object error
        {
            get;
            set;
        }
        double lineno
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        void initErrorEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string messageArg, string filenameArg, double linenoArg);
    }
    public partial interface SVGFilterElement : SVGElement, SVGUnitTypes, SVGStylable, SVGLangSpace, SVGURIReference, SVGExternalResourcesRequired
    {
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedInteger filterResX
        {
            get;
            set;
        }
        SVGAnimatedEnumeration filterUnits
        {
            get;
            set;
        }
        SVGAnimatedEnumeration primitiveUnits
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
        SVGAnimatedInteger filterResY
        {
            get;
            set;
        }
        void setFilterRes(double filterResX, double filterResY);
    }
    public partial interface TrackEvent : Event
    {
        object track
        {
            get;
            set;
        }
    }
    public partial interface SVGFEMergeNodeElement : SVGElement
    {
        SVGAnimatedString in1
        {
            get;
            set;
        }
    }
    public partial interface SVGFEFloodElement : SVGElement, SVGFilterPrimitiveStandardAttributes { }
    public partial interface MSGesture
    {
        Element target
        {
            get;
            set;
        }
        void addPointer(double pointerId);
        void stop();
    }
    public partial interface TextTrackCue : EventTarget
    {
        System.Func<Event, object> onenter
        {
            get;
            set;
        }
        TextTrack track
        {
            get;
            set;
        }
        double endTime
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        bool pauseOnExit
        {
            get;
            set;
        }
        string id
        {
            get;
            set;
        }
        double startTime
        {
            get;
            set;
        }
        System.Func<Event, object> onexit
        {
            get;
            set;
        }
        DocumentFragment getCueAsHTML();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface MSStreamReader : MSBaseReader
    {
        DOMError error
        {
            get;
            set;
        }
        void readAsArrayBuffer(MSStream stream, double size = 0.0);
        void readAsBlob(MSStream stream, double size = 0.0);
        void readAsDataURL(MSStream stream, double size = 0.0);
        void readAsText(MSStream stream, string encoding = null, double size = 0.0);
    }
    public partial interface DOMTokenList
    {
        double Length
        {
            get;
            set;
        }
        bool contains(string token);
        void remove(string token);
        bool toggle(string token);
        void add(string token);
        string item(double index);
        string this[double index]
        {
            get;
            set;
        }
        string.ToString();
    }
    public partial interface SVGFEFuncAElement : SVGComponentTransferFunctionElement { }
    public partial interface SVGFETileElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1
        {
            get;
            set;
        }
    }
    public partial interface SVGFEBlendElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in2
        {
            get;
            set;
        }
        SVGAnimatedEnumeration mode
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        double SVG_FEBLEND_MODE_DARKEN
        {
            get;
            set;
        }
        double SVG_FEBLEND_MODE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_FEBLEND_MODE_MULTIPLY
        {
            get;
            set;
        }
        double SVG_FEBLEND_MODE_NORMAL
        {
            get;
            set;
        }
        double SVG_FEBLEND_MODE_SCREEN
        {
            get;
            set;
        }
        double SVG_FEBLEND_MODE_LIGHTEN
        {
            get;
            set;
        }
    }
    public partial interface MessageChannel
    {
        MessagePort port2
        {
            get;
            set;
        }
        MessagePort port1
        {
            get;
            set;
        }
    }
    public partial interface SVGFEMergeElement : SVGElement, SVGFilterPrimitiveStandardAttributes { }
    public partial interface TransitionEvent : Event
    {
        string propertyName
        {
            get;
            set;
        }
        double elapsedTime
        {
            get;
            set;
        }
        void initTransitionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string propertyNameArg, double elapsedTimeArg);
    }
    public partial interface MediaQueryList
    {
        bool matches
        {
            get;
            set;
        }
        string media
        {
            get;
            set;
        }
        void addListener(MediaQueryListListener listener);
        void removeListener(MediaQueryListListener listener);
    }
    public partial interface DOMError
    {
        string name
        {
            get;
            set;
        }
        string.ToString();
    }
    public partial interface CloseEvent : Event
    {
        bool wasClean
        {
            get;
            set;
        }
        string reason
        {
            get;
            set;
        }
        double code
        {
            get;
            set;
        }
        void initCloseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool wasCleanArg, double codeArg, string reasonArg);
    }
    public partial interface WebSocket : EventTarget
    {
        string protocol
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        double bufferedAmount
        {
            get;
            set;
        }
        System.Func<Event, object> onopen
        {
            get;
            set;
        }
        string extensions
        {
            get;
            set;
        }
        System.Func<MessageEvent, object> onmessage
        {
            get;
            set;
        }
        System.Func<CloseEvent, object> onclose
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        string binaryType
        {
            get;
            set;
        }
        string url
        {
            get;
            set;
        }
        void close(double code = 0.0, string reason = null);
        void send(object data);
        double OPEN
        {
            get;
            set;
        }
        double CLOSING
        {
            get;
            set;
        }
        double CONNECTING
        {
            get;
            set;
        }
        double CLOSED
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface SVGFEPointLightElement : SVGElement
    {
        SVGAnimatedNumber y
        {
            get;
            set;
        }
        SVGAnimatedNumber x
        {
            get;
            set;
        }
        SVGAnimatedNumber z
        {
            get;
            set;
        }
    }
    public partial interface ProgressEvent : Event
    {
        double loaded
        {
            get;
            set;
        }
        bool lengthComputable
        {
            get;
            set;
        }
        double total
        {
            get;
            set;
        }
        void initProgressEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool lengthComputableArg, double loadedArg, double totalArg);
    }
    public partial interface IDBObjectStore
    {
        DOMStringList indexNames
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        IDBTransaction transaction
        {
            get;
            set;
        }
        string keyPath
        {
            get;
            set;
        }
        IDBRequest count(object key = null);
        IDBRequest add(object value, object key = null);
        IDBRequest clear();
        IDBIndex createIndex(string name, string keyPath, object optionalParameters = null);
        IDBRequest put(object value, object key = null);
        IDBRequest openCursor(object range = null, string direction = null);
        void deleteIndex(string indexName);
        IDBIndex index(string name);
        IDBRequest get(object key);
        IDBRequest delete(object key);
    }
    public partial interface SVGFEGaussianBlurElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber stdDeviationX
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        SVGAnimatedNumber stdDeviationY
        {
            get;
            set;
        }
        void setStdDeviation(double stdDeviationX, double stdDeviationY);
    }
    public partial interface SVGFilterPrimitiveStandardAttributes : SVGStylable
    {
        SVGAnimatedLength y
        {
            get;
            set;
        }
        SVGAnimatedLength width
        {
            get;
            set;
        }
        SVGAnimatedLength x
        {
            get;
            set;
        }
        SVGAnimatedLength height
        {
            get;
            set;
        }
        SVGAnimatedString result
        {
            get;
            set;
        }
    }
    public partial interface IDBVersionChangeEvent : Event
    {
        double newVersion
        {
            get;
            set;
        }
        double oldVersion
        {
            get;
            set;
        }
    }
    public partial interface IDBIndex
    {
        bool unique
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string keyPath
        {
            get;
            set;
        }
        IDBObjectStore objectStore
        {
            get;
            set;
        }
        IDBRequest count(object key = null);
        IDBRequest getKey(object key);
        IDBRequest openKeyCursor(IDBKeyRange range = null, string direction = null);
        IDBRequest get(object key);
        IDBRequest openCursor(IDBKeyRange range = null, string direction = null);
    }
    public partial interface FileList
    {
        double Length
        {
            get;
            set;
        }
        File item(double index);
        File this[double index]
        {
            get;
            set;
        }
    }
    public partial interface IDBCursor
    {
        object source
        {
            get;
            set;
        }
        string direction
        {
            get;
            set;
        }
        object key
        {
            get;
            set;
        }
        object primaryKey
        {
            get;
            set;
        }
        void advance(double count);
        IDBRequest delete();
        void _continue(object key = null);
        IDBRequest update(object value);
        string PREV
        {
            get;
            set;
        }
        string PREV_NO_DUPLICATE
        {
            get;
            set;
        }
        string NEXT
        {
            get;
            set;
        }
        string NEXT_NO_DUPLICATE
        {
            get;
            set;
        }
    }
    public partial interface SVGFESpecularLightingElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber kernelUnitLengthY
        {
            get;
            set;
        }
        SVGAnimatedNumber surfaceScale
        {
            get;
            set;
        }
        SVGAnimatedNumber specularExponent
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        SVGAnimatedNumber kernelUnitLengthX
        {
            get;
            set;
        }
        SVGAnimatedNumber specularConstant
        {
            get;
            set;
        }
    }
    public partial interface File : Blob
    {
        object lastModifiedDate
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
    }
    public partial interface URL
    {
        void revokeObjectURL(string url);
        string createObjectURL(object _object, ObjectURLOptions options = null);
    }
    public partial interface XMLHttpRequestEventTarget : EventTarget
    {
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<Event, object> ontimeout
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        System.Func<Event, object> onloadstart
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onloadend
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface IDBEnvironment
    {
        IDBFactory msIndexedDB
        {
            get;
            set;
        }
        IDBFactory indexedDB
        {
            get;
            set;
        }
    }
    public partial interface AudioTrackList : EventTarget
    {
        double Length
        {
            get;
            set;
        }
        System.Func<Event, object> onchange
        {
            get;
            set;
        }
        System.Func<TrackEvent, object> onaddtrack
        {
            get;
            set;
        }
        System.Func<object, object> onremovetrack
        {
            get;
            set;
        }
        AudioTrack getTrackById(string id);
        AudioTrack item(double index);
        AudioTrack this[double index]
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface MSBaseReader : EventTarget
    {
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onloadend
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<Event, object> onloadstart
        {
            get;
            set;
        }
        object result
        {
            get;
            set;
        }
        void abort();
        double LOADING
        {
            get;
            set;
        }
        double EMPTY
        {
            get;
            set;
        }
        double DONE
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface SVGFEMorphologyElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedEnumeration _operator
        {
            get;
            set;
        }
        SVGAnimatedNumber radiusX
        {
            get;
            set;
        }
        SVGAnimatedNumber radiusY
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        double SVG_MORPHOLOGY_OPERATOR_UNKNOWN
        {
            get;
            set;
        }
        double SVG_MORPHOLOGY_OPERATOR_ERODE
        {
            get;
            set;
        }
        double SVG_MORPHOLOGY_OPERATOR_DILATE
        {
            get;
            set;
        }
    }
    public partial interface SVGFEFuncRElement : SVGComponentTransferFunctionElement { }
    public partial interface WindowTimersExtension
    {
        double msSetImmediate(object expression, params object[] args);
        void clearImmediate(double handle);
        void msClearImmediate(double handle);
        double setImmediate(object expression, params object[] args);
    }
    public partial interface SVGFEDisplacementMapElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in2
        {
            get;
            set;
        }
        SVGAnimatedEnumeration xChannelSelector
        {
            get;
            set;
        }
        SVGAnimatedEnumeration yChannelSelector
        {
            get;
            set;
        }
        SVGAnimatedNumber scale
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        double SVG_CHANNEL_B
        {
            get;
            set;
        }
        double SVG_CHANNEL_R
        {
            get;
            set;
        }
        double SVG_CHANNEL_G
        {
            get;
            set;
        }
        double SVG_CHANNEL_UNKNOWN
        {
            get;
            set;
        }
        double SVG_CHANNEL_A
        {
            get;
            set;
        }
    }
    public partial interface AnimationEvent : Event
    {
        string animationName
        {
            get;
            set;
        }
        double elapsedTime
        {
            get;
            set;
        }
        void initAnimationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string animationNameArg, double elapsedTimeArg);
    }
    public partial interface SVGComponentTransferFunctionElement : SVGElement
    {
        SVGAnimatedNumberList tableValues
        {
            get;
            set;
        }
        SVGAnimatedNumber slope
        {
            get;
            set;
        }
        SVGAnimatedEnumeration type
        {
            get;
            set;
        }
        SVGAnimatedNumber exponent
        {
            get;
            set;
        }
        SVGAnimatedNumber amplitude
        {
            get;
            set;
        }
        SVGAnimatedNumber intercept
        {
            get;
            set;
        }
        SVGAnimatedNumber offset
        {
            get;
            set;
        }
        double SVG_FECOMPONENTTRANSFER_TYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_FECOMPONENTTRANSFER_TYPE_TABLE
        {
            get;
            set;
        }
        double SVG_FECOMPONENTTRANSFER_TYPE_IDENTITY
        {
            get;
            set;
        }
        double SVG_FECOMPONENTTRANSFER_TYPE_GAMMA
        {
            get;
            set;
        }
        double SVG_FECOMPONENTTRANSFER_TYPE_DISCRETE
        {
            get;
            set;
        }
        double SVG_FECOMPONENTTRANSFER_TYPE_LINEAR
        {
            get;
            set;
        }
    }
    public partial interface MSRangeCollection
    {
        double Length
        {
            get;
            set;
        }
        Range item(double index);
        Range this[double index]
        {
            get;
            set;
        }
    }
    public partial interface SVGFEDistantLightElement : SVGElement
    {
        SVGAnimatedNumber azimuth
        {
            get;
            set;
        }
        SVGAnimatedNumber elevation
        {
            get;
            set;
        }
    }
    public partial interface SVGFEFuncBElement : SVGComponentTransferFunctionElement { }
    public partial interface IDBKeyRange
    {
        object upper
        {
            get;
            set;
        }
        bool upperOpen
        {
            get;
            set;
        }
        object lower
        {
            get;
            set;
        }
        bool lowerOpen
        {
            get;
            set;
        }
    }
    public partial interface WindowConsole
    {
        Console console
        {
            get;
            set;
        }
    }
    public partial interface IDBTransaction : EventTarget
    {
        System.Func<Event, object> oncomplete
        {
            get;
            set;
        }
        IDBDatabase db
        {
            get;
            set;
        }
        string mode
        {
            get;
            set;
        }
        DOMError error
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        void abort();
        IDBObjectStore objectStore(string name);
        string READ_ONLY
        {
            get;
            set;
        }
        string VERSION_CHANGE
        {
            get;
            set;
        }
        string READ_WRITE
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface AudioTrack
    {
        string kind
        {
            get;
            set;
        }
        string language
        {
            get;
            set;
        }
        string id
        {
            get;
            set;
        }
        string label
        {
            get;
            set;
        }
        bool enabled
        {
            get;
            set;
        }
        SourceBuffer sourceBuffer
        {
            get;
            set;
        }
    }
    public partial interface SVGFEConvolveMatrixElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedInteger orderY
        {
            get;
            set;
        }
        SVGAnimatedNumber kernelUnitLengthY
        {
            get;
            set;
        }
        SVGAnimatedInteger orderX
        {
            get;
            set;
        }
        SVGAnimatedBoolean preserveAlpha
        {
            get;
            set;
        }
        SVGAnimatedNumberList kernelMatrix
        {
            get;
            set;
        }
        SVGAnimatedEnumeration edgeMode
        {
            get;
            set;
        }
        SVGAnimatedNumber kernelUnitLengthX
        {
            get;
            set;
        }
        SVGAnimatedNumber bias
        {
            get;
            set;
        }
        SVGAnimatedInteger targetX
        {
            get;
            set;
        }
        SVGAnimatedInteger targetY
        {
            get;
            set;
        }
        SVGAnimatedNumber divisor
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        double SVG_EDGEMODE_WRAP
        {
            get;
            set;
        }
        double SVG_EDGEMODE_DUPLICATE
        {
            get;
            set;
        }
        double SVG_EDGEMODE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_EDGEMODE_NONE
        {
            get;
            set;
        }
    }
    public partial interface TextTrackCueList
    {
        double Length
        {
            get;
            set;
        }
        TextTrackCue item(double index);
        TextTrackCue this[double index]
        {
            get;
            set;
        }
        TextTrackCue getCueById(string id);
    }
    public partial interface CSSKeyframesRule : CSSRule
    {
        string name
        {
            get;
            set;
        }
        CSSRuleList cssRules
        {
            get;
            set;
        }
        CSSKeyframeRule findRule(string rule);
        void deleteRule(string rule);
        void appendRule(string rule);
    }
    public partial interface SVGFETurbulenceElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber baseFrequencyX
        {
            get;
            set;
        }
        SVGAnimatedInteger numOctaves
        {
            get;
            set;
        }
        SVGAnimatedEnumeration type
        {
            get;
            set;
        }
        SVGAnimatedNumber baseFrequencyY
        {
            get;
            set;
        }
        SVGAnimatedEnumeration stitchTiles
        {
            get;
            set;
        }
        SVGAnimatedNumber seed
        {
            get;
            set;
        }
        double SVG_STITCHTYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_STITCHTYPE_NOSTITCH
        {
            get;
            set;
        }
        double SVG_TURBULENCE_TYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_TURBULENCE_TYPE_TURBULENCE
        {
            get;
            set;
        }
        double SVG_TURBULENCE_TYPE_FRACTALNOISE
        {
            get;
            set;
        }
        double SVG_STITCHTYPE_STITCH
        {
            get;
            set;
        }
    }
    public partial interface TextTrackList : EventTarget
    {
        double Length
        {
            get;
            set;
        }
        System.Func<TrackEvent, object> onaddtrack
        {
            get;
            set;
        }
        TextTrack item(double index);
        TextTrack this[double index]
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface SVGFEFuncGElement : SVGComponentTransferFunctionElement { }
    public partial interface SVGFEColorMatrixElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1
        {
            get;
            set;
        }
        SVGAnimatedEnumeration type
        {
            get;
            set;
        }
        SVGAnimatedNumberList values
        {
            get;
            set;
        }
        double SVG_FECOLORMATRIX_TYPE_SATURATE
        {
            get;
            set;
        }
        double SVG_FECOLORMATRIX_TYPE_UNKNOWN
        {
            get;
            set;
        }
        double SVG_FECOLORMATRIX_TYPE_MATRIX
        {
            get;
            set;
        }
        double SVG_FECOLORMATRIX_TYPE_HUEROTATE
        {
            get;
            set;
        }
        double SVG_FECOLORMATRIX_TYPE_LUMINANCETOALPHA
        {
            get;
            set;
        }
    }
    public partial interface SVGFESpotLightElement : SVGElement
    {
        SVGAnimatedNumber pointsAtY
        {
            get;
            set;
        }
        SVGAnimatedNumber y
        {
            get;
            set;
        }
        SVGAnimatedNumber limitingConeAngle
        {
            get;
            set;
        }
        SVGAnimatedNumber specularExponent
        {
            get;
            set;
        }
        SVGAnimatedNumber x
        {
            get;
            set;
        }
        SVGAnimatedNumber pointsAtZ
        {
            get;
            set;
        }
        SVGAnimatedNumber z
        {
            get;
            set;
        }
        SVGAnimatedNumber pointsAtX
        {
            get;
            set;
        }
    }
    public partial interface WindowBase64
    {
        string btoa(string rawString);
        string atob(string encodedString);
    }
    public partial interface IDBDatabase : EventTarget
    {
        string version
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        DOMStringList objectStoreNames
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        IDBObjectStore createObjectStore(string name, object optionalParameters = null);
        void close();
        IDBTransaction transaction(object storeNames, string mode = null);
        void deleteObjectStore(string name);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface DOMStringList
    {
        double Length
        {
            get;
            set;
        }
        bool contains(string str);
        string item(double index);
        string this[double index]
        {
            get;
            set;
        }
    }
    public partial interface IDBOpenDBRequest : IDBRequest
    {
        System.Func<IDBVersionChangeEvent, object> onupgradeneeded
        {
            get;
            set;
        }
        System.Func<Event, object> onblocked
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface HTMLProgressElement : HTMLElement
    {
        double value
        {
            get;
            set;
        }
        double Max
        {
            get;
            set;
        }
        double position
        {
            get;
            set;
        }
        HTMLFormElement form
        {
            get;
            set;
        }
    }
    public delegate void MSLaunchUriCallback();
    public partial interface SVGFEOffsetElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber dy
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        SVGAnimatedNumber dx
        {
            get;
            set;
        }
    }
    public delegate object MSUnsafeFunctionCallback();
    public partial interface TextTrack : EventTarget
    {
        string language
        {
            get;
            set;
        }
        object mode
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        TextTrackCueList activeCues
        {
            get;
            set;
        }
        TextTrackCueList cues
        {
            get;
            set;
        }
        System.Func<Event, object> oncuechange
        {
            get;
            set;
        }
        string kind
        {
            get;
            set;
        }
        System.Func<Event, object> onload
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        string label
        {
            get;
            set;
        }
        void addCue(TextTrackCue cue);
        void removeCue(TextTrackCue cue);
        double ERROR
        {
            get;
            set;
        }
        double SHOWING
        {
            get;
            set;
        }
        double LOADING
        {
            get;
            set;
        }
        double LOADED
        {
            get;
            set;
        }
        double NONE
        {
            get;
            set;
        }
        double HIDDEN
        {
            get;
            set;
        }
        double DISABLED
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public delegate void MediaQueryListListener(MediaQueryList mql);
    public partial interface IDBRequest : EventTarget
    {
        object source
        {
            get;
            set;
        }
        System.Func<Event, object> onsuccess
        {
            get;
            set;
        }
        DOMError error
        {
            get;
            set;
        }
        IDBTransaction transaction
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        string readyState
        {
            get;
            set;
        }
        object result
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface MessagePort : EventTarget
    {
        System.Func<MessageEvent, object> onmessage
        {
            get;
            set;
        }
        void close();
        void postMessage(object message = null, object ports = null);
        void start();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface FileReader : MSBaseReader
    {
        DOMError error
        {
            get;
            set;
        }
        void readAsArrayBuffer(Blob blob);
        void readAsDataURL(Blob blob);
        void readAsText(Blob blob, string encoding = null);
    }
    public partial interface Blob
    {
        string type
        {
            get;
            set;
        }
        double size
        {
            get;
            set;
        }
        object msDetachStream();
        Blob slice(double start = 0.0, double end = 0.0, string contentType = null);
        void msClose();
    }
    public partial interface ApplicationCache : EventTarget
    {
        double status
        {
            get;
            set;
        }
        System.Func<Event, object> ondownloading
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<Event, object> onupdateready
        {
            get;
            set;
        }
        System.Func<Event, object> oncached
        {
            get;
            set;
        }
        System.Func<Event, object> onobsolete
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<Event, object> onchecking
        {
            get;
            set;
        }
        System.Func<Event, object> onnoupdate
        {
            get;
            set;
        }
        void swapCache();
        void abort();
        void update();
        double CHECKING
        {
            get;
            set;
        }
        double UNCACHED
        {
            get;
            set;
        }
        double UPDATEREADY
        {
            get;
            set;
        }
        double DOWNLOADING
        {
            get;
            set;
        }
        double IDLE
        {
            get;
            set;
        }
        double OBSOLETE
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public delegate void FrameRequestCallback(double time);
    public partial interface PopStateEvent : Event
    {
        object state
        {
            get;
            set;
        }
        void initPopStateEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object stateArg);
    }
    public partial interface CSSKeyframeRule : CSSRule
    {
        string keyText
        {
            get;
            set;
        }
        CSSStyleDeclaration style
        {
            get;
            set;
        }
    }
    public partial interface MSFileSaver
    {
        bool msSaveBlob(object blob, string defaultName = null);
        bool msSaveOrOpenBlob(object blob, string defaultName = null);
    }
    public partial interface MSStream
    {
        string type
        {
            get;
            set;
        }
        object msDetachStream();
        void msClose();
    }
    public partial interface MSBlobBuilder
    {
        void append(object data, string endings = null);
        Blob getBlob(string contentType = null);
    }
    public partial interface DOMSettableTokenList : DOMTokenList
    {
        string value
        {
            get;
            set;
        }
    }
    public partial interface IDBFactory
    {
        IDBOpenDBRequest open(string name, double version = 0.0);
        double cmp(object first, object second);
        IDBOpenDBRequest deleteDatabase(string name);
    }
    public partial interface MSPointerEvent : MouseEvent
    {
        double width
        {
            get;
            set;
        }
        double rotation
        {
            get;
            set;
        }
        double pressure
        {
            get;
            set;
        }
        object pointerType
        {
            get;
            set;
        }
        bool isPrimary
        {
            get;
            set;
        }
        double tiltY
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        object intermediatePoints
        {
            get;
            set;
        }
        object currentPoint
        {
            get;
            set;
        }
        double tiltX
        {
            get;
            set;
        }
        double hwTimestamp
        {
            get;
            set;
        }
        double pointerId
        {
            get;
            set;
        }
        void initPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, double offsetXArg, double offsetYArg, double widthArg, double heightArg, double pressure, double rotation, double tiltX, double tiltY, double pointerIdArg, object pointerType, double hwTimestampArg, bool isPrimary);
        void getCurrentPoint(Element element);
        void getIntermediatePoints(Element element);
        double MSPOINTER_TYPE_PEN
        {
            get;
            set;
        }
        double MSPOINTER_TYPE_MOUSE
        {
            get;
            set;
        }
        double MSPOINTER_TYPE_TOUCH
        {
            get;
            set;
        }
    }
    public partial interface MSManipulationEvent : UIEvent
    {
        double lastState
        {
            get;
            set;
        }
        double currentState
        {
            get;
            set;
        }
        void initMSManipulationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double lastState, double currentState);
        double MS_MANIPULATION_STATE_STOPPED
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_ACTIVE
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_INERTIA
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_SELECTING
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_COMMITTED
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_PRESELECT
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_DRAGGING
        {
            get;
            set;
        }
        double MS_MANIPULATION_STATE_CANCELLED
        {
            get;
            set;
        }
    }
    public partial interface FormData
    {
        void append(object name, object value, string blobName = null);
    }
    public partial interface HTMLDataListElement : HTMLElement
    {
        HTMLCollection options
        {
            get;
            set;
        }
    }
    public partial interface SVGFEImageElement : SVGElement, SVGLangSpace, SVGFilterPrimitiveStandardAttributes, SVGURIReference, SVGExternalResourcesRequired
    {
        SVGAnimatedPreserveAspectRatio preserveAspectRatio
        {
            get;
            set;
        }
    }
    public partial interface AbstractWorker : EventTarget
    {
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface SVGFECompositeElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedEnumeration _operator
        {
            get;
            set;
        }
        SVGAnimatedString in2
        {
            get;
            set;
        }
        SVGAnimatedNumber k2
        {
            get;
            set;
        }
        SVGAnimatedNumber k1
        {
            get;
            set;
        }
        SVGAnimatedNumber k3
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        SVGAnimatedNumber k4
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_OUT
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_OVER
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_XOR
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_ARITHMETIC
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_UNKNOWN
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_IN
        {
            get;
            set;
        }
        double SVG_FECOMPOSITE_OPERATOR_ATOP
        {
            get;
            set;
        }
    }
    public partial interface ValidityState
    {
        bool customError
        {
            get;
            set;
        }
        bool valueMissing
        {
            get;
            set;
        }
        bool stepMismatch
        {
            get;
            set;
        }
        bool rangeUnderflow
        {
            get;
            set;
        }
        bool rangeOverflow
        {
            get;
            set;
        }
        bool typeMismatch
        {
            get;
            set;
        }
        bool patternMismatch
        {
            get;
            set;
        }
        bool tooLong
        {
            get;
            set;
        }
        bool valid
        {
            get;
            set;
        }
    }
    public partial interface HTMLTrackElement : HTMLElement
    {
        string kind
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        string srclang
        {
            get;
            set;
        }
        TextTrack track
        {
            get;
            set;
        }
        string label
        {
            get;
            set;
        }
        bool _default
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        double ERROR
        {
            get;
            set;
        }
        double LOADING
        {
            get;
            set;
        }
        double LOADED
        {
            get;
            set;
        }
        double NONE
        {
            get;
            set;
        }
    }
    public partial interface MSApp
    {
        File createFileFromStorageFile(object storageFile);
        Blob createBlobFromRandomAccessStream(string type, object seeker);
        MSStream createStreamFromInputStream(string type, object inputStream);
        void terminateApp(object exceptionObject);
        object createDataPackage(object _object);
        object execUnsafeLocalFunction(MSUnsafeFunctionCallback unsafeFunction);
        object getHtmlPrintDocumentSource(object htmlDoc);
        void addPublicLocalApplicationUri(string uri);
        object createDataPackageFromSelection();
        MSAppView getViewOpener();
        void suppressSubdownloadCredentialPrompts(bool suppress);
        void execAsyncAtPriority(MSExecAtPriorityFunctionCallback asynchronousCallback, string priority, params object[] args);
        bool isTaskScheduledAtPriorityOrHigher(string priority);
        object execAtPriority(MSExecAtPriorityFunctionCallback synchronousCallback, string priority, params object[] args);
        MSAppView createNewView(string uri);
        string getCurrentPriority();
        string NORMAL
        {
            get;
            set;
        }
        string HIGH
        {
            get;
            set;
        }
        string IDLE
        {
            get;
            set;
        }
        string CURRENT
        {
            get;
            set;
        }
    }
    public partial interface SVGFEDiffuseLightingElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber kernelUnitLengthY
        {
            get;
            set;
        }
        SVGAnimatedNumber surfaceScale
        {
            get;
            set;
        }
        SVGAnimatedString in1
        {
            get;
            set;
        }
        SVGAnimatedNumber kernelUnitLengthX
        {
            get;
            set;
        }
        SVGAnimatedNumber diffuseConstant
        {
            get;
            set;
        }
    }
    public partial interface MSCSSMatrix
    {
        double m24
        {
            get;
            set;
        }
        double m34
        {
            get;
            set;
        }
        double a
        {
            get;
            set;
        }
        double d
        {
            get;
            set;
        }
        double m32
        {
            get;
            set;
        }
        double m41
        {
            get;
            set;
        }
        double m11
        {
            get;
            set;
        }
        double f
        {
            get;
            set;
        }
        double e
        {
            get;
            set;
        }
        double m23
        {
            get;
            set;
        }
        double m14
        {
            get;
            set;
        }
        double m33
        {
            get;
            set;
        }
        double m22
        {
            get;
            set;
        }
        double m21
        {
            get;
            set;
        }
        double c
        {
            get;
            set;
        }
        double m12
        {
            get;
            set;
        }
        double b
        {
            get;
            set;
        }
        double m42
        {
            get;
            set;
        }
        double m31
        {
            get;
            set;
        }
        double m43
        {
            get;
            set;
        }
        double m13
        {
            get;
            set;
        }
        double m44
        {
            get;
            set;
        }
        MSCSSMatrix multiply(MSCSSMatrix secondMatrix);
        MSCSSMatrix skewY(double angle);
        void setMatrixValue(string value);
        MSCSSMatrix inverse();
        MSCSSMatrix rotateAxisAngle(double x, double y, double z, double angle);
        string.ToString();
        MSCSSMatrix rotate(double angleX, double angleY = 0.0, double angleZ = 0.0);
        MSCSSMatrix translate(double x, double y, double z = 0.0);
        MSCSSMatrix scale(double scaleX, double scaleY = 0.0, double scaleZ = 0.0);
        MSCSSMatrix skewX(double angle);
    }
    public partial interface Worker : AbstractWorker
    {
        System.Func<MessageEvent, object> onmessage
        {
            get;
            set;
        }
        void postMessage(object message, object ports = null);
        void terminate();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public delegate object MSExecAtPriorityFunctionCallback(params object[] args);
    public partial interface MSGraphicsTrust
    {
        string status
        {
            get;
            set;
        }
        bool constrictionActive
        {
            get;
            set;
        }
    }
    public partial interface SubtleCrypto
    {
        KeyOperation unwrapKey(ArrayBufferView wrappedKey, object keyAlgorithm, Key keyEncryptionKey, bool extractable = false, Array<string> keyUsages = null);
        CryptoOperation encrypt(object algorithm, Key key, ArrayBufferView buffer = null);
        KeyOperation importKey(string format, ArrayBufferView keyData, object algorithm, bool extractable = false, Array<string> keyUsages = null);
        KeyOperation wrapKey(Key key, Key keyEncryptionKey, object keyWrappingAlgorithm);
        CryptoOperation verify(object algorithm, Key key, ArrayBufferView signature, ArrayBufferView buffer = null);
        KeyOperation deriveKey(object algorithm, Key baseKey, object derivedKeyType, bool extractable = false, Array<string> keyUsages = null);
        CryptoOperation digest(object algorithm, ArrayBufferView buffer = null);
        KeyOperation exportKey(string format, Key key);
        KeyOperation generateKey(object algorithm, bool extractable = false, Array<string> keyUsages = null);
        CryptoOperation sign(object algorithm, Key key, ArrayBufferView buffer = null);
        CryptoOperation decrypt(object algorithm, Key key, ArrayBufferView buffer = null);
    }
    public partial interface Crypto : RandomSource
    {
        SubtleCrypto subtle
        {
            get;
            set;
        }
    }
    public partial interface VideoPlaybackQuality
    {
        double totalFrameDelay
        {
            get;
            set;
        }
        double creationTime
        {
            get;
            set;
        }
        double totalVideoFrames
        {
            get;
            set;
        }
        double droppedVideoFrames
        {
            get;
            set;
        }
    }
    public partial interface GlobalEventHandlers
    {
        System.Func<PointerEvent, object> onpointerenter
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointerout
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointerdown
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointerup
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointercancel
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointerover
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointermove
        {
            get;
            set;
        }
        System.Func<PointerEvent, object> onpointerleave
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface Key
    {
        Algorithm algorithm
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        bool extractable
        {
            get;
            set;
        }
        Array<string> keyUsage
        {
            get;
            set;
        }
    }
    public partial interface DeviceAcceleration
    {
        double y
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        double z
        {
            get;
            set;
        }
    }
    public partial interface HTMLAllCollection : HTMLCollection
    {
        Element namedItem(string name);
    }
    public partial interface AesGcmEncryptResult
    {
        ArrayBuffer ciphertext
        {
            get;
            set;
        }
        ArrayBuffer tag
        {
            get;
            set;
        }
    }
    public partial interface NavigationCompletedEvent : NavigationEvent
    {
        double webErrorStatus
        {
            get;
            set;
        }
        bool isSuccess
        {
            get;
            set;
        }
    }
    public partial interface MutationRecord
    {
        string oldValue
        {
            get;
            set;
        }
        Node previousSibling
        {
            get;
            set;
        }
        NodeList addedNodes
        {
            get;
            set;
        }
        string attributeName
        {
            get;
            set;
        }
        NodeList removedNodes
        {
            get;
            set;
        }
        Node target
        {
            get;
            set;
        }
        Node nextSibling
        {
            get;
            set;
        }
        string attributeNamespace
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
    }
    public partial interface MimeTypeArray
    {
        double Length
        {
            get;
            set;
        }
        Plugin item(double index);
        Plugin this[double index]
        {
            get;
            set;
        }
        Plugin namedItem(string type);
    }
    public partial interface KeyOperation : EventTarget
    {
        System.Func<Event, object> oncomplete
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        object result
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface DOMStringMap { }
    public partial interface DeviceOrientationEvent : Event
    {
        double gamma
        {
            get;
            set;
        }
        double alpha
        {
            get;
            set;
        }
        bool absolute
        {
            get;
            set;
        }
        double beta
        {
            get;
            set;
        }
        void initDeviceOrientationEvent(string type, bool bubbles, bool cancelable, double alpha, double beta, double gamma, bool absolute);
    }
    public partial interface MSMediaKeys
    {
        string keySystem
        {
            get;
            set;
        }
        MSMediaKeySession createSession(string type, Uint8Array initData, Uint8Array cdmData = null);
    }
    public partial interface MSMediaKeyMessageEvent : Event
    {
        string destinationURL
        {
            get;
            set;
        }
        Uint8Array message
        {
            get;
            set;
        }
    }
    public partial interface MSHTMLWebViewElement : HTMLElement
    {
        string documentTitle
        {
            get;
            set;
        }
        double width
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        bool canGoForward
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        bool canGoBack
        {
            get;
            set;
        }
        void navigateWithHttpRequestMessage(object requestMessage);
        void goBack();
        void navigate(string uri);
        void stop();
        void navigateToString(string contents);
        MSWebViewAsyncOperation captureSelectedContentToDataPackageAsync();
        MSWebViewAsyncOperation capturePreviewToBlobAsync();
        void refresh();
        void goForward();
        void navigateToLocalStreamUri(string source, object streamResolver);
        MSWebViewAsyncOperation invokeScriptAsync(string scriptName, params object[] args);
        string buildLocalStreamUri(string contentIdentifier, string relativePath);
    }
    public partial interface NavigationEvent : Event
    {
        string uri
        {
            get;
            set;
        }
    }
    public partial interface RandomSource
    {
        ArrayBufferView getRandomValues(ArrayBufferView array);
    }
    public partial interface SourceBuffer : EventTarget
    {
        bool updating
        {
            get;
            set;
        }
        double appendWindowStart
        {
            get;
            set;
        }
        double appendWindowEnd
        {
            get;
            set;
        }
        TimeRanges buffered
        {
            get;
            set;
        }
        double timestampOffset
        {
            get;
            set;
        }
        AudioTrackList audioTracks
        {
            get;
            set;
        }
        void appendBuffer(ArrayBuffer data);
        void remove(double start, double end);
        void abort();
        void appendStream(MSStream stream, double maxSize = 0.0);
    }
    public partial interface MSInputMethodContext : EventTarget
    {
        System.Func<object, object> oncandidatewindowshow
        {
            get;
            set;
        }
        HTMLElement target
        {
            get;
            set;
        }
        double compositionStartOffset
        {
            get;
            set;
        }
        System.Func<object, object> oncandidatewindowhide
        {
            get;
            set;
        }
        System.Func<object, object> oncandidatewindowupdate
        {
            get;
            set;
        }
        double compositionEndOffset
        {
            get;
            set;
        }
        Array<string> getCompositionAlternatives();
        ClientRect getCandidateWindowClientRect();
        bool hasComposition();
        bool isCandidateWindowVisible();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface DeviceRotationRate
    {
        double gamma
        {
            get;
            set;
        }
        double alpha
        {
            get;
            set;
        }
        double beta
        {
            get;
            set;
        }
    }
    public partial interface PluginArray
    {
        double Length
        {
            get;
            set;
        }
        void refresh(bool reload = false);
        Plugin item(double index);
        Plugin this[double index]
        {
            get;
            set;
        }
        Plugin namedItem(string name);
    }
    public partial interface MSMediaKeyError
    {
        double systemCode
        {
            get;
            set;
        }
        double code
        {
            get;
            set;
        }
        double MS_MEDIA_KEYERR_SERVICE
        {
            get;
            set;
        }
        double MS_MEDIA_KEYERR_HARDWARECHANGE
        {
            get;
            set;
        }
        double MS_MEDIA_KEYERR_OUTPUT
        {
            get;
            set;
        }
        double MS_MEDIA_KEYERR_DOMAIN
        {
            get;
            set;
        }
        double MS_MEDIA_KEYERR_UNKNOWN
        {
            get;
            set;
        }
        double MS_MEDIA_KEYERR_CLIENT
        {
            get;
            set;
        }
    }
    public partial interface Plugin
    {
        double Length
        {
            get;
            set;
        }
        string filename
        {
            get;
            set;
        }
        string version
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        string description
        {
            get;
            set;
        }
        MimeType item(double index);
        MimeType this[double index]
        {
            get;
            set;
        }
        MimeType namedItem(string type);
    }
    public partial interface MediaSource : EventTarget
    {
        SourceBufferList sourceBuffers
        {
            get;
            set;
        }
        double duration
        {
            get;
            set;
        }
        string readyState
        {
            get;
            set;
        }
        SourceBufferList activeSourceBuffers
        {
            get;
            set;
        }
        SourceBuffer addSourceBuffer(string type);
        void endOfStream(string error = null);
        void removeSourceBuffer(SourceBuffer sourceBuffer);
    }
    public partial interface SourceBufferList : EventTarget
    {
        double Length
        {
            get;
            set;
        }
        SourceBuffer item(double index);
        SourceBuffer this[double index]
        {
            get;
            set;
        }
    }
    public partial interface XMLDocument : Document { }
    public partial interface DeviceMotionEvent : Event
    {
        DeviceRotationRate rotationRate
        {
            get;
            set;
        }
        DeviceAcceleration acceleration
        {
            get;
            set;
        }
        double interval
        {
            get;
            set;
        }
        DeviceAcceleration accelerationIncludingGravity
        {
            get;
            set;
        }
        void initDeviceMotionEvent(string type, bool bubbles, bool cancelable, DeviceAccelerationDict acceleration, DeviceAccelerationDict accelerationIncludingGravity, DeviceRotationRateDict rotationRate, double interval);
    }
    public partial interface MimeType
    {
        Plugin enabledPlugin
        {
            get;
            set;
        }
        string suffixes
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
        string description
        {
            get;
            set;
        }
    }
    public partial interface PointerEvent : MouseEvent
    {
        double width
        {
            get;
            set;
        }
        double rotation
        {
            get;
            set;
        }
        double pressure
        {
            get;
            set;
        }
        object pointerType
        {
            get;
            set;
        }
        bool isPrimary
        {
            get;
            set;
        }
        double tiltY
        {
            get;
            set;
        }
        double height
        {
            get;
            set;
        }
        object intermediatePoints
        {
            get;
            set;
        }
        object currentPoint
        {
            get;
            set;
        }
        double tiltX
        {
            get;
            set;
        }
        double hwTimestamp
        {
            get;
            set;
        }
        double pointerId
        {
            get;
            set;
        }
        void initPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double screenXArg, double screenYArg, double clientXArg, double clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, double buttonArg, EventTarget relatedTargetArg, double offsetXArg, double offsetYArg, double widthArg, double heightArg, double pressure, double rotation, double tiltX, double tiltY, double pointerIdArg, object pointerType, double hwTimestampArg, bool isPrimary);
        void getCurrentPoint(Element element);
        void getIntermediatePoints(Element element);
    }
    public partial interface MSDocumentExtensions
    {
        void captureEvents();
        void releaseEvents();
    }
    public partial interface MutationObserver
    {
        void observe(Node target, MutationObserverInit options);
        Array<MutationRecord> takeRecords();
        void disconnect();
    }
    public partial interface MSWebViewAsyncOperation : EventTarget
    {
        MSHTMLWebViewElement target
        {
            get;
            set;
        }
        System.Func<Event, object> oncomplete
        {
            get;
            set;
        }
        DOMError error
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        double readyState
        {
            get;
            set;
        }
        double type
        {
            get;
            set;
        }
        object result
        {
            get;
            set;
        }
        void start();
        double ERROR
        {
            get;
            set;
        }
        double TYPE_CREATE_DATA_PACKAGE_FROM_SELECTION
        {
            get;
            set;
        }
        double TYPE_INVOKE_SCRIPT
        {
            get;
            set;
        }
        double COMPLETED
        {
            get;
            set;
        }
        double TYPE_CAPTURE_PREVIEW_TO_RANDOM_ACCESS_STREAM
        {
            get;
            set;
        }
        double STARTED
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface ScriptNotifyEvent : Event
    {
        string value
        {
            get;
            set;
        }
        string callingUri
        {
            get;
            set;
        }
    }
    public partial interface PerformanceNavigationTiming : PerformanceEntry
    {
        double redirectStart
        {
            get;
            set;
        }
        double domainLookupEnd
        {
            get;
            set;
        }
        double responseStart
        {
            get;
            set;
        }
        double domComplete
        {
            get;
            set;
        }
        double domainLookupStart
        {
            get;
            set;
        }
        double loadEventStart
        {
            get;
            set;
        }
        double unloadEventEnd
        {
            get;
            set;
        }
        double fetchStart
        {
            get;
            set;
        }
        double requestStart
        {
            get;
            set;
        }
        double domInteractive
        {
            get;
            set;
        }
        double navigationStart
        {
            get;
            set;
        }
        double connectEnd
        {
            get;
            set;
        }
        double loadEventEnd
        {
            get;
            set;
        }
        double connectStart
        {
            get;
            set;
        }
        double responseEnd
        {
            get;
            set;
        }
        double domLoading
        {
            get;
            set;
        }
        double redirectEnd
        {
            get;
            set;
        }
        double redirectCount
        {
            get;
            set;
        }
        double unloadEventStart
        {
            get;
            set;
        }
        double domContentLoadedEventStart
        {
            get;
            set;
        }
        double domContentLoadedEventEnd
        {
            get;
            set;
        }
        string type
        {
            get;
            set;
        }
    }
    public partial interface MSMediaKeyNeededEvent : Event
    {
        Uint8Array initData
        {
            get;
            set;
        }
    }
    public partial interface LongRunningScriptDetectedEvent : Event
    {
        bool stopPageScriptExecution
        {
            get;
            set;
        }
        double executionTime
        {
            get;
            set;
        }
    }
    public partial interface MSAppView
    {
        double viewId
        {
            get;
            set;
        }
        void close();
        void postMessage(object message, string targetOrigin, object ports = null);
    }
    public partial interface PerfWidgetExternal
    {
        double maxCpuSpeed
        {
            get;
            set;
        }
        bool independentRenderingEnabled
        {
            get;
            set;
        }
        string irDisablingContentString
        {
            get;
            set;
        }
        bool irStatusAvailable
        {
            get;
            set;
        }
        double performanceCounter
        {
            get;
            set;
        }
        double averagePaintTime
        {
            get;
            set;
        }
        double activeNetworkRequestCount
        {
            get;
            set;
        }
        double paintRequestsPerSecond
        {
            get;
            set;
        }
        bool extraInformationEnabled
        {
            get;
            set;
        }
        double performanceCounterFrequency
        {
            get;
            set;
        }
        double averageFrameTime
        {
            get;
            set;
        }
        void repositionWindow(double x, double y);
        object getRecentMemoryUsage(double last);
        double getMemoryUsage();
        void resizeWindow(double width, double height);
        double getProcessCpuUsage();
        void removeEventListener(string eventType, System.Func<object, object> callback);
        object getRecentCpuUsage(double last);
        void addEventListener(string eventType, System.Func<object, object> callback);
        object getRecentFrames(double last);
        object getRecentPaintRequests(double last);
    }
    public partial interface PageTransitionEvent : Event
    {
        bool persisted
        {
            get;
            set;
        }
    }
    public delegate void MutationCallback(Array<MutationRecord> mutations, MutationObserver observer);
    public partial interface HTMLDocument : Document { }
    public partial interface KeyPair
    {
        Key privateKey
        {
            get;
            set;
        }
        Key publicKey
        {
            get;
            set;
        }
    }
    public partial interface MSMediaKeySession : EventTarget
    {
        string sessionId
        {
            get;
            set;
        }
        MSMediaKeyError error
        {
            get;
            set;
        }
        string keySystem
        {
            get;
            set;
        }
        void close();
        void update(Uint8Array key);
    }
    public partial interface UnviewableContentIdentifiedEvent : NavigationEvent
    {
        string referrer
        {
            get;
            set;
        }
    }
    public partial interface CryptoOperation : EventTarget
    {
        Algorithm algorithm
        {
            get;
            set;
        }
        System.Func<Event, object> oncomplete
        {
            get;
            set;
        }
        System.Func<ErrorEvent, object> onerror
        {
            get;
            set;
        }
        System.Func<ProgressEvent, object> onprogress
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onabort
        {
            get;
            set;
        }
        Key key
        {
            get;
            set;
        }
        object result
        {
            get;
            set;
        }
        void abort();
        void finish();
        void process(ArrayBufferView buffer);
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface WebGLTexture : WebGLObject { }
    public partial interface OES_texture_float { }
    public partial interface WebGLContextEvent : Event
    {
        string statusMessage
        {
            get;
            set;
        }
    }
    public partial interface WebGLRenderbuffer : WebGLObject { }
    public partial interface WebGLUniformLocation { }
    public partial interface WebGLActiveInfo
    {
        string name
        {
            get;
            set;
        }
        double type
        {
            get;
            set;
        }
        double size
        {
            get;
            set;
        }
    }
    public partial interface WEBGL_compressed_texture_s3tc
    {
        double COMPRESSED_RGBA_S3TC_DXT1_EXT
        {
            get;
            set;
        }
        double COMPRESSED_RGBA_S3TC_DXT5_EXT
        {
            get;
            set;
        }
        double COMPRESSED_RGBA_S3TC_DXT3_EXT
        {
            get;
            set;
        }
        double COMPRESSED_RGB_S3TC_DXT1_EXT
        {
            get;
            set;
        }
    }
    public partial interface WebGLRenderingContext
    {
        double drawingBufferWidth
        {
            get;
            set;
        }
        double drawingBufferHeight
        {
            get;
            set;
        }
        HTMLCanvasElement canvas
        {
            get;
            set;
        }
        WebGLUniformLocation getUniformLocation(WebGLProgram program, string name);
        void bindTexture(double target, WebGLTexture texture);
        void bufferData(double target, ArrayBufferView data, double usage);
        void bufferData(double target, ArrayBuffer data, double usage);
        void bufferData(double target, double size, double usage);
        void depthMask(bool flag);
        object getUniform(WebGLProgram program, WebGLUniformLocation location);
        void vertexAttrib3fv(double indx, Array<double> values);
        void vertexAttrib3fv(double indx, Float32Array values);
        void linkProgram(WebGLProgram program);
        Array<string> getSupportedExtensions();
        void bufferSubData(double target, double offset, ArrayBuffer data);
        void bufferSubData(double target, double offset, ArrayBufferView data);
        void vertexAttribPointer(double indx, double size, double type, bool normalized, double stride, double offset);
        void polygonOffset(double factor, double units);
        void blendColor(double red, double green, double blue, double alpha);
        WebGLTexture createTexture();
        void hint(double target, double mode);
        object getVertexAttrib(double index, double pname);
        void enableVertexAttribArray(double index);
        void depthRange(double zNear, double zFar);
        void cullFace(double mode);
        WebGLFramebuffer createFramebuffer();
        void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, Array<double> value);
        void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, Float32Array value);
        void framebufferTexture2D(double target, double attachment, double textarget, WebGLTexture texture, double level);
        void deleteFramebuffer(WebGLFramebuffer framebuffer);
        void colorMask(bool red, bool green, bool blue, bool alpha);
        void compressedTexImage2D(double target, double level, double internalformat, double width, double height, double border, ArrayBufferView data);
        void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Array<double> value);
        void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Float32Array value);
        object getExtension(string name);
        WebGLProgram createProgram();
        void deleteShader(WebGLShader shader);
        Array<WebGLShader> getAttachedShaders(WebGLProgram program);
        void enable(double cap);
        void blendEquation(double mode);
        void texImage2D(double target, double level, double internalformat, double width, double height, double border, double format, double type, ArrayBufferView pixels);
        void texImage2D(double target, double level, double internalformat, double format, double type, HTMLImageElement image);
        void texImage2D(double target, double level, double internalformat, double format, double type, HTMLCanvasElement canvas);
        void texImage2D(double target, double level, double internalformat, double format, double type, HTMLVideoElement video);
        void texImage2D(double target, double level, double internalformat, double format, double type, ImageData pixels);
        WebGLBuffer createBuffer();
        void deleteTexture(WebGLTexture texture);
        void useProgram(WebGLProgram program);
        void vertexAttrib2fv(double indx, Array<double> values);
        void vertexAttrib2fv(double indx, Float32Array values);
        double checkFramebufferStatus(double target);
        void frontFace(double mode);
        object getBufferParameter(double target, double pname);
        void texSubImage2D(double target, double level, double xoffset, double yoffset, double width, double height, double format, double type, ArrayBufferView pixels);
        void texSubImage2D(double target, double level, double xoffset, double yoffset, double format, double type, HTMLImageElement image);
        void texSubImage2D(double target, double level, double xoffset, double yoffset, double format, double type, HTMLCanvasElement canvas);
        void texSubImage2D(double target, double level, double xoffset, double yoffset, double format, double type, HTMLVideoElement video);
        void texSubImage2D(double target, double level, double xoffset, double yoffset, double format, double type, ImageData pixels);
        void copyTexImage2D(double target, double level, double internalformat, double x, double y, double width, double height, double border);
        double getVertexAttribOffset(double index, double pname);
        void disableVertexAttribArray(double index);
        void blendFunc(double sfactor, double dfactor);
        void drawElements(double mode, double count, double type, double offset);
        bool isFramebuffer(WebGLFramebuffer framebuffer);
        void uniform3iv(WebGLUniformLocation location, Array<double> v);
        void uniform3iv(WebGLUniformLocation location, Int32Array v);
        void lineWidth(double width);
        string getShaderInfoLog(WebGLShader shader);
        object getTexParameter(double target, double pname);
        object getParameter(double pname);
        WebGLShaderPrecisionFormat getShaderPrecisionFormat(double shadertype, double precisiontype);
        WebGLContextAttributes getContextAttributes();
        void vertexAttrib1f(double indx, double x);
        void bindFramebuffer(double target, WebGLFramebuffer framebuffer);
        void compressedTexSubImage2D(double target, double level, double xoffset, double yoffset, double width, double height, double format, ArrayBufferView data);
        bool isContextLost();
        void uniform1iv(WebGLUniformLocation location, Array<double> v);
        void uniform1iv(WebGLUniformLocation location, Int32Array v);
        object getRenderbufferParameter(double target, double pname);
        void uniform2fv(WebGLUniformLocation location, Array<double> v);
        void uniform2fv(WebGLUniformLocation location, Float32Array v);
        bool isTexture(WebGLTexture texture);
        double getError();
        void shaderSource(WebGLShader shader, string source);
        void deleteRenderbuffer(WebGLRenderbuffer renderbuffer);
        void stencilMask(double mask);
        void bindBuffer(double target, WebGLBuffer buffer);
        double getAttribLocation(WebGLProgram program, string name);
        void uniform3i(WebGLUniformLocation location, double x, double y, double z);
        void blendEquationSeparate(double modeRGB, double modeAlpha);
        void clear(double mask);
        void blendFuncSeparate(double srcRGB, double dstRGB, double srcAlpha, double dstAlpha);
        void stencilFuncSeparate(double face, double func, double _ref, double mask);
        void readPixels(double x, double y, double width, double height, double format, double type, ArrayBufferView pixels);
        void scissor(double x, double y, double width, double height);
        void uniform2i(WebGLUniformLocation location, double x, double y);
        WebGLActiveInfo getActiveAttrib(WebGLProgram program, double index);
        string getShaderSource(WebGLShader shader);
        void generateMipmap(double target);
        void bindAttribLocation(WebGLProgram program, double index, string name);
        void uniform1fv(WebGLUniformLocation location, Array<double> v);
        void uniform1fv(WebGLUniformLocation location, Float32Array v);
        void uniform2iv(WebGLUniformLocation location, Array<double> v);
        void uniform2iv(WebGLUniformLocation location, Int32Array v);
        void stencilOp(double fail, double zfail, double zpass);
        void uniform4fv(WebGLUniformLocation location, Array<double> v);
        void uniform4fv(WebGLUniformLocation location, Float32Array v);
        void vertexAttrib1fv(double indx, Array<double> values);
        void vertexAttrib1fv(double indx, Float32Array values);
        void flush();
        void uniform4f(WebGLUniformLocation location, double x, double y, double z, double w);
        void deleteProgram(WebGLProgram program);
        bool isRenderbuffer(WebGLRenderbuffer renderbuffer);
        void uniform1i(WebGLUniformLocation location, double x);
        object getProgramParameter(WebGLProgram program, double pname);
        WebGLActiveInfo getActiveUniform(WebGLProgram program, double index);
        void stencilFunc(double func, double _ref, double mask);
        void pixelStorei(double pname, double param);
        void disable(double cap);
        void vertexAttrib4fv(double indx, Array<double> values);
        void vertexAttrib4fv(double indx, Float32Array values);
        WebGLRenderbuffer createRenderbuffer();
        bool isBuffer(WebGLBuffer buffer);
        void stencilOpSeparate(double face, double fail, double zfail, double zpass);
        object getFramebufferAttachmentParameter(double target, double attachment, double pname);
        void uniform4i(WebGLUniformLocation location, double x, double y, double z, double w);
        void sampleCoverage(double value, bool invert);
        void depthFunc(double func);
        void texParameterf(double target, double pname, double param);
        void vertexAttrib3f(double indx, double x, double y, double z);
        void drawArrays(double mode, double first, double count);
        void texParameteri(double target, double pname, double param);
        void vertexAttrib4f(double indx, double x, double y, double z, double w);
        object getShaderParameter(WebGLShader shader, double pname);
        void clearDepth(double depth);
        void activeTexture(double texture);
        void viewport(double x, double y, double width, double height);
        void detachShader(WebGLProgram program, WebGLShader shader);
        void uniform1f(WebGLUniformLocation location, double x);
        void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Array<double> value);
        void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Float32Array value);
        void deleteBuffer(WebGLBuffer buffer);
        void copyTexSubImage2D(double target, double level, double xoffset, double yoffset, double x, double y, double width, double height);
        void uniform3fv(WebGLUniformLocation location, Array<double> v);
        void uniform3fv(WebGLUniformLocation location, Float32Array v);
        void stencilMaskSeparate(double face, double mask);
        void attachShader(WebGLProgram program, WebGLShader shader);
        void compileShader(WebGLShader shader);
        void clearColor(double red, double green, double blue, double alpha);
        bool isShader(WebGLShader shader);
        void clearStencil(double s);
        void framebufferRenderbuffer(double target, double attachment, double renderbuffertarget, WebGLRenderbuffer renderbuffer);
        void finish();
        void uniform2f(WebGLUniformLocation location, double x, double y);
        void renderbufferStorage(double target, double internalformat, double width, double height);
        void uniform3f(WebGLUniformLocation location, double x, double y, double z);
        string getProgramInfoLog(WebGLProgram program);
        void validateProgram(WebGLProgram program);
        bool isEnabled(double cap);
        void vertexAttrib2f(double indx, double x, double y);
        bool isProgram(WebGLProgram program);
        WebGLShader createShader(double type);
        void bindRenderbuffer(double target, WebGLRenderbuffer renderbuffer);
        void uniform4iv(WebGLUniformLocation location, Array<double> v);
        void uniform4iv(WebGLUniformLocation location, Int32Array v);
        double DEPTH_FUNC
        {
            get;
            set;
        }
        double DEPTH_COMPONENT16
        {
            get;
            set;
        }
        double REPLACE
        {
            get;
            set;
        }
        double REPEAT
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_ENABLED
        {
            get;
            set;
        }
        double FRAMEBUFFER_INCOMPLETE_DIMENSIONS
        {
            get;
            set;
        }
        double STENCIL_BUFFER_BIT
        {
            get;
            set;
        }
        double RENDERER
        {
            get;
            set;
        }
        double STENCIL_BACK_REF
        {
            get;
            set;
        }
        double TEXTURE26
        {
            get;
            set;
        }
        double RGB565
        {
            get;
            set;
        }
        double DITHER
        {
            get;
            set;
        }
        double CONSTANT_COLOR
        {
            get;
            set;
        }
        double GENERATE_MIPMAP_HINT
        {
            get;
            set;
        }
        double POINTS
        {
            get;
            set;
        }
        double DECR
        {
            get;
            set;
        }
        double INT_VEC3
        {
            get;
            set;
        }
        double TEXTURE28
        {
            get;
            set;
        }
        double ONE_MINUS_CONSTANT_ALPHA
        {
            get;
            set;
        }
        double BACK
        {
            get;
            set;
        }
        double RENDERBUFFER_STENCIL_SIZE
        {
            get;
            set;
        }
        double UNPACK_FLIP_Y_WEBGL
        {
            get;
            set;
        }
        double BLEND
        {
            get;
            set;
        }
        double TEXTURE9
        {
            get;
            set;
        }
        double ARRAY_BUFFER_BINDING
        {
            get;
            set;
        }
        double MAX_VIEWPORT_DIMS
        {
            get;
            set;
        }
        double INVALID_FRAMEBUFFER_OPERATION
        {
            get;
            set;
        }
        double TEXTURE
        {
            get;
            set;
        }
        double TEXTURE0
        {
            get;
            set;
        }
        double TEXTURE31
        {
            get;
            set;
        }
        double TEXTURE24
        {
            get;
            set;
        }
        double HIGH_INT
        {
            get;
            set;
        }
        double RENDERBUFFER_BINDING
        {
            get;
            set;
        }
        double BLEND_COLOR
        {
            get;
            set;
        }
        double FASTEST
        {
            get;
            set;
        }
        double STENCIL_WRITEMASK
        {
            get;
            set;
        }
        double ALIASED_POINT_SIZE_RANGE
        {
            get;
            set;
        }
        double TEXTURE12
        {
            get;
            set;
        }
        double DST_ALPHA
        {
            get;
            set;
        }
        double BLEND_EQUATION_RGB
        {
            get;
            set;
        }
        double FRAMEBUFFER_COMPLETE
        {
            get;
            set;
        }
        double NEAREST_MIPMAP_NEAREST
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_SIZE
        {
            get;
            set;
        }
        double TEXTURE3
        {
            get;
            set;
        }
        double DEPTH_WRITEMASK
        {
            get;
            set;
        }
        double CONTEXT_LOST_WEBGL
        {
            get;
            set;
        }
        double INVALID_VALUE
        {
            get;
            set;
        }
        double TEXTURE_MAG_FILTER
        {
            get;
            set;
        }
        double ONE_MINUS_CONSTANT_COLOR
        {
            get;
            set;
        }
        double ONE_MINUS_SRC_ALPHA
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP_POSITIVE_Z
        {
            get;
            set;
        }
        double NOTEQUAL
        {
            get;
            set;
        }
        double ALPHA
        {
            get;
            set;
        }
        double DEPTH_STENCIL
        {
            get;
            set;
        }
        double MAX_VERTEX_UNIFORM_VECTORS
        {
            get;
            set;
        }
        double DEPTH_COMPONENT
        {
            get;
            set;
        }
        double RENDERBUFFER_RED_SIZE
        {
            get;
            set;
        }
        double TEXTURE20
        {
            get;
            set;
        }
        double RED_BITS
        {
            get;
            set;
        }
        double RENDERBUFFER_BLUE_SIZE
        {
            get;
            set;
        }
        double SCISSOR_BOX
        {
            get;
            set;
        }
        double VENDOR
        {
            get;
            set;
        }
        double FRONT_AND_BACK
        {
            get;
            set;
        }
        double CONSTANT_ALPHA
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_BUFFER_BINDING
        {
            get;
            set;
        }
        double NEAREST
        {
            get;
            set;
        }
        double CULL_FACE
        {
            get;
            set;
        }
        double ALIASED_LINE_WIDTH_RANGE
        {
            get;
            set;
        }
        double TEXTURE19
        {
            get;
            set;
        }
        double FRONT
        {
            get;
            set;
        }
        double DEPTH_CLEAR_VALUE
        {
            get;
            set;
        }
        double GREEN_BITS
        {
            get;
            set;
        }
        double TEXTURE29
        {
            get;
            set;
        }
        double TEXTURE23
        {
            get;
            set;
        }
        double MAX_RENDERBUFFER_SIZE
        {
            get;
            set;
        }
        double STENCIL_ATTACHMENT
        {
            get;
            set;
        }
        double TEXTURE27
        {
            get;
            set;
        }
        double BOOL_VEC2
        {
            get;
            set;
        }
        double OUT_OF_MEMORY
        {
            get;
            set;
        }
        double MIRRORED_REPEAT
        {
            get;
            set;
        }
        double POLYGON_OFFSET_UNITS
        {
            get;
            set;
        }
        double TEXTURE_MIN_FILTER
        {
            get;
            set;
        }
        double STENCIL_BACK_PASS_DEPTH_PASS
        {
            get;
            set;
        }
        double LINE_LOOP
        {
            get;
            set;
        }
        double FLOAT_MAT3
        {
            get;
            set;
        }
        double TEXTURE14
        {
            get;
            set;
        }
        double LINEAR
        {
            get;
            set;
        }
        double RGB5_A1
        {
            get;
            set;
        }
        double ONE_MINUS_SRC_COLOR
        {
            get;
            set;
        }
        double SAMPLE_COVERAGE_INVERT
        {
            get;
            set;
        }
        double DONT_CARE
        {
            get;
            set;
        }
        double FRAMEBUFFER_BINDING
        {
            get;
            set;
        }
        double RENDERBUFFER_ALPHA_SIZE
        {
            get;
            set;
        }
        double STENCIL_REF
        {
            get;
            set;
        }
        double ZERO
        {
            get;
            set;
        }
        double DECR_WRAP
        {
            get;
            set;
        }
        double SAMPLE_COVERAGE
        {
            get;
            set;
        }
        double STENCIL_BACK_FUNC
        {
            get;
            set;
        }
        double TEXTURE30
        {
            get;
            set;
        }
        double VIEWPORT
        {
            get;
            set;
        }
        double STENCIL_BITS
        {
            get;
            set;
        }
        double FLOAT
        {
            get;
            set;
        }
        double COLOR_WRITEMASK
        {
            get;
            set;
        }
        double SAMPLE_COVERAGE_VALUE
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP_NEGATIVE_Y
        {
            get;
            set;
        }
        double STENCIL_BACK_FAIL
        {
            get;
            set;
        }
        double FLOAT_MAT4
        {
            get;
            set;
        }
        double UNSIGNED_SHORT_4_4_4_4
        {
            get;
            set;
        }
        double TEXTURE6
        {
            get;
            set;
        }
        double RENDERBUFFER_WIDTH
        {
            get;
            set;
        }
        double RGBA4
        {
            get;
            set;
        }
        double ALWAYS
        {
            get;
            set;
        }
        double BLEND_EQUATION_ALPHA
        {
            get;
            set;
        }
        double COLOR_BUFFER_BIT
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP
        {
            get;
            set;
        }
        double DEPTH_BUFFER_BIT
        {
            get;
            set;
        }
        double STENCIL_CLEAR_VALUE
        {
            get;
            set;
        }
        double BLEND_EQUATION
        {
            get;
            set;
        }
        double RENDERBUFFER_GREEN_SIZE
        {
            get;
            set;
        }
        double NEAREST_MIPMAP_LINEAR
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_TYPE
        {
            get;
            set;
        }
        double INCR_WRAP
        {
            get;
            set;
        }
        double ONE_MINUS_DST_COLOR
        {
            get;
            set;
        }
        double HIGH_FLOAT
        {
            get;
            set;
        }
        double BYTE
        {
            get;
            set;
        }
        double FRONT_FACE
        {
            get;
            set;
        }
        double SAMPLE_ALPHA_TO_COVERAGE
        {
            get;
            set;
        }
        double CCW
        {
            get;
            set;
        }
        double TEXTURE13
        {
            get;
            set;
        }
        double MAX_VERTEX_ATTRIBS
        {
            get;
            set;
        }
        double MAX_VERTEX_TEXTURE_IMAGE_UNITS
        {
            get;
            set;
        }
        double TEXTURE_WRAP_T
        {
            get;
            set;
        }
        double UNPACK_PREMULTIPLY_ALPHA_WEBGL
        {
            get;
            set;
        }
        double FLOAT_VEC2
        {
            get;
            set;
        }
        double LUMINANCE
        {
            get;
            set;
        }
        double GREATER
        {
            get;
            set;
        }
        double INT_VEC2
        {
            get;
            set;
        }
        double VALIDATE_STATUS
        {
            get;
            set;
        }
        double FRAMEBUFFER
        {
            get;
            set;
        }
        double FRAMEBUFFER_UNSUPPORTED
        {
            get;
            set;
        }
        double TEXTURE5
        {
            get;
            set;
        }
        double FUNC_SUBTRACT
        {
            get;
            set;
        }
        double BLEND_DST_ALPHA
        {
            get;
            set;
        }
        double SAMPLER_CUBE
        {
            get;
            set;
        }
        double ONE_MINUS_DST_ALPHA
        {
            get;
            set;
        }
        double LESS
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP_POSITIVE_X
        {
            get;
            set;
        }
        double BLUE_BITS
        {
            get;
            set;
        }
        double DEPTH_TEST
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_STRIDE
        {
            get;
            set;
        }
        double DELETE_STATUS
        {
            get;
            set;
        }
        double TEXTURE18
        {
            get;
            set;
        }
        double POLYGON_OFFSET_FACTOR
        {
            get;
            set;
        }
        double UNSIGNED_INT
        {
            get;
            set;
        }
        double TEXTURE_2D
        {
            get;
            set;
        }
        double DST_COLOR
        {
            get;
            set;
        }
        double FLOAT_MAT2
        {
            get;
            set;
        }
        double COMPRESSED_TEXTURE_FORMATS
        {
            get;
            set;
        }
        double MAX_FRAGMENT_UNIFORM_VECTORS
        {
            get;
            set;
        }
        double DEPTH_STENCIL_ATTACHMENT
        {
            get;
            set;
        }
        double LUMINANCE_ALPHA
        {
            get;
            set;
        }
        double CW
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_NORMALIZED
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP_NEGATIVE_Z
        {
            get;
            set;
        }
        double LINEAR_MIPMAP_LINEAR
        {
            get;
            set;
        }
        double BUFFER_SIZE
        {
            get;
            set;
        }
        double SAMPLE_BUFFERS
        {
            get;
            set;
        }
        double TEXTURE15
        {
            get;
            set;
        }
        double ACTIVE_TEXTURE
        {
            get;
            set;
        }
        double VERTEX_SHADER
        {
            get;
            set;
        }
        double TEXTURE22
        {
            get;
            set;
        }
        double VERTEX_ATTRIB_ARRAY_POINTER
        {
            get;
            set;
        }
        double INCR
        {
            get;
            set;
        }
        double COMPILE_STATUS
        {
            get;
            set;
        }
        double MAX_COMBINED_TEXTURE_IMAGE_UNITS
        {
            get;
            set;
        }
        double TEXTURE7
        {
            get;
            set;
        }
        double UNSIGNED_SHORT_5_5_5_1
        {
            get;
            set;
        }
        double DEPTH_BITS
        {
            get;
            set;
        }
        double RGBA
        {
            get;
            set;
        }
        double TRIANGLE_STRIP
        {
            get;
            set;
        }
        double COLOR_CLEAR_VALUE
        {
            get;
            set;
        }
        double BROWSER_DEFAULT_WEBGL
        {
            get;
            set;
        }
        double INVALID_ENUM
        {
            get;
            set;
        }
        double SCISSOR_TEST
        {
            get;
            set;
        }
        double LINE_STRIP
        {
            get;
            set;
        }
        double FRAMEBUFFER_INCOMPLETE_ATTACHMENT
        {
            get;
            set;
        }
        double STENCIL_FUNC
        {
            get;
            set;
        }
        double FRAMEBUFFER_ATTACHMENT_OBJECT_NAME
        {
            get;
            set;
        }
        double RENDERBUFFER_HEIGHT
        {
            get;
            set;
        }
        double TEXTURE8
        {
            get;
            set;
        }
        double TRIANGLES
        {
            get;
            set;
        }
        double FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE
        {
            get;
            set;
        }
        double STENCIL_BACK_VALUE_MASK
        {
            get;
            set;
        }
        double TEXTURE25
        {
            get;
            set;
        }
        double RENDERBUFFER
        {
            get;
            set;
        }
        double LEQUAL
        {
            get;
            set;
        }
        double TEXTURE1
        {
            get;
            set;
        }
        double STENCIL_INDEX8
        {
            get;
            set;
        }
        double FUNC_ADD
        {
            get;
            set;
        }
        double STENCIL_FAIL
        {
            get;
            set;
        }
        double BLEND_SRC_ALPHA
        {
            get;
            set;
        }
        double BOOL
        {
            get;
            set;
        }
        double ALPHA_BITS
        {
            get;
            set;
        }
        double LOW_INT
        {
            get;
            set;
        }
        double TEXTURE10
        {
            get;
            set;
        }
        double SRC_COLOR
        {
            get;
            set;
        }
        double MAX_VARYING_VECTORS
        {
            get;
            set;
        }
        double BLEND_DST_RGB
        {
            get;
            set;
        }
        double TEXTURE_BINDING_CUBE_MAP
        {
            get;
            set;
        }
        double STENCIL_INDEX
        {
            get;
            set;
        }
        double TEXTURE_BINDING_2D
        {
            get;
            set;
        }
        double MEDIUM_INT
        {
            get;
            set;
        }
        double SHADER_TYPE
        {
            get;
            set;
        }
        double POLYGON_OFFSET_FILL
        {
            get;
            set;
        }
        double DYNAMIC_DRAW
        {
            get;
            set;
        }
        double TEXTURE4
        {
            get;
            set;
        }
        double STENCIL_BACK_PASS_DEPTH_FAIL
        {
            get;
            set;
        }
        double STREAM_DRAW
        {
            get;
            set;
        }
        double MAX_CUBE_MAP_TEXTURE_SIZE
        {
            get;
            set;
        }
        double TEXTURE17
        {
            get;
            set;
        }
        double TRIANGLE_FAN
        {
            get;
            set;
        }
        double UNPACK_ALIGNMENT
        {
            get;
            set;
        }
        double CURRENT_PROGRAM
        {
            get;
            set;
        }
        double LINES
        {
            get;
            set;
        }
        double INVALID_OPERATION
        {
            get;
            set;
        }
        double FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT
        {
            get;
            set;
        }
        double LINEAR_MIPMAP_NEAREST
        {
            get;
            set;
        }
        double CLAMP_TO_EDGE
        {
            get;
            set;
        }
        double RENDERBUFFER_DEPTH_SIZE
        {
            get;
            set;
        }
        double TEXTURE_WRAP_S
        {
            get;
            set;
        }
        double ELEMENT_ARRAY_BUFFER
        {
            get;
            set;
        }
        double UNSIGNED_SHORT_5_6_5
        {
            get;
            set;
        }
        double ACTIVE_UNIFORMS
        {
            get;
            set;
        }
        double FLOAT_VEC3
        {
            get;
            set;
        }
        double NO_ERROR
        {
            get;
            set;
        }
        double ATTACHED_SHADERS
        {
            get;
            set;
        }
        double DEPTH_ATTACHMENT
        {
            get;
            set;
        }
        double TEXTURE11
        {
            get;
            set;
        }
        double STENCIL_TEST
        {
            get;
            set;
        }
        double ONE
        {
            get;
            set;
        }
        double FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE
        {
            get;
            set;
        }
        double STATIC_DRAW
        {
            get;
            set;
        }
        double GEQUAL
        {
            get;
            set;
        }
        double BOOL_VEC4
        {
            get;
            set;
        }
        double COLOR_ATTACHMENT0
        {
            get;
            set;
        }
        double PACK_ALIGNMENT
        {
            get;
            set;
        }
        double MAX_TEXTURE_SIZE
        {
            get;
            set;
        }
        double STENCIL_PASS_DEPTH_FAIL
        {
            get;
            set;
        }
        double CULL_FACE_MODE
        {
            get;
            set;
        }
        double TEXTURE16
        {
            get;
            set;
        }
        double STENCIL_BACK_WRITEMASK
        {
            get;
            set;
        }
        double SRC_ALPHA
        {
            get;
            set;
        }
        double UNSIGNED_SHORT
        {
            get;
            set;
        }
        double TEXTURE21
        {
            get;
            set;
        }
        double FUNC_REVERSE_SUBTRACT
        {
            get;
            set;
        }
        double SHADING_LANGUAGE_VERSION
        {
            get;
            set;
        }
        double EQUAL
        {
            get;
            set;
        }
        double FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL
        {
            get;
            set;
        }
        double BOOL_VEC3
        {
            get;
            set;
        }
        double SAMPLER_2D
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP_NEGATIVE_X
        {
            get;
            set;
        }
        double MAX_TEXTURE_IMAGE_UNITS
        {
            get;
            set;
        }
        double TEXTURE_CUBE_MAP_POSITIVE_Y
        {
            get;
            set;
        }
        double RENDERBUFFER_INTERNAL_FORMAT
        {
            get;
            set;
        }
        double STENCIL_VALUE_MASK
        {
            get;
            set;
        }
        double ELEMENT_ARRAY_BUFFER_BINDING
        {
            get;
            set;
        }
        double ARRAY_BUFFER
        {
            get;
            set;
        }
        double DEPTH_RANGE
        {
            get;
            set;
        }
        double NICEST
        {
            get;
            set;
        }
        double ACTIVE_ATTRIBUTES
        {
            get;
            set;
        }
        double NEVER
        {
            get;
            set;
        }
        double FLOAT_VEC4
        {
            get;
            set;
        }
        double CURRENT_VERTEX_ATTRIB
        {
            get;
            set;
        }
        double STENCIL_PASS_DEPTH_PASS
        {
            get;
            set;
        }
        double INVERT
        {
            get;
            set;
        }
        double LINK_STATUS
        {
            get;
            set;
        }
        double RGB
        {
            get;
            set;
        }
        double INT_VEC4
        {
            get;
            set;
        }
        double TEXTURE2
        {
            get;
            set;
        }
        double UNPACK_COLORSPACE_CONVERSION_WEBGL
        {
            get;
            set;
        }
        double MEDIUM_FLOAT
        {
            get;
            set;
        }
        double SRC_ALPHA_SATURATE
        {
            get;
            set;
        }
        double BUFFER_USAGE
        {
            get;
            set;
        }
        double SHORT
        {
            get;
            set;
        }
        double NONE
        {
            get;
            set;
        }
        double UNSIGNED_BYTE
        {
            get;
            set;
        }
        double INT
        {
            get;
            set;
        }
        double SUBPIXEL_BITS
        {
            get;
            set;
        }
        double KEEP
        {
            get;
            set;
        }
        double SAMPLES
        {
            get;
            set;
        }
        double FRAGMENT_SHADER
        {
            get;
            set;
        }
        double LINE_WIDTH
        {
            get;
            set;
        }
        double BLEND_SRC_RGB
        {
            get;
            set;
        }
        double LOW_FLOAT
        {
            get;
            set;
        }
        double VERSION
        {
            get;
            set;
        }
    }
    public partial interface WebGLProgram : WebGLObject { }
    public partial interface OES_standard_derivatives
    {
        double FRAGMENT_SHADER_DERIVATIVE_HINT_OES
        {
            get;
            set;
        }
    }
    public partial interface WebGLFramebuffer : WebGLObject { }
    public partial interface WebGLShader : WebGLObject { }
    public partial interface OES_texture_float_linear { }
    public partial interface WebGLObject { }
    public partial interface WebGLBuffer : WebGLObject { }
    public partial interface WebGLShaderPrecisionFormat
    {
        double rangeMin
        {
            get;
            set;
        }
        double rangeMax
        {
            get;
            set;
        }
        double precision
        {
            get;
            set;
        }
    }
    public partial interface EXT_texture_filter_anisotropic
    {
        double TEXTURE_MAX_ANISOTROPY_EXT
        {
            get;
            set;
        }
        double MAX_TEXTURE_MAX_ANISOTROPY_EXT
        {
            get;
            set;
        }
    }
}

namespace Intl
{
    public partial interface CollatorOptions
    {
        string usage
        {
            get;
            set;
        }
        string localeMatcher
        {
            get;
            set;
        }
        bool numeric
        {
            get;
            set;
        }
        string caseFirst
        {
            get;
            set;
        }
        string sensitivity
        {
            get;
            set;
        }
        bool ignorePunctuation
        {
            get;
            set;
        }
    }
    public partial interface ResolvedCollatorOptions
    {
        string locale
        {
            get;
            set;
        }
        string usage
        {
            get;
            set;
        }
        string sensitivity
        {
            get;
            set;
        }
        bool ignorePunctuation
        {
            get;
            set;
        }
        string collation
        {
            get;
            set;
        }
        string caseFirst
        {
            get;
            set;
        }
        bool numeric
        {
            get;
            set;
        }
    }
    public partial interface Collator
    {
        double compare(string x, string y);
        ResolvedCollatorOptions resolvedOptions();
    }
    public partial interface NumberFormatOptions
    {
        string localeMatcher
        {
            get;
            set;
        }
        string style
        {
            get;
            set;
        }
        string currency
        {
            get;
            set;
        }
        string currencyDisplay
        {
            get;
            set;
        }
        bool useGrouping
        {
            get;
            set;
        }
    }
    public partial interface ResolvedNumberFormatOptions
    {
        string locale
        {
            get;
            set;
        }
        string numberingSystem
        {
            get;
            set;
        }
        string style
        {
            get;
            set;
        }
        string currency
        {
            get;
            set;
        }
        string currencyDisplay
        {
            get;
            set;
        }
        double minimumintegerDigits
        {
            get;
            set;
        }
        double minimumFractionDigits
        {
            get;
            set;
        }
        double maximumFractionDigits
        {
            get;
            set;
        }
        double minimumSignificantDigits
        {
            get;
            set;
        }
        double maximumSignificantDigits
        {
            get;
            set;
        }
        bool useGrouping
        {
            get;
            set;
        }
    }
    public partial interface NumberFormat
    {
        string format(double value);
        ResolvedNumberFormatOptions resolvedOptions();
    }
    public partial interface DateTimeFormatOptions
    {
        string localeMatcher
        {
            get;
            set;
        }
        string weekday
        {
            get;
            set;
        }
        string era
        {
            get;
            set;
        }
        string year
        {
            get;
            set;
        }
        string month
        {
            get;
            set;
        }
        string day
        {
            get;
            set;
        }
        string hour
        {
            get;
            set;
        }
        string minute
        {
            get;
            set;
        }
        string second
        {
            get;
            set;
        }
        string timeZoneName
        {
            get;
            set;
        }
        string formatMatcher
        {
            get;
            set;
        }
        bool hour12
        {
            get;
            set;
        }
    }
    public partial interface ResolvedDateTimeFormatOptions
    {
        string locale
        {
            get;
            set;
        }
        string calendar
        {
            get;
            set;
        }
        string numberingSystem
        {
            get;
            set;
        }
        string timeZone
        {
            get;
            set;
        }
        bool hour12
        {
            get;
            set;
        }
        string weekday
        {
            get;
            set;
        }
        string era
        {
            get;
            set;
        }
        string year
        {
            get;
            set;
        }
        string month
        {
            get;
            set;
        }
        string day
        {
            get;
            set;
        }
        string hour
        {
            get;
            set;
        }
        string minute
        {
            get;
            set;
        }
        string second
        {
            get;
            set;
        }
        string timeZoneName
        {
            get;
            set;
        }
    }
    public partial interface DateTimeFormat
    {
        string format(double date);
        ResolvedDateTimeFormatOptions resolvedOptions();
    }
}