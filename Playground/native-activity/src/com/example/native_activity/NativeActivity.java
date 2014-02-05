package com.example.native_activity;

/**
 * This class loads the Java Native Interface (JNI)
 * library, 'libnative_activity.so', and provides access to the
 * exposed C functions.
 * The library is packaged and installed with the application.
 * See the C file, /jni/NativeActivity.c file for the
 * implementations of the native methods. 
 * 
 * For more information on JNI, see: http://java.sun.com/docs/books/jni/
 */
public class NativeActivity
{
	/**
	 * An example native method.  See the library function,
	 * <code>Java_com_example_native_activity_NativeActivity_nativeactivityNative</code>
	 * for the implementation.
	 */
	static public native void nativeactivityNative();

	/* This is the static constructor used to load the
	 * 'native_activity' library when the class is
	 * loaded.
	 */
	static {
		System.loadLibrary("native_activity");
	}
}
