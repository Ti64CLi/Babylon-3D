using System;

namespace Web
{
    using System;

    using BABYLON;

    using Intl;

    public partial interface ArrayBuffer
    {
        int byteLength { get; set; }
    }

    public partial interface ArrayBufferView
    {
        ArrayBuffer buffer { get; set; }

        int byteLength { get; set; }

        int byteOffset { get; set; }
    }

    public partial interface Int8Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        sbyte this[int index] { get; set; }

        int Length { get; set; }

        sbyte get(int index);

        void set(int index, sbyte value);

        void set(Int8Array array, int offset = 0);

        void set(Array<sbyte> array, int offset = 0);

        Int8Array subarray(int begin, int end = 0);
    }

    public partial interface Uint8Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        byte this[int index] { get; set; }

        int Length { get; set; }

        byte get(int index);

        void set(int index, byte value);

        void set(Uint8Array array, int offset = 0);

        void set(Array<byte> array, int offset = 0);

        Uint8Array subarray(int begin, int end = 0);
    }

    public partial interface Int16Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        short this[int index] { get; set; }

        int Length { get; set; }

        short get(int index);

        void set(int index, short value);

        void set(Int16Array array, int offset = 0);

        void set(Array<short> array, int offset = 0);

        Int16Array subarray(int begin, int end = 0);
    }

    public partial interface Uint16Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        ushort this[int index] { get; set; }

        int Length { get; set; }

        ushort get(int index);

        void set(int index, ushort value);

        void set(Uint16Array array, int offset = 0);

        void set(Array<ushort> array, int offset = 0);

        Uint16Array subarray(int begin, int end = 0);
    }

    public partial interface Int32Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        int this[int index] { get; set; }

        int Length { get; set; }

        int get(int index);

        void set(int index, int value);

        void set(Int32Array array, int offset = 0);

        void set(Array<int> array, int offset = 0);

        Int32Array subarray(int begin, int end = 0);
    }

    public partial interface Uint32Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        int this[int index] { get; set; }

        int Length { get; set; }

        uint get(int index);

        void set(int index, uint value);

        void set(Uint32Array array, int offset = 0);

        void set(Array<uint> array, int offset = 0);

        Uint32Array subarray(int begin, int end = 0);
    }

    public partial interface Float32Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        float this[int index] { get; set; }

        int Length { get; set; }

        float get(int index);

        void set(int index, float value);

        void set(Float32Array array, int offset = 0);

        void set(Array<float> array, int offset = 0);

        Float32Array subarray(int begin, int end = 0);
    }

    public partial interface Float64Array : ArrayBufferView
    {
        int BYTES_PER_ELEMENT { get; set; }

        int this[int index] { get; set; }

        int Length { get; set; }

        int get(int index);

        void set(int index, int value);

        void set(Float64Array array, int offset = 0);

        void set(float[] array, int offset = 0);

        Float64Array subarray(int begin, int end = 0);
    }

    public partial interface DataView : ArrayBufferView
    {
        int getFloat32(int byteOffset, bool littleEndian = false);

        int getFloat64(int byteOffset, bool littleEndian = false);

        int getInt16(int byteOffset, bool littleEndian = false);

        int getInt32(int byteOffset, bool littleEndian = false);

        int getInt8(int byteOffset);

        int getUint16(int byteOffset, bool littleEndian = false);

        int getUint32(int byteOffset, bool littleEndian = false);

        int getUint8(int byteOffset);

        void setFloat32(int byteOffset, int value, bool littleEndian = false);

        void setFloat64(int byteOffset, int value, bool littleEndian = false);

        void setInt16(int byteOffset, int value, bool littleEndian = false);

        void setInt32(int byteOffset, int value, bool littleEndian = false);

        void setInt8(int byteOffset, int value);

        void setUint16(int byteOffset, int value, bool littleEndian = false);

        void setUint32(int byteOffset, int value, bool littleEndian = false);

        void setUint8(int byteOffset, int value);
    }

    public partial interface Map<K, V>
    {
        int size { get; set; }

        void clear();

        bool delete(K key);

        void forEach(Action<V, K, Map<K, V>> callbackfn, object thisArg = null);

        V get(K key);

        bool has(K key);

        Map<K, V> set(K key, V value);
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
        int size { get; set; }

        Set<T> add(T value);

        void clear();

        bool delete(T value);

        void forEach(Action<T, T, Set<T>> callbackfn, object thisArg = null);

        bool has(T value);
    }

    public partial interface String
    {
        int localeCompare(string that, Array<string> locales, CollatorOptions options = null);

        int localeCompare(string that, string locale, CollatorOptions options = null);
    }

    public partial interface Number
    {
        string toLocaleString(Array<string> locales = null, NumberFormatOptions options = null);

        string toLocaleString(string locale = null, NumberFormatOptions options = null);
    }

    public partial interface Date
    {
        string toLocaleString(Array<string> locales = null, DateTimeFormatOptions options = null);

        string toLocaleString(string locale = null, DateTimeFormatOptions options = null);
    }

    public partial interface PositionOptions
    {
        bool enableHighAccuracy { get; set; }

        int maximumAge { get; set; }

        int timeout { get; set; }
    }

    public partial interface ObjectURLOptions
    {
        bool oneTimeOnly { get; set; }
    }

    public partial interface StoreExceptionsInformation : ExceptionInformation
    {
        string detailURI { get; set; }

        string explanationString { get; set; }

        string siteName { get; set; }
    }

    public partial interface StoreSiteSpecificExceptionsInformation : StoreExceptionsInformation
    {
        Array<string> arrayOfDomainStrings { get; set; }
    }

    public partial interface ConfirmSiteSpecificExceptionsInformation : ExceptionInformation
    {
        Array<string> arrayOfDomainStrings { get; set; }
    }

    public partial interface AlgorithmParameters
    {
    }

    public partial interface MutationObserverInit
    {
        Array<string> attributeFilter { get; set; }

        bool attributeOldValue { get; set; }

        bool attributes { get; set; }

        bool characterData { get; set; }

        bool characterDataOldValue { get; set; }

        bool childList { get; set; }

        bool subtree { get; set; }
    }

    public partial interface PointerEventInit : MouseEventInit
    {
        int height { get; set; }

        bool isPrimary { get; set; }

        int pointerId { get; set; }

        string pointerType { get; set; }

        int pressure { get; set; }

        int tiltX { get; set; }

        int tiltY { get; set; }

        int width { get; set; }
    }

    public partial interface ExceptionInformation
    {
        string domain { get; set; }
    }

    public partial interface DeviceAccelerationDict
    {
        double x { get; set; }

        double y { get; set; }

        double z { get; set; }
    }

    public partial interface MsZoomToOptions
    {
        string animate { get; set; }

        int contentX { get; set; }

        int contentY { get; set; }

        int scaleFactor { get; set; }

        string viewportX { get; set; }

        string viewportY { get; set; }
    }

    public partial interface DeviceRotationRateDict
    {
        int alpha { get; set; }

        int beta { get; set; }

        int gamma { get; set; }
    }

    public partial interface Algorithm
    {
        AlgorithmParameters _params { get; set; }

        string name { get; set; }
    }

    public partial interface MouseEventInit
    {
        bool altKey { get; set; }

        bool bubbles { get; set; }

        int button { get; set; }

        int buttons { get; set; }

        bool cancelable { get; set; }

        int clientX { get; set; }

        int clientY { get; set; }

        bool ctrlKey { get; set; }

        int detail { get; set; }

        bool metaKey { get; set; }

        EventTarget relatedTarget { get; set; }

        int screenX { get; set; }

        int screenY { get; set; }

        bool shiftKey { get; set; }

        Window view { get; set; }
    }

    public partial interface WebGLContextAttributes
    {
        bool alpha { get; set; }

        bool antialias { get; set; }

        bool depth { get; set; }

        bool premultipliedAlpha { get; set; }

        bool preserveDrawingBuffer { get; set; }

        bool stencil { get; set; }
    }

    public partial interface NodeListOf<TNode> : NodeList
    {
    }

    public partial interface HTMLElement : Element, ElementCSSInlineStyle, MSEventAttachmentTarget, MSNodeExtensions
    {
        string accessKey { get; set; }

        HTMLCollection all { get; set; }

        MSBehaviorUrnsCollection behaviorUrns { get; set; }

        bool canHaveChildren { get; set; }

        bool canHaveHTML { get; set; }

        HTMLCollection children { get; set; }

        DOMTokenList classList { get; set; }

        string className { get; set; }

        string contentEditable { get; set; }

        DOMStringMap dataset { get; set; }

        string dir { get; set; }

        bool disabled { get; set; }

        Document document { get; set; }

        bool draggable { get; set; }

        object filters { get; set; }

        object hidden { get; set; }

        bool hideFocus { get; set; }

        string id { get; set; }

        string innerHTML { get; set; }

        string innerText { get; set; }

        bool isContentEditable { get; set; }

        bool isDisabled { get; set; }

        bool isMultiLine { get; set; }

        bool isTextEdit { get; set; }

        string lang { get; set; }

        string language { get; set; }

        int offsetHeight { get; set; }

        int offsetLeft { get; set; }

        Element offsetParent { get; set; }

        int offsetTop { get; set; }

        int offsetWidth { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<UIEvent, object> onactivate { get; set; }

        Func<MSEventObj, object> onafterupdate { get; set; }

        Func<UIEvent, object> onbeforeactivate { get; set; }

        Func<DragEvent, object> onbeforecopy { get; set; }

        Func<DragEvent, object> onbeforecut { get; set; }

        Func<UIEvent, object> onbeforedeactivate { get; set; }

        Func<MSEventObj, object> onbeforeeditfocus { get; set; }

        Func<DragEvent, object> onbeforepaste { get; set; }

        Func<MSEventObj, object> onbeforeupdate { get; set; }

        Func<FocusEvent, object> onblur { get; set; }

        Func<Event, object> oncanplay { get; set; }

        Func<Event, object> oncanplaythrough { get; set; }

        Func<MSEventObj, object> oncellchange { get; set; }

        Func<Event, object> onchange { get; set; }

        Func<MouseEvent, object> onclick { get; set; }

        Func<MouseEvent, object> oncontextmenu { get; set; }

        Func<MSEventObj, object> oncontrolselect { get; set; }

        Func<DragEvent, object> oncopy { get; set; }

        Func<Event, object> oncuechange { get; set; }

        Func<DragEvent, object> oncut { get; set; }

        Func<MSEventObj, object> ondataavailable { get; set; }

        Func<MSEventObj, object> ondatasetchanged { get; set; }

        Func<MSEventObj, object> ondatasetcomplete { get; set; }

        Func<MouseEvent, object> ondblclick { get; set; }

        Func<UIEvent, object> ondeactivate { get; set; }

        Func<DragEvent, object> ondrag { get; set; }

        Func<DragEvent, object> ondragend { get; set; }

        Func<DragEvent, object> ondragenter { get; set; }

        Func<DragEvent, object> ondragleave { get; set; }

        Func<DragEvent, object> ondragover { get; set; }

        Func<DragEvent, object> ondragstart { get; set; }

        Func<DragEvent, object> ondrop { get; set; }

        Func<Event, object> ondurationchange { get; set; }

        Func<Event, object> onemptied { get; set; }

        Func<Event, object> onended { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<MSEventObj, object> onerrorupdate { get; set; }

        Func<MSEventObj, object> onfilterchange { get; set; }

        Func<FocusEvent, object> onfocus { get; set; }

        Func<FocusEvent, object> onfocusin { get; set; }

        Func<FocusEvent, object> onfocusout { get; set; }

        Func<Event, object> onhelp { get; set; }

        Func<Event, object> oninput { get; set; }

        Func<KeyboardEvent, object> onkeydown { get; set; }

        Func<KeyboardEvent, object> onkeypress { get; set; }

        Func<KeyboardEvent, object> onkeyup { get; set; }

        Func<MSEventObj, object> onlayoutcomplete { get; set; }

        Func<Event, object> onload { get; set; }

        Func<Event, object> onloadeddata { get; set; }

        Func<Event, object> onloadedmetadata { get; set; }

        Func<Event, object> onloadstart { get; set; }

        Func<MSEventObj, object> onlosecapture { get; set; }

        Func<MouseEvent, object> onmousedown { get; set; }

        Func<MouseEvent, object> onmouseenter { get; set; }

        Func<MouseEvent, object> onmouseleave { get; set; }

        Func<MouseEvent, object> onmousemove { get; set; }

        Func<MouseEvent, object> onmouseout { get; set; }

        Func<MouseEvent, object> onmouseover { get; set; }

        Func<MouseEvent, object> onmouseup { get; set; }

        Func<MouseWheelEvent, object> onmousewheel { get; set; }

        Func<MSEventObj, object> onmove { get; set; }

        Func<MSEventObj, object> onmoveend { get; set; }

        Func<MSEventObj, object> onmovestart { get; set; }

        Func<MSEventObj, object> onmscontentzoom { get; set; }

        Func<object, object> onmsmanipulationstatechanged { get; set; }

        Func<DragEvent, object> onpaste { get; set; }

        Func<Event, object> onpause { get; set; }

        Func<Event, object> onplay { get; set; }

        Func<Event, object> onplaying { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<MSEventObj, object> onpropertychange { get; set; }

        Func<Event, object> onratechange { get; set; }

        Func<Event, object> onreadystatechange { get; set; }

        Func<Event, object> onreset { get; set; }

        Func<UIEvent, object> onresize { get; set; }

        Func<MSEventObj, object> onresizeend { get; set; }

        Func<MSEventObj, object> onresizestart { get; set; }

        Func<MSEventObj, object> onrowenter { get; set; }

        Func<MSEventObj, object> onrowexit { get; set; }

        Func<MSEventObj, object> onrowsdelete { get; set; }

        Func<MSEventObj, object> onrowsinserted { get; set; }

        Func<UIEvent, object> onscroll { get; set; }

        Func<Event, object> onseeked { get; set; }

        Func<Event, object> onseeking { get; set; }

        Func<UIEvent, object> onselect { get; set; }

        Func<Event, object> onselectstart { get; set; }

        Func<Event, object> onstalled { get; set; }

        Func<Event, object> onsubmit { get; set; }

        Func<Event, object> onsuspend { get; set; }

        Func<Event, object> ontimeupdate { get; set; }

        Func<Event, object> onvolumechange { get; set; }

        Func<Event, object> onwaiting { get; set; }

        string outerHTML { get; set; }

        string outerText { get; set; }

        HTMLElement parentElement { get; set; }

        Element parentTextEdit { get; set; }

        object readyState { get; set; }

        object recordNumber { get; set; }

        string scopeName { get; set; }

        int sourceIndex { get; set; }

        bool spellcheck { get; set; }

        MSStyleCSSProperties style { get; set; }

        int tabIndex { get; set; }

        string tagUrn { get; set; }

        string title { get; set; }

        string uniqueID { get; set; }

        int uniqueNumber { get; set; }

        int addBehavior(string bstrUrl, object factory = null);

        void addFilter(object filter);

        Element applyElement(Element apply, string where = null);

        void blur();

        void clearAttributes();

        void click();

        bool contains(HTMLElement child);

        ControlRangeCollection createControlRange();

        bool dragDrop();

        void focus();

        string getAdjacentText(string where);

        NodeList getElementsByClassName(string classNames);

        Element insertAdjacentElement(string position, Element insertedElement);

        void insertAdjacentHTML(string where, string html);

        void insertAdjacentText(string where, string text);

        void mergeAttributes(HTMLElement source, bool preserveIdentity = false);

        MSInputMethodContext msGetInputContext();

        void releaseCapture();

        bool removeBehavior(int cookie);

        void removeFilter(object filter);

        string replaceAdjacentText(string where, string newText);

        void scrollIntoView(bool top = false);

        void setActive();

        void setCapture(bool containerCapture = false);
    }

    public partial interface Document : Node,
                                        NodeSelector,
                                        MSEventAttachmentTarget,
                                        DocumentEvent,
                                        MSResourceMetadata,
                                        MSNodeExtensions,
                                        MSDocumentExtensions,
                                        GlobalEventHandlers
    {
        MSScriptHost Script { get; set; }

        string URL { get; set; }

        string URLUnencoded { get; set; }

        Element activeElement { get; set; }

        string alinkColor { get; set; }

        HTMLCollection all { get; set; }

        HTMLCollection anchors { get; set; }

        HTMLCollection applets { get; set; }

        string bgColor { get; set; }

        HTMLElement body { get; set; }

        string characterSet { get; set; }

        string charset { get; set; }

        string compatMode { get; set; }

        MSCompatibleInfoCollection compatible { get; set; }

        string cookie { get; set; }

        string defaultCharset { get; set; }

        Window defaultView { get; set; }

        string designMode { get; set; }

        string dir { get; set; }

        DocumentType doctype { get; set; }

        HTMLElement documentElement { get; set; }

        int documentMode { get; set; }

        string domain { get; set; }

        HTMLCollection embeds { get; set; }

        string fgColor { get; set; }

        HTMLCollection forms { get; set; }

        Window frames { get; set; }

        HTMLHeadElement head { get; set; }

        bool hidden { get; set; }

        HTMLCollection images { get; set; }

        DOMImplementation implementation { get; set; }

        string inputEncoding { get; set; }

        string lastModified { get; set; }

        string linkColor { get; set; }

        HTMLCollection links { get; set; }

        Location location { get; set; }

        string media { get; set; }

        bool msCSSOMElementFloatMetrics { get; set; }

        bool msCapsLockWarningOff { get; set; }

        Element msFullscreenElement { get; set; }

        bool msFullscreenEnabled { get; set; }

        bool msHidden { get; set; }

        string msVisibilityState { get; set; }

        MSNamespaceInfoCollection namespaces { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<UIEvent, object> onactivate { get; set; }

        Func<MSEventObj, object> onafterupdate { get; set; }

        Func<UIEvent, object> onbeforeactivate { get; set; }

        Func<UIEvent, object> onbeforedeactivate { get; set; }

        Func<MSEventObj, object> onbeforeeditfocus { get; set; }

        Func<MSEventObj, object> onbeforeupdate { get; set; }

        Func<FocusEvent, object> onblur { get; set; }

        Func<Event, object> oncanplay { get; set; }

        Func<Event, object> oncanplaythrough { get; set; }

        Func<MSEventObj, object> oncellchange { get; set; }

        Func<Event, object> onchange { get; set; }

        Func<MouseEvent, object> onclick { get; set; }

        Func<MouseEvent, object> oncontextmenu { get; set; }

        Func<MSEventObj, object> oncontrolselect { get; set; }

        Func<MSEventObj, object> ondataavailable { get; set; }

        Func<MSEventObj, object> ondatasetchanged { get; set; }

        Func<MSEventObj, object> ondatasetcomplete { get; set; }

        Func<MouseEvent, object> ondblclick { get; set; }

        Func<UIEvent, object> ondeactivate { get; set; }

        Func<DragEvent, object> ondrag { get; set; }

        Func<DragEvent, object> ondragend { get; set; }

        Func<DragEvent, object> ondragenter { get; set; }

        Func<DragEvent, object> ondragleave { get; set; }

        Func<DragEvent, object> ondragover { get; set; }

        Func<DragEvent, object> ondragstart { get; set; }

        Func<DragEvent, object> ondrop { get; set; }

        Func<Event, object> ondurationchange { get; set; }

        Func<Event, object> onemptied { get; set; }

        Func<Event, object> onended { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<MSEventObj, object> onerrorupdate { get; set; }

        Func<FocusEvent, object> onfocus { get; set; }

        Func<FocusEvent, object> onfocusin { get; set; }

        Func<FocusEvent, object> onfocusout { get; set; }

        Func<Event, object> onhelp { get; set; }

        Func<Event, object> oninput { get; set; }

        Func<KeyboardEvent, object> onkeydown { get; set; }

        Func<KeyboardEvent, object> onkeypress { get; set; }

        Func<KeyboardEvent, object> onkeyup { get; set; }

        Func<Event, object> onload { get; set; }

        Func<Event, object> onloadeddata { get; set; }

        Func<Event, object> onloadedmetadata { get; set; }

        Func<Event, object> onloadstart { get; set; }

        Func<MouseEvent, object> onmousedown { get; set; }

        Func<MouseEvent, object> onmousemove { get; set; }

        Func<MouseEvent, object> onmouseout { get; set; }

        Func<MouseEvent, object> onmouseover { get; set; }

        Func<MouseEvent, object> onmouseup { get; set; }

        Func<MouseWheelEvent, object> onmousewheel { get; set; }

        Func<MSEventObj, object> onmscontentzoom { get; set; }

        Func<object, object> onmsfullscreenchange { get; set; }

        Func<object, object> onmsfullscreenerror { get; set; }

        Func<object, object> onmsgesturechange { get; set; }

        Func<object, object> onmsgesturedoubletap { get; set; }

        Func<object, object> onmsgestureend { get; set; }

        Func<object, object> onmsgesturehold { get; set; }

        Func<object, object> onmsgesturestart { get; set; }

        Func<object, object> onmsgesturetap { get; set; }

        Func<object, object> onmsinertiastart { get; set; }

        Func<object, object> onmsmanipulationstatechanged { get; set; }

        Func<object, object> onmspointercancel { get; set; }

        Func<object, object> onmspointerdown { get; set; }

        Func<object, object> onmspointerenter { get; set; }

        Func<object, object> onmspointerhover { get; set; }

        Func<object, object> onmspointerleave { get; set; }

        Func<object, object> onmspointermove { get; set; }

        Func<object, object> onmspointerout { get; set; }

        Func<object, object> onmspointerover { get; set; }

        Func<object, object> onmspointerup { get; set; }

        Func<MSSiteModeEvent, object> onmssitemodejumplistitemremoved { get; set; }

        Func<MSSiteModeEvent, object> onmsthumbnailclick { get; set; }

        Func<Event, object> onpause { get; set; }

        Func<Event, object> onplay { get; set; }

        Func<Event, object> onplaying { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<MSEventObj, object> onpropertychange { get; set; }

        Func<Event, object> onratechange { get; set; }

        Func<Event, object> onreadystatechange { get; set; }

        Func<Event, object> onreset { get; set; }

        Func<MSEventObj, object> onrowenter { get; set; }

        Func<MSEventObj, object> onrowexit { get; set; }

        Func<MSEventObj, object> onrowsdelete { get; set; }

        Func<MSEventObj, object> onrowsinserted { get; set; }

        Func<UIEvent, object> onscroll { get; set; }

        Func<Event, object> onseeked { get; set; }

        Func<Event, object> onseeking { get; set; }

        Func<UIEvent, object> onselect { get; set; }

        Func<Event, object> onselectionchange { get; set; }

        Func<Event, object> onselectstart { get; set; }

        Func<Event, object> onstalled { get; set; }

        Func<Event, object> onstop { get; set; }

        Func<StorageEvent, object> onstoragecommit { get; set; }

        Func<Event, object> onsubmit { get; set; }

        Func<Event, object> onsuspend { get; set; }

        Func<Event, object> ontimeupdate { get; set; }

        Func<Event, object> onvolumechange { get; set; }

        Func<Event, object> onwaiting { get; set; }

        Window parentWindow { get; set; }

        HTMLCollection plugins { get; set; }

        string readyState { get; set; }

        string referrer { get; set; }

        SVGSVGElement rootElement { get; set; }

        HTMLCollection scripts { get; set; }

        string security { get; set; }

        MSSelection selection { get; set; }

        StyleSheetList styleSheets { get; set; }

        string title { get; set; }

        string uniqueID { get; set; }

        string visibilityState { get; set; }

        string vlinkColor { get; set; }

        string xmlEncoding { get; set; }

        bool xmlStandalone { get; set; }

        string xmlVersion { get; set; }

        Node adoptNode(Node source);

        void clear();

        void close();

        Attr createAttribute(string name);

        Attr createAttributeNS(string namespaceURI, string qualifiedName);

        CDATASection createCDATASection(string data);

        Comment createComment(string data);

        DocumentFragment createDocumentFragment();

        HTMLElement createElement(string tagName);

        Element createElementNS(string namespaceURI, string qualifiedName);

        MSEventObj createEventObject(object eventObj = null);

        NodeIterator createNodeIterator(Node root, double whatToShow, NodeFilter filter, bool entityReferenceExpansion);

        ProcessingInstruction createProcessingInstruction(string target, string data);

        Range createRange();

        CSSStyleSheet createStyleSheet(string href = null, int index = 0);

        Text createTextNode(string data);

        TreeWalker createTreeWalker(Node root, double whatToShow, NodeFilter filter, bool entityReferenceExpansion);

        Element elementFromPoint(double x, double y);

        bool execCommand(string commandId, bool showUI = false, object value = null);

        bool execCommandShowHelp(string commandId);

        bool fireEvent(string eventName, object eventObj = null);

        void focus();

        HTMLElement getElementById(string elementId);

        NodeList getElementsByClassName(string classNames);

        NodeList getElementsByName(string elementName);

        NodeList getElementsByTagName(string name);

        NodeList getElementsByTagNameNS(string namespaceURI, string localName);

        Selection getSelection();

        bool hasFocus();

        Node importNode(Node importedNode, bool deep);

        NodeList msElementsFromPoint(double x, double y);

        NodeList msElementsFromRect(int left, int top, int width, int height);

        void msExitFullscreen();

        object open(string url = null, string name = null, string features = null, bool replace = false);

        bool queryCommandEnabled(string commandId);

        bool queryCommandIndeterm(string commandId);

        bool queryCommandState(string commandId);

        bool queryCommandSupported(string commandId);

        string queryCommandText(string commandId);

        string queryCommandValue(string commandId);

        void releaseCapture();

        void updateSettings();

        void write(params object[] content);

        void writeln(params object[] content);
    }

    public partial interface Console
    {
        void assert(bool test = false, string message = null, params object[] optionalParams);

        void clear();

        void count(string countTitle = null);

        void debug(string message = null, params object[] optionalParams);

        void dir(object value = null, params object[] optionalParams);

        void dirxml(object value);

        void error(object message = null, params object[] optionalParams);

        void group(string groupTitle = null);

        void groupCollapsed(string groupTitle = null);

        void groupEnd();

        void info(object message = null, params object[] optionalParams);

        void log(object message = null, params object[] optionalParams);

        bool msIsIndependentlyComposed(Element element);

        void profile(string reportName = null);

        void profileEnd();

        void select(Element element);

        void time(string timerName = null);

        void timeEnd(string timerName = null);

        void trace();

        void warn(object message = null, params object[] optionalParams);
    }

    public partial interface MSEventObj : Event
    {
        string actionURL { get; set; }

        bool altKey { get; set; }

        bool altLeft { get; set; }

        int behaviorCookie { get; set; }

        int behaviorPart { get; set; }

        BookmarkCollection bookmarks { get; set; }

        HTMLCollection boundElements { get; set; }

        int button { get; set; }

        int buttonID { get; set; }

        int clientX { get; set; }

        int clientY { get; set; }

        bool contentOverflow { get; set; }

        bool ctrlKey { get; set; }

        bool ctrlLeft { get; set; }

        string data { get; set; }

        string dataFld { get; set; }

        DataTransfer dataTransfer { get; set; }

        Element fromElement { get; set; }

        int keyCode { get; set; }

        string nextPage { get; set; }

        int offsetX { get; set; }

        int offsetY { get; set; }

        string origin { get; set; }

        string propertyName { get; set; }

        string qualifier { get; set; }

        int reason { get; set; }

        object recordset { get; set; }

        bool repeat { get; set; }

        object returnValue { get; set; }

        int screenX { get; set; }

        int screenY { get; set; }

        bool shiftKey { get; set; }

        bool shiftLeft { get; set; }

        Window source { get; set; }

        object srcFilter { get; set; }

        string srcUrn { get; set; }

        Element toElement { get; set; }

        string url { get; set; }

        double wheelDelta { get; set; }

        double x { get; set; }

        double y { get; set; }

        object getAttribute(string strAttributeName, int lFlags = 0);

        bool removeAttribute(string strAttributeName, int lFlags = 0);

        void setAttribute(string strAttributeName, object AttributeValue, int lFlags = 0);
    }

    public partial interface HTMLCanvasElement : HTMLElement
    {
        int height { get; set; }

        int width { get; set; }

        object getContext(string contextId, params object[] args);

        Blob msToBlob();

        string toDataURL(string type = null, params object[] args);
    }

    public partial interface Window : EventTarget,
                                      MSEventAttachmentTarget,
                                      WindowLocalStorage,
                                      MSWindowExtensions,
                                      WindowSessionStorage,
                                      WindowTimers,
                                      WindowBase64,
                                      IDBEnvironment,
                                      WindowConsole,
                                      GlobalEventHandlers
    {
        int Length { get; set; }

        int animationStartTime { get; set; }

        ApplicationCache applicationCache { get; set; }

        int devicePixelRatio { get; set; }

        string doNotTrack { get; set; }

        Document document { get; set; }

        Element frameElement { get; set; }

        Window frames { get; set; }

        History history { get; set; }

        int innerHeight { get; set; }

        int innerWidth { get; set; }

        Location location { get; set; }

        int msAnimationStartTime { get; set; }

        Crypto msCrypto { get; set; }

        string name { get; set; }

        Navigator navigator { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<Event, object> onafterprint { get; set; }

        Func<Event, object> onbeforeprint { get; set; }

        Func<BeforeUnloadEvent, object> onbeforeunload { get; set; }

        Func<FocusEvent, object> onblur { get; set; }

        Func<Event, object> oncanplay { get; set; }

        Func<Event, object> oncanplaythrough { get; set; }

        Func<Event, object> onchange { get; set; }

        Func<MouseEvent, object> onclick { get; set; }

        Func<MouseEvent, object> oncontextmenu { get; set; }

        Func<MouseEvent, object> ondblclick { get; set; }

        Func<DeviceMotionEvent, object> ondevicemotion { get; set; }

        Func<DeviceOrientationEvent, object> ondeviceorientation { get; set; }

        Func<DragEvent, object> ondrag { get; set; }

        Func<DragEvent, object> ondragend { get; set; }

        Func<DragEvent, object> ondragenter { get; set; }

        Func<DragEvent, object> ondragleave { get; set; }

        Func<DragEvent, object> ondragover { get; set; }

        Func<DragEvent, object> ondragstart { get; set; }

        Func<DragEvent, object> ondrop { get; set; }

        Func<Event, object> ondurationchange { get; set; }

        Func<Event, object> onemptied { get; set; }

        Func<Event, object> onended { get; set; }

        ErrorEventHandler onerror { get; set; }

        Func<FocusEvent, object> onfocus { get; set; }

        Func<Event, object> onhashchange { get; set; }

        Func<Event, object> oninput { get; set; }

        Func<KeyboardEvent, object> onkeydown { get; set; }

        Func<KeyboardEvent, object> onkeypress { get; set; }

        Func<KeyboardEvent, object> onkeyup { get; set; }

        Func<Event, object> onload { get; set; }

        Func<Event, object> onloadeddata { get; set; }

        Func<Event, object> onloadedmetadata { get; set; }

        Func<Event, object> onloadstart { get; set; }

        Func<MessageEvent, object> onmessage { get; set; }

        Func<MouseEvent, object> onmousedown { get; set; }

        Func<MouseEvent, object> onmousemove { get; set; }

        Func<MouseEvent, object> onmouseout { get; set; }

        Func<MouseEvent, object> onmouseover { get; set; }

        Func<MouseEvent, object> onmouseup { get; set; }

        Func<MouseWheelEvent, object> onmousewheel { get; set; }

        Func<object, object> onmsgesturechange { get; set; }

        Func<object, object> onmsgesturedoubletap { get; set; }

        Func<object, object> onmsgestureend { get; set; }

        Func<object, object> onmsgesturehold { get; set; }

        Func<object, object> onmsgesturestart { get; set; }

        Func<object, object> onmsgesturetap { get; set; }

        Func<object, object> onmsinertiastart { get; set; }

        Func<object, object> onmspointercancel { get; set; }

        Func<object, object> onmspointerdown { get; set; }

        Func<object, object> onmspointerenter { get; set; }

        Func<object, object> onmspointerhover { get; set; }

        Func<object, object> onmspointerleave { get; set; }

        Func<object, object> onmspointermove { get; set; }

        Func<object, object> onmspointerout { get; set; }

        Func<object, object> onmspointerover { get; set; }

        Func<object, object> onmspointerup { get; set; }

        Func<Event, object> onoffline { get; set; }

        Func<Event, object> ononline { get; set; }

        Func<PageTransitionEvent, object> onpagehide { get; set; }

        Func<PageTransitionEvent, object> onpageshow { get; set; }

        Func<Event, object> onpause { get; set; }

        Func<Event, object> onplay { get; set; }

        Func<Event, object> onplaying { get; set; }

        Func<PopStateEvent, object> onpopstate { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<Event, object> onratechange { get; set; }

        Func<Event, object> onreadystatechange { get; set; }

        Func<Event, object> onreset { get; set; }

        Func<UIEvent, object> onresize { get; set; }

        Func<UIEvent, object> onscroll { get; set; }

        Func<Event, object> onseeked { get; set; }

        Func<Event, object> onseeking { get; set; }

        Func<UIEvent, object> onselect { get; set; }

        Func<Event, object> onstalled { get; set; }

        Func<StorageEvent, object> onstorage { get; set; }

        Func<Event, object> onsubmit { get; set; }

        Func<Event, object> onsuspend { get; set; }

        Func<Event, object> ontimeupdate { get; set; }

        Func<Event, object> onunload { get; set; }

        Func<Event, object> onvolumechange { get; set; }

        Func<Event, object> onwaiting { get; set; }

        Window opener { get; set; }

        int outerHeight { get; set; }

        int outerWidth { get; set; }

        int pageXOffset { get; set; }

        int pageYOffset { get; set; }

        Window parent { get; set; }

        Performance performance { get; set; }

        Screen screen { get; set; }

        int screenX { get; set; }

        int screenY { get; set; }

        Window self { get; set; }

        StyleMedia styleMedia { get; set; }

        Window top { get; set; }

        Window window { get; set; }

        string ToString();

        void alert(object message = null);

        void blur();

        void cancelAnimationFrame(int handle);

        void close();

        bool confirm(string message = null);

        void focus();

        CSSStyleDeclaration getComputedStyle(Element elt, string pseudoElt = null);

        Selection getSelection();

        MediaQueryList matchMedia(string mediaQuery);

        void msCancelRequestAnimationFrame(int handle);

        bool msIsStaticHTML(string html);

        MediaQueryList msMatchMedia(string mediaQuery);

        int msRequestAnimationFrame(FrameRequestCallback callback);

        Window open(string url = null, string target = null, string features = null, bool replace = false);

        void postMessage(object message, string targetOrigin, object ports = null);

        void print();

        string prompt(string message = null, string _default = null);

        int requestAnimationFrame(FrameRequestCallback callback);

        void scroll(double x = 0, double y = 0);

        void scrollBy(double x = 0, double y = 0);

        void scrollTo(double x = 0, double y = 0);

        object showModalDialog(string url = null, object argument = null, object options = null);
    }

    public partial interface NavigatorID
    {
        string appName { get; set; }

        string appVersion { get; set; }

        string platform { get; set; }

        string product { get; set; }

        string userAgent { get; set; }

        string vendor { get; set; }
    }

    public partial interface HTMLTableElement : HTMLElement,
                                                MSDataBindingTableExtensions,
                                                MSDataBindingExtensions,
                                                DOML2DeprecatedBackgroundStyle,
                                                DOML2DeprecatedBackgroundColorStyle
    {
        string align { get; set; }

        string border { get; set; }

        object borderColor { get; set; }

        object borderColorDark { get; set; }

        object borderColorLight { get; set; }

        HTMLTableCaptionElement caption { get; set; }

        string cellPadding { get; set; }

        string cellSpacing { get; set; }

        HTMLCollection cells { get; set; }

        int cols { get; set; }

        string frame { get; set; }

        object height { get; set; }

        HTMLCollection rows { get; set; }

        string rules { get; set; }

        string summary { get; set; }

        HTMLCollection tBodies { get; set; }

        HTMLTableSectionElement tFoot { get; set; }

        HTMLTableSectionElement tHead { get; set; }

        string width { get; set; }

        HTMLElement createCaption();

        HTMLElement createTBody();

        HTMLElement createTFoot();

        HTMLElement createTHead();

        void deleteCaption();

        void deleteRow(int index = 0);

        void deleteTFoot();

        void deleteTHead();

        HTMLElement insertRow(int index = 0);

        object moveRow(int indexFrom = 0, int indexTo = 0);
    }

    public partial interface TreeWalker
    {
        Node currentNode { get; set; }

        bool expandEntityReferences { get; set; }

        NodeFilter filter { get; set; }

        Node root { get; set; }

        double whatToShow { get; set; }

        Node firstChild();

        Node lastChild();

        Node nextNode();

        Node nextSibling();

        Node parentNode();

        Node previousNode();

        Node previousSibling();
    }

    public partial interface GetSVGDocument
    {
        Document getSVGDocument();
    }

    public partial interface SVGPathSegCurvetoQuadraticRel : SVGPathSeg
    {
        double x { get; set; }

        double x1 { get; set; }

        double y { get; set; }

        double y1 { get; set; }
    }

    public partial interface Performance
    {
        PerformanceNavigation navigation { get; set; }

        PerformanceTiming timing { get; set; }

        void clearMarks(string markName = null);

        void clearMeasures(string measureName = null);

        void clearResourceTimings();

        object getEntries();

        object getEntriesByName(string name, string entryType = null);

        object getEntriesByType(string entryType);

        object getMarks(string markName = null);

        object getMeasures(string measureName = null);

        void mark(string markName);

        void measure(string measureName, string startMarkName = null, string endMarkName = null);

        int now();

        void setResourceTimingBufferSize(int maxSize);

        object toJSON();
    }

    public partial interface MSDataBindingTableExtensions
    {
        int dataPageSize { get; set; }

        void firstPage();

        void lastPage();

        void nextPage();

        void previousPage();

        void refresh();
    }

    public partial interface CompositionEvent : UIEvent
    {
        string data { get; set; }

        string locale { get; set; }

        void initCompositionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, string locale);
    }

    public partial interface WindowTimers : WindowTimersExtension
    {
        void clearInterval(int handle);

        void clearTimeout(int handle);

        int setInterval(object handler, object timeout = null, params object[] args);

        int setTimeout(object handler, object timeout = null, params object[] args);
    }

    public partial interface SVGMarkerElement : SVGElement, SVGStylable, SVGLangSpace, SVGFitToViewBox, SVGExternalResourcesRequired
    {
        int SVG_MARKERUNITS_STROKEWIDTH { get; set; }

        int SVG_MARKERUNITS_UNKNOWN { get; set; }

        int SVG_MARKERUNITS_USERSPACEONUSE { get; set; }

        int SVG_MARKER_ORIENT_ANGLE { get; set; }

        int SVG_MARKER_ORIENT_AUTO { get; set; }

        int SVG_MARKER_ORIENT_UNKNOWN { get; set; }

        SVGAnimatedLength markerHeight { get; set; }

        SVGAnimatedEnumeration markerUnits { get; set; }

        SVGAnimatedLength markerWidth { get; set; }

        SVGAnimatedAngle orientAngle { get; set; }

        SVGAnimatedEnumeration orientType { get; set; }

        SVGAnimatedLength refX { get; set; }

        SVGAnimatedLength refY { get; set; }

        void setOrientToAngle(SVGAngle angle);

        void setOrientToAuto();
    }

    public partial interface CSSStyleDeclaration
    {
        string this[int index] { get; set; }

        int Length { get; set; }

        string alignContent { get; set; }

        string alignItems { get; set; }

        string alignSelf { get; set; }

        string alignmentBaseline { get; set; }

        string animation { get; set; }

        string animationDelay { get; set; }

        string animationDirection { get; set; }

        string animationDuration { get; set; }

        string animationFillMode { get; set; }

        string animationIterationCount { get; set; }

        string animationName { get; set; }

        string animationPlayState { get; set; }

        string animationTimingFunction { get; set; }

        string backfaceVisibility { get; set; }

        string background { get; set; }

        string backgroundAttachment { get; set; }

        string backgroundClip { get; set; }

        string backgroundColor { get; set; }

        string backgroundImage { get; set; }

        string backgroundOrigin { get; set; }

        string backgroundPosition { get; set; }

        string backgroundRepeat { get; set; }

        string backgroundSize { get; set; }

        string baselineShift { get; set; }

        string border { get; set; }

        string borderBottom { get; set; }

        string borderBottomColor { get; set; }

        string borderBottomLeftRadius { get; set; }

        string borderBottomRightRadius { get; set; }

        string borderBottomStyle { get; set; }

        string borderBottomWidth { get; set; }

        string borderCollapse { get; set; }

        string borderColor { get; set; }

        string borderImage { get; set; }

        string borderImageOutset { get; set; }

        string borderImageRepeat { get; set; }

        string borderImageSlice { get; set; }

        string borderImageSource { get; set; }

        string borderImageWidth { get; set; }

        string borderLeft { get; set; }

        string borderLeftColor { get; set; }

        string borderLeftStyle { get; set; }

        string borderLeftWidth { get; set; }

        string borderRadius { get; set; }

        string borderRight { get; set; }

        string borderRightColor { get; set; }

        string borderRightStyle { get; set; }

        string borderRightWidth { get; set; }

        string borderSpacing { get; set; }

        string borderStyle { get; set; }

        string borderTop { get; set; }

        string borderTopColor { get; set; }

        string borderTopLeftRadius { get; set; }

        string borderTopRightRadius { get; set; }

        string borderTopStyle { get; set; }

        string borderTopWidth { get; set; }

        string borderWidth { get; set; }

        string bottom { get; set; }

        string boxShadow { get; set; }

        string boxSizing { get; set; }

        string breakAfter { get; set; }

        string breakBefore { get; set; }

        string breakInside { get; set; }

        string captionSide { get; set; }

        string clear { get; set; }

        string clip { get; set; }

        string clipPath { get; set; }

        string clipRule { get; set; }

        string color { get; set; }

        string colorInterpolationFilters { get; set; }

        object columnCount { get; set; }

        string columnFill { get; set; }

        object columnGap { get; set; }

        string columnRule { get; set; }

        object columnRuleColor { get; set; }

        string columnRuleStyle { get; set; }

        object columnRuleWidth { get; set; }

        string columnSpan { get; set; }

        object columnWidth { get; set; }

        string columns { get; set; }

        string content { get; set; }

        string counterIncrement { get; set; }

        string counterReset { get; set; }

        string cssFloat { get; set; }

        string cssText { get; set; }

        string cursor { get; set; }

        string direction { get; set; }

        string display { get; set; }

        string dominantBaseline { get; set; }

        string emptyCells { get; set; }

        string enableBackground { get; set; }

        string fill { get; set; }

        string fillOpacity { get; set; }

        string fillRule { get; set; }

        string filter { get; set; }

        string flex { get; set; }

        string flexBasis { get; set; }

        string flexDirection { get; set; }

        string flexFlow { get; set; }

        string flexGrow { get; set; }

        string flexShrink { get; set; }

        string flexWrap { get; set; }

        string floodColor { get; set; }

        string floodOpacity { get; set; }

        string font { get; set; }

        string fontFamily { get; set; }

        string fontFeatureSettings { get; set; }

        string fontSize { get; set; }

        string fontSizeAdjust { get; set; }

        string fontStretch { get; set; }

        string fontStyle { get; set; }

        string fontVariant { get; set; }

        string fontWeight { get; set; }

        string glyphOrientationHorizontal { get; set; }

        string glyphOrientationVertical { get; set; }

        string height { get; set; }

        string justifyContent { get; set; }

        string kerning { get; set; }

        string left { get; set; }

        string letterSpacing { get; set; }

        string lightingColor { get; set; }

        string lineHeight { get; set; }

        string listStyle { get; set; }

        string listStyleImage { get; set; }

        string listStylePosition { get; set; }

        string listStyleType { get; set; }

        string margin { get; set; }

        string marginBottom { get; set; }

        string marginLeft { get; set; }

        string marginRight { get; set; }

        string marginTop { get; set; }

        string marker { get; set; }

        string markerEnd { get; set; }

        string markerMid { get; set; }

        string markerStart { get; set; }

        string mask { get; set; }

        string maxHeight { get; set; }

        string maxWidth { get; set; }

        string minHeight { get; set; }

        string minWidth { get; set; }

        string msAnimation { get; set; }

        string msAnimationDelay { get; set; }

        string msAnimationDirection { get; set; }

        string msAnimationDuration { get; set; }

        string msAnimationFillMode { get; set; }

        string msAnimationIterationCount { get; set; }

        string msAnimationName { get; set; }

        string msAnimationPlayState { get; set; }

        string msAnimationTimingFunction { get; set; }

        string msBackfaceVisibility { get; set; }

        string msContentZoomChaining { get; set; }

        string msContentZoomLimit { get; set; }

        object msContentZoomLimitMax { get; set; }

        object msContentZoomLimitMin { get; set; }

        string msContentZoomSnap { get; set; }

        string msContentZoomSnapPoints { get; set; }

        string msContentZoomSnapType { get; set; }

        string msContentZooming { get; set; }

        string msFlex { get; set; }

        string msFlexAlign { get; set; }

        string msFlexDirection { get; set; }

        string msFlexFlow { get; set; }

        string msFlexItemAlign { get; set; }

        string msFlexLinePack { get; set; }

        string msFlexNegative { get; set; }

        string msFlexOrder { get; set; }

        string msFlexPack { get; set; }

        string msFlexPositive { get; set; }

        string msFlexPreferredSize { get; set; }

        string msFlexWrap { get; set; }

        string msFlowFrom { get; set; }

        string msFlowInto { get; set; }

        string msFontFeatureSettings { get; set; }

        object msGridColumn { get; set; }

        string msGridColumnAlign { get; set; }

        object msGridColumnSpan { get; set; }

        string msGridColumns { get; set; }

        object msGridRow { get; set; }

        string msGridRowAlign { get; set; }

        object msGridRowSpan { get; set; }

        string msGridRows { get; set; }

        string msHighContrastAdjust { get; set; }

        string msHyphenateLimitChars { get; set; }

        object msHyphenateLimitLines { get; set; }

        object msHyphenateLimitZone { get; set; }

        string msHyphens { get; set; }

        string msImeAlign { get; set; }

        string msOverflowStyle { get; set; }

        string msPerspective { get; set; }

        string msPerspectiveOrigin { get; set; }

        string msScrollChaining { get; set; }

        string msScrollLimit { get; set; }

        object msScrollLimitXMax { get; set; }

        object msScrollLimitXMin { get; set; }

        object msScrollLimitYMax { get; set; }

        object msScrollLimitYMin { get; set; }

        string msScrollRails { get; set; }

        string msScrollSnapPointsX { get; set; }

        string msScrollSnapPointsY { get; set; }

        string msScrollSnapType { get; set; }

        string msScrollSnapX { get; set; }

        string msScrollSnapY { get; set; }

        string msScrollTranslation { get; set; }

        string msTextCombineHorizontal { get; set; }

        string msTouchAction { get; set; }

        string msTouchSelect { get; set; }

        string msTransform { get; set; }

        string msTransformOrigin { get; set; }

        string msTransformStyle { get; set; }

        string msTransition { get; set; }

        string msTransitionDelay { get; set; }

        string msTransitionDuration { get; set; }

        string msTransitionProperty { get; set; }

        string msTransitionTimingFunction { get; set; }

        string msUserSelect { get; set; }

        string msWrapFlow { get; set; }

        object msWrapMargin { get; set; }

        string msWrapThrough { get; set; }

        string opacity { get; set; }

        string order { get; set; }

        string orphans { get; set; }

        string outline { get; set; }

        string outlineColor { get; set; }

        string outlineStyle { get; set; }

        string outlineWidth { get; set; }

        string overflow { get; set; }

        string overflowX { get; set; }

        string overflowY { get; set; }

        string padding { get; set; }

        string paddingBottom { get; set; }

        string paddingLeft { get; set; }

        string paddingRight { get; set; }

        string paddingTop { get; set; }

        string pageBreakAfter { get; set; }

        string pageBreakBefore { get; set; }

        string pageBreakInside { get; set; }

        CSSRule parentRule { get; set; }

        string perspective { get; set; }

        string perspectiveOrigin { get; set; }

        string pointerEvents { get; set; }

        string position { get; set; }

        string quotes { get; set; }

        string right { get; set; }

        string rubyAlign { get; set; }

        string rubyOverhang { get; set; }

        string rubyPosition { get; set; }

        string stopColor { get; set; }

        string stopOpacity { get; set; }

        string stroke { get; set; }

        string strokeDasharray { get; set; }

        string strokeDashoffset { get; set; }

        string strokeLinecap { get; set; }

        string strokeLinejoin { get; set; }

        string strokeMiterlimit { get; set; }

        string strokeOpacity { get; set; }

        string strokeWidth { get; set; }

        string tableLayout { get; set; }

        string textAlign { get; set; }

        string textAlignLast { get; set; }

        string textAnchor { get; set; }

        string textDecoration { get; set; }

        string textIndent { get; set; }

        string textJustify { get; set; }

        string textOverflow { get; set; }

        string textShadow { get; set; }

        string textTransform { get; set; }

        string textUnderlinePosition { get; set; }

        string top { get; set; }

        string touchAction { get; set; }

        string transform { get; set; }

        string transformOrigin { get; set; }

        string transformStyle { get; set; }

        string transition { get; set; }

        string transitionDelay { get; set; }

        string transitionDuration { get; set; }

        string transitionProperty { get; set; }

        string transitionTimingFunction { get; set; }

        string unicodeBidi { get; set; }

        string verticalAlign { get; set; }

        string visibility { get; set; }

        string whiteSpace { get; set; }

        string widows { get; set; }

        string width { get; set; }

        string wordBreak { get; set; }

        string wordSpacing { get; set; }

        string wordWrap { get; set; }

        string zIndex { get; set; }

        string getPropertyPriority(string propertyName);

        string getPropertyValue(string propertyName);

        string item(int index);

        string removeProperty(string propertyName);

        void setProperty(string propertyName, string value, string priority = null);
    }

    public partial interface SVGGElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
    }

    public partial interface MSStyleCSSProperties : MSCSSProperties
    {
        int pixelBottom { get; set; }

        int pixelHeight { get; set; }

        int pixelLeft { get; set; }

        int pixelRight { get; set; }

        int pixelTop { get; set; }

        int pixelWidth { get; set; }

        int posBottom { get; set; }

        int posHeight { get; set; }

        int posLeft { get; set; }

        int posRight { get; set; }

        int posTop { get; set; }

        int posWidth { get; set; }

        bool textDecorationBlink { get; set; }

        bool textDecorationLineThrough { get; set; }

        bool textDecorationNone { get; set; }

        bool textDecorationOverline { get; set; }

        bool textDecorationUnderline { get; set; }
    }

    public partial interface Navigator : NavigatorID,
                                         NavigatorOnLine,
                                         NavigatorContentUtils,
                                         MSNavigatorExtensions,
                                         NavigatorGeolocation,
                                         MSNavigatorDoNotTrack,
                                         NavigatorStorageUtils,
                                         MSFileSaver
    {
        int maxTouchPoints { get; set; }

        bool msManipulationViewsEnabled { get; set; }

        int msMaxTouchPoints { get; set; }

        bool msPointerEnabled { get; set; }

        bool pointerEnabled { get; set; }

        void msLaunchUri(string uri, MSLaunchUriCallback successCallback = null, MSLaunchUriCallback noHandlerCallback = null);
    }

    public partial interface SVGPathSegCurvetoCubicSmoothAbs : SVGPathSeg
    {
        double x { get; set; }

        double x2 { get; set; }

        double y { get; set; }

        double y2 { get; set; }
    }

    public partial interface SVGZoomEvent : UIEvent
    {
        int newScale { get; set; }

        SVGPoint newTranslate { get; set; }

        int previousScale { get; set; }

        SVGPoint previousTranslate { get; set; }

        SVGRect zoomRectScreen { get; set; }
    }

    public partial interface NodeSelector
    {
        Element querySelector(string selectors);

        NodeList querySelectorAll(string selectors);
    }

    public partial interface HTMLTableDataCellElement : HTMLTableCellElement
    {
    }

    public partial interface HTMLBaseElement : HTMLElement
    {
        string href { get; set; }

        string target { get; set; }
    }

    public partial interface ClientRect
    {
        int bottom { get; set; }

        int height { get; set; }

        int left { get; set; }

        int right { get; set; }

        int top { get; set; }

        int width { get; set; }
    }

    public delegate void PositionErrorCallback(PositionError error);

    public partial interface DOMImplementation
    {
        Document createDocument(string namespaceURI, string qualifiedName, DocumentType doctype);

        DocumentType createDocumentType(string qualifiedName, string publicId, string systemId);

        Document createHTMLDocument(string title);

        bool hasFeature(string feature, string version = null);
    }

    public partial interface SVGUnitTypes
    {
        int SVG_UNIT_TYPE_OBJECTBOUNDINGBOX { get; set; }

        int SVG_UNIT_TYPE_UNKNOWN { get; set; }

        int SVG_UNIT_TYPE_USERSPACEONUSE { get; set; }
    }

    public partial interface Element : Node, NodeSelector, ElementTraversal, GlobalEventHandlers
    {
        int clientHeight { get; set; }

        int clientLeft { get; set; }

        int clientTop { get; set; }

        int clientWidth { get; set; }

        int msContentZoomFactor { get; set; }

        string msRegionOverflow { get; set; }

        Func<PointerEvent, object> ongotpointercapture { get; set; }

        Func<PointerEvent, object> onlostpointercapture { get; set; }

        Func<object, object> onmsgesturechange { get; set; }

        Func<object, object> onmsgesturedoubletap { get; set; }

        Func<object, object> onmsgestureend { get; set; }

        Func<object, object> onmsgesturehold { get; set; }

        Func<object, object> onmsgesturestart { get; set; }

        Func<object, object> onmsgesturetap { get; set; }

        Func<object, object> onmsgotpointercapture { get; set; }

        Func<object, object> onmsinertiastart { get; set; }

        Func<object, object> onmslostpointercapture { get; set; }

        Func<object, object> onmspointercancel { get; set; }

        Func<object, object> onmspointerdown { get; set; }

        Func<object, object> onmspointerenter { get; set; }

        Func<object, object> onmspointerhover { get; set; }

        Func<object, object> onmspointerleave { get; set; }

        Func<object, object> onmspointermove { get; set; }

        Func<object, object> onmspointerout { get; set; }

        Func<object, object> onmspointerover { get; set; }

        Func<object, object> onmspointerup { get; set; }

        int scrollHeight { get; set; }

        int scrollLeft { get; set; }

        int scrollTop { get; set; }

        int scrollWidth { get; set; }

        string tagName { get; set; }

        bool fireEvent(string eventName, object eventObj = null);

        string getAttribute(string name = null);

        string getAttributeNS(string namespaceURI, string localName);

        Attr getAttributeNode(string name);

        Attr getAttributeNodeNS(string namespaceURI, string localName);

        ClientRect getBoundingClientRect();

        ClientRectList getClientRects();

        NodeList getElementsByTagName(string name);

        NodeList getElementsByTagNameNS(string namespaceURI, string localName);

        bool hasAttribute(string name);

        bool hasAttributeNS(string namespaceURI, string localName);

        MSRangeCollection msGetRegionContent();

        ClientRect msGetUntransformedBounds();

        bool msMatchesSelector(string selectors);

        void msReleasePointerCapture(int pointerId);

        void msRequestFullscreen();

        void msSetPointerCapture(int pointerId);

        void msZoomTo(MsZoomToOptions args);

        void releasePointerCapture(int pointerId);

        void removeAttribute(string name = null);

        void removeAttributeNS(string namespaceURI, string localName);

        Attr removeAttributeNode(Attr oldAttr);

        void setAttribute(string name = null, string value = null);

        void setAttributeNS(string namespaceURI, string qualifiedName, string value);

        Attr setAttributeNode(Attr newAttr);

        Attr setAttributeNodeNS(Attr newAttr);

        void setPointerCapture(int pointerId);
    }

    public partial interface HTMLNextIdElement : HTMLElement
    {
        string n { get; set; }
    }

    public partial interface SVGPathSegMovetoRel : SVGPathSeg
    {
        double x { get; set; }

        double y { get; set; }
    }

    public partial interface SVGLineElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength x1 { get; set; }

        SVGAnimatedLength x2 { get; set; }

        SVGAnimatedLength y1 { get; set; }

        SVGAnimatedLength y2 { get; set; }
    }

    public partial interface HTMLParagraphElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        string align { get; set; }
    }

    public partial interface HTMLAreasCollection : HTMLCollection
    {
        void add(HTMLElement element, object before = null);

        void remove(int index = 0);
    }

    public partial interface SVGDescElement : SVGElement, SVGStylable, SVGLangSpace
    {
    }

    public partial interface Node : EventTarget
    {
        int ATTRIBUTE_NODE { get; set; }

        int CDATA_SECTION_NODE { get; set; }

        int COMMENT_NODE { get; set; }

        int DOCUMENT_FRAGMENT_NODE { get; set; }

        int DOCUMENT_NODE { get; set; }

        int DOCUMENT_POSITION_CONTAINED_BY { get; set; }

        int DOCUMENT_POSITION_CONTAINS { get; set; }

        int DOCUMENT_POSITION_DISCONNECTED { get; set; }

        int DOCUMENT_POSITION_FOLLOWING { get; set; }

        int DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC { get; set; }

        int DOCUMENT_POSITION_PRECEDING { get; set; }

        int DOCUMENT_TYPE_NODE { get; set; }

        int ELEMENT_NODE { get; set; }

        int ENTITY_NODE { get; set; }

        int ENTITY_REFERENCE_NODE { get; set; }

        int NOTATION_NODE { get; set; }

        int PROCESSING_INSTRUCTION_NODE { get; set; }

        int TEXT_NODE { get; set; }

        NamedNodeMap attributes { get; set; }

        NodeList childNodes { get; set; }

        Node firstChild { get; set; }

        Node lastChild { get; set; }

        string localName { get; set; }

        string namespaceURI { get; set; }

        Node nextSibling { get; set; }

        string nodeName { get; set; }

        int nodeType { get; set; }

        string nodeValue { get; set; }

        Document ownerDocument { get; set; }

        Node parentNode { get; set; }

        string prefix { get; set; }

        Node previousSibling { get; set; }

        string textContent { get; set; }

        Node appendChild(Node newChild);

        Node cloneNode(bool deep = false);

        int compareDocumentPosition(Node other);

        bool hasAttributes();

        bool hasChildNodes();

        Node insertBefore(Node newChild, Node refChild = null);

        bool isDefaultNamespace(string namespaceURI);

        bool isEqualNode(Node arg);

        bool isSameNode(Node other);

        bool isSupported(string feature, string version);

        string lookupNamespaceURI(string prefix);

        string lookupPrefix(string namespaceURI);

        void normalize();

        Node removeChild(Node oldChild);

        Node replaceChild(Node newChild, Node oldChild);
    }

    public partial interface SVGPathSegCurvetoQuadraticSmoothRel : SVGPathSeg
    {
        double x { get; set; }

        double y { get; set; }
    }

    public partial interface DOML2DeprecatedListSpaceReduction
    {
        bool compact { get; set; }
    }

    public partial interface MSScriptHost
    {
    }

    public partial interface SVGClipPathElement : SVGElement, SVGUnitTypes, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedEnumeration clipPathUnits { get; set; }
    }

    public partial interface MouseEvent : UIEvent
    {
        bool altKey { get; set; }

        int button { get; set; }

        int buttons { get; set; }

        int clientX { get; set; }

        int clientY { get; set; }

        bool ctrlKey { get; set; }

        Element fromElement { get; set; }

        int layerX { get; set; }

        int layerY { get; set; }

        bool metaKey { get; set; }

        int offsetX { get; set; }

        int offsetY { get; set; }

        int pageX { get; set; }

        int pageY { get; set; }

        EventTarget relatedTarget { get; set; }

        int screenX { get; set; }

        int screenY { get; set; }

        bool shiftKey { get; set; }

        Element toElement { get; set; }

        double which { get; set; }

        double x { get; set; }

        double y { get; set; }

        bool getModifierState(string keyArg);

        void initMouseEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            int buttonArg,
            EventTarget relatedTargetArg);
    }

    public partial interface RangeException
    {
        int BAD_BOUNDARYPOINTS_ERR { get; set; }

        int INVALID_NODE_TYPE_ERR { get; set; }

        int code { get; set; }

        string message { get; set; }

        string name { get; set; }

        string ToString();
    }

    public partial interface SVGTextPositioningElement : SVGTextContentElement
    {
        SVGAnimatedLengthList dx { get; set; }

        SVGAnimatedLengthList dy { get; set; }

        SVGAnimatedNumberList rotate { get; set; }

        SVGAnimatedLengthList x { get; set; }

        SVGAnimatedLengthList y { get; set; }
    }

    public partial interface HTMLAppletElement : HTMLElement,
                                                 DOML2DeprecatedMarginStyle,
                                                 DOML2DeprecatedBorderStyle,
                                                 DOML2DeprecatedAlignmentStyle,
                                                 MSDataBindingExtensions,
                                                 MSDataBindingRecordSetExtensions
    {
        string BaseHref { get; set; }

        string _object { get; set; }

        string alt { get; set; }

        string altHtml { get; set; }

        string archive { get; set; }

        string classid { get; set; }

        string code { get; set; }

        string codeBase { get; set; }

        string codeType { get; set; }

        Document contentDocument { get; set; }

        string data { get; set; }

        bool declare { get; set; }

        HTMLFormElement form { get; set; }

        string height { get; set; }

        string name { get; set; }

        string standby { get; set; }

        string type { get; set; }

        string useMap { get; set; }

        int width { get; set; }
    }

    public partial interface TextMetrics
    {
        int width { get; set; }
    }

    public partial interface DocumentEvent
    {
        Event createEvent(string eventInterface);
    }

    public partial interface HTMLOListElement : HTMLElement, DOML2DeprecatedListSpaceReduction, DOML2DeprecatedListNumberingAndBulletStyle
    {
        int start { get; set; }
    }

    public partial interface SVGPathSegLinetoVerticalRel : SVGPathSeg
    {
        double y { get; set; }
    }

    public partial interface SVGAnimatedString
    {
        string animVal { get; set; }

        string baseVal { get; set; }
    }

    public partial interface CDATASection : Text
    {
    }

    public partial interface StyleMedia
    {
        string type { get; set; }

        bool matchMedium(string mediaquery);
    }

    public partial interface HTMLSelectElement : HTMLElement, MSHTMLCollectionExtensions, MSDataBindingExtensions
    {
        object this[string name] { get; set; }

        int Length { get; set; }

        bool autofocus { get; set; }

        HTMLFormElement form { get; set; }

        bool multiple { get; set; }

        string name { get; set; }

        HTMLSelectElement options { get; set; }

        bool required { get; set; }

        int selectedIndex { get; set; }

        int size { get; set; }

        string type { get; set; }

        string validationMessage { get; set; }

        ValidityState validity { get; set; }

        string value { get; set; }

        bool willValidate { get; set; }

        void add(HTMLElement element, object before = null);

        bool checkValidity();

        object item(object name = null, object index = null);

        object namedItem(string name);

        void remove(int index = 0);

        void setCustomValidity(string error);
    }

    public partial interface TextRange
    {
        int boundingHeight { get; set; }

        int boundingLeft { get; set; }

        int boundingTop { get; set; }

        int boundingWidth { get; set; }

        string htmlText { get; set; }

        int offsetLeft { get; set; }

        int offsetTop { get; set; }

        string text { get; set; }

        void collapse(bool start = false);

        int compareEndPoints(string how, TextRange sourceRange);

        TextRange duplicate();

        bool execCommand(string cmdID, bool showUI = false, object value = null);

        bool execCommandShowHelp(string cmdID);

        bool expand(string Unit);

        bool findText(string _string, int count = 0, int flags = 0);

        string getBookmark();

        ClientRect getBoundingClientRect();

        ClientRectList getClientRects();

        bool inRange(TextRange range);

        bool isEqual(TextRange range);

        int move(string unit, int count = 0);

        int moveEnd(string unit, int count = 0);

        int moveStart(string unit, int count = 0);

        bool moveToBookmark(string bookmark);

        void moveToElementText(Element element);

        void moveToPoint(double x, double y);

        Element parentElement();

        void pasteHTML(string html);

        bool queryCommandEnabled(string cmdID);

        bool queryCommandIndeterm(string cmdID);

        bool queryCommandState(string cmdID);

        bool queryCommandSupported(string cmdID);

        string queryCommandText(string cmdID);

        object queryCommandValue(string cmdID);

        void scrollIntoView(bool fStart = false);

        void select();

        void setEndPoint(string how, TextRange SourceRange);
    }

    public partial interface SVGTests
    {
        SVGStringList requiredExtensions { get; set; }

        SVGStringList requiredFeatures { get; set; }

        SVGStringList systemLanguage { get; set; }

        bool hasExtension(string extension);
    }

    public partial interface HTMLBlockElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        string cite { get; set; }

        int width { get; set; }
    }

    public partial interface CSSStyleSheet : StyleSheet
    {
        CSSRuleList cssRules { get; set; }

        string cssText { get; set; }

        string id { get; set; }

        StyleSheetList imports { get; set; }

        bool isAlternate { get; set; }

        bool isPrefAlternate { get; set; }

        CSSRule ownerRule { get; set; }

        Element owningElement { get; set; }

        StyleSheetPageList pages { get; set; }

        bool readOnly { get; set; }

        MSCSSRuleList rules { get; set; }

        int addImport(string bstrURL, int lIndex = 0);

        int addPageRule(string bstrSelector, string bstrStyle, int lIndex = 0);

        int addRule(string bstrSelector, string bstrStyle = null, int lIndex = 0);

        void deleteRule(int index = 0);

        int insertRule(string rule, int index = 0);

        void removeImport(int lIndex);

        void removeRule(int lIndex);
    }

    public partial interface MSSelection
    {
        string type { get; set; }

        string typeDetail { get; set; }

        void clear();

        TextRange createRange();

        TextRangeCollection createRangeCollection();

        void empty();
    }

    public partial interface HTMLMetaElement : HTMLElement
    {
        string charset { get; set; }

        string content { get; set; }

        string httpEquiv { get; set; }

        string name { get; set; }

        string scheme { get; set; }

        string url { get; set; }
    }

    public partial interface SVGPatternElement : SVGElement,
                                                 SVGUnitTypes,
                                                 SVGStylable,
                                                 SVGLangSpace,
                                                 SVGTests,
                                                 SVGFitToViewBox,
                                                 SVGExternalResourcesRequired,
                                                 SVGURIReference
    {
        SVGAnimatedLength height { get; set; }

        SVGAnimatedEnumeration patternContentUnits { get; set; }

        SVGAnimatedTransformList patternTransform { get; set; }

        SVGAnimatedEnumeration patternUnits { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }
    }

    public partial interface SVGAnimatedAngle
    {
        SVGAngle animVal { get; set; }

        SVGAngle baseVal { get; set; }
    }

    public partial interface Selection
    {
        Node anchorNode { get; set; }

        int anchorOffset { get; set; }

        Node focusNode { get; set; }

        int focusOffset { get; set; }

        bool isCollapsed { get; set; }

        int rangeCount { get; set; }

        string ToString();

        void addRange(Range range);

        void collapse(Node parentNode, int offset);

        void collapseToEnd();

        void collapseToStart();

        void deleteFromDocument();

        Range getRangeAt(int index);

        void removeAllRanges();

        void removeRange(Range range);

        void selectAllChildren(Node parentNode);
    }

    public partial interface SVGScriptElement : SVGElement, SVGExternalResourcesRequired, SVGURIReference
    {
        string type { get; set; }
    }

    public partial interface HTMLDDElement : HTMLElement
    {
        bool noWrap { get; set; }
    }

    public partial interface MSDataBindingRecordSetReadonlyExtensions
    {
        object recordset { get; set; }

        object namedRecordset(string dataMember, object hierarchy = null);
    }

    public partial interface CSSStyleRule : CSSRule
    {
        bool readOnly { get; set; }

        string selectorText { get; set; }

        MSStyleCSSProperties style { get; set; }
    }

    public partial interface NodeIterator
    {
        bool expandEntityReferences { get; set; }

        NodeFilter filter { get; set; }

        Node root { get; set; }

        double whatToShow { get; set; }

        void detach();

        Node nextNode();

        Node previousNode();
    }

    public partial interface SVGViewElement : SVGElement, SVGZoomAndPan, SVGFitToViewBox, SVGExternalResourcesRequired
    {
        SVGStringList viewTarget { get; set; }
    }

    public partial interface HTMLLinkElement : HTMLElement, LinkStyle
    {
        string charset { get; set; }

        string href { get; set; }

        string hreflang { get; set; }

        string media { get; set; }

        string rel { get; set; }

        string rev { get; set; }

        string target { get; set; }

        string type { get; set; }
    }

    public partial interface SVGLocatable
    {
        SVGElement farthestViewportElement { get; set; }

        SVGElement nearestViewportElement { get; set; }

        SVGRect getBBox();

        SVGMatrix getCTM();

        SVGMatrix getScreenCTM();

        SVGMatrix getTransformToElement(SVGElement element);
    }

    public partial interface HTMLFontElement : HTMLElement, DOML2DeprecatedColorProperty, DOML2DeprecatedSizeProperty
    {
        string face { get; set; }
    }

    public partial interface SVGTitleElement : SVGElement, SVGStylable, SVGLangSpace
    {
    }

    public partial interface ControlRangeCollection
    {
        Element this[int index] { get; set; }

        int Length { get; set; }

        void add(Element item);

        void addElement(Element item);

        bool execCommand(string cmdID, bool showUI = false, object value = null);

        Element item(int index);

        bool queryCommandEnabled(string cmdID);

        bool queryCommandIndeterm(string cmdID);

        bool queryCommandState(string cmdID);

        bool queryCommandSupported(string cmdID);

        string queryCommandText(string cmdID);

        object queryCommandValue(string cmdID);

        void remove(int index);

        void scrollIntoView(object varargStart = null);

        void select();
    }

    public partial interface MSNamespaceInfo : MSEventAttachmentTarget
    {
        string name { get; set; }

        Func<Event, object> onreadystatechange { get; set; }

        string readyState { get; set; }

        string urn { get; set; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);

        void doImport(string implementationUrl);
    }

    public partial interface WindowSessionStorage
    {
        Storage sessionStorage { get; set; }
    }

    public partial interface SVGAnimatedTransformList
    {
        SVGTransformList animVal { get; set; }

        SVGTransformList baseVal { get; set; }
    }

    public partial interface HTMLTableCaptionElement : HTMLElement
    {
        string align { get; set; }

        string vAlign { get; set; }
    }

    public partial interface HTMLOptionElement : HTMLElement, MSDataBindingExtensions
    {
        bool defaultSelected { get; set; }

        HTMLFormElement form { get; set; }

        int index { get; set; }

        string label { get; set; }

        bool selected { get; set; }

        string text { get; set; }

        string value { get; set; }
    }

    public partial interface HTMLMapElement : HTMLElement
    {
        HTMLAreasCollection areas { get; set; }

        string name { get; set; }
    }

    public partial interface HTMLMenuElement : HTMLElement, DOML2DeprecatedListSpaceReduction
    {
        string type { get; set; }
    }

    public partial interface MouseWheelEvent : MouseEvent
    {
        double wheelDelta { get; set; }

        void initMouseWheelEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            int buttonArg,
            EventTarget relatedTargetArg,
            string modifiersListArg,
            double wheelDeltaArg);
    }

    public partial interface SVGFitToViewBox
    {
        SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; set; }

        SVGAnimatedRect viewBox { get; set; }
    }

    public partial interface SVGPointList
    {
        int numberOfItems { get; set; }

        SVGPoint appendItem(SVGPoint newItem);

        void clear();

        SVGPoint getItem(int index);

        SVGPoint initialize(SVGPoint newItem);

        SVGPoint insertItemBefore(SVGPoint newItem, int index);

        SVGPoint removeItem(int index);

        SVGPoint replaceItem(SVGPoint newItem, int index);
    }

    public partial interface SVGAnimatedLengthList
    {
        SVGLengthList animVal { get; set; }

        SVGLengthList baseVal { get; set; }
    }

    public partial interface SVGAnimatedPreserveAspectRatio
    {
        SVGPreserveAspectRatio animVal { get; set; }

        SVGPreserveAspectRatio baseVal { get; set; }
    }

    public partial interface MSSiteModeEvent : Event
    {
        string actionURL { get; set; }

        int buttonID { get; set; }
    }

    public partial interface DOML2DeprecatedTextFlowControl
    {
        string clear { get; set; }
    }

    public partial interface StyleSheetPageList
    {
        CSSPageRule this[int index] { get; set; }

        int Length { get; set; }

        CSSPageRule item(int index);
    }

    public partial interface MSCSSProperties : CSSStyleDeclaration
    {
        string accelerator { get; set; }

        string backgroundPositionX { get; set; }

        string backgroundPositionY { get; set; }

        string behavior { get; set; }

        string imeMode { get; set; }

        string layoutFlow { get; set; }

        string layoutGrid { get; set; }

        string layoutGridChar { get; set; }

        string layoutGridLine { get; set; }

        string layoutGridMode { get; set; }

        string layoutGridType { get; set; }

        string lineBreak { get; set; }

        string msBlockProgression { get; set; }

        string msInterpolationMode { get; set; }

        string scrollbar3dLightColor { get; set; }

        string scrollbarArrowColor { get; set; }

        string scrollbarBaseColor { get; set; }

        string scrollbarDarkShadowColor { get; set; }

        string scrollbarFaceColor { get; set; }

        string scrollbarHighlightColor { get; set; }

        string scrollbarShadowColor { get; set; }

        string scrollbarTrackColor { get; set; }

        string styleFloat { get; set; }

        string textAutospace { get; set; }

        string textJustifyTrim { get; set; }

        string textKashida { get; set; }

        string textKashidaSpace { get; set; }

        string writingMode { get; set; }

        string zoom { get; set; }

        object getAttribute(string attributeName, int flags = 0);

        bool removeAttribute(string attributeName, int flags = 0);

        void setAttribute(string attributeName, object AttributeValue, int flags = 0);
    }

    public partial interface HTMLCollection : MSHTMLCollectionExtensions
    {
        int Length { get; set; }

        Element item(object nameOrIndex = null, object optionalIndex = null);

        Element namedItem(string name);
    }

    public partial interface SVGExternalResourcesRequired
    {
        SVGAnimatedBoolean externalResourcesRequired { get; set; }
    }

    public partial interface HTMLImageElement : HTMLElement, MSImageResourceExtensions, MSDataBindingExtensions, MSResourceMetadata
    {
        string align { get; set; }

        string alt { get; set; }

        string border { get; set; }

        bool complete { get; set; }

        string crossOrigin { get; set; }

        int height { get; set; }

        string href { get; set; }

        int hspace { get; set; }

        bool isMap { get; set; }

        string longDesc { get; set; }

        bool msPlayToDisabled { get; set; }

        string msPlayToPreferredSourceUri { get; set; }

        bool msPlayToPrimary { get; set; }

        object msPlayToSource { get; set; }

        string name { get; set; }

        int naturalHeight { get; set; }

        int naturalWidth { get; set; }

        string src { get; set; }

        string useMap { get; set; }

        int vspace { get; set; }

        int width { get; set; }
    }

    public partial interface HTMLAreaElement : HTMLElement
    {
        string alt { get; set; }

        string coords { get; set; }

        string hash { get; set; }

        string host { get; set; }

        string hostname { get; set; }

        string href { get; set; }

        bool noHref { get; set; }

        string pathname { get; set; }

        string port { get; set; }

        string protocol { get; set; }

        string search { get; set; }

        string shape { get; set; }

        string target { get; set; }

        string ToString();
    }

    public partial interface EventTarget
    {
        void addEventListener(string type, EventListener listener, bool useCapture = false);

        bool dispatchEvent(Event evt);

        void removeEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGAngle
    {
        int SVG_ANGLETYPE_DEG { get; set; }

        int SVG_ANGLETYPE_GRAD { get; set; }

        int SVG_ANGLETYPE_RAD { get; set; }

        int SVG_ANGLETYPE_UNKNOWN { get; set; }

        int SVG_ANGLETYPE_UNSPECIFIED { get; set; }

        int unitType { get; set; }

        int value { get; set; }

        string valueAsString { get; set; }

        int valueInSpecifiedUnits { get; set; }

        void convertToSpecifiedUnits(int unitType);

        void newValueSpecifiedUnits(int unitType, int valueInSpecifiedUnits);
    }

    public partial interface HTMLButtonElement : HTMLElement, MSDataBindingExtensions
    {
        bool autofocus { get; set; }

        HTMLFormElement form { get; set; }

        string formAction { get; set; }

        string formEnctype { get; set; }

        string formMethod { get; set; }

        string formNoValidate { get; set; }

        string formTarget { get; set; }

        string name { get; set; }

        object status { get; set; }

        string type { get; set; }

        string validationMessage { get; set; }

        ValidityState validity { get; set; }

        string value { get; set; }

        bool willValidate { get; set; }

        bool checkValidity();

        TextRange createTextRange();

        void setCustomValidity(string error);
    }

    public partial interface HTMLSourceElement : HTMLElement
    {
        string media { get; set; }

        string msKeySystem { get; set; }

        string src { get; set; }

        string type { get; set; }
    }

    public partial interface CanvasGradient
    {
        void addColorStop(int offset, string color);
    }

    public partial interface KeyboardEvent : UIEvent
    {
        int DOM_KEY_LOCATION_JOYSTICK { get; set; }

        int DOM_KEY_LOCATION_LEFT { get; set; }

        int DOM_KEY_LOCATION_MOBILE { get; set; }

        int DOM_KEY_LOCATION_NUMPAD { get; set; }

        int DOM_KEY_LOCATION_RIGHT { get; set; }

        int DOM_KEY_LOCATION_STANDARD { get; set; }

        string _char { get; set; }

        bool altKey { get; set; }

        int charCode { get; set; }

        bool ctrlKey { get; set; }

        string key { get; set; }

        int keyCode { get; set; }

        string locale { get; set; }

        int location { get; set; }

        bool metaKey { get; set; }

        bool repeat { get; set; }

        bool shiftKey { get; set; }

        double which { get; set; }

        bool getModifierState(string keyArg);

        void initKeyboardEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            string keyArg,
            int locationArg,
            string modifiersListArg,
            bool repeat,
            string locale);
    }

    public partial interface MessageEvent : Event
    {
        object data { get; set; }

        string origin { get; set; }

        object ports { get; set; }

        Window source { get; set; }

        void initMessageEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object dataArg, string originArg, string lastEventIdArg, Window sourceArg);
    }

    public partial interface SVGElement : Element
    {
        string id { get; set; }

        Func<MouseEvent, object> onclick { get; set; }

        Func<MouseEvent, object> ondblclick { get; set; }

        Func<FocusEvent, object> onfocusin { get; set; }

        Func<FocusEvent, object> onfocusout { get; set; }

        Func<Event, object> onload { get; set; }

        Func<MouseEvent, object> onmousedown { get; set; }

        Func<MouseEvent, object> onmousemove { get; set; }

        Func<MouseEvent, object> onmouseout { get; set; }

        Func<MouseEvent, object> onmouseover { get; set; }

        Func<MouseEvent, object> onmouseup { get; set; }

        SVGSVGElement ownerSVGElement { get; set; }

        SVGElement viewportElement { get; set; }

        string xmlbase { get; set; }
    }

    public partial interface HTMLScriptElement : HTMLElement
    {
        string _event { get; set; }

        bool async { get; set; }

        string charset { get; set; }

        bool defer { get; set; }

        string htmlFor { get; set; }

        string src { get; set; }

        string text { get; set; }

        string type { get; set; }
    }

    public partial interface HTMLTableRowElement : HTMLElement, HTMLTableAlignment, DOML2DeprecatedBackgroundColorStyle
    {
        string align { get; set; }

        object borderColor { get; set; }

        object borderColorDark { get; set; }

        object borderColorLight { get; set; }

        HTMLCollection cells { get; set; }

        object height { get; set; }

        int rowIndex { get; set; }

        int sectionRowIndex { get; set; }

        void deleteCell(int index = 0);

        HTMLElement insertCell(int index = 0);
    }

    public partial interface CanvasRenderingContext2D
    {
        HTMLCanvasElement canvas { get; set; }

        object fillStyle { get; set; }

        string font { get; set; }

        int globalAlpha { get; set; }

        string globalCompositeOperation { get; set; }

        string lineCap { get; set; }

        int lineDashOffset { get; set; }

        string lineJoin { get; set; }

        int lineWidth { get; set; }

        int miterLimit { get; set; }

        string msFillRule { get; set; }

        bool msImageSmoothingEnabled { get; set; }

        int shadowBlur { get; set; }

        string shadowColor { get; set; }

        int shadowOffsetX { get; set; }

        int shadowOffsetY { get; set; }

        object strokeStyle { get; set; }

        string textAlign { get; set; }

        string textBaseline { get; set; }

        void arc(double x, double y, int radius, int startAngle, int endAngle, bool anticlockwise = false);

        void arcTo(double x1, double y1, double x2, double y2, int radius);

        void beginPath();

        void bezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, double x, double y);

        void clearRect(double x, double y, double w, int h);

        void clip(string fillRule = null);

        void closePath();

        ImageData createImageData(object imageDataOrSw, int sh = 0);

        CanvasGradient createLinearGradient(double x0, double y0, double x1, double y1);

        CanvasPattern createPattern(HTMLElement image, string repetition);

        CanvasGradient createRadialGradient(double x0, double y0, int r0, double x1, double y1, int r1);

        void drawImage(
            HTMLElement image,
            int offsetX,
            int offsetY,
            int width = 0,
            int height = 0,
            int canvasOffsetX = 0,
            int canvasOffsetY = 0,
            int canvasImageWidth = 0,
            int canvasImageHeight = 0);

        void fill(string fillRule = null);

        void fillRect(double x, double y, double w, int h);

        void fillText(string text, double x, double y, int maxWidth = 0);

        ImageData getImageData(int sx, int sy, int sw, int sh);

        float[] getLineDash();

        bool isPointInPath(double x, double y, string fillRule = null);

        void lineTo(double x, double y);

        TextMetrics measureText(string text);

        void moveTo(double x, double y);

        void putImageData(ImageData imagedata, int dx, int dy, int dirtyX = 0, int dirtyY = 0, int dirtyWidth = 0, int dirtyHeight = 0);

        void quadraticCurveTo(int cpx, int cpy, double x, double y);

        void rect(double x, double y, double w, int h);

        void restore();

        void rotate(int angle);

        void save();

        void scale(double x, double y);

        void setLineDash(float[] segments);

        void setTransform(int m11, int m12, int m21, int m22, int dx, int dy);

        void stroke();

        void strokeRect(double x, double y, double w, int h);

        void strokeText(string text, double x, double y, int maxWidth = 0);

        void transform(int m11, int m12, int m21, int m22, int dx, int dy);

        void translate(double x, double y);
    }

    public partial interface MSCSSRuleList
    {
        CSSStyleRule this[int index] { get; set; }

        int Length { get; set; }

        CSSStyleRule item(int index = 0);
    }

    public partial interface SVGPathSegLinetoHorizontalAbs : SVGPathSeg
    {
        double x { get; set; }
    }

    public partial interface SVGPathSegArcAbs : SVGPathSeg
    {
        int angle { get; set; }

        bool largeArcFlag { get; set; }

        int r1 { get; set; }

        int r2 { get; set; }

        bool sweepFlag { get; set; }

        double x { get; set; }

        double y { get; set; }
    }

    public partial interface SVGTransformList
    {
        int numberOfItems { get; set; }

        SVGTransform appendItem(SVGTransform newItem);

        void clear();

        SVGTransform consolidate();

        SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix);

        SVGTransform getItem(int index);

        SVGTransform initialize(SVGTransform newItem);

        SVGTransform insertItemBefore(SVGTransform newItem, int index);

        SVGTransform removeItem(int index);

        SVGTransform replaceItem(SVGTransform newItem, int index);
    }

    public partial interface HTMLHtmlElement : HTMLElement
    {
        string version { get; set; }
    }

    public partial interface SVGPathSegClosePath : SVGPathSeg
    {
    }

    public partial interface HTMLFrameElement : HTMLElement, GetSVGDocument, MSDataBindingExtensions
    {
        string border { get; set; }

        object borderColor { get; set; }

        Document contentDocument { get; set; }

        Window contentWindow { get; set; }

        string frameBorder { get; set; }

        object frameSpacing { get; set; }

        object height { get; set; }

        string longDesc { get; set; }

        string marginHeight { get; set; }

        string marginWidth { get; set; }

        string name { get; set; }

        bool noResize { get; set; }

        string scrolling { get; set; }

        object security { get; set; }

        string src { get; set; }

        object width { get; set; }
    }

    public partial interface SVGAnimatedLength
    {
        SVGLength animVal { get; set; }

        SVGLength baseVal { get; set; }
    }

    public partial interface SVGAnimatedPoints
    {
        SVGPointList animatedPoints { get; set; }

        SVGPointList points { get; set; }
    }

    public partial interface SVGDefsElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
    }

    public partial interface HTMLQuoteElement : HTMLElement
    {
        string cite { get; set; }

        string dateTime { get; set; }
    }

    public partial interface CSSMediaRule : CSSRule
    {
        CSSRuleList cssRules { get; set; }

        MediaList media { get; set; }

        void deleteRule(int index = 0);

        int insertRule(string rule, int index = 0);
    }

    public partial interface WindowModal
    {
        object dialogArguments { get; set; }

        object returnValue { get; set; }
    }

    public partial interface XMLHttpRequest : EventTarget
    {
        int DONE { get; set; }

        int HEADERS_RECEIVED { get; set; }

        int LOADING { get; set; }

        int OPENED { get; set; }

        int UNSENT { get; set; }

        string msCaching { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onload { get; set; }

        Func<ProgressEvent, object> onloadend { get; set; }

        Func<Event, object> onloadstart { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<Event, object> onreadystatechange { get; set; }

        Func<Event, object> ontimeout { get; set; }

        int readyState { get; set; }

        object response { get; set; }

        object responseBody { get; set; }

        string responseText { get; set; }

        string responseType { get; set; }

        object responseXML { get; set; }

        int status { get; set; }

        string statusText { get; set; }

        int timeout { get; set; }

        XMLHttpRequestEventTarget upload { get; set; }

        bool withCredentials { get; set; }

        void abort();

        string getAllResponseHeaders();

        string getResponseHeader(string header);

        bool msCachingEnabled();

        void open(string method, string url, bool async = false, string user = null, string password = null);

        void overrideMimeType(string mime);

        void send(object data = null);

        void setRequestHeader(string header, string value);
    }

    public partial interface HTMLTableHeaderCellElement : HTMLTableCellElement
    {
    }

    public partial interface HTMLDListElement : HTMLElement, DOML2DeprecatedListSpaceReduction
    {
    }

    public partial interface MSDataBindingExtensions
    {
        string dataFld { get; set; }

        string dataFormatAs { get; set; }

        string dataSrc { get; set; }
    }

    public partial interface SVGPathSegLinetoHorizontalRel : SVGPathSeg
    {
        double x { get; set; }
    }

    public partial interface SVGEllipseElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength cx { get; set; }

        SVGAnimatedLength cy { get; set; }

        SVGAnimatedLength rx { get; set; }

        SVGAnimatedLength ry { get; set; }
    }

    public partial interface SVGAElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedString target { get; set; }
    }

    public partial interface SVGStylable
    {
        SVGAnimatedString className { get; set; }

        CSSStyleDeclaration style { get; set; }
    }

    public partial interface SVGTransformable : SVGLocatable
    {
        SVGAnimatedTransformList transform { get; set; }
    }

    public partial interface HTMLFrameSetElement : HTMLElement
    {
        string border { get; set; }

        object borderColor { get; set; }

        string cols { get; set; }

        string frameBorder { get; set; }

        object frameSpacing { get; set; }

        string name { get; set; }

        Func<Event, object> onafterprint { get; set; }

        Func<Event, object> onbeforeprint { get; set; }

        Func<BeforeUnloadEvent, object> onbeforeunload { get; set; }

        Func<Event, object> onhashchange { get; set; }

        Func<MessageEvent, object> onmessage { get; set; }

        Func<Event, object> onoffline { get; set; }

        Func<Event, object> ononline { get; set; }

        Func<PageTransitionEvent, object> onpagehide { get; set; }

        Func<PageTransitionEvent, object> onpageshow { get; set; }

        Func<StorageEvent, object> onstorage { get; set; }

        Func<Event, object> onunload { get; set; }

        string rows { get; set; }
    }

    public partial interface Screen : EventTarget
    {
        int availHeight { get; set; }

        int availWidth { get; set; }

        int bufferDepth { get; set; }

        int colorDepth { get; set; }

        int deviceXDPI { get; set; }

        int deviceYDPI { get; set; }

        bool fontSmoothingEnabled { get; set; }

        int height { get; set; }

        int logicalXDPI { get; set; }

        int logicalYDPI { get; set; }

        string msOrientation { get; set; }

        Func<object, object> onmsorientationchange { get; set; }

        int pixelDepth { get; set; }

        int systemXDPI { get; set; }

        int systemYDPI { get; set; }

        int updateInterval { get; set; }

        int width { get; set; }

        bool msLockOrientation(string orientation);

        bool msLockOrientation(Array<string> orientations);

        void msUnlockOrientation();
    }

    public partial interface Coordinates
    {
        int accuracy { get; set; }

        int altitude { get; set; }

        int altitudeAccuracy { get; set; }

        int heading { get; set; }

        int latitude { get; set; }

        int longitude { get; set; }

        int speed { get; set; }
    }

    public partial interface NavigatorGeolocation
    {
        Geolocation geolocation { get; set; }
    }

    public partial interface NavigatorContentUtils
    {
    }

    public delegate void EventListener(Event evt);

    public partial interface SVGLangSpace
    {
        string xmllang { get; set; }

        string xmlspace { get; set; }
    }

    public partial interface DataTransfer
    {
        string dropEffect { get; set; }

        string effectAllowed { get; set; }

        FileList files { get; set; }

        DOMStringList types { get; set; }

        bool clearData(string format = null);

        string getData(string format);

        bool setData(string format, string data);
    }

    public partial interface FocusEvent : UIEvent
    {
        EventTarget relatedTarget { get; set; }

        void initFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, EventTarget relatedTargetArg);
    }

    public partial interface Range
    {
        int END_TO_END { get; set; }

        int END_TO_START { get; set; }

        int START_TO_END { get; set; }

        int START_TO_START { get; set; }

        bool collapsed { get; set; }

        Node commonAncestorContainer { get; set; }

        Node endContainer { get; set; }

        int endOffset { get; set; }

        Node startContainer { get; set; }

        int startOffset { get; set; }

        string ToString();

        DocumentFragment cloneContents();

        Range cloneRange();

        void collapse(bool toStart);

        int compareBoundaryPoints(int how, Range sourceRange);

        DocumentFragment createContextualFragment(string fragment);

        void deleteContents();

        void detach();

        DocumentFragment extractContents();

        ClientRect getBoundingClientRect();

        ClientRectList getClientRects();

        void insertNode(Node newNode);

        void selectNode(Node refNode);

        void selectNodeContents(Node refNode);

        void setEnd(Node refNode, int offset);

        void setEndAfter(Node refNode);

        void setEndBefore(Node refNode);

        void setStart(Node refNode, int offset);

        void setStartAfter(Node refNode);

        void setStartBefore(Node refNode);

        void surroundContents(Node newParent);
    }

    public partial interface SVGPoint
    {
        double x { get; set; }

        double y { get; set; }

        SVGPoint matrixTransform(SVGMatrix matrix);
    }

    public partial interface MSPluginsCollection
    {
        int Length { get; set; }

        void refresh(bool reload = false);
    }

    public partial interface SVGAnimatedNumberList
    {
        SVGNumberList animVal { get; set; }

        SVGNumberList baseVal { get; set; }
    }

    public partial interface SVGSVGElement : SVGElement,
                                             SVGStylable,
                                             SVGZoomAndPan,
                                             DocumentEvent,
                                             SVGLangSpace,
                                             SVGLocatable,
                                             SVGTests,
                                             SVGFitToViewBox,
                                             SVGExternalResourcesRequired
    {
        string contentScriptType { get; set; }

        string contentStyleType { get; set; }

        int currentScale { get; set; }

        SVGPoint currentTranslate { get; set; }

        SVGAnimatedLength height { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<UIEvent, object> onresize { get; set; }

        Func<UIEvent, object> onscroll { get; set; }

        Func<Event, object> onunload { get; set; }

        Func<object, object> onzoom { get; set; }

        int pixelUnitToMillimeterX { get; set; }

        int pixelUnitToMillimeterY { get; set; }

        int screenPixelToMillimeterX { get; set; }

        int screenPixelToMillimeterY { get; set; }

        SVGRect viewport { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }

        bool checkEnclosure(SVGElement element, SVGRect rect);

        bool checkIntersection(SVGElement element, SVGRect rect);

        SVGAngle createSVGAngle();

        SVGLength createSVGLength();

        SVGMatrix createSVGMatrix();

        SVGNumber createSVGNumber();

        SVGPoint createSVGPoint();

        SVGRect createSVGRect();

        SVGTransform createSVGTransform();

        SVGTransform createSVGTransformFromMatrix(SVGMatrix matrix);

        void deselectAll();

        void forceRedraw();

        CSSStyleDeclaration getComputedStyle(Element elt, string pseudoElt = null);

        int getCurrentTime();

        Element getElementById(string elementId);

        NodeList getEnclosureList(SVGRect rect, SVGElement referenceElement);

        NodeList getIntersectionList(SVGRect rect, SVGElement referenceElement);

        void pauseAnimations();

        void setCurrentTime(int seconds);

        int suspendRedraw(int maxWaitMilliseconds);

        void unpauseAnimations();

        void unsuspendRedraw(int suspendHandleID);

        void unsuspendRedrawAll();
    }

    public partial interface HTMLLabelElement : HTMLElement, MSDataBindingExtensions
    {
        HTMLFormElement form { get; set; }

        string htmlFor { get; set; }
    }

    public partial interface MSResourceMetadata
    {
        string fileCreatedDate { get; set; }

        string fileModifiedDate { get; set; }

        string fileSize { get; set; }

        string fileUpdatedDate { get; set; }

        string mimeType { get; set; }

        string nameProp { get; set; }

        string protocol { get; set; }
    }

    public partial interface HTMLLegendElement : HTMLElement, MSDataBindingExtensions
    {
        string align { get; set; }

        HTMLFormElement form { get; set; }
    }

    public partial interface HTMLDirectoryElement : HTMLElement, DOML2DeprecatedListSpaceReduction, DOML2DeprecatedListNumberingAndBulletStyle
    {
    }

    public partial interface SVGAnimatedInteger
    {
        int animVal { get; set; }

        int baseVal { get; set; }
    }

    public partial interface SVGTextElement : SVGTextPositioningElement, SVGTransformable
    {
    }

    public partial interface SVGTSpanElement : SVGTextPositioningElement
    {
    }

    public partial interface HTMLLIElement : HTMLElement, DOML2DeprecatedListNumberingAndBulletStyle
    {
        int value { get; set; }
    }

    public partial interface SVGPathSegLinetoVerticalAbs : SVGPathSeg
    {
        double y { get; set; }
    }

    public partial interface MSStorageExtensions
    {
        int remainingSpace { get; set; }
    }

    public partial interface SVGStyleElement : SVGElement, SVGLangSpace
    {
        string media { get; set; }

        string title { get; set; }

        string type { get; set; }
    }

    public partial interface MSCurrentStyleCSSProperties : MSCSSProperties
    {
        string blockDirection { get; set; }

        string clipBottom { get; set; }

        string clipLeft { get; set; }

        string clipRight { get; set; }

        string clipTop { get; set; }

        string hasLayout { get; set; }
    }

    public partial interface MSHTMLCollectionExtensions
    {
        object tags(object tagName);

        object urns(object urn);
    }

    public partial interface Storage : MSStorageExtensions
    {
        object this[string key] { get; set; }

        string this[int index] { get; set; }

        int Length { get; set; }

        void clear();

        object getItem(string key);

        string key(int index);

        void removeItem(string key);

        void setItem(string key, string data);
    }

    public partial interface HTMLIFrameElement : HTMLElement, GetSVGDocument, MSDataBindingExtensions
    {
        string align { get; set; }

        string border { get; set; }

        Document contentDocument { get; set; }

        Window contentWindow { get; set; }

        string frameBorder { get; set; }

        object frameSpacing { get; set; }

        string height { get; set; }

        int hspace { get; set; }

        string longDesc { get; set; }

        string marginHeight { get; set; }

        string marginWidth { get; set; }

        string name { get; set; }

        bool noResize { get; set; }

        DOMSettableTokenList sandbox { get; set; }

        string scrolling { get; set; }

        object security { get; set; }

        string src { get; set; }

        int vspace { get; set; }

        string width { get; set; }
    }

    public partial interface TextRangeCollection
    {
        TextRange this[int index] { get; set; }

        int Length { get; set; }

        TextRange item(int index);
    }

    public partial interface HTMLBodyElement : HTMLElement, DOML2DeprecatedBackgroundStyle, DOML2DeprecatedBackgroundColorStyle
    {
        object aLink { get; set; }

        string bgProperties { get; set; }

        object bottomMargin { get; set; }

        object leftMargin { get; set; }

        object link { get; set; }

        bool noWrap { get; set; }

        Func<Event, object> onafterprint { get; set; }

        Func<Event, object> onbeforeprint { get; set; }

        Func<BeforeUnloadEvent, object> onbeforeunload { get; set; }

        Func<Event, object> onhashchange { get; set; }

        Func<MessageEvent, object> onmessage { get; set; }

        Func<Event, object> onoffline { get; set; }

        Func<Event, object> ononline { get; set; }

        Func<PageTransitionEvent, object> onpagehide { get; set; }

        Func<PageTransitionEvent, object> onpageshow { get; set; }

        Func<PopStateEvent, object> onpopstate { get; set; }

        Func<StorageEvent, object> onstorage { get; set; }

        Func<Event, object> onunload { get; set; }

        object rightMargin { get; set; }

        string scroll { get; set; }

        object text { get; set; }

        object topMargin { get; set; }

        object vLink { get; set; }

        TextRange createTextRange();
    }

    public partial interface DocumentType : Node
    {
        NamedNodeMap entities { get; set; }

        string internalSubset { get; set; }

        string name { get; set; }

        NamedNodeMap notations { get; set; }

        string publicId { get; set; }

        string systemId { get; set; }
    }

    public partial interface SVGRadialGradientElement : SVGGradientElement
    {
        SVGAnimatedLength cx { get; set; }

        SVGAnimatedLength cy { get; set; }

        SVGAnimatedLength fx { get; set; }

        SVGAnimatedLength fy { get; set; }

        SVGAnimatedLength r { get; set; }
    }

    public partial interface MutationEvent : Event
    {
        int ADDITION { get; set; }

        int MODIFICATION { get; set; }

        int REMOVAL { get; set; }

        int attrChange { get; set; }

        string attrName { get; set; }

        string newValue { get; set; }

        string prevValue { get; set; }

        Node relatedNode { get; set; }

        void initMutationEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Node relatedNodeArg,
            string prevValueArg,
            string newValueArg,
            string attrNameArg,
            int attrChangeArg);
    }

    public partial interface DragEvent : MouseEvent
    {
        DataTransfer dataTransfer { get; set; }

        void initDragEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            int buttonArg,
            EventTarget relatedTargetArg,
            DataTransfer dataTransferArg);

        void msConvertURL(File file, string targetType, string targetURL = null);
    }

    public partial interface HTMLTableSectionElement : HTMLElement, HTMLTableAlignment, DOML2DeprecatedBackgroundColorStyle
    {
        string align { get; set; }

        HTMLCollection rows { get; set; }

        void deleteRow(int index = 0);

        HTMLElement insertRow(int index = 0);

        object moveRow(int indexFrom = 0, int indexTo = 0);
    }

    public partial interface DOML2DeprecatedListNumberingAndBulletStyle
    {
        string type { get; set; }
    }

    public partial interface HTMLInputElement : HTMLElement, MSDataBindingExtensions
    {
        string Max { get; set; }

        bool _checked { get; set; }

        string accept { get; set; }

        string align { get; set; }

        string alt { get; set; }

        string autocomplete { get; set; }

        bool autofocus { get; set; }

        string border { get; set; }

        bool complete { get; set; }

        bool defaultChecked { get; set; }

        string defaultValue { get; set; }

        string dynsrc { get; set; }

        FileList files { get; set; }

        HTMLFormElement form { get; set; }

        string formAction { get; set; }

        string formEnctype { get; set; }

        string formMethod { get; set; }

        string formNoValidate { get; set; }

        string formTarget { get; set; }

        string height { get; set; }

        int hspace { get; set; }

        bool indeterminate { get; set; }

        HTMLElement list { get; set; }

        int loop { get; set; }

        string lowsrc { get; set; }

        int maxLength { get; set; }

        string min { get; set; }

        bool multiple { get; set; }

        string name { get; set; }

        string pattern { get; set; }

        string placeholder { get; set; }

        bool readOnly { get; set; }

        bool required { get; set; }

        int selectionEnd { get; set; }

        int selectionStart { get; set; }

        int size { get; set; }

        string src { get; set; }

        string start { get; set; }

        bool status { get; set; }

        string step { get; set; }

        string type { get; set; }

        string useMap { get; set; }

        string validationMessage { get; set; }

        ValidityState validity { get; set; }

        string value { get; set; }

        int valueAsNumber { get; set; }

        string vrml { get; set; }

        int vspace { get; set; }

        string width { get; set; }

        bool willValidate { get; set; }

        bool checkValidity();

        TextRange createTextRange();

        void select();

        void setCustomValidity(string error);

        void setSelectionRange(int start, int end);

        void stepDown(int n = 0);

        void stepUp(int n = 0);
    }

    public partial interface HTMLAnchorElement : HTMLElement, MSDataBindingExtensions
    {
        string Methods { get; set; }

        string charset { get; set; }

        string coords { get; set; }

        string hash { get; set; }

        string host { get; set; }

        string hostname { get; set; }

        string href { get; set; }

        string hreflang { get; set; }

        string mimeType { get; set; }

        string name { get; set; }

        string nameProp { get; set; }

        string pathname { get; set; }

        string port { get; set; }

        string protocol { get; set; }

        string protocolLong { get; set; }

        string rel { get; set; }

        string rev { get; set; }

        string search { get; set; }

        string shape { get; set; }

        string target { get; set; }

        string text { get; set; }

        string type { get; set; }

        string urn { get; set; }

        string ToString();
    }

    public partial interface HTMLParamElement : HTMLElement
    {
        string name { get; set; }

        string type { get; set; }

        string value { get; set; }

        string valueType { get; set; }
    }

    public partial interface SVGImageElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGAnimatedLength height { get; set; }

        SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }
    }

    public partial interface SVGAnimatedNumber
    {
        int animVal { get; set; }

        int baseVal { get; set; }
    }

    public partial interface PerformanceTiming
    {
        int connectEnd { get; set; }

        int connectStart { get; set; }

        int domComplete { get; set; }

        int domContentLoadedEventEnd { get; set; }

        int domContentLoadedEventStart { get; set; }

        int domInteractive { get; set; }

        int domLoading { get; set; }

        int domainLookupEnd { get; set; }

        int domainLookupStart { get; set; }

        int fetchStart { get; set; }

        int loadEventEnd { get; set; }

        int loadEventStart { get; set; }

        int msFirstPaint { get; set; }

        int navigationStart { get; set; }

        int redirectEnd { get; set; }

        int redirectStart { get; set; }

        int requestStart { get; set; }

        int responseEnd { get; set; }

        int responseStart { get; set; }

        int unloadEventEnd { get; set; }

        int unloadEventStart { get; set; }

        object toJSON();
    }

    public partial interface HTMLPreElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        string cite { get; set; }

        int width { get; set; }
    }

    public partial interface EventException
    {
        int DISPATCH_REQUEST_ERR { get; set; }

        int UNSPECIFIED_EVENT_TYPE_ERR { get; set; }

        int code { get; set; }

        string message { get; set; }

        string name { get; set; }

        string ToString();
    }

    public partial interface MSNavigatorDoNotTrack
    {
        string msDoNotTrack { get; set; }

        bool confirmSiteSpecificTrackingException(ConfirmSiteSpecificExceptionsInformation args);

        bool confirmWebWideTrackingException(ExceptionInformation args);

        void removeSiteSpecificTrackingException(ExceptionInformation args);

        void removeWebWideTrackingException(ExceptionInformation args);

        void storeSiteSpecificTrackingException(StoreSiteSpecificExceptionsInformation args);

        void storeWebWideTrackingException(StoreExceptionsInformation args);
    }

    public partial interface NavigatorOnLine
    {
        bool onLine { get; set; }
    }

    public partial interface WindowLocalStorage
    {
        Storage localStorage { get; set; }
    }

    public partial interface SVGMetadataElement : SVGElement
    {
    }

    public partial interface SVGPathSegArcRel : SVGPathSeg
    {
        int angle { get; set; }

        bool largeArcFlag { get; set; }

        int r1 { get; set; }

        int r2 { get; set; }

        bool sweepFlag { get; set; }

        double x { get; set; }

        double y { get; set; }
    }

    public partial interface SVGPathSegMovetoAbs : SVGPathSeg
    {
        double x { get; set; }

        double y { get; set; }
    }

    public partial interface SVGStringList
    {
        int numberOfItems { get; set; }

        string appendItem(string newItem);

        void clear();

        string getItem(int index);

        string initialize(string newItem);

        string insertItemBefore(string newItem, int index);

        string removeItem(int index);

        string replaceItem(string newItem, int index);
    }

    public partial interface XDomainRequest
    {
        string contentType { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onload { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<Event, object> ontimeout { get; set; }

        string responseText { get; set; }

        int timeout { get; set; }

        void abort();

        void addEventListener(string type, EventListener listener, bool useCapture = false);

        void open(string method, string url);

        void send(object data = null);
    }

    public partial interface DOML2DeprecatedBackgroundColorStyle
    {
        object bgColor { get; set; }
    }

    public partial interface ElementTraversal
    {
        int childElementCount { get; set; }

        Element firstElementChild { get; set; }

        Element lastElementChild { get; set; }

        Element nextElementSibling { get; set; }

        Element previousElementSibling { get; set; }
    }

    public partial interface SVGLength
    {
        int SVG_LENGTHTYPE_CM { get; set; }

        int SVG_LENGTHTYPE_EMS { get; set; }

        int SVG_LENGTHTYPE_EXS { get; set; }

        int SVG_LENGTHTYPE_IN { get; set; }

        int SVG_LENGTHTYPE_MM { get; set; }

        int SVG_LENGTHTYPE_NUMBER { get; set; }

        int SVG_LENGTHTYPE_PC { get; set; }

        int SVG_LENGTHTYPE_PERCENTAGE { get; set; }

        int SVG_LENGTHTYPE_PT { get; set; }

        int SVG_LENGTHTYPE_PX { get; set; }

        int SVG_LENGTHTYPE_UNKNOWN { get; set; }

        int unitType { get; set; }

        int value { get; set; }

        string valueAsString { get; set; }

        int valueInSpecifiedUnits { get; set; }

        void convertToSpecifiedUnits(int unitType);

        void newValueSpecifiedUnits(int unitType, int valueInSpecifiedUnits);
    }

    public partial interface SVGPolygonElement : SVGElement,
                                                 SVGStylable,
                                                 SVGTransformable,
                                                 SVGLangSpace,
                                                 SVGAnimatedPoints,
                                                 SVGTests,
                                                 SVGExternalResourcesRequired
    {
    }

    public partial interface HTMLPhraseElement : HTMLElement
    {
        string cite { get; set; }

        string dateTime { get; set; }
    }

    public partial interface NavigatorStorageUtils
    {
    }

    public partial interface SVGPathSegCurvetoCubicRel : SVGPathSeg
    {
        double x { get; set; }

        double x1 { get; set; }

        double x2 { get; set; }

        double y { get; set; }

        double y1 { get; set; }

        double y2 { get; set; }
    }

    public partial interface SVGTextContentElement : SVGElement, SVGStylable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        int LENGTHADJUST_SPACING { get; set; }

        int LENGTHADJUST_SPACINGANDGLYPHS { get; set; }

        int LENGTHADJUST_UNKNOWN { get; set; }

        SVGAnimatedEnumeration lengthAdjust { get; set; }

        SVGAnimatedLength textLength { get; set; }

        int getCharNumAtPosition(SVGPoint point);

        int getComputedTextLength();

        SVGPoint getEndPositionOfChar(int charnum);

        SVGRect getExtentOfChar(int charnum);

        int getNumberOfChars();

        int getRotationOfChar(int charnum);

        SVGPoint getStartPositionOfChar(int charnum);

        int getSubStringLength(int charnum, int nchars);

        void selectSubString(int charnum, int nchars);
    }

    public partial interface DOML2DeprecatedColorProperty
    {
        string color { get; set; }
    }

    public partial interface Location
    {
        string hash { get; set; }

        string host { get; set; }

        string hostname { get; set; }

        string href { get; set; }

        string pathname { get; set; }

        string port { get; set; }

        string protocol { get; set; }

        string search { get; set; }

        string ToString();

        void assign(string url);

        void reload(bool flag = false);

        void replace(string url);
    }

    public partial interface HTMLTitleElement : HTMLElement
    {
        string text { get; set; }
    }

    public partial interface HTMLStyleElement : HTMLElement, LinkStyle
    {
        string media { get; set; }

        string type { get; set; }
    }

    public partial interface PerformanceEntry
    {
        int duration { get; set; }

        string entryType { get; set; }

        string name { get; set; }

        int startTime { get; set; }
    }

    public partial interface SVGTransform
    {
        int SVG_TRANSFORM_MATRIX { get; set; }

        int SVG_TRANSFORM_ROTATE { get; set; }

        int SVG_TRANSFORM_SCALE { get; set; }

        int SVG_TRANSFORM_SKEWX { get; set; }

        int SVG_TRANSFORM_SKEWY { get; set; }

        int SVG_TRANSFORM_TRANSLATE { get; set; }

        int SVG_TRANSFORM_UNKNOWN { get; set; }

        int angle { get; set; }

        SVGMatrix matrix { get; set; }

        int type { get; set; }

        void setMatrix(SVGMatrix matrix);

        void setRotate(int angle, int cx, int cy);

        void setScale(int sx, int sy);

        void setSkewX(int angle);

        void setSkewY(int angle);

        void setTranslate(int tx, int ty);
    }

    public partial interface UIEvent : Event
    {
        int detail { get; set; }

        Window view { get; set; }

        void initUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg);
    }

    public partial interface SVGURIReference
    {
        SVGAnimatedString href { get; set; }
    }

    public partial interface SVGPathSeg
    {
        int PATHSEG_ARC_ABS { get; set; }

        int PATHSEG_ARC_REL { get; set; }

        int PATHSEG_CLOSEPATH { get; set; }

        int PATHSEG_CURVETO_CUBIC_ABS { get; set; }

        int PATHSEG_CURVETO_CUBIC_REL { get; set; }

        int PATHSEG_CURVETO_CUBIC_SMOOTH_ABS { get; set; }

        int PATHSEG_CURVETO_CUBIC_SMOOTH_REL { get; set; }

        int PATHSEG_CURVETO_QUADRATIC_ABS { get; set; }

        int PATHSEG_CURVETO_QUADRATIC_REL { get; set; }

        int PATHSEG_CURVETO_QUADRATIC_SMOOTH_ABS { get; set; }

        int PATHSEG_CURVETO_QUADRATIC_SMOOTH_REL { get; set; }

        int PATHSEG_LINETO_ABS { get; set; }

        int PATHSEG_LINETO_HORIZONTAL_ABS { get; set; }

        int PATHSEG_LINETO_HORIZONTAL_REL { get; set; }

        int PATHSEG_LINETO_REL { get; set; }

        int PATHSEG_LINETO_VERTICAL_ABS { get; set; }

        int PATHSEG_LINETO_VERTICAL_REL { get; set; }

        int PATHSEG_MOVETO_ABS { get; set; }

        int PATHSEG_MOVETO_REL { get; set; }

        int PATHSEG_UNKNOWN { get; set; }

        int pathSegType { get; set; }

        string pathSegTypeAsLetter { get; set; }
    }

    public partial interface WheelEvent : MouseEvent
    {
        int DOM_DELTA_LINE { get; set; }

        int DOM_DELTA_PAGE { get; set; }

        int DOM_DELTA_PIXEL { get; set; }

        int deltaMode { get; set; }

        int deltaX { get; set; }

        int deltaY { get; set; }

        int deltaZ { get; set; }

        void getCurrentPoint(Element element);

        void initWheelEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            int buttonArg,
            EventTarget relatedTargetArg,
            string modifiersListArg,
            int deltaXArg,
            int deltaYArg,
            int deltaZArg,
            int deltaMode);
    }

    public partial interface MSEventAttachmentTarget
    {
        bool attachEvent(string _event, EventListener listener);

        void detachEvent(string _event, EventListener listener);
    }

    public partial interface SVGNumber
    {
        int value { get; set; }
    }

    public partial interface SVGPathElement : SVGElement,
                                              SVGStylable,
                                              SVGAnimatedPathData,
                                              SVGTransformable,
                                              SVGLangSpace,
                                              SVGTests,
                                              SVGExternalResourcesRequired
    {
        SVGPathSegArcAbs createSVGPathSegArcAbs(double x, double y, int r1, int r2, int angle, bool largeArcFlag, bool sweepFlag);

        SVGPathSegArcRel createSVGPathSegArcRel(double x, double y, int r1, int r2, int angle, bool largeArcFlag, bool sweepFlag);

        SVGPathSegClosePath createSVGPathSegClosePath();

        SVGPathSegCurvetoCubicAbs createSVGPathSegCurvetoCubicAbs(double x, double y, double x1, double y1, double x2, double y2);

        SVGPathSegCurvetoCubicRel createSVGPathSegCurvetoCubicRel(double x, double y, double x1, double y1, double x2, double y2);

        SVGPathSegCurvetoCubicSmoothAbs createSVGPathSegCurvetoCubicSmoothAbs(double x, double y, double x2, double y2);

        SVGPathSegCurvetoCubicSmoothRel createSVGPathSegCurvetoCubicSmoothRel(double x, double y, double x2, double y2);

        SVGPathSegCurvetoQuadraticAbs createSVGPathSegCurvetoQuadraticAbs(double x, double y, double x1, double y1);

        SVGPathSegCurvetoQuadraticRel createSVGPathSegCurvetoQuadraticRel(double x, double y, double x1, double y1);

        SVGPathSegCurvetoQuadraticSmoothAbs createSVGPathSegCurvetoQuadraticSmoothAbs(double x, double y);

        SVGPathSegCurvetoQuadraticSmoothRel createSVGPathSegCurvetoQuadraticSmoothRel(double x, double y);

        SVGPathSegLinetoAbs createSVGPathSegLinetoAbs(double x, double y);

        SVGPathSegLinetoHorizontalAbs createSVGPathSegLinetoHorizontalAbs(double x);

        SVGPathSegLinetoHorizontalRel createSVGPathSegLinetoHorizontalRel(double x);

        SVGPathSegLinetoRel createSVGPathSegLinetoRel(double x, double y);

        SVGPathSegLinetoVerticalAbs createSVGPathSegLinetoVerticalAbs(double y);

        SVGPathSegLinetoVerticalRel createSVGPathSegLinetoVerticalRel(double y);

        SVGPathSegMovetoAbs createSVGPathSegMovetoAbs(double x, double y);

        SVGPathSegMovetoRel createSVGPathSegMovetoRel(double x, double y);

        int getPathSegAtLength(int distance);

        SVGPoint getPointAtLength(int distance);

        int getTotalLength();
    }

    public partial interface MSCompatibleInfo
    {
        string userAgent { get; set; }

        string version { get; set; }
    }

    public partial interface Text : CharacterData, MSNodeExtensions
    {
        string wholeText { get; set; }

        Text replaceWholeText(string content);

        Text splitText(int offset);
    }

    public partial interface SVGAnimatedRect
    {
        SVGRect animVal { get; set; }

        SVGRect baseVal { get; set; }
    }

    public partial interface CSSNamespaceRule : CSSRule
    {
        string namespaceURI { get; set; }

        string prefix { get; set; }
    }

    public partial interface SVGPathSegList
    {
        int numberOfItems { get; set; }

        SVGPathSeg appendItem(SVGPathSeg newItem);

        void clear();

        SVGPathSeg getItem(int index);

        SVGPathSeg initialize(SVGPathSeg newItem);

        SVGPathSeg insertItemBefore(SVGPathSeg newItem, int index);

        SVGPathSeg removeItem(int index);

        SVGPathSeg replaceItem(SVGPathSeg newItem, int index);
    }

    public partial interface HTMLUnknownElement : HTMLElement, MSDataBindingRecordSetReadonlyExtensions
    {
    }

    public partial interface HTMLAudioElement : HTMLMediaElement
    {
    }

    public partial interface MSImageResourceExtensions
    {
        string dynsrc { get; set; }

        int loop { get; set; }

        string lowsrc { get; set; }

        string start { get; set; }

        string vrml { get; set; }
    }

    public partial interface PositionError
    {
        int PERMISSION_DENIED { get; set; }

        int POSITION_UNAVAILABLE { get; set; }

        int TIMEOUT { get; set; }

        int code { get; set; }

        string message { get; set; }

        string ToString();
    }

    public partial interface HTMLTableCellElement : HTMLElement, HTMLTableAlignment, DOML2DeprecatedBackgroundStyle, DOML2DeprecatedBackgroundColorStyle
    {
        string abbr { get; set; }

        string align { get; set; }

        string axis { get; set; }

        object borderColor { get; set; }

        object borderColorDark { get; set; }

        object borderColorLight { get; set; }

        int cellIndex { get; set; }

        int colSpan { get; set; }

        string headers { get; set; }

        object height { get; set; }

        bool noWrap { get; set; }

        int rowSpan { get; set; }

        string scope { get; set; }

        int width { get; set; }
    }

    public partial interface SVGElementInstance : EventTarget
    {
        SVGElementInstanceList childNodes { get; set; }

        SVGElement correspondingElement { get; set; }

        SVGUseElement correspondingUseElement { get; set; }

        SVGElementInstance firstChild { get; set; }

        SVGElementInstance lastChild { get; set; }

        SVGElementInstance nextSibling { get; set; }

        SVGElementInstance parentNode { get; set; }

        SVGElementInstance previousSibling { get; set; }
    }

    public partial interface MSNamespaceInfoCollection
    {
        int Length { get; set; }

        object add(string _namespace = null, string urn = null, object implementationUrl = null);

        object item(object index);
    }

    public partial interface SVGCircleElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength cx { get; set; }

        SVGAnimatedLength cy { get; set; }

        SVGAnimatedLength r { get; set; }
    }

    public partial interface StyleSheetList
    {
        StyleSheet this[int index] { get; set; }

        int Length { get; set; }

        StyleSheet item(int index = 0);
    }

    public partial interface CSSImportRule : CSSRule
    {
        string href { get; set; }

        MediaList media { get; set; }

        CSSStyleSheet styleSheet { get; set; }
    }

    public partial interface CustomEvent : Event
    {
        object detail { get; set; }

        void initCustomEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object detailArg);
    }

    public partial interface HTMLBaseFontElement : HTMLElement, DOML2DeprecatedColorProperty
    {
        string face { get; set; }

        int size { get; set; }
    }

    public partial interface HTMLTextAreaElement : HTMLElement, MSDataBindingExtensions
    {
        bool autofocus { get; set; }

        int cols { get; set; }

        string defaultValue { get; set; }

        HTMLFormElement form { get; set; }

        int maxLength { get; set; }

        string name { get; set; }

        string placeholder { get; set; }

        bool readOnly { get; set; }

        bool required { get; set; }

        int rows { get; set; }

        int selectionEnd { get; set; }

        int selectionStart { get; set; }

        object status { get; set; }

        string type { get; set; }

        string validationMessage { get; set; }

        ValidityState validity { get; set; }

        string value { get; set; }

        bool willValidate { get; set; }

        string wrap { get; set; }

        bool checkValidity();

        TextRange createTextRange();

        void select();

        void setCustomValidity(string error);

        void setSelectionRange(int start, int end);
    }

    public partial interface Geolocation
    {
        void clearWatch(int watchId);

        void getCurrentPosition(PositionCallback successCallback, PositionErrorCallback errorCallback = null, PositionOptions options = null);

        double watchPosition(PositionCallback successCallback, PositionErrorCallback errorCallback = null, PositionOptions options = null);
    }

    public partial interface DOML2DeprecatedMarginStyle
    {
        int hspace { get; set; }

        int vspace { get; set; }
    }

    public partial interface MSWindowModeless
    {
        object dialogHeight { get; set; }

        object dialogLeft { get; set; }

        object dialogTop { get; set; }

        object dialogWidth { get; set; }

        object menuArguments { get; set; }
    }

    public partial interface DOML2DeprecatedAlignmentStyle
    {
        string align { get; set; }
    }

    public partial interface HTMLMarqueeElement : HTMLElement, MSDataBindingExtensions, DOML2DeprecatedBackgroundColorStyle
    {
        string behavior { get; set; }

        string direction { get; set; }

        string height { get; set; }

        int hspace { get; set; }

        int loop { get; set; }

        Func<Event, object> onbounce { get; set; }

        Func<Event, object> onfinish { get; set; }

        Func<Event, object> onstart { get; set; }

        int scrollAmount { get; set; }

        int scrollDelay { get; set; }

        bool trueSpeed { get; set; }

        int vspace { get; set; }

        string width { get; set; }

        void start();

        void stop();
    }

    public partial interface SVGRect
    {
        int height { get; set; }

        int width { get; set; }

        double x { get; set; }

        double y { get; set; }
    }

    public partial interface MSNodeExtensions
    {
        Node removeNode(bool deep = false);

        Node replaceNode(Node replacement);

        Node swapNode(Node otherNode);
    }

    public partial interface History
    {
        int Length { get; set; }

        object state { get; set; }

        void back(object distance = null);

        void forward(object distance = null);

        void go(object delta = null);

        void pushState(object statedata, string title, string url = null);

        void replaceState(object statedata, string title, string url = null);
    }

    public partial interface SVGPathSegCurvetoCubicAbs : SVGPathSeg
    {
        double x { get; set; }

        double x1 { get; set; }

        double x2 { get; set; }

        double y { get; set; }

        double y1 { get; set; }

        double y2 { get; set; }
    }

    public partial interface SVGPathSegCurvetoQuadraticAbs : SVGPathSeg
    {
        double x { get; set; }

        double x1 { get; set; }

        double y { get; set; }

        double y1 { get; set; }
    }

    public partial interface TimeRanges
    {
        int Length { get; set; }

        int end(int index);

        int start(int index);
    }

    public partial interface CSSRule
    {
        int CHARSET_RULE { get; set; }

        int FONT_FACE_RULE { get; set; }

        int IMPORT_RULE { get; set; }

        int KEYFRAMES_RULE { get; set; }

        int KEYFRAME_RULE { get; set; }

        int MEDIA_RULE { get; set; }

        int NAMESPACE_RULE { get; set; }

        int PAGE_RULE { get; set; }

        int STYLE_RULE { get; set; }

        int UNKNOWN_RULE { get; set; }

        int VIEWPORT_RULE { get; set; }

        string cssText { get; set; }

        CSSRule parentRule { get; set; }

        CSSStyleSheet parentStyleSheet { get; set; }

        int type { get; set; }
    }

    public partial interface SVGPathSegLinetoAbs : SVGPathSeg
    {
        double x { get; set; }

        double y { get; set; }
    }

    public partial interface HTMLModElement : HTMLElement
    {
        string cite { get; set; }

        string dateTime { get; set; }
    }

    public partial interface SVGMatrix
    {
        int a { get; set; }

        int b { get; set; }

        int c { get; set; }

        int d { get; set; }

        int e { get; set; }

        int f { get; set; }

        SVGMatrix flipX();

        SVGMatrix flipY();

        SVGMatrix inverse();

        SVGMatrix multiply(SVGMatrix secondMatrix);

        SVGMatrix rotate(int angle);

        SVGMatrix rotateFromVector(double x, double y);

        SVGMatrix scale(int scaleFactor);

        SVGMatrix scaleNonUniform(int scaleFactorX, int scaleFactorY);

        SVGMatrix skewX(int angle);

        SVGMatrix skewY(int angle);

        SVGMatrix translate(double x, double y);
    }

    public partial interface MSPopupWindow
    {
        Document document { get; set; }

        bool isOpen { get; set; }

        void hide();

        void show(double x, double y, double w, int h, object element = null);
    }

    public partial interface BeforeUnloadEvent : Event
    {
        string returnValue { get; set; }
    }

    public partial interface SVGUseElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired, SVGURIReference
    {
        SVGElementInstance animatedInstanceRoot { get; set; }

        SVGAnimatedLength height { get; set; }

        SVGElementInstance instanceRoot { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }
    }

    public partial interface Event
    {
        int AT_TARGET { get; set; }

        int BUBBLING_PHASE { get; set; }

        int CAPTURING_PHASE { get; set; }

        bool bubbles { get; set; }

        bool cancelBubble { get; set; }

        bool cancelable { get; set; }

        EventTarget currentTarget { get; set; }

        bool defaultPrevented { get; set; }

        int eventPhase { get; set; }

        bool isTrusted { get; set; }

        Element srcElement { get; set; }

        EventTarget target { get; set; }

        int timeStamp { get; set; }

        string type { get; set; }

        void initEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg);

        void preventDefault();

        void stopImmediatePropagation();

        void stopPropagation();
    }

    public partial interface ImageData
    {
        Uint8Array data { get; set; }

        int height { get; set; }

        uint width { get; set; }
    }

    public partial interface HTMLTableColElement : HTMLElement, HTMLTableAlignment
    {
        string align { get; set; }

        int span { get; set; }

        object width { get; set; }
    }

    public partial interface SVGException
    {
        int SVG_INVALID_VALUE_ERR { get; set; }

        int SVG_MATRIX_NOT_INVERTABLE { get; set; }

        int SVG_WRONG_TYPE_ERR { get; set; }

        int code { get; set; }

        string message { get; set; }

        string name { get; set; }

        string ToString();
    }

    public partial interface SVGLinearGradientElement : SVGGradientElement
    {
        SVGAnimatedLength x1 { get; set; }

        SVGAnimatedLength x2 { get; set; }

        SVGAnimatedLength y1 { get; set; }

        SVGAnimatedLength y2 { get; set; }
    }

    public partial interface HTMLTableAlignment
    {
        string ch { get; set; }

        string chOff { get; set; }

        string vAlign { get; set; }
    }

    public partial interface SVGAnimatedEnumeration
    {
        int animVal { get; set; }

        int baseVal { get; set; }
    }

    public partial interface DOML2DeprecatedSizeProperty
    {
        int size { get; set; }
    }

    public partial interface HTMLUListElement : HTMLElement, DOML2DeprecatedListSpaceReduction, DOML2DeprecatedListNumberingAndBulletStyle
    {
    }

    public partial interface SVGRectElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength height { get; set; }

        SVGAnimatedLength rx { get; set; }

        SVGAnimatedLength ry { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }
    }

    public delegate void ErrorEventHandler(Event _event, string source, int fileno, int columnNumber);

    public partial interface HTMLDivElement : HTMLElement, MSDataBindingExtensions
    {
        string align { get; set; }

        bool noWrap { get; set; }
    }

    public partial interface DOML2DeprecatedBorderStyle
    {
        string border { get; set; }
    }

    public partial interface NamedNodeMap
    {
        Attr this[int index] { get; set; }

        int Length { get; set; }

        Attr getNamedItem(string name);

        Attr getNamedItemNS(string namespaceURI, string localName);

        Attr item(int index);

        Attr removeNamedItem(string name);

        Attr removeNamedItemNS(string namespaceURI, string localName);

        Attr setNamedItem(Attr arg);

        Attr setNamedItemNS(Attr arg);
    }

    public partial interface MediaList
    {
        string this[int index] { get; set; }

        int Length { get; set; }

        string mediaText { get; set; }

        string ToString();

        void appendMedium(string newMedium);

        void deleteMedium(string oldMedium);

        string item(int index);
    }

    public partial interface SVGPathSegCurvetoQuadraticSmoothAbs : SVGPathSeg
    {
        double x { get; set; }

        double y { get; set; }
    }

    public partial interface SVGPathSegCurvetoCubicSmoothRel : SVGPathSeg
    {
        double x { get; set; }

        double x2 { get; set; }

        double y { get; set; }

        double y2 { get; set; }
    }

    public partial interface SVGLengthList
    {
        int numberOfItems { get; set; }

        SVGLength appendItem(SVGLength newItem);

        void clear();

        SVGLength getItem(int index);

        SVGLength initialize(SVGLength newItem);

        SVGLength insertItemBefore(SVGLength newItem, int index);

        SVGLength removeItem(int index);

        SVGLength replaceItem(SVGLength newItem, int index);
    }

    public partial interface ProcessingInstruction : Node
    {
        string data { get; set; }

        string target { get; set; }
    }

    public partial interface MSWindowExtensions
    {
        MSEventObj _event { get; set; }

        Navigator clientInformation { get; set; }

        DataTransfer clipboardData { get; set; }

        bool closed { get; set; }

        string defaultStatus { get; set; }

        External external { get; set; }

        int maxConnectionsPerServer { get; set; }

        object offscreenBuffering { get; set; }

        Func<FocusEvent, object> onfocusin { get; set; }

        Func<FocusEvent, object> onfocusout { get; set; }

        Func<Event, object> onhelp { get; set; }

        Func<MouseEvent, object> onmouseenter { get; set; }

        Func<MouseEvent, object> onmouseleave { get; set; }

        int screenLeft { get; set; }

        int screenTop { get; set; }

        string status { get; set; }

        void captureEvents();

        MSPopupWindow createPopup(object arguments = null);

        object execScript(string code, string language = null);

        object item(object index);

        void moveBy(double x = 0, double y = 0);

        void moveTo(double x = 0, double y = 0);

        void msWriteProfilerMark(string profilerMarkName);

        void navigate(string url);

        void releaseEvents();

        void resizeBy(double x = 0, double y = 0);

        void resizeTo(double x = 0, double y = 0);

        void showHelp(string url, object helpArg = null, string features = null);

        Window showModelessDialog(string url = null, object argument = null, object options = null);

        string toStaticHTML(string html);
    }

    public partial interface MSBehaviorUrnsCollection
    {
        int Length { get; set; }

        string item(int index);
    }

    public partial interface CSSFontFaceRule : CSSRule
    {
        CSSStyleDeclaration style { get; set; }
    }

    public partial interface DOML2DeprecatedBackgroundStyle
    {
        string background { get; set; }
    }

    public partial interface TextEvent : UIEvent
    {
        int DOM_INPUT_METHOD_DROP { get; set; }

        int DOM_INPUT_METHOD_HANDWRITING { get; set; }

        int DOM_INPUT_METHOD_IME { get; set; }

        int DOM_INPUT_METHOD_KEYBOARD { get; set; }

        int DOM_INPUT_METHOD_MULTIMODAL { get; set; }

        int DOM_INPUT_METHOD_OPTION { get; set; }

        int DOM_INPUT_METHOD_PASTE { get; set; }

        int DOM_INPUT_METHOD_SCRIPT { get; set; }

        int DOM_INPUT_METHOD_UNKNOWN { get; set; }

        int DOM_INPUT_METHOD_VOICE { get; set; }

        string data { get; set; }

        int inputMethod { get; set; }

        string locale { get; set; }

        void initTextEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, int inputMethod, string locale);
    }

    public partial interface DocumentFragment : Node, NodeSelector, MSEventAttachmentTarget, MSNodeExtensions
    {
    }

    public partial interface SVGPolylineElement : SVGElement,
                                                  SVGStylable,
                                                  SVGTransformable,
                                                  SVGLangSpace,
                                                  SVGAnimatedPoints,
                                                  SVGTests,
                                                  SVGExternalResourcesRequired
    {
    }

    public partial interface SVGAnimatedPathData
    {
        SVGPathSegList pathSegList { get; set; }
    }

    public partial interface Position
    {
        Coordinates coords { get; set; }

        Date timestamp { get; set; }
    }

    public partial interface BookmarkCollection
    {
        object this[int index] { get; set; }

        int Length { get; set; }

        object item(int index);
    }

    public partial interface PerformanceMark : PerformanceEntry
    {
    }

    public partial interface CSSPageRule : CSSRule
    {
        string pseudoClass { get; set; }

        string selector { get; set; }

        string selectorText { get; set; }

        CSSStyleDeclaration style { get; set; }
    }

    public partial interface HTMLBRElement : HTMLElement
    {
        string clear { get; set; }
    }

    public partial interface MSNavigatorExtensions
    {
        string appCodeName { get; set; }

        string appMinorVersion { get; set; }

        string browserLanguage { get; set; }

        int connectionSpeed { get; set; }

        bool cookieEnabled { get; set; }

        string cpuClass { get; set; }

        string language { get; set; }

        MSMimeTypesCollection mimeTypes { get; set; }

        MSPluginsCollection plugins { get; set; }

        string systemLanguage { get; set; }

        string userLanguage { get; set; }

        bool javaEnabled();

        bool taintEnabled();
    }

    public partial interface HTMLSpanElement : HTMLElement, MSDataBindingExtensions
    {
    }

    public partial interface HTMLHeadElement : HTMLElement
    {
        string profile { get; set; }
    }

    public partial interface HTMLHeadingElement : HTMLElement, DOML2DeprecatedTextFlowControl
    {
        string align { get; set; }
    }

    public partial interface HTMLFormElement : HTMLElement, MSHTMLCollectionExtensions
    {
        object this[string name] { get; set; }

        int Length { get; set; }

        string acceptCharset { get; set; }

        string action { get; set; }

        string autocomplete { get; set; }

        HTMLCollection elements { get; set; }

        string encoding { get; set; }

        string enctype { get; set; }

        string method { get; set; }

        string name { get; set; }

        bool noValidate { get; set; }

        string target { get; set; }

        bool checkValidity();

        object item(object name = null, object index = null);

        object namedItem(string name);

        void reset();

        void submit();
    }

    public partial interface SVGZoomAndPan
    {
        int SVG_ZOOMANDPAN_DISABLE { get; set; }

        int SVG_ZOOMANDPAN_MAGNIFY { get; set; }

        int SVG_ZOOMANDPAN_UNKNOWN { get; set; }

        double zoomAndPan { get; set; }
    }

    public partial interface HTMLMediaElement : HTMLElement
    {
        int HAVE_CURRENT_DATA { get; set; }

        int HAVE_ENOUGH_DATA { get; set; }

        int HAVE_FUTURE_DATA { get; set; }

        int HAVE_METADATA { get; set; }

        int HAVE_NOTHING { get; set; }

        int NETWORK_EMPTY { get; set; }

        int NETWORK_IDLE { get; set; }

        int NETWORK_LOADING { get; set; }

        int NETWORK_NO_SOURCE { get; set; }

        AudioTrackList audioTracks { get; set; }

        bool autobuffer { get; set; }

        bool autoplay { get; set; }

        TimeRanges buffered { get; set; }

        bool controls { get; set; }

        string currentSrc { get; set; }

        int currentTime { get; set; }

        int defaultPlaybackRate { get; set; }

        int duration { get; set; }

        bool ended { get; set; }

        MediaError error { get; set; }

        int initialTime { get; set; }

        bool loop { get; set; }

        string msAudioCategory { get; set; }

        string msAudioDeviceType { get; set; }

        MSGraphicsTrust msGraphicsTrustStatus { get; set; }

        MSMediaKeys msKeys { get; set; }

        bool msPlayToDisabled { get; set; }

        string msPlayToPreferredSourceUri { get; set; }

        bool msPlayToPrimary { get; set; }

        object msPlayToSource { get; set; }

        bool msRealTime { get; set; }

        bool muted { get; set; }

        int networkState { get; set; }

        Func<MSMediaKeyNeededEvent, object> onmsneedkey { get; set; }

        bool paused { get; set; }

        int playbackRate { get; set; }

        TimeRanges played { get; set; }

        string preload { get; set; }

        TimeRanges seekable { get; set; }

        bool seeking { get; set; }

        string src { get; set; }

        TextTrackList textTracks { get; set; }

        int volume { get; set; }

        TextTrack addTextTrack(string kind, string label = null, string language = null);

        string canPlayType(string type);

        void load();

        void msClearEffects();

        void msInsertAudioEffect(string activatableClassId, bool effectRequired, object config = null);

        void msSetMediaKeys(MSMediaKeys mediaKeys);

        void msSetMediaProtectionManager(object mediaProtectionManager = null);

        void pause();

        void play();
    }

    public partial interface ElementCSSInlineStyle
    {
        MSCurrentStyleCSSProperties currentStyle { get; set; }

        MSStyleCSSProperties runtimeStyle { get; set; }

        string componentFromPoint(double x, double y);

        void doScroll(object component = null);
    }

    public partial interface DOMParser
    {
        Document parseFromString(string source, string mimeType);
    }

    public partial interface MSMimeTypesCollection
    {
        int Length { get; set; }
    }

    public partial interface StyleSheet
    {
        bool disabled { get; set; }

        string href { get; set; }

        MediaList media { get; set; }

        Node ownerNode { get; set; }

        StyleSheet parentStyleSheet { get; set; }

        string title { get; set; }

        string type { get; set; }
    }

    public partial interface SVGTextPathElement : SVGTextContentElement, SVGURIReference
    {
        int TEXTPATH_METHODTYPE_ALIGN { get; set; }

        int TEXTPATH_METHODTYPE_STRETCH { get; set; }

        int TEXTPATH_METHODTYPE_UNKNOWN { get; set; }

        int TEXTPATH_SPACINGTYPE_AUTO { get; set; }

        int TEXTPATH_SPACINGTYPE_EXACT { get; set; }

        int TEXTPATH_SPACINGTYPE_UNKNOWN { get; set; }

        SVGAnimatedEnumeration method { get; set; }

        SVGAnimatedEnumeration spacing { get; set; }

        SVGAnimatedLength startOffset { get; set; }
    }

    public partial interface HTMLDTElement : HTMLElement
    {
        bool noWrap { get; set; }
    }

    public partial interface NodeList
    {
        Node this[int index] { get; set; }

        int Length { get; set; }

        Node item(int index);
    }

    public partial interface XMLSerializer
    {
        string serializeToString(Node target);
    }

    public partial interface PerformanceMeasure : PerformanceEntry
    {
    }

    public partial interface SVGGradientElement : SVGElement, SVGUnitTypes, SVGStylable, SVGExternalResourcesRequired, SVGURIReference
    {
        int SVG_SPREADMETHOD_PAD { get; set; }

        int SVG_SPREADMETHOD_REFLECT { get; set; }

        int SVG_SPREADMETHOD_REPEAT { get; set; }

        int SVG_SPREADMETHOD_UNKNOWN { get; set; }

        SVGAnimatedTransformList gradientTransform { get; set; }

        SVGAnimatedEnumeration gradientUnits { get; set; }

        SVGAnimatedEnumeration spreadMethod { get; set; }
    }

    public partial interface NodeFilter
    {
        int FILTER_ACCEPT { get; set; }

        int FILTER_REJECT { get; set; }

        int FILTER_SKIP { get; set; }

        int SHOW_ALL { get; set; }

        int SHOW_ATTRIBUTE { get; set; }

        int SHOW_CDATA_SECTION { get; set; }

        int SHOW_COMMENT { get; set; }

        int SHOW_DOCUMENT { get; set; }

        int SHOW_DOCUMENT_FRAGMENT { get; set; }

        int SHOW_DOCUMENT_TYPE { get; set; }

        int SHOW_ELEMENT { get; set; }

        int SHOW_ENTITY { get; set; }

        int SHOW_ENTITY_REFERENCE { get; set; }

        int SHOW_NOTATION { get; set; }

        int SHOW_PROCESSING_INSTRUCTION { get; set; }

        int SHOW_TEXT { get; set; }

        int acceptNode(Node n);
    }

    public partial interface SVGNumberList
    {
        int numberOfItems { get; set; }

        SVGNumber appendItem(SVGNumber newItem);

        void clear();

        SVGNumber getItem(int index);

        SVGNumber initialize(SVGNumber newItem);

        SVGNumber insertItemBefore(SVGNumber newItem, int index);

        SVGNumber removeItem(int index);

        SVGNumber replaceItem(SVGNumber newItem, int index);
    }

    public partial interface MediaError
    {
        int MEDIA_ERR_ABORTED { get; set; }

        int MEDIA_ERR_DECODE { get; set; }

        int MEDIA_ERR_NETWORK { get; set; }

        int MEDIA_ERR_SRC_NOT_SUPPORTED { get; set; }

        int MS_MEDIA_ERR_ENCRYPTED { get; set; }

        int code { get; set; }

        int msExtendedCode { get; set; }
    }

    public partial interface HTMLFieldSetElement : HTMLElement
    {
        string align { get; set; }

        HTMLFormElement form { get; set; }

        string validationMessage { get; set; }

        ValidityState validity { get; set; }

        bool willValidate { get; set; }

        bool checkValidity();

        void setCustomValidity(string error);
    }

    public partial interface HTMLBGSoundElement : HTMLElement
    {
        object balance { get; set; }

        int loop { get; set; }

        string src { get; set; }

        object volume { get; set; }
    }

    public partial interface Comment : CharacterData
    {
        string text { get; set; }
    }

    public partial interface PerformanceResourceTiming : PerformanceEntry
    {
        int connectEnd { get; set; }

        int connectStart { get; set; }

        int domainLookupEnd { get; set; }

        int domainLookupStart { get; set; }

        int fetchStart { get; set; }

        string initiatorType { get; set; }

        int redirectEnd { get; set; }

        int redirectStart { get; set; }

        int requestStart { get; set; }

        int responseEnd { get; set; }

        int responseStart { get; set; }
    }

    public partial interface CanvasPattern
    {
    }

    public partial interface HTMLHRElement : HTMLElement, DOML2DeprecatedColorProperty, DOML2DeprecatedSizeProperty
    {
        string align { get; set; }

        bool noShade { get; set; }

        int width { get; set; }
    }

    public partial interface HTMLObjectElement : HTMLElement,
                                                 GetSVGDocument,
                                                 DOML2DeprecatedMarginStyle,
                                                 DOML2DeprecatedBorderStyle,
                                                 DOML2DeprecatedAlignmentStyle,
                                                 MSDataBindingExtensions,
                                                 MSDataBindingRecordSetExtensions
    {
        string BaseHref { get; set; }

        object _object { get; set; }

        string alt { get; set; }

        string altHtml { get; set; }

        string archive { get; set; }

        string classid { get; set; }

        string code { get; set; }

        string codeBase { get; set; }

        string codeType { get; set; }

        Document contentDocument { get; set; }

        string data { get; set; }

        bool declare { get; set; }

        HTMLFormElement form { get; set; }

        string height { get; set; }

        bool msPlayToDisabled { get; set; }

        string msPlayToPreferredSourceUri { get; set; }

        bool msPlayToPrimary { get; set; }

        object msPlayToSource { get; set; }

        string name { get; set; }

        string standby { get; set; }

        string type { get; set; }

        string useMap { get; set; }

        string validationMessage { get; set; }

        ValidityState validity { get; set; }

        string width { get; set; }

        bool willValidate { get; set; }

        bool checkValidity();

        void setCustomValidity(string error);
    }

    public partial interface HTMLEmbedElement : HTMLElement, GetSVGDocument
    {
        string height { get; set; }

        bool msPlayToDisabled { get; set; }

        string msPlayToPreferredSourceUri { get; set; }

        bool msPlayToPrimary { get; set; }

        object msPlayToSource { get; set; }

        string name { get; set; }

        string palette { get; set; }

        string pluginspage { get; set; }

        string src { get; set; }

        string units { get; set; }

        string width { get; set; }
    }

    public partial interface StorageEvent : Event
    {
        string key { get; set; }

        object newValue { get; set; }

        object oldValue { get; set; }

        Storage storageArea { get; set; }

        string url { get; set; }

        void initStorageEvent(
            string typeArg, bool canBubbleArg, bool cancelableArg, string keyArg, object oldValueArg, object newValueArg, string urlArg, Storage storageAreaArg);
    }

    public partial interface CharacterData : Node
    {
        int Length { get; set; }

        string data { get; set; }

        void appendData(string arg);

        void deleteData(int offset, int count);

        void insertData(int offset, string arg);

        void replaceData(int offset, int count, string arg);

        string substringData(int offset, int count);
    }

    public partial interface HTMLOptGroupElement : HTMLElement, MSDataBindingExtensions
    {
        bool defaultSelected { get; set; }

        HTMLFormElement form { get; set; }

        int index { get; set; }

        string label { get; set; }

        bool selected { get; set; }

        string text { get; set; }

        string value { get; set; }
    }

    public partial interface HTMLIsIndexElement : HTMLElement
    {
        string action { get; set; }

        HTMLFormElement form { get; set; }

        string prompt { get; set; }
    }

    public partial interface SVGPathSegLinetoRel : SVGPathSeg
    {
        double x { get; set; }

        double y { get; set; }
    }

    public partial interface DOMException
    {
        int ABORT_ERR { get; set; }

        int DATA_CLONE_ERR { get; set; }

        int DOMSTRING_SIZE_ERR { get; set; }

        int HIERARCHY_REQUEST_ERR { get; set; }

        int INDEX_SIZE_ERR { get; set; }

        int INUSE_ATTRIBUTE_ERR { get; set; }

        int INVALID_ACCESS_ERR { get; set; }

        int INVALID_CHARACTER_ERR { get; set; }

        int INVALID_MODIFICATION_ERR { get; set; }

        int INVALID_NODE_TYPE_ERR { get; set; }

        int INVALID_STATE_ERR { get; set; }

        int NAMESPACE_ERR { get; set; }

        int NETWORK_ERR { get; set; }

        int NOT_FOUND_ERR { get; set; }

        int NOT_SUPPORTED_ERR { get; set; }

        int NO_DATA_ALLOWED_ERR { get; set; }

        int NO_MODIFICATION_ALLOWED_ERR { get; set; }

        int PARSE_ERR { get; set; }

        int QUOTA_EXCEEDED_ERR { get; set; }

        int SECURITY_ERR { get; set; }

        int SERIALIZE_ERR { get; set; }

        int SYNTAX_ERR { get; set; }

        int TIMEOUT_ERR { get; set; }

        int TYPE_MISMATCH_ERR { get; set; }

        int URL_MISMATCH_ERR { get; set; }

        int VALIDATION_ERR { get; set; }

        int WRONG_DOCUMENT_ERR { get; set; }

        int code { get; set; }

        string message { get; set; }

        string name { get; set; }

        string ToString();
    }

    public partial interface SVGAnimatedBoolean
    {
        bool animVal { get; set; }

        bool baseVal { get; set; }
    }

    public partial interface MSCompatibleInfoCollection
    {
        int Length { get; set; }

        MSCompatibleInfo item(int index);
    }

    public partial interface SVGSwitchElement : SVGElement, SVGStylable, SVGTransformable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
    }

    public partial interface SVGPreserveAspectRatio
    {
        int SVG_MEETORSLICE_MEET { get; set; }

        int SVG_MEETORSLICE_SLICE { get; set; }

        int SVG_MEETORSLICE_UNKNOWN { get; set; }

        int SVG_PRESERVEASPECTRATIO_NONE { get; set; }

        int SVG_PRESERVEASPECTRATIO_UNKNOWN { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMAXYMAX { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMAXYMID { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMAXYMIN { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMIDYMAX { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMIDYMID { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMIDYMIN { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMINYMAX { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMINYMID { get; set; }

        int SVG_PRESERVEASPECTRATIO_XMINYMIN { get; set; }

        int align { get; set; }

        int meetOrSlice { get; set; }
    }

    public partial interface Attr : Node
    {
        bool expando { get; set; }

        string name { get; set; }

        Element ownerElement { get; set; }

        bool specified { get; set; }

        string value { get; set; }
    }

    public partial interface PerformanceNavigation
    {
        int TYPE_BACK_FORWARD { get; set; }

        int TYPE_NAVIGATE { get; set; }

        int TYPE_RELOAD { get; set; }

        int TYPE_RESERVED { get; set; }

        int redirectCount { get; set; }

        int type { get; set; }

        object toJSON();
    }

    public partial interface SVGStopElement : SVGElement, SVGStylable
    {
        SVGAnimatedNumber offset { get; set; }
    }

    public delegate void PositionCallback(Position position);

    public partial interface SVGSymbolElement : SVGElement, SVGStylable, SVGLangSpace, SVGFitToViewBox, SVGExternalResourcesRequired
    {
    }

    public partial interface SVGElementInstanceList
    {
        int Length { get; set; }

        SVGElementInstance item(int index);
    }

    public partial interface CSSRuleList
    {
        CSSRule this[int index] { get; set; }

        int Length { get; set; }

        CSSRule item(int index);
    }

    public partial interface MSDataBindingRecordSetExtensions
    {
        object recordset { get; set; }

        object namedRecordset(string dataMember, object hierarchy = null);
    }

    public partial interface LinkStyle
    {
        StyleSheet sheet { get; set; }

        StyleSheet styleSheet { get; set; }
    }

    public partial interface HTMLVideoElement : HTMLMediaElement
    {
        int height { get; set; }

        bool msHorizontalMirror { get; set; }

        bool msIsLayoutOptimalForPlayback { get; set; }

        bool msIsStereo3D { get; set; }

        string msStereo3DPackingMode { get; set; }

        string msStereo3DRenderMode { get; set; }

        bool msZoom { get; set; }

        Func<object, object> onMSVideoFormatChanged { get; set; }

        Func<object, object> onMSVideoFrameStepCompleted { get; set; }

        Func<object, object> onMSVideoOptimalLayoutChanged { get; set; }

        string poster { get; set; }

        int videoHeight { get; set; }

        int videoWidth { get; set; }

        int width { get; set; }

        VideoPlaybackQuality getVideoPlaybackQuality();

        void msFrameStep(bool forward);

        void msInsertVideoEffect(string activatableClassId, bool effectRequired, object config = null);

        void msSetVideoRectangle(int left, int top, int right, int bottom);
    }

    public partial interface ClientRectList
    {
        ClientRect this[int index] { get; set; }

        int Length { get; set; }

        ClientRect item(int index);
    }

    public partial interface SVGMaskElement : SVGElement, SVGUnitTypes, SVGStylable, SVGLangSpace, SVGTests, SVGExternalResourcesRequired
    {
        SVGAnimatedLength height { get; set; }

        SVGAnimatedEnumeration maskContentUnits { get; set; }

        SVGAnimatedEnumeration maskUnits { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }
    }

    public partial interface External
    {
    }

    public partial interface MSGestureEvent : UIEvent
    {
        int MSGESTURE_FLAG_BEGIN { get; set; }

        int MSGESTURE_FLAG_CANCEL { get; set; }

        int MSGESTURE_FLAG_END { get; set; }

        int MSGESTURE_FLAG_INERTIA { get; set; }

        int MSGESTURE_FLAG_NONE { get; set; }

        int clientX { get; set; }

        int clientY { get; set; }

        int expansion { get; set; }

        object gestureObject { get; set; }

        int hwTimestamp { get; set; }

        int offsetX { get; set; }

        int offsetY { get; set; }

        int rotation { get; set; }

        int scale { get; set; }

        int screenX { get; set; }

        int screenY { get; set; }

        int translationX { get; set; }

        int translationY { get; set; }

        int velocityAngular { get; set; }

        int velocityExpansion { get; set; }

        int velocityX { get; set; }

        int velocityY { get; set; }

        void initGestureEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            int offsetXArg,
            int offsetYArg,
            int translationXArg,
            int translationYArg,
            int scaleArg,
            int expansionArg,
            int rotationArg,
            int velocityXArg,
            int velocityYArg,
            int velocityExpansionArg,
            int velocityAngularArg,
            int hwTimestampArg);
    }

    public partial interface ErrorEvent : Event
    {
        int colno { get; set; }

        object error { get; set; }

        string filename { get; set; }

        int lineno { get; set; }

        string message { get; set; }

        void initErrorEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string messageArg, string filenameArg, int linenoArg);
    }

    public partial interface SVGFilterElement : SVGElement, SVGUnitTypes, SVGStylable, SVGLangSpace, SVGURIReference, SVGExternalResourcesRequired
    {
        SVGAnimatedInteger filterResX { get; set; }

        SVGAnimatedInteger filterResY { get; set; }

        SVGAnimatedEnumeration filterUnits { get; set; }

        SVGAnimatedLength height { get; set; }

        SVGAnimatedEnumeration primitiveUnits { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }

        void setFilterRes(int filterResX, int filterResY);
    }

    public partial interface TrackEvent : Event
    {
        object track { get; set; }
    }

    public partial interface SVGFEMergeNodeElement : SVGElement
    {
        SVGAnimatedString in1 { get; set; }
    }

    public partial interface SVGFEFloodElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
    }

    public partial interface MSGesture
    {
        Element target { get; set; }

        void addPointer(int pointerId);

        void stop();
    }

    public partial interface TextTrackCue : EventTarget
    {
        int endTime { get; set; }

        string id { get; set; }

        Func<Event, object> onenter { get; set; }

        Func<Event, object> onexit { get; set; }

        bool pauseOnExit { get; set; }

        int startTime { get; set; }

        string text { get; set; }

        TextTrack track { get; set; }

        DocumentFragment getCueAsHTML();
    }

    public partial interface MSStreamReader : MSBaseReader
    {
        DOMError error { get; set; }

        void readAsArrayBuffer(MSStream stream, int size = 0);

        void readAsBlob(MSStream stream, int size = 0);

        void readAsDataURL(MSStream stream, int size = 0);

        void readAsText(MSStream stream, string encoding = null, int size = 0);
    }

    public partial interface DOMTokenList
    {
        string this[int index] { get; set; }

        int Length { get; set; }

        string ToString();

        void add(string token);

        bool contains(string token);

        string item(int index);

        void remove(string token);

        bool toggle(string token);
    }

    public partial interface SVGFEFuncAElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface SVGFETileElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1 { get; set; }
    }

    public partial interface SVGFEBlendElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_FEBLEND_MODE_DARKEN { get; set; }

        int SVG_FEBLEND_MODE_LIGHTEN { get; set; }

        int SVG_FEBLEND_MODE_MULTIPLY { get; set; }

        int SVG_FEBLEND_MODE_NORMAL { get; set; }

        int SVG_FEBLEND_MODE_SCREEN { get; set; }

        int SVG_FEBLEND_MODE_UNKNOWN { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedString in2 { get; set; }

        SVGAnimatedEnumeration mode { get; set; }
    }

    public partial interface MessageChannel
    {
        MessagePort port1 { get; set; }

        MessagePort port2 { get; set; }
    }

    public partial interface SVGFEMergeElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
    }

    public partial interface TransitionEvent : Event
    {
        int elapsedTime { get; set; }

        string propertyName { get; set; }

        void initTransitionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string propertyNameArg, int elapsedTimeArg);
    }

    public partial interface MediaQueryList
    {
        bool matches { get; set; }

        string media { get; set; }

        void addListener(MediaQueryListListener listener);

        void removeListener(MediaQueryListListener listener);
    }

    public partial interface DOMError
    {
        string name { get; set; }

        string ToString();
    }

    public partial interface CloseEvent : Event
    {
        int code { get; set; }

        string reason { get; set; }

        bool wasClean { get; set; }

        void initCloseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool wasCleanArg, int codeArg, string reasonArg);
    }

    public partial interface WebSocket : EventTarget
    {
        int CLOSED { get; set; }

        int CLOSING { get; set; }

        int CONNECTING { get; set; }

        int OPEN { get; set; }

        string binaryType { get; set; }

        int bufferedAmount { get; set; }

        string extensions { get; set; }

        Func<CloseEvent, object> onclose { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<MessageEvent, object> onmessage { get; set; }

        Func<Event, object> onopen { get; set; }

        string protocol { get; set; }

        int readyState { get; set; }

        string url { get; set; }

        void close(int code = 0, string reason = null);

        void send(object data);
    }

    public partial interface SVGFEPointLightElement : SVGElement
    {
        SVGAnimatedNumber x { get; set; }

        SVGAnimatedNumber y { get; set; }

        SVGAnimatedNumber z { get; set; }
    }

    public partial interface ProgressEvent : Event
    {
        bool lengthComputable { get; set; }

        int loaded { get; set; }

        int total { get; set; }

        void initProgressEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool lengthComputableArg, int loadedArg, int totalArg);
    }

    public partial interface IDBObjectStore
    {
        DOMStringList indexNames { get; set; }

        string keyPath { get; set; }

        string name { get; set; }

        IDBTransaction transaction { get; set; }

        IDBRequest add(object value, object key = null);

        IDBRequest clear();

        IDBRequest count(object key = null);

        IDBIndex createIndex(string name, string keyPath, object optionalParameters = null);

        IDBRequest delete(object key);

        void deleteIndex(string indexName);

        IDBRequest get(object key);

        IDBIndex index(string name);

        IDBRequest openCursor(object range = null, string direction = null);

        IDBRequest put(object value, object key = null);
    }

    public partial interface SVGFEGaussianBlurElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1 { get; set; }

        SVGAnimatedNumber stdDeviationX { get; set; }

        SVGAnimatedNumber stdDeviationY { get; set; }

        void setStdDeviation(int stdDeviationX, int stdDeviationY);
    }

    public partial interface SVGFilterPrimitiveStandardAttributes : SVGStylable
    {
        SVGAnimatedLength height { get; set; }

        SVGAnimatedString result { get; set; }

        SVGAnimatedLength width { get; set; }

        SVGAnimatedLength x { get; set; }

        SVGAnimatedLength y { get; set; }
    }

    public partial interface IDBVersionChangeEvent : Event
    {
        int newVersion { get; set; }

        int oldVersion { get; set; }
    }

    public partial interface IDBIndex
    {
        string keyPath { get; set; }

        string name { get; set; }

        IDBObjectStore objectStore { get; set; }

        bool unique { get; set; }

        IDBRequest count(object key = null);

        IDBRequest get(object key);

        IDBRequest getKey(object key);

        IDBRequest openCursor(IDBKeyRange range = null, string direction = null);

        IDBRequest openKeyCursor(IDBKeyRange range = null, string direction = null);
    }

    public partial interface FileList
    {
        File this[int index] { get; set; }

        int Length { get; set; }

        File item(int index);
    }

    public partial interface IDBCursor
    {
        string NEXT { get; set; }

        string NEXT_NO_DUPLICATE { get; set; }

        string PREV { get; set; }

        string PREV_NO_DUPLICATE { get; set; }

        string direction { get; set; }

        object key { get; set; }

        object primaryKey { get; set; }

        object source { get; set; }

        void _continue(object key = null);

        void advance(int count);

        IDBRequest delete();

        IDBRequest update(object value);
    }

    public partial interface SVGFESpecularLightingElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1 { get; set; }

        SVGAnimatedNumber kernelUnitLengthX { get; set; }

        SVGAnimatedNumber kernelUnitLengthY { get; set; }

        SVGAnimatedNumber specularConstant { get; set; }

        SVGAnimatedNumber specularExponent { get; set; }

        SVGAnimatedNumber surfaceScale { get; set; }
    }

    public partial interface File : Blob
    {
        object lastModifiedDate { get; set; }

        string name { get; set; }
    }

    public partial interface URL
    {
        string createObjectURL(object _object, ObjectURLOptions options = null);

        void revokeObjectURL(string url);
    }

    public partial interface XMLHttpRequestEventTarget : EventTarget
    {
        Func<UIEvent, object> onabort { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onload { get; set; }

        Func<ProgressEvent, object> onloadend { get; set; }

        Func<Event, object> onloadstart { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<Event, object> ontimeout { get; set; }
    }

    public partial interface IDBEnvironment
    {
        IDBFactory indexedDB { get; set; }

        IDBFactory msIndexedDB { get; set; }
    }

    public partial interface AudioTrackList : EventTarget
    {
        AudioTrack this[int index] { get; set; }

        int Length { get; set; }

        Func<TrackEvent, object> onaddtrack { get; set; }

        Func<Event, object> onchange { get; set; }

        Func<object, object> onremovetrack { get; set; }

        AudioTrack getTrackById(string id);

        AudioTrack item(int index);
    }

    public partial interface MSBaseReader : EventTarget
    {
        int DONE { get; set; }

        int EMPTY { get; set; }

        int LOADING { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onload { get; set; }

        Func<ProgressEvent, object> onloadend { get; set; }

        Func<Event, object> onloadstart { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        int readyState { get; set; }

        object result { get; set; }

        void abort();
    }

    public partial interface SVGFEMorphologyElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_MORPHOLOGY_OPERATOR_DILATE { get; set; }

        int SVG_MORPHOLOGY_OPERATOR_ERODE { get; set; }

        int SVG_MORPHOLOGY_OPERATOR_UNKNOWN { get; set; }

        SVGAnimatedEnumeration _operator { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedNumber radiusX { get; set; }

        SVGAnimatedNumber radiusY { get; set; }
    }

    public partial interface SVGFEFuncRElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface WindowTimersExtension
    {
        void clearImmediate(int handle);

        void msClearImmediate(int handle);

        int msSetImmediate(object expression, params object[] args);

        int setImmediate(object expression, params object[] args);
    }

    public partial interface SVGFEDisplacementMapElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_CHANNEL_A { get; set; }

        int SVG_CHANNEL_B { get; set; }

        int SVG_CHANNEL_G { get; set; }

        int SVG_CHANNEL_R { get; set; }

        int SVG_CHANNEL_UNKNOWN { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedString in2 { get; set; }

        SVGAnimatedNumber scale { get; set; }

        SVGAnimatedEnumeration xChannelSelector { get; set; }

        SVGAnimatedEnumeration yChannelSelector { get; set; }
    }

    public partial interface AnimationEvent : Event
    {
        string animationName { get; set; }

        int elapsedTime { get; set; }

        void initAnimationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string animationNameArg, int elapsedTimeArg);
    }

    public partial interface SVGComponentTransferFunctionElement : SVGElement
    {
        int SVG_FECOMPONENTTRANSFER_TYPE_DISCRETE { get; set; }

        int SVG_FECOMPONENTTRANSFER_TYPE_GAMMA { get; set; }

        int SVG_FECOMPONENTTRANSFER_TYPE_IDENTITY { get; set; }

        int SVG_FECOMPONENTTRANSFER_TYPE_LINEAR { get; set; }

        int SVG_FECOMPONENTTRANSFER_TYPE_TABLE { get; set; }

        int SVG_FECOMPONENTTRANSFER_TYPE_UNKNOWN { get; set; }

        SVGAnimatedNumber amplitude { get; set; }

        SVGAnimatedNumber exponent { get; set; }

        SVGAnimatedNumber intercept { get; set; }

        SVGAnimatedNumber offset { get; set; }

        SVGAnimatedNumber slope { get; set; }

        SVGAnimatedNumberList tableValues { get; set; }

        SVGAnimatedEnumeration type { get; set; }
    }

    public partial interface MSRangeCollection
    {
        Range this[int index] { get; set; }

        int Length { get; set; }

        Range item(int index);
    }

    public partial interface SVGFEDistantLightElement : SVGElement
    {
        SVGAnimatedNumber azimuth { get; set; }

        SVGAnimatedNumber elevation { get; set; }
    }

    public partial interface SVGFEFuncBElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface IDBKeyRange
    {
        object lower { get; set; }

        bool lowerOpen { get; set; }

        object upper { get; set; }

        bool upperOpen { get; set; }
    }

    public partial interface WindowConsole
    {
        Console console { get; set; }
    }

    public partial interface IDBTransaction : EventTarget
    {
        string READ_ONLY { get; set; }

        string READ_WRITE { get; set; }

        string VERSION_CHANGE { get; set; }

        IDBDatabase db { get; set; }

        DOMError error { get; set; }

        string mode { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<Event, object> oncomplete { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        void abort();

        IDBObjectStore objectStore(string name);
    }

    public partial interface AudioTrack
    {
        bool enabled { get; set; }

        string id { get; set; }

        string kind { get; set; }

        string label { get; set; }

        string language { get; set; }

        SourceBuffer sourceBuffer { get; set; }
    }

    public partial interface SVGFEConvolveMatrixElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_EDGEMODE_DUPLICATE { get; set; }

        int SVG_EDGEMODE_NONE { get; set; }

        int SVG_EDGEMODE_UNKNOWN { get; set; }

        int SVG_EDGEMODE_WRAP { get; set; }

        SVGAnimatedNumber bias { get; set; }

        SVGAnimatedNumber divisor { get; set; }

        SVGAnimatedEnumeration edgeMode { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedNumberList kernelMatrix { get; set; }

        SVGAnimatedNumber kernelUnitLengthX { get; set; }

        SVGAnimatedNumber kernelUnitLengthY { get; set; }

        SVGAnimatedInteger orderX { get; set; }

        SVGAnimatedInteger orderY { get; set; }

        SVGAnimatedBoolean preserveAlpha { get; set; }

        SVGAnimatedInteger targetX { get; set; }

        SVGAnimatedInteger targetY { get; set; }
    }

    public partial interface TextTrackCueList
    {
        TextTrackCue this[int index] { get; set; }

        int Length { get; set; }

        TextTrackCue getCueById(string id);

        TextTrackCue item(int index);
    }

    public partial interface CSSKeyframesRule : CSSRule
    {
        CSSRuleList cssRules { get; set; }

        string name { get; set; }

        void appendRule(string rule);

        void deleteRule(string rule);

        CSSKeyframeRule findRule(string rule);
    }

    public partial interface SVGFETurbulenceElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_STITCHTYPE_NOSTITCH { get; set; }

        int SVG_STITCHTYPE_STITCH { get; set; }

        int SVG_STITCHTYPE_UNKNOWN { get; set; }

        int SVG_TURBULENCE_TYPE_FRACTALNOISE { get; set; }

        int SVG_TURBULENCE_TYPE_TURBULENCE { get; set; }

        int SVG_TURBULENCE_TYPE_UNKNOWN { get; set; }

        SVGAnimatedNumber baseFrequencyX { get; set; }

        SVGAnimatedNumber baseFrequencyY { get; set; }

        SVGAnimatedInteger numOctaves { get; set; }

        SVGAnimatedNumber seed { get; set; }

        SVGAnimatedEnumeration stitchTiles { get; set; }

        SVGAnimatedEnumeration type { get; set; }
    }

    public partial interface TextTrackList : EventTarget
    {
        TextTrack this[int index] { get; set; }

        int Length { get; set; }

        Func<TrackEvent, object> onaddtrack { get; set; }

        TextTrack item(int index);
    }

    public partial interface SVGFEFuncGElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface SVGFEColorMatrixElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_FECOLORMATRIX_TYPE_HUEROTATE { get; set; }

        int SVG_FECOLORMATRIX_TYPE_LUMINANCETOALPHA { get; set; }

        int SVG_FECOLORMATRIX_TYPE_MATRIX { get; set; }

        int SVG_FECOLORMATRIX_TYPE_SATURATE { get; set; }

        int SVG_FECOLORMATRIX_TYPE_UNKNOWN { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedEnumeration type { get; set; }

        SVGAnimatedNumberList values { get; set; }
    }

    public partial interface SVGFESpotLightElement : SVGElement
    {
        SVGAnimatedNumber limitingConeAngle { get; set; }

        SVGAnimatedNumber pointsAtX { get; set; }

        SVGAnimatedNumber pointsAtY { get; set; }

        SVGAnimatedNumber pointsAtZ { get; set; }

        SVGAnimatedNumber specularExponent { get; set; }

        SVGAnimatedNumber x { get; set; }

        SVGAnimatedNumber y { get; set; }

        SVGAnimatedNumber z { get; set; }
    }

    public partial interface WindowBase64
    {
        string atob(string encodedString);

        string btoa(string rawString);
    }

    public partial interface IDBDatabase : EventTarget
    {
        string name { get; set; }

        DOMStringList objectStoreNames { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        string version { get; set; }

        void close();

        IDBObjectStore createObjectStore(string name, object optionalParameters = null);

        void deleteObjectStore(string name);

        IDBTransaction transaction(object storeNames, string mode = null);
    }

    public partial interface DOMStringList
    {
        string this[int index] { get; set; }

        int Length { get; set; }

        bool contains(string str);

        string item(int index);
    }

    public partial interface IDBOpenDBRequest : IDBRequest
    {
        Func<Event, object> onblocked { get; set; }

        Func<IDBVersionChangeEvent, object> onupgradeneeded { get; set; }
    }

    public partial interface HTMLProgressElement : HTMLElement
    {
        int Max { get; set; }

        HTMLFormElement form { get; set; }

        int position { get; set; }

        int value { get; set; }
    }

    public delegate void MSLaunchUriCallback();

    public partial interface SVGFEOffsetElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber dx { get; set; }

        SVGAnimatedNumber dy { get; set; }

        SVGAnimatedString in1 { get; set; }
    }

    public delegate object MSUnsafeFunctionCallback();

    public partial interface TextTrack : EventTarget
    {
        int DISABLED { get; set; }

        int ERROR { get; set; }

        int HIDDEN { get; set; }

        int LOADED { get; set; }

        int LOADING { get; set; }

        int NONE { get; set; }

        int SHOWING { get; set; }

        TextTrackCueList activeCues { get; set; }

        TextTrackCueList cues { get; set; }

        string kind { get; set; }

        string label { get; set; }

        string language { get; set; }

        object mode { get; set; }

        Func<Event, object> oncuechange { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onload { get; set; }

        int readyState { get; set; }

        void addCue(TextTrackCue cue);

        void removeCue(TextTrackCue cue);
    }

    public delegate void MediaQueryListListener(MediaQueryList mql);

    public partial interface IDBRequest : EventTarget
    {
        DOMError error { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onsuccess { get; set; }

        string readyState { get; set; }

        object result { get; set; }

        object source { get; set; }

        IDBTransaction transaction { get; set; }
    }

    public partial interface MessagePort : EventTarget
    {
        Func<MessageEvent, object> onmessage { get; set; }

        void close();

        void postMessage(object message = null, object ports = null);

        void start();
    }

    public partial interface FileReader : MSBaseReader
    {
        DOMError error { get; set; }

        void readAsArrayBuffer(Blob blob);

        void readAsDataURL(Blob blob);

        void readAsText(Blob blob, string encoding = null);
    }

    public partial interface Blob
    {
        int size { get; set; }

        string type { get; set; }

        void msClose();

        object msDetachStream();

        Blob slice(int start = 0, int end = 0, string contentType = null);
    }

    public partial interface ApplicationCache : EventTarget
    {
        int CHECKING { get; set; }

        int DOWNLOADING { get; set; }

        int IDLE { get; set; }

        int OBSOLETE { get; set; }

        int UNCACHED { get; set; }

        int UPDATEREADY { get; set; }

        Func<Event, object> oncached { get; set; }

        Func<Event, object> onchecking { get; set; }

        Func<Event, object> ondownloading { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<Event, object> onnoupdate { get; set; }

        Func<Event, object> onobsolete { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        Func<Event, object> onupdateready { get; set; }

        int status { get; set; }

        void abort();

        void swapCache();

        void update();
    }

    public delegate void FrameRequestCallback(int time);

    public partial interface PopStateEvent : Event
    {
        object state { get; set; }

        void initPopStateEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object stateArg);
    }

    public partial interface CSSKeyframeRule : CSSRule
    {
        string keyText { get; set; }

        CSSStyleDeclaration style { get; set; }
    }

    public partial interface MSFileSaver
    {
        bool msSaveBlob(object blob, string defaultName = null);

        bool msSaveOrOpenBlob(object blob, string defaultName = null);
    }

    public partial interface MSStream
    {
        string type { get; set; }

        void msClose();

        object msDetachStream();
    }

    public partial interface MSBlobBuilder
    {
        void append(object data, string endings = null);

        Blob getBlob(string contentType = null);
    }

    public partial interface DOMSettableTokenList : DOMTokenList
    {
        string value { get; set; }
    }

    public partial interface IDBFactory
    {
        int cmp(object first, object second);

        IDBOpenDBRequest deleteDatabase(string name);

        IDBOpenDBRequest open(string name, int version = 0);
    }

    public partial interface MSPointerEvent : MouseEvent
    {
        int MSPOINTER_TYPE_MOUSE { get; set; }

        int MSPOINTER_TYPE_PEN { get; set; }

        int MSPOINTER_TYPE_TOUCH { get; set; }

        object currentPoint { get; set; }

        int height { get; set; }

        int hwTimestamp { get; set; }

        object intermediatePoints { get; set; }

        bool isPrimary { get; set; }

        int pointerId { get; set; }

        object pointerType { get; set; }

        int pressure { get; set; }

        int rotation { get; set; }

        int tiltX { get; set; }

        int tiltY { get; set; }

        int width { get; set; }

        void getCurrentPoint(Element element);

        void getIntermediatePoints(Element element);

        void initPointerEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            int buttonArg,
            EventTarget relatedTargetArg,
            int offsetXArg,
            int offsetYArg,
            double widthArg,
            int heightArg,
            int pressure,
            int rotation,
            int tiltX,
            int tiltY,
            int pointerIdArg,
            object pointerType,
            int hwTimestampArg,
            bool isPrimary);
    }

    public partial interface MSManipulationEvent : UIEvent
    {
        int MS_MANIPULATION_STATE_ACTIVE { get; set; }

        int MS_MANIPULATION_STATE_CANCELLED { get; set; }

        int MS_MANIPULATION_STATE_COMMITTED { get; set; }

        int MS_MANIPULATION_STATE_DRAGGING { get; set; }

        int MS_MANIPULATION_STATE_INERTIA { get; set; }

        int MS_MANIPULATION_STATE_PRESELECT { get; set; }

        int MS_MANIPULATION_STATE_SELECTING { get; set; }

        int MS_MANIPULATION_STATE_STOPPED { get; set; }

        int currentState { get; set; }

        int lastState { get; set; }

        void initMSManipulationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, int detailArg, int lastState, int currentState);
    }

    public partial interface FormData
    {
        void append(object name, object value, string blobName = null);
    }

    public partial interface HTMLDataListElement : HTMLElement
    {
        HTMLCollection options { get; set; }
    }

    public partial interface SVGFEImageElement : SVGElement, SVGLangSpace, SVGFilterPrimitiveStandardAttributes, SVGURIReference, SVGExternalResourcesRequired
    {
        SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; set; }
    }

    public partial interface AbstractWorker : EventTarget
    {
        Func<ErrorEvent, object> onerror { get; set; }
    }

    public partial interface SVGFECompositeElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        int SVG_FECOMPOSITE_OPERATOR_ARITHMETIC { get; set; }

        int SVG_FECOMPOSITE_OPERATOR_ATOP { get; set; }

        int SVG_FECOMPOSITE_OPERATOR_IN { get; set; }

        int SVG_FECOMPOSITE_OPERATOR_OUT { get; set; }

        int SVG_FECOMPOSITE_OPERATOR_OVER { get; set; }

        int SVG_FECOMPOSITE_OPERATOR_UNKNOWN { get; set; }

        int SVG_FECOMPOSITE_OPERATOR_XOR { get; set; }

        SVGAnimatedEnumeration _operator { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedString in2 { get; set; }

        SVGAnimatedNumber k1 { get; set; }

        SVGAnimatedNumber k2 { get; set; }

        SVGAnimatedNumber k3 { get; set; }

        SVGAnimatedNumber k4 { get; set; }
    }

    public partial interface ValidityState
    {
        bool customError { get; set; }

        bool patternMismatch { get; set; }

        bool rangeOverflow { get; set; }

        bool rangeUnderflow { get; set; }

        bool stepMismatch { get; set; }

        bool tooLong { get; set; }

        bool typeMismatch { get; set; }

        bool valid { get; set; }

        bool valueMissing { get; set; }
    }

    public partial interface HTMLTrackElement : HTMLElement
    {
        int ERROR { get; set; }

        int LOADED { get; set; }

        int LOADING { get; set; }

        int NONE { get; set; }

        bool _default { get; set; }

        string kind { get; set; }

        string label { get; set; }

        string src { get; set; }

        string srclang { get; set; }

        TextTrack track { get; set; }
    }

    public partial interface MSApp
    {
        string CURRENT { get; set; }

        string HIGH { get; set; }

        string IDLE { get; set; }

        string NORMAL { get; set; }

        void addPublicLocalApplicationUri(string uri);

        Blob createBlobFromRandomAccessStream(string type, object seeker);

        object createDataPackage(object _object);

        object createDataPackageFromSelection();

        File createFileFromStorageFile(object storageFile);

        MSAppView createNewView(string uri);

        MSStream createStreamFromInputStream(string type, object inputStream);

        void execAsyncAtPriority(MSExecAtPriorityFunctionCallback asynchronousCallback, string priority, params object[] args);

        object execAtPriority(MSExecAtPriorityFunctionCallback synchronousCallback, string priority, params object[] args);

        object execUnsafeLocalFunction(MSUnsafeFunctionCallback unsafeFunction);

        string getCurrentPriority();

        object getHtmlPrintDocumentSource(object htmlDoc);

        MSAppView getViewOpener();

        bool isTaskScheduledAtPriorityOrHigher(string priority);

        void suppressSubdownloadCredentialPrompts(bool suppress);

        void terminateApp(object exceptionObject);
    }

    public partial interface SVGFEDiffuseLightingElement : SVGElement, SVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber diffuseConstant { get; set; }

        SVGAnimatedString in1 { get; set; }

        SVGAnimatedNumber kernelUnitLengthX { get; set; }

        SVGAnimatedNumber kernelUnitLengthY { get; set; }

        SVGAnimatedNumber surfaceScale { get; set; }
    }

    public partial interface MSCSSMatrix
    {
        int a { get; set; }

        int b { get; set; }

        int c { get; set; }

        int d { get; set; }

        int e { get; set; }

        int f { get; set; }

        int m11 { get; set; }

        int m12 { get; set; }

        int m13 { get; set; }

        int m14 { get; set; }

        int m21 { get; set; }

        int m22 { get; set; }

        int m23 { get; set; }

        int m24 { get; set; }

        int m31 { get; set; }

        int m32 { get; set; }

        int m33 { get; set; }

        int m34 { get; set; }

        int m41 { get; set; }

        int m42 { get; set; }

        int m43 { get; set; }

        int m44 { get; set; }

        string ToString();

        MSCSSMatrix inverse();

        MSCSSMatrix multiply(MSCSSMatrix secondMatrix);

        MSCSSMatrix rotate(int angleX, int angleY = 0, int angleZ = 0);

        MSCSSMatrix rotateAxisAngle(double x, double y, double z, int angle);

        MSCSSMatrix scale(int scaleX, int scaleY = 0, int scaleZ = 0);

        void setMatrixValue(string value);

        MSCSSMatrix skewX(int angle);

        MSCSSMatrix skewY(int angle);

        MSCSSMatrix translate(double x, double y, double z = 0);
    }

    public partial interface Worker : AbstractWorker
    {
        Func<MessageEvent, object> onmessage { get; set; }

        void postMessage(object message, object ports = null);

        void terminate();
    }

    public delegate object MSExecAtPriorityFunctionCallback(params object[] args);

    public partial interface MSGraphicsTrust
    {
        bool constrictionActive { get; set; }

        string status { get; set; }
    }

    public partial interface SubtleCrypto
    {
        CryptoOperation decrypt(object algorithm, Key key, ArrayBufferView buffer = null);

        KeyOperation deriveKey(object algorithm, Key baseKey, object derivedKeyType, bool extractable = false, Array<string> keyUsages = null);

        CryptoOperation digest(object algorithm, ArrayBufferView buffer = null);

        CryptoOperation encrypt(object algorithm, Key key, ArrayBufferView buffer = null);

        KeyOperation exportKey(string format, Key key);

        KeyOperation generateKey(object algorithm, bool extractable = false, Array<string> keyUsages = null);

        KeyOperation importKey(string format, ArrayBufferView keyData, object algorithm, bool extractable = false, Array<string> keyUsages = null);

        CryptoOperation sign(object algorithm, Key key, ArrayBufferView buffer = null);

        KeyOperation unwrapKey(ArrayBufferView wrappedKey, object keyAlgorithm, Key keyEncryptionKey, bool extractable = false, Array<string> keyUsages = null);

        CryptoOperation verify(object algorithm, Key key, ArrayBufferView signature, ArrayBufferView buffer = null);

        KeyOperation wrapKey(Key key, Key keyEncryptionKey, object keyWrappingAlgorithm);
    }

    public partial interface Crypto : RandomSource
    {
        SubtleCrypto subtle { get; set; }
    }

    public partial interface VideoPlaybackQuality
    {
        int creationTime { get; set; }

        int droppedVideoFrames { get; set; }

        int totalFrameDelay { get; set; }

        int totalVideoFrames { get; set; }
    }

    public partial interface GlobalEventHandlers
    {
        Func<PointerEvent, object> onpointercancel { get; set; }

        Func<PointerEvent, object> onpointerdown { get; set; }

        Func<PointerEvent, object> onpointerenter { get; set; }

        Func<PointerEvent, object> onpointerleave { get; set; }

        Func<PointerEvent, object> onpointermove { get; set; }

        Func<PointerEvent, object> onpointerout { get; set; }

        Func<PointerEvent, object> onpointerover { get; set; }

        Func<PointerEvent, object> onpointerup { get; set; }
    }

    public partial interface Key
    {
        Algorithm algorithm { get; set; }

        bool extractable { get; set; }

        Array<string> keyUsage { get; set; }

        string type { get; set; }
    }

    public partial interface DeviceAcceleration
    {
        double x { get; set; }

        double y { get; set; }

        double z { get; set; }
    }

    public partial interface HTMLAllCollection : HTMLCollection
    {
    }

    public partial interface AesGcmEncryptResult
    {
        ArrayBuffer ciphertext { get; set; }

        ArrayBuffer tag { get; set; }
    }

    public partial interface NavigationCompletedEvent : NavigationEvent
    {
        bool isSuccess { get; set; }

        double webErrorStatus { get; set; }
    }

    public partial interface MutationRecord
    {
        NodeList addedNodes { get; set; }

        string attributeName { get; set; }

        string attributeNamespace { get; set; }

        Node nextSibling { get; set; }

        string oldValue { get; set; }

        Node previousSibling { get; set; }

        NodeList removedNodes { get; set; }

        Node target { get; set; }

        string type { get; set; }
    }

    public partial interface MimeTypeArray
    {
        Plugin this[int index] { get; set; }

        int Length { get; set; }

        Plugin item(int index);

        Plugin namedItem(string type);
    }

    public partial interface KeyOperation : EventTarget
    {
        Func<Event, object> oncomplete { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        object result { get; set; }
    }

    public partial interface DOMStringMap
    {
    }

    public partial interface DeviceOrientationEvent : Event
    {
        bool absolute { get; set; }

        int alpha { get; set; }

        int beta { get; set; }

        int gamma { get; set; }

        void initDeviceOrientationEvent(string type, bool bubbles, bool cancelable, int alpha, int beta, int gamma, bool absolute);
    }

    public partial interface MSMediaKeys
    {
        string keySystem { get; set; }

        MSMediaKeySession createSession(string type, Uint8Array initData, Uint8Array cdmData = null);
    }

    public partial interface MSMediaKeyMessageEvent : Event
    {
        string destinationURL { get; set; }

        Uint8Array message { get; set; }
    }

    public partial interface MSHTMLWebViewElement : HTMLElement
    {
        bool canGoBack { get; set; }

        bool canGoForward { get; set; }

        string documentTitle { get; set; }

        int height { get; set; }

        string src { get; set; }

        int width { get; set; }

        string buildLocalStreamUri(string contentIdentifier, string relativePath);

        MSWebViewAsyncOperation capturePreviewToBlobAsync();

        MSWebViewAsyncOperation captureSelectedContentToDataPackageAsync();

        void goBack();

        void goForward();

        MSWebViewAsyncOperation invokeScriptAsync(string scriptName, params object[] args);

        void navigate(string uri);

        void navigateToLocalStreamUri(string source, object streamResolver);

        void navigateToString(string contents);

        void navigateWithHttpRequestMessage(object requestMessage);

        void refresh();

        void stop();
    }

    public partial interface NavigationEvent : Event
    {
        string uri { get; set; }
    }

    public partial interface RandomSource
    {
        ArrayBufferView getRandomValues(ArrayBufferView array);
    }

    public partial interface SourceBuffer : EventTarget
    {
        int appendWindowEnd { get; set; }

        int appendWindowStart { get; set; }

        AudioTrackList audioTracks { get; set; }

        TimeRanges buffered { get; set; }

        int timestampOffset { get; set; }

        bool updating { get; set; }

        void abort();

        void appendBuffer(ArrayBuffer data);

        void appendStream(MSStream stream, int maxSize = 0);

        void remove(int start, int end);
    }

    public partial interface MSInputMethodContext : EventTarget
    {
        int compositionEndOffset { get; set; }

        int compositionStartOffset { get; set; }

        Func<object, object> oncandidatewindowhide { get; set; }

        Func<object, object> oncandidatewindowshow { get; set; }

        Func<object, object> oncandidatewindowupdate { get; set; }

        HTMLElement target { get; set; }

        ClientRect getCandidateWindowClientRect();

        Array<string> getCompositionAlternatives();

        bool hasComposition();

        bool isCandidateWindowVisible();
    }

    public partial interface DeviceRotationRate
    {
        int alpha { get; set; }

        int beta { get; set; }

        int gamma { get; set; }
    }

    public partial interface PluginArray
    {
        Plugin this[int index] { get; set; }

        int Length { get; set; }

        Plugin item(int index);

        Plugin namedItem(string name);

        void refresh(bool reload = false);
    }

    public partial interface MSMediaKeyError
    {
        int MS_MEDIA_KEYERR_CLIENT { get; set; }

        int MS_MEDIA_KEYERR_DOMAIN { get; set; }

        int MS_MEDIA_KEYERR_HARDWARECHANGE { get; set; }

        int MS_MEDIA_KEYERR_OUTPUT { get; set; }

        int MS_MEDIA_KEYERR_SERVICE { get; set; }

        int MS_MEDIA_KEYERR_UNKNOWN { get; set; }

        int code { get; set; }

        int systemCode { get; set; }
    }

    public partial interface Plugin
    {
        MimeType this[int index] { get; set; }

        int Length { get; set; }

        string description { get; set; }

        string filename { get; set; }

        string name { get; set; }

        string version { get; set; }

        MimeType item(int index);

        MimeType namedItem(string type);
    }

    public partial interface MediaSource : EventTarget
    {
        SourceBufferList activeSourceBuffers { get; set; }

        int duration { get; set; }

        string readyState { get; set; }

        SourceBufferList sourceBuffers { get; set; }

        SourceBuffer addSourceBuffer(string type);

        void endOfStream(string error = null);

        void removeSourceBuffer(SourceBuffer sourceBuffer);
    }

    public partial interface SourceBufferList : EventTarget
    {
        SourceBuffer this[int index] { get; set; }

        int Length { get; set; }

        SourceBuffer item(int index);
    }

    public partial interface XMLDocument : Document
    {
    }

    public partial interface DeviceMotionEvent : Event
    {
        DeviceAcceleration acceleration { get; set; }

        DeviceAcceleration accelerationIncludingGravity { get; set; }

        int interval { get; set; }

        DeviceRotationRate rotationRate { get; set; }

        void initDeviceMotionEvent(
            string type,
            bool bubbles,
            bool cancelable,
            DeviceAccelerationDict acceleration,
            DeviceAccelerationDict accelerationIncludingGravity,
            DeviceRotationRateDict rotationRate,
            int interval);
    }

    public partial interface MimeType
    {
        string description { get; set; }

        Plugin enabledPlugin { get; set; }

        string suffixes { get; set; }

        string type { get; set; }
    }

    public partial interface PointerEvent : MouseEvent
    {
        object currentPoint { get; set; }

        int height { get; set; }

        int hwTimestamp { get; set; }

        object intermediatePoints { get; set; }

        bool isPrimary { get; set; }

        int pointerId { get; set; }

        object pointerType { get; set; }

        int pressure { get; set; }

        int rotation { get; set; }

        int tiltX { get; set; }

        int tiltY { get; set; }

        int width { get; set; }

        void getCurrentPoint(Element element);

        void getIntermediatePoints(Element element);

        void initPointerEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            int detailArg,
            int screenXArg,
            int screenYArg,
            int clientXArg,
            int clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            int buttonArg,
            EventTarget relatedTargetArg,
            int offsetXArg,
            int offsetYArg,
            double widthArg,
            int heightArg,
            int pressure,
            int rotation,
            int tiltX,
            int tiltY,
            int pointerIdArg,
            object pointerType,
            int hwTimestampArg,
            bool isPrimary);
    }

    public partial interface MSDocumentExtensions
    {
        void captureEvents();

        void releaseEvents();
    }

    public partial interface MutationObserver
    {
        void disconnect();

        void observe(Node target, MutationObserverInit options);

        Array<MutationRecord> takeRecords();
    }

    public partial interface MSWebViewAsyncOperation : EventTarget
    {
        int COMPLETED { get; set; }

        int ERROR { get; set; }

        int STARTED { get; set; }

        int TYPE_CAPTURE_PREVIEW_TO_RANDOM_ACCESS_STREAM { get; set; }

        int TYPE_CREATE_DATA_PACKAGE_FROM_SELECTION { get; set; }

        int TYPE_INVOKE_SCRIPT { get; set; }

        DOMError error { get; set; }

        Func<Event, object> oncomplete { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        int readyState { get; set; }

        object result { get; set; }

        MSHTMLWebViewElement target { get; set; }

        int type { get; set; }

        void start();
    }

    public partial interface ScriptNotifyEvent : Event
    {
        string callingUri { get; set; }

        string value { get; set; }
    }

    public partial interface PerformanceNavigationTiming : PerformanceEntry
    {
        int connectEnd { get; set; }

        int connectStart { get; set; }

        int domComplete { get; set; }

        int domContentLoadedEventEnd { get; set; }

        int domContentLoadedEventStart { get; set; }

        int domInteractive { get; set; }

        int domLoading { get; set; }

        int domainLookupEnd { get; set; }

        int domainLookupStart { get; set; }

        int fetchStart { get; set; }

        int loadEventEnd { get; set; }

        int loadEventStart { get; set; }

        int navigationStart { get; set; }

        int redirectCount { get; set; }

        int redirectEnd { get; set; }

        int redirectStart { get; set; }

        int requestStart { get; set; }

        int responseEnd { get; set; }

        int responseStart { get; set; }

        string type { get; set; }

        int unloadEventEnd { get; set; }

        int unloadEventStart { get; set; }
    }

    public partial interface MSMediaKeyNeededEvent : Event
    {
        Uint8Array initData { get; set; }
    }

    public partial interface LongRunningScriptDetectedEvent : Event
    {
        int executionTime { get; set; }

        bool stopPageScriptExecution { get; set; }
    }

    public partial interface MSAppView
    {
        int viewId { get; set; }

        void close();

        void postMessage(object message, string targetOrigin, object ports = null);
    }

    public partial interface PerfWidgetExternal
    {
        int activeNetworkRequestCount { get; set; }

        int averageFrameTime { get; set; }

        int averagePaintTime { get; set; }

        bool extraInformationEnabled { get; set; }

        bool independentRenderingEnabled { get; set; }

        string irDisablingContentString { get; set; }

        bool irStatusAvailable { get; set; }

        int maxCpuSpeed { get; set; }

        int paintRequestsPerSecond { get; set; }

        int performanceCounter { get; set; }

        int performanceCounterFrequency { get; set; }

        void addEventListener(string eventType, Func<object, object> callback);

        int getMemoryUsage();

        int getProcessCpuUsage();

        object getRecentCpuUsage(int last);

        object getRecentFrames(int last);

        object getRecentMemoryUsage(int last);

        object getRecentPaintRequests(int last);

        void removeEventListener(string eventType, Func<object, object> callback);

        void repositionWindow(double x, double y);

        void resizeWindow(int width, int height);
    }

    public partial interface PageTransitionEvent : Event
    {
        bool persisted { get; set; }
    }

    public delegate void MutationCallback(Array<MutationRecord> mutations, MutationObserver observer);

    public partial interface HTMLDocument : Document
    {
    }

    public partial interface KeyPair
    {
        Key privateKey { get; set; }

        Key publicKey { get; set; }
    }

    public partial interface MSMediaKeySession : EventTarget
    {
        MSMediaKeyError error { get; set; }

        string keySystem { get; set; }

        string sessionId { get; set; }

        void close();

        void update(Uint8Array key);
    }

    public partial interface UnviewableContentIdentifiedEvent : NavigationEvent
    {
        string referrer { get; set; }
    }

    public partial interface CryptoOperation : EventTarget
    {
        Algorithm algorithm { get; set; }

        Key key { get; set; }

        Func<UIEvent, object> onabort { get; set; }

        Func<Event, object> oncomplete { get; set; }

        Func<ErrorEvent, object> onerror { get; set; }

        Func<ProgressEvent, object> onprogress { get; set; }

        object result { get; set; }

        void abort();

        void finish();

        void process(ArrayBufferView buffer);
    }

    public partial interface WebGLTexture : WebGLObject
    {
        int _baseHeight { get; set; }

        int _baseWidth { get; set; }

        int _cachedCoordinatesMode { get; set; }

        int _cachedWrapU { get; set; }

        int _cachedWrapV { get; set; }

        WebGLRenderbuffer _depthBuffer { get; set; }

        WebGLFramebuffer _framebuffer { get; set; }

        int _height { get; set; }

        // hack for width and hight
        int _size { get; set; }

        int _width { get; set; }

        HTMLCanvasElement _workingCanvas { get; set; }

        CanvasRenderingContext2D _workingContext { get; set; }

        bool generateMipMaps { get; set; }

        bool isCube { get; set; }

        bool isReady { get; set; }

        bool noMipmap { get; set; }

        int references { get; set; }

        string url { get; set; }
    }

    public partial interface OES_texture_float
    {
    }

    public partial interface WebGLContextEvent : Event
    {
        string statusMessage { get; set; }
    }

    public partial interface WebGLRenderbuffer : WebGLObject
    {
    }

    public partial interface WebGLUniformLocation
    {
        int Value { get; }
    }

    public partial interface WebGLActiveInfo
    {
        string name { get; set; }

        int size { get; set; }

        int type { get; set; }
    }

    public partial interface WEBGL_compressed_texture_s3tc
    {
        int COMPRESSED_RGBA_S3TC_DXT1_EXT { get; set; }

        int COMPRESSED_RGBA_S3TC_DXT3_EXT { get; set; }

        int COMPRESSED_RGBA_S3TC_DXT5_EXT { get; set; }

        int COMPRESSED_RGB_S3TC_DXT1_EXT { get; set; }
    }

    public partial interface WebGLRenderingContext
    {
        int this[string enumName] { get; }

        HTMLCanvasElement canvas { get; set; }

        int drawingBufferHeight { get; set; }

        int drawingBufferWidth { get; set; }

        void activeTexture(int texture);

        void attachShader(WebGLProgram program, WebGLShader shader);

        void bindAttribLocation(WebGLProgram program, int index, string name);

        void bindBuffer(int target, WebGLBuffer buffer);

        void bindFramebuffer(int target, WebGLFramebuffer framebuffer);

        void bindRenderbuffer(int target, WebGLRenderbuffer renderbuffer);

        void bindTexture(int target, WebGLTexture texture);

        void blendColor(int red, int green, int blue, int alpha);

        void blendEquation(int mode);

        void blendEquationSeparate(int modeRGB, int modeAlpha);

        void blendFunc(int sfactor, int dfactor);

        void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);

        void bufferData(int target, float[] data, int usage);

        void bufferData(int target, ushort[] data, int usage);

        void bufferData(int target, int size, int usage);

        void bufferSubData(int target, int offset, float[] data);

        void bufferSubData(int target, int offset, int size, IntPtr data);

        int checkFramebufferStatus(int target);

        void clear(int mask);

        void clearColor(double red, double green, double blue, double alpha);

        void clearDepth(double depth);

        void clearStencil(int s);

        void colorMask(bool red, bool green, bool blue, bool alpha);

        void compileShader(WebGLShader shader);

        void compressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, byte[] data);

        void compressedTexSubImage2D(int target, int level, double xoffset, double yoffset, int width, int height, int format, ArrayBufferView data);

        void copyTexImage2D(int target, int level, int internalformat, double x, double y, int width, int height, int border);

        void copyTexSubImage2D(int target, int level, double xoffset, double yoffset, double x, double y, int width, int height);

        WebGLBuffer createBuffer();

        WebGLFramebuffer createFramebuffer();

        WebGLProgram createProgram();

        WebGLRenderbuffer createRenderbuffer();

        WebGLShader createShader(int type);

        WebGLTexture createTexture();

        void cullFace(int mode);

        void deleteBuffer(WebGLBuffer buffer);

        void deleteFramebuffer(WebGLFramebuffer framebuffer);

        void deleteProgram(WebGLProgram program);

        void deleteRenderbuffer(WebGLRenderbuffer renderbuffer);

        void deleteShader(WebGLShader shader);

        void deleteTexture(WebGLTexture texture);

        void depthFunc(int func);

        void depthMask(bool flag);

        void depthRange(double zNear, double zFar);

        void detachShader(WebGLProgram program, WebGLShader shader);

        void disable(int cap);

        void disableVertexAttribArray(int index);

        void drawArrays(int mode, int first, int count);

        void drawElements(int mode, int count, int type, int offset);

        void enable(int cap);

        void enableVertexAttribArray(int index);

        void finish();

        void flush();

        void framebufferRenderbuffer(int target, int attachment, int renderbuffertarget, WebGLRenderbuffer renderbuffer);

        void framebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level);

        void frontFace(int mode);

        void generateMipmap(int target);

        WebGLActiveInfo getActiveAttrib(WebGLProgram program, int index);

        WebGLActiveInfo getActiveUniform(WebGLProgram program, int index);

        Array<WebGLShader> getAttachedShaders(WebGLProgram program);

        int getAttribLocation(WebGLProgram program, string name);

        object getBufferParameter(int target, int pname);

        WebGLContextAttributes getContextAttributes();

        int getError();

        object getExtension(string name);

        object getFramebufferAttachmentParameter(int target, int attachment, int pname);

        object getParameter(int pname);

        string getProgramInfoLog(WebGLProgram program);

        object getProgramParameter(WebGLProgram program, int pname);

        object getRenderbufferParameter(int target, int pname);

        string getShaderInfoLog(WebGLShader shader);

        object getShaderParameter(WebGLShader shader, int pname);

        WebGLShaderPrecisionFormat getShaderPrecisionFormat(int shadertype, int precisiontype);

        string getShaderSource(WebGLShader shader);

        Array<string> getSupportedExtensions();

        object getTexParameter(int target, int pname);

        object getUniform(WebGLProgram program, WebGLUniformLocation location);

        WebGLUniformLocation getUniformLocation(WebGLProgram program, string name);

        object getVertexAttrib(int index, int pname);

        int getVertexAttribOffset(int index, int pname);

        void hint(int target, int mode);

        bool isBuffer(WebGLBuffer buffer);

        bool isContextLost();

        bool isEnabled(int cap);

        bool isFramebuffer(WebGLFramebuffer framebuffer);

        bool isProgram(WebGLProgram program);

        bool isRenderbuffer(WebGLRenderbuffer renderbuffer);

        bool isShader(WebGLShader shader);

        bool isTexture(WebGLTexture texture);

        void lineWidth(int width);

        void linkProgram(WebGLProgram program);

        void pixelStorei(int pname, int param);

        void polygonOffset(int factor, int units);

        void readPixels(int x, int y, int width, int height, int format, int type, byte[] pixels);

        void renderbufferStorage(int target, int internalformat, int width, int height);

        void sampleCoverage(int value, bool invert);

        void scissor(int x, int y, int width, int height);

        void shaderSource(WebGLShader shader, string source);

        void stencilFunc(int func, int _ref, int mask);

        void stencilFuncSeparate(int face, int func, int _ref, int mask);

        void stencilMask(int mask);

        void stencilMaskSeparate(int face, int mask);

        void stencilOp(int fail, double zfail, double zpass);

        void stencilOpSeparate(int face, int fail, double zfail, double zpass);

        void texImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels);

        void texImage2D(int target, int level, int internalformat, int format, int type, HTMLImageElement image);

        void texImage2D(int target, int level, int internalformat, int format, int type, HTMLCanvasElement canvas);

        void texImage2D(int target, int level, int internalformat, int format, int type, HTMLVideoElement video);

        void texImage2D(int target, int level, int internalformat, int format, int type, ImageData pixels);

        void texParameterf(int target, int pname, float param);

        void texParameteri(int target, int pname, int param);

        void texSubImage2D(int target, int level, double xoffset, double yoffset, int width, int height, int format, int type, ArrayBufferView pixels);

        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, HTMLImageElement image);

        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, HTMLCanvasElement canvas);

        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, HTMLVideoElement video);

        void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, ImageData pixels);

        void uniform1f(WebGLUniformLocation location, double x);

        void uniform1fv(WebGLUniformLocation location, float[] v);

        void uniform1fv(WebGLUniformLocation location, Float32Array v);

        void uniform1i(WebGLUniformLocation location, int x);

        void uniform1iv(WebGLUniformLocation location, int[] v);

        void uniform1iv(WebGLUniformLocation location, Int32Array v);

        void uniform2f(WebGLUniformLocation location, double x, double y);

        void uniform2fv(WebGLUniformLocation location, float[] v);

        void uniform2fv(WebGLUniformLocation location, Float32Array v);

        void uniform2i(WebGLUniformLocation location, int x, int y);

        void uniform2iv(WebGLUniformLocation location, int[] v);

        void uniform2iv(WebGLUniformLocation location, Int32Array v);

        void uniform3f(WebGLUniformLocation location, double x, double y, double z);

        void uniform3fv(WebGLUniformLocation location, float[] v);

        void uniform3fv(WebGLUniformLocation location, Float32Array v);

        void uniform3i(WebGLUniformLocation location, int x, int y, int z);

        void uniform3iv(WebGLUniformLocation location, int[] v);

        void uniform3iv(WebGLUniformLocation location, Int32Array v);

        void uniform4f(WebGLUniformLocation location, double x, double y, double z, double w);

        void uniform4fv(WebGLUniformLocation location, float[] v);

        void uniform4fv(WebGLUniformLocation location, Float32Array v);

        void uniform4i(WebGLUniformLocation location, int x, int y, int z, int w);

        void uniform4iv(WebGLUniformLocation location, int[] v);

        void uniform4iv(WebGLUniformLocation location, Int32Array v);

        void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, float[] value);

        void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Float32Array value);

        void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, float[] value);

        void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Float32Array value);

        void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, float[] value);

        void useProgram(WebGLProgram program);

        void validateProgram(WebGLProgram program);

        void vertexAttrib1f(int indx, double x);

        void vertexAttrib1fv(int indx, float[] values);

        void vertexAttrib1fv(int indx, Float32Array values);

        void vertexAttrib2f(int indx, double x, double y);

        void vertexAttrib2fv(int indx, float[] values);

        void vertexAttrib2fv(int indx, Float32Array values);

        void vertexAttrib3f(int indx, double x, double y, double z);

        void vertexAttrib3fv(int indx, float[] values);

        void vertexAttrib3fv(int indx, Float32Array values);

        void vertexAttrib4f(int indx, double x, double y, double z, double w);

        void vertexAttrib4fv(int indx, float[] values);

        void vertexAttrib4fv(int indx, Float32Array values);

        void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset);

        void viewport(int x, int y, int width, int height);
    }

    public partial interface WebGLProgram : WebGLObject
    {
    }

    public partial interface OES_standard_derivatives
    {
    }

    public partial interface WebGLFramebuffer : WebGLObject
    {
    }

    public partial interface WebGLShader : WebGLObject
    {
    }

    public partial interface OES_texture_float_linear
    {
    }

    public partial interface WebGLObject
    {
        uint Value { get; }
    }

    public partial interface  WebGLBuffer : WebGLObject
    {
        int capacity { get; set; }

        int references { get; set; }
    }

    public partial interface WebGLShaderPrecisionFormat
    {
        int precision { get; set; }

        int rangeMax { get; set; }

        int rangeMin { get; set; }
    }

    public partial interface EXT_texture_filter_anisotropic
    {
    }
}

