target datalayout = "e-p:32:32:32-i1:8:8-i8:8:8-i16:16:16-i32:32:32-i64:64:64-f32:32:32-f64:64:64-f80:128:128-v64:64:64-v128:128:128-a0:0:64-f80:32:32-n8:16:32-S32"
target triple = "i686-pc-win32"

@llvm.global_ctors = appending global [1 x { i32, void ()* }] [{ i32, void ()* } { i32 65535, void ()* @_GLOBAL_CTORS_EXECUTE_ }]

declare i8* @malloc(i32) #99900

; Function Attrs: nounwind
declare void @llvm.memcpy.p0i8.p0i8.i32(i8* nocapture, i8* nocapture readonly, i32, i32, i1) #88801
declare void @llvm.memset.p0i8.i32(i8*, i8, i32, i32, i1) #88802

attributes #88801 = { nounwind }
attributes #88802 = { nounwind }

; Exception support - DWARF
declare i32 @__gxx_personality_v0(...) #78801
declare i8* @__cxa_allocate_exception(i32) #78802
declare void @__cxa_free_exception(i8*) #78803
declare void @__cxa_throw(i8*, i8*, i8*) #78804
; Function Attrs: nounwind readnone
declare i32 @llvm.eh.typeid.for(i8*) #78805
declare i8* @__cxa_begin_catch(i8*) #78806
declare void @__cxa_end_catch() #78807
declare void @__cxa_call_unexpected(i8*) #78808
declare void @__cxa_rethrow() #78809
; Function Attrs: nounwind readonly
declare i8* @__dynamic_cast(i8*, i8*, i8*, i32) #78810
; 'c++ new' Function Attrs: nobuiltin
declare noalias i8* @_Znwj(i32) #78811
; 'c++ delete' Function Attrs: nobuiltin nounwind
declare void @_ZdlPv(i8*) #78812
declare void @__cxa_pure_virtual() #78813

attributes #78805 = { nounwind readnone }
attributes #78810 = { nounwind readonly }
attributes #78811 = { nobuiltin }
attributes #78812 = { nobuiltin nounwind }

; RTTI externals
@_ZTVN10__cxxabiv116__enum_type_infoE = external global i8*
@_ZTVN10__cxxabiv117__array_type_infoE = external global i8*
@_ZTVN10__cxxabiv117__class_type_infoE = external global i8*
@_ZTVN10__cxxabiv119__pointer_type_infoE = external global i8*
@_ZTVN10__cxxabiv120__si_class_type_infoE = external global i8*
@_ZTVN10__cxxabiv120__function_type_infoE = external global i8*
@_ZTVN10__cxxabiv121__vmi_class_type_infoE = external global i8*
@_ZTVN10__cxxabiv123__fundamental_type_infoE = external global i8*
@_ZTVN10__cxxabiv129__pointer_to_member_type_infoE = external global i8*


%"System.Object" = type {
    i32 (...)**
    
}

%"BabylonGlut.Main" = type {
    %"System.Object",
    i32,
    i32,
    i32,
    i32
}
@"BabylonGlut.Main.GL_COLOR_BUFFER_BIT" = global i32 undef
@"BabylonGlut.Main.GL_DEPTH_BUFFER_BIT" = global i32 undef

@"BabylonGlut.Main Virtual Table" = linkonce_odr unnamed_addr constant [6 x i8*] [
    i8* null,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Main Info" to i8*),
    i8* bitcast (%"System.String"* (%"System.Object"*)* @"System.String System.Object.ToString()" to i8*),
    i8* bitcast (i1 (%"System.Object"*, %"System.Object"*)* @"Boolean System.Object.Equals(System.Object)" to i8*),
    i8* bitcast (i32 (%"System.Object"*)* @"Int32 System.Object.GetHashCode()" to i8*),
    i8* bitcast (void (%"System.Object"*)* @"Void System.Object.Finalize()" to i8*)
]

; RTTI class
@"BabylonGlut.Main String Name" = linkonce_odr constant [19 x i8] c"16BabylonGlut.Main\00"
@"BabylonGlut.Main Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv120__si_class_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([19 x i8]* @"BabylonGlut.Main String Name", i32 0, i32 0),
    i8* bitcast ({ i8*, i8* }* @"System.Object Info" to i8*)
}
; RTTI pointer
@"BabylonGlut.Main Pointer String Name" = linkonce_odr constant [20 x i8] c"P16BabylonGlut.Main\00"
@"BabylonGlut.Main Pointer Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i32, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv119__pointer_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([20 x i8]* @"BabylonGlut.Main Pointer String Name", i32 0, i32 0),
    i32 0,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Main Info" to i8*)
}

; Init Object method
define void @"Void BabylonGlut.Main..init()"(%"BabylonGlut.Main"* %this) #0 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Main"* %.r1 to i8***
    store i8** getelementptr inbounds ([6 x i8*]* @"BabylonGlut.Main Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



%"BabylonGlut.Program" = type {
    %"System.Object"
}
@"BabylonGlut.Program.GLUT_RGB" = global i32 undef
@"BabylonGlut.Program.GLUT_RGBA" = global i32 undef
@"BabylonGlut.Program.GLUT_INDEX" = global i32 undef
@"BabylonGlut.Program.GLUT_SINGLE" = global i32 undef
@"BabylonGlut.Program.GLUT_DOUBLE" = global i32 undef
@"BabylonGlut.Program.GLUT_ACCUM" = global i32 undef
@"BabylonGlut.Program.GLUT_ALPHA" = global i32 undef
@"BabylonGlut.Program.GLUT_DEPTH" = global i32 undef
@"BabylonGlut.Program.GLUT_STENCIL" = global i32 undef
@"BabylonGlut.Program.GLUT_MULTISAMPLE" = global i32 undef
@"BabylonGlut.Program.GLUT_STEREO" = global i32 undef
@"BabylonGlut.Program.GLUT_LUMINANCE" = global i32 undef
@"BabylonGlut.Program._main" = global %"BabylonGlut.Main"* undef

@"BabylonGlut.Program Virtual Table" = linkonce_odr unnamed_addr constant [6 x i8*] [
    i8* null,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program Info" to i8*),
    i8* bitcast (%"System.String"* (%"System.Object"*)* @"System.String System.Object.ToString()" to i8*),
    i8* bitcast (i1 (%"System.Object"*, %"System.Object"*)* @"Boolean System.Object.Equals(System.Object)" to i8*),
    i8* bitcast (i32 (%"System.Object"*)* @"Int32 System.Object.GetHashCode()" to i8*),
    i8* bitcast (void (%"System.Object"*)* @"Void System.Object.Finalize()" to i8*)
]

; RTTI class
@"BabylonGlut.Program String Name" = linkonce_odr constant [22 x i8] c"19BabylonGlut.Program\00"
@"BabylonGlut.Program Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv120__si_class_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([22 x i8]* @"BabylonGlut.Program String Name", i32 0, i32 0),
    i8* bitcast ({ i8*, i8* }* @"System.Object Info" to i8*)
}
; RTTI pointer
@"BabylonGlut.Program Pointer String Name" = linkonce_odr constant [23 x i8] c"P19BabylonGlut.Program\00"
@"BabylonGlut.Program Pointer Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i32, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv119__pointer_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([23 x i8]* @"BabylonGlut.Program Pointer String Name", i32 0, i32 0),
    i32 0,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program Info" to i8*)
}

