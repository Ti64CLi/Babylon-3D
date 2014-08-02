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
        int byteLength
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
        int byteOffset
        {
            get;
            set;
        }
        int byteLength
        {
            get;
            set;
        }
    }
    public partial interface Int8Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        sbyte this[int index]
        {
            get;
            set;
        }
        sbyte get(int index);
        void set(int index, sbyte value);
        void set(Int8Array array, int offset = 0);
        void set(Array<sbyte> array, int offset = 0);
        Int8Array subarray(int begin, int end = 0);
    }
    public partial interface Uint8Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        byte this[int index]
        {
            get;
            set;
        }
        byte get(int index);
        void set(int index, byte value);
        void set(Uint8Array array, int offset = 0);
        void set(Array<byte> array, int offset = 0);
        Uint8Array subarray(int begin, int end = 0);
    }
    public partial interface Int16Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        short this[int index]
        {
            get;
            set;
        }
        short get(int index);
        void set(int index, short value);
        void set(Int16Array array, int offset = 0);
        void set(Array<short> array, int offset = 0);
        Int16Array subarray(int begin, int end = 0);
    }
    public partial interface Uint16Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        ushort this[int index]
        {
            get;
            set;
        }
        ushort get(int index);
        void set(int index, ushort value);
        void set(Uint16Array array, int offset = 0);
        void set(Array<ushort> array, int offset = 0);
        Uint16Array subarray(int begin, int end = 0);
    }
    public partial interface Int32Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        int this[int index]
        {
            get;
            set;
        }
        int get(int index);
        void set(int index, int value);
        void set(Int32Array array, int offset = 0);
        void set(Array<int> array, int offset = 0);
        Int32Array subarray(int begin, int end = 0);
    }
    public partial interface Uint32Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        int this[int index]
        {
            get;
            set;
        }
        uint get(int index);
        void set(int index, uint value);
        void set(Uint32Array array, int offset = 0);
        void set(Array<uint> array, int offset = 0);
        Uint32Array subarray(int begin, int end = 0);
    }
    public partial interface Float32Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        float this[int index]
        {
            get;
            set;
        }
        float get(int index);
        void set(int index, float value);
        void set(Float32Array array, int offset = 0);
        void set(Array<float> array, int offset = 0);
        Float32Array subarray(int begin, int end = 0);
    }
    public partial interface Float64Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        int this[int index]
        {
            get;
            set;
        }
        int get(int index);
        void set(int index, int value);
        void set(Float64Array array, int offset = 0);
        void set(Array<double> array, int offset = 0);
        Float64Array subarray(int begin, int end = 0);
    }
    public partial interface DataView : ArrayBufferView
    {
        int getInt8(int byteOffset);
        int getUint8(int byteOffset);
        int getInt16(int byteOffset, bool littleEndian = false);
        int getUint16(int byteOffset, bool littleEndian = false);
        int getInt32(int byteOffset, bool littleEndian = false);
        int getUint32(int byteOffset, bool littleEndian = false);
        int getFloat32(int byteOffset, bool littleEndian = false);
        int getFloat64(int byteOffset, bool littleEndian = false);
        void setInt8(int byteOffset, int value);
        void setUint8(int byteOffset, int value);
        void setInt16(int byteOffset, int value, bool littleEndian = false);
        void setUint16(int byteOffset, int value, bool littleEndian = false);
        void setInt32(int byteOffset, int value, bool littleEndian = false);
        void setUint32(int byteOffset, int value, bool littleEndian = false);
        void setFloat32(int byteOffset, int value, bool littleEndian = false);
        void setFloat64(int byteOffset, int value, bool littleEndian = false);
    }
    public partial interface Map<K, V>
    {
        void clear();
        bool delete(K key);
        void forEach(System.Action<V, K, Map<K, V>> callbackfn, object thisArg = null);
        V get(K key);
        bool has(K key);
        Map<K, V> set(K key, V value);
        int size
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
        int size
        {
            get;
            set;
        }
    }
    public partial interface String
    {
        int localeCompare(string that, Array<string> locales, Intl.CollatorOptions options = null);
        int localeCompare(string that, string locale, Intl.CollatorOptions options = null);
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
        int timeout
        {
            get;
            set;
        }
        int maximumAge
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
        int pointerId
        {
            get;
            set;
        }
        double width
        {
            get;
            set;
        }
        int height
        {
            get;
            set;
        }
        int pressure
        {
            get;
            set;
        }
        int tiltX
        {
            get;
            set;
        }
        int tiltY
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
        int contentX
        {
            get;
            set;
        }
        int contentY
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
        int scaleFactor
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
        int alpha
        {
            get;
            set;
        }
        int beta
        {
            get;
            set;
        }
        int gamma
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
        int detail
        {
            get;
            set;
        }
        int screenX
        {
            get;
            set;
        }
        int screenY
        {
            get;
            set;
        }
        int clientX
        {
            get;
            set;
        }
        int clientY
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
        int button
        {
            get;
            set;
        }
        int buttons
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
        int Length
        {
            get;
            set;
        }
        TNode item(int index);
        TNode this[int index]
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
        int offsetHeight
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
        int sourceIndex
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
        int offsetTop
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
        int uniqueNumber
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
        int offsetLeft
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
        int tabIndex
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
        int offsetWidth
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
        bool removeBehavior(int cookie);
        bool contains(HTMLElement child);
        void click();
        Element insertAdjacentElement(string position, Element insertedElement);
        void mergeAttributes(HTMLElement source, bool preserveIdentity = false);
        string replaceAdjacentText(string where, string newText);
        Element applyElement(Element apply, string where = null);
        int addBehavior(string bstrUrl, object factory = null);
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
        int documentMode
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
        CSSStyleSheet createStyleSheet(string href = null, int index = 0);
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
        NodeList msElementsFromRect(int left, int top, double width, int height);
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
        int keyCode
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
        int offsetX
        {
            get;
            set;
        }
        object recordset
        {
            get;
            set;
        }
        int screenX
        {
            get;
            set;
        }
        int buttonID
        {
            get;
            set;
        }
        double wheelDelta
        {
            get;
            set;
        }
        int reason
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
        int behaviorCookie
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
        int offsetY
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        int behaviorPart
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
        int clientY
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
        int screenY
        {
            get;
            set;
        }
        bool ctrlLeft
        {
            get;
            set;
        }
        int button
        {
            get;
            set;
        }
        string srcUrn
        {
            get;
            set;
        }
        int clientX
        {
            get;
            set;
        }
        string actionURL
        {
            get;
            set;
        }
        object getAttribute(string strAttributeName, int lFlags = 0);
        void setAttribute(string strAttributeName, object AttributeValue, int lFlags = 0);
        bool removeAttribute(string strAttributeName, int lFlags = 0);
    }
    public partial interface HTMLCanvasElement : HTMLElement
    {
        int width
        {
            get;
            set;
        }
        int height
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
        int screenX
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
        int pageXOffset
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
        int innerHeight
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
        int outerWidth
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
        int innerWidth
        {
            get;
            set;
        }
        System.Func<Event, object> onoffline
        {
            get;
            set;
        }
        int Length
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
        int pageYOffset
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
        int outerHeight
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
        int screenY
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
        int animationStartTime
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
        int msAnimationStartTime
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
        int devicePixelRatio
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
        void scroll(double x = 0, double y = 0);
        void focus();
        void scrollTo(double x = 0, double y = 0);
        void print();
        string prompt(string message = null, string _default = null);
        string ToString();
        Window open(string url = null, string target = null, string features = null, bool replace = false);
        void scrollBy(double x = 0, double y = 0);
        bool confirm(string message = null);
        void close();
        void postMessage(object message, string targetOrigin, object ports = null);
        object showModalDialog(string url = null, object argument = null, object options = null);
        void blur();
        Selection getSelection();
        CSSStyleDeclaration getComputedStyle(Element elt, string pseudoElt = null);
        void msCancelRequestAnimationFrame(int handle);
        MediaQueryList matchMedia(string mediaQuery);
        void cancelAnimationFrame(int handle);
        bool msIsStaticHTML(string html);
        MediaQueryList msMatchMedia(string mediaQuery);
        int requestAnimationFrame(FrameRequestCallback callback);
        int msRequestAnimationFrame(FrameRequestCallback callback);
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
        int cols
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
        void deleteRow(int index = 0);
        HTMLElement createTBody();
        void deleteCaption();
        HTMLElement insertRow(int index = 0);
        void deleteTFoot();
        HTMLElement createTHead();
        void deleteTHead();
        HTMLElement createCaption();
        object moveRow(int indexFrom = 0, int indexTo = 0);
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
        void setResourceTimingBufferSize(int maxSize);
        int now();
    }
    public partial interface MSDataBindingTableExtensions
    {
        int dataPageSize
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
        void clearTimeout(int handle);
        int setTimeout(object handler, object timeout = null, params object[] args);
        void clearInterval(int handle);
        int setInterval(object handler, object timeout = null, params object[] args);
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
        int SVG_MARKER_ORIENT_UNKNOWN
        {
            get;
            set;
        }
        int SVG_MARKER_ORIENT_ANGLE
        {
            get;
            set;
        }
        int SVG_MARKERUNITS_UNKNOWN
        {
            get;
            set;
        }
        int SVG_MARKERUNITS_STROKEWIDTH
        {
            get;
            set;
        }
        int SVG_MARKER_ORIENT_AUTO
        {
            get;
            set;
        }
        int SVG_MARKERUNITS_USERSPACEONUSE
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
        int Length
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
        string item(int index);
        string this[int index]
        {
            get;
            set;
        }
        void setProperty(string propertyName, string value, string priority = null);
    }
    public partial interface SVGGElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired { }
    public partial interface MSStyleCSSProperties : MSCSSProperties
    {
        int pixelWidth
        {
            get;
            set;
        }
        int posHeight
        {
            get;
            set;
        }
        int posLeft
        {
            get;
            set;
        }
        int pixelTop
        {
            get;
            set;
        }
        int pixelBottom
        {
            get;
            set;
        }
        bool textDecorationNone
        {
            get;
            set;
        }
        int pixelLeft
        {
            get;
            set;
        }
        int posTop
        {
            get;
            set;
        }
        int posBottom
        {
            get;
            set;
        }
        bool textDecorationOverline
        {
            get;
            set;
        }
        int posWidth
        {
            get;
            set;
        }
        bool textDecorationLineThrough
        {
            get;
            set;
        }
        int pixelHeight
        {
            get;
            set;
        }
        bool textDecorationBlink
        {
            get;
            set;
        }
        int posRight
        {
            get;
            set;
        }
        int pixelRight
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
        int msMaxTouchPoints
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
        int maxTouchPoints
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
        int previousScale
        {
            get;
            set;
        }
        int newScale
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
        int left
        {
            get;
            set;
        }
        int width
        {
            get;
            set;
        }
        int right
        {
            get;
            set;
        }
        int top
        {
            get;
            set;
        }
        int bottom
        {
            get;
            set;
        }
        int height
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
        int SVG_UNIT_TYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_UNIT_TYPE_OBJECTBOUNDINGBOX
        {
            get;
            set;
        }
        int SVG_UNIT_TYPE_USERSPACEONUSE
        {
            get;
            set;
        }
    }
    public partial interface Element : Node, NodeSelector, ElementTraversal, GlobalEventHandlers
    {
        int scrollTop
        {
            get;
            set;
        }
        int clientLeft
        {
            get;
            set;
        }
        int scrollLeft
        {
            get;
            set;
        }
        string tagName
        {
            get;
            set;
        }
        int clientWidth
        {
            get;
            set;
        }
        int scrollWidth
        {
            get;
            set;
        }
        int clientHeight
        {
            get;
            set;
        }
        int clientTop
        {
            get;
            set;
        }
        int scrollHeight
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
        int msContentZoomFactor
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
        void msReleasePointerCapture(int pointerId);
        void msSetPointerCapture(int pointerId);
        void msZoomTo(MsZoomToOptions args);
        void setPointerCapture(int pointerId);
        ClientRect msGetUntransformedBounds();
        void releasePointerCapture(int pointerId);
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
        void remove(int index = 0);
        void add(HTMLElement element, object before = null);
    }
    public partial interface SVGDescElement : SVGElement, SVGStylable, SVGLangSpace { }
    public partial interface Node : EventTarget
    {
        int nodeType
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
        int compareDocumentPosition(Node other);
        void normalize();
        bool isSameNode(Node other);
        bool hasAttributes();
        string lookupNamespaceURI(string prefix);
        Node cloneNode(bool deep = false);
        bool hasChildNodes();
        Node replaceChild(Node newChild, Node oldChild);
        Node insertBefore(Node newChild, Node refChild = null);
        int ENTITY_REFERENCE_NODE
        {
            get;
            set;
        }
        int ATTRIBUTE_NODE
        {
            get;
            set;
        }
        int DOCUMENT_FRAGMENT_NODE
        {
            get;
            set;
        }
        int TEXT_NODE
        {
            get;
            set;
        }
        int ELEMENT_NODE
        {
            get;
            set;
        }
        int COMMENT_NODE
        {
            get;
            set;
        }
        int DOCUMENT_POSITION_DISCONNECTED
        {
            get;
            set;
        }
        int DOCUMENT_POSITION_CONTAINED_BY
        {
            get;
            set;
        }
        int DOCUMENT_POSITION_CONTAINS
        {
            get;
            set;
        }
        int DOCUMENT_TYPE_NODE
        {
            get;
            set;
        }
        int DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC
        {
            get;
            set;
        }
        int DOCUMENT_NODE
        {
            get;
            set;
        }
        int ENTITY_NODE
        {
            get;
            set;
        }
        int PROCESSING_INSTRUCTION_NODE
        {
            get;
            set;
        }
        int CDATA_SECTION_NODE
        {
            get;
            set;
        }
        int NOTATION_NODE
        {
            get;
            set;
        }
        int DOCUMENT_POSITION_FOLLOWING
        {
            get;
            set;
        }
        int DOCUMENT_POSITION_PRECEDING
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
        int layerY
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
        int pageX
        {
            get;
            set;
        }
        int offsetY
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
        int offsetX
        {
            get;
            set;
        }
        int screenX
        {
            get;
            set;
        }
        int clientY
        {
            get;
            set;
        }
        bool shiftKey
        {
            get;
            set;
        }
        int layerX
        {
            get;
            set;
        }
        int screenY
        {
            get;
            set;
        }
        EventTarget relatedTarget
        {
            get;
            set;
        }
        int button
        {
            get;
            set;
        }
        int pageY
        {
            get;
            set;
        }
        int buttons
        {
            get;
            set;
        }
        int clientX
        {
            get;
            set;
        }
        void initMouseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg, EventTarget relatedTargetArg);
        bool getModifierState(string keyArg);
    }
    public partial interface RangeException
    {
        int code
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
        string ToString();
        int INVALID_NODE_TYPE_ERR
        {
            get;
            set;
        }
        int BAD_BOUNDARYPOINTS_ERR
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
        int start
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
        int size
        {
            get;
            set;
        }
        int Length
        {
            get;
            set;
        }
        int selectedIndex
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
        void remove(int index = 0);
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
        int boundingLeft
        {
            get;
            set;
        }
        string htmlText
        {
            get;
            set;
        }
        int offsetLeft
        {
            get;
            set;
        }
        int boundingWidth
        {
            get;
            set;
        }
        int boundingHeight
        {
            get;
            set;
        }
        int boundingTop
        {
            get;
            set;
        }
        string text
        {
            get;
            set;
        }
        int offsetTop
        {
            get;
            set;
        }
        void moveToPoint(double x, double y);
        object queryCommandValue(string cmdID);
        string getBookmark();
        int move(string unit, int count = 0);
        bool queryCommandIndeterm(string cmdID);
        void scrollIntoView(bool fStart = false);
        bool findText(string _string, int count = 0, int flags = 0);
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
        int moveEnd(string unit, int count = 0);
        ClientRectList getClientRects();
        int moveStart(string unit, int count = 0);
        Element parentElement();
        bool queryCommandState(string cmdID);
        int compareEndPoints(string how, TextRange sourceRange);
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
        int addImport(string bstrURL, int lIndex = 0);
        int addPageRule(string bstrSelector, string bstrStyle, int lIndex = 0);
        int insertRule(string rule, int index = 0);
        void removeRule(int lIndex);
        void deleteRule(int index = 0);
        int addRule(string bstrSelector, string bstrStyle = null, int lIndex = 0);
        void removeImport(int lIndex);
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
        int anchorOffset
        {
            get;
            set;
        }
        int focusOffset
        {
            get;
            set;
        }
        int rangeCount
        {
            get;
            set;
        }
        void addRange(Range range);
        void collapseToEnd();
        string ToString();
        void selectAllChildren(Node parentNode);
        Range getRangeAt(int index);
        void collapse(Node parentNode, int offset);
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
        int Length
        {
            get;
            set;
        }
        object queryCommandValue(string cmdID);
        void remove(int index);
        void add(Element item);
        bool queryCommandIndeterm(string cmdID);
        void scrollIntoView(object varargStart = null);
        Element item(int index);
        Element this[int index]
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
        int index
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
        void initMouseWheelEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, int buttonArg, EventTarget relatedTargetArg, string modifiersListArg, double wheelDeltaArg);
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
        int numberOfItems
        {
            get;
            set;
        }
        SVGPoint replaceItem(SVGPoint newItem, int index);
        SVGPoint getItem(int index);
        void clear();
        SVGPoint appendItem(SVGPoint newItem);
        SVGPoint initialize(SVGPoint newItem);
        SVGPoint removeItem(int index);
        SVGPoint insertItemBefore(SVGPoint newItem, int index);
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
        int buttonID
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
        int Length
        {
            get;
            set;
        }
        CSSPageRule item(int index);
        CSSPageRule this[int index]
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
        object getAttribute(string attributeName, int flags = 0);
        void setAttribute(string attributeName, object AttributeValue, int flags = 0);
        bool removeAttribute(string attributeName, int flags = 0);
    }
    public partial interface HTMLCollection : MSHTMLCollectionExtensions
    {
        int Length
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
        int width
        {
            get;
            set;
        }
        int vspace
        {
            get;
            set;
        }
        int naturalHeight
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
        int naturalWidth
        {
            get;
            set;
        }
        string name
        {
            get;
            set;
        }
        int height
        {
            get;
            set;
        }
        string border
        {
            get;
            set;
        }
        int hspace
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
        string ToString();
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
        int valueInSpecifiedUnits
        {
            get;
            set;
        }
        int value
        {
            get;
            set;
        }
        int unitType
        {
            get;
            set;
        }
        void newValueSpecifiedUnits(int unitType, int valueInSpecifiedUnits);
        void convertToSpecifiedUnits(int unitType);
        int SVG_ANGLETYPE_RAD
        {
            get;
            set;
        }
        int SVG_ANGLETYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_ANGLETYPE_UNSPECIFIED
        {
            get;
            set;
        }
        int SVG_ANGLETYPE_DEG
        {
            get;
            set;
        }
        int SVG_ANGLETYPE_GRAD
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
        void addColorStop(int offset, string color);
    }
    public partial interface KeyboardEvent : UIEvent
    {
        int location
        {
            get;
            set;
        }
        int keyCode
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
        int charCode
        {
            get;
            set;
        }
        bool getModifierState(string keyArg);
        void initKeyboardEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string keyArg, int locationArg, string modifiersListArg, bool repeat, string locale);
        int DOM_KEY_LOCATION_RIGHT
        {
            get;
            set;
        }
        int DOM_KEY_LOCATION_STANDARD
        {
            get;
            set;
        }
        int DOM_KEY_LOCATION_LEFT
        {
            get;
            set;
        }
        int DOM_KEY_LOCATION_NUMPAD
        {
            get;
            set;
        }
        int DOM_KEY_LOCATION_JOYSTICK
        {
            get;
            set;
        }
        int DOM_KEY_LOCATION_MOBILE
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
        int rowIndex
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
        int sectionRowIndex
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
        void deleteCell(int index = 0);
        HTMLElement insertCell(int index = 0);
    }
    public partial interface CanvasRenderingContext2D
    {
        int miterLimit
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
        int lineDashOffset
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
        int shadowOffsetX
        {
            get;
            set;
        }
        int lineWidth
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
        int globalAlpha
        {
            get;
            set;
        }
        int shadowOffsetY
        {
            get;
            set;
        }
        object fillStyle
        {
            get;
            set;
        }
        int shadowBlur
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
        void setTransform(int m11, int m12, int m21, int m22, int dx, int dy);
        void save();
        void arc(double x, double y, int radius, int startAngle, int endAngle, bool anticlockwise = false);
        TextMetrics measureText(string text);
        bool isPointInPath(double x, double y, string fillRule = null);
        void quadraticCurveTo(int cpx, int cpy, double x, double y);
        void putImageData(ImageData imagedata, int dx, int dy, int dirtyX = 0, int dirtyY = 0, int dirtyWidth = 0, int dirtyHeight = 0);
        void rotate(int angle);
        void fillText(string text, double x, double y, int maxWidth = 0);
        void translate(double x, double y);
        void scale(double x, double y);
        CanvasGradient createRadialGradient(double x0, double y0, int r0, double x1, double y1, int r1);
        void lineTo(double x, double y);
        Array<double> getLineDash();
        void fill(string fillRule = null);
        ImageData createImageData(object imageDataOrSw, int sh = 0);
        CanvasPattern createPattern(HTMLElement image, string repetition);
        void closePath();
        void rect(double x, double y, double w, int h);
        void clip(string fillRule = null);
        void clearRect(double x, double y, double w, int h);
        void moveTo(double x, double y);
        ImageData getImageData(int sx, int sy, int sw, int sh);
        void fillRect(double x, double y, double w, int h);
        void bezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, double x, double y);
        void drawImage(HTMLElement image, int offsetX, int offsetY, double width = 0, int height = 0, int canvasOffsetX = 0, int canvasOffsetY = 0, int canvasImageWidth = 0, int canvasImageHeight = 0);
        void transform(int m11, int m12, int m21, int m22, int dx, int dy);
        void stroke();
        void strokeRect(double x, double y, double w, int h);
        void setLineDash(Array<double> segments);
        void strokeText(string text, double x, double y, int maxWidth = 0);
        void beginPath();
        void arcTo(double x1, double y1, double x2, double y2, int radius);
        CanvasGradient createLinearGradient(double x0, double y0, double x1, double y1);
    }
    public partial interface MSCSSRuleList
    {
        int Length
        {
            get;
            set;
        }
        CSSStyleRule item(int index = 0);
        CSSStyleRule this[int index]
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
        int r2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        int angle
        {
            get;
            set;
        }
        int r1
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
        int numberOfItems
        {
            get;
            set;
        }
        SVGTransform getItem(int index);
        SVGTransform consolidate();
        void clear();
        SVGTransform appendItem(SVGTransform newItem);
        SVGTransform initialize(SVGTransform newItem);
        SVGTransform removeItem(int index);
        SVGTransform insertItemBefore(SVGTransform newItem, int index);
        SVGTransform replaceItem(SVGTransform newItem, int index);
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
        int insertRule(string rule, int index = 0);
        void deleteRule(int index = 0);
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
        int status
        {
            get;
            set;
        }
        int readyState
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
        int timeout
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
        int LOADING
        {
            get;
            set;
        }
        int DONE
        {
            get;
            set;
        }
        int UNSENT
        {
            get;
            set;
        }
        int OPENED
        {
            get;
            set;
        }
        int HEADERS_RECEIVED
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
        int deviceXDPI
        {
            get;
            set;
        }
        bool fontSmoothingEnabled
        {
            get;
            set;
        }
        int bufferDepth
        {
            get;
            set;
        }
        int logicalXDPI
        {
            get;
            set;
        }
        int systemXDPI
        {
            get;
            set;
        }
        int availHeight
        {
            get;
            set;
        }
        int height
        {
            get;
            set;
        }
        int logicalYDPI
        {
            get;
            set;
        }
        int systemYDPI
        {
            get;
            set;
        }
        int updateInterval
        {
            get;
            set;
        }
        int colorDepth
        {
            get;
            set;
        }
        int availWidth
        {
            get;
            set;
        }
        int deviceYDPI
        {
            get;
            set;
        }
        int pixelDepth
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
        int altitudeAccuracy
        {
            get;
            set;
        }
        int longitude
        {
            get;
            set;
        }
        int latitude
        {
            get;
            set;
        }
        int speed
        {
            get;
            set;
        }
        int heading
        {
            get;
            set;
        }
        int altitude
        {
            get;
            set;
        }
        int accuracy
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
        void initFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, EventTarget relatedTargetArg);
    }
    public partial interface Range
    {
        int startOffset
        {
            get;
            set;
        }
        bool collapsed
        {
            get;
            set;
        }
        int endOffset
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
        void setStart(Node refNode, int offset);
        void setEndBefore(Node refNode);
        void setStartBefore(Node refNode);
        void selectNode(Node refNode);
        void detach();
        ClientRect getBoundingClientRect();
        string ToString();
        int compareBoundaryPoints(int how, Range sourceRange);
        void insertNode(Node newNode);
        void collapse(bool toStart);
        void selectNodeContents(Node refNode);
        DocumentFragment cloneContents();
        void setEnd(Node refNode, int offset);
        Range cloneRange();
        ClientRectList getClientRects();
        void surroundContents(Node newParent);
        void deleteContents();
        void setStartAfter(Node refNode);
        DocumentFragment extractContents();
        void setEndAfter(Node refNode);
        DocumentFragment createContextualFragment(string fragment);
        int END_TO_END
        {
            get;
            set;
        }
        int START_TO_START
        {
            get;
            set;
        }
        int START_TO_END
        {
            get;
            set;
        }
        int END_TO_START
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
        int Length
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
        int pixelUnitToMillimeterY
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onresize
        {
            get;
            set;
        }
        int screenPixelToMillimeterY
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
        int pixelUnitToMillimeterX
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
        int currentScale
        {
            get;
            set;
        }
        System.Func<UIEvent, object> onscroll
        {
            get;
            set;
        }
        int screenPixelToMillimeterX
        {
            get;
            set;
        }
        void setCurrentTime(int seconds);
        SVGLength createSVGLength();
        NodeList getIntersectionList(SVGRect rect, SVGElement referenceElement);
        void unpauseAnimations();
        SVGRect createSVGRect();
        bool checkIntersection(SVGElement element, SVGRect rect);
        void unsuspendRedrawAll();
        void pauseAnimations();
        int suspendRedraw(int maxWaitMilliseconds);
        void deselectAll();
        SVGAngle createSVGAngle();
        NodeList getEnclosureList(SVGRect rect, SVGElement referenceElement);
        SVGTransform createSVGTransform();
        void unsuspendRedraw(int suspendHandleID);
        void forceRedraw();
        int getCurrentTime();
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
        int animVal
        {
            get;
            set;
        }
        int baseVal
        {
            get;
            set;
        }
    }
    public partial interface SVGTextElement : SVGTextPositioningElement, SVGTransformable { }
    public partial interface SVGTSpanElement : SVGTextPositioningElement { }
    public partial interface HTMLLIElement : HTMLElement, DOML2DeprecatedListNumberingAndBulletStyle
    {
        int value
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
        int remainingSpace
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
        int Length
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
        string key(int index);
        string this[int index]
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
        int vspace
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
        int hspace
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
        int Length
        {
            get;
            set;
        }
        TextRange item(int index);
        TextRange this[int index]
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
        int attrChange
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
        void initMutationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Node relatedNodeArg, string prevValueArg, string newValueArg, string attrNameArg, int attrChangeArg);
        int MODIFICATION
        {
            get;
            set;
        }
        int REMOVAL
        {
            get;
            set;
        }
        int ADDITION
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
        void initDragEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg, EventTarget relatedTargetArg, DataTransfer dataTransferArg);
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
        void deleteRow(int index = 0);
        object moveRow(int indexFrom = 0, int indexTo = 0);
        HTMLElement insertRow(int index = 0);
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
        int selectionStart
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
        int size
        {
            get;
            set;
        }
        int loop
        {
            get;
            set;
        }
        int selectionEnd
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
        int vspace
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
        int hspace
        {
            get;
            set;
        }
        int maxLength
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
        int valueAsNumber
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
        void setSelectionRange(int start, int end);
        void select();
        bool checkValidity();
        void stepDown(int n = 0);
        void stepUp(int n = 0);
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
        string ToString();
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
        int animVal
        {
            get;
            set;
        }
        int baseVal
        {
            get;
            set;
        }
    }
    public partial interface PerformanceTiming
    {
        int redirectStart
        {
            get;
            set;
        }
        int domainLookupEnd
        {
            get;
            set;
        }
        int responseStart
        {
            get;
            set;
        }
        int domComplete
        {
            get;
            set;
        }
        int domainLookupStart
        {
            get;
            set;
        }
        int loadEventStart
        {
            get;
            set;
        }
        int msFirstPaint
        {
            get;
            set;
        }
        int unloadEventEnd
        {
            get;
            set;
        }
        int fetchStart
        {
            get;
            set;
        }
        int requestStart
        {
            get;
            set;
        }
        int domInteractive
        {
            get;
            set;
        }
        int navigationStart
        {
            get;
            set;
        }
        int connectEnd
        {
            get;
            set;
        }
        int loadEventEnd
        {
            get;
            set;
        }
        int connectStart
        {
            get;
            set;
        }
        int responseEnd
        {
            get;
            set;
        }
        int domLoading
        {
            get;
            set;
        }
        int redirectEnd
        {
            get;
            set;
        }
        int unloadEventStart
        {
            get;
            set;
        }
        int domContentLoadedEventStart
        {
            get;
            set;
        }
        int domContentLoadedEventEnd
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
        int code
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
        string ToString();
        int DISPATCH_REQUEST_ERR
        {
            get;
            set;
        }
        int UNSPECIFIED_EVENT_TYPE_ERR
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
        int r2
        {
            get;
            set;
        }
        double x
        {
            get;
            set;
        }
        int angle
        {
            get;
            set;
        }
        int r1
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
        int numberOfItems
        {
            get;
            set;
        }
        string replaceItem(string newItem, int index);
        string getItem(int index);
        void clear();
        string appendItem(string newItem);
        string initialize(string newItem);
        string removeItem(int index);
        string insertItemBefore(string newItem, int index);
    }
    public partial interface XDomainRequest
    {
        int timeout
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
        int childElementCount
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
        int valueInSpecifiedUnits
        {
            get;
            set;
        }
        int value
        {
            get;
            set;
        }
        int unitType
        {
            get;
            set;
        }
        void newValueSpecifiedUnits(int unitType, int valueInSpecifiedUnits);
        void convertToSpecifiedUnits(int unitType);
        int SVG_LENGTHTYPE_NUMBER
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_CM
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_PC
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_PERCENTAGE
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_MM
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_PT
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_IN
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_EMS
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_PX
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_LENGTHTYPE_EXS
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
        int getCharNumAtPosition(SVGPoint point);
        SVGPoint getStartPositionOfChar(int charnum);
        SVGRect getExtentOfChar(int charnum);
        int getComputedTextLength();
        int getSubStringLength(int charnum, int nchars);
        void selectSubString(int charnum, int nchars);
        int getNumberOfChars();
        int getRotationOfChar(int charnum);
        SVGPoint getEndPositionOfChar(int charnum);
        int LENGTHADJUST_SPACING
        {
            get;
            set;
        }
        int LENGTHADJUST_SPACINGANDGLYPHS
        {
            get;
            set;
        }
        int LENGTHADJUST_UNKNOWN
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
        string ToString();
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
        int startTime
        {
            get;
            set;
        }
        int duration
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
        int type
        {
            get;
            set;
        }
        int angle
        {
            get;
            set;
        }
        SVGMatrix matrix
        {
            get;
            set;
        }
        void setTranslate(int tx, int ty);
        void setScale(int sx, int sy);
        void setMatrix(SVGMatrix matrix);
        void setSkewY(int angle);
        void setRotate(int angle, int cx, int cy);
        void setSkewX(int angle);
        int SVG_TRANSFORM_SKEWX
        {
            get;
            set;
        }
        int SVG_TRANSFORM_UNKNOWN
        {
            get;
            set;
        }
        int SVG_TRANSFORM_SCALE
        {
            get;
            set;
        }
        int SVG_TRANSFORM_TRANSLATE
        {
            get;
            set;
        }
        int SVG_TRANSFORM_MATRIX
        {
            get;
            set;
        }
        int SVG_TRANSFORM_ROTATE
        {
            get;
            set;
        }
        int SVG_TRANSFORM_SKEWY
        {
            get;
            set;
        }
    }
    public partial interface UIEvent : Event
    {
        int detail
        {
            get;
            set;
        }
        Window view
        {
            get;
            set;
        }
        void initUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg);
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
        int pathSegType
        {
            get;
            set;
        }
        string pathSegTypeAsLetter
        {
            get;
            set;
        }
        int PATHSEG_MOVETO_REL
        {
            get;
            set;
        }
        int PATHSEG_LINETO_VERTICAL_REL
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_CUBIC_SMOOTH_ABS
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_QUADRATIC_REL
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_CUBIC_ABS
        {
            get;
            set;
        }
        int PATHSEG_LINETO_HORIZONTAL_ABS
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_QUADRATIC_ABS
        {
            get;
            set;
        }
        int PATHSEG_LINETO_ABS
        {
            get;
            set;
        }
        int PATHSEG_CLOSEPATH
        {
            get;
            set;
        }
        int PATHSEG_LINETO_HORIZONTAL_REL
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_CUBIC_SMOOTH_REL
        {
            get;
            set;
        }
        int PATHSEG_LINETO_REL
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_QUADRATIC_SMOOTH_ABS
        {
            get;
            set;
        }
        int PATHSEG_ARC_REL
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_CUBIC_REL
        {
            get;
            set;
        }
        int PATHSEG_UNKNOWN
        {
            get;
            set;
        }
        int PATHSEG_LINETO_VERTICAL_ABS
        {
            get;
            set;
        }
        int PATHSEG_ARC_ABS
        {
            get;
            set;
        }
        int PATHSEG_MOVETO_ABS
        {
            get;
            set;
        }
        int PATHSEG_CURVETO_QUADRATIC_SMOOTH_REL
        {
            get;
            set;
        }
    }
    public partial interface WheelEvent : MouseEvent
    {
        int deltaZ
        {
            get;
            set;
        }
        int deltaX
        {
            get;
            set;
        }
        int deltaMode
        {
            get;
            set;
        }
        int deltaY
        {
            get;
            set;
        }
        void initWheelEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, int buttonArg, EventTarget relatedTargetArg, string modifiersListArg, int deltaXArg, int deltaYArg, int deltaZArg, int deltaMode);
        void getCurrentPoint(Element element);
        int DOM_DELTA_PIXEL
        {
            get;
            set;
        }
        int DOM_DELTA_LINE
        {
            get;
            set;
        }
        int DOM_DELTA_PAGE
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
        int value
        {
            get;
            set;
        }
    }
    public partial interface SVGPathElement : SVGElement, SVGStylable, SVGAnimatedPathData, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        int getPathSegAtLength(int distance);
        SVGPoint getPointAtLength(int distance);
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
        SVGPathSegArcRel createSVGPathSegArcRel(double x, double y, int r1, int r2, int angle, bool largeArcFlag, bool sweepFlag);
        SVGPathSegCurvetoQuadraticSmoothAbs createSVGPathSegCurvetoQuadraticSmoothAbs(double x, double y);
        SVGPathSegLinetoHorizontalRel createSVGPathSegLinetoHorizontalRel(double x);
        int getTotalLength();
        SVGPathSegCurvetoCubicSmoothRel createSVGPathSegCurvetoCubicSmoothRel(double x, double y, double x2, double y2);
        SVGPathSegLinetoHorizontalAbs createSVGPathSegLinetoHorizontalAbs(double x);
        SVGPathSegLinetoVerticalAbs createSVGPathSegLinetoVerticalAbs(double y);
        SVGPathSegArcAbs createSVGPathSegArcAbs(double x, double y, int r1, int r2, int angle, bool largeArcFlag, bool sweepFlag);
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
        Text splitText(int offset);
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
        int numberOfItems
        {
            get;
            set;
        }
        SVGPathSeg replaceItem(SVGPathSeg newItem, int index);
        SVGPathSeg getItem(int index);
        void clear();
        SVGPathSeg appendItem(SVGPathSeg newItem);
        SVGPathSeg initialize(SVGPathSeg newItem);
        SVGPathSeg removeItem(int index);
        SVGPathSeg insertItemBefore(SVGPathSeg newItem, int index);
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
        int loop
        {
            get;
            set;
        }
    }
    public partial interface PositionError
    {
        int code
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        string ToString();
        int POSITION_UNAVAILABLE
        {
            get;
            set;
        }
        int PERMISSION_DENIED
        {
            get;
            set;
        }
        int TIMEOUT
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
        int cellIndex
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
        int colSpan
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
        int rowSpan
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
        int Length
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
        int Length
        {
            get;
            set;
        }
        StyleSheet item(int index = 0);
        StyleSheet this[int index]
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
        int size
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
        int selectionStart
        {
            get;
            set;
        }
        int rows
        {
            get;
            set;
        }
        int cols
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
        int selectionEnd
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
        int maxLength
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
        void setSelectionRange(int start, int end);
        void select();
        bool checkValidity();
        void setCustomValidity(string error);
    }
    public partial interface Geolocation
    {
        void clearWatch(int watchId);
        void getCurrentPosition(PositionCallback successCallback, PositionErrorCallback errorCallback = null, PositionOptions options = null);
        double watchPosition(PositionCallback successCallback, PositionErrorCallback errorCallback = null, PositionOptions options = null);
    }
    public partial interface DOML2DeprecatedMarginStyle
    {
        int vspace
        {
            get;
            set;
        }
        int hspace
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
        int vspace
        {
            get;
            set;
        }
        bool trueSpeed
        {
            get;
            set;
        }
        int scrollAmount
        {
            get;
            set;
        }
        int scrollDelay
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
        int loop
        {
            get;
            set;
        }
        string direction
        {
            get;
            set;
        }
        int hspace
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
        int height
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
        int Length
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
        int Length
        {
            get;
            set;
        }
        int start(int index);
        int end(int index);
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
        int type
        {
            get;
            set;
        }
        int IMPORT_RULE
        {
            get;
            set;
        }
        int MEDIA_RULE
        {
            get;
            set;
        }
        int STYLE_RULE
        {
            get;
            set;
        }
        int NAMESPACE_RULE
        {
            get;
            set;
        }
        int PAGE_RULE
        {
            get;
            set;
        }
        int UNKNOWN_RULE
        {
            get;
            set;
        }
        int FONT_FACE_RULE
        {
            get;
            set;
        }
        int CHARSET_RULE
        {
            get;
            set;
        }
        int KEYFRAMES_RULE
        {
            get;
            set;
        }
        int KEYFRAME_RULE
        {
            get;
            set;
        }
        int VIEWPORT_RULE
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
        int e
        {
            get;
            set;
        }
        int c
        {
            get;
            set;
        }
        int a
        {
            get;
            set;
        }
        int b
        {
            get;
            set;
        }
        int d
        {
            get;
            set;
        }
        int f
        {
            get;
            set;
        }
        SVGMatrix multiply(SVGMatrix secondMatrix);
        SVGMatrix flipY();
        SVGMatrix skewY(int angle);
        SVGMatrix inverse();
        SVGMatrix scaleNonUniform(int scaleFactorX, int scaleFactorY);
        SVGMatrix rotate(int angle);
        SVGMatrix flipX();
        SVGMatrix translate(double x, double y);
        SVGMatrix scale(int scaleFactor);
        SVGMatrix rotateFromVector(double x, double y);
        SVGMatrix skewX(int angle);
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
        void show(double x, double y, double w, int h, object element = null);
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
        int timeStamp
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
        int eventPhase
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
        int CAPTURING_PHASE
        {
            get;
            set;
        }
        int AT_TARGET
        {
            get;
            set;
        }
        int BUBBLING_PHASE
        {
            get;
            set;
        }
    }
    public partial interface ImageData
    {
        uint width
        {
            get;
            set;
        }
        Uint8Array data
        {
            get;
            set;
        }
        int height
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
        int span
        {
            get;
            set;
        }
    }
    public partial interface SVGException
    {
        int code
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
        string ToString();
        int SVG_MATRIX_NOT_INVERTABLE
        {
            get;
            set;
        }
        int SVG_WRONG_TYPE_ERR
        {
            get;
            set;
        }
        int SVG_INVALID_VALUE_ERR
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
        int animVal
        {
            get;
            set;
        }
        int baseVal
        {
            get;
            set;
        }
    }
    public partial interface DOML2DeprecatedSizeProperty
    {
        int size
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
    public delegate void ErrorEventHandler(Event _event, string source, int fileno, int columnNumber);
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
        int Length
        {
            get;
            set;
        }
        Attr removeNamedItemNS(string namespaceURI, string localName);
        Attr item(int index);
        Attr this[int index]
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
        int Length
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
        string item(int index);
        string this[int index]
        {
            get;
            set;
        }
        string ToString();
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
        int numberOfItems
        {
            get;
            set;
        }
        SVGLength replaceItem(SVGLength newItem, int index);
        SVGLength getItem(int index);
        void clear();
        SVGLength appendItem(SVGLength newItem);
        SVGLength initialize(SVGLength newItem);
        SVGLength removeItem(int index);
        SVGLength insertItemBefore(SVGLength newItem, int index);
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
        int screenLeft
        {
            get;
            set;
        }
        object offscreenBuffering
        {
            get;
            set;
        }
        int maxConnectionsPerServer
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
        int screenTop
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
        void resizeBy(double x = 0, double y = 0);
        object item(object index);
        void resizeTo(double x = 0, double y = 0);
        MSPopupWindow createPopup(object arguments = null);
        string toStaticHTML(string html);
        object execScript(string code, string language = null);
        void msWriteProfilerMark(string profilerMarkName);
        void moveTo(double x = 0, double y = 0);
        void moveBy(double x = 0, double y = 0);
        void showHelp(string url, object helpArg = null, string features = null);
        void captureEvents();
        void releaseEvents();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface MSBehaviorUrnsCollection
    {
        int Length
        {
            get;
            set;
        }
        string item(int index);
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
        int inputMethod
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
        void initTextEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, int inputMethod, string locale);
        int DOM_INPUT_METHOD_KEYBOARD
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_DROP
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_IME
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_SCRIPT
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_VOICE
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_UNKNOWN
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_PASTE
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_HANDWRITING
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_OPTION
        {
            get;
            set;
        }
        int DOM_INPUT_METHOD_MULTIMODAL
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
        int Length
        {
            get;
            set;
        }
        object item(int index);
        object this[int index]
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
        int connectionSpeed
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
        int Length
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
        int SVG_ZOOMANDPAN_MAGNIFY
        {
            get;
            set;
        }
        int SVG_ZOOMANDPAN_UNKNOWN
        {
            get;
            set;
        }
        int SVG_ZOOMANDPAN_DISABLE
        {
            get;
            set;
        }
    }
    public partial interface HTMLMediaElement : HTMLElement
    {
        int initialTime
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
        int volume
        {
            get;
            set;
        }
        string src
        {
            get;
            set;
        }
        int playbackRate
        {
            get;
            set;
        }
        int duration
        {
            get;
            set;
        }
        bool muted
        {
            get;
            set;
        }
        int defaultPlaybackRate
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
        int currentTime
        {
            get;
            set;
        }
        string preload
        {
            get;
            set;
        }
        int networkState
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
        int HAVE_METADATA
        {
            get;
            set;
        }
        int HAVE_CURRENT_DATA
        {
            get;
            set;
        }
        int HAVE_NOTHING
        {
            get;
            set;
        }
        int NETWORK_NO_SOURCE
        {
            get;
            set;
        }
        int HAVE_ENOUGH_DATA
        {
            get;
            set;
        }
        int NETWORK_EMPTY
        {
            get;
            set;
        }
        int NETWORK_LOADING
        {
            get;
            set;
        }
        int NETWORK_IDLE
        {
            get;
            set;
        }
        int HAVE_FUTURE_DATA
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
        int Length
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
        int TEXTPATH_SPACINGTYPE_EXACT
        {
            get;
            set;
        }
        int TEXTPATH_METHODTYPE_STRETCH
        {
            get;
            set;
        }
        int TEXTPATH_SPACINGTYPE_AUTO
        {
            get;
            set;
        }
        int TEXTPATH_SPACINGTYPE_UNKNOWN
        {
            get;
            set;
        }
        int TEXTPATH_METHODTYPE_UNKNOWN
        {
            get;
            set;
        }
        int TEXTPATH_METHODTYPE_ALIGN
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
        int Length
        {
            get;
            set;
        }
        Node item(int index);
        Node this[int index]
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
        int SVG_SPREADMETHOD_REFLECT
        {
            get;
            set;
        }
        int SVG_SPREADMETHOD_PAD
        {
            get;
            set;
        }
        int SVG_SPREADMETHOD_UNKNOWN
        {
            get;
            set;
        }
        int SVG_SPREADMETHOD_REPEAT
        {
            get;
            set;
        }
    }
    public partial interface NodeFilter
    {
        int acceptNode(Node n);
        int SHOW_ENTITY_REFERENCE
        {
            get;
            set;
        }
        int SHOW_NOTATION
        {
            get;
            set;
        }
        int SHOW_ENTITY
        {
            get;
            set;
        }
        int SHOW_DOCUMENT
        {
            get;
            set;
        }
        int SHOW_PROCESSING_INSTRUCTION
        {
            get;
            set;
        }
        int FILTER_REJECT
        {
            get;
            set;
        }
        int SHOW_CDATA_SECTION
        {
            get;
            set;
        }
        int FILTER_ACCEPT
        {
            get;
            set;
        }
        int SHOW_ALL
        {
            get;
            set;
        }
        int SHOW_DOCUMENT_TYPE
        {
            get;
            set;
        }
        int SHOW_TEXT
        {
            get;
            set;
        }
        int SHOW_ELEMENT
        {
            get;
            set;
        }
        int SHOW_COMMENT
        {
            get;
            set;
        }
        int FILTER_SKIP
        {
            get;
            set;
        }
        int SHOW_ATTRIBUTE
        {
            get;
            set;
        }
        int SHOW_DOCUMENT_FRAGMENT
        {
            get;
            set;
        }
    }
    public partial interface SVGNumberList
    {
        int numberOfItems
        {
            get;
            set;
        }
        SVGNumber replaceItem(SVGNumber newItem, int index);
        SVGNumber getItem(int index);
        void clear();
        SVGNumber appendItem(SVGNumber newItem);
        SVGNumber initialize(SVGNumber newItem);
        SVGNumber removeItem(int index);
        SVGNumber insertItemBefore(SVGNumber newItem, int index);
    }
    public partial interface MediaError
    {
        int code
        {
            get;
            set;
        }
        int msExtendedCode
        {
            get;
            set;
        }
        int MEDIA_ERR_ABORTED
        {
            get;
            set;
        }
        int MEDIA_ERR_NETWORK
        {
            get;
            set;
        }
        int MEDIA_ERR_SRC_NOT_SUPPORTED
        {
            get;
            set;
        }
        int MEDIA_ERR_DECODE
        {
            get;
            set;
        }
        int MS_MEDIA_ERR_ENCRYPTED
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
        int loop
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
        int redirectStart
        {
            get;
            set;
        }
        int redirectEnd
        {
            get;
            set;
        }
        int domainLookupEnd
        {
            get;
            set;
        }
        int responseStart
        {
            get;
            set;
        }
        int domainLookupStart
        {
            get;
            set;
        }
        int fetchStart
        {
            get;
            set;
        }
        int requestStart
        {
            get;
            set;
        }
        int connectEnd
        {
            get;
            set;
        }
        int connectStart
        {
            get;
            set;
        }
        string initiatorType
        {
            get;
            set;
        }
        int responseEnd
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
        int readyState
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
        int Length
        {
            get;
            set;
        }
        string data
        {
            get;
            set;
        }
        void deleteData(int offset, int count);
        void replaceData(int offset, int count, string arg);
        void appendData(string arg);
        void insertData(int offset, string arg);
        string substringData(int offset, int count);
    }
    public partial interface HTMLOptGroupElement : HTMLElement, MSDataBindingExtensions
    {
        int index
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
        int code
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
        string ToString();
        int HIERARCHY_REQUEST_ERR
        {
            get;
            set;
        }
        int NO_MODIFICATION_ALLOWED_ERR
        {
            get;
            set;
        }
        int INVALID_MODIFICATION_ERR
        {
            get;
            set;
        }
        int NAMESPACE_ERR
        {
            get;
            set;
        }
        int INVALID_CHARACTER_ERR
        {
            get;
            set;
        }
        int TYPE_MISMATCH_ERR
        {
            get;
            set;
        }
        int ABORT_ERR
        {
            get;
            set;
        }
        int INVALID_STATE_ERR
        {
            get;
            set;
        }
        int SECURITY_ERR
        {
            get;
            set;
        }
        int NETWORK_ERR
        {
            get;
            set;
        }
        int WRONG_DOCUMENT_ERR
        {
            get;
            set;
        }
        int QUOTA_EXCEEDED_ERR
        {
            get;
            set;
        }
        int INDEX_SIZE_ERR
        {
            get;
            set;
        }
        int DOMSTRING_SIZE_ERR
        {
            get;
            set;
        }
        int SYNTAX_ERR
        {
            get;
            set;
        }
        int SERIALIZE_ERR
        {
            get;
            set;
        }
        int VALIDATION_ERR
        {
            get;
            set;
        }
        int NOT_FOUND_ERR
        {
            get;
            set;
        }
        int URL_MISMATCH_ERR
        {
            get;
            set;
        }
        int PARSE_ERR
        {
            get;
            set;
        }
        int NO_DATA_ALLOWED_ERR
        {
            get;
            set;
        }
        int NOT_SUPPORTED_ERR
        {
            get;
            set;
        }
        int INVALID_ACCESS_ERR
        {
            get;
            set;
        }
        int INUSE_ATTRIBUTE_ERR
        {
            get;
            set;
        }
        int INVALID_NODE_TYPE_ERR
        {
            get;
            set;
        }
        int DATA_CLONE_ERR
        {
            get;
            set;
        }
        int TIMEOUT_ERR
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
        int Length
        {
            get;
            set;
        }
        MSCompatibleInfo item(int index);
    }
    public partial interface SVGSwitchElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired { }
    public partial interface SVGPreserveAspectRatio
    {
        int align
        {
            get;
            set;
        }
        int meetOrSlice
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_NONE
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMINYMID
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMAXYMIN
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMINYMAX
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMAXYMAX
        {
            get;
            set;
        }
        int SVG_MEETORSLICE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMAXYMID
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMIDYMAX
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMINYMIN
        {
            get;
            set;
        }
        int SVG_MEETORSLICE_MEET
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMIDYMID
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_XMIDYMIN
        {
            get;
            set;
        }
        int SVG_MEETORSLICE_SLICE
        {
            get;
            set;
        }
        int SVG_PRESERVEASPECTRATIO_UNKNOWN
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
        int redirectCount
        {
            get;
            set;
        }
        int type
        {
            get;
            set;
        }
        object toJSON();
        int TYPE_RELOAD
        {
            get;
            set;
        }
        int TYPE_RESERVED
        {
            get;
            set;
        }
        int TYPE_BACK_FORWARD
        {
            get;
            set;
        }
        int TYPE_NAVIGATE
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
        int Length
        {
            get;
            set;
        }
        SVGElementInstance item(int index);
    }
    public partial interface CSSRuleList
    {
        int Length
        {
            get;
            set;
        }
        CSSRule item(int index);
        CSSRule this[int index]
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
        int videoWidth
        {
            get;
            set;
        }
        int videoHeight
        {
            get;
            set;
        }
        int height
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
        void msSetVideoRectangle(int left, int top, int right, int bottom);
        void msFrameStep(bool forward);
        VideoPlaybackQuality getVideoPlaybackQuality();
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public partial interface ClientRectList
    {
        int Length
        {
            get;
            set;
        }
        ClientRect item(int index);
        ClientRect this[int index]
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
        int offsetY
        {
            get;
            set;
        }
        int translationY
        {
            get;
            set;
        }
        int velocityExpansion
        {
            get;
            set;
        }
        int velocityY
        {
            get;
            set;
        }
        int velocityAngular
        {
            get;
            set;
        }
        int translationX
        {
            get;
            set;
        }
        int velocityX
        {
            get;
            set;
        }
        int hwTimestamp
        {
            get;
            set;
        }
        int offsetX
        {
            get;
            set;
        }
        int screenX
        {
            get;
            set;
        }
        int rotation
        {
            get;
            set;
        }
        int expansion
        {
            get;
            set;
        }
        int clientY
        {
            get;
            set;
        }
        int screenY
        {
            get;
            set;
        }
        int scale
        {
            get;
            set;
        }
        object gestureObject
        {
            get;
            set;
        }
        int clientX
        {
            get;
            set;
        }
        void initGestureEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, int offsetXArg, int offsetYArg, int translationXArg, int translationYArg, int scaleArg, int expansionArg, int rotationArg, int velocityXArg, int velocityYArg, int velocityExpansionArg, int velocityAngularArg, int hwTimestampArg);
        int MSGESTURE_FLAG_BEGIN
        {
            get;
            set;
        }
        int MSGESTURE_FLAG_END
        {
            get;
            set;
        }
        int MSGESTURE_FLAG_CANCEL
        {
            get;
            set;
        }
        int MSGESTURE_FLAG_INERTIA
        {
            get;
            set;
        }
        int MSGESTURE_FLAG_NONE
        {
            get;
            set;
        }
    }
    public partial interface ErrorEvent : Event
    {
        int colno
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
        int lineno
        {
            get;
            set;
        }
        string message
        {
            get;
            set;
        }
        void initErrorEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string messageArg, string filenameArg, int linenoArg);
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
        void setFilterRes(int filterResX, int filterResY);
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
        void addPointer(int pointerId);
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
        int endTime
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
        int startTime
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
        void readAsArrayBuffer(MSStream stream, int size = 0);
        void readAsBlob(MSStream stream, int size = 0);
        void readAsDataURL(MSStream stream, int size = 0);
        void readAsText(MSStream stream, string encoding = null, int size = 0);
    }
    public partial interface DOMTokenList
    {
        int Length
        {
            get;
            set;
        }
        bool contains(string token);
        void remove(string token);
        bool toggle(string token);
        void add(string token);
        string item(int index);
        string this[int index]
        {
            get;
            set;
        }
        string ToString();
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
        int SVG_FEBLEND_MODE_DARKEN
        {
            get;
            set;
        }
        int SVG_FEBLEND_MODE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_FEBLEND_MODE_MULTIPLY
        {
            get;
            set;
        }
        int SVG_FEBLEND_MODE_NORMAL
        {
            get;
            set;
        }
        int SVG_FEBLEND_MODE_SCREEN
        {
            get;
            set;
        }
        int SVG_FEBLEND_MODE_LIGHTEN
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
        int elapsedTime
        {
            get;
            set;
        }
        void initTransitionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string propertyNameArg, int elapsedTimeArg);
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
        string ToString();
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
        int code
        {
            get;
            set;
        }
        void initCloseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool wasCleanArg, int codeArg, string reasonArg);
    }
    public partial interface WebSocket : EventTarget
    {
        string protocol
        {
            get;
            set;
        }
        int readyState
        {
            get;
            set;
        }
        int bufferedAmount
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
        void close(int code = 0, string reason = null);
        void send(object data);
        int OPEN
        {
            get;
            set;
        }
        int CLOSING
        {
            get;
            set;
        }
        int CONNECTING
        {
            get;
            set;
        }
        int CLOSED
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
        int loaded
        {
            get;
            set;
        }
        bool lengthComputable
        {
            get;
            set;
        }
        int total
        {
            get;
            set;
        }
        void initProgressEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool lengthComputableArg, int loadedArg, int totalArg);
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
        void setStdDeviation(int stdDeviationX, int stdDeviationY);
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
        int newVersion
        {
            get;
            set;
        }
        int oldVersion
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
        int Length
        {
            get;
            set;
        }
        File item(int index);
        File this[int index]
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
        void advance(int count);
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
        int Length
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
        AudioTrack item(int index);
        AudioTrack this[int index]
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
        int readyState
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
        int LOADING
        {
            get;
            set;
        }
        int EMPTY
        {
            get;
            set;
        }
        int DONE
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
        int SVG_MORPHOLOGY_OPERATOR_UNKNOWN
        {
            get;
            set;
        }
        int SVG_MORPHOLOGY_OPERATOR_ERODE
        {
            get;
            set;
        }
        int SVG_MORPHOLOGY_OPERATOR_DILATE
        {
            get;
            set;
        }
    }
    public partial interface SVGFEFuncRElement : SVGComponentTransferFunctionElement { }
    public partial interface WindowTimersExtension
    {
        int msSetImmediate(object expression, params object[] args);
        void clearImmediate(int handle);
        void msClearImmediate(int handle);
        int setImmediate(object expression, params object[] args);
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
        int SVG_CHANNEL_B
        {
            get;
            set;
        }
        int SVG_CHANNEL_R
        {
            get;
            set;
        }
        int SVG_CHANNEL_G
        {
            get;
            set;
        }
        int SVG_CHANNEL_UNKNOWN
        {
            get;
            set;
        }
        int SVG_CHANNEL_A
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
        int elapsedTime
        {
            get;
            set;
        }
        void initAnimationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string animationNameArg, int elapsedTimeArg);
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
        int SVG_FECOMPONENTTRANSFER_TYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_FECOMPONENTTRANSFER_TYPE_TABLE
        {
            get;
            set;
        }
        int SVG_FECOMPONENTTRANSFER_TYPE_IDENTITY
        {
            get;
            set;
        }
        int SVG_FECOMPONENTTRANSFER_TYPE_GAMMA
        {
            get;
            set;
        }
        int SVG_FECOMPONENTTRANSFER_TYPE_DISCRETE
        {
            get;
            set;
        }
        int SVG_FECOMPONENTTRANSFER_TYPE_LINEAR
        {
            get;
            set;
        }
    }
    public partial interface MSRangeCollection
    {
        int Length
        {
            get;
            set;
        }
        Range item(int index);
        Range this[int index]
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
        int SVG_EDGEMODE_WRAP
        {
            get;
            set;
        }
        int SVG_EDGEMODE_DUPLICATE
        {
            get;
            set;
        }
        int SVG_EDGEMODE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_EDGEMODE_NONE
        {
            get;
            set;
        }
    }
    public partial interface TextTrackCueList
    {
        int Length
        {
            get;
            set;
        }
        TextTrackCue item(int index);
        TextTrackCue this[int index]
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
        int SVG_STITCHTYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_STITCHTYPE_NOSTITCH
        {
            get;
            set;
        }
        int SVG_TURBULENCE_TYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_TURBULENCE_TYPE_TURBULENCE
        {
            get;
            set;
        }
        int SVG_TURBULENCE_TYPE_FRACTALNOISE
        {
            get;
            set;
        }
        int SVG_STITCHTYPE_STITCH
        {
            get;
            set;
        }
    }
    public partial interface TextTrackList : EventTarget
    {
        int Length
        {
            get;
            set;
        }
        System.Func<TrackEvent, object> onaddtrack
        {
            get;
            set;
        }
        TextTrack item(int index);
        TextTrack this[int index]
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
        int SVG_FECOLORMATRIX_TYPE_SATURATE
        {
            get;
            set;
        }
        int SVG_FECOLORMATRIX_TYPE_UNKNOWN
        {
            get;
            set;
        }
        int SVG_FECOLORMATRIX_TYPE_MATRIX
        {
            get;
            set;
        }
        int SVG_FECOLORMATRIX_TYPE_HUEROTATE
        {
            get;
            set;
        }
        int SVG_FECOLORMATRIX_TYPE_LUMINANCETOALPHA
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
        int Length
        {
            get;
            set;
        }
        bool contains(string str);
        string item(int index);
        string this[int index]
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
        int value
        {
            get;
            set;
        }
        int Max
        {
            get;
            set;
        }
        int position
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
        int readyState
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
        int ERROR
        {
            get;
            set;
        }
        int SHOWING
        {
            get;
            set;
        }
        int LOADING
        {
            get;
            set;
        }
        int LOADED
        {
            get;
            set;
        }
        int NONE
        {
            get;
            set;
        }
        int HIDDEN
        {
            get;
            set;
        }
        int DISABLED
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
        int size
        {
            get;
            set;
        }
        object msDetachStream();
        Blob slice(int start = 0, int end = 0, string contentType = null);
        void msClose();
    }
    public partial interface ApplicationCache : EventTarget
    {
        int status
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
        int CHECKING
        {
            get;
            set;
        }
        int UNCACHED
        {
            get;
            set;
        }
        int UPDATEREADY
        {
            get;
            set;
        }
        int DOWNLOADING
        {
            get;
            set;
        }
        int IDLE
        {
            get;
            set;
        }
        int OBSOLETE
        {
            get;
            set;
        }
        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }
    public delegate void FrameRequestCallback(int time);
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
        IDBOpenDBRequest open(string name, int version = 0);
        int cmp(object first, object second);
        IDBOpenDBRequest deleteDatabase(string name);
    }
    public partial interface MSPointerEvent : MouseEvent
    {
        double width
        {
            get;
            set;
        }
        int rotation
        {
            get;
            set;
        }
        int pressure
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
        int tiltY
        {
            get;
            set;
        }
        int height
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
        int tiltX
        {
            get;
            set;
        }
        int hwTimestamp
        {
            get;
            set;
        }
        int pointerId
        {
            get;
            set;
        }
        void initPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg, EventTarget relatedTargetArg, int offsetXArg, int offsetYArg, double widthArg, int heightArg, int pressure, int rotation, int tiltX, int tiltY, int pointerIdArg, object pointerType, int hwTimestampArg, bool isPrimary);
        void getCurrentPoint(Element element);
        void getIntermediatePoints(Element element);
        int MSPOINTER_TYPE_PEN
        {
            get;
            set;
        }
        int MSPOINTER_TYPE_MOUSE
        {
            get;
            set;
        }
        int MSPOINTER_TYPE_TOUCH
        {
            get;
            set;
        }
    }
    public partial interface MSManipulationEvent : UIEvent
    {
        int lastState
        {
            get;
            set;
        }
        int currentState
        {
            get;
            set;
        }
        void initMSManipulationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int lastState, int currentState);
        int MS_MANIPULATION_STATE_STOPPED
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_ACTIVE
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_INERTIA
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_SELECTING
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_COMMITTED
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_PRESELECT
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_DRAGGING
        {
            get;
            set;
        }
        int MS_MANIPULATION_STATE_CANCELLED
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
        int SVG_FECOMPOSITE_OPERATOR_OUT
        {
            get;
            set;
        }
        int SVG_FECOMPOSITE_OPERATOR_OVER
        {
            get;
            set;
        }
        int SVG_FECOMPOSITE_OPERATOR_XOR
        {
            get;
            set;
        }
        int SVG_FECOMPOSITE_OPERATOR_ARITHMETIC
        {
            get;
            set;
        }
        int SVG_FECOMPOSITE_OPERATOR_UNKNOWN
        {
            get;
            set;
        }
        int SVG_FECOMPOSITE_OPERATOR_IN
        {
            get;
            set;
        }
        int SVG_FECOMPOSITE_OPERATOR_ATOP
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
        int readyState
        {
            get;
            set;
        }
        int ERROR
        {
            get;
            set;
        }
        int LOADING
        {
            get;
            set;
        }
        int LOADED
        {
            get;
            set;
        }
        int NONE
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
        int m24
        {
            get;
            set;
        }
        int m34
        {
            get;
            set;
        }
        int a
        {
            get;
            set;
        }
        int d
        {
            get;
            set;
        }
        int m32
        {
            get;
            set;
        }
        int m41
        {
            get;
            set;
        }
        int m11
        {
            get;
            set;
        }
        int f
        {
            get;
            set;
        }
        int e
        {
            get;
            set;
        }
        int m23
        {
            get;
            set;
        }
        int m14
        {
            get;
            set;
        }
        int m33
        {
            get;
            set;
        }
        int m22
        {
            get;
            set;
        }
        int m21
        {
            get;
            set;
        }
        int c
        {
            get;
            set;
        }
        int m12
        {
            get;
            set;
        }
        int b
        {
            get;
            set;
        }
        int m42
        {
            get;
            set;
        }
        int m31
        {
            get;
            set;
        }
        int m43
        {
            get;
            set;
        }
        int m13
        {
            get;
            set;
        }
        int m44
        {
            get;
            set;
        }
        MSCSSMatrix multiply(MSCSSMatrix secondMatrix);
        MSCSSMatrix skewY(int angle);
        void setMatrixValue(string value);
        MSCSSMatrix inverse();
        MSCSSMatrix rotateAxisAngle(double x, double y, double z, int angle);
        string ToString();
        MSCSSMatrix rotate(int angleX, int angleY = 0, int angleZ = 0);
        MSCSSMatrix translate(double x, double y, double z = 0);
        MSCSSMatrix scale(int scaleX, int scaleY = 0, int scaleZ = 0);
        MSCSSMatrix skewX(int angle);
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
        int totalFrameDelay
        {
            get;
            set;
        }
        int creationTime
        {
            get;
            set;
        }
        int totalVideoFrames
        {
            get;
            set;
        }
        int droppedVideoFrames
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
        int Length
        {
            get;
            set;
        }
        Plugin item(int index);
        Plugin this[int index]
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
        int gamma
        {
            get;
            set;
        }
        int alpha
        {
            get;
            set;
        }
        bool absolute
        {
            get;
            set;
        }
        int beta
        {
            get;
            set;
        }
        void initDeviceOrientationEvent(string type, bool bubbles, bool cancelable, int alpha, int beta, int gamma, bool absolute);
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
        int height
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
        int appendWindowStart
        {
            get;
            set;
        }
        int appendWindowEnd
        {
            get;
            set;
        }
        TimeRanges buffered
        {
            get;
            set;
        }
        int timestampOffset
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
        void remove(int start, int end);
        void abort();
        void appendStream(MSStream stream, int maxSize = 0);
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
        int compositionStartOffset
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
        int compositionEndOffset
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
        int gamma
        {
            get;
            set;
        }
        int alpha
        {
            get;
            set;
        }
        int beta
        {
            get;
            set;
        }
    }
    public partial interface PluginArray
    {
        int Length
        {
            get;
            set;
        }
        void refresh(bool reload = false);
        Plugin item(int index);
        Plugin this[int index]
        {
            get;
            set;
        }
        Plugin namedItem(string name);
    }
    public partial interface MSMediaKeyError
    {
        int systemCode
        {
            get;
            set;
        }
        int code
        {
            get;
            set;
        }
        int MS_MEDIA_KEYERR_SERVICE
        {
            get;
            set;
        }
        int MS_MEDIA_KEYERR_HARDWARECHANGE
        {
            get;
            set;
        }
        int MS_MEDIA_KEYERR_OUTPUT
        {
            get;
            set;
        }
        int MS_MEDIA_KEYERR_DOMAIN
        {
            get;
            set;
        }
        int MS_MEDIA_KEYERR_UNKNOWN
        {
            get;
            set;
        }
        int MS_MEDIA_KEYERR_CLIENT
        {
            get;
            set;
        }
    }
    public partial interface Plugin
    {
        int Length
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
        MimeType item(int index);
        MimeType this[int index]
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
        int duration
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
        int Length
        {
            get;
            set;
        }
        SourceBuffer item(int index);
        SourceBuffer this[int index]
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
        int interval
        {
            get;
            set;
        }
        DeviceAcceleration accelerationIncludingGravity
        {
            get;
            set;
        }
        void initDeviceMotionEvent(string type, bool bubbles, bool cancelable, DeviceAccelerationDict acceleration, DeviceAccelerationDict accelerationIncludingGravity, DeviceRotationRateDict rotationRate, int interval);
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
        int rotation
        {
            get;
            set;
        }
        int pressure
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
        int tiltY
        {
            get;
            set;
        }
        int height
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
        int tiltX
        {
            get;
            set;
        }
        int hwTimestamp
        {
            get;
            set;
        }
        int pointerId
        {
            get;
            set;
        }
        void initPointerEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int screenXArg, int screenYArg, int clientXArg, int clientYArg, bool ctrlKeyArg, bool altKeyArg, bool shiftKeyArg, bool metaKeyArg, int buttonArg, EventTarget relatedTargetArg, int offsetXArg, int offsetYArg, double widthArg, int heightArg, int pressure, int rotation, int tiltX, int tiltY, int pointerIdArg, object pointerType, int hwTimestampArg, bool isPrimary);
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
        int readyState
        {
            get;
            set;
        }
        int type
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
        int ERROR
        {
            get;
            set;
        }
        int TYPE_CREATE_DATA_PACKAGE_FROM_SELECTION
        {
            get;
            set;
        }
        int TYPE_INVOKE_SCRIPT
        {
            get;
            set;
        }
        int COMPLETED
        {
            get;
            set;
        }
        int TYPE_CAPTURE_PREVIEW_TO_RANDOM_ACCESS_STREAM
        {
            get;
            set;
        }
        int STARTED
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
        int redirectStart
        {
            get;
            set;
        }
        int domainLookupEnd
        {
            get;
            set;
        }
        int responseStart
        {
            get;
            set;
        }
        int domComplete
        {
            get;
            set;
        }
        int domainLookupStart
        {
            get;
            set;
        }
        int loadEventStart
        {
            get;
            set;
        }
        int unloadEventEnd
        {
            get;
            set;
        }
        int fetchStart
        {
            get;
            set;
        }
        int requestStart
        {
            get;
            set;
        }
        int domInteractive
        {
            get;
            set;
        }
        int navigationStart
        {
            get;
            set;
        }
        int connectEnd
        {
            get;
            set;
        }
        int loadEventEnd
        {
            get;
            set;
        }
        int connectStart
        {
            get;
            set;
        }
        int responseEnd
        {
            get;
            set;
        }
        int domLoading
        {
            get;
            set;
        }
        int redirectEnd
        {
            get;
            set;
        }
        int redirectCount
        {
            get;
            set;
        }
        int unloadEventStart
        {
            get;
            set;
        }
        int domContentLoadedEventStart
        {
            get;
            set;
        }
        int domContentLoadedEventEnd
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
        int executionTime
        {
            get;
            set;
        }
    }
    public partial interface MSAppView
    {
        int viewId
        {
            get;
            set;
        }
        void close();
        void postMessage(object message, string targetOrigin, object ports = null);
    }
    public partial interface PerfWidgetExternal
    {
        int maxCpuSpeed
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
        int performanceCounter
        {
            get;
            set;
        }
        int averagePaintTime
        {
            get;
            set;
        }
        int activeNetworkRequestCount
        {
            get;
            set;
        }
        int paintRequestsPerSecond
        {
            get;
            set;
        }
        bool extraInformationEnabled
        {
            get;
            set;
        }
        int performanceCounterFrequency
        {
            get;
            set;
        }
        int averageFrameTime
        {
            get;
            set;
        }
        void repositionWindow(double x, double y);
        object getRecentMemoryUsage(int last);
        int getMemoryUsage();
        void resizeWindow(int width, int height);
        int getProcessCpuUsage();
        void removeEventListener(string eventType, System.Func<object, object> callback);
        object getRecentCpuUsage(int last);
        void addEventListener(string eventType, System.Func<object, object> callback);
        object getRecentFrames(int last);
        object getRecentPaintRequests(int last);
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
    public partial interface WebGLTexture : WebGLObject
    {
        int _baseWidth { get; set; }

        int _baseHeight { get; set; }

        int _width { get; set; }

        int _height { get; set; }

        // hack for width and hight
        int _size { get; set; }

        bool isReady { get; set; }

        WebGLFramebuffer _framebuffer { get; set; }

        bool generateMipMaps { get; set; }

        int references { get; set; }

        HTMLCanvasElement _workingCanvas { get; set; }

        CanvasRenderingContext2D _workingContext { get; set; }

        WebGLRenderbuffer _depthBuffer { get; set; }

        string url { get; set; }

        bool noMipmap { get; set; }

        bool isCube { get; set; }

        int _cachedCoordinatesMode { get; set; }

        int _cachedWrapU { get; set; }

        int _cachedWrapV { get; set; }
    }
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
        int type
        {
            get;
            set;
        }
        int size
        {
            get;
            set;
        }
    }
    public partial interface WEBGL_compressed_texture_s3tc
    {
        int COMPRESSED_RGBA_S3TC_DXT1_EXT
        {
            get;
            set;
        }
        int COMPRESSED_RGBA_S3TC_DXT5_EXT
        {
            get;
            set;
        }
        int COMPRESSED_RGBA_S3TC_DXT3_EXT
        {
            get;
            set;
        }
        int COMPRESSED_RGB_S3TC_DXT1_EXT
        {
            get;
            set;
        }
    }
    public partial interface WebGLRenderingContext
    {
        int drawingBufferWidth
        {
            get;
            set;
        }
        int drawingBufferHeight
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
        void bindTexture(int target, WebGLTexture texture);
        void bufferData(int target, ArrayBufferView data, int usage);
        void bufferData(int target, ArrayBuffer data, int usage);
        void bufferData(int target, int size, int usage);
        void depthMask(bool flag);
        object getUniform(WebGLProgram program, WebGLUniformLocation location);
        void vertexAttrib3fv(int indx, Array<double> values);
        void vertexAttrib3fv(int indx, Float32Array values);
        void linkProgram(WebGLProgram program);
        Array<string> getSupportedExtensions();
        void bufferSubData(int target, int offset, ArrayBuffer data);
        void bufferSubData(int target, int offset, ArrayBufferView data);
        void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset);
        void polygonOffset(int factor, int units);
        void blendColor(int red, int green, int blue, int alpha);
        WebGLTexture createTexture();
        void hint(int target, int mode);
        object getVertexAttrib(int index, int pname);
        void enableVertexAttribArray(int index);
        void depthRange(double zNear, double zFar);
        void cullFace(int mode);
        WebGLFramebuffer createFramebuffer();
        void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, Array<double> value);
        void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, Float32Array value);
        void framebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level);
        void deleteFramebuffer(WebGLFramebuffer framebuffer);
        void colorMask(bool red, bool green, bool blue, bool alpha);
        void compressedTexImage2D(int target, int level, int internalformat, double width, int height, int border, ArrayBufferView data);
        void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Array<double> value);
        void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Float32Array value);
        object getExtension(string name);
        WebGLProgram createProgram();
        void deleteShader(WebGLShader shader);
        Array<WebGLShader> getAttachedShaders(WebGLProgram program);
        void enable(int cap);
        void blendEquation(int mode);
        void texImage2D(int target, int level, int internalformat, double width, int height, int border, int format, int type, ArrayBufferView pixels);
        void texImage2D(int target, int level, int internalformat, int format, int type, HTMLImageElement image);
        void texImage2D(int target, int level, int internalformat, int format, int type, HTMLCanvasElement canvas);
        void texImage2D(int target, int level, int internalformat, int format, int type, HTMLVideoElement video);
        void texImage2D(int target, int level, int internalformat, int format, int type, ImageData pixels);
        WebGLBuffer createBuffer();
        void deleteTexture(WebGLTexture texture);
        void useProgram(WebGLProgram program);
        void vertexAttrib2fv(int indx, Array<double> values);
        void vertexAttrib2fv(int indx, Float32Array values);
        int checkFramebufferStatus(int target);
        void frontFace(int mode);
        object getBufferParameter(int target, int pname);
        void texSubImage2D(int target, int level, double xoffset, double yoffset, double width, int height, int format, int type, ArrayBufferView pixels);
        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, HTMLImageElement image);
        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, HTMLCanvasElement canvas);
        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, HTMLVideoElement video);
        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, ImageData pixels);
        void copyTexImage2D(int target, int level, int internalformat, double x, double y, double width, int height, int border);
        int getVertexAttribOffset(int index, int pname);
        void disableVertexAttribArray(int index);
        void blendFunc(int sfactor, int dfactor);
        void drawElements(int mode, int count, int type, int offset);
        bool isFramebuffer(WebGLFramebuffer framebuffer);
        void uniform3iv(WebGLUniformLocation location, Array<double> v);
        void uniform3iv(WebGLUniformLocation location, Int32Array v);
        void lineWidth(int width);
        string getShaderInfoLog(WebGLShader shader);
        object getTexParameter(int target, int pname);
        object getParameter(int pname);
        WebGLShaderPrecisionFormat getShaderPrecisionFormat(int shadertype, int precisiontype);
        WebGLContextAttributes getContextAttributes();
        void vertexAttrib1f(int indx, double x);
        void bindFramebuffer(int target, WebGLFramebuffer framebuffer);
        void compressedTexSubImage2D(int target, int level, double xoffset, double yoffset, double width, int height, int format, ArrayBufferView data);
        bool isContextLost();
        void uniform1iv(WebGLUniformLocation location, Array<double> v);
        void uniform1iv(WebGLUniformLocation location, Int32Array v);
        object getRenderbufferParameter(int target, int pname);
        void uniform2fv(WebGLUniformLocation location, Array<double> v);
        void uniform2fv(WebGLUniformLocation location, Float32Array v);
        bool isTexture(WebGLTexture texture);
        int getError();
        void shaderSource(WebGLShader shader, string source);
        void deleteRenderbuffer(WebGLRenderbuffer renderbuffer);
        void stencilMask(int mask);
        void bindBuffer(int target, WebGLBuffer buffer);
        int getAttribLocation(WebGLProgram program, string name);
        void uniform3i(WebGLUniformLocation location, double x, double y, double z);
        void blendEquationSeparate(int modeRGB, int modeAlpha);
        void clear(int mask);
        void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);
        void stencilFuncSeparate(int face, int func, int _ref, int mask);
        void readPixels(double x, double y, double width, int height, int format, int type, ArrayBufferView pixels);
        void scissor(double x, double y, double width, int height);
        void uniform2i(WebGLUniformLocation location, double x, double y);
        WebGLActiveInfo getActiveAttrib(WebGLProgram program, int index);
        string getShaderSource(WebGLShader shader);
        void generateMipmap(int target);
        void bindAttribLocation(WebGLProgram program, int index, string name);
        void uniform1fv(WebGLUniformLocation location, Array<double> v);
        void uniform1fv(WebGLUniformLocation location, Float32Array v);
        void uniform2iv(WebGLUniformLocation location, Array<double> v);
        void uniform2iv(WebGLUniformLocation location, Int32Array v);
        void stencilOp(int fail, double zfail, double zpass);
        void uniform4fv(WebGLUniformLocation location, Array<double> v);
        void uniform4fv(WebGLUniformLocation location, Float32Array v);
        void vertexAttrib1fv(int indx, Array<double> values);
        void vertexAttrib1fv(int indx, Float32Array values);
        void flush();
        void uniform4f(WebGLUniformLocation location, double x, double y, double z, double w);
        void deleteProgram(WebGLProgram program);
        bool isRenderbuffer(WebGLRenderbuffer renderbuffer);
        void uniform1i(WebGLUniformLocation location, double x);
        object getProgramParameter(WebGLProgram program, int pname);
        WebGLActiveInfo getActiveUniform(WebGLProgram program, int index);
        void stencilFunc(int func, int _ref, int mask);
        void pixelStorei(int pname, int param);
        void disable(int cap);
        void vertexAttrib4fv(int indx, Array<double> values);
        void vertexAttrib4fv(int indx, Float32Array values);
        WebGLRenderbuffer createRenderbuffer();
        bool isBuffer(WebGLBuffer buffer);
        void stencilOpSeparate(int face, int fail, double zfail, double zpass);
        object getFramebufferAttachmentParameter(int target, int attachment, int pname);
        void uniform4i(WebGLUniformLocation location, double x, double y, double z, double w);
        void sampleCoverage(int value, bool invert);
        void depthFunc(int func);
        void texParameterf(int target, int pname, float param);
        void vertexAttrib3f(int indx, double x, double y, double z);
        void drawArrays(int mode, int first, int count);
        void texParameteri(int target, int pname, int param);
        void vertexAttrib4f(int indx, double x, double y, double z, double w);
        object getShaderParameter(WebGLShader shader, int pname);
        void clearDepth(double depth);
        void activeTexture(int texture);
        void viewport(int x, int y, int width, int height);
        void detachShader(WebGLProgram program, WebGLShader shader);
        void uniform1f(WebGLUniformLocation location, double x);
        void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Array<double> value);
        void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Float32Array value);
        void deleteBuffer(WebGLBuffer buffer);
        void copyTexSubImage2D(int target, int level, double xoffset, double yoffset, double x, double y, double width, int height);
        void uniform3fv(WebGLUniformLocation location, Array<double> v);
        void uniform3fv(WebGLUniformLocation location, Float32Array v);
        void stencilMaskSeparate(int face, int mask);
        void attachShader(WebGLProgram program, WebGLShader shader);
        void compileShader(WebGLShader shader);
        void clearColor(double red, double green, double blue, double alpha);
        bool isShader(WebGLShader shader);
        void clearStencil(int s);
        void framebufferRenderbuffer(int target, int attachment, int renderbuffertarget, WebGLRenderbuffer renderbuffer);
        void finish();
        void uniform2f(WebGLUniformLocation location, double x, double y);
        void renderbufferStorage(int target, int internalformat, double width, int height);
        void uniform3f(WebGLUniformLocation location, double x, double y, double z);
        string getProgramInfoLog(WebGLProgram program);
        void validateProgram(WebGLProgram program);
        bool isEnabled(int cap);
        void vertexAttrib2f(int indx, double x, double y);
        bool isProgram(WebGLProgram program);
        WebGLShader createShader(int type);
        void bindRenderbuffer(int target, WebGLRenderbuffer renderbuffer);
        void uniform4iv(WebGLUniformLocation location, Array<double> v);
        void uniform4iv(WebGLUniformLocation location, Int32Array v);
        int DEPTH_FUNC
        {
            get;
            set;
        }
        int DEPTH_COMPONENT16
        {
            get;
            set;
        }
        int REPLACE
        {
            get;
            set;
        }
        int REPEAT
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_ENABLED
        {
            get;
            set;
        }
        int FRAMEBUFFER_INCOMPLETE_DIMENSIONS
        {
            get;
            set;
        }
        int STENCIL_BUFFER_BIT
        {
            get;
            set;
        }
        int RENDERER
        {
            get;
            set;
        }
        int STENCIL_BACK_REF
        {
            get;
            set;
        }
        int TEXTURE26
        {
            get;
            set;
        }
        int RGB565
        {
            get;
            set;
        }
        int DITHER
        {
            get;
            set;
        }
        int CONSTANT_COLOR
        {
            get;
            set;
        }
        int GENERATE_MIPMAP_HINT
        {
            get;
            set;
        }
        int POINTS
        {
            get;
            set;
        }
        int DECR
        {
            get;
            set;
        }
        int INT_VEC3
        {
            get;
            set;
        }
        int TEXTURE28
        {
            get;
            set;
        }
        int ONE_MINUS_CONSTANT_ALPHA
        {
            get;
            set;
        }
        int BACK
        {
            get;
            set;
        }
        int RENDERBUFFER_STENCIL_SIZE
        {
            get;
            set;
        }
        int UNPACK_FLIP_Y_WEBGL
        {
            get;
            set;
        }
        int BLEND
        {
            get;
            set;
        }
        int TEXTURE9
        {
            get;
            set;
        }
        int ARRAY_BUFFER_BINDING
        {
            get;
            set;
        }
        int MAX_VIEWPORT_DIMS
        {
            get;
            set;
        }
        int INVALID_FRAMEBUFFER_OPERATION
        {
            get;
            set;
        }
        int TEXTURE
        {
            get;
            set;
        }
        int TEXTURE0
        {
            get;
            set;
        }
        int TEXTURE31
        {
            get;
            set;
        }
        int TEXTURE24
        {
            get;
            set;
        }
        int HIGH_INT
        {
            get;
            set;
        }
        int RENDERBUFFER_BINDING
        {
            get;
            set;
        }
        int BLEND_COLOR
        {
            get;
            set;
        }
        int FASTEST
        {
            get;
            set;
        }
        int STENCIL_WRITEMASK
        {
            get;
            set;
        }
        int ALIASED_POINT_SIZE_RANGE
        {
            get;
            set;
        }
        int TEXTURE12
        {
            get;
            set;
        }
        int DST_ALPHA
        {
            get;
            set;
        }
        int BLEND_EQUATION_RGB
        {
            get;
            set;
        }
        int FRAMEBUFFER_COMPLETE
        {
            get;
            set;
        }
        int NEAREST_MIPMAP_NEAREST
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_SIZE
        {
            get;
            set;
        }
        int TEXTURE3
        {
            get;
            set;
        }
        int DEPTH_WRITEMASK
        {
            get;
            set;
        }
        int CONTEXT_LOST_WEBGL
        {
            get;
            set;
        }
        int INVALID_VALUE
        {
            get;
            set;
        }
        int TEXTURE_MAG_FILTER
        {
            get;
            set;
        }
        int ONE_MINUS_CONSTANT_COLOR
        {
            get;
            set;
        }
        int ONE_MINUS_SRC_ALPHA
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP_POSITIVE_Z
        {
            get;
            set;
        }
        int NOTEQUAL
        {
            get;
            set;
        }
        int ALPHA
        {
            get;
            set;
        }
        int DEPTH_STENCIL
        {
            get;
            set;
        }
        int MAX_VERTEX_UNIFORM_VECTORS
        {
            get;
            set;
        }
        int DEPTH_COMPONENT
        {
            get;
            set;
        }
        int RENDERBUFFER_RED_SIZE
        {
            get;
            set;
        }
        int TEXTURE20
        {
            get;
            set;
        }
        int RED_BITS
        {
            get;
            set;
        }
        int RENDERBUFFER_BLUE_SIZE
        {
            get;
            set;
        }
        int SCISSOR_BOX
        {
            get;
            set;
        }
        int VENDOR
        {
            get;
            set;
        }
        int FRONT_AND_BACK
        {
            get;
            set;
        }
        int CONSTANT_ALPHA
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING
        {
            get;
            set;
        }
        int NEAREST
        {
            get;
            set;
        }
        int CULL_FACE
        {
            get;
            set;
        }
        int ALIASED_LINE_WIDTH_RANGE
        {
            get;
            set;
        }
        int TEXTURE19
        {
            get;
            set;
        }
        int FRONT
        {
            get;
            set;
        }
        int DEPTH_CLEAR_VALUE
        {
            get;
            set;
        }
        int GREEN_BITS
        {
            get;
            set;
        }
        int TEXTURE29
        {
            get;
            set;
        }
        int TEXTURE23
        {
            get;
            set;
        }
        int MAX_RENDERBUFFER_SIZE
        {
            get;
            set;
        }
        int STENCIL_ATTACHMENT
        {
            get;
            set;
        }
        int TEXTURE27
        {
            get;
            set;
        }
        int BOOL_VEC2
        {
            get;
            set;
        }
        int OUT_OF_MEMORY
        {
            get;
            set;
        }
        int MIRRORED_REPEAT
        {
            get;
            set;
        }
        int POLYGON_OFFSET_UNITS
        {
            get;
            set;
        }
        int TEXTURE_MIN_FILTER
        {
            get;
            set;
        }
        int STENCIL_BACK_PASS_DEPTH_PASS
        {
            get;
            set;
        }
        int LINE_LOOP
        {
            get;
            set;
        }
        int FLOAT_MAT3
        {
            get;
            set;
        }
        int TEXTURE14
        {
            get;
            set;
        }
        int LINEAR
        {
            get;
            set;
        }
        int RGB5_A1
        {
            get;
            set;
        }
        int ONE_MINUS_SRC_COLOR
        {
            get;
            set;
        }
        int SAMPLE_COVERAGE_INVERT
        {
            get;
            set;
        }
        int DONT_CARE
        {
            get;
            set;
        }
        int FRAMEBUFFER_BINDING
        {
            get;
            set;
        }
        int RENDERBUFFER_ALPHA_SIZE
        {
            get;
            set;
        }
        int STENCIL_REF
        {
            get;
            set;
        }
        int ZERO
        {
            get;
            set;
        }
        int DECR_WRAP
        {
            get;
            set;
        }
        int SAMPLE_COVERAGE
        {
            get;
            set;
        }
        int STENCIL_BACK_FUNC
        {
            get;
            set;
        }
        int TEXTURE30
        {
            get;
            set;
        }
        int VIEWPORT
        {
            get;
            set;
        }
        int STENCIL_BITS
        {
            get;
            set;
        }
        int FLOAT
        {
            get;
            set;
        }
        int COLOR_WRITEMASK
        {
            get;
            set;
        }
        int SAMPLE_COVERAGE_VALUE
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP_NEGATIVE_Y
        {
            get;
            set;
        }
        int STENCIL_BACK_FAIL
        {
            get;
            set;
        }
        int FLOAT_MAT4
        {
            get;
            set;
        }
        int UNSIGNED_SHORT_4_4_4_4
        {
            get;
            set;
        }
        int TEXTURE6
        {
            get;
            set;
        }
        int RENDERBUFFER_WIDTH
        {
            get;
            set;
        }
        int RGBA4
        {
            get;
            set;
        }
        int ALWAYS
        {
            get;
            set;
        }
        int BLEND_EQUATION_ALPHA
        {
            get;
            set;
        }
        int COLOR_BUFFER_BIT
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP
        {
            get;
            set;
        }
        int DEPTH_BUFFER_BIT
        {
            get;
            set;
        }
        int STENCIL_CLEAR_VALUE
        {
            get;
            set;
        }
        int BLEND_EQUATION
        {
            get;
            set;
        }
        int RENDERBUFFER_GREEN_SIZE
        {
            get;
            set;
        }
        int NEAREST_MIPMAP_LINEAR
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_TYPE
        {
            get;
            set;
        }
        int INCR_WRAP
        {
            get;
            set;
        }
        int ONE_MINUS_DST_COLOR
        {
            get;
            set;
        }
        int HIGH_FLOAT
        {
            get;
            set;
        }
        int BYTE
        {
            get;
            set;
        }
        int FRONT_FACE
        {
            get;
            set;
        }
        int SAMPLE_ALPHA_TO_COVERAGE
        {
            get;
            set;
        }
        int CCW
        {
            get;
            set;
        }
        int TEXTURE13
        {
            get;
            set;
        }
        int MAX_VERTEX_ATTRIBS
        {
            get;
            set;
        }
        int MAX_VERTEX_TEXTURE_IMAGE_UNITS
        {
            get;
            set;
        }
        int TEXTURE_WRAP_T
        {
            get;
            set;
        }
        int UNPACK_PREMULTIPLY_ALPHA_WEBGL
        {
            get;
            set;
        }
        int FLOAT_VEC2
        {
            get;
            set;
        }
        int LUMINANCE
        {
            get;
            set;
        }
        int GREATER
        {
            get;
            set;
        }
        int INT_VEC2
        {
            get;
            set;
        }
        int VALIDATE_STATUS
        {
            get;
            set;
        }
        int FRAMEBUFFER
        {
            get;
            set;
        }
        int FRAMEBUFFER_UNSUPPORTED
        {
            get;
            set;
        }
        int TEXTURE5
        {
            get;
            set;
        }
        int FUNC_SUBTRACT
        {
            get;
            set;
        }
        int BLEND_DST_ALPHA
        {
            get;
            set;
        }
        int SAMPLER_CUBE
        {
            get;
            set;
        }
        int ONE_MINUS_DST_ALPHA
        {
            get;
            set;
        }
        int LESS
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP_POSITIVE_X
        {
            get;
            set;
        }
        int BLUE_BITS
        {
            get;
            set;
        }
        int DEPTH_TEST
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_STRIDE
        {
            get;
            set;
        }
        int DELETE_STATUS
        {
            get;
            set;
        }
        int TEXTURE18
        {
            get;
            set;
        }
        int POLYGON_OFFSET_FACTOR
        {
            get;
            set;
        }
        int UNSIGNED_INT
        {
            get;
            set;
        }
        int TEXTURE_2D
        {
            get;
            set;
        }
        int DST_COLOR
        {
            get;
            set;
        }
        int FLOAT_MAT2
        {
            get;
            set;
        }
        int COMPRESSED_TEXTURE_FORMATS
        {
            get;
            set;
        }
        int MAX_FRAGMENT_UNIFORM_VECTORS
        {
            get;
            set;
        }
        int DEPTH_STENCIL_ATTACHMENT
        {
            get;
            set;
        }
        int LUMINANCE_ALPHA
        {
            get;
            set;
        }
        int CW
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_NORMALIZED
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP_NEGATIVE_Z
        {
            get;
            set;
        }
        int LINEAR_MIPMAP_LINEAR
        {
            get;
            set;
        }
        int BUFFER_SIZE
        {
            get;
            set;
        }
        int SAMPLE_BUFFERS
        {
            get;
            set;
        }
        int TEXTURE15
        {
            get;
            set;
        }
        int ACTIVE_TEXTURE
        {
            get;
            set;
        }
        int VERTEX_SHADER
        {
            get;
            set;
        }
        int TEXTURE22
        {
            get;
            set;
        }
        int VERTEX_ATTRIB_ARRAY_POINTER
        {
            get;
            set;
        }
        int INCR
        {
            get;
            set;
        }
        int COMPILE_STATUS
        {
            get;
            set;
        }
        int MAX_COMBINED_TEXTURE_IMAGE_UNITS
        {
            get;
            set;
        }
        int TEXTURE7
        {
            get;
            set;
        }
        int UNSIGNED_SHORT_5_5_5_1
        {
            get;
            set;
        }
        int DEPTH_BITS
        {
            get;
            set;
        }
        int RGBA
        {
            get;
            set;
        }
        int TRIANGLE_STRIP
        {
            get;
            set;
        }
        int COLOR_CLEAR_VALUE
        {
            get;
            set;
        }
        int BROWSER_DEFAULT_WEBGL
        {
            get;
            set;
        }
        int INVALID_ENUM
        {
            get;
            set;
        }
        int SCISSOR_TEST
        {
            get;
            set;
        }
        int LINE_STRIP
        {
            get;
            set;
        }
        int FRAMEBUFFER_INCOMPLETE_ATTACHMENT
        {
            get;
            set;
        }
        int STENCIL_FUNC
        {
            get;
            set;
        }
        int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME
        {
            get;
            set;
        }
        int RENDERBUFFER_HEIGHT
        {
            get;
            set;
        }
        int TEXTURE8
        {
            get;
            set;
        }
        int TRIANGLES
        {
            get;
            set;
        }
        int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE
        {
            get;
            set;
        }
        int STENCIL_BACK_VALUE_MASK
        {
            get;
            set;
        }
        int TEXTURE25
        {
            get;
            set;
        }
        int RENDERBUFFER
        {
            get;
            set;
        }
        int LEQUAL
        {
            get;
            set;
        }
        int TEXTURE1
        {
            get;
            set;
        }
        int STENCIL_INDEX8
        {
            get;
            set;
        }
        int FUNC_ADD
        {
            get;
            set;
        }
        int STENCIL_FAIL
        {
            get;
            set;
        }
        int BLEND_SRC_ALPHA
        {
            get;
            set;
        }
        int BOOL
        {
            get;
            set;
        }
        int ALPHA_BITS
        {
            get;
            set;
        }
        int LOW_INT
        {
            get;
            set;
        }
        int TEXTURE10
        {
            get;
            set;
        }
        int SRC_COLOR
        {
            get;
            set;
        }
        int MAX_VARYING_VECTORS
        {
            get;
            set;
        }
        int BLEND_DST_RGB
        {
            get;
            set;
        }
        int TEXTURE_BINDING_CUBE_MAP
        {
            get;
            set;
        }
        int STENCIL_INDEX
        {
            get;
            set;
        }
        int TEXTURE_BINDING_2D
        {
            get;
            set;
        }
        int MEDIUM_INT
        {
            get;
            set;
        }
        int SHADER_TYPE
        {
            get;
            set;
        }
        int POLYGON_OFFSET_FILL
        {
            get;
            set;
        }
        int DYNAMIC_DRAW
        {
            get;
            set;
        }
        int TEXTURE4
        {
            get;
            set;
        }
        int STENCIL_BACK_PASS_DEPTH_FAIL
        {
            get;
            set;
        }
        int STREAM_DRAW
        {
            get;
            set;
        }
        int MAX_CUBE_MAP_TEXTURE_SIZE
        {
            get;
            set;
        }
        int TEXTURE17
        {
            get;
            set;
        }
        int TRIANGLE_FAN
        {
            get;
            set;
        }
        int UNPACK_ALIGNMENT
        {
            get;
            set;
        }
        int CURRENT_PROGRAM
        {
            get;
            set;
        }
        int LINES
        {
            get;
            set;
        }
        int INVALID_OPERATION
        {
            get;
            set;
        }
        int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT
        {
            get;
            set;
        }
        int LINEAR_MIPMAP_NEAREST
        {
            get;
            set;
        }
        int CLAMP_TO_EDGE
        {
            get;
            set;
        }
        int RENDERBUFFER_DEPTH_SIZE
        {
            get;
            set;
        }
        int TEXTURE_WRAP_S
        {
            get;
            set;
        }
        int ELEMENT_ARRAY_BUFFER
        {
            get;
            set;
        }
        int UNSIGNED_SHORT_5_6_5
        {
            get;
            set;
        }
        int ACTIVE_UNIFORMS
        {
            get;
            set;
        }
        int FLOAT_VEC3
        {
            get;
            set;
        }
        int NO_ERROR
        {
            get;
            set;
        }
        int ATTACHED_SHADERS
        {
            get;
            set;
        }
        int DEPTH_ATTACHMENT
        {
            get;
            set;
        }
        int TEXTURE11
        {
            get;
            set;
        }
        int STENCIL_TEST
        {
            get;
            set;
        }
        int ONE
        {
            get;
            set;
        }
        int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE
        {
            get;
            set;
        }
        int STATIC_DRAW
        {
            get;
            set;
        }
        int GEQUAL
        {
            get;
            set;
        }
        int BOOL_VEC4
        {
            get;
            set;
        }
        int COLOR_ATTACHMENT0
        {
            get;
            set;
        }
        int PACK_ALIGNMENT
        {
            get;
            set;
        }
        int MAX_TEXTURE_SIZE
        {
            get;
            set;
        }
        int STENCIL_PASS_DEPTH_FAIL
        {
            get;
            set;
        }
        int CULL_FACE_MODE
        {
            get;
            set;
        }
        int TEXTURE16
        {
            get;
            set;
        }
        int STENCIL_BACK_WRITEMASK
        {
            get;
            set;
        }
        int SRC_ALPHA
        {
            get;
            set;
        }
        int UNSIGNED_SHORT
        {
            get;
            set;
        }
        int TEXTURE21
        {
            get;
            set;
        }
        int FUNC_REVERSE_SUBTRACT
        {
            get;
            set;
        }
        int SHADING_LANGUAGE_VERSION
        {
            get;
            set;
        }
        int EQUAL
        {
            get;
            set;
        }
        int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL
        {
            get;
            set;
        }
        int BOOL_VEC3
        {
            get;
            set;
        }
        int SAMPLER_2D
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP_NEGATIVE_X
        {
            get;
            set;
        }
        int MAX_TEXTURE_IMAGE_UNITS
        {
            get;
            set;
        }
        int TEXTURE_CUBE_MAP_POSITIVE_Y
        {
            get;
            set;
        }
        int RENDERBUFFER_INTERNAL_FORMAT
        {
            get;
            set;
        }
        int STENCIL_VALUE_MASK
        {
            get;
            set;
        }
        int ELEMENT_ARRAY_BUFFER_BINDING
        {
            get;
            set;
        }
        int ARRAY_BUFFER
        {
            get;
            set;
        }
        int DEPTH_RANGE
        {
            get;
            set;
        }
        int NICEST
        {
            get;
            set;
        }
        int ACTIVE_ATTRIBUTES
        {
            get;
            set;
        }
        int NEVER
        {
            get;
            set;
        }
        int FLOAT_VEC4
        {
            get;
            set;
        }
        int CURRENT_VERTEX_ATTRIB
        {
            get;
            set;
        }
        int STENCIL_PASS_DEPTH_PASS
        {
            get;
            set;
        }
        int INVERT
        {
            get;
            set;
        }
        int LINK_STATUS
        {
            get;
            set;
        }
        int RGB
        {
            get;
            set;
        }
        int INT_VEC4
        {
            get;
            set;
        }
        int TEXTURE2
        {
            get;
            set;
        }
        int UNPACK_COLORSPACE_CONVERSION_WEBGL
        {
            get;
            set;
        }
        int MEDIUM_FLOAT
        {
            get;
            set;
        }
        int SRC_ALPHA_SATURATE
        {
            get;
            set;
        }
        int BUFFER_USAGE
        {
            get;
            set;
        }
        int SHORT
        {
            get;
            set;
        }
        int NONE
        {
            get;
            set;
        }
        int UNSIGNED_BYTE
        {
            get;
            set;
        }
        int INT
        {
            get;
            set;
        }
        int SUBPIXEL_BITS
        {
            get;
            set;
        }
        int KEEP
        {
            get;
            set;
        }
        int SAMPLES
        {
            get;
            set;
        }
        int FRAGMENT_SHADER
        {
            get;
            set;
        }
        int LINE_WIDTH
        {
            get;
            set;
        }
        int BLEND_SRC_RGB
        {
            get;
            set;
        }
        int LOW_FLOAT
        {
            get;
            set;
        }
        int VERSION
        {
            get;
            set;
        }

        int this[string enumName] { get; }
    }
    public partial interface WebGLProgram : WebGLObject { }
    public partial interface OES_standard_derivatives
    {
        int FRAGMENT_SHADER_DERIVATIVE_HINT_OES
        {
            get;
            set;
        }
    }
    public partial interface WebGLFramebuffer : WebGLObject { }
    public partial interface WebGLShader : WebGLObject { }
    public partial interface OES_texture_float_linear { }
    public partial interface WebGLObject { }
    public partial interface WebGLBuffer : WebGLObject
    {
        int references { get; set; }

        int capacity { get; set; }
    }
    public partial interface WebGLShaderPrecisionFormat
    {
        int rangeMin
        {
            get;
            set;
        }
        int rangeMax
        {
            get;
            set;
        }
        int precision
        {
            get;
            set;
        }
    }
    public partial interface EXT_texture_filter_anisotropic
    {
        int TEXTURE_MAX_ANISOTROPY_EXT
        {
            get;
            set;
        }
        int MAX_TEXTURE_MAX_ANISOTROPY_EXT
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
        int compare(string x, string y);
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
        int minimumintegerDigits
        {
            get;
            set;
        }
        int minimumFractionDigits
        {
            get;
            set;
        }
        int maximumFractionDigits
        {
            get;
            set;
        }
        int minimumSignificantDigits
        {
            get;
            set;
        }
        int maximumSignificantDigits
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
        string format(int value);
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
        string format(int date);
        ResolvedDateTimeFormatOptions resolvedOptions();
    }
}

//const int VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE = 0x88FE;
public interface ANGLE_instanced_arrays
{
    void drawArraysInstancedANGLE(int mode, int first, int count, int primcount);
    void drawElementsInstancedANGLE(int mode, int count, int type, IntPtr offset, int primcount);
    void vertexAttribDivisorANGLE(uint index, uint divisor);
};