namespace Intl
{
    public partial interface CollatorOptions
    {
        string caseFirst { get; set; }

        bool ignorePunctuation { get; set; }

        string localeMatcher { get; set; }

        bool numeric { get; set; }

        string sensitivity { get; set; }

        string usage { get; set; }
    }

    public partial interface ResolvedCollatorOptions
    {
        string caseFirst { get; set; }

        string collation { get; set; }

        bool ignorePunctuation { get; set; }

        string locale { get; set; }

        bool numeric { get; set; }

        string sensitivity { get; set; }

        string usage { get; set; }
    }

    public partial interface Collator
    {
        int compare(string x, string y);

        ResolvedCollatorOptions resolvedOptions();
    }

    public partial interface NumberFormatOptions
    {
        string currency { get; set; }

        string currencyDisplay { get; set; }

        string localeMatcher { get; set; }

        string style { get; set; }

        bool useGrouping { get; set; }
    }

    public partial interface ResolvedNumberFormatOptions
    {
        string currency { get; set; }

        string currencyDisplay { get; set; }

        string locale { get; set; }

        int maximumFractionDigits { get; set; }

        int maximumSignificantDigits { get; set; }

        int minimumFractionDigits { get; set; }

        int minimumSignificantDigits { get; set; }

        int minimumintegerDigits { get; set; }