; Init Object method
define void @"Void BabylonGlut.Program..init()"(%"BabylonGlut.Program"* %this) #1 {
    %.this = alloca %"BabylonGlut.Program"*, align 4
    store %"BabylonGlut.Program"* %this, %"BabylonGlut.Program"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Program"* %.r1 to i8***
    store i8** getelementptr inbounds ([6 x i8*]* @"BabylonGlut.Program Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



%"System.ValueType" = type {
    %"System.Object"
}

%"System.IntPtr" = type {
    %"System.ValueType",
    i8*
}

%"System.Delegate" = type {
    %"System.Object",
    %"System.Object"*,
    %"System.IntPtr"
}

%"System.MulticastDelegate" = type {
    %"System.Delegate"
}

%"BabylonGlut.Program+EmptyDelegate" = type {
    %"System.MulticastDelegate"
}

@"BabylonGlut.Program+EmptyDelegate Virtual Table" = linkonce_odr unnamed_addr constant [9 x i8*] [
    i8* null,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+EmptyDelegate Info" to i8*),
    i8* bitcast (%"System.String"* (%"System.Object"*)* @"System.String System.Object.ToString()" to i8*),
    i8* bitcast (i1 (%"System.Delegate"*, %"System.Object"*)* @"Boolean System.Delegate.Equals(System.Object)" to i8*),
    i8* bitcast (i32 (%"System.Object"*)* @"Int32 System.Object.GetHashCode()" to i8*),
    i8* bitcast (void (%"System.Object"*)* @"Void System.Object.Finalize()" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+EmptyDelegate"*)* @"Void BabylonGlut.Program+EmptyDelegate.Invoke()" to i8*),
    i8* bitcast (%"System.IAsyncResult"* (%"BabylonGlut.Program+EmptyDelegate"*, %"System.AsyncCallback"*, %"System.Object"*)* @"System.IAsyncResult BabylonGlut.Program+EmptyDelegate.BeginInvoke(System.AsyncCallback, System.Object)" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+EmptyDelegate"*, %"System.IAsyncResult"*)* @"Void BabylonGlut.Program+EmptyDelegate.EndInvoke(System.IAsyncResult)" to i8*)
]

; RTTI class
@"BabylonGlut.Program+EmptyDelegate String Name" = linkonce_odr constant [36 x i8] c"33BabylonGlut.Program+EmptyDelegate\00"
@"BabylonGlut.Program+EmptyDelegate Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv120__si_class_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([36 x i8]* @"BabylonGlut.Program+EmptyDelegate String Name", i32 0, i32 0),
    i8* bitcast ({ i8*, i8*, i8* }* @"System.MulticastDelegate Info" to i8*)
}
; RTTI pointer
@"BabylonGlut.Program+EmptyDelegate Pointer String Name" = linkonce_odr constant [37 x i8] c"P33BabylonGlut.Program+EmptyDelegate\00"
@"BabylonGlut.Program+EmptyDelegate Pointer Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i32, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv119__pointer_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([37 x i8]* @"BabylonGlut.Program+EmptyDelegate Pointer String Name", i32 0, i32 0),
    i32 0,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+EmptyDelegate Info" to i8*)
}

; Init Object method
define void @"Void BabylonGlut.Program+EmptyDelegate..init()"(%"BabylonGlut.Program+EmptyDelegate"* %this) #2 {
    %.this = alloca %"BabylonGlut.Program+EmptyDelegate"*, align 4
    store %"BabylonGlut.Program+EmptyDelegate"* %this, %"BabylonGlut.Program+EmptyDelegate"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program+EmptyDelegate"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Program+EmptyDelegate"* %.r1 to i8***
    store i8** getelementptr inbounds ([9 x i8*]* @"BabylonGlut.Program+EmptyDelegate Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



%"BabylonGlut.Program+TwoDimDelegate" = type {
    %"System.MulticastDelegate"
}

@"BabylonGlut.Program+TwoDimDelegate Virtual Table" = linkonce_odr unnamed_addr constant [9 x i8*] [
    i8* null,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+TwoDimDelegate Info" to i8*),
    i8* bitcast (%"System.String"* (%"System.Object"*)* @"System.String System.Object.ToString()" to i8*),
    i8* bitcast (i1 (%"System.Delegate"*, %"System.Object"*)* @"Boolean System.Delegate.Equals(System.Object)" to i8*),
    i8* bitcast (i32 (%"System.Object"*)* @"Int32 System.Object.GetHashCode()" to i8*),
    i8* bitcast (void (%"System.Object"*)* @"Void System.Object.Finalize()" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+TwoDimDelegate"*, i32, i32)* @"Void BabylonGlut.Program+TwoDimDelegate.Invoke(Int32, Int32)" to i8*),
    i8* bitcast (%"System.IAsyncResult"* (%"BabylonGlut.Program+TwoDimDelegate"*, i32, i32, %"System.AsyncCallback"*, %"System.Object"*)* @"System.IAsyncResult BabylonGlut.Program+TwoDimDelegate.BeginInvoke(Int32, Int32, System.AsyncCallback, System.Object)" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+TwoDimDelegate"*, %"System.IAsyncResult"*)* @"Void BabylonGlut.Program+TwoDimDelegate.EndInvoke(System.IAsyncResult)" to i8*)
]

; RTTI class
@"BabylonGlut.Program+TwoDimDelegate String Name" = linkonce_odr constant [37 x i8] c"34BabylonGlut.Program+TwoDimDelegate\00"
@"BabylonGlut.Program+TwoDimDelegate Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv120__si_class_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([37 x i8]* @"BabylonGlut.Program+TwoDimDelegate String Name", i32 0, i32 0),
    i8* bitcast ({ i8*, i8*, i8* }* @"System.MulticastDelegate Info" to i8*)
}
; RTTI pointer
@"BabylonGlut.Program+TwoDimDelegate Pointer String Name" = linkonce_odr constant [38 x i8] c"P34BabylonGlut.Program+TwoDimDelegate\00"
@"BabylonGlut.Program+TwoDimDelegate Pointer Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i32, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv119__pointer_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([38 x i8]* @"BabylonGlut.Program+TwoDimDelegate Pointer String Name", i32 0, i32 0),
    i32 0,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+TwoDimDelegate Info" to i8*)
}

; Init Object method
define void @"Void BabylonGlut.Program+TwoDimDelegate..init()"(%"BabylonGlut.Program+TwoDimDelegate"* %this) #3 {
    %.this = alloca %"BabylonGlut.Program+TwoDimDelegate"*, align 4
    store %"BabylonGlut.Program+TwoDimDelegate"* %this, %"BabylonGlut.Program+TwoDimDelegate"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program+TwoDimDelegate"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Program+TwoDimDelegate"* %.r1 to i8***
    store i8** getelementptr inbounds ([9 x i8*]* @"BabylonGlut.Program+TwoDimDelegate Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



%"BabylonGlut.Program+MouseDelegate" = type {
    %"System.MulticastDelegate"
}

@"BabylonGlut.Program+MouseDelegate Virtual Table" = linkonce_odr unnamed_addr constant [9 x i8*] [
    i8* null,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+MouseDelegate Info" to i8*),
    i8* bitcast (%"System.String"* (%"System.Object"*)* @"System.String System.Object.ToString()" to i8*),
    i8* bitcast (i1 (%"System.Delegate"*, %"System.Object"*)* @"Boolean System.Delegate.Equals(System.Object)" to i8*),
    i8* bitcast (i32 (%"System.Object"*)* @"Int32 System.Object.GetHashCode()" to i8*),
    i8* bitcast (void (%"System.Object"*)* @"Void System.Object.Finalize()" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+MouseDelegate"*, i32, i32, i32, i32)* @"Void BabylonGlut.Program+MouseDelegate.Invoke(Int32, Int32, Int32, Int32)" to i8*),
    i8* bitcast (%"System.IAsyncResult"* (%"BabylonGlut.Program+MouseDelegate"*, i32, i32, i32, i32, %"System.AsyncCallback"*, %"System.Object"*)* @"System.IAsyncResult BabylonGlut.Program+MouseDelegate.BeginInvoke(Int32, Int32, Int32, Int32, System.AsyncCallback, System.Object)" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+MouseDelegate"*, %"System.IAsyncResult"*)* @"Void BabylonGlut.Program+MouseDelegate.EndInvoke(System.IAsyncResult)" to i8*)
]

; RTTI class
@"BabylonGlut.Program+MouseDelegate String Name" = linkonce_odr constant [36 x i8] c"33BabylonGlut.Program+MouseDelegate\00"
@"BabylonGlut.Program+MouseDelegate Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv120__si_class_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([36 x i8]* @"BabylonGlut.Program+MouseDelegate String Name", i32 0, i32 0),
    i8* bitcast ({ i8*, i8*, i8* }* @"System.MulticastDelegate Info" to i8*)
}
; RTTI pointer
@"BabylonGlut.Program+MouseDelegate Pointer String Name" = linkonce_odr constant [37 x i8] c"P33BabylonGlut.Program+MouseDelegate\00"
@"BabylonGlut.Program+MouseDelegate Pointer Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i32, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv119__pointer_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([37 x i8]* @"BabylonGlut.Program+MouseDelegate Pointer String Name", i32 0, i32 0),
    i32 0,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+MouseDelegate Info" to i8*)
}

; Init Object method
define void @"Void BabylonGlut.Program+MouseDelegate..init()"(%"BabylonGlut.Program+MouseDelegate"* %this) #4 {
    %.this = alloca %"BabylonGlut.Program+MouseDelegate"*, align 4
    store %"BabylonGlut.Program+MouseDelegate"* %this, %"BabylonGlut.Program+MouseDelegate"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program+MouseDelegate"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Program+MouseDelegate"* %.r1 to i8***
    store i8** getelementptr inbounds ([9 x i8*]* @"BabylonGlut.Program+MouseDelegate Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



%"BabylonGlut.Program+KeyDelegate" = type {
    %"System.MulticastDelegate"
}

@"BabylonGlut.Program+KeyDelegate Virtual Table" = linkonce_odr unnamed_addr constant [9 x i8*] [
    i8* null,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+KeyDelegate Info" to i8*),
    i8* bitcast (%"System.String"* (%"System.Object"*)* @"System.String System.Object.ToString()" to i8*),
    i8* bitcast (i1 (%"System.Delegate"*, %"System.Object"*)* @"Boolean System.Delegate.Equals(System.Object)" to i8*),
    i8* bitcast (i32 (%"System.Object"*)* @"Int32 System.Object.GetHashCode()" to i8*),
    i8* bitcast (void (%"System.Object"*)* @"Void System.Object.Finalize()" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+KeyDelegate"*, i8, i32, i32)* @"Void BabylonGlut.Program+KeyDelegate.Invoke(Byte, Int32, Int32)" to i8*),
    i8* bitcast (%"System.IAsyncResult"* (%"BabylonGlut.Program+KeyDelegate"*, i8, i32, i32, %"System.AsyncCallback"*, %"System.Object"*)* @"System.IAsyncResult BabylonGlut.Program+KeyDelegate.BeginInvoke(Byte, Int32, Int32, System.AsyncCallback, System.Object)" to i8*),
    i8* bitcast (void (%"BabylonGlut.Program+KeyDelegate"*, %"System.IAsyncResult"*)* @"Void BabylonGlut.Program+KeyDelegate.EndInvoke(System.IAsyncResult)" to i8*)
]

; RTTI class
@"BabylonGlut.Program+KeyDelegate String Name" = linkonce_odr constant [34 x i8] c"31BabylonGlut.Program+KeyDelegate\00"
@"BabylonGlut.Program+KeyDelegate Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv120__si_class_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([34 x i8]* @"BabylonGlut.Program+KeyDelegate String Name", i32 0, i32 0),
    i8* bitcast ({ i8*, i8*, i8* }* @"System.MulticastDelegate Info" to i8*)
}
; RTTI pointer
@"BabylonGlut.Program+KeyDelegate Pointer String Name" = linkonce_odr constant [35 x i8] c"P31BabylonGlut.Program+KeyDelegate\00"
@"BabylonGlut.Program+KeyDelegate Pointer Info" = linkonce_odr unnamed_addr constant { i8*, i8*, i32, i8* } {
    i8* bitcast (i8** getelementptr inbounds (i8** @_ZTVN10__cxxabiv119__pointer_type_infoE, i32 2) to i8*),
    i8* getelementptr inbounds ([35 x i8]* @"BabylonGlut.Program+KeyDelegate Pointer String Name", i32 0, i32 0),
    i32 0,
    i8* bitcast ({ i8*, i8*, i8* }* @"BabylonGlut.Program+KeyDelegate Info" to i8*)
}

; Init Object method
define void @"Void BabylonGlut.Program+KeyDelegate..init()"(%"BabylonGlut.Program+KeyDelegate"* %this) #5 {
    %.this = alloca %"BabylonGlut.Program+KeyDelegate"*, align 4
    store %"BabylonGlut.Program+KeyDelegate"* %this, %"BabylonGlut.Program+KeyDelegate"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program+KeyDelegate"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Program+KeyDelegate"* %.r1 to i8***
    store i8** getelementptr inbounds ([9 x i8*]* @"BabylonGlut.Program+KeyDelegate Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



define void @"Void BabylonGlut.Main..ctor()"(%"BabylonGlut.Main"* %this) #6 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    ; Cast of 'This' parameter
    %.r2 = bitcast %"BabylonGlut.Main"* %.r1 to %"System.Object"*
    call void @"Void System.Object..ctor()"(%"System.Object"* %.r2)
    ret void
}

declare dllimport x86_stdcallcc void @glClear(i32) #7

define i32 @"Int32 BabylonGlut.Main.get_Width()"(%"BabylonGlut.Main"* %this) #8 {
    %local0 = alloca i32, align 4
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    ; Access to '<Width>k__BackingField' field
    %.r2 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 1
    %.r3 = load i32* %.r2, align 4
    store i32 %.r3, i32* %local0, align 4
    br label %.a9
.a9:
    %.r4 = load i32* %local0, align 4
    ret i32 %.r4
}

define void @"Void BabylonGlut.Main.set_Width(Int32)"(%"BabylonGlut.Main"* %this, i32 %value) #9 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.value = alloca i32, align 4
    store i32 %value, i32* %.value, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    %.r2 = load i32* %.value, align 4
    ; Access to '<Width>k__BackingField' field
    %.r3 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 1
    store i32 %.r2, i32* %.r3
    ret void
}

define i32 @"Int32 BabylonGlut.Main.get_Height()"(%"BabylonGlut.Main"* %this) #10 {
    %local0 = alloca i32, align 4
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    ; Access to '<Height>k__BackingField' field
    %.r2 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 2
    %.r3 = load i32* %.r2, align 4
    store i32 %.r3, i32* %local0, align 4
    br label %.a9
.a9:
    %.r4 = load i32* %local0, align 4
    ret i32 %.r4
}

define void @"Void BabylonGlut.Main.set_Height(Int32)"(%"BabylonGlut.Main"* %this, i32 %value) #11 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.value = alloca i32, align 4
    store i32 %value, i32* %.value, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    %.r2 = load i32* %.value, align 4
    ; Access to '<Height>k__BackingField' field
    %.r3 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 2
    store i32 %.r2, i32* %.r3
    ret void
}

