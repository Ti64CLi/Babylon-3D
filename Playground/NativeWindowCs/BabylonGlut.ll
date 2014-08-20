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
define void @"Void BabylonGlut.Program..init()"(%"BabylonGlut.Program"* %this) #0 {
    %.this = alloca %"BabylonGlut.Program"*, align 4
    store %"BabylonGlut.Program"* %this, %"BabylonGlut.Program"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program"** %.this, align 4
    ; set virtual table
    %.r2 = bitcast %"BabylonGlut.Program"* %.r1 to i8***
    store i8** getelementptr inbounds ([6 x i8*]* @"BabylonGlut.Program Virtual Table", i64 0, i64 2), i8*** %.r2
    ret void
}



define void @"Void BabylonGlut.Program..ctor()"(%"BabylonGlut.Program"* %this) #1 {
    %.this = alloca %"BabylonGlut.Program"*, align 4
    store %"BabylonGlut.Program"* %this, %"BabylonGlut.Program"** %.this, align 4
    %.r1 = load %"BabylonGlut.Program"** %.this, align 4
    ; Cast of 'This' parameter
    %.r2 = bitcast %"BabylonGlut.Program"* %.r1 to %"System.Object"*
    call void @"Void System.Object..ctor()"(%"System.Object"* %.r2)
    ret void
}

declare void @glutInit(...) #2

declare void @glutInitWindowSize(...) #3

declare void @glutInitDisplayMode(...) #4

declare void @glutCreateWindow(...) #5

declare void @glutMainLoop(...) #6

define void @"Void BabylonGlut.Program.Main(System.String[])"(%"System.String"** %args) #7 {
    %local0 = alloca i32, align 4
    %local1 = alloca i8**, align 4
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
    call void @"Void System.String..ctor(Char[])"(%"System.String"* %.r2, i16* bitcast ([10 x i16]* getelementptr inbounds ({ i32, [10 x i16] }* @.s1, i32 0, i32 1) to i16*))
    call void @"Void System.Console.WriteLine(System.String)"(%"System.String"* %.r2)
    store i32 0, i32* %local0, align 4
    ; New array
    %.r3 = mul i32 0, 4
    %.r4 = add i32 4, %.r3
    %.r5 = call i8* @malloc(i32 %.r4)
    %.r6 = bitcast i8* %.r5 to i32*
    store i32 0, i32* %.r6
    %.r7 = getelementptr i32* %.r6, i32 1
    %.r8 = bitcast i32* %.r7 to i8**
    ; end of new array
    store i8** %.r8, i8*** %local1, align 4
    %.r9 = load i8*** %local1, align 4
    call void (...)* @glutInit(i32* %local0, i8** %.r9)
    call void (...)* @glutInitWindowSize(i32 400, i32 640)
    call void (...)* @glutInitDisplayMode(i32 18)
    call void (...)* @glutCreateWindow(i8* null)
    call void (...)* @glutMainLoop()
    ret void
}

@.s1 = private unnamed_addr constant { i32, [10 x i16] } { i32 9, [10 x i16] [i16 83, i16 116, i16 97, i16 114, i16 116, i16 105, i16 110, i16 103, i16 46, i16 0] }, align 2

define i32 @main() #8 {
    call void @"Void BabylonGlut.Program.Main(System.String[])"(%"System.String"** null);
    ret i32 0
}

define internal void @_GLOBAL_CTORS_EXECUTE_() {
    ret void
}

@"System.Object Info" = external global { i8*, i8* }

%"System.String" = type opaque
%"System.Boolean" = type opaque
%"System.Int32" = type opaque
%"System.Void" = type opaque
%"System.Char" = type opaque
%"System.Console" = type opaque
%"System.Byte" = type opaque

declare %"System.String"* @"System.String System.Object.ToString()"(%"System.Object"* %this)
declare i1 @"Boolean System.Object.Equals(System.Object)"(%"System.Object"* %this, %"System.Object"* %obj)
declare i32 @"Int32 System.Object.GetHashCode()"(%"System.Object"* %this)
declare void @"Void System.Object.Finalize()"(%"System.Object"* %this)
declare void @"Void System.Object..ctor()"(%"System.Object"* %this)
declare void @"Void System.String..init()"(%"System.String"* %this)
declare void @"Void System.String..ctor(Char[])"(%"System.String"* %this, i16* %value)
declare void @"Void System.Console.WriteLine(System.String)"(%"System.String"* %value)
