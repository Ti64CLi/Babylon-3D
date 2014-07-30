using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Web
{
    using BABYLON;

    public partial interface ArrayBuffer
    {
        double byteLength { get; }
    }

    public partial interface ArrayBufferView
    {
        ArrayBuffer buffer { get; }

        double byteOffset { get; }

        double byteLength { get; }
    }

    public partial interface Int8Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Int8Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Int8Array subarray(double begin, double end = 0.0);
    }

    public partial interface Uint8Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Uint8Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Uint8Array subarray(double begin, double end = 0.0);
    }

    public partial interface Int16Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Int16Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Int16Array subarray(double begin, double end = 0.0);
    }

    public partial interface Uint16Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Uint16Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Uint16Array subarray(double begin, double end = 0.0);
    }

    public partial interface Int32Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Int32Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Int32Array subarray(double begin, double end = 0.0);
    }

    public partial interface Uint32Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Uint32Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Uint32Array subarray(double begin, double end = 0.0);
    }

    public partial interface Float32Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

        double get(double index);

        void set(double index, double value);

        void set(Float32Array array, double offset = 0.0);

        void set(Array<double> array, double offset = 0.0);

        Float32Array subarray(double begin, double end = 0.0);
    }

    public partial interface Float64Array : ArrayBufferView
    {
        double BYTES_PER_ELEMENT { get; }

        double Length { get; }

        double this[double index] { get; set; }

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

        double size { get; }
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

        double size { get; }
    }

    namespace Intl
    {
        public partial interface CollatorOptions
        {
            string usage { get; }

            string localeMatcher { get; }

            bool numeric { get; }

            string caseFirst { get; }

            string sensitivity { get; }

            bool ignorePunctuation { get; }
        }

        public partial interface ResolvedCollatorOptions
        {
            string locale { get; }

            string usage { get; }

            string sensitivity { get; }

            bool ignorePunctuation { get; }

            string collation { get; }

            string caseFirst { get; }

            bool numeric { get; }
        }

        public partial interface Collator
        {
            double compare(string x, string y);

            ResolvedCollatorOptions resolvedOptions();
        }

        public partial interface NumberFormatOptions
        {
            string localeMatcher { get; }

            string style { get; }

            string currency { get; }

            string currencyDisplay { get; }

            bool useGrouping { get; }
        }

        public partial interface ResolvedNumberFormatOptions
        {
            string locale { get; }

            string numberingSystem { get; }

            string style { get; }

            string currency { get; }

            string currencyDisplay { get; }

            double minimumintegerDigits { get; }

            double minimumFractionDigits { get; }

            double maximumFractionDigits { get; }

            double minimumSignificantDigits { get; }

            double maximumSignificantDigits { get; }

            bool useGrouping { get; }
        }

        public partial interface NumberFormat
        {
            string format(double value);

            ResolvedNumberFormatOptions resolvedOptions();
        }

        public partial interface DateTimeFormatOptions
        {
            string localeMatcher { get; }

            string weekday { get; }

            string era { get; }

            string year { get; }

            string month { get; }

            string day { get; }

            string hour { get; }

            string minute { get; }

            string second { get; }

            string timeZoneName { get; }

            string formatMatcher { get; }

            bool hour12 { get; }
        }

        public partial interface ResolvedDateTimeFormatOptions
        {
            string locale { get; }

            string calendar { get; }

            string numberingSystem { get; }

            string timeZone { get; }

            bool hour12 { get; }

            string weekday { get; }

            string era { get; }

            string year { get; }

            string month { get; }

            string day { get; }

            string hour { get; }

            string minute { get; }

            string second { get; }

            string timeZoneName { get; }
        }

        public partial interface DateTimeFormat
        {
            string format(double date);

            ResolvedDateTimeFormatOptions resolvedOptions();
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
        bool enableHighAccuracy { get; }

        double timeout { get; }

        double maximumAge { get; }
    }

    public partial interface ObjectURLOptions
    {
        bool oneTimeOnly { get; }
    }

    public partial interface StoreExceptionsInformation : ExceptionInformation
    {
        string siteName { get; }

        string explanationString { get; }

        string detailURI { get; }
    }

    public partial interface StoreSiteSpecificExceptionsInformation : StoreExceptionsInformation
    {
        Array<string> arrayOfDomainStrings { get; }
    }

    public partial interface ConfirmSiteSpecificExceptionsInformation : ExceptionInformation
    {
        Array<string> arrayOfDomainStrings { get; }
    }

    public partial interface AlgorithmParameters
    {
    }

    public partial interface MutationObserverInit
    {
        bool childList { get; }

        bool attributes { get; }

        bool characterData { get; }

        bool subtree { get; }

        bool attributeOldValue { get; }

        bool characterDataOldValue { get; }

        Array<string> attributeFilter { get; }
    }

    public partial interface PointerEventInit : MouseEventInit
    {
        double pointerId { get; }

        double width { get; }

        double height { get; }

        double pressure { get; }

        double tiltX { get; }

        double tiltY { get; }

        string pointerType { get; }

        bool isPrimary { get; }
    }

    public partial interface ExceptionInformation
    {
        string domain { get; }
    }

    public partial interface DeviceAccelerationDict
    {
        double x { get; }

        double y { get; }

        double z { get; }
    }

    public partial interface MsZoomToOptions
    {
        double contentX { get; }

        double contentY { get; }

        string viewportX { get; }

        string viewportY { get; }

        double scaleFactor { get; }

        string animate { get; }
    }

    public partial interface DeviceRotationRateDict
    {
        double alpha { get; }

        double beta { get; }

        double gamma { get; }
    }

    public partial interface Algorithm
    {
        string name { get; }

        AlgorithmParameters _params { get; }
    }

    public partial interface MouseEventInit
    {
        bool bubbles { get; }

        bool cancelable { get; }

        Window view { get; }

        double detail { get; }

        double screenX { get; }

        double screenY { get; }

        double clientX { get; }

        double clientY { get; }

        bool ctrlKey { get; }

        bool shiftKey { get; }

        bool altKey { get; }

        bool metaKey { get; }

        double button { get; }

        double buttons { get; }

        EventTarget relatedTarget { get; }
    }

    public partial interface WebGLContextAttributes
    {
        bool alpha { get; }

        bool depth { get; }

        bool stencil { get; }

        bool antialias { get; }

        bool premultipliedAlpha { get; }

        bool preserveDrawingBuffer { get; }
    }

    public partial interface NodeListOf<TNode> : NodeList
    {
        double Length { get; }

        TNode item(double index);

        TNode this[double index] { get; set; }
    }

    public partial interface HTMLElement : ElementElementCSSInlineStyleMSEventAttachmentTargetMSNodeExtensions
    {
        object hidden { get; }

        object readyState { get; }

        System.Func<MouseEvent, object> onmouseleave { get; }

        System.Func<DragEvent, object> onbeforecut { get; }

        System.Func<KeyboardEvent, object> onkeydown { get; }

        System.Func<MSEventObj, object> onmove { get; }

        System.Func<KeyboardEvent, object> onkeyup { get; }

        System.Func<Event, object> onreset { get; }

        System.Func<Event, object> onhelp { get; }

        System.Func<DragEvent, object> ondragleave { get; }

        string className { get; }

        System.Func<FocusEvent, object> onfocusin { get; }

        System.Func<Event, object> onseeked { get; }

        object recordNumber { get; }

        string title { get; }

        Element parentTextEdit { get; }

        string outerHTML { get; }

        System.Func<Event, object> ondurationchange { get; }

        double offsetHeight { get; }

        HTMLCollection all { get; }

        System.Func<FocusEvent, object> onblur { get; }

        string dir { get; }

        System.Func<Event, object> onemptied { get; }

        System.Func<Event, object> onseeking { get; }

        System.Func<Event, object> oncanplay { get; }

        System.Func<UIEvent, object> ondeactivate { get; }

        System.Func<MSEventObj, object> ondatasetchanged { get; }

        System.Func<MSEventObj, object> onrowsdelete { get; }

        double sourceIndex { get; }

        System.Func<Event, object> onloadstart { get; }

        System.Func<MSEventObj, object> onlosecapture { get; }

        System.Func<DragEvent, object> ondragenter { get; }

        System.Func<MSEventObj, object> oncontrolselect { get; }

        System.Func<Event, object> onsubmit { get; }

        MSBehaviorUrnsCollection behaviorUrns { get; }

        string scopeName { get; }

        System.Func<Event, object> onchange { get; }

        string id { get; }

        System.Func<MSEventObj, object> onlayoutcomplete { get; }

        string uniqueID { get; }

        System.Func<UIEvent, object> onbeforeactivate { get; }

        System.Func<Event, object> oncanplaythrough { get; }

        System.Func<MSEventObj, object> onbeforeupdate { get; }

        System.Func<MSEventObj, object> onfilterchange { get; }

        Element offsetParent { get; }

        System.Func<MSEventObj, object> ondatasetcomplete { get; }

        System.Func<Event, object> onsuspend { get; }

        System.Func<MouseEvent, object> onmouseenter { get; }

        string innerText { get; }

        System.Func<MSEventObj, object> onerrorupdate { get; }

        System.Func<MouseEvent, object> onmouseout { get; }

        HTMLElement parentElement { get; }

        System.Func<MouseWheelEvent, object> onmousewheel { get; }

        System.Func<Event, object> onvolumechange { get; }

        System.Func<MSEventObj, object> oncellchange { get; }

        System.Func<MSEventObj, object> onrowexit { get; }

        System.Func<MSEventObj, object> onrowsinserted { get; }

        System.Func<MSEventObj, object> onpropertychange { get; }

        object filters { get; }

        HTMLCollection children { get; }

        System.Func<DragEvent, object> ondragend { get; }

        System.Func<DragEvent, object> onbeforepaste { get; }

        System.Func<DragEvent, object> ondragover { get; }

        double offsetTop { get; }

        System.Func<MouseEvent, object> onmouseup { get; }

        System.Func<DragEvent, object> ondragstart { get; }

        System.Func<DragEvent, object> onbeforecopy { get; }

        System.Func<DragEvent, object> ondrag { get; }

        string innerHTML { get; }

        System.Func<MouseEvent, object> onmouseover { get; }

        string lang { get; }

        double uniqueNumber { get; }

        System.Func<Event, object> onpause { get; }

        string tagUrn { get; }

        System.Func<MouseEvent, object> onmousedown { get; }

        System.Func<MouseEvent, object> onclick { get; }

        System.Func<Event, object> onwaiting { get; }

        System.Func<MSEventObj, object> onresizestart { get; }

        double offsetLeft { get; }

        bool isTextEdit { get; }

        bool isDisabled { get; }

        System.Func<DragEvent, object> onpaste { get; }

        bool canHaveHTML { get; }

        System.Func<MSEventObj, object> onmoveend { get; }

        string language { get; }

        System.Func<Event, object> onstalled { get; }

        System.Func<MouseEvent, object> onmousemove { get; }

        MSStyleCSSProperties style { get; }

        bool isContentEditable { get; }

        System.Func<MSEventObj, object> onbeforeeditfocus { get; }

        System.Func<Event, object> onratechange { get; }

        string contentEditable { get; }

        double tabIndex { get; }

        Document document { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<MouseEvent, object> ondblclick { get; }

        System.Func<MouseEvent, object> oncontextmenu { get; }

        System.Func<Event, object> onloadedmetadata { get; }

        System.Func<MSEventObj, object> onafterupdate { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onplay { get; }

        System.Func<MSEventObj, object> onresizeend { get; }

        System.Func<Event, object> onplaying { get; }

        bool isMultiLine { get; }

        System.Func<FocusEvent, object> onfocusout { get; }

        System.Func<UIEvent, object> onabort { get; }

        System.Func<MSEventObj, object> ondataavailable { get; }

        bool hideFocus { get; }

        System.Func<Event, object> onreadystatechange { get; }

        System.Func<KeyboardEvent, object> onkeypress { get; }

        System.Func<Event, object> onloadeddata { get; }

        System.Func<UIEvent, object> onbeforedeactivate { get; }

        string outerText { get; }

        bool disabled { get; }

        System.Func<UIEvent, object> onactivate { get; }

        string accessKey { get; }

        System.Func<MSEventObj, object> onmovestart { get; }

        System.Func<Event, object> onselectstart { get; }

        System.Func<FocusEvent, object> onfocus { get; }

        System.Func<Event, object> ontimeupdate { get; }

        System.Func<UIEvent, object> onresize { get; }

        System.Func<DragEvent, object> oncut { get; }

        System.Func<UIEvent, object> onselect { get; }

        System.Func<DragEvent, object> ondrop { get; }

        double offsetWidth { get; }

        System.Func<DragEvent, object> oncopy { get; }

        System.Func<Event, object> onended { get; }

        System.Func<UIEvent, object> onscroll { get; }

        System.Func<MSEventObj, object> onrowenter { get; }

        System.Func<Event, object> onload { get; }

        bool canHaveChildren { get; }

        System.Func<Event, object> oninput { get; }

        System.Func<MSEventObj, object> onmscontentzoom { get; }

        System.Func<Event, object> oncuechange { get; }

        bool spellcheck { get; }

        DOMTokenList classList { get; }

        System.Func<object, object> onmsmanipulationstatechanged { get; }

        bool draggable { get; }

        DOMStringMap dataset { get; }

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

    public partial interface Document :
        NodeNodeSelectorMSEventAttachmentTargetDocumentEventMSResourceMetadataMSNodeExtensionsMSDocumentExtensionsGlobalEventHandlers
    {
        HTMLElement documentElement { get; }

        MSCompatibleInfoCollection compatible { get; }

        System.Func<KeyboardEvent, object> onkeydown { get; }

        System.Func<KeyboardEvent, object> onkeyup { get; }

        DOMImplementation implementation { get; }

        System.Func<Event, object> onreset { get; }

        HTMLCollection scripts { get; }

        System.Func<Event, object> onhelp { get; }

        System.Func<DragEvent, object> ondragleave { get; }

        string charset { get; }

        System.Func<FocusEvent, object> onfocusin { get; }

        string vlinkColor { get; }

        System.Func<Event, object> onseeked { get; }

        string security { get; }

        string title { get; }

        MSNamespaceInfoCollection namespaces { get; }

        string defaultCharset { get; }

        HTMLCollection embeds { get; }

        StyleSheetList styleSheets { get; }

        Window frames { get; }

        System.Func<Event, object> ondurationchange { get; }

        HTMLCollection all { get; }

        HTMLCollection forms { get; }

        System.Func<FocusEvent, object> onblur { get; }

        string dir { get; }

        System.Func<Event, object> onemptied { get; }

        string designMode { get; }

        System.Func<Event, object> onseeking { get; }

        System.Func<UIEvent, object> ondeactivate { get; }

        System.Func<Event, object> oncanplay { get; }

        System.Func<MSEventObj, object> ondatasetchanged { get; }

        System.Func<MSEventObj, object> onrowsdelete { get; }

        MSScriptHost Script { get; }

        System.Func<Event, object> onloadstart { get; }

        string URLUnencoded { get; }

        Window defaultView { get; }

        System.Func<MSEventObj, object> oncontrolselect { get; }

        System.Func<DragEvent, object> ondragenter { get; }

        System.Func<Event, object> onsubmit { get; }

        string inputEncoding { get; }

        Element activeElement { get; }

        System.Func<Event, object> onchange { get; }

        HTMLCollection links { get; }

        string uniqueID { get; }

        string URL { get; }

        System.Func<UIEvent, object> onbeforeactivate { get; }

        HTMLHeadElement head { get; }

        string cookie { get; }

        string xmlEncoding { get; }

        System.Func<Event, object> oncanplaythrough { get; }

        double documentMode { get; }

        string characterSet { get; }

        HTMLCollection anchors { get; }

        System.Func<MSEventObj, object> onbeforeupdate { get; }

        System.Func<MSEventObj, object> ondatasetcomplete { get; }

        HTMLCollection plugins { get; }

        System.Func<Event, object> onsuspend { get; }

        SVGSVGElement rootElement { get; }

        string readyState { get; }

        string referrer { get; }

        string alinkColor { get; }

        System.Func<MSEventObj, object> onerrorupdate { get; }

        Window parentWindow { get; }

        System.Func<MouseEvent, object> onmouseout { get; }

        System.Func<MSSiteModeEvent, object> onmsthumbnailclick { get; }

        System.Func<MouseWheelEvent, object> onmousewheel { get; }

        System.Func<Event, object> onvolumechange { get; }

        System.Func<MSEventObj, object> oncellchange { get; }

        System.Func<MSEventObj, object> onrowexit { get; }

        System.Func<MSEventObj, object> onrowsinserted { get; }

        string xmlVersion { get; }

        bool msCapsLockWarningOff { get; }

        System.Func<MSEventObj, object> onpropertychange { get; }

        System.Func<DragEvent, object> ondragend { get; }

        DocumentType doctype { get; }

        System.Func<DragEvent, object> ondragover { get; }

        string bgColor { get; }

        System.Func<DragEvent, object> ondragstart { get; }

        System.Func<MouseEvent, object> onmouseup { get; }

        System.Func<DragEvent, object> ondrag { get; }

        System.Func<MouseEvent, object> onmouseover { get; }

        string linkColor { get; }

        System.Func<Event, object> onpause { get; }

        System.Func<MouseEvent, object> onmousedown { get; }

        System.Func<MouseEvent, object> onclick { get; }

        System.Func<Event, object> onwaiting { get; }

        System.Func<Event, object> onstop { get; }

        System.Func<MSSiteModeEvent, object> onmssitemodejumplistitemremoved { get; }

        HTMLCollection applets { get; }

        HTMLElement body { get; }

        string domain { get; }

        bool xmlStandalone { get; }

        MSSelection selection { get; }

        System.Func<Event, object> onstalled { get; }

        System.Func<MouseEvent, object> onmousemove { get; }

        System.Func<MSEventObj, object> onbeforeeditfocus { get; }

        System.Func<Event, object> onratechange { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<MouseEvent, object> ondblclick { get; }

        System.Func<MouseEvent, object> oncontextmenu { get; }

        System.Func<Event, object> onloadedmetadata { get; }

        string media { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onplay { get; }

        System.Func<MSEventObj, object> onafterupdate { get; }

        System.Func<Event, object> onplaying { get; }

        HTMLCollection images { get; }

        Location location { get; }

        System.Func<UIEvent, object> onabort { get; }

        System.Func<FocusEvent, object> onfocusout { get; }

        System.Func<Event, object> onselectionchange { get; }

        System.Func<StorageEvent, object> onstoragecommit { get; }

        System.Func<MSEventObj, object> ondataavailable { get; }

        System.Func<Event, object> onreadystatechange { get; }

        string lastModified { get; }

        System.Func<KeyboardEvent, object> onkeypress { get; }

        System.Func<Event, object> onloadeddata { get; }

        System.Func<UIEvent, object> onbeforedeactivate { get; }

        System.Func<UIEvent, object> onactivate { get; }

        System.Func<Event, object> onselectstart { get; }

        System.Func<FocusEvent, object> onfocus { get; }

        string fgColor { get; }

        System.Func<Event, object> ontimeupdate { get; }

        System.Func<UIEvent, object> onselect { get; }

        System.Func<DragEvent, object> ondrop { get; }

        System.Func<Event, object> onended { get; }

        string compatMode { get; }

        System.Func<UIEvent, object> onscroll { get; }

        System.Func<MSEventObj, object> onrowenter { get; }

        System.Func<Event, object> onload { get; }

        System.Func<Event, object> oninput { get; }

        System.Func<object, object> onmspointerdown { get; }

        bool msHidden { get; }

        string msVisibilityState { get; }

        System.Func<object, object> onmsgesturedoubletap { get; }

        string visibilityState { get; }

        System.Func<object, object> onmsmanipulationstatechanged { get; }

        System.Func<object, object> onmspointerhover { get; }

        System.Func<MSEventObj, object> onmscontentzoom { get; }

        System.Func<object, object> onmspointermove { get; }

        System.Func<object, object> onmsgesturehold { get; }

        System.Func<object, object> onmsgesturechange { get; }

        System.Func<object, object> onmsgesturestart { get; }

        System.Func<object, object> onmspointercancel { get; }

        System.Func<object, object> onmsgestureend { get; }

        System.Func<object, object> onmsgesturetap { get; }

        System.Func<object, object> onmspointerout { get; }

        System.Func<object, object> onmsinertiastart { get; }

        bool msCSSOMElementFloatMetrics { get; }

        System.Func<object, object> onmspointerover { get; }

        bool hidden { get; }

        System.Func<object, object> onmspointerup { get; }

        bool msFullscreenEnabled { get; }

        System.Func<object, object> onmsfullscreenerror { get; }

        System.Func<object, object> onmspointerenter { get; }

        Element msFullscreenElement { get; }

        System.Func<object, object> onmsfullscreenchange { get; }

        System.Func<object, object> onmspointerleave { get; }

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
        string nextPage { get; }

        double keyCode { get; }

        Element toElement { get; }

        object returnValue { get; }

        string dataFld { get; }

        double y { get; }

        DataTransfer dataTransfer { get; }

        string propertyName { get; }

        string url { get; }

        double offsetX { get; }

        object recordset { get; }

        double screenX { get; }

        double buttonID { get; }

        double wheelDelta { get; }

        double reason { get; }

        string origin { get; }

        string data { get; }

        object srcFilter { get; }

        HTMLCollection boundElements { get; }

        bool cancelBubble { get; }

        bool altLeft { get; }

        double behaviorCookie { get; }

        BookmarkCollection bookmarks { get; }

        string type { get; }

        bool repeat { get; }

        Element srcElement { get; }

        Window source { get; }

        Element fromElement { get; }

        double offsetY { get; }

        double x { get; }

        double behaviorPart { get; }

        string qualifier { get; }

        bool altKey { get; }

        bool ctrlKey { get; }

        double clientY { get; }

        bool shiftKey { get; }

        bool shiftLeft { get; }

        bool contentOverflow { get; }

        double screenY { get; }

        bool ctrlLeft { get; }

        double button { get; }

        string srcUrn { get; }

        double clientX { get; }

        string actionURL { get; }

        object getAttribute(string strAttributeName, double lFlags = 0.0);

        void setAttribute(string strAttributeName, object AttributeValue, double lFlags = 0.0);

        bool removeAttribute(string strAttributeName, double lFlags = 0.0);
    }

    public partial interface HTMLCanvasElement : HTMLElement
    {
        double width { get; }

        double height { get; }

        object getContext(string contextId, params object[] args);

        string toDataURL(string type = null, params object[] args);

        Blob msToBlob();
    }

    public partial interface Window :
        EventTargetMSEventAttachmentTargetWindowLocalStorageMSWindowExtensionsWindowSessionStorageWindowTimersWindowBase64IDBEnvironmentWindowConsoleGlobalEventHandlers
    {
        System.Func<DragEvent, object> ondragend { get; }

        System.Func<KeyboardEvent, object> onkeydown { get; }

        System.Func<DragEvent, object> ondragover { get; }

        System.Func<KeyboardEvent, object> onkeyup { get; }

        System.Func<Event, object> onreset { get; }

        System.Func<MouseEvent, object> onmouseup { get; }

        System.Func<DragEvent, object> ondragstart { get; }

        System.Func<DragEvent, object> ondrag { get; }

        double screenX { get; }

        System.Func<MouseEvent, object> onmouseover { get; }

        System.Func<DragEvent, object> ondragleave { get; }

        History history { get; }

        double pageXOffset { get; }

        string name { get; }

        System.Func<Event, object> onafterprint { get; }

        System.Func<Event, object> onpause { get; }

        System.Func<Event, object> onbeforeprint { get; }

        Window top { get; }

        System.Func<MouseEvent, object> onmousedown { get; }

        System.Func<Event, object> onseeked { get; }

        Window opener { get; }

        System.Func<MouseEvent, object> onclick { get; }

        double innerHeight { get; }

        System.Func<Event, object> onwaiting { get; }

        System.Func<Event, object> ononline { get; }

        System.Func<Event, object> ondurationchange { get; }

        Window frames { get; }

        System.Func<FocusEvent, object> onblur { get; }

        System.Func<Event, object> onemptied { get; }

        System.Func<Event, object> onseeking { get; }

        System.Func<Event, object> oncanplay { get; }

        double outerWidth { get; }

        System.Func<Event, object> onstalled { get; }

        System.Func<MouseEvent, object> onmousemove { get; }

        double innerWidth { get; }

        System.Func<Event, object> onoffline { get; }

        double Length { get; }

        Screen screen { get; }

        System.Func<BeforeUnloadEvent, object> onbeforeunload { get; }

        System.Func<Event, object> onratechange { get; }

        System.Func<StorageEvent, object> onstorage { get; }

        System.Func<Event, object> onloadstart { get; }

        System.Func<DragEvent, object> ondragenter { get; }

        System.Func<Event, object> onsubmit { get; }

        Window self { get; }

        Document document { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<MouseEvent, object> ondblclick { get; }

        double pageYOffset { get; }

        System.Func<MouseEvent, object> oncontextmenu { get; }

        System.Func<Event, object> onchange { get; }

        System.Func<Event, object> onloadedmetadata { get; }

        System.Func<Event, object> onplay { get; }

        ErrorEventHandler onerror { get; }

        System.Func<Event, object> onplaying { get; }

        Window parent { get; }

        Location location { get; }

        System.Func<Event, object> oncanplaythrough { get; }

        System.Func<UIEvent, object> onabort { get; }

        System.Func<Event, object> onreadystatechange { get; }

        double outerHeight { get; }

        System.Func<KeyboardEvent, object> onkeypress { get; }

        Element frameElement { get; }

        System.Func<Event, object> onloadeddata { get; }

        System.Func<Event, object> onsuspend { get; }

        Window window { get; }

        System.Func<FocusEvent, object> onfocus { get; }

        System.Func<MessageEvent, object> onmessage { get; }

        System.Func<Event, object> ontimeupdate { get; }

        System.Func<UIEvent, object> onresize { get; }

        System.Func<UIEvent, object> onselect { get; }

        Navigator navigator { get; }

        StyleMedia styleMedia { get; }

        System.Func<DragEvent, object> ondrop { get; }

        System.Func<MouseEvent, object> onmouseout { get; }

        System.Func<Event, object> onended { get; }

        System.Func<Event, object> onhashchange { get; }

        System.Func<Event, object> onunload { get; }

        System.Func<UIEvent, object> onscroll { get; }

        double screenY { get; }

        System.Func<MouseWheelEvent, object> onmousewheel { get; }

        System.Func<Event, object> onload { get; }

        System.Func<Event, object> onvolumechange { get; }

        System.Func<Event, object> oninput { get; }

        Performance performance { get; }

        System.Func<object, object> onmspointerdown { get; }

        double animationStartTime { get; }

        System.Func<object, object> onmsgesturedoubletap { get; }

        System.Func<object, object> onmspointerhover { get; }

        System.Func<object, object> onmsgesturehold { get; }

        System.Func<object, object> onmspointermove { get; }

        System.Func<object, object> onmsgesturechange { get; }

        System.Func<object, object> onmsgesturestart { get; }

        System.Func<object, object> onmspointercancel { get; }

        System.Func<object, object> onmsgestureend { get; }

        System.Func<object, object> onmsgesturetap { get; }

        System.Func<object, object> onmspointerout { get; }

        double msAnimationStartTime { get; }

        ApplicationCache applicationCache { get; }

        System.Func<object, object> onmsinertiastart { get; }

        System.Func<object, object> onmspointerover { get; }

        System.Func<PopStateEvent, object> onpopstate { get; }

        System.Func<object, object> onmspointerup { get; }

        System.Func<PageTransitionEvent, object> onpageshow { get; }

        System.Func<DeviceMotionEvent, object> ondevicemotion { get; }

        double devicePixelRatio { get; }

        Crypto msCrypto { get; }

        System.Func<DeviceOrientationEvent, object> ondeviceorientation { get; }

        string doNotTrack { get; }

        System.Func<object, object> onmspointerenter { get; }

        System.Func<PageTransitionEvent, object> onpagehide { get; }

        System.Func<object, object> onmspointerleave { get; }

        void alert(object message = null);

        void scroll(double x = 0.0, double y = 0.0);

        void focus();

        void scrollTo(double x = 0.0, double y = 0.0);

        void print();

        string prompt(string message = null, string _default = null);

        string toString();

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
        string appVersion { get; }

        string appName { get; }

        string userAgent { get; }

        string platform { get; }

        string product { get; }

        string vendor { get; }
    }

    public partial interface HTMLTableElement :
        HTMLElementMSDataBindingTableExtensionsMSDataBindingExtensionsDOML2DeprecatedBackgroundStyleDOML2DeprecatedBackgroundColorStyle
    {
        string width { get; }

        object borderColorLight { get; }

        string cellSpacing { get; }

        HTMLTableSectionElement tFoot { get; }

        string frame { get; }

        object borderColor { get; }

        HTMLCollection rows { get; }

        string rules { get; }

        double cols { get; }

        string summary { get; }

        HTMLTableCaptionElement caption { get; }

        HTMLCollection tBodies { get; }

        HTMLTableSectionElement tHead { get; }

        string align { get; }

        HTMLCollection cells { get; }

        object height { get; }

        string cellPadding { get; }

        string border { get; }

        object borderColorDark { get; }

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
        double whatToShow { get; }

        NodeFilter filter { get; }

        Node root { get; }

        Node currentNode { get; }

        bool expandEntityReferences { get; }

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
        double y { get; }

        double y1 { get; }

        double x { get; }

        double x1 { get; }
    }

    public partial interface Performance
    {
        PerformanceNavigation navigation { get; }

        PerformanceTiming timing { get; }

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
        double dataPageSize { get; }

        void nextPage();

        void firstPage();

        void refresh();

        void previousPage();

        void lastPage();
    }

    public partial interface CompositionEvent : UIEvent
    {
        string data { get; }

        string locale { get; }

        void initCompositionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, string locale);
    }

    public partial interface WindowTimers : WindowTimersExtension
    {
        void clearTimeout(double handle);

        double setTimeout(object handler, object timeout = null, params object[] args);

        void clearInterval(double handle);

        double setInterval(object handler, object timeout = null, params object[] args);
    }

    public partial interface SVGMarkerElement : SVGElementSVGStylableSVGLangSpaceSVGFitToViewBoxSVGExternalResourcesRequired
    {
        SVGAnimatedEnumeration orientType { get; }

        SVGAnimatedEnumeration markerUnits { get; }

        SVGAnimatedLength markerWidth { get; }

        SVGAnimatedLength markerHeight { get; }

        SVGAnimatedAngle orientAngle { get; }

        SVGAnimatedLength refY { get; }

        SVGAnimatedLength refX { get; }

        void setOrientToAngle(SVGAngle angle);

        void setOrientToAuto();

        double SVG_MARKER_ORIENT_UNKNOWN { get; }

        double SVG_MARKER_ORIENT_ANGLE { get; }

        double SVG_MARKERUNITS_UNKNOWN { get; }

        double SVG_MARKERUNITS_STROKEWIDTH { get; }

        double SVG_MARKER_ORIENT_AUTO { get; }

        double SVG_MARKERUNITS_USERSPACEONUSE { get; }
    }

    public partial interface CSSStyleDeclaration
    {
        string backgroundAttachment { get; }

        string visibility { get; }

        string textAlignLast { get; }

        string borderRightStyle { get; }

        string counterIncrement { get; }

        string orphans { get; }

        string cssText { get; }

        string borderStyle { get; }

        string pointerEvents { get; }

        string borderTopColor { get; }

        string markerEnd { get; }

        string textIndent { get; }

        string listStyleImage { get; }

        string cursor { get; }

        string listStylePosition { get; }

        string wordWrap { get; }

        string borderTopStyle { get; }

        string alignmentBaseline { get; }

        string opacity { get; }

        string direction { get; }

        string strokeMiterlimit { get; }

        string maxWidth { get; }

        string color { get; }

        string clip { get; }

        string borderRightWidth { get; }

        string verticalAlign { get; }

        string overflow { get; }

        string mask { get; }

        string borderLeftStyle { get; }

        string emptyCells { get; }

        string stopOpacity { get; }

        string paddingRight { get; }

        CSSRule parentRule { get; }

        string background { get; }

        string boxSizing { get; }

        string textJustify { get; }

        string height { get; }

        string paddingTop { get; }

        double Length { get; }

        string right { get; }

        string baselineShift { get; }

        string borderLeft { get; }

        string widows { get; }

        string lineHeight { get; }

        string left { get; }

        string textUnderlinePosition { get; }

        string glyphOrientationHorizontal { get; }

        string display { get; }

        string textAnchor { get; }

        string cssFloat { get; }

        string strokeDasharray { get; }

        string rubyAlign { get; }

        string fontSizeAdjust { get; }

        string borderLeftColor { get; }

        string backgroundImage { get; }

        string listStyleType { get; }

        string strokeWidth { get; }

        string textOverflow { get; }

        string fillRule { get; }

        string borderBottomColor { get; }

        string zIndex { get; }

        string position { get; }

        string listStyle { get; }

        string msTransformOrigin { get; }

        string dominantBaseline { get; }

        string overflowY { get; }

        string fill { get; }

        string captionSide { get; }

        string borderCollapse { get; }

        string boxShadow { get; }

        string quotes { get; }

        string tableLayout { get; }

        string unicodeBidi { get; }

        string borderBottomWidth { get; }

        string backgroundSize { get; }

        string textDecoration { get; }

        string strokeDashoffset { get; }

        string fontSize { get; }

        string border { get; }

        string pageBreakBefore { get; }

        string borderTopRightRadius { get; }

        string msTransform { get; }

        string borderBottomLeftRadius { get; }

        string textTransform { get; }

        string rubyPosition { get; }

        string strokeLinejoin { get; }

        string clipPath { get; }

        string borderRightColor { get; }

        string fontFamily { get; }

        string clear { get; }

        string content { get; }

        string backgroundClip { get; }

        string marginBottom { get; }

        string counterReset { get; }

        string outlineWidth { get; }

        string marginRight { get; }

        string paddingLeft { get; }

        string borderBottom { get; }

        string wordBreak { get; }

        string marginTop { get; }

        string top { get; }

        string fontWeight { get; }

        string borderRight { get; }

        string width { get; }

        string kerning { get; }

        string pageBreakAfter { get; }

        string borderBottomStyle { get; }

        string fontStretch { get; }

        string padding { get; }

        string strokeOpacity { get; }

        string markerStart { get; }

        string bottom { get; }

        string borderLeftWidth { get; }

        string clipRule { get; }

        string backgroundPosition { get; }

        string backgroundColor { get; }

        string pageBreakInside { get; }

        string backgroundOrigin { get; }

        string strokeLinecap { get; }

        string borderTopWidth { get; }

        string outlineStyle { get; }

        string borderTop { get; }

        string outlineColor { get; }

        string paddingBottom { get; }

        string marginLeft { get; }

        string font { get; }

        string outline { get; }

        string wordSpacing { get; }

        string maxHeight { get; }

        string fillOpacity { get; }

        string letterSpacing { get; }

        string borderSpacing { get; }

        string backgroundRepeat { get; }

        string borderRadius { get; }

        string borderWidth { get; }

        string borderBottomRightRadius { get; }

        string whiteSpace { get; }

        string fontStyle { get; }

        string minWidth { get; }

        string stopColor { get; }

        string borderTopLeftRadius { get; }

        string borderColor { get; }

        string marker { get; }

        string glyphOrientationVertical { get; }

        string markerMid { get; }

        string fontVariant { get; }

        string minHeight { get; }

        string stroke { get; }

        string rubyOverhang { get; }

        string overflowX { get; }

        string textAlign { get; }

        string margin { get; }

        string animationFillMode { get; }

        string floodColor { get; }

        string animationIterationCount { get; }

        string textShadow { get; }

        string backfaceVisibility { get; }

        string msAnimationIterationCount { get; }

        string animationDelay { get; }

        string animationTimingFunction { get; }

        object columnWidth { get; }

        string msScrollSnapX { get; }

        object columnRuleColor { get; }

        object columnRuleWidth { get; }

        string transitionDelay { get; }

        string transition { get; }

        string msFlowFrom { get; }

        string msScrollSnapType { get; }

        string msContentZoomSnapType { get; }

        string msGridColumns { get; }

        string msAnimationName { get; }

        string msGridRowAlign { get; }

        string msContentZoomChaining { get; }

        object msGridColumn { get; }

        object msHyphenateLimitZone { get; }

        string msScrollRails { get; }

        string msAnimationDelay { get; }

        string enableBackground { get; }

        string msWrapThrough { get; }

        string columnRuleStyle { get; }

        string msAnimation { get; }

        string msFlexFlow { get; }

        string msScrollSnapY { get; }

        object msHyphenateLimitLines { get; }

        string msTouchAction { get; }

        string msScrollLimit { get; }

        string animation { get; }

        string transform { get; }

        string filter { get; }

        string colorInterpolationFilters { get; }

        string transitionTimingFunction { get; }

        string msBackfaceVisibility { get; }

        string animationPlayState { get; }

        string transformOrigin { get; }

        object msScrollLimitYMin { get; }

        string msFontFeatureSettings { get; }

        object msContentZoomLimitMin { get; }

        object columnGap { get; }

        string transitionProperty { get; }

        string msAnimationDuration { get; }

        string msAnimationFillMode { get; }

        string msFlexDirection { get; }

        string msTransitionDuration { get; }

        string fontFeatureSettings { get; }

        string breakBefore { get; }

        string msFlexWrap { get; }

        string perspective { get; }

        string msFlowInto { get; }

        string msTransformStyle { get; }

        string msScrollTranslation { get; }

        string msTransitionProperty { get; }

        string msUserSelect { get; }

        string msOverflowStyle { get; }

        string msScrollSnapPointsY { get; }

        string animationDirection { get; }

        string animationDuration { get; }

        string msFlex { get; }

        string msTransitionTimingFunction { get; }

        string animationName { get; }

        string columnRule { get; }

        object msGridColumnSpan { get; }

        string msFlexNegative { get; }

        string columnFill { get; }

        object msGridRow { get; }

        string msFlexOrder { get; }

        string msFlexItemAlign { get; }

        string msFlexPositive { get; }

        object msContentZoomLimitMax { get; }

        object msScrollLimitYMax { get; }

        string msGridColumnAlign { get; }

        string perspectiveOrigin { get; }

        string lightingColor { get; }

        string columns { get; }

        string msScrollChaining { get; }

        string msHyphenateLimitChars { get; }

        string msTouchSelect { get; }

        string floodOpacity { get; }

        string msAnimationDirection { get; }

        string msAnimationPlayState { get; }

        string columnSpan { get; }

        string msContentZooming { get; }

        string msPerspective { get; }

        string msFlexPack { get; }

        string msScrollSnapPointsX { get; }

        string msContentZoomSnapPoints { get; }

        object msGridRowSpan { get; }

        string msContentZoomSnap { get; }

        object msScrollLimitXMin { get; }

        string breakInside { get; }

        string msHighContrastAdjust { get; }

        string msFlexLinePack { get; }

        string msGridRows { get; }

        string transitionDuration { get; }

        string msHyphens { get; }

        string breakAfter { get; }

        string msTransition { get; }

        string msPerspectiveOrigin { get; }

        string msContentZoomLimit { get; }

        object msScrollLimitXMax { get; }

        string msFlexAlign { get; }

        object msWrapMargin { get; }

        object columnCount { get; }

        string msAnimationTimingFunction { get; }

        string msTransitionDelay { get; }

        string transformStyle { get; }

        string msWrapFlow { get; }

        string msFlexPreferredSize { get; }

        string alignItems { get; }

        string borderImageSource { get; }

        string flexBasis { get; }

        string borderImageWidth { get; }

        string borderImageRepeat { get; }

        string order { get; }

        string flex { get; }

        string alignContent { get; }

        string msImeAlign { get; }

        string flexShrink { get; }

        string flexGrow { get; }

        string borderImageSlice { get; }

        string flexWrap { get; }

        string borderImageOutset { get; }

        string flexDirection { get; }

        string touchAction { get; }

        string flexFlow { get; }

        string borderImage { get; }

        string justifyContent { get; }

        string alignSelf { get; }

        string msTextCombineHorizontal { get; }

        string getPropertyPriority(string propertyName);

        string getPropertyValue(string propertyName);

        string removeProperty(string propertyName);

        string item(double index);

        string this[double index] { get; set; }

        void setProperty(string propertyName, string value, string priority = null);
    }

    public partial interface SVGGElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
    }

    public partial interface MSStyleCSSProperties : MSCSSProperties
    {
        double pixelWidth { get; }

        double posHeight { get; }

        double posLeft { get; }

        double pixelTop { get; }

        double pixelBottom { get; }

        bool textDecorationNone { get; }

        double pixelLeft { get; }

        double posTop { get; }

        double posBottom { get; }

        bool textDecorationOverline { get; }

        double posWidth { get; }

        bool textDecorationLineThrough { get; }

        double pixelHeight { get; }

        bool textDecorationBlink { get; }

        double posRight { get; }

        double pixelRight { get; }

        bool textDecorationUnderline { get; }
    }

    public partial interface Navigator :
        NavigatorIDNavigatorOnLineNavigatorContentUtilsMSNavigatorExtensionsNavigatorGeolocationMSNavigatorDoNotTrackNavigatorStorageUtilsMSFileSaver
    {
        double msMaxTouchPoints { get; }

        bool msPointerEnabled { get; }

        bool msManipulationViewsEnabled { get; }

        bool pointerEnabled { get; }

        double maxTouchPoints { get; }

        void msLaunchUri(string uri, MSLaunchUriCallback successCallback = null, MSLaunchUriCallback noHandlerCallback = null);
    }

    public partial interface SVGPathSegCurvetoCubicSmoothAbs : SVGPathSeg
    {
        double y { get; }

        double x2 { get; }

        double x { get; }

        double y2 { get; }
    }

    public partial interface SVGZoomEvent : UIEvent
    {
        SVGRect zoomRectScreen { get; }

        double previousScale { get; }

        double newScale { get; }

        SVGPoint previousTranslate { get; }

        SVGPoint newTranslate { get; }
    }

    public partial interface NodeSelector
    {
        NodeList querySelectorAll(string selectors);

        Element querySelector(string selectors);
    }

    public partial interface HTMLTableDataCellElement : HTMLTableCellElement
    {
    }

    public partial interface HTMLBaseElement : HTMLElement
    {
        string target { get; }

        string href { get; }
    }

    public partial interface ClientRect
    {
        double left { get; }

        double width { get; }

        double right { get; }

        double top { get; }

        double bottom { get; }

        double height { get; }
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
        double SVG_UNIT_TYPE_UNKNOWN { get; }

        double SVG_UNIT_TYPE_OBJECTBOUNDINGBOX { get; }

        double SVG_UNIT_TYPE_USERSPACEONUSE { get; }
    }

    public partial interface Element : NodeNodeSelectorElementTraversalGlobalEventHandlers
    {
        double scrollTop { get; }

        double clientLeft { get; }

        double scrollLeft { get; }

        string tagName { get; }

        double clientWidth { get; }

        double scrollWidth { get; }

        double clientHeight { get; }

        double clientTop { get; }

        double scrollHeight { get; }

        string msRegionOverflow { get; }

        System.Func<object, object> onmspointerdown { get; }

        System.Func<object, object> onmsgotpointercapture { get; }

        System.Func<object, object> onmsgesturedoubletap { get; }

        System.Func<object, object> onmspointerhover { get; }

        System.Func<object, object> onmsgesturehold { get; }

        System.Func<object, object> onmspointermove { get; }

        System.Func<object, object> onmsgesturechange { get; }

        System.Func<object, object> onmsgesturestart { get; }

        System.Func<object, object> onmspointercancel { get; }

        System.Func<object, object> onmsgestureend { get; }

        System.Func<object, object> onmsgesturetap { get; }

        System.Func<object, object> onmspointerout { get; }

        System.Func<object, object> onmsinertiastart { get; }

        System.Func<object, object> onmslostpointercapture { get; }

        System.Func<object, object> onmspointerover { get; }

        double msContentZoomFactor { get; }

        System.Func<object, object> onmspointerup { get; }

        System.Func<PointerEvent, object> onlostpointercapture { get; }

        System.Func<object, object> onmspointerenter { get; }

        System.Func<PointerEvent, object> ongotpointercapture { get; }

        System.Func<object, object> onmspointerleave { get; }

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
        string n { get; }
    }

    public partial interface SVGPathSegMovetoRel : SVGPathSeg
    {
        double y { get; }

        double x { get; }
    }

    public partial interface SVGLineElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedLength y1 { get; }

        SVGAnimatedLength x2 { get; }

        SVGAnimatedLength x1 { get; }

        SVGAnimatedLength y2 { get; }
    }

    public partial interface HTMLParagraphElement : HTMLElementDOML2DeprecatedTextFlowControl
    {
        string align { get; }
    }

    public partial interface HTMLAreasCollection : HTMLCollection
    {
        void remove(double index = 0.0);

        void add(HTMLElement element, object before = null);
    }

    public partial interface SVGDescElement : SVGElementSVGStylableSVGLangSpace
    {
    }

    public partial interface Node : EventTarget
    {
        double nodeType { get; }

        Node previousSibling { get; }

        string localName { get; }

        string namespaceURI { get; }

        string textContent { get; }

        Node parentNode { get; }

        Node nextSibling { get; }

        string nodeValue { get; }

        Node lastChild { get; }

        NodeList childNodes { get; }

        string nodeName { get; }

        Document ownerDocument { get; }

        NamedNodeMap attributes { get; }

        Node firstChild { get; }

        string prefix { get; }

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

        double ENTITY_REFERENCE_NODE { get; }

        double ATTRIBUTE_NODE { get; }

        double DOCUMENT_FRAGMENT_NODE { get; }

        double TEXT_NODE { get; }

        double ELEMENT_NODE { get; }

        double COMMENT_NODE { get; }

        double DOCUMENT_POSITION_DISCONNECTED { get; }

        double DOCUMENT_POSITION_CONTAINED_BY { get; }

        double DOCUMENT_POSITION_CONTAINS { get; }

        double DOCUMENT_TYPE_NODE { get; }

        double DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC { get; }

        double DOCUMENT_NODE { get; }

        double ENTITY_NODE { get; }

        double PROCESSING_INSTRUCTION_NODE { get; }

        double CDATA_SECTION_NODE { get; }

        double NOTATION_NODE { get; }

        double DOCUMENT_POSITION_FOLLOWING { get; }

        double DOCUMENT_POSITION_PRECEDING { get; }
    }

    public partial interface SVGPathSegCurvetoQuadraticSmoothRel : SVGPathSeg
    {
        double y { get; }

        double x { get; }
    }

    public partial interface DOML2DeprecatedListSpaceReduction
    {
        bool compact { get; }
    }

    public partial interface MSScriptHost
    {
    }

    public partial interface SVGClipPathElement : SVGElementSVGUnitTypesSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedEnumeration clipPathUnits { get; }
    }

    public partial interface MouseEvent : UIEvent
    {
        Element toElement { get; }

        double layerY { get; }

        Element fromElement { get; }

        double which { get; }

        double pageX { get; }

        double offsetY { get; }

        double x { get; }

        double y { get; }

        bool metaKey { get; }

        bool altKey { get; }

        bool ctrlKey { get; }

        double offsetX { get; }

        double screenX { get; }

        double clientY { get; }

        bool shiftKey { get; }

        double layerX { get; }

        double screenY { get; }

        EventTarget relatedTarget { get; }

        double button { get; }

        double pageY { get; }

        double buttons { get; }

        double clientX { get; }

        void initMouseEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            double buttonArg,
            EventTarget relatedTargetArg);

        bool getModifierState(string keyArg);
    }

    public partial interface RangeException
    {
        double code { get; }

        string message { get; }

        string name { get; }

        string toString();

        double INVALID_NODE_TYPE_ERR { get; }

        double BAD_BOUNDARYPOINTS_ERR { get; }
    }

    public partial interface SVGTextPositioningElement : SVGTextContentElement
    {
        SVGAnimatedLengthList y { get; }

        SVGAnimatedNumberList rotate { get; }

        SVGAnimatedLengthList dy { get; }

        SVGAnimatedLengthList x { get; }

        SVGAnimatedLengthList dx { get; }
    }

    public partial interface HTMLAppletElement :
        HTMLElementDOML2DeprecatedMarginStyleDOML2DeprecatedBorderStyleDOML2DeprecatedAlignmentStyleMSDataBindingExtensionsMSDataBindingRecordSetExtensions
    {
        double width { get; }

        string codeType { get; }

        string _object { get; }

        HTMLFormElement form { get; }

        string code { get; }

        string archive { get; }

        string alt { get; }

        string standby { get; }

        string classid { get; }

        string name { get; }

        string useMap { get; }

        string data { get; }

        string height { get; }

        string altHtml { get; }

        Document contentDocument { get; }

        string codeBase { get; }

        bool declare { get; }

        string type { get; }

        string BaseHref { get; }
    }

    public partial interface TextMetrics
    {
        double width { get; }
    }

    public partial interface DocumentEvent
    {
        Event createEvent(string eventInterface);
    }

    public partial interface HTMLOListElement : HTMLElementDOML2DeprecatedListSpaceReductionDOML2DeprecatedListNumberingAndBulletStyle
    {
        double start { get; }
    }

    public partial interface SVGPathSegLinetoVerticalRel : SVGPathSeg
    {
        double y { get; }
    }

    public partial interface SVGAnimatedString
    {
        string animVal { get; }

        string baseVal { get; }
    }

    public partial interface CDATASection : Text
    {
    }

    public partial interface StyleMedia
    {
        string type { get; }

        bool matchMedium(string mediaquery);
    }

    public partial interface HTMLSelectElement : HTMLElementMSHTMLCollectionExtensionsMSDataBindingExtensions
    {
        HTMLSelectElement options { get; }

        string value { get; }

        HTMLFormElement form { get; }

        string name { get; }

        double size { get; }

        double Length { get; }

        double selectedIndex { get; }

        bool multiple { get; }

        string type { get; }

        string validationMessage { get; }

        bool autofocus { get; }

        ValidityState validity { get; }

        bool required { get; }

        bool willValidate { get; }

        void remove(double index = 0.0);

        void add(HTMLElement element, object before = null);

        object item(object name = null, object index = null);

        object namedItem(string name);

        object this[string name] { get; set; }

        bool checkValidity();

        void setCustomValidity(string error);
    }

    public partial interface TextRange
    {
        double boundingLeft { get; }

        string htmlText { get; }

        double offsetLeft { get; }

        double boundingWidth { get; }

        double boundingHeight { get; }

        double boundingTop { get; }

        string text { get; }

        double offsetTop { get; }

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
        SVGStringList requiredFeatures { get; }

        SVGStringList requiredExtensions { get; }

        SVGStringList systemLanguage { get; }

        bool hasExtension(string extension);
    }

    public partial interface HTMLBlockElement : HTMLElementDOML2DeprecatedTextFlowControl
    {
        double width { get; }

        string cite { get; }
    }

    public partial interface CSSStyleSheet : StyleSheet
    {
        Element owningElement { get; }

        StyleSheetList imports { get; }

        bool isAlternate { get; }

        MSCSSRuleList rules { get; }

        bool isPrefAlternate { get; }

        bool readOnly { get; }

        string cssText { get; }

        CSSRule ownerRule { get; }

        string href { get; }

        CSSRuleList cssRules { get; }

        string id { get; }

        StyleSheetPageList pages { get; }

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
        string type { get; }

        string typeDetail { get; }

        TextRange createRange();

        void clear();

        TextRangeCollection createRangeCollection();

        void empty();
    }

    public partial interface HTMLMetaElement : HTMLElement
    {
        string httpEquiv { get; }

        string name { get; }

        string content { get; }

        string url { get; }

        string scheme { get; }

        string charset { get; }
    }

    public partial interface SVGPatternElement : SVGElementSVGUnitTypesSVGStylableSVGLangSpaceSVGTestsSVGFitToViewBoxSVGExternalResourcesRequiredSVGURIReference
    {
        SVGAnimatedEnumeration patternUnits { get; }

        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedEnumeration patternContentUnits { get; }

        SVGAnimatedTransformList patternTransform { get; }

        SVGAnimatedLength height { get; }
    }

    public partial interface SVGAnimatedAngle
    {
        SVGAngle animVal { get; }

        SVGAngle baseVal { get; }
    }

    public partial interface Selection
    {
        bool isCollapsed { get; }

        Node anchorNode { get; }

        Node focusNode { get; }

        double anchorOffset { get; }

        double focusOffset { get; }

        double rangeCount { get; }

        void addRange(Range range);

        void collapseToEnd();

        string toString();

        void selectAllChildren(Node parentNode);

        Range getRangeAt(double index);

        void collapse(Node parentNode, double offset);

        void removeAllRanges();

        void collapseToStart();

        void deleteFromDocument();

        void removeRange(Range range);
    }

    public partial interface SVGScriptElement : SVGElementSVGExternalResourcesRequiredSVGURIReference
    {
        string type { get; }
    }

    public partial interface HTMLDDElement : HTMLElement
    {
        bool noWrap { get; }
    }

    public partial interface MSDataBindingRecordSetReadonlyExtensions
    {
        object recordset { get; }

        object namedRecordset(string dataMember, object hierarchy = null);
    }

    public partial interface CSSStyleRule : CSSRule
    {
        string selectorText { get; }

        MSStyleCSSProperties style { get; }

        bool readOnly { get; }
    }

    public partial interface NodeIterator
    {
        double whatToShow { get; }

        NodeFilter filter { get; }

        Node root { get; }

        bool expandEntityReferences { get; }

        Node nextNode();

        void detach();

        Node previousNode();
    }

    public partial interface SVGViewElement : SVGElementSVGZoomAndPanSVGFitToViewBoxSVGExternalResourcesRequired
    {
        SVGStringList viewTarget { get; }
    }

    public partial interface HTMLLinkElement : HTMLElementLinkStyle
    {
        string rel { get; }

        string target { get; }

        string href { get; }

        string media { get; }

        string rev { get; }

        string type { get; }

        string charset { get; }

        string hreflang { get; }
    }

    public partial interface SVGLocatable
    {
        SVGElement farthestViewportElement { get; }

        SVGElement nearestViewportElement { get; }

        SVGRect getBBox();

        SVGMatrix getTransformToElement(SVGElement element);

        SVGMatrix getCTM();

        SVGMatrix getScreenCTM();
    }

    public partial interface HTMLFontElement : HTMLElementDOML2DeprecatedColorPropertyDOML2DeprecatedSizeProperty
    {
        string face { get; }
    }

    public partial interface SVGTitleElement : SVGElementSVGStylableSVGLangSpace
    {
    }

    public partial interface ControlRangeCollection
    {
        double Length { get; }

        object queryCommandValue(string cmdID);

        void remove(double index);

        void add(Element item);

        bool queryCommandIndeterm(string cmdID);

        void scrollIntoView(object varargStart = null);

        Element item(double index);

        Element this[double index] { get; set; }

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
        string urn { get; }

        System.Func<Event, object> onreadystatechange { get; }

        string name { get; }

        string readyState { get; }

        void doImport(string implementationUrl);

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface WindowSessionStorage
    {
        Storage sessionStorage { get; }
    }

    public partial interface SVGAnimatedTransformList
    {
        SVGTransformList animVal { get; }

        SVGTransformList baseVal { get; }
    }

    public partial interface HTMLTableCaptionElement : HTMLElement
    {
        string align { get; }

        string vAlign { get; }
    }

    public partial interface HTMLOptionElement : HTMLElementMSDataBindingExtensions
    {
        double index { get; }

        bool defaultSelected { get; }

        string value { get; }

        string text { get; }

        HTMLFormElement form { get; }

        string label { get; }

        bool selected { get; }
    }

    public partial interface HTMLMapElement : HTMLElement
    {
        string name { get; }

        HTMLAreasCollection areas { get; }
    }

    public partial interface HTMLMenuElement : HTMLElementDOML2DeprecatedListSpaceReduction
    {
        string type { get; }
    }

    public partial interface MouseWheelEvent : MouseEvent
    {
        double wheelDelta { get; }

        void initMouseWheelEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            double buttonArg,
            EventTarget relatedTargetArg,
            string modifiersListArg,
            double wheelDeltaArg);
    }

    public partial interface SVGFitToViewBox
    {
        SVGAnimatedRect viewBox { get; }

        SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; }
    }

    public partial interface SVGPointList
    {
        double numberOfItems { get; }

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
        SVGLengthList animVal { get; }

        SVGLengthList baseVal { get; }
    }

    public partial interface SVGAnimatedPreserveAspectRatio
    {
        SVGPreserveAspectRatio animVal { get; }

        SVGPreserveAspectRatio baseVal { get; }
    }

    public partial interface MSSiteModeEvent : Event
    {
        double buttonID { get; }

        string actionURL { get; }
    }

    public partial interface DOML2DeprecatedTextFlowControl
    {
        string clear { get; }
    }

    public partial interface StyleSheetPageList
    {
        double Length { get; }

        CSSPageRule item(double index);

        CSSPageRule this[double index] { get; set; }
    }

    public partial interface MSCSSProperties : CSSStyleDeclaration
    {
        string scrollbarShadowColor { get; }

        string scrollbarHighlightColor { get; }

        string layoutGridChar { get; }

        string layoutGridType { get; }

        string textAutospace { get; }

        string textKashidaSpace { get; }

        string writingMode { get; }

        string scrollbarFaceColor { get; }

        string backgroundPositionY { get; }

        string lineBreak { get; }

        string imeMode { get; }

        string msBlockProgression { get; }

        string layoutGridLine { get; }

        string scrollbarBaseColor { get; }

        string layoutGrid { get; }

        string layoutFlow { get; }

        string textKashida { get; }

        string filter { get; }

        string zoom { get; }

        string scrollbarArrowColor { get; }

        string behavior { get; }

        string backgroundPositionX { get; }

        string accelerator { get; }

        string layoutGridMode { get; }

        string textJustifyTrim { get; }

        string scrollbar3dLightColor { get; }

        string msInterpolationMode { get; }

        string scrollbarTrackColor { get; }

        string scrollbarDarkShadowColor { get; }

        string styleFloat { get; }

        object getAttribute(string attributeName, double flags = 0.0);

        void setAttribute(string attributeName, object AttributeValue, double flags = 0.0);

        bool removeAttribute(string attributeName, double flags = 0.0);
    }

    public partial interface HTMLCollection : MSHTMLCollectionExtensions
    {
        double Length { get; }

        Element item(object nameOrIndex = null, object optionalIndex = null);

        Element namedItem(string name);
    }

    public partial interface SVGExternalResourcesRequired
    {
        SVGAnimatedBoolean externalResourcesRequired { get; }
    }

    public partial interface HTMLImageElement : HTMLElementMSImageResourceExtensionsMSDataBindingExtensionsMSResourceMetadata
    {
        double width { get; }

        double vspace { get; }

        double naturalHeight { get; }

        string alt { get; }

        string align { get; }

        string src { get; }

        string useMap { get; }

        double naturalWidth { get; }

        string name { get; }

        double height { get; }

        string border { get; }

        double hspace { get; }

        string longDesc { get; }

        string href { get; }

        bool isMap { get; }

        bool complete { get; }

        bool msPlayToPrimary { get; }

        bool msPlayToDisabled { get; }

        object msPlayToSource { get; }

        string crossOrigin { get; }

        string msPlayToPreferredSourceUri { get; }
    }

    public partial interface HTMLAreaElement : HTMLElement
    {
        string protocol { get; }

        string search { get; }

        string alt { get; }

        string coords { get; }

        string hostname { get; }

        string port { get; }

        string pathname { get; }

        string host { get; }

        string hash { get; }

        string target { get; }

        string href { get; }

        bool noHref { get; }

        string shape { get; }

        string toString();
    }

    public partial interface EventTarget
    {
        void removeEventListener(string type, EventListener listener, bool useCapture = false);

        void addEventListener(string type, EventListener listener, bool useCapture = false);

        bool dispatchEvent(Event evt);
    }

    public partial interface SVGAngle
    {
        string valueAsString { get; }

        double valueInSpecifiedUnits { get; }

        double value { get; }

        double unitType { get; }

        void newValueSpecifiedUnits(double unitType, double valueInSpecifiedUnits);

        void convertToSpecifiedUnits(double unitType);

        double SVG_ANGLETYPE_RAD { get; }

        double SVG_ANGLETYPE_UNKNOWN { get; }

        double SVG_ANGLETYPE_UNSPECIFIED { get; }

        double SVG_ANGLETYPE_DEG { get; }

        double SVG_ANGLETYPE_GRAD { get; }
    }

    public partial interface HTMLButtonElement : HTMLElementMSDataBindingExtensions
    {
        string value { get; }

        object status { get; }

        HTMLFormElement form { get; }

        string name { get; }

        string type { get; }

        string validationMessage { get; }

        string formTarget { get; }

        bool willValidate { get; }

        string formAction { get; }

        bool autofocus { get; }

        ValidityState validity { get; }

        string formNoValidate { get; }

        string formEnctype { get; }

        string formMethod { get; }

        TextRange createTextRange();

        bool checkValidity();

        void setCustomValidity(string error);
    }

    public partial interface HTMLSourceElement : HTMLElement
    {
        string src { get; }

        string media { get; }

        string type { get; }

        string msKeySystem { get; }
    }

    public partial interface CanvasGradient
    {
        void addColorStop(double offset, string color);
    }

    public partial interface KeyboardEvent : UIEvent
    {
        double location { get; }

        double keyCode { get; }

        bool shiftKey { get; }

        double which { get; }

        string locale { get; }

        string key { get; }

        bool altKey { get; }

        bool metaKey { get; }

        string _char { get; }

        bool ctrlKey { get; }

        bool repeat { get; }

        double charCode { get; }

        bool getModifierState(string keyArg);

        void initKeyboardEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            string keyArg,
            double locationArg,
            string modifiersListArg,
            bool repeat,
            string locale);

        double DOM_KEY_LOCATION_RIGHT { get; }

        double DOM_KEY_LOCATION_STANDARD { get; }

        double DOM_KEY_LOCATION_LEFT { get; }

        double DOM_KEY_LOCATION_NUMPAD { get; }

        double DOM_KEY_LOCATION_JOYSTICK { get; }

        double DOM_KEY_LOCATION_MOBILE { get; }
    }

    public partial interface MessageEvent : Event
    {
        Window source { get; }

        string origin { get; }

        object data { get; }

        object ports { get; }

        void initMessageEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object dataArg, string originArg, string lastEventIdArg, Window sourceArg);
    }

    public partial interface SVGElement : Element
    {
        System.Func<MouseEvent, object> onmouseover { get; }

        SVGElement viewportElement { get; }

        System.Func<MouseEvent, object> onmousemove { get; }

        System.Func<MouseEvent, object> onmouseout { get; }

        System.Func<MouseEvent, object> ondblclick { get; }

        System.Func<FocusEvent, object> onfocusout { get; }

        System.Func<FocusEvent, object> onfocusin { get; }

        string xmlbase { get; }

        System.Func<MouseEvent, object> onmousedown { get; }

        System.Func<Event, object> onload { get; }

        System.Func<MouseEvent, object> onmouseup { get; }

        System.Func<MouseEvent, object> onclick { get; }

        SVGSVGElement ownerSVGElement { get; }

        string id { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface HTMLScriptElement : HTMLElement
    {
        bool defer { get; }

        string text { get; }

        string src { get; }

        string htmlFor { get; }

        string charset { get; }

        string type { get; }

        string _event { get; }

        bool async { get; }
    }

    public partial interface HTMLTableRowElement : HTMLElementHTMLTableAlignmentDOML2DeprecatedBackgroundColorStyle
    {
        double rowIndex { get; }

        HTMLCollection cells { get; }

        string align { get; }

        object borderColorLight { get; }

        double sectionRowIndex { get; }

        object borderColor { get; }

        object height { get; }

        object borderColorDark { get; }

        void deleteCell(double index = 0.0);

        HTMLElement insertCell(double index = 0.0);
    }

    public partial interface CanvasRenderingContext2D
    {
        double miterLimit { get; }

        string font { get; }

        string globalCompositeOperation { get; }

        string msFillRule { get; }

        string lineCap { get; }

        bool msImageSmoothingEnabled { get; }

        double lineDashOffset { get; }

        string shadowColor { get; }

        string lineJoin { get; }

        double shadowOffsetX { get; }

        double lineWidth { get; }

        HTMLCanvasElement canvas { get; }

        object strokeStyle { get; }

        double globalAlpha { get; }

        double shadowOffsetY { get; }

        object fillStyle { get; }

        double shadowBlur { get; }

        string textAlign { get; }

        string textBaseline { get; }

        void restore();

        void setTransform(double m11, double m12, double m21, double m22, double dx, double dy);

        void save();

        void arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise = false);

        TextMetrics measureText(string text);

        bool isPointInPath(double x, double y, string fillRule = null);

        void quadraticCurveTo(double cpx, double cpy, double x, double y);

        void putImageData(
            ImageData imagedata, double dx, double dy, double dirtyX = 0.0, double dirtyY = 0.0, double dirtyWidth = 0.0, double dirtyHeight = 0.0);

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

        void drawImage(
            HTMLElement image,
            double offsetX,
            double offsetY,
            double width = 0.0,
            double height = 0.0,
            double canvasOffsetX = 0.0,
            double canvasOffsetY = 0.0,
            double canvasImageWidth = 0.0,
            double canvasImageHeight = 0.0);

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
        double Length { get; }

        CSSStyleRule item(double index = 0.0);

        CSSStyleRule this[double index] { get; set; }
    }

    public partial interface SVGPathSegLinetoHorizontalAbs : SVGPathSeg
    {
        double x { get; }
    }

    public partial interface SVGPathSegArcAbs : SVGPathSeg
    {
        double y { get; }

        bool sweepFlag { get; }

        double r2 { get; }

        double x { get; }

        double angle { get; }

        double r1 { get; }

        bool largeArcFlag { get; }
    }

    public partial interface SVGTransformList
    {
        double numberOfItems { get; }

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
        string version { get; }
    }

    public partial interface SVGPathSegClosePath : SVGPathSeg
    {
    }

    public partial interface HTMLFrameElement : HTMLElementGetSVGDocumentMSDataBindingExtensions
    {
        object width { get; }

        string scrolling { get; }

        string marginHeight { get; }

        string marginWidth { get; }

        object borderColor { get; }

        object frameSpacing { get; }

        string frameBorder { get; }

        bool noResize { get; }

        Window contentWindow { get; }

        string src { get; }

        string name { get; }

        object height { get; }

        Document contentDocument { get; }

        string border { get; }

        string longDesc { get; }

        System.Func<Event, object> onload { get; }

        object security { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGAnimatedLength
    {
        SVGLength animVal { get; }

        SVGLength baseVal { get; }
    }

    public partial interface SVGAnimatedPoints
    {
        SVGPointList points { get; }

        SVGPointList animatedPoints { get; }
    }

    public partial interface SVGDefsElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
    }

    public partial interface HTMLQuoteElement : HTMLElement
    {
        string dateTime { get; }

        string cite { get; }
    }

    public partial interface CSSMediaRule : CSSRule
    {
        MediaList media { get; }

        CSSRuleList cssRules { get; }

        double insertRule(string rule, double index = 0.0);

        void deleteRule(double index = 0.0);
    }

    public partial interface WindowModal
    {
        object dialogArguments { get; }

        object returnValue { get; }
    }

    public partial interface XMLHttpRequest : EventTarget
    {
        object responseBody { get; }

        double status { get; }

        double readyState { get; }

        string responseText { get; }

        object responseXML { get; }

        System.Func<Event, object> ontimeout { get; }

        string statusText { get; }

        System.Func<Event, object> onreadystatechange { get; }

        double timeout { get; }

        System.Func<Event, object> onload { get; }

        object response { get; }

        bool withCredentials { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<UIEvent, object> onabort { get; }

        string responseType { get; }

        System.Func<ProgressEvent, object> onloadend { get; }

        XMLHttpRequestEventTarget upload { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onloadstart { get; }

        string msCaching { get; }

        void open(string method, string url, bool async = false, string user = null, string password = null);

        void send(object data = null);

        void abort();

        string getAllResponseHeaders();

        void setRequestHeader(string header, string value);

        string getResponseHeader(string header);

        bool msCachingEnabled();

        void overrideMimeType(string mime);

        double LOADING { get; }

        double DONE { get; }

        double UNSENT { get; }

        double OPENED { get; }

        double HEADERS_RECEIVED { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface HTMLTableHeaderCellElement : HTMLTableCellElement
    {
        string scope { get; }
    }

    public partial interface HTMLDListElement : HTMLElementDOML2DeprecatedListSpaceReduction
    {
    }

    public partial interface MSDataBindingExtensions
    {
        string dataSrc { get; }

        string dataFormatAs { get; }

        string dataFld { get; }
    }

    public partial interface SVGPathSegLinetoHorizontalRel : SVGPathSeg
    {
        double x { get; }
    }

    public partial interface SVGEllipseElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedLength ry { get; }

        SVGAnimatedLength cx { get; }

        SVGAnimatedLength rx { get; }

        SVGAnimatedLength cy { get; }
    }

    public partial interface SVGAElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequiredSVGURIReference
    {
        SVGAnimatedString target { get; }
    }

    public partial interface SVGStylable
    {
        SVGAnimatedString className { get; }

        CSSStyleDeclaration style { get; }
    }

    public partial interface SVGTransformable : SVGLocatable
    {
        SVGAnimatedTransformList transform { get; }
    }

    public partial interface HTMLFrameSetElement : HTMLElement
    {
        System.Func<Event, object> ononline { get; }

        object borderColor { get; }

        string rows { get; }

        string cols { get; }

        System.Func<FocusEvent, object> onblur { get; }

        object frameSpacing { get; }

        System.Func<FocusEvent, object> onfocus { get; }

        System.Func<MessageEvent, object> onmessage { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        string frameBorder { get; }

        System.Func<UIEvent, object> onresize { get; }

        string name { get; }

        System.Func<Event, object> onafterprint { get; }

        System.Func<Event, object> onbeforeprint { get; }

        System.Func<Event, object> onoffline { get; }

        string border { get; }

        System.Func<Event, object> onunload { get; }

        System.Func<Event, object> onhashchange { get; }

        System.Func<Event, object> onload { get; }

        System.Func<BeforeUnloadEvent, object> onbeforeunload { get; }

        System.Func<StorageEvent, object> onstorage { get; }

        System.Func<PageTransitionEvent, object> onpageshow { get; }

        System.Func<PageTransitionEvent, object> onpagehide { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface Screen : EventTarget
    {
        double width { get; }

        double deviceXDPI { get; }

        bool fontSmoothingEnabled { get; }

        double bufferDepth { get; }

        double logicalXDPI { get; }

        double systemXDPI { get; }

        double availHeight { get; }

        double height { get; }

        double logicalYDPI { get; }

        double systemYDPI { get; }

        double updateInterval { get; }

        double colorDepth { get; }

        double availWidth { get; }

        double deviceYDPI { get; }

        double pixelDepth { get; }

        string msOrientation { get; }

        System.Func<object, object> onmsorientationchange { get; }

        bool msLockOrientation(string orientation);

        bool msLockOrientation(Array<string> orientations);

        void msUnlockOrientation();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface Coordinates
    {
        double altitudeAccuracy { get; }

        double longitude { get; }

        double latitude { get; }

        double speed { get; }

        double heading { get; }

        double altitude { get; }

        double accuracy { get; }
    }

    public partial interface NavigatorGeolocation
    {
        Geolocation geolocation { get; }
    }

    public partial interface NavigatorContentUtils
    {
    }

    public delegate void EventListener(Event evt);

    public partial interface SVGLangSpace
    {
        string xmllang { get; }

        string xmlspace { get; }
    }

    public partial interface DataTransfer
    {
        string effectAllowed { get; }

        string dropEffect { get; }

        DOMStringList types { get; }

        FileList files { get; }

        bool clearData(string format = null);

        bool setData(string format, string data);

        string getData(string format);
    }

    public partial interface FocusEvent : UIEvent
    {
        EventTarget relatedTarget { get; }

        void initFocusEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, EventTarget relatedTargetArg);
    }

    public partial interface Range
    {
        double startOffset { get; }

        bool collapsed { get; }

        double endOffset { get; }

        Node startContainer { get; }

        Node endContainer { get; }

        Node commonAncestorContainer { get; }

        void setStart(Node refNode, double offset);

        void setEndBefore(Node refNode);

        void setStartBefore(Node refNode);

        void selectNode(Node refNode);

        void detach();

        ClientRect getBoundingClientRect();

        string toString();

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

        double END_TO_END { get; }

        double START_TO_START { get; }

        double START_TO_END { get; }

        double END_TO_START { get; }
    }

    public partial interface SVGPoint
    {
        double y { get; }

        double x { get; }

        SVGPoint matrixTransform(SVGMatrix matrix);
    }

    public partial interface MSPluginsCollection
    {
        double Length { get; }

        void refresh(bool reload = false);
    }

    public partial interface SVGAnimatedNumberList
    {
        SVGNumberList animVal { get; }

        SVGNumberList baseVal { get; }
    }

    public partial interface SVGSVGElement :
        SVGElementSVGStylableSVGZoomAndPanDocumentEventSVGLangSpaceSVGLocatableSVGTestsSVGFitToViewBoxSVGExternalResourcesRequired
    {
        SVGAnimatedLength width { get; }

        SVGAnimatedLength x { get; }

        string contentStyleType { get; }

        System.Func<object, object> onzoom { get; }

        SVGAnimatedLength y { get; }

        SVGRect viewport { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        double pixelUnitToMillimeterY { get; }

        System.Func<UIEvent, object> onresize { get; }

        double screenPixelToMillimeterY { get; }

        SVGAnimatedLength height { get; }

        System.Func<UIEvent, object> onabort { get; }

        string contentScriptType { get; }

        double pixelUnitToMillimeterX { get; }

        SVGPoint currentTranslate { get; }

        System.Func<Event, object> onunload { get; }

        double currentScale { get; }

        System.Func<UIEvent, object> onscroll { get; }

        double screenPixelToMillimeterX { get; }

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

    public partial interface HTMLLabelElement : HTMLElementMSDataBindingExtensions
    {
        string htmlFor { get; }

        HTMLFormElement form { get; }
    }

    public partial interface MSResourceMetadata
    {
        string protocol { get; }

        string fileSize { get; }

        string fileUpdatedDate { get; }

        string nameProp { get; }

        string fileCreatedDate { get; }

        string fileModifiedDate { get; }

        string mimeType { get; }
    }

    public partial interface HTMLLegendElement : HTMLElementMSDataBindingExtensions
    {
        string align { get; }

        HTMLFormElement form { get; }
    }

    public partial interface HTMLDirectoryElement : HTMLElementDOML2DeprecatedListSpaceReductionDOML2DeprecatedListNumberingAndBulletStyle
    {
    }

    public partial interface SVGAnimatedInteger
    {
        double animVal { get; }

        double baseVal { get; }
    }

    public partial interface SVGTextElement : SVGTextPositioningElementSVGTransformable
    {
    }

    public partial interface SVGTSpanElement : SVGTextPositioningElement
    {
    }

    public partial interface HTMLLIElement : HTMLElementDOML2DeprecatedListNumberingAndBulletStyle
    {
        double value { get; }
    }

    public partial interface SVGPathSegLinetoVerticalAbs : SVGPathSeg
    {
        double y { get; }
    }

    public partial interface MSStorageExtensions
    {
        double remainingSpace { get; }
    }

    public partial interface SVGStyleElement : SVGElementSVGLangSpace
    {
        string media { get; }

        string type { get; }

        string title { get; }
    }

    public partial interface MSCurrentStyleCSSProperties : MSCSSProperties
    {
        string blockDirection { get; }

        string clipBottom { get; }

        string clipLeft { get; }

        string clipRight { get; }

        string clipTop { get; }

        string hasLayout { get; }
    }

    public partial interface MSHTMLCollectionExtensions
    {
        object urns(object urn);

        object tags(object tagName);
    }

    public partial interface Storage : MSStorageExtensions
    {
        double Length { get; }

        object getItem(string key);

        object this[string key] { get; set; }

        void setItem(string key, string data);

        void clear();

        void removeItem(string key);

        string key(double index);

        string this[double index] { get; set; }
    }

    public partial interface HTMLIFrameElement : HTMLElementGetSVGDocumentMSDataBindingExtensions
    {
        string width { get; }

        string scrolling { get; }

        string marginHeight { get; }

        string marginWidth { get; }

        object frameSpacing { get; }

        string frameBorder { get; }

        bool noResize { get; }

        double vspace { get; }

        Window contentWindow { get; }

        string align { get; }

        string src { get; }

        string name { get; }

        string height { get; }

        string border { get; }

        Document contentDocument { get; }

        double hspace { get; }

        string longDesc { get; }

        object security { get; }

        System.Func<Event, object> onload { get; }

        DOMSettableTokenList sandbox { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface TextRangeCollection
    {
        double Length { get; }

        TextRange item(double index);

        TextRange this[double index] { get; set; }
    }

    public partial interface HTMLBodyElement : HTMLElementDOML2DeprecatedBackgroundStyleDOML2DeprecatedBackgroundColorStyle
    {
        string scroll { get; }

        System.Func<Event, object> ononline { get; }

        System.Func<FocusEvent, object> onblur { get; }

        bool noWrap { get; }

        System.Func<FocusEvent, object> onfocus { get; }

        System.Func<MessageEvent, object> onmessage { get; }

        object text { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        string bgProperties { get; }

        System.Func<UIEvent, object> onresize { get; }

        object link { get; }

        object aLink { get; }

        object bottomMargin { get; }

        object topMargin { get; }

        System.Func<Event, object> onafterprint { get; }

        object vLink { get; }

        System.Func<Event, object> onbeforeprint { get; }

        System.Func<Event, object> onoffline { get; }

        System.Func<Event, object> onunload { get; }

        System.Func<Event, object> onhashchange { get; }

        System.Func<Event, object> onload { get; }

        object rightMargin { get; }

        System.Func<BeforeUnloadEvent, object> onbeforeunload { get; }

        object leftMargin { get; }

        System.Func<StorageEvent, object> onstorage { get; }

        System.Func<PopStateEvent, object> onpopstate { get; }

        System.Func<PageTransitionEvent, object> onpageshow { get; }

        System.Func<PageTransitionEvent, object> onpagehide { get; }

        TextRange createTextRange();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface DocumentType : Node
    {
        string name { get; }

        NamedNodeMap notations { get; }

        string systemId { get; }

        string internalSubset { get; }

        NamedNodeMap entities { get; }

        string publicId { get; }
    }

    public partial interface SVGRadialGradientElement : SVGGradientElement
    {
        SVGAnimatedLength cx { get; }

        SVGAnimatedLength r { get; }

        SVGAnimatedLength cy { get; }

        SVGAnimatedLength fx { get; }

        SVGAnimatedLength fy { get; }
    }

    public partial interface MutationEvent : Event
    {
        string newValue { get; }

        double attrChange { get; }

        string attrName { get; }

        string prevValue { get; }

        Node relatedNode { get; }

        void initMutationEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Node relatedNodeArg,
            string prevValueArg,
            string newValueArg,
            string attrNameArg,
            double attrChangeArg);

        double MODIFICATION { get; }

        double REMOVAL { get; }

        double ADDITION { get; }
    }

    public partial interface DragEvent : MouseEvent
    {
        DataTransfer dataTransfer { get; }

        void initDragEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            double buttonArg,
            EventTarget relatedTargetArg,
            DataTransfer dataTransferArg);

        void msConvertURL(File file, string targetType, string targetURL = null);
    }

    public partial interface HTMLTableSectionElement : HTMLElementHTMLTableAlignmentDOML2DeprecatedBackgroundColorStyle
    {
        string align { get; }

        HTMLCollection rows { get; }

        void deleteRow(double index = 0.0);

        object moveRow(double indexFrom = 0.0, double indexTo = 0.0);

        HTMLElement insertRow(double index = 0.0);
    }

    public partial interface DOML2DeprecatedListNumberingAndBulletStyle
    {
        string type { get; }
    }

    public partial interface HTMLInputElement : HTMLElementMSDataBindingExtensions
    {
        string width { get; }

        bool status { get; }

        HTMLFormElement form { get; }

        double selectionStart { get; }

        bool indeterminate { get; }

        bool readOnly { get; }

        double size { get; }

        double loop { get; }

        double selectionEnd { get; }

        string vrml { get; }

        string lowsrc { get; }

        double vspace { get; }

        string accept { get; }

        string alt { get; }

        bool defaultChecked { get; }

        string align { get; }

        string value { get; }

        string src { get; }

        string name { get; }

        string useMap { get; }

        string height { get; }

        string border { get; }

        string dynsrc { get; }

        bool _checked { get; }

        double hspace { get; }

        double maxLength { get; }

        string type { get; }

        string defaultValue { get; }

        bool complete { get; }

        string start { get; }

        string validationMessage { get; }

        FileList files { get; }

        string Max { get; }

        string formTarget { get; }

        bool willValidate { get; }

        string step { get; }

        bool autofocus { get; }

        bool required { get; }

        string formEnctype { get; }

        double valueAsNumber { get; }

        string placeholder { get; }

        string formMethod { get; }

        HTMLElement list { get; }

        string autocomplete { get; }

        string min { get; }

        string formAction { get; }

        string pattern { get; }

        ValidityState validity { get; }

        string formNoValidate { get; }

        bool multiple { get; }

        TextRange createTextRange();

        void setSelectionRange(double start, double end);

        void select();

        bool checkValidity();

        void stepDown(double n = 0.0);

        void stepUp(double n = 0.0);

        void setCustomValidity(string error);
    }

    public partial interface HTMLAnchorElement : HTMLElementMSDataBindingExtensions
    {
        string rel { get; }

        string protocol { get; }

        string search { get; }

        string coords { get; }

        string hostname { get; }

        string pathname { get; }

        string Methods { get; }

        string target { get; }

        string protocolLong { get; }

        string href { get; }

        string name { get; }

        string charset { get; }

        string hreflang { get; }

        string port { get; }

        string host { get; }

        string hash { get; }

        string nameProp { get; }

        string urn { get; }

        string rev { get; }

        string shape { get; }

        string type { get; }

        string mimeType { get; }

        string text { get; }

        string toString();
    }

    public partial interface HTMLParamElement : HTMLElement
    {
        string value { get; }

        string name { get; }

        string type { get; }

        string valueType { get; }
    }

    public partial interface SVGImageElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequiredSVGURIReference
    {
        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedLength height { get; }
    }

    public partial interface SVGAnimatedNumber
    {
        double animVal { get; }

        double baseVal { get; }
    }

    public partial interface PerformanceTiming
    {
        double redirectStart { get; }

        double domainLookupEnd { get; }

        double responseStart { get; }

        double domComplete { get; }

        double domainLookupStart { get; }

        double loadEventStart { get; }

        double msFirstPaint { get; }

        double unloadEventEnd { get; }

        double fetchStart { get; }

        double requestStart { get; }

        double domInteractive { get; }

        double navigationStart { get; }

        double connectEnd { get; }

        double loadEventEnd { get; }

        double connectStart { get; }

        double responseEnd { get; }

        double domLoading { get; }

        double redirectEnd { get; }

        double unloadEventStart { get; }

        double domContentLoadedEventStart { get; }

        double domContentLoadedEventEnd { get; }

        object toJSON();
    }

    public partial interface HTMLPreElement : HTMLElementDOML2DeprecatedTextFlowControl
    {
        double width { get; }

        string cite { get; }
    }

    public partial interface EventException
    {
        double code { get; }

        string message { get; }

        string name { get; }

        string toString();

        double DISPATCH_REQUEST_ERR { get; }

        double UNSPECIFIED_EVENT_TYPE_ERR { get; }
    }

    public partial interface MSNavigatorDoNotTrack
    {
        string msDoNotTrack { get; }

        void removeSiteSpecificTrackingException(ExceptionInformation args);

        void removeWebWideTrackingException(ExceptionInformation args);

        void storeWebWideTrackingException(StoreExceptionsInformation args);

        void storeSiteSpecificTrackingException(StoreSiteSpecificExceptionsInformation args);

        bool confirmSiteSpecificTrackingException(ConfirmSiteSpecificExceptionsInformation args);

        bool confirmWebWideTrackingException(ExceptionInformation args);
    }

    public partial interface NavigatorOnLine
    {
        bool onLine { get; }
    }

    public partial interface WindowLocalStorage
    {
        Storage localStorage { get; }
    }

    public partial interface SVGMetadataElement : SVGElement
    {
    }

    public partial interface SVGPathSegArcRel : SVGPathSeg
    {
        double y { get; }

        bool sweepFlag { get; }

        double r2 { get; }

        double x { get; }

        double angle { get; }

        double r1 { get; }

        bool largeArcFlag { get; }
    }

    public partial interface SVGPathSegMovetoAbs : SVGPathSeg
    {
        double y { get; }

        double x { get; }
    }

    public partial interface SVGStringList
    {
        double numberOfItems { get; }

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
        double timeout { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onload { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<Event, object> ontimeout { get; }

        string responseText { get; }

        string contentType { get; }

        void open(string method, string url);

        void abort();

        void send(object data = null);

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface DOML2DeprecatedBackgroundColorStyle
    {
        object bgColor { get; }
    }

    public partial interface ElementTraversal
    {
        double childElementCount { get; }

        Element previousElementSibling { get; }

        Element lastElementChild { get; }

        Element nextElementSibling { get; }

        Element firstElementChild { get; }
    }

    public partial interface SVGLength
    {
        string valueAsString { get; }

        double valueInSpecifiedUnits { get; }

        double value { get; }

        double unitType { get; }

        void newValueSpecifiedUnits(double unitType, double valueInSpecifiedUnits);

        void convertToSpecifiedUnits(double unitType);

        double SVG_LENGTHTYPE_NUMBER { get; }

        double SVG_LENGTHTYPE_CM { get; }

        double SVG_LENGTHTYPE_PC { get; }

        double SVG_LENGTHTYPE_PERCENTAGE { get; }

        double SVG_LENGTHTYPE_MM { get; }

        double SVG_LENGTHTYPE_PT { get; }

        double SVG_LENGTHTYPE_IN { get; }

        double SVG_LENGTHTYPE_EMS { get; }

        double SVG_LENGTHTYPE_PX { get; }

        double SVG_LENGTHTYPE_UNKNOWN { get; }

        double SVG_LENGTHTYPE_EXS { get; }
    }

    public partial interface SVGPolygonElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGAnimatedPointsSVGTestsSVGExternalResourcesRequired
    {
    }

    public partial interface HTMLPhraseElement : HTMLElement
    {
        string dateTime { get; }

        string cite { get; }
    }

    public partial interface NavigatorStorageUtils
    {
    }

    public partial interface SVGPathSegCurvetoCubicRel : SVGPathSeg
    {
        double y { get; }

        double y1 { get; }

        double x2 { get; }

        double x { get; }

        double x1 { get; }

        double y2 { get; }
    }

    public partial interface SVGTextContentElement : SVGElementSVGStylableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedLength textLength { get; }

        SVGAnimatedEnumeration lengthAdjust { get; }

        double getCharNumAtPosition(SVGPoint point);

        SVGPoint getStartPositionOfChar(double charnum);

        SVGRect getExtentOfChar(double charnum);

        double getComputedTextLength();

        double getSubStringLength(double charnum, double nchars);

        void selectSubString(double charnum, double nchars);

        double getNumberOfChars();

        double getRotationOfChar(double charnum);

        SVGPoint getEndPositionOfChar(double charnum);

        double LENGTHADJUST_SPACING { get; }

        double LENGTHADJUST_SPACINGANDGLYPHS { get; }

        double LENGTHADJUST_UNKNOWN { get; }
    }

    public partial interface DOML2DeprecatedColorProperty
    {
        string color { get; }
    }

    public partial interface Location
    {
        string hash { get; }

        string protocol { get; }

        string search { get; }

        string href { get; }

        string hostname { get; }

        string port { get; }

        string pathname { get; }

        string host { get; }

        void reload(bool flag = false);

        void replace(string url);

        void assign(string url);

        string toString();
    }

    public partial interface HTMLTitleElement : HTMLElement
    {
        string text { get; }
    }

    public partial interface HTMLStyleElement : HTMLElementLinkStyle
    {
        string media { get; }

        string type { get; }
    }

    public partial interface PerformanceEntry
    {
        string name { get; }

        double startTime { get; }

        double duration { get; }

        string entryType { get; }
    }

    public partial interface SVGTransform
    {
        double type { get; }

        double angle { get; }

        SVGMatrix matrix { get; }

        void setTranslate(double tx, double ty);

        void setScale(double sx, double sy);

        void setMatrix(SVGMatrix matrix);

        void setSkewY(double angle);

        void setRotate(double angle, double cx, double cy);

        void setSkewX(double angle);

        double SVG_TRANSFORM_SKEWX { get; }

        double SVG_TRANSFORM_UNKNOWN { get; }

        double SVG_TRANSFORM_SCALE { get; }

        double SVG_TRANSFORM_TRANSLATE { get; }

        double SVG_TRANSFORM_MATRIX { get; }

        double SVG_TRANSFORM_ROTATE { get; }

        double SVG_TRANSFORM_SKEWY { get; }
    }

    public partial interface UIEvent : Event
    {
        double detail { get; }

        Window view { get; }

        void initUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg);
    }

    public partial interface SVGURIReference
    {
        SVGAnimatedString href { get; }
    }

    public partial interface SVGPathSeg
    {
        double pathSegType { get; }

        string pathSegTypeAsLetter { get; }

        double PATHSEG_MOVETO_REL { get; }

        double PATHSEG_LINETO_VERTICAL_REL { get; }

        double PATHSEG_CURVETO_CUBIC_SMOOTH_ABS { get; }

        double PATHSEG_CURVETO_QUADRATIC_REL { get; }

        double PATHSEG_CURVETO_CUBIC_ABS { get; }

        double PATHSEG_LINETO_HORIZONTAL_ABS { get; }

        double PATHSEG_CURVETO_QUADRATIC_ABS { get; }

        double PATHSEG_LINETO_ABS { get; }

        double PATHSEG_CLOSEPATH { get; }

        double PATHSEG_LINETO_HORIZONTAL_REL { get; }

        double PATHSEG_CURVETO_CUBIC_SMOOTH_REL { get; }

        double PATHSEG_LINETO_REL { get; }

        double PATHSEG_CURVETO_QUADRATIC_SMOOTH_ABS { get; }

        double PATHSEG_ARC_REL { get; }

        double PATHSEG_CURVETO_CUBIC_REL { get; }

        double PATHSEG_UNKNOWN { get; }

        double PATHSEG_LINETO_VERTICAL_ABS { get; }

        double PATHSEG_ARC_ABS { get; }

        double PATHSEG_MOVETO_ABS { get; }

        double PATHSEG_CURVETO_QUADRATIC_SMOOTH_REL { get; }
    }

    public partial interface WheelEvent : MouseEvent
    {
        double deltaZ { get; }

        double deltaX { get; }

        double deltaMode { get; }

        double deltaY { get; }

        void initWheelEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            double buttonArg,
            EventTarget relatedTargetArg,
            string modifiersListArg,
            double deltaXArg,
            double deltaYArg,
            double deltaZArg,
            double deltaMode);

        void getCurrentPoint(Element element);

        double DOM_DELTA_PIXEL { get; }

        double DOM_DELTA_LINE { get; }

        double DOM_DELTA_PAGE { get; }
    }

    public partial interface MSEventAttachmentTarget
    {
        bool attachEvent(string _event, EventListener listener);

        void detachEvent(string _event, EventListener listener);
    }

    public partial interface SVGNumber
    {
        double value { get; }
    }

    public partial interface SVGPathElement : SVGElementSVGStylableSVGAnimatedPathDataSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
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
        string version { get; }

        string userAgent { get; }
    }

    public partial interface Text : CharacterDataMSNodeExtensions
    {
        string wholeText { get; }

        Text splitText(double offset);

        Text replaceWholeText(string content);
    }

    public partial interface SVGAnimatedRect
    {
        SVGRect animVal { get; }

        SVGRect baseVal { get; }
    }

    public partial interface CSSNamespaceRule : CSSRule
    {
        string namespaceURI { get; }

        string prefix { get; }
    }

    public partial interface SVGPathSegList
    {
        double numberOfItems { get; }

        SVGPathSeg replaceItem(SVGPathSeg newItem, double index);

        SVGPathSeg getItem(double index);

        void clear();

        SVGPathSeg appendItem(SVGPathSeg newItem);

        SVGPathSeg initialize(SVGPathSeg newItem);

        SVGPathSeg removeItem(double index);

        SVGPathSeg insertItemBefore(SVGPathSeg newItem, double index);
    }

    public partial interface HTMLUnknownElement : HTMLElementMSDataBindingRecordSetReadonlyExtensions
    {
    }

    public partial interface HTMLAudioElement : HTMLMediaElement
    {
    }

    public partial interface MSImageResourceExtensions
    {
        string dynsrc { get; }

        string vrml { get; }

        string lowsrc { get; }

        string start { get; }

        double loop { get; }
    }

    public partial interface PositionError
    {
        double code { get; }

        string message { get; }

        string toString();

        double POSITION_UNAVAILABLE { get; }

        double PERMISSION_DENIED { get; }

        double TIMEOUT { get; }
    }

    public partial interface HTMLTableCellElement : HTMLElementHTMLTableAlignmentDOML2DeprecatedBackgroundStyleDOML2DeprecatedBackgroundColorStyle
    {
        double width { get; }

        string headers { get; }

        double cellIndex { get; }

        string align { get; }

        object borderColorLight { get; }

        double colSpan { get; }

        object borderColor { get; }

        string axis { get; }

        object height { get; }

        bool noWrap { get; }

        string abbr { get; }

        double rowSpan { get; }

        string scope { get; }

        object borderColorDark { get; }
    }

    public partial interface SVGElementInstance : EventTarget
    {
        SVGElementInstance previousSibling { get; }

        SVGElementInstance parentNode { get; }

        SVGElementInstance lastChild { get; }

        SVGElementInstance nextSibling { get; }

        SVGElementInstanceList childNodes { get; }

        SVGUseElement correspondingUseElement { get; }

        SVGElement correspondingElement { get; }

        SVGElementInstance firstChild { get; }
    }

    public partial interface MSNamespaceInfoCollection
    {
        double Length { get; }

        object add(string _namespace = null, string urn = null, object implementationUrl = null);

        object item(object index);
    }

    public partial interface SVGCircleElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedLength cx { get; }

        SVGAnimatedLength r { get; }

        SVGAnimatedLength cy { get; }
    }

    public partial interface StyleSheetList
    {
        double Length { get; }

        StyleSheet item(double index = 0.0);

        StyleSheet this[double index] { get; set; }
    }

    public partial interface CSSImportRule : CSSRule
    {
        CSSStyleSheet styleSheet { get; }

        string href { get; }

        MediaList media { get; }
    }

    public partial interface CustomEvent : Event
    {
        object detail { get; }

        void initCustomEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object detailArg);
    }

    public partial interface HTMLBaseFontElement : HTMLElementDOML2DeprecatedColorProperty
    {
        string face { get; }

        double size { get; }
    }

    public partial interface HTMLTextAreaElement : HTMLElementMSDataBindingExtensions
    {
        string value { get; }

        object status { get; }

        HTMLFormElement form { get; }

        string name { get; }

        double selectionStart { get; }

        double rows { get; }

        double cols { get; }

        bool readOnly { get; }

        string wrap { get; }

        double selectionEnd { get; }

        string type { get; }

        string defaultValue { get; }

        string validationMessage { get; }

        bool autofocus { get; }

        ValidityState validity { get; }

        bool required { get; }

        double maxLength { get; }

        bool willValidate { get; }

        string placeholder { get; }

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
        double vspace { get; }

        double hspace { get; }
    }

    public partial interface MSWindowModeless
    {
        object dialogTop { get; }

        object dialogLeft { get; }

        object dialogWidth { get; }

        object dialogHeight { get; }

        object menuArguments { get; }
    }

    public partial interface DOML2DeprecatedAlignmentStyle
    {
        string align { get; }
    }

    public partial interface HTMLMarqueeElement : HTMLElementMSDataBindingExtensionsDOML2DeprecatedBackgroundColorStyle
    {
        string width { get; }

        System.Func<Event, object> onbounce { get; }

        double vspace { get; }

        bool trueSpeed { get; }

        double scrollAmount { get; }

        double scrollDelay { get; }

        string behavior { get; }

        string height { get; }

        double loop { get; }

        string direction { get; }

        double hspace { get; }

        System.Func<Event, object> onstart { get; }

        System.Func<Event, object> onfinish { get; }

        void stop();

        void start();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGRect
    {
        double y { get; }

        double width { get; }

        double x { get; }

        double height { get; }
    }

    public partial interface MSNodeExtensions
    {
        Node swapNode(Node otherNode);

        Node removeNode(bool deep = false);

        Node replaceNode(Node replacement);
    }

    public partial interface History
    {
        double Length { get; }

        object state { get; }

        void back(object distance = null);

        void forward(object distance = null);

        void go(object delta = null);

        void replaceState(object statedata, string title, string url = null);

        void pushState(object statedata, string title, string url = null);
    }

    public partial interface SVGPathSegCurvetoCubicAbs : SVGPathSeg
    {
        double y { get; }

        double y1 { get; }

        double x2 { get; }

        double x { get; }

        double x1 { get; }

        double y2 { get; }
    }

    public partial interface SVGPathSegCurvetoQuadraticAbs : SVGPathSeg
    {
        double y { get; }

        double y1 { get; }

        double x { get; }

        double x1 { get; }
    }

    public partial interface TimeRanges
    {
        double Length { get; }

        double start(double index);

        double end(double index);
    }

    public partial interface CSSRule
    {
        string cssText { get; }

        CSSStyleSheet parentStyleSheet { get; }

        CSSRule parentRule { get; }

        double type { get; }

        double IMPORT_RULE { get; }

        double MEDIA_RULE { get; }

        double STYLE_RULE { get; }

        double NAMESPACE_RULE { get; }

        double PAGE_RULE { get; }

        double UNKNOWN_RULE { get; }

        double FONT_FACE_RULE { get; }

        double CHARSET_RULE { get; }

        double KEYFRAMES_RULE { get; }

        double KEYFRAME_RULE { get; }

        double VIEWPORT_RULE { get; }
    }

    public partial interface SVGPathSegLinetoAbs : SVGPathSeg
    {
        double y { get; }

        double x { get; }
    }

    public partial interface HTMLModElement : HTMLElement
    {
        string dateTime { get; }

        string cite { get; }
    }

    public partial interface SVGMatrix
    {
        double e { get; }

        double c { get; }

        double a { get; }

        double b { get; }

        double d { get; }

        double f { get; }

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
        Document document { get; }

        bool isOpen { get; }

        void show(double x, double y, double w, double h, object element = null);

        void hide();
    }

    public partial interface BeforeUnloadEvent : Event
    {
        string returnValue { get; }
    }

    public partial interface SVGUseElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequiredSVGURIReference
    {
        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGElementInstance animatedInstanceRoot { get; }

        SVGElementInstance instanceRoot { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedLength height { get; }
    }

    public partial interface Event
    {
        double timeStamp { get; }

        bool defaultPrevented { get; }

        bool isTrusted { get; }

        EventTarget currentTarget { get; }

        bool cancelBubble { get; }

        EventTarget target { get; }

        double eventPhase { get; }

        bool cancelable { get; }

        string type { get; }

        Element srcElement { get; }

        bool bubbles { get; }

        void initEvent(string eventTypeArg, bool canBubbleArg, bool cancelableArg);

        void stopPropagation();

        void stopImmediatePropagation();

        void preventDefault();

        double CAPTURING_PHASE { get; }

        double AT_TARGET { get; }

        double BUBBLING_PHASE { get; }
    }

    public partial interface ImageData
    {
        double width { get; }

        Array<double> data { get; }

        double height { get; }
    }

    public partial interface HTMLTableColElement : HTMLElementHTMLTableAlignment
    {
        object width { get; }

        string align { get; }

        double span { get; }
    }

    public partial interface SVGException
    {
        double code { get; }

        string message { get; }

        string name { get; }

        string toString();

        double SVG_MATRIX_NOT_INVERTABLE { get; }

        double SVG_WRONG_TYPE_ERR { get; }

        double SVG_INVALID_VALUE_ERR { get; }
    }

    public partial interface SVGLinearGradientElement : SVGGradientElement
    {
        SVGAnimatedLength y1 { get; }

        SVGAnimatedLength x2 { get; }

        SVGAnimatedLength x1 { get; }

        SVGAnimatedLength y2 { get; }
    }

    public partial interface HTMLTableAlignment
    {
        string ch { get; }

        string vAlign { get; }

        string chOff { get; }
    }

    public partial interface SVGAnimatedEnumeration
    {
        double animVal { get; }

        double baseVal { get; }
    }

    public partial interface DOML2DeprecatedSizeProperty
    {
        double size { get; }
    }

    public partial interface HTMLUListElement : HTMLElementDOML2DeprecatedListSpaceReductionDOML2DeprecatedListNumberingAndBulletStyle
    {
    }

    public partial interface SVGRectElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGAnimatedLength ry { get; }

        SVGAnimatedLength rx { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedLength height { get; }
    }

    public delegate void ErrorEventHandler(Event _event, string source, double fileno, double columnNumber);

    public partial interface HTMLDivElement : HTMLElementMSDataBindingExtensions
    {
        string align { get; }

        bool noWrap { get; }
    }

    public partial interface DOML2DeprecatedBorderStyle
    {
        string border { get; }
    }

    public partial interface NamedNodeMap
    {
        double Length { get; }

        Attr removeNamedItemNS(string namespaceURI, string localName);

        Attr item(double index);

        Attr this[double index] { get; set; }

        Attr removeNamedItem(string name);

        Attr getNamedItem(string name);

        Attr setNamedItem(Attr arg);

        Attr getNamedItemNS(string namespaceURI, string localName);

        Attr setNamedItemNS(Attr arg);
    }

    public partial interface MediaList
    {
        double Length { get; }

        string mediaText { get; }

        void deleteMedium(string oldMedium);

        void appendMedium(string newMedium);

        string item(double index);

        string this[double index] { get; set; }

        string toString();
    }

    public partial interface SVGPathSegCurvetoQuadraticSmoothAbs : SVGPathSeg
    {
        double y { get; }

        double x { get; }
    }

    public partial interface SVGPathSegCurvetoCubicSmoothRel : SVGPathSeg
    {
        double y { get; }

        double x2 { get; }

        double x { get; }

        double y2 { get; }
    }

    public partial interface SVGLengthList
    {
        double numberOfItems { get; }

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
        string target { get; }

        string data { get; }
    }

    public partial interface MSWindowExtensions
    {
        string status { get; }

        System.Func<MouseEvent, object> onmouseleave { get; }

        double screenLeft { get; }

        object offscreenBuffering { get; }

        double maxConnectionsPerServer { get; }

        System.Func<MouseEvent, object> onmouseenter { get; }

        DataTransfer clipboardData { get; }

        string defaultStatus { get; }

        Navigator clientInformation { get; }

        bool closed { get; }

        System.Func<Event, object> onhelp { get; }

        External external { get; }

        MSEventObj _event { get; }

        System.Func<FocusEvent, object> onfocusout { get; }

        double screenTop { get; }

        System.Func<FocusEvent, object> onfocusin { get; }

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
        double Length { get; }

        string item(double index);
    }

    public partial interface CSSFontFaceRule : CSSRule
    {
        CSSStyleDeclaration style { get; }
    }

    public partial interface DOML2DeprecatedBackgroundStyle
    {
        string background { get; }
    }

    public partial interface TextEvent : UIEvent
    {
        double inputMethod { get; }

        string data { get; }

        string locale { get; }

        void initTextEvent(string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, string dataArg, double inputMethod, string locale);

        double DOM_INPUT_METHOD_KEYBOARD { get; }

        double DOM_INPUT_METHOD_DROP { get; }

        double DOM_INPUT_METHOD_IME { get; }

        double DOM_INPUT_METHOD_SCRIPT { get; }

        double DOM_INPUT_METHOD_VOICE { get; }

        double DOM_INPUT_METHOD_UNKNOWN { get; }

        double DOM_INPUT_METHOD_PASTE { get; }

        double DOM_INPUT_METHOD_HANDWRITING { get; }

        double DOM_INPUT_METHOD_OPTION { get; }

        double DOM_INPUT_METHOD_MULTIMODAL { get; }
    }

    public partial interface DocumentFragment : NodeNodeSelectorMSEventAttachmentTargetMSNodeExtensions
    {
    }

    public partial interface SVGPolylineElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGAnimatedPointsSVGTestsSVGExternalResourcesRequired
    {
    }

    public partial interface SVGAnimatedPathData
    {
        SVGPathSegList pathSegList { get; }
    }

    public partial interface Position
    {
        Date timestamp { get; }

        Coordinates coords { get; }
    }

    public partial interface BookmarkCollection
    {
        double Length { get; }

        object item(double index);

        object this[double index] { get; set; }
    }

    public partial interface PerformanceMark : PerformanceEntry
    {
    }

    public partial interface CSSPageRule : CSSRule
    {
        string pseudoClass { get; }

        string selectorText { get; }

        string selector { get; }

        CSSStyleDeclaration style { get; }
    }

    public partial interface HTMLBRElement : HTMLElement
    {
        string clear { get; }
    }

    public partial interface MSNavigatorExtensions
    {
        string userLanguage { get; }

        MSPluginsCollection plugins { get; }

        bool cookieEnabled { get; }

        string appCodeName { get; }

        string cpuClass { get; }

        string appMinorVersion { get; }

        double connectionSpeed { get; }

        string browserLanguage { get; }

        MSMimeTypesCollection mimeTypes { get; }

        string systemLanguage { get; }

        string language { get; }

        bool javaEnabled();

        bool taintEnabled();
    }

    public partial interface HTMLSpanElement : HTMLElementMSDataBindingExtensions
    {
    }

    public partial interface HTMLHeadElement : HTMLElement
    {
        string profile { get; }
    }

    public partial interface HTMLHeadingElement : HTMLElementDOML2DeprecatedTextFlowControl
    {
        string align { get; }
    }

    public partial interface HTMLFormElement : HTMLElementMSHTMLCollectionExtensions
    {
        double Length { get; }

        string target { get; }

        string acceptCharset { get; }

        string enctype { get; }

        HTMLCollection elements { get; }

        string action { get; }

        string name { get; }

        string method { get; }

        string encoding { get; }

        string autocomplete { get; }

        bool noValidate { get; }

        void reset();

        object item(object name = null, object index = null);

        void submit();

        object namedItem(string name);

        object this[string name] { get; set; }

        bool checkValidity();
    }

    public partial interface SVGZoomAndPan
    {
        double zoomAndPan { get; }

        double SVG_ZOOMANDPAN_MAGNIFY { get; }

        double SVG_ZOOMANDPAN_UNKNOWN { get; }

        double SVG_ZOOMANDPAN_DISABLE { get; }
    }

    public partial interface ElementCSSInlineStyle
    {
        MSStyleCSSProperties runtimeStyle { get; }

        MSCurrentStyleCSSProperties currentStyle { get; }

        void doScroll(object component = null);

        string componentFromPoint(double x, double y);
    }

    public partial interface DOMParser
    {
        Document parseFromString(string source, string mimeType);
    }

    public partial interface MSMimeTypesCollection
    {
        double Length { get; }
    }

    public partial interface StyleSheet
    {
        bool disabled { get; }

        Node ownerNode { get; }

        StyleSheet parentStyleSheet { get; }

        string href { get; }

        MediaList media { get; }

        string type { get; }

        string title { get; }
    }

    public partial interface SVGTextPathElement : SVGTextContentElementSVGURIReference
    {
        SVGAnimatedLength startOffset { get; }

        SVGAnimatedEnumeration method { get; }

        SVGAnimatedEnumeration spacing { get; }

        double TEXTPATH_SPACINGTYPE_EXACT { get; }

        double TEXTPATH_METHODTYPE_STRETCH { get; }

        double TEXTPATH_SPACINGTYPE_AUTO { get; }

        double TEXTPATH_SPACINGTYPE_UNKNOWN { get; }

        double TEXTPATH_METHODTYPE_UNKNOWN { get; }

        double TEXTPATH_METHODTYPE_ALIGN { get; }
    }

    public partial interface HTMLDTElement : HTMLElement
    {
        bool noWrap { get; }
    }

    public partial interface NodeList
    {
        double Length { get; }

        Node item(double index);

        Node this[double index] { get; set; }
    }

    public partial interface XMLSerializer
    {
        string serializeToString(Node target);
    }

    public partial interface PerformanceMeasure : PerformanceEntry
    {
    }

    public partial interface SVGGradientElement : SVGElementSVGUnitTypesSVGStylableSVGExternalResourcesRequiredSVGURIReference
    {
        SVGAnimatedEnumeration spreadMethod { get; }

        SVGAnimatedTransformList gradientTransform { get; }

        SVGAnimatedEnumeration gradientUnits { get; }

        double SVG_SPREADMETHOD_REFLECT { get; }

        double SVG_SPREADMETHOD_PAD { get; }

        double SVG_SPREADMETHOD_UNKNOWN { get; }

        double SVG_SPREADMETHOD_REPEAT { get; }
    }

    public partial interface NodeFilter
    {
        double acceptNode(Node n);

        double SHOW_ENTITY_REFERENCE { get; }

        double SHOW_NOTATION { get; }

        double SHOW_ENTITY { get; }

        double SHOW_DOCUMENT { get; }

        double SHOW_PROCESSING_INSTRUCTION { get; }

        double FILTER_REJECT { get; }

        double SHOW_CDATA_SECTION { get; }

        double FILTER_ACCEPT { get; }

        double SHOW_ALL { get; }

        double SHOW_DOCUMENT_TYPE { get; }

        double SHOW_TEXT { get; }

        double SHOW_ELEMENT { get; }

        double SHOW_COMMENT { get; }

        double FILTER_SKIP { get; }

        double SHOW_ATTRIBUTE { get; }

        double SHOW_DOCUMENT_FRAGMENT { get; }
    }

    public partial interface MediaError
    {
        double code { get; }

        double msExtendedCode { get; }

        double MEDIA_ERR_ABORTED { get; }

        double MEDIA_ERR_NETWORK { get; }

        double MEDIA_ERR_SRC_NOT_SUPPORTED { get; }

        double MEDIA_ERR_DECODE { get; }

        double MS_MEDIA_ERR_ENCRYPTED { get; }
    }

    public partial interface HTMLFieldSetElement : HTMLElement
    {
        string align { get; }

        HTMLFormElement form { get; }

        string validationMessage { get; }

        ValidityState validity { get; }

        bool willValidate { get; }

        bool checkValidity();

        void setCustomValidity(string error);
    }

    public partial interface HTMLBGSoundElement : HTMLElement
    {
        object balance { get; }

        object volume { get; }

        string src { get; }

        double loop { get; }
    }

    public partial interface Comment : CharacterData
    {
        string text { get; }
    }

    public partial interface PerformanceResourceTiming : PerformanceEntry
    {
        double redirectStart { get; }

        double redirectEnd { get; }

        double domainLookupEnd { get; }

        double responseStart { get; }

        double domainLookupStart { get; }

        double fetchStart { get; }

        double requestStart { get; }

        double connectEnd { get; }

        double connectStart { get; }

        string initiatorType { get; }

        double responseEnd { get; }
    }

    public partial interface CanvasPattern
    {
    }

    public partial interface HTMLHRElement : HTMLElementDOML2DeprecatedColorPropertyDOML2DeprecatedSizeProperty
    {
        double width { get; }

        string align { get; }

        bool noShade { get; }
    }

    public partial interface HTMLObjectElement :
        HTMLElementGetSVGDocumentDOML2DeprecatedMarginStyleDOML2DeprecatedBorderStyleDOML2DeprecatedAlignmentStyleMSDataBindingExtensionsMSDataBindingRecordSetExtensions
    {
        string width { get; }

        string codeType { get; }

        object _object { get; }

        HTMLFormElement form { get; }

        string code { get; }

        string archive { get; }

        string standby { get; }

        string alt { get; }

        string classid { get; }

        string name { get; }

        string useMap { get; }

        string data { get; }

        string height { get; }

        Document contentDocument { get; }

        string altHtml { get; }

        string codeBase { get; }

        bool declare { get; }

        string type { get; }

        string BaseHref { get; }

        string validationMessage { get; }

        ValidityState validity { get; }

        bool willValidate { get; }

        string msPlayToPreferredSourceUri { get; }

        bool msPlayToPrimary { get; }

        bool msPlayToDisabled { get; }

        double readyState { get; }

        object msPlayToSource { get; }

        bool checkValidity();

        void setCustomValidity(string error);
    }

    public partial interface HTMLEmbedElement : HTMLElementGetSVGDocument
    {
        string width { get; }

        string palette { get; }

        string src { get; }

        string name { get; }

        string hidden { get; }

        string pluginspage { get; }

        string height { get; }

        string units { get; }

        string msPlayToPreferredSourceUri { get; }

        bool msPlayToPrimary { get; }

        bool msPlayToDisabled { get; }

        string readyState { get; }

        object msPlayToSource { get; }
    }

    public partial interface StorageEvent : Event
    {
        object oldValue { get; }

        object newValue { get; }

        string url { get; }

        Storage storageArea { get; }

        string key { get; }

        void initStorageEvent(
            string typeArg, bool canBubbleArg, bool cancelableArg, string keyArg, object oldValueArg, object newValueArg, string urlArg, Storage storageAreaArg);
    }

    public partial interface CharacterData : Node
    {
        double Length { get; }

        string data { get; }

        void deleteData(double offset, double count);

        void replaceData(double offset, double count, string arg);

        void appendData(string arg);

        void insertData(double offset, string arg);

        string substringData(double offset, double count);
    }

    public partial interface HTMLOptGroupElement : HTMLElementMSDataBindingExtensions
    {
        double index { get; }

        bool defaultSelected { get; }

        string text { get; }

        string value { get; }

        HTMLFormElement form { get; }

        string label { get; }

        bool selected { get; }
    }

    public partial interface HTMLIsIndexElement : HTMLElement
    {
        HTMLFormElement form { get; }

        string action { get; }

        string prompt { get; }
    }

    public partial interface SVGPathSegLinetoRel : SVGPathSeg
    {
        double y { get; }

        double x { get; }
    }

    public partial interface DOMException
    {
        double code { get; }

        string message { get; }

        string name { get; }

        string toString();

        double HIERARCHY_REQUEST_ERR { get; }

        double NO_MODIFICATION_ALLOWED_ERR { get; }

        double INVALID_MODIFICATION_ERR { get; }

        double NAMESPACE_ERR { get; }

        double INVALID_CHARACTER_ERR { get; }

        double TYPE_MISMATCH_ERR { get; }

        double ABORT_ERR { get; }

        double INVALID_STATE_ERR { get; }

        double SECURITY_ERR { get; }

        double NETWORK_ERR { get; }

        double WRONG_DOCUMENT_ERR { get; }

        double QUOTA_EXCEEDED_ERR { get; }

        double INDEX_SIZE_ERR { get; }

        double DOMSTRING_SIZE_ERR { get; }

        double SYNTAX_ERR { get; }

        double SERIALIZE_ERR { get; }

        double VALIDATION_ERR { get; }

        double NOT_FOUND_ERR { get; }

        double URL_MISMATCH_ERR { get; }

        double PARSE_ERR { get; }

        double NO_DATA_ALLOWED_ERR { get; }

        double NOT_SUPPORTED_ERR { get; }

        double INVALID_ACCESS_ERR { get; }

        double INUSE_ATTRIBUTE_ERR { get; }

        double INVALID_NODE_TYPE_ERR { get; }

        double DATA_CLONE_ERR { get; }

        double TIMEOUT_ERR { get; }
    }

    public partial interface SVGAnimatedBoolean
    {
        bool animVal { get; }

        bool baseVal { get; }
    }

    public partial interface MSCompatibleInfoCollection
    {
        double Length { get; }

        MSCompatibleInfo item(double index);
    }

    public partial interface SVGSwitchElement : SVGElementSVGStylableSVGTransformableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
    }

    public partial interface SVGPreserveAspectRatio
    {
        double align { get; }

        double meetOrSlice { get; }

        double SVG_PRESERVEASPECTRATIO_NONE { get; }

        double SVG_PRESERVEASPECTRATIO_XMINYMID { get; }

        double SVG_PRESERVEASPECTRATIO_XMAXYMIN { get; }

        double SVG_PRESERVEASPECTRATIO_XMINYMAX { get; }

        double SVG_PRESERVEASPECTRATIO_XMAXYMAX { get; }

        double SVG_MEETORSLICE_UNKNOWN { get; }

        double SVG_PRESERVEASPECTRATIO_XMAXYMID { get; }

        double SVG_PRESERVEASPECTRATIO_XMIDYMAX { get; }

        double SVG_PRESERVEASPECTRATIO_XMINYMIN { get; }

        double SVG_MEETORSLICE_MEET { get; }

        double SVG_PRESERVEASPECTRATIO_XMIDYMID { get; }

        double SVG_PRESERVEASPECTRATIO_XMIDYMIN { get; }

        double SVG_MEETORSLICE_SLICE { get; }

        double SVG_PRESERVEASPECTRATIO_UNKNOWN { get; }
    }

    public partial interface Attr : Node
    {
        bool expando { get; }

        bool specified { get; }

        Element ownerElement { get; }

        string value { get; }

        string name { get; }
    }

    public partial interface PerformanceNavigation
    {
        double redirectCount { get; }

        double type { get; }

        object toJSON();

        double TYPE_RELOAD { get; }

        double TYPE_RESERVED { get; }

        double TYPE_BACK_FORWARD { get; }

        double TYPE_NAVIGATE { get; }
    }

    public partial interface SVGStopElement : SVGElementSVGStylable
    {
        SVGAnimatedNumber offset { get; }
    }

    public delegate void PositionCallback(Position position);

    public partial interface SVGSymbolElement : SVGElementSVGStylableSVGLangSpaceSVGFitToViewBoxSVGExternalResourcesRequired
    {
    }

    public partial interface SVGElementInstanceList
    {
        double Length { get; }

        SVGElementInstance item(double index);
    }

    public partial interface CSSRuleList
    {
        double Length { get; }

        CSSRule item(double index);

        CSSRule this[double index] { get; set; }
    }

    public partial interface MSDataBindingRecordSetExtensions
    {
        object recordset { get; }

        object namedRecordset(string dataMember, object hierarchy = null);
    }

    public partial interface LinkStyle
    {
        StyleSheet styleSheet { get; }

        StyleSheet sheet { get; }
    }

    public partial interface HTMLVideoElement : HTMLMediaElement
    {
        double width { get; }

        double videoWidth { get; }

        double videoHeight { get; }

        double height { get; }

        string poster { get; }

        bool msIsStereo3D { get; }

        string msStereo3DPackingMode { get; }

        System.Func<object, object> onMSVideoOptimalLayoutChanged { get; }

        System.Func<object, object> onMSVideoFrameStepCompleted { get; }

        string msStereo3DRenderMode { get; }

        bool msIsLayoutOptimalForPlayback { get; }

        bool msHorizontalMirror { get; }

        System.Func<object, object> onMSVideoFormatChanged { get; }

        bool msZoom { get; }

        void msInsertVideoEffect(string activatableClassId, bool effectRequired, object config = null);

        void msSetVideoRectangle(double left, double top, double right, double bottom);

        void msFrameStep(bool forward);

        VideoPlaybackQuality getVideoPlaybackQuality();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface ClientRectList
    {
        double Length { get; }

        ClientRect item(double index);

        ClientRect this[double index] { get; set; }
    }

    public partial interface SVGMaskElement : SVGElementSVGUnitTypesSVGStylableSVGLangSpaceSVGTestsSVGExternalResourcesRequired
    {
        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGAnimatedEnumeration maskUnits { get; }

        SVGAnimatedEnumeration maskContentUnits { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedLength height { get; }
    }

    public partial interface External
    {
    }

    public partial interface MSGestureEvent : UIEvent
    {
        double offsetY { get; }

        double translationY { get; }

        double velocityExpansion { get; }

        double velocityY { get; }

        double velocityAngular { get; }

        double translationX { get; }

        double velocityX { get; }

        double hwTimestamp { get; }

        double offsetX { get; }

        double screenX { get; }

        double rotation { get; }

        double expansion { get; }

        double clientY { get; }

        double screenY { get; }

        double scale { get; }

        object gestureObject { get; }

        double clientX { get; }

        void initGestureEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            double offsetXArg,
            double offsetYArg,
            double translationXArg,
            double translationYArg,
            double scaleArg,
            double expansionArg,
            double rotationArg,
            double velocityXArg,
            double velocityYArg,
            double velocityExpansionArg,
            double velocityAngularArg,
            double hwTimestampArg);

        double MSGESTURE_FLAG_BEGIN { get; }

        double MSGESTURE_FLAG_END { get; }

        double MSGESTURE_FLAG_CANCEL { get; }

        double MSGESTURE_FLAG_INERTIA { get; }

        double MSGESTURE_FLAG_NONE { get; }
    }

    public partial interface ErrorEvent : Event
    {
        double colno { get; }

        string filename { get; }

        object error { get; }

        double lineno { get; }

        string message { get; }

        void initErrorEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string messageArg, string filenameArg, double linenoArg);
    }

    public partial interface SVGFilterElement : SVGElementSVGUnitTypesSVGStylableSVGLangSpaceSVGURIReferenceSVGExternalResourcesRequired
    {
        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGAnimatedInteger filterResX { get; }

        SVGAnimatedEnumeration filterUnits { get; }

        SVGAnimatedEnumeration primitiveUnits { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedLength height { get; }

        SVGAnimatedInteger filterResY { get; }

        void setFilterRes(double filterResX, double filterResY);
    }

    public partial interface TrackEvent : Event
    {
        object track { get; }
    }

    public partial interface SVGFEMergeNodeElement : SVGElement
    {
        SVGAnimatedString in1 { get; }
    }

    public partial interface SVGFEFloodElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
    }

    public partial interface MSGesture
    {
        Element target { get; }

        void addPointer(double pointerId);

        void stop();
    }

    public partial interface TextTrackCue : EventTarget
    {
        System.Func<Event, object> onenter { get; }

        TextTrack track { get; }

        double endTime { get; }

        string text { get; }

        bool pauseOnExit { get; }

        string id { get; }

        double startTime { get; }

        System.Func<Event, object> onexit { get; }

        DocumentFragment getCueAsHTML();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface MSStreamReader : MSBaseReader
    {
        DOMError error { get; }

        void readAsArrayBuffer(MSStream stream, double size = 0.0);

        void readAsBlob(MSStream stream, double size = 0.0);

        void readAsDataURL(MSStream stream, double size = 0.0);

        void readAsText(MSStream stream, string encoding = null, double size = 0.0);
    }

    public partial interface DOMTokenList
    {
        double Length { get; }

        bool contains(string token);

        void remove(string token);

        bool toggle(string token);

        void add(string token);

        string item(double index);

        string this[double index] { get; set; }

        string toString();
    }

    public partial interface SVGFEFuncAElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface SVGFETileElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1 { get; }
    }

    public partial interface SVGFEBlendElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in2 { get; }

        SVGAnimatedEnumeration mode { get; }

        SVGAnimatedString in1 { get; }

        double SVG_FEBLEND_MODE_DARKEN { get; }

        double SVG_FEBLEND_MODE_UNKNOWN { get; }

        double SVG_FEBLEND_MODE_MULTIPLY { get; }

        double SVG_FEBLEND_MODE_NORMAL { get; }

        double SVG_FEBLEND_MODE_SCREEN { get; }

        double SVG_FEBLEND_MODE_LIGHTEN { get; }
    }

    public partial interface MessageChannel
    {
        MessagePort port2 { get; }

        MessagePort port1 { get; }
    }

    public partial interface SVGFEMergeElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
    }

    public partial interface TransitionEvent : Event
    {
        string propertyName { get; }

        double elapsedTime { get; }

        void initTransitionEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string propertyNameArg, double elapsedTimeArg);
    }

    public partial interface MediaQueryList
    {
        bool matches { get; }

        string media { get; }

        void addListener(MediaQueryListListener listener);

        void removeListener(MediaQueryListListener listener);
    }

    public partial interface DOMError
    {
        string name { get; }

        string toString();
    }

    public partial interface CloseEvent : Event
    {
        bool wasClean { get; }

        string reason { get; }

        double code { get; }

        void initCloseEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool wasCleanArg, double codeArg, string reasonArg);
    }

    public partial interface WebSocket : EventTarget
    {
        string protocol { get; }

        double readyState { get; }

        double bufferedAmount { get; }

        System.Func<Event, object> onopen { get; }

        string extensions { get; }

        System.Func<MessageEvent, object> onmessage { get; }

        System.Func<CloseEvent, object> onclose { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        string binaryType { get; }

        string url { get; }

        void close(double code = 0.0, string reason = null);

        void send(object data);

        double OPEN { get; }

        double CLOSING { get; }

        double CONNECTING { get; }

        double CLOSED { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGFEPointLightElement : SVGElement
    {
        SVGAnimatedNumber y { get; }

        SVGAnimatedNumber x { get; }

        SVGAnimatedNumber z { get; }
    }

    public partial interface ProgressEvent : Event
    {
        double loaded { get; }

        bool lengthComputable { get; }

        double total { get; }

        void initProgressEvent(string typeArg, bool canBubbleArg, bool cancelableArg, bool lengthComputableArg, double loadedArg, double totalArg);
    }

    public partial interface IDBObjectStore
    {
        DOMStringList indexNames { get; }

        string name { get; }

        IDBTransaction transaction { get; }

        string keyPath { get; }

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

    public partial interface SVGFEGaussianBlurElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber stdDeviationX { get; }

        SVGAnimatedString in1 { get; }

        SVGAnimatedNumber stdDeviationY { get; }

        void setStdDeviation(double stdDeviationX, double stdDeviationY);
    }

    public partial interface SVGFilterPrimitiveStandardAttributes : SVGStylable
    {
        SVGAnimatedLength y { get; }

        SVGAnimatedLength width { get; }

        SVGAnimatedLength x { get; }

        SVGAnimatedLength height { get; }

        SVGAnimatedString result { get; }
    }

    public partial interface IDBVersionChangeEvent : Event
    {
        double newVersion { get; }

        double oldVersion { get; }
    }

    public partial interface IDBIndex
    {
        bool unique { get; }

        string name { get; }

        string keyPath { get; }

        IDBObjectStore objectStore { get; }

        IDBRequest count(object key = null);

        IDBRequest getKey(object key);

        IDBRequest openKeyCursor(IDBKeyRange range = null, string direction = null);

        IDBRequest get(object key);

        IDBRequest openCursor(IDBKeyRange range = null, string direction = null);
    }

    public partial interface FileList
    {
        double Length { get; }

        File item(double index);

        File this[double index] { get; set; }
    }

    public partial interface IDBCursor
    {
        object source { get; }

        string direction { get; }

        object key { get; }

        object primaryKey { get; }

        void advance(double count);

        IDBRequest delete();

        void _continue(object key = null);

        IDBRequest update(object value);

        string PREV { get; }

        string PREV_NO_DUPLICATE { get; }

        string NEXT { get; }

        string NEXT_NO_DUPLICATE { get; }
    }

    public partial interface SVGFESpecularLightingElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber kernelUnitLengthY { get; }

        SVGAnimatedNumber surfaceScale { get; }

        SVGAnimatedNumber specularExponent { get; }

        SVGAnimatedString in1 { get; }

        SVGAnimatedNumber kernelUnitLengthX { get; }

        SVGAnimatedNumber specularConstant { get; }
    }

    public partial interface File : Blob
    {
        object lastModifiedDate { get; }

        string name { get; }
    }

    public partial interface URL
    {
        void revokeObjectURL(string url);

        string createObjectURL(object _object, ObjectURLOptions options = null);
    }

    public partial interface XMLHttpRequestEventTarget : EventTarget
    {
        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onload { get; }

        System.Func<Event, object> ontimeout { get; }

        System.Func<UIEvent, object> onabort { get; }

        System.Func<Event, object> onloadstart { get; }

        System.Func<ProgressEvent, object> onloadend { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface IDBEnvironment
    {
        IDBFactory msIndexedDB { get; }

        IDBFactory indexedDB { get; }
    }

    public partial interface AudioTrackList : EventTarget
    {
        double Length { get; }

        System.Func<Event, object> onchange { get; }

        System.Func<TrackEvent, object> onaddtrack { get; }

        System.Func<object, object> onremovetrack { get; }

        AudioTrack getTrackById(string id);

        AudioTrack item(double index);

        AudioTrack this[double index] { get; set; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface MSBaseReader : EventTarget
    {
        System.Func<ProgressEvent, object> onprogress { get; }

        double readyState { get; }

        System.Func<UIEvent, object> onabort { get; }

        System.Func<ProgressEvent, object> onloadend { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onload { get; }

        System.Func<Event, object> onloadstart { get; }

        object result { get; }

        void abort();

        double LOADING { get; }

        double EMPTY { get; }

        double DONE { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGFEMorphologyElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedEnumeration _operator { get; }

        SVGAnimatedNumber radiusX { get; }

        SVGAnimatedNumber radiusY { get; }

        SVGAnimatedString in1 { get; }

        double SVG_MORPHOLOGY_OPERATOR_UNKNOWN { get; }

        double SVG_MORPHOLOGY_OPERATOR_ERODE { get; }

        double SVG_MORPHOLOGY_OPERATOR_DILATE { get; }
    }

    public partial interface SVGFEFuncRElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface WindowTimersExtension
    {
        double msSetImmediate(object expression, params object[] args);

        void clearImmediate(double handle);

        void msClearImmediate(double handle);

        double setImmediate(object expression, params object[] args);
    }

    public partial interface SVGFEDisplacementMapElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in2 { get; }

        SVGAnimatedEnumeration xChannelSelector { get; }

        SVGAnimatedEnumeration yChannelSelector { get; }

        SVGAnimatedNumber scale { get; }

        SVGAnimatedString in1 { get; }

        double SVG_CHANNEL_B { get; }

        double SVG_CHANNEL_R { get; }

        double SVG_CHANNEL_G { get; }

        double SVG_CHANNEL_UNKNOWN { get; }

        double SVG_CHANNEL_A { get; }
    }

    public partial interface AnimationEvent : Event
    {
        string animationName { get; }

        double elapsedTime { get; }

        void initAnimationEvent(string typeArg, bool canBubbleArg, bool cancelableArg, string animationNameArg, double elapsedTimeArg);
    }

    public partial interface SVGComponentTransferFunctionElement : SVGElement
    {
        SVGAnimatedNumberList tableValues { get; }

        SVGAnimatedNumber slope { get; }

        SVGAnimatedEnumeration type { get; }

        SVGAnimatedNumber exponent { get; }

        SVGAnimatedNumber amplitude { get; }

        SVGAnimatedNumber intercept { get; }

        SVGAnimatedNumber offset { get; }

        double SVG_FECOMPONENTTRANSFER_TYPE_UNKNOWN { get; }

        double SVG_FECOMPONENTTRANSFER_TYPE_TABLE { get; }

        double SVG_FECOMPONENTTRANSFER_TYPE_IDENTITY { get; }

        double SVG_FECOMPONENTTRANSFER_TYPE_GAMMA { get; }

        double SVG_FECOMPONENTTRANSFER_TYPE_DISCRETE { get; }

        double SVG_FECOMPONENTTRANSFER_TYPE_LINEAR { get; }
    }

    public partial interface MSRangeCollection
    {
        double Length { get; }

        Range item(double index);

        Range this[double index] { get; set; }
    }

    public partial interface SVGFEDistantLightElement : SVGElement
    {
        SVGAnimatedNumber azimuth { get; }

        SVGAnimatedNumber elevation { get; }
    }

    public partial interface SVGFEFuncBElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface IDBKeyRange
    {
        object upper { get; }

        bool upperOpen { get; }

        object lower { get; }

        bool lowerOpen { get; }
    }

    public partial interface WindowConsole
    {
        Console console { get; }
    }

    public partial interface IDBTransaction : EventTarget
    {
        System.Func<Event, object> oncomplete { get; }

        IDBDatabase db { get; }

        string mode { get; }

        DOMError error { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<UIEvent, object> onabort { get; }

        void abort();

        IDBObjectStore objectStore(string name);

        string READ_ONLY { get; }

        string VERSION_CHANGE { get; }

        string READ_WRITE { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface AudioTrack
    {
        string kind { get; }

        string language { get; }

        string id { get; }

        string label { get; }

        bool enabled { get; }

        SourceBuffer sourceBuffer { get; }
    }

    public partial interface SVGFEConvolveMatrixElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedInteger orderY { get; }

        SVGAnimatedNumber kernelUnitLengthY { get; }

        SVGAnimatedInteger orderX { get; }

        SVGAnimatedBoolean preserveAlpha { get; }

        SVGAnimatedNumberList kernelMatrix { get; }

        SVGAnimatedEnumeration edgeMode { get; }

        SVGAnimatedNumber kernelUnitLengthX { get; }

        SVGAnimatedNumber bias { get; }

        SVGAnimatedInteger targetX { get; }

        SVGAnimatedInteger targetY { get; }

        SVGAnimatedNumber divisor { get; }

        SVGAnimatedString in1 { get; }

        double SVG_EDGEMODE_WRAP { get; }

        double SVG_EDGEMODE_DUPLICATE { get; }

        double SVG_EDGEMODE_UNKNOWN { get; }

        double SVG_EDGEMODE_NONE { get; }
    }

    public partial interface TextTrackCueList
    {
        double Length { get; }

        TextTrackCue item(double index);

        TextTrackCue this[double index] { get; set; }

        TextTrackCue getCueById(string id);
    }

    public partial interface CSSKeyframesRule : CSSRule
    {
        string name { get; }

        CSSRuleList cssRules { get; }

        CSSKeyframeRule findRule(string rule);

        void deleteRule(string rule);

        void appendRule(string rule);
    }

    public partial interface SVGFETurbulenceElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber baseFrequencyX { get; }

        SVGAnimatedInteger numOctaves { get; }

        SVGAnimatedEnumeration type { get; }

        SVGAnimatedNumber baseFrequencyY { get; }

        SVGAnimatedEnumeration stitchTiles { get; }

        SVGAnimatedNumber seed { get; }

        double SVG_STITCHTYPE_UNKNOWN { get; }

        double SVG_STITCHTYPE_NOSTITCH { get; }

        double SVG_TURBULENCE_TYPE_UNKNOWN { get; }

        double SVG_TURBULENCE_TYPE_TURBULENCE { get; }

        double SVG_TURBULENCE_TYPE_FRACTALNOISE { get; }

        double SVG_STITCHTYPE_STITCH { get; }
    }

    public partial interface TextTrackList : EventTarget
    {
        double Length { get; }

        System.Func<TrackEvent, object> onaddtrack { get; }

        TextTrack item(double index);

        TextTrack this[double index] { get; set; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGFEFuncGElement : SVGComponentTransferFunctionElement
    {
    }

    public partial interface SVGFEColorMatrixElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedString in1 { get; }

        SVGAnimatedEnumeration type { get; }

        SVGAnimatedNumberList values { get; }

        double SVG_FECOLORMATRIX_TYPE_SATURATE { get; }

        double SVG_FECOLORMATRIX_TYPE_UNKNOWN { get; }

        double SVG_FECOLORMATRIX_TYPE_MATRIX { get; }

        double SVG_FECOLORMATRIX_TYPE_HUEROTATE { get; }

        double SVG_FECOLORMATRIX_TYPE_LUMINANCETOALPHA { get; }
    }

    public partial interface SVGFESpotLightElement : SVGElement
    {
        SVGAnimatedNumber pointsAtY { get; }

        SVGAnimatedNumber y { get; }

        SVGAnimatedNumber limitingConeAngle { get; }

        SVGAnimatedNumber specularExponent { get; }

        SVGAnimatedNumber x { get; }

        SVGAnimatedNumber pointsAtZ { get; }

        SVGAnimatedNumber z { get; }

        SVGAnimatedNumber pointsAtX { get; }
    }

    public partial interface WindowBase64
    {
        string btoa(string rawString);

        string atob(string encodedString);
    }

    public partial interface IDBDatabase : EventTarget
    {
        string version { get; }

        string name { get; }

        DOMStringList objectStoreNames { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<UIEvent, object> onabort { get; }

        IDBObjectStore createObjectStore(string name, object optionalParameters = null);

        void close();

        IDBTransaction transaction(object storeNames, string mode = null);

        void deleteObjectStore(string name);

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface DOMStringList
    {
        double Length { get; }

        bool contains(string str);

        string item(double index);

        string this[double index] { get; set; }
    }

    public partial interface IDBOpenDBRequest : IDBRequest
    {
        System.Func<IDBVersionChangeEvent, object> onupgradeneeded { get; }

        System.Func<Event, object> onblocked { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface HTMLProgressElement : HTMLElement
    {
        double value { get; }

        double Max { get; }

        double position { get; }

        HTMLFormElement form { get; }
    }

    public delegate void MSLaunchUriCallback();

    public partial interface SVGFEOffsetElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber dy { get; }

        SVGAnimatedString in1 { get; }

        SVGAnimatedNumber dx { get; }
    }

    public delegate object MSUnsafeFunctionCallback();

    public partial interface TextTrack : EventTarget
    {
        string language { get; }

        object mode { get; }

        double readyState { get; }

        TextTrackCueList activeCues { get; }

        TextTrackCueList cues { get; }

        System.Func<Event, object> oncuechange { get; }

        string kind { get; }

        System.Func<Event, object> onload { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        string label { get; }

        void addCue(TextTrackCue cue);

        void removeCue(TextTrackCue cue);

        double ERROR { get; }

        double SHOWING { get; }

        double LOADING { get; }

        double LOADED { get; }

        double NONE { get; }

        double HIDDEN { get; }

        double DISABLED { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public delegate void MediaQueryListListener(MediaQueryList mql);

    public partial interface IDBRequest : EventTarget
    {
        object source { get; }

        System.Func<Event, object> onsuccess { get; }

        DOMError error { get; }

        IDBTransaction transaction { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        string readyState { get; }

        object result { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface MessagePort : EventTarget
    {
        System.Func<MessageEvent, object> onmessage { get; }

        void close();

        void postMessage(object message = null, object ports = null);

        void start();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface FileReader : MSBaseReader
    {
        DOMError error { get; }

        void readAsArrayBuffer(Blob blob);

        void readAsDataURL(Blob blob);

        void readAsText(Blob blob, string encoding = null);
    }

    public partial interface Blob
    {
        string type { get; }

        double size { get; }

        object msDetachStream();

        Blob slice(double start = 0.0, double end = 0.0, string contentType = null);

        void msClose();
    }

    public partial interface ApplicationCache : EventTarget
    {
        double status { get; }

        System.Func<Event, object> ondownloading { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<Event, object> onupdateready { get; }

        System.Func<Event, object> oncached { get; }

        System.Func<Event, object> onobsolete { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<Event, object> onchecking { get; }

        System.Func<Event, object> onnoupdate { get; }

        void swapCache();

        void abort();

        void update();

        double CHECKING { get; }

        double UNCACHED { get; }

        double UPDATEREADY { get; }

        double DOWNLOADING { get; }

        double IDLE { get; }

        double OBSOLETE { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public delegate void FrameRequestCallback(double time);

    public partial interface PopStateEvent : Event
    {
        object state { get; }

        void initPopStateEvent(string typeArg, bool canBubbleArg, bool cancelableArg, object stateArg);
    }

    public partial interface CSSKeyframeRule : CSSRule
    {
        string keyText { get; }

        CSSStyleDeclaration style { get; }
    }

    public partial interface MSFileSaver
    {
        bool msSaveBlob(object blob, string defaultName = null);

        bool msSaveOrOpenBlob(object blob, string defaultName = null);
    }

    public partial interface MSStream
    {
        string type { get; }

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
        string value { get; }
    }

    public partial interface IDBFactory
    {
        IDBOpenDBRequest open(string name, double version = 0.0);

        double cmp(object first, object second);

        IDBOpenDBRequest deleteDatabase(string name);
    }

    public partial interface MSPointerEvent : MouseEvent
    {
        double width { get; }

        double rotation { get; }

        double pressure { get; }

        object pointerType { get; }

        bool isPrimary { get; }

        double tiltY { get; }

        double height { get; }

        object intermediatePoints { get; }

        object currentPoint { get; }

        double tiltX { get; }

        double hwTimestamp { get; }

        double pointerId { get; }

        void initPointerEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            double buttonArg,
            EventTarget relatedTargetArg,
            double offsetXArg,
            double offsetYArg,
            double widthArg,
            double heightArg,
            double pressure,
            double rotation,
            double tiltX,
            double tiltY,
            double pointerIdArg,
            object pointerType,
            double hwTimestampArg,
            bool isPrimary);

        void getCurrentPoint(Element element);

        void getIntermediatePoints(Element element);

        double MSPOINTER_TYPE_PEN { get; }

        double MSPOINTER_TYPE_MOUSE { get; }

        double MSPOINTER_TYPE_TOUCH { get; }
    }

    public partial interface MSManipulationEvent : UIEvent
    {
        double lastState { get; }

        double currentState { get; }

        void initMSManipulationEvent(
            string typeArg, bool canBubbleArg, bool cancelableArg, Window viewArg, double detailArg, double lastState, double currentState);

        double MS_MANIPULATION_STATE_STOPPED { get; }

        double MS_MANIPULATION_STATE_ACTIVE { get; }

        double MS_MANIPULATION_STATE_INERTIA { get; }

        double MS_MANIPULATION_STATE_SELECTING { get; }

        double MS_MANIPULATION_STATE_COMMITTED { get; }

        double MS_MANIPULATION_STATE_PRESELECT { get; }

        double MS_MANIPULATION_STATE_DRAGGING { get; }

        double MS_MANIPULATION_STATE_CANCELLED { get; }
    }

    public partial interface FormData
    {
        void append(object name, object value, string blobName = null);
    }

    public partial interface HTMLDataListElement : HTMLElement
    {
        HTMLCollection options { get; }
    }

    public partial interface SVGFEImageElement : SVGElementSVGLangSpaceSVGFilterPrimitiveStandardAttributesSVGURIReferenceSVGExternalResourcesRequired
    {
        SVGAnimatedPreserveAspectRatio preserveAspectRatio { get; }
    }

    public partial interface AbstractWorker : EventTarget
    {
        System.Func<ErrorEvent, object> onerror { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface SVGFECompositeElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedEnumeration _operator { get; }

        SVGAnimatedString in2 { get; }

        SVGAnimatedNumber k2 { get; }

        SVGAnimatedNumber k1 { get; }

        SVGAnimatedNumber k3 { get; }

        SVGAnimatedString in1 { get; }

        SVGAnimatedNumber k4 { get; }

        double SVG_FECOMPOSITE_OPERATOR_OUT { get; }

        double SVG_FECOMPOSITE_OPERATOR_OVER { get; }

        double SVG_FECOMPOSITE_OPERATOR_XOR { get; }

        double SVG_FECOMPOSITE_OPERATOR_ARITHMETIC { get; }

        double SVG_FECOMPOSITE_OPERATOR_UNKNOWN { get; }

        double SVG_FECOMPOSITE_OPERATOR_IN { get; }

        double SVG_FECOMPOSITE_OPERATOR_ATOP { get; }
    }

    public partial interface ValidityState
    {
        bool customError { get; }

        bool valueMissing { get; }

        bool stepMismatch { get; }

        bool rangeUnderflow { get; }

        bool rangeOverflow { get; }

        bool typeMismatch { get; }

        bool patternMismatch { get; }

        bool tooLong { get; }

        bool valid { get; }
    }

    public partial interface HTMLTrackElement : HTMLElement
    {
        string kind { get; }

        string src { get; }

        string srclang { get; }

        TextTrack track { get; }

        string label { get; }

        bool _default { get; }

        double readyState { get; }

        double ERROR { get; }

        double LOADING { get; }

        double LOADED { get; }

        double NONE { get; }
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

        string NORMAL { get; }

        string HIGH { get; }

        string IDLE { get; }

        string CURRENT { get; }
    }

    public partial interface SVGFEDiffuseLightingElement : SVGElementSVGFilterPrimitiveStandardAttributes
    {
        SVGAnimatedNumber kernelUnitLengthY { get; }

        SVGAnimatedNumber surfaceScale { get; }

        SVGAnimatedString in1 { get; }

        SVGAnimatedNumber kernelUnitLengthX { get; }

        SVGAnimatedNumber diffuseConstant { get; }
    }

    public partial interface MSCSSMatrix
    {
        double m24 { get; }

        double m34 { get; }

        double a { get; }

        double d { get; }

        double m32 { get; }

        double m41 { get; }

        double m11 { get; }

        double f { get; }

        double e { get; }

        double m23 { get; }

        double m14 { get; }

        double m33 { get; }

        double m22 { get; }

        double m21 { get; }

        double c { get; }

        double m12 { get; }

        double b { get; }

        double m42 { get; }

        double m31 { get; }

        double m43 { get; }

        double m13 { get; }

        double m44 { get; }

        MSCSSMatrix multiply(MSCSSMatrix secondMatrix);

        MSCSSMatrix skewY(double angle);

        void setMatrixValue(string value);

        MSCSSMatrix inverse();

        MSCSSMatrix rotateAxisAngle(double x, double y, double z, double angle);

        string toString();

        MSCSSMatrix rotate(double angleX, double angleY = 0.0, double angleZ = 0.0);

        MSCSSMatrix translate(double x, double y, double z = 0.0);

        MSCSSMatrix scale(double scaleX, double scaleY = 0.0, double scaleZ = 0.0);

        MSCSSMatrix skewX(double angle);
    }

    public partial interface Worker : AbstractWorker
    {
        System.Func<MessageEvent, object> onmessage { get; }

        void postMessage(object message, object ports = null);

        void terminate();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public delegate object MSExecAtPriorityFunctionCallback(params object[] args);

    public partial interface MSGraphicsTrust
    {
        string status { get; }

        bool constrictionActive { get; }
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
        SubtleCrypto subtle { get; }
    }

    public partial interface VideoPlaybackQuality
    {
        double totalFrameDelay { get; }

        double creationTime { get; }

        double totalVideoFrames { get; }

        double droppedVideoFrames { get; }
    }

    public partial interface GlobalEventHandlers
    {
        System.Func<PointerEvent, object> onpointerenter { get; }

        System.Func<PointerEvent, object> onpointerout { get; }

        System.Func<PointerEvent, object> onpointerdown { get; }

        System.Func<PointerEvent, object> onpointerup { get; }

        System.Func<PointerEvent, object> onpointercancel { get; }

        System.Func<PointerEvent, object> onpointerover { get; }

        System.Func<PointerEvent, object> onpointermove { get; }

        System.Func<PointerEvent, object> onpointerleave { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface Key
    {
        Algorithm algorithm { get; }

        string type { get; }

        bool extractable { get; }

        Array<string> keyUsage { get; }
    }

    public partial interface DeviceAcceleration
    {
        double y { get; }

        double x { get; }

        double z { get; }
    }

    public partial interface HTMLAllCollection : HTMLCollection
    {
        Element namedItem(string name);
    }

    public partial interface AesGcmEncryptResult
    {
        ArrayBuffer ciphertext { get; }

        ArrayBuffer tag { get; }
    }

    public partial interface NavigationCompletedEvent : NavigationEvent
    {
        double webErrorStatus { get; }

        bool isSuccess { get; }
    }

    public partial interface MutationRecord
    {
        string oldValue { get; }

        Node previousSibling { get; }

        NodeList addedNodes { get; }

        string attributeName { get; }

        NodeList removedNodes { get; }

        Node target { get; }

        Node nextSibling { get; }

        string attributeNamespace { get; }

        string type { get; }
    }

    public partial interface MimeTypeArray
    {
        double Length { get; }

        Plugin item(double index);

        Plugin this[double index] { get; set; }

        Plugin namedItem(string type);
    }

    public partial interface KeyOperation : EventTarget
    {
        System.Func<Event, object> oncomplete { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        object result { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface DOMStringMap
    {
    }

    public partial interface DeviceOrientationEvent : Event
    {
        double gamma { get; }

        double alpha { get; }

        bool absolute { get; }

        double beta { get; }

        void initDeviceOrientationEvent(string type, bool bubbles, bool cancelable, double alpha, double beta, double gamma, bool absolute);
    }

    public partial interface MSMediaKeys
    {
        string keySystem { get; }

        MSMediaKeySession createSession(string type, Uint8Array initData, Uint8Array cdmData = null);
    }

    public partial interface MSMediaKeyMessageEvent : Event
    {
        string destinationURL { get; }

        Uint8Array message { get; }
    }

    public partial interface MSHTMLWebViewElement : HTMLElement
    {
        string documentTitle { get; }

        double width { get; }

        string src { get; }

        bool canGoForward { get; }

        double height { get; }

        bool canGoBack { get; }

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
        string uri { get; }
    }

    public partial interface RandomSource
    {
        ArrayBufferView getRandomValues(ArrayBufferView array);
    }

    public partial interface SourceBuffer : EventTarget
    {
        bool updating { get; }

        double appendWindowStart { get; }

        double appendWindowEnd { get; }

        TimeRanges buffered { get; }

        double timestampOffset { get; }

        AudioTrackList audioTracks { get; }

        void appendBuffer(ArrayBuffer data);

        void remove(double start, double end);

        void abort();

        void appendStream(MSStream stream, double maxSize = 0.0);
    }

    public partial interface MSInputMethodContext : EventTarget
    {
        System.Func<object, object> oncandidatewindowshow { get; }

        HTMLElement target { get; }

        double compositionStartOffset { get; }

        System.Func<object, object> oncandidatewindowhide { get; }

        System.Func<object, object> oncandidatewindowupdate { get; }

        double compositionEndOffset { get; }

        Array<string> getCompositionAlternatives();

        ClientRect getCandidateWindowClientRect();

        bool hasComposition();

        bool isCandidateWindowVisible();

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface DeviceRotationRate
    {
        double gamma { get; }

        double alpha { get; }

        double beta { get; }
    }

    public partial interface PluginArray
    {
        double Length { get; }

        void refresh(bool reload = false);

        Plugin item(double index);

        Plugin this[double index] { get; set; }

        Plugin namedItem(string name);
    }

    public partial interface MSMediaKeyError
    {
        double systemCode { get; }

        double code { get; }

        double MS_MEDIA_KEYERR_SERVICE { get; }

        double MS_MEDIA_KEYERR_HARDWARECHANGE { get; }

        double MS_MEDIA_KEYERR_OUTPUT { get; }

        double MS_MEDIA_KEYERR_DOMAIN { get; }

        double MS_MEDIA_KEYERR_UNKNOWN { get; }

        double MS_MEDIA_KEYERR_CLIENT { get; }
    }

    public partial interface Plugin
    {
        double Length { get; }

        string filename { get; }

        string version { get; }

        string name { get; }

        string description { get; }

        MimeType item(double index);

        MimeType this[double index] { get; set; }

        MimeType namedItem(string type);
    }

    public partial interface MediaSource : EventTarget
    {
        SourceBufferList sourceBuffers { get; }

        double duration { get; }

        string readyState { get; }

        SourceBufferList activeSourceBuffers { get; }

        SourceBuffer addSourceBuffer(string type);

        void endOfStream(string error = null);

        void removeSourceBuffer(SourceBuffer sourceBuffer);
    }

    public partial interface SourceBufferList : EventTarget
    {
        double Length { get; }

        SourceBuffer item(double index);

        SourceBuffer this[double index] { get; set; }
    }

    public partial interface XMLDocument : Document
    {
    }

    public partial interface DeviceMotionEvent : Event
    {
        DeviceRotationRate rotationRate { get; }

        DeviceAcceleration acceleration { get; }

        double interval { get; }

        DeviceAcceleration accelerationIncludingGravity { get; }

        void initDeviceMotionEvent(
            string type,
            bool bubbles,
            bool cancelable,
            DeviceAccelerationDict acceleration,
            DeviceAccelerationDict accelerationIncludingGravity,
            DeviceRotationRateDict rotationRate,
            double interval);
    }

    public partial interface MimeType
    {
        Plugin enabledPlugin { get; }

        string suffixes { get; }

        string type { get; }

        string description { get; }
    }

    public partial interface PointerEvent : MouseEvent
    {
        double width { get; }

        double rotation { get; }

        double pressure { get; }

        object pointerType { get; }

        bool isPrimary { get; }

        double tiltY { get; }

        double height { get; }

        object intermediatePoints { get; }

        object currentPoint { get; }

        double tiltX { get; }

        double hwTimestamp { get; }

        double pointerId { get; }

        void initPointerEvent(
            string typeArg,
            bool canBubbleArg,
            bool cancelableArg,
            Window viewArg,
            double detailArg,
            double screenXArg,
            double screenYArg,
            double clientXArg,
            double clientYArg,
            bool ctrlKeyArg,
            bool altKeyArg,
            bool shiftKeyArg,
            bool metaKeyArg,
            double buttonArg,
            EventTarget relatedTargetArg,
            double offsetXArg,
            double offsetYArg,
            double widthArg,
            double heightArg,
            double pressure,
            double rotation,
            double tiltX,
            double tiltY,
            double pointerIdArg,
            object pointerType,
            double hwTimestampArg,
            bool isPrimary);

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
        MSHTMLWebViewElement target { get; }

        System.Func<Event, object> oncomplete { get; }

        DOMError error { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        double readyState { get; }

        double type { get; }

        object result { get; }

        void start();

        double ERROR { get; }

        double TYPE_CREATE_DATA_PACKAGE_FROM_SELECTION { get; }

        double TYPE_INVOKE_SCRIPT { get; }

        double COMPLETED { get; }

        double TYPE_CAPTURE_PREVIEW_TO_RANDOM_ACCESS_STREAM { get; }

        double STARTED { get; }

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface ScriptNotifyEvent : Event
    {
        string value { get; }

        string callingUri { get; }
    }

    public partial interface PerformanceNavigationTiming : PerformanceEntry
    {
        double redirectStart { get; }

        double domainLookupEnd { get; }

        double responseStart { get; }

        double domComplete { get; }

        double domainLookupStart { get; }

        double loadEventStart { get; }

        double unloadEventEnd { get; }

        double fetchStart { get; }

        double requestStart { get; }

        double domInteractive { get; }

        double navigationStart { get; }

        double connectEnd { get; }

        double loadEventEnd { get; }

        double connectStart { get; }

        double responseEnd { get; }

        double domLoading { get; }

        double redirectEnd { get; }

        double redirectCount { get; }

        double unloadEventStart { get; }

        double domContentLoadedEventStart { get; }

        double domContentLoadedEventEnd { get; }

        string type { get; }
    }

    public partial interface MSMediaKeyNeededEvent : Event
    {
        Uint8Array initData { get; }
    }

    public partial interface LongRunningScriptDetectedEvent : Event
    {
        bool stopPageScriptExecution { get; }

        double executionTime { get; }
    }

    public partial interface MSAppView
    {
        double viewId { get; }

        void close();

        void postMessage(object message, string targetOrigin, object ports = null);
    }

    public partial interface PerfWidgetExternal
    {
        double maxCpuSpeed { get; }

        bool independentRenderingEnabled { get; }

        string irDisablingContentString { get; }

        bool irStatusAvailable { get; }

        double performanceCounter { get; }

        double averagePaintTime { get; }

        double activeNetworkRequestCount { get; }

        double paintRequestsPerSecond { get; }

        bool extraInformationEnabled { get; }

        double performanceCounterFrequency { get; }

        double averageFrameTime { get; }

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
        bool persisted { get; }
    }

    public delegate void MutationCallback(Array<MutationRecord> mutations, MutationObserver observer);

    public partial interface HTMLDocument : Document
    {
    }

    public partial interface KeyPair
    {
        Key privateKey { get; }

        Key publicKey { get; }
    }

    public partial interface MSMediaKeySession : EventTarget
    {
        string sessionId { get; }

        MSMediaKeyError error { get; }

        string keySystem { get; }

        void close();

        void update(Uint8Array key);
    }

    public partial interface UnviewableContentIdentifiedEvent : NavigationEvent
    {
        string referrer { get; }
    }

    public partial interface CryptoOperation : EventTarget
    {
        Algorithm algorithm { get; }

        System.Func<Event, object> oncomplete { get; }

        System.Func<ErrorEvent, object> onerror { get; }

        System.Func<ProgressEvent, object> onprogress { get; }

        System.Func<UIEvent, object> onabort { get; }

        Key key { get; }

        object result { get; }

        void abort();

        void finish();

        void process(ArrayBufferView buffer);

        void addEventListener(string type, EventListener listener, bool useCapture = false);
    }

    public partial interface WebGLTexture : WebGLObject
    {
    }

    public partial interface OES_texture_float
    {
    }

    public partial interface WebGLContextEvent : Event
    {
        string statusMessage { get; }
    }

    public partial interface WebGLRenderbuffer : WebGLObject
    {
    }

    public partial interface WebGLUniformLocation
    {
    }

    public partial interface WebGLActiveInfo
    {
        string name { get; }

        double type { get; }

        double size { get; }
    }

    public partial interface WEBGL_compressed_texture_s3tc
    {
        double COMPRESSED_RGBA_S3TC_DXT1_EXT { get; }

        double COMPRESSED_RGBA_S3TC_DXT5_EXT { get; }

        double COMPRESSED_RGBA_S3TC_DXT3_EXT { get; }

        double COMPRESSED_RGB_S3TC_DXT1_EXT { get; }
    }

    public partial interface WebGLRenderingContext
    {
        double drawingBufferWidth { get; }

        double drawingBufferHeight { get; }

        HTMLCanvasElement canvas { get; }

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

        void texImage2D(
            double target, double level, double internalformat, double width, double height, double border, double format, double type, ArrayBufferView pixels);

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

        void texSubImage2D(
            double target, double level, double xoffset, double yoffset, double width, double height, double format, double type, ArrayBufferView pixels);

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

        void compressedTexSubImage2D(
            double target, double level, double xoffset, double yoffset, double width, double height, double format, ArrayBufferView data);

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

        double DEPTH_FUNC { get; }

        double DEPTH_COMPONENT16 { get; }

        double REPLACE { get; }

        double REPEAT { get; }

        double VERTEX_ATTRIB_ARRAY_ENABLED { get; }

        double FRAMEBUFFER_INCOMPLETE_DIMENSIONS { get; }

        double STENCIL_BUFFER_BIT { get; }

        double RENDERER { get; }

        double STENCIL_BACK_REF { get; }

        double TEXTURE26 { get; }

        double RGB565 { get; }

        double DITHER { get; }

        double CONSTANT_COLOR { get; }

        double GENERATE_MIPMAP_HINT { get; }

        double POINTS { get; }

        double DECR { get; }

        double INT_VEC3 { get; }

        double TEXTURE28 { get; }

        double ONE_MINUS_CONSTANT_ALPHA { get; }

        double BACK { get; }

        double RENDERBUFFER_STENCIL_SIZE { get; }

        double UNPACK_FLIP_Y_WEBGL { get; }

        double BLEND { get; }

        double TEXTURE9 { get; }

        double ARRAY_BUFFER_BINDING { get; }

        double MAX_VIEWPORT_DIMS { get; }

        double INVALID_FRAMEBUFFER_OPERATION { get; }

        double TEXTURE { get; }

        double TEXTURE0 { get; }

        double TEXTURE31 { get; }

        double TEXTURE24 { get; }

        double HIGH_INT { get; }

        double RENDERBUFFER_BINDING { get; }

        double BLEND_COLOR { get; }

        double FASTEST { get; }

        double STENCIL_WRITEMASK { get; }

        double ALIASED_POINT_SIZE_RANGE { get; }

        double TEXTURE12 { get; }

        double DST_ALPHA { get; }

        double BLEND_EQUATION_RGB { get; }

        double FRAMEBUFFER_COMPLETE { get; }

        double NEAREST_MIPMAP_NEAREST { get; }

        double VERTEX_ATTRIB_ARRAY_SIZE { get; }

        double TEXTURE3 { get; }

        double DEPTH_WRITEMASK { get; }

        double CONTEXT_LOST_WEBGL { get; }

        double INVALID_VALUE { get; }

        double TEXTURE_MAG_FILTER { get; }

        double ONE_MINUS_CONSTANT_COLOR { get; }

        double ONE_MINUS_SRC_ALPHA { get; }

        double TEXTURE_CUBE_MAP_POSITIVE_Z { get; }

        double NOTEQUAL { get; }

        double ALPHA { get; }

        double DEPTH_STENCIL { get; }

        double MAX_VERTEX_UNIFORM_VECTORS { get; }

        double DEPTH_COMPONENT { get; }

        double RENDERBUFFER_RED_SIZE { get; }

        double TEXTURE20 { get; }

        double RED_BITS { get; }

        double RENDERBUFFER_BLUE_SIZE { get; }

        double SCISSOR_BOX { get; }

        double VENDOR { get; }

        double FRONT_AND_BACK { get; }

        double CONSTANT_ALPHA { get; }

        double VERTEX_ATTRIB_ARRAY_BUFFER_BINDING { get; }

        double NEAREST { get; }

        double CULL_FACE { get; }

        double ALIASED_LINE_WIDTH_RANGE { get; }

        double TEXTURE19 { get; }

        double FRONT { get; }

        double DEPTH_CLEAR_VALUE { get; }

        double GREEN_BITS { get; }

        double TEXTURE29 { get; }

        double TEXTURE23 { get; }

        double MAX_RENDERBUFFER_SIZE { get; }

        double STENCIL_ATTACHMENT { get; }

        double TEXTURE27 { get; }

        double BOOL_VEC2 { get; }

        double OUT_OF_MEMORY { get; }

        double MIRRORED_REPEAT { get; }

        double POLYGON_OFFSET_UNITS { get; }

        double TEXTURE_MIN_FILTER { get; }

        double STENCIL_BACK_PASS_DEPTH_PASS { get; }

        double LINE_LOOP { get; }

        double FLOAT_MAT3 { get; }

        double TEXTURE14 { get; }

        double LINEAR { get; }

        double RGB5_A1 { get; }

        double ONE_MINUS_SRC_COLOR { get; }

        double SAMPLE_COVERAGE_INVERT { get; }

        double DONT_CARE { get; }

        double FRAMEBUFFER_BINDING { get; }

        double RENDERBUFFER_ALPHA_SIZE { get; }

        double STENCIL_REF { get; }

        double ZERO { get; }

        double DECR_WRAP { get; }

        double SAMPLE_COVERAGE { get; }

        double STENCIL_BACK_FUNC { get; }

        double TEXTURE30 { get; }

        double VIEWPORT { get; }

        double STENCIL_BITS { get; }

        double FLOAT { get; }

        double COLOR_WRITEMASK { get; }

        double SAMPLE_COVERAGE_VALUE { get; }

        double TEXTURE_CUBE_MAP_NEGATIVE_Y { get; }

        double STENCIL_BACK_FAIL { get; }

        double FLOAT_MAT4 { get; }

        double UNSIGNED_SHORT_4_4_4_4 { get; }

        double TEXTURE6 { get; }

        double RENDERBUFFER_WIDTH { get; }

        double RGBA4 { get; }

        double ALWAYS { get; }

        double BLEND_EQUATION_ALPHA { get; }

        double COLOR_BUFFER_BIT { get; }

        double TEXTURE_CUBE_MAP { get; }

        double DEPTH_BUFFER_BIT { get; }

        double STENCIL_CLEAR_VALUE { get; }

        double BLEND_EQUATION { get; }

        double RENDERBUFFER_GREEN_SIZE { get; }

        double NEAREST_MIPMAP_LINEAR { get; }

        double VERTEX_ATTRIB_ARRAY_TYPE { get; }

        double INCR_WRAP { get; }

        double ONE_MINUS_DST_COLOR { get; }

        double HIGH_FLOAT { get; }

        double BYTE { get; }

        double FRONT_FACE { get; }

        double SAMPLE_ALPHA_TO_COVERAGE { get; }

        double CCW { get; }

        double TEXTURE13 { get; }

        double MAX_VERTEX_ATTRIBS { get; }

        double MAX_VERTEX_TEXTURE_IMAGE_UNITS { get; }

        double TEXTURE_WRAP_T { get; }

        double UNPACK_PREMULTIPLY_ALPHA_WEBGL { get; }

        double FLOAT_VEC2 { get; }

        double LUMINANCE { get; }

        double GREATER { get; }

        double INT_VEC2 { get; }

        double VALIDATE_STATUS { get; }

        double FRAMEBUFFER { get; }

        double FRAMEBUFFER_UNSUPPORTED { get; }

        double TEXTURE5 { get; }

        double FUNC_SUBTRACT { get; }

        double BLEND_DST_ALPHA { get; }

        double SAMPLER_CUBE { get; }

        double ONE_MINUS_DST_ALPHA { get; }

        double LESS { get; }

        double TEXTURE_CUBE_MAP_POSITIVE_X { get; }

        double BLUE_BITS { get; }

        double DEPTH_TEST { get; }

        double VERTEX_ATTRIB_ARRAY_STRIDE { get; }

        double DELETE_STATUS { get; }

        double TEXTURE18 { get; }

        double POLYGON_OFFSET_FACTOR { get; }

        double UNSIGNED_INT { get; }

        double TEXTURE_2D { get; }

        double DST_COLOR { get; }

        double FLOAT_MAT2 { get; }

        double COMPRESSED_TEXTURE_FORMATS { get; }

        double MAX_FRAGMENT_UNIFORM_VECTORS { get; }

        double DEPTH_STENCIL_ATTACHMENT { get; }

        double LUMINANCE_ALPHA { get; }

        double CW { get; }

        double VERTEX_ATTRIB_ARRAY_NORMALIZED { get; }

        double TEXTURE_CUBE_MAP_NEGATIVE_Z { get; }

        double LINEAR_MIPMAP_LINEAR { get; }

        double BUFFER_SIZE { get; }

        double SAMPLE_BUFFERS { get; }

        double TEXTURE15 { get; }

        double ACTIVE_TEXTURE { get; }

        double VERTEX_SHADER { get; }

        double TEXTURE22 { get; }

        double VERTEX_ATTRIB_ARRAY_POINTER { get; }

        double INCR { get; }

        double COMPILE_STATUS { get; }

        double MAX_COMBINED_TEXTURE_IMAGE_UNITS { get; }

        double TEXTURE7 { get; }

        double UNSIGNED_SHORT_5_5_5_1 { get; }

        double DEPTH_BITS { get; }

        double RGBA { get; }

        double TRIANGLE_STRIP { get; }

        double COLOR_CLEAR_VALUE { get; }

        double BROWSER_DEFAULT_WEBGL { get; }

        double INVALID_ENUM { get; }

        double SCISSOR_TEST { get; }

        double LINE_STRIP { get; }

        double FRAMEBUFFER_INCOMPLETE_ATTACHMENT { get; }

        double STENCIL_FUNC { get; }

        double FRAMEBUFFER_ATTACHMENT_OBJECT_NAME { get; }

        double RENDERBUFFER_HEIGHT { get; }

        double TEXTURE8 { get; }

        double TRIANGLES { get; }

        double FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE { get; }

        double STENCIL_BACK_VALUE_MASK { get; }

        double TEXTURE25 { get; }

        double RENDERBUFFER { get; }

        double LEQUAL { get; }

        double TEXTURE1 { get; }

        double STENCIL_INDEX8 { get; }

        double FUNC_ADD { get; }

        double STENCIL_FAIL { get; }

        double BLEND_SRC_ALPHA { get; }

        double BOOL { get; }

        double ALPHA_BITS { get; }

        double LOW_INT { get; }

        double TEXTURE10 { get; }

        double SRC_COLOR { get; }

        double MAX_VARYING_VECTORS { get; }

        double BLEND_DST_RGB { get; }

        double TEXTURE_BINDING_CUBE_MAP { get; }

        double STENCIL_INDEX { get; }

        double TEXTURE_BINDING_2D { get; }

        double MEDIUM_INT { get; }

        double SHADER_TYPE { get; }

        double POLYGON_OFFSET_FILL { get; }

        double DYNAMIC_DRAW { get; }

        double TEXTURE4 { get; }

        double STENCIL_BACK_PASS_DEPTH_FAIL { get; }

        double STREAM_DRAW { get; }

        double MAX_CUBE_MAP_TEXTURE_SIZE { get; }

        double TEXTURE17 { get; }

        double TRIANGLE_FAN { get; }

        double UNPACK_ALIGNMENT { get; }

        double CURRENT_PROGRAM { get; }

        double LINES { get; }

        double INVALID_OPERATION { get; }

        double FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT { get; }

        double LINEAR_MIPMAP_NEAREST { get; }

        double CLAMP_TO_EDGE { get; }

        double RENDERBUFFER_DEPTH_SIZE { get; }

        double TEXTURE_WRAP_S { get; }

        double ELEMENT_ARRAY_BUFFER { get; }

        double UNSIGNED_SHORT_5_6_5 { get; }

        double ACTIVE_UNIFORMS { get; }

        double FLOAT_VEC3 { get; }

        double NO_ERROR { get; }

        double ATTACHED_SHADERS { get; }

        double DEPTH_ATTACHMENT { get; }

        double TEXTURE11 { get; }

        double STENCIL_TEST { get; }

        double ONE { get; }

        double FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE { get; }

        double STATIC_DRAW { get; }

        double GEQUAL { get; }

        double BOOL_VEC4 { get; }

        double COLOR_ATTACHMENT0 { get; }

        double PACK_ALIGNMENT { get; }

        double MAX_TEXTURE_SIZE { get; }

        double STENCIL_PASS_DEPTH_FAIL { get; }

        double CULL_FACE_MODE { get; }

        double TEXTURE16 { get; }

        double STENCIL_BACK_WRITEMASK { get; }

        double SRC_ALPHA { get; }

        double UNSIGNED_SHORT { get; }

        double TEXTURE21 { get; }

        double FUNC_REVERSE_SUBTRACT { get; }

        double SHADING_LANGUAGE_VERSION { get; }

        double EQUAL { get; }

        double FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL { get; }

        double BOOL_VEC3 { get; }

        double SAMPLER_2D { get; }

        double TEXTURE_CUBE_MAP_NEGATIVE_X { get; }

        double MAX_TEXTURE_IMAGE_UNITS { get; }

        double TEXTURE_CUBE_MAP_POSITIVE_Y { get; }

        double RENDERBUFFER_INTERNAL_FORMAT { get; }

        double STENCIL_VALUE_MASK { get; }

        double ELEMENT_ARRAY_BUFFER_BINDING { get; }

        double ARRAY_BUFFER { get; }

        double DEPTH_RANGE { get; }

        double NICEST { get; }

        double ACTIVE_ATTRIBUTES { get; }

        double NEVER { get; }

        double FLOAT_VEC4 { get; }

        double CURRENT_VERTEX_ATTRIB { get; }

        double STENCIL_PASS_DEPTH_PASS { get; }

        double INVERT { get; }

        double LINK_STATUS { get; }

        double RGB { get; }

        double INT_VEC4 { get; }

        double TEXTURE2 { get; }

        double UNPACK_COLORSPACE_CONVERSION_WEBGL { get; }

        double MEDIUM_FLOAT { get; }

        double SRC_ALPHA_SATURATE { get; }

        double BUFFER_USAGE { get; }

        double SHORT { get; }

        double NONE { get; }

        double UNSIGNED_BYTE { get; }

        double INT { get; }

        double SUBPIXEL_BITS { get; }

        double KEEP { get; }

        double SAMPLES { get; }

        double FRAGMENT_SHADER { get; }

        double LINE_WIDTH { get; }

        double BLEND_SRC_RGB { get; }

        double LOW_FLOAT { get; }

        double VERSION { get; }
    }

    public partial interface WebGLProgram : WebGLObject
    {
    }

    public partial interface OES_standard_derivatives
    {
        double FRAGMENT_SHADER_DERIVATIVE_HINT_OES { get; }
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
    }

    public partial interface WebGLBuffer : WebGLObject
    {
    }

    public partial interface WebGLShaderPrecisionFormat
    {
        double rangeMin { get; }

        double rangeMax { get; }

        double precision { get; }
    }

    public partial interface EXT_texture_filter_anisotropic
    {
        double TEXTURE_MAX_ANISOTROPY_EXT { get; }

        double MAX_TEXTURE_MAX_ANISOTROPY_EXT { get; }
    }
}