define i32 @"Int32 BabylonGlut.Main.get_MaxWidth()"(%"BabylonGlut.Main"* %this) #12 {
    %local0 = alloca i32, align 4
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    ; Access to '<MaxWidth>k__BackingField' field
    %.r2 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 3
    %.r3 = load i32* %.r2, align 4
    store i32 %.r3, i32* %local0, align 4
    br label %.a9
.a9:
    %.r4 = load i32* %local0, align 4
    ret i32 %.r4
}

define void @"Void BabylonGlut.Main.set_MaxWidth(Int32)"(%"BabylonGlut.Main"* %this, i32 %value) #13 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.value = alloca i32, align 4
    store i32 %value, i32* %.value, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    %.r2 = load i32* %.value, align 4
    ; Access to '<MaxWidth>k__BackingField' field
    %.r3 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 3
    store i32 %.r2, i32* %.r3
    ret void
}

define i32 @"Int32 BabylonGlut.Main.get_MaxHeight()"(%"BabylonGlut.Main"* %this) #14 {
    %local0 = alloca i32, align 4
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    ; Access to '<MaxHeight>k__BackingField' field
    %.r2 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 4
    %.r3 = load i32* %.r2, align 4
    store i32 %.r3, i32* %local0, align 4
    br label %.a9
.a9:
    %.r4 = load i32* %local0, align 4
    ret i32 %.r4
}