        string numberingSystem { get; set; }

        string style { get; set; }

        bool useGrouping { get; set; }
    }

    public partial interface NumberFormat
    {
        string format(int value);

        ResolvedNumberFormatOptions resolvedOptions();
    }

    public partial interface DateTimeFormatOptions
    {
        string day { get; set; }

        string era { get; set; }

        string formatMatcher { get; set; }

        string hour { get; set; }

        bool hour12 { get; set; }

        string localeMatcher { get; set; }

        string minute { get; set; }

        string month { get; set; }

        string second { get; set; }

        string timeZoneName { get; set; }

        string weekday { get; set; }

        string year { get; set; }
    }

    public partial interface ResolvedDateTimeFormatOptions
    {
        string calendar { get; set; }

        string day { get; set; }

        string era { get; set; }

        string hour { get; set; }

        bool hour12 { get; set; }

        string locale { get; set; }

        string minute { get; set; }

        string month { get; set; }

        string numberingSystem { get; set; }

        string second { get; set; }

        string timeZone { get; set; }

        string timeZoneName { get; set; }

        string weekday { get; set; }

        string year { get; set; }
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

    void drawElementsInstancedANGLE(int mode, int count, int type, int offset, int primcount);

    void vertexAttribDivisorANGLE(uint index, uint divisor);
};