define void @"Void BabylonGlut.Main.set_MaxHeight(Int32)"(%"BabylonGlut.Main"* %this, i32 %value) #15 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    %.value = alloca i32, align 4
    store i32 %value, i32* %.value, align 4
    %.r1 = load %"BabylonGlut.Main"** %.this, align 4
    %.r2 = load i32* %.value, align 4
    ; Access to '<MaxHeight>k__BackingField' field
    %.r3 = getelementptr inbounds %"BabylonGlut.Main"* %.r1, i32 0, i32 4
    store i32 %.r2, i32* %.r3
    ret void
}

define void @"Void BabylonGlut.Main.OnInitialize()"(%"BabylonGlut.Main"* %this) #16 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    ret void
}

define void @"Void BabylonGlut.Main.OnDraw()"(%"BabylonGlut.Main"* %this) #17 {
    %.this = alloca %"BabylonGlut.Main"*, align 4
    store %"BabylonGlut.Main"* %this, %"BabylonGlut.Main"** %.this, align 4
    call x86_stdcallcc void @glClear(i32 16640)
    ret void
}

define void @"Void BabylonGlut.Program..ctor()"(%"BabylonGlut.Program"* %this) #18 {
    %.this = alloca %"BabylonGlut.Program"*, align 4
    store %"BabylonGlut.Program"* %this, %"BabylonGlut.Program"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program"** %.this, align 4
    ; Cast of 'This' parameter
    %.r2 = bitcast %"BabylonGlut.Program"* %.r1 to %"System.Object"*
    call void @"Void System.Object..ctor()"(%"System.Object"* %.r2)
    ret void
}

declare void @glutInit(...) #19

declare void @glutInitWindowSize(...) #20

declare void @glutInitDisplayMode(...) #21

declare void @glutCreateWindow(...) #22

declare void @glutMainLoop(...) #23

declare void @glutDisplayFunc(...) #24

declare void @glutPassiveMotionFunc(...) #25

declare void @glutMouseFunc(...) #26

declare void @glutMotionFunc(...) #27

declare void @glutIdleFunc(...) #28

declare void @glutReshapeFunc(...) #29

declare void @glutKeyboardFunc(...) #30

declare void @glutPostRedisplay(...) #31

declare void @glutSwapBuffers(...) #32

define void @"Void BabylonGlut.Program.display()"() #33 {
    %.r1 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    call void @"Void BabylonGlut.Main.OnDraw()"(%"BabylonGlut.Main"* %.r1)
    call void (...)* @glutSwapBuffers()
    ret void
}

define void @"Void BabylonGlut.Program.passiveMotion(Int32, Int32)"(i32 %x, i32 %y) #34 {
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    call void (...)* @glutPostRedisplay()
    ret void
}

define void @"Void BabylonGlut.Program.key(Byte, Int32, Int32)"(i8 %k, i32 %x, i32 %y) #35 {
    %.k = alloca i8, align 4
    store i8 %k, i8* %.k, align 4
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    call void (...)* @glutPostRedisplay()
    ret void
}

define void @"Void BabylonGlut.Program.mouse(Int32, Int32, Int32, Int32)"(i32 %button, i32 %state, i32 %x, i32 %y) #36 {
    %.button = alloca i32, align 4
    store i32 %button, i32* %.button, align 4
    %.state = alloca i32, align 4
    store i32 %state, i32* %.state, align 4
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    call void (...)* @glutPostRedisplay()
    ret void
}

define void @"Void BabylonGlut.Program.idle()"() #37 {
    call void (...)* @glutPostRedisplay()
    ret void
}

define void @"Void BabylonGlut.Program.resize(Int32, Int32)"(i32 %w, i32 %h) #38 {
    %.w = alloca i32, align 4
    store i32 %w, i32* %.w, align 4
    %.h = alloca i32, align 4
    store i32 %h, i32* %.h, align 4
    ret void
}

define void @"Void BabylonGlut.Program.motion(Int32, Int32)"(i32 %x, i32 %y) #39 {
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    ret void
}

define void @"Void BabylonGlut.Program.Main(System.String[])"(%"System.String"** %args) #40 {
    %local0 = alloca i32, align 4
    %local1 = alloca i8**, align 4
    %local2 = alloca i32, align 4
    %.args = alloca %"System.String"**, align 4
    store %"System.String"** %args, %"System.String"*** %.args, align 4
    ; New obj
    %.r1 = call i8* @_Znwj(i32 12)
    call void @llvm.memset.p0i8.i32(i8* %.r1, i8 0, i32 12, i32 4, i1 false)
    %.r2 = bitcast i8* %.r1 to %"System.String"*
    ; call Init Object method
    call void @"Void System.String..init()"(%"System.String"* %.r2)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.String..ctor(Char[])"(%"System.String"* %.r2, i16* bitcast ([7 x i16]* getelementptr inbounds ({ i32, [7 x i16] }* @.s1, i32 0, i32 1) to i16*))
    call void @"Void System.Console.WriteLine(System.String)"(%"System.String"* %.r2)
    ; New obj
    %.r3 = call i8* @_Znwj(i32 20)
    call void @llvm.memset.p0i8.i32(i8* %.r3, i8 0, i32 20, i32 4, i1 false)
    %.r4 = bitcast i8* %.r3 to %"BabylonGlut.Main"*
    ; call Init Object method
    call void @"Void BabylonGlut.Main..init()"(%"BabylonGlut.Main"* %.r4)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Main..ctor()"(%"BabylonGlut.Main"* %.r4)
    store %"BabylonGlut.Main"* %.r4, %"BabylonGlut.Main"** @"BabylonGlut.Program._main"
    %.r5 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    %.r6 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    store i32 400, i32* %local2, align 4
    call void @"Void BabylonGlut.Main.set_Width(Int32)"(%"BabylonGlut.Main"* %.r6, i32 400)
    %.r7 = load i32* %local2, align 4
    call void @"Void BabylonGlut.Main.set_MaxWidth(Int32)"(%"BabylonGlut.Main"* %.r5, i32 %.r7)
    %.r8 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    %.r9 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    store i32 640, i32* %local2, align 4
    call void @"Void BabylonGlut.Main.set_Height(Int32)"(%"BabylonGlut.Main"* %.r9, i32 640)
    %.r10 = load i32* %local2, align 4
    call void @"Void BabylonGlut.Main.set_MaxHeight(Int32)"(%"BabylonGlut.Main"* %.r8, i32 %.r10)
    store i32 0, i32* %local0, align 4
    ; New array
    %.r11 = mul i32 0, 4
    %.r12 = add i32 4, %.r11
    %.r13 = call i8* @malloc(i32 %.r12)
    %.r14 = bitcast i8* %.r13 to i32*
    store i32 0, i32* %.r14
    %.r15 = getelementptr i32* %.r14, i32 1
    %.r16 = bitcast i32* %.r15 to i8**
    ; end of new array
    store i8** %.r16, i8*** %local1, align 4
    %.r17 = load i8*** %local1, align 4
    call void (...)* @glutInit(i32* %local0, i8** %.r17)
    %.r18 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    %.r19 = call i32 @"Int32 BabylonGlut.Main.get_Width()"(%"BabylonGlut.Main"* %.r18)
    %.r20 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    %.r21 = call i32 @"Int32 BabylonGlut.Main.get_Height()"(%"BabylonGlut.Main"* %.r20)
    call void (...)* @glutInitWindowSize(i32 %.r19, i32 %.r21)
    call void (...)* @glutInitDisplayMode(i32 18)
    call void (...)* @glutCreateWindow(i8* null)
    ; New obj
    %.r22 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r22, i8 0, i32 8, i32 4, i1 false)
    %.r23 = bitcast i8* %.r22 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r23)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r23, i8* bitcast (void ()* @"Void BabylonGlut.Program.display()" to i8*))
    ; New obj
    %.r24 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r24, i8 0, i32 24, i32 4, i1 false)
    %.r25 = bitcast i8* %.r24 to %"BabylonGlut.Program+EmptyDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+EmptyDelegate..init()"(%"BabylonGlut.Program+EmptyDelegate"* %.r25)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+EmptyDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+EmptyDelegate"* %.r25, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r23)
    ; Cast of 'This' parameter
    %.r26 = bitcast %"BabylonGlut.Program+EmptyDelegate"* %.r25 to %"System.Delegate"*
    %.r27 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r26)
    call void (...)* @glutDisplayFunc(i8* %.r27)
    ; New obj
    %.r28 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r28, i8 0, i32 8, i32 4, i1 false)
    %.r29 = bitcast i8* %.r28 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r29)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r29, i8* bitcast (void (i32, i32)* @"Void BabylonGlut.Program.passiveMotion(Int32, Int32)" to i8*))
    ; New obj
    %.r30 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r30, i8 0, i32 24, i32 4, i1 false)
    %.r31 = bitcast i8* %.r30 to %"BabylonGlut.Program+TwoDimDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+TwoDimDelegate..init()"(%"BabylonGlut.Program+TwoDimDelegate"* %.r31)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+TwoDimDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+TwoDimDelegate"* %.r31, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r29)
    ; Cast of 'This' parameter
    %.r32 = bitcast %"BabylonGlut.Program+TwoDimDelegate"* %.r31 to %"System.Delegate"*
    %.r33 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r32)
    call void (...)* @glutPassiveMotionFunc(i8* %.r33)
    ; New obj
    %.r34 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r34, i8 0, i32 8, i32 4, i1 false)
    %.r35 = bitcast i8* %.r34 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r35)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r35, i8* bitcast (void (i32, i32, i32, i32)* @"Void BabylonGlut.Program.mouse(Int32, Int32, Int32, Int32)" to i8*))
    ; New obj
    %.r36 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r36, i8 0, i32 24, i32 4, i1 false)
    %.r37 = bitcast i8* %.r36 to %"BabylonGlut.Program+MouseDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+MouseDelegate..init()"(%"BabylonGlut.Program+MouseDelegate"* %.r37)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+MouseDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+MouseDelegate"* %.r37, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r35)
    ; Cast of 'This' parameter
    %.r38 = bitcast %"BabylonGlut.Program+MouseDelegate"* %.r37 to %"System.Delegate"*
    %.r39 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r38)
    call void (...)* @glutMouseFunc(i8* %.r39)
    ; New obj
    %.r40 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r40, i8 0, i32 8, i32 4, i1 false)
    %.r41 = bitcast i8* %.r40 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r41)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r41, i8* bitcast (void (i32, i32)* @"Void BabylonGlut.Program.motion(Int32, Int32)" to i8*))
    ; New obj
    %.r42 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r42, i8 0, i32 24, i32 4, i1 false)
    %.r43 = bitcast i8* %.r42 to %"BabylonGlut.Program+TwoDimDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+TwoDimDelegate..init()"(%"BabylonGlut.Program+TwoDimDelegate"* %.r43)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+TwoDimDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+TwoDimDelegate"* %.r43, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r41)
    ; Cast of 'This' parameter
    %.r44 = bitcast %"BabylonGlut.Program+TwoDimDelegate"* %.r43 to %"System.Delegate"*
    %.r45 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r44)
    call void (...)* @glutMotionFunc(i8* %.r45)
    ; New obj
    %.r46 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r46, i8 0, i32 8, i32 4, i1 false)
    %.r47 = bitcast i8* %.r46 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r47)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r47, i8* bitcast (void ()* @"Void BabylonGlut.Program.idle()" to i8*))
    ; New obj
    %.r48 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r48, i8 0, i32 24, i32 4, i1 false)
    %.r49 = bitcast i8* %.r48 to %"BabylonGlut.Program+EmptyDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+EmptyDelegate..init()"(%"BabylonGlut.Program+EmptyDelegate"* %.r49)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+EmptyDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+EmptyDelegate"* %.r49, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r47)
    ; Cast of 'This' parameter
    %.r50 = bitcast %"BabylonGlut.Program+EmptyDelegate"* %.r49 to %"System.Delegate"*
    %.r51 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r50)
    call void (...)* @glutIdleFunc(i8* %.r51)
    ; New obj
    %.r52 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r52, i8 0, i32 8, i32 4, i1 false)
    %.r53 = bitcast i8* %.r52 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r53)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r53, i8* bitcast (void (i8, i32, i32)* @"Void BabylonGlut.Program.key(Byte, Int32, Int32)" to i8*))
    ; New obj
    %.r54 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r54, i8 0, i32 24, i32 4, i1 false)
    %.r55 = bitcast i8* %.r54 to %"BabylonGlut.Program+KeyDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+KeyDelegate..init()"(%"BabylonGlut.Program+KeyDelegate"* %.r55)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+KeyDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+KeyDelegate"* %.r55, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r53)
    ; Cast of 'This' parameter
    %.r56 = bitcast %"BabylonGlut.Program+KeyDelegate"* %.r55 to %"System.Delegate"*
    %.r57 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r56)
    call void (...)* @glutKeyboardFunc(i8* %.r57)
    ; New obj
    %.r58 = call i8* @_Znwj(i32 8)
    call void @llvm.memset.p0i8.i32(i8* %.r58, i8 0, i32 8, i32 4, i1 false)
    %.r59 = bitcast i8* %.r58 to %"System.IntPtr"*
    ; call Init Object method
    call void @"Void System.IntPtr..init()"(%"System.IntPtr"* %.r59)
    ; end of new obj
    ; Call Constructor
    call void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %.r59, i8* bitcast (void (i32, i32)* @"Void BabylonGlut.Program.resize(Int32, Int32)" to i8*))
    ; New obj
    %.r60 = call i8* @_Znwj(i32 24)
    call void @llvm.memset.p0i8.i32(i8* %.r60, i8 0, i32 24, i32 4, i1 false)
    %.r61 = bitcast i8* %.r60 to %"BabylonGlut.Program+TwoDimDelegate"*
    ; call Init Object method
    call void @"Void BabylonGlut.Program+TwoDimDelegate..init()"(%"BabylonGlut.Program+TwoDimDelegate"* %.r61)
    ; end of new obj
    ; Call Constructor
    call void @"Void BabylonGlut.Program+TwoDimDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+TwoDimDelegate"* %.r61, %"System.Object"* null, %"System.IntPtr"* byval align 4 %.r59)
    ; Cast of 'This' parameter
    %.r62 = bitcast %"BabylonGlut.Program+TwoDimDelegate"* %.r61 to %"System.Delegate"*
    %.r63 = call i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %.r62)
    call void (...)* @glutReshapeFunc(i8* %.r63)
    %.r64 = load %"BabylonGlut.Main"** @"BabylonGlut.Program._main", align 4
    call void @"Void BabylonGlut.Main.OnInitialize()"(%"BabylonGlut.Main"* %.r64)
    call void (...)* @glutMainLoop()
    ret void
}

@.s1 = private unnamed_addr constant { i32, [7 x i16] } { i32 6, [7 x i16] [i16 115, i16 116, i16 97, i16 114, i16 116, i16 46, i16 0] }, align 2

define void @"Void BabylonGlut.Program+EmptyDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+EmptyDelegate"* %this, %"System.Object"* %object, %"System.IntPtr"* byval align 4 %.method) #41 {
    %.this = alloca %"BabylonGlut.Program+EmptyDelegate"*, align 4
    store %"BabylonGlut.Program+EmptyDelegate"* %this, %"BabylonGlut.Program+EmptyDelegate"** %.this, align 4
    %.object = alloca %"System.Object"*, align 4
    store %"System.Object"* %object, %"System.Object"** %.object, align 4
    %.r1 = load %"BabylonGlut.Program+EmptyDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+EmptyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.object, align 4
    store %"System.Object"* %.r3, %"System.Object"** %.r2
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+EmptyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    
    %.r5 = bitcast %"System.IntPtr"* %.r4 to i8*
    %.r6 = bitcast %"System.IntPtr"* %.method to i8*
    call void @llvm.memcpy.p0i8.p0i8.i32(i8* %.r5, i8* %.r6, i32 8, i32 4, i1 false)
    
    ret void
}

define void @"Void BabylonGlut.Program+EmptyDelegate.Invoke()"(%"BabylonGlut.Program+EmptyDelegate"* %this) #42 {
    %.this = alloca %"BabylonGlut.Program+EmptyDelegate"*, align 4
    store %"BabylonGlut.Program+EmptyDelegate"* %this, %"BabylonGlut.Program+EmptyDelegate"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program+EmptyDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+EmptyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.r2, align 4
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+EmptyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    %.r5 = getelementptr inbounds %"System.IntPtr"* %.r4, i32 0, i32 1
    %.r6 = load i8** %.r5, align 4
    %.r7 = icmp ne %"System.Object"* %.r3, null
    br i1 %.r7, label %normal, label %static
normal:
    %.r8 = bitcast i8* %.r6 to void (%"System.Object"*)*
    call void %.r8(%"System.Object"* %.r3)
    
    
    ret void 
static:
    %.r9 = bitcast i8* %.r6 to void ()*
    call void %.r9()
    
    
    ret void 
}


define %"System.IAsyncResult"* @"System.IAsyncResult BabylonGlut.Program+EmptyDelegate.BeginInvoke(System.AsyncCallback, System.Object)"(%"BabylonGlut.Program+EmptyDelegate"* %this, %"System.AsyncCallback"* %callback, %"System.Object"* %object) #43 {
    ret %"System.IAsyncResult"* undef
}


define void @"Void BabylonGlut.Program+EmptyDelegate.EndInvoke(System.IAsyncResult)"(%"BabylonGlut.Program+EmptyDelegate"* %this, %"System.IAsyncResult"* %result) #44 {
    ret void
}


define void @"Void BabylonGlut.Program+TwoDimDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+TwoDimDelegate"* %this, %"System.Object"* %object, %"System.IntPtr"* byval align 4 %.method) #45 {
    %.this = alloca %"BabylonGlut.Program+TwoDimDelegate"*, align 4
    store %"BabylonGlut.Program+TwoDimDelegate"* %this, %"BabylonGlut.Program+TwoDimDelegate"** %.this, align 4
    %.object = alloca %"System.Object"*, align 4
    store %"System.Object"* %object, %"System.Object"** %.object, align 4
    %.r1 = load %"BabylonGlut.Program+TwoDimDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+TwoDimDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.object, align 4
    store %"System.Object"* %.r3, %"System.Object"** %.r2
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+TwoDimDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    
    %.r5 = bitcast %"System.IntPtr"* %.r4 to i8*
    %.r6 = bitcast %"System.IntPtr"* %.method to i8*
    call void @llvm.memcpy.p0i8.p0i8.i32(i8* %.r5, i8* %.r6, i32 8, i32 4, i1 false)
    
    ret void
}

define void @"Void BabylonGlut.Program+TwoDimDelegate.Invoke(Int32, Int32)"(%"BabylonGlut.Program+TwoDimDelegate"* %this, i32 %x, i32 %y) #46 {
    %.this = alloca %"BabylonGlut.Program+TwoDimDelegate"*, align 4
    store %"BabylonGlut.Program+TwoDimDelegate"* %this, %"BabylonGlut.Program+TwoDimDelegate"** %.this, align 4
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    %.r1 = load %"BabylonGlut.Program+TwoDimDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+TwoDimDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.r2, align 4
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+TwoDimDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    %.r5 = getelementptr inbounds %"System.IntPtr"* %.r4, i32 0, i32 1
    %.r6 = load i8** %.r5, align 4
    %.r7 = icmp ne %"System.Object"* %.r3, null
    br i1 %.r7, label %normal, label %static
normal:
    %.r8 = bitcast i8* %.r6 to void (%"System.Object"*, i32, i32)*
    %.r9 = load i32* %.x, align 4
    %.r10 = load i32* %.y, align 4
    call void %.r8(%"System.Object"* %.r3, i32 %.r9, i32 %.r10)
    
    
    ret void 
static:
    %.r11 = bitcast i8* %.r6 to void (i32, i32)*
    %.r12 = load i32* %.x, align 4
    %.r13 = load i32* %.y, align 4
    call void %.r11(i32 %.r12, i32 %.r13)
    
    
    ret void 
}


define %"System.IAsyncResult"* @"System.IAsyncResult BabylonGlut.Program+TwoDimDelegate.BeginInvoke(Int32, Int32, System.AsyncCallback, System.Object)"(%"BabylonGlut.Program+TwoDimDelegate"* %this, i32 %x, i32 %y, %"System.AsyncCallback"* %callback, %"System.Object"* %object) #47 {
    ret %"System.IAsyncResult"* undef
}


define void @"Void BabylonGlut.Program+TwoDimDelegate.EndInvoke(System.IAsyncResult)"(%"BabylonGlut.Program+TwoDimDelegate"* %this, %"System.IAsyncResult"* %result) #48 {
    ret void
}


define void @"Void BabylonGlut.Program+MouseDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+MouseDelegate"* %this, %"System.Object"* %object, %"System.IntPtr"* byval align 4 %.method) #49 {
    %.this = alloca %"BabylonGlut.Program+MouseDelegate"*, align 4
    store %"BabylonGlut.Program+MouseDelegate"* %this, %"BabylonGlut.Program+MouseDelegate"** %.this, align 4
    %.object = alloca %"System.Object"*, align 4
    store %"System.Object"* %object, %"System.Object"** %.object, align 4
    %.r1 = load %"BabylonGlut.Program+MouseDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+MouseDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.object, align 4
    store %"System.Object"* %.r3, %"System.Object"** %.r2
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+MouseDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    
    %.r5 = bitcast %"System.IntPtr"* %.r4 to i8*
    %.r6 = bitcast %"System.IntPtr"* %.method to i8*
    call void @llvm.memcpy.p0i8.p0i8.i32(i8* %.r5, i8* %.r6, i32 8, i32 4, i1 false)
    
    ret void
}

define void @"Void BabylonGlut.Program+MouseDelegate.Invoke(Int32, Int32, Int32, Int32)"(%"BabylonGlut.Program+MouseDelegate"* %this, i32 %button, i32 %state, i32 %x, i32 %y) #50 {
    %.this = alloca %"BabylonGlut.Program+MouseDelegate"*, align 4
    store %"BabylonGlut.Program+MouseDelegate"* %this, %"BabylonGlut.Program+MouseDelegate"** %.this, align 4
    %.button = alloca i32, align 4
    store i32 %button, i32* %.button, align 4
    %.state = alloca i32, align 4
    store i32 %state, i32* %.state, align 4
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    %.r1 = load %"BabylonGlut.Program+MouseDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+MouseDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.r2, align 4
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+MouseDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    %.r5 = getelementptr inbounds %"System.IntPtr"* %.r4, i32 0, i32 1
    %.r6 = load i8** %.r5, align 4
    %.r7 = icmp ne %"System.Object"* %.r3, null
    br i1 %.r7, label %normal, label %static
normal:
    %.r8 = bitcast i8* %.r6 to void (%"System.Object"*, i32, i32, i32, i32)*
    %.r9 = load i32* %.button, align 4
    %.r10 = load i32* %.state, align 4
    %.r11 = load i32* %.x, align 4
    %.r12 = load i32* %.y, align 4
    call void %.r8(%"System.Object"* %.r3, i32 %.r9, i32 %.r10, i32 %.r11, i32 %.r12)
    
    
    ret void 
static:
    %.r13 = bitcast i8* %.r6 to void (i32, i32, i32, i32)*
    %.r14 = load i32* %.button, align 4
    %.r15 = load i32* %.state, align 4
    %.r16 = load i32* %.x, align 4
    %.r17 = load i32* %.y, align 4
    call void %.r13(i32 %.r14, i32 %.r15, i32 %.r16, i32 %.r17)
    
    
    ret void 
}


define %"System.IAsyncResult"* @"System.IAsyncResult BabylonGlut.Program+MouseDelegate.BeginInvoke(Int32, Int32, Int32, Int32, System.AsyncCallback, System.Object)"(%"BabylonGlut.Program+MouseDelegate"* %this, i32 %button, i32 %state, i32 %x, i32 %y, %"System.AsyncCallback"* %callback, %"System.Object"* %object) #51 {
    ret %"System.IAsyncResult"* undef
}


define void @"Void BabylonGlut.Program+MouseDelegate.EndInvoke(System.IAsyncResult)"(%"BabylonGlut.Program+MouseDelegate"* %this, %"System.IAsyncResult"* %result) #52 {
    ret void
}


define void @"Void BabylonGlut.Program+KeyDelegate..ctor(System.Object, System.IntPtr)"(%"BabylonGlut.Program+KeyDelegate"* %this, %"System.Object"* %object, %"System.IntPtr"* byval align 4 %.method) #53 {
    %.this = alloca %"BabylonGlut.Program+KeyDelegate"*, align 4
    store %"BabylonGlut.Program+KeyDelegate"* %this, %"BabylonGlut.Program+KeyDelegate"** %.this, align 4
    %.object = alloca %"System.Object"*, align 4
    store %"System.Object"* %object, %"System.Object"** %.object, align 4
    %.r1 = load %"BabylonGlut.Program+KeyDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+KeyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.object, align 4
    store %"System.Object"* %.r3, %"System.Object"** %.r2
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+KeyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    
    %.r5 = bitcast %"System.IntPtr"* %.r4 to i8*
    %.r6 = bitcast %"System.IntPtr"* %.method to i8*
    call void @llvm.memcpy.p0i8.p0i8.i32(i8* %.r5, i8* %.r6, i32 8, i32 4, i1 false)
    
    ret void
}

define void @"Void BabylonGlut.Program+KeyDelegate.Invoke(Byte, Int32, Int32)"(%"BabylonGlut.Program+KeyDelegate"* %this, i8 %key, i32 %x, i32 %y) #54 {
    %.this = alloca %"BabylonGlut.Program+KeyDelegate"*, align 4
    store %"BabylonGlut.Program+KeyDelegate"* %this, %"BabylonGlut.Program+KeyDelegate"** %.this, align 4
    %.key = alloca i8, align 4
    store i8 %key, i8* %.key, align 4
    %.x = alloca i32, align 4
    store i32 %x, i32* %.x, align 4
    %.y = alloca i32, align 4
    store i32 %y, i32* %.y, align 4
    %.r1 = load %"BabylonGlut.Program+KeyDelegate"** %.this, align 4
    %.r2 = getelementptr inbounds %"BabylonGlut.Program+KeyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 1
    %.r3 = load %"System.Object"** %.r2, align 4
    %.r4 = getelementptr inbounds %"BabylonGlut.Program+KeyDelegate"* %.r1, i32 0, i32 0, i32 0, i32 2
    %.r5 = getelementptr inbounds %"System.IntPtr"* %.r4, i32 0, i32 1
    %.r6 = load i8** %.r5, align 4
    %.r7 = icmp ne %"System.Object"* %.r3, null
    br i1 %.r7, label %normal, label %static
normal:
    %.r8 = bitcast i8* %.r6 to void (%"System.Object"*, i8, i32, i32)*
    %.r9 = load i8* %.key, align 4
    %.r10 = load i32* %.x, align 4
    %.r11 = load i32* %.y, align 4
    call void %.r8(%"System.Object"* %.r3, i8 %.r9, i32 %.r10, i32 %.r11)
    
    
    ret void 
static:
    %.r12 = bitcast i8* %.r6 to void (i8, i32, i32)*
    %.r13 = load i8* %.key, align 4
    %.r14 = load i32* %.x, align 4
    %.r15 = load i32* %.y, align 4
    call void %.r12(i8 %.r13, i32 %.r14, i32 %.r15)
    
    
    ret void 
}


define %"System.IAsyncResult"* @"System.IAsyncResult BabylonGlut.Program+KeyDelegate.BeginInvoke(Byte, Int32, Int32, System.AsyncCallback, System.Object)"(%"BabylonGlut.Program+KeyDelegate"* %this, i8 %key, i32 %x, i32 %y, %"System.AsyncCallback"* %callback, %"System.Object"* %object) #55 {
    ret %"System.IAsyncResult"* undef
}


define void @"Void BabylonGlut.Program+KeyDelegate.EndInvoke(System.IAsyncResult)"(%"BabylonGlut.Program+KeyDelegate"* %this, %"System.IAsyncResult"* %result) #56 {
    ret void
}


define i32 @main() #57 {
    call void @"Void BabylonGlut.Program.Main(System.String[])"(%"System.String"** null);
    ret i32 0
}

define internal void @_GLOBAL_CTORS_EXECUTE_() {
    ret void
}

@"System.Object Info" = external global { i8*, i8* }
@"System.MulticastDelegate Info" = external global { i8*, i8*, i8* }

%"System.Int32" = type opaque
%"System.String" = type opaque
%"System.Boolean" = type opaque
%"System.Void" = type opaque
%"System.IAsyncResult" = type opaque
%"System.AsyncCallback" = type opaque
%"System.Byte" = type opaque
%"System.Char" = type opaque
%"System.Console" = type opaque

declare %"System.String"* @"System.String System.Object.ToString()"(%"System.Object"* %this)
declare i1 @"Boolean System.Object.Equals(System.Object)"(%"System.Object"* %this, %"System.Object"* %obj)
declare i32 @"Int32 System.Object.GetHashCode()"(%"System.Object"* %this)
declare void @"Void System.Object.Finalize()"(%"System.Object"* %this)
declare i1 @"Boolean System.Delegate.Equals(System.Object)"(%"System.Delegate"* %this, %"System.Object"* %obj)
declare void @"Void System.Object..ctor()"(%"System.Object"* %this)
declare void @"Void System.String..init()"(%"System.String"* %this)
declare void @"Void System.String..ctor(Char[])"(%"System.String"* %this, i16* %value)
declare void @"Void System.Console.WriteLine(System.String)"(%"System.String"* %value)
declare void @"Void System.IntPtr..init()"(%"System.IntPtr"* %this)
declare void @"Void System.IntPtr..ctor(Void*)"(%"System.IntPtr"* %this, i8* %value)
declare i8* @"Void* System.Delegate.ToPointer()"(%"System.Delegate"* %this)
