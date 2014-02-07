/*
 * Copyright (C) 2010 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

//BEGIN_INCLUDE(all)
#include <jni.h>
#include <errno.h>

#include <EGL/egl.h>
#include <GLES2/gl2.h>
#include <GLES2/gl2ext.h>

#include <android/sensor.h>
#include <android/log.h>
#include "android_native_app_glue.h"

#include "iengine.h"
#include "canvas.h"
#include "engine.h"
#include "arcRotateCamera.h"
#include "pointLight.h"
#include "strings.h"

#define LOGI(...) ((void)__android_log_print(ANDROID_LOG_INFO, "native-activity", __VA_ARGS__))
#define LOGW(...) ((void)__android_log_print(ANDROID_LOG_WARN, "native-activity", __VA_ARGS__))

using namespace std;
using namespace Babylon;

class Main {

	// engine
	Canvas::Ptr canvas;
	Engine::Ptr engine;
	Scene::Ptr scene;

public:

	Main()
	{
	}

	void init(int32_t width, int32_t height)
	{
		// engine
		this->canvas = make_shared<Canvas>(width, height);
		this->engine = Engine::New(dynamic_pointer_cast<ICanvas>(this->canvas), true);

		// for testing loading shaders manually
		Effect::ShadersStore["defaultVertexShader"] = defaultVertexShader; 
		Effect::ShadersStore["defaultPixelShader"] = defaultPixelShader;
	}

	void loadSceneTutorial1() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 1, 0.8, 10, make_shared<Vector3>(0, 0, 0), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(0, 0, 10), scene);
		auto origin = Mesh::CreateSphere("origin", 10, 1.0, scene);

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void loadSceneTutorial2() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 0, 0.8, 100, make_shared<Vector3>(0, 0, 0), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(10, 10, -30), scene);

		auto box = Mesh::CreateBox("Box", 6.0, scene);
		auto sphere = Mesh::CreateSphere("Sphere", 10.0, 10.0, scene);	
		auto plan = Mesh::CreatePlane("Plane", 50.0, scene);

		// move object
		box->position = make_shared<Vector3>(-10,0,0);
		sphere->position = make_shared<Vector3>(0,10,0);
		plan->position->z = 10;

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void loadSceneTutorial3() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 0, 0.8, 100, Vector3::Zero(), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(0, 100, 100), scene);

		auto box1 = Mesh::CreateBox("Box1", 6.0, scene);
		auto box2 = Mesh::CreateBox("Box2", 6.0, scene);
		auto box3 = Mesh::CreateBox("Box3", 6.0, scene);

		//Positioning the boxes
		box1->position = make_shared<Vector3>(-20, 0, 0);
		box2->position->x = -10;
		box3->position->x = 0;

		//Rotate the box around the x axis
		box1->rotation->x = 3.14/4;

		//Rotate the box around the y axis
		box2->rotation->y = 3.14/6;

		//Scaling of 2x on the x axis
		box3->scaling->x = 2;

		//Positioning the box3 relative to the box1
		box3->parent = dynamic_pointer_cast<Node>(box1);
		box3->position->z = -10;

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void loadSceneTutorial4() {
		// scene
		this->scene = Scene::New(engine);

		// Creating a camera looking to the zero point (0,0,0), a light, and a sphere of size 1
		auto camera = ArcRotateCamera::New("Camera", 0, 0.8, 100, Vector3::Zero(), scene);
		auto light0 = PointLight::New("Omni", make_shared<Vector3>(20, 20, 100), scene);

		//Creation of 6 spheres
		auto sphere1 = Mesh::CreateSphere("Sphere1", 10.0, 6.0, scene);
		auto sphere2 = Mesh::CreateSphere("Sphere2", 2.0, 7.0, scene);//Only two segments
		auto sphere3 = Mesh::CreateSphere("Sphere3", 10.0, 9.0, scene);
		auto sphere4 = Mesh::CreateSphere("Sphere4", 10.0, 9.0, scene);
		auto sphere5 = Mesh::CreateSphere("Sphere5", 10.0, 9.0, scene);
		auto sphere6 = Mesh::CreateSphere("Sphere6", 10.0, 9.0, scene);

		//Positioning spheres
		sphere1->position->x = 40;
		sphere2->position->x = 30;
		sphere3->position->x = 10;
		sphere4->position->x = 0;
		sphere5->position->x = -20;
		sphere6->position->x = -30;

		//Creation of a plane
		auto plan = Mesh::CreatePlane("plan", 120, scene);
		plan->position->z = -10;
		plan->rotation->y = 3.14;

		//Creation of a material in wireFrame
		auto materialSphere1 = StandardMaterial::New("texture1", scene);
		materialSphere1->wireframe = true;

		//Creation of a red material with alpha
		auto materialSphere2 = StandardMaterial::New("texture2", scene);
		materialSphere2->diffuseColor = make_shared<Color3>(1, 0, 0); //Red
		materialSphere2->alpha = 0.3;


		//Creation of a material with an image
		auto materialSphere3 = StandardMaterial::New("texture3", scene);
		materialSphere3->diffuseTexture = Texture::New("text.jpg", scene);

		//Creation of a material, with translated texture
		auto materialSphere4 = StandardMaterial::New("texture4", scene);
		materialSphere4->diffuseTexture = Texture::New("text.jpg", scene);
		materialSphere4->diffuseTexture->vOffset = 0.1;//Offset of 10% vertical
		materialSphere4->diffuseTexture->uOffset = 0.4;//Offset of 40% horizontal

		//Creation of a material with alpha texture
		auto materialSphere5 = StandardMaterial::New("texture5", scene);
		materialSphere5->diffuseTexture = Texture::New("Planet.png", scene);//Planet
		materialSphere5->diffuseTexture->hasAlpha = true;//Have an alpha

		//Creation of a material and allways show all the faces
		auto materialSphere6 = StandardMaterial::New("texture6", scene);
		materialSphere6->diffuseTexture =  Texture::New("Planet.png", scene);//Planet
		materialSphere6->diffuseTexture->hasAlpha = true;//Have an alpha
		materialSphere6->backFaceCulling = false;//Allways show all the faces of the element

		//Creation of a repeated textured material
		auto materialPlan = StandardMaterial::New("texturePlane", scene);
		materialPlan->diffuseTexture =  Texture::New("grass_texture.jpg", scene);//Wood effect
		materialPlan->diffuseTexture->uScale = 5.0;//Repeat 5 times on the Vertical Axes
		materialPlan->diffuseTexture->vScale = 5.0;//Repeat 5 times on the Horizontal Axes
		materialPlan->backFaceCulling = false;//Allways show the front and the back of an element

		//Applying the materials to the mesh
		sphere1->material = materialSphere1;
		sphere2->material = materialSphere2;

		sphere3->material = materialSphere3;
		sphere4->material = materialSphere4;

		sphere5->material = materialSphere5;
		sphere6->material = materialSphere6;

		plan->material = materialPlan;

		// Attach the camera to the scene
		scene->activeCamera->attachControl(canvas);
	}

	void render() {
		this->scene->render();
	}

	void onMotion(int x, int y)
	{
		this->canvas->raiseEvent_Move(x, y);
	}
};

//Main _main;

/**
 * Our saved state data.
 */
struct saved_state {
    float angle;
    int32_t x;
    int32_t y;
};

/**
 * Shared state for our app.
 */
struct engine {
    struct android_app* app;

    ASensorManager* sensorManager;
    const ASensor* accelerometerSensor;
    ASensorEventQueue* sensorEventQueue;

    int animating;
    EGLDisplay display;
    EGLSurface surface;
    EGLContext context;
    int32_t width;
    int32_t height;
    struct saved_state state;

	shared_ptr<Main> main;
};

/**
 * Initialize an EGL context for the current display.
 */
static int engine_init_display(struct engine* engine) {
    // initialize OpenGL ES and EGL

    /*
     * Here specify the attributes of the desired configuration.
     * Below, we select an EGLConfig with at least 8 bits per color
     * component compatible with on-screen windows
     */
    const EGLint attribs[] = {
            EGL_SURFACE_TYPE, EGL_WINDOW_BIT,
            EGL_BLUE_SIZE, 8,
            EGL_GREEN_SIZE, 8,
            EGL_RED_SIZE, 8,
            EGL_NONE
    };
    EGLint w, h, dummy, format;
    EGLint numConfigs;
    EGLConfig config;
    EGLSurface surface;
    EGLContext context;

    EGLDisplay display = eglGetDisplay(EGL_DEFAULT_DISPLAY);

    eglInitialize(display, 0, 0);

    /* Here, the application chooses the configuration it desires. In this
     * sample, we have a very simplified selection process, where we pick
     * the first EGLConfig that matches our criteria */
    eglChooseConfig(display, attribs, &config, 1, &numConfigs);

    /* EGL_NATIVE_VISUAL_ID is an attribute of the EGLConfig that is
     * guaranteed to be accepted by ANativeWindow_setBuffersGeometry().
     * As soon as we picked a EGLConfig, we can safely reconfigure the
     * ANativeWindow buffers to match, using EGL_NATIVE_VISUAL_ID. */
    eglGetConfigAttrib(display, config, EGL_NATIVE_VISUAL_ID, &format);

    ANativeWindow_setBuffersGeometry(engine->app->window, 0, 0, format);

    surface = eglCreateWindowSurface(display, config, engine->app->window, NULL);

	int attrib_list[3] = {EGL_CONTEXT_CLIENT_VERSION, 2, EGL_NONE };
    context = eglCreateContext(display, config, EGL_NO_CONTEXT, attrib_list);

    if (eglMakeCurrent(display, surface, surface, context) == EGL_FALSE) {
        LOGW("Unable to eglMakeCurrent");
        return -1;
    }

    eglQuerySurface(display, surface, EGL_WIDTH, &w);
    eglQuerySurface(display, surface, EGL_HEIGHT, &h);

    engine->display = display;
    engine->context = context;
    engine->surface = surface;
    engine->width = w;
    engine->height = h;
    engine->state.angle = 0;

    // Initialize GL state.
    ////glEnable(GL_DEPTH_TEST);
    ////glEnable(GL_CULL_FACE);
    ////glCullFace(GL_BACK);
    ////glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

	engine->main->init(engine->width, engine->height);
	engine->main->loadSceneTutorial1();

    return 0;
}

/**
 * Just the current frame in the display.
 */
static void engine_draw_frame(struct engine* engine) {
    if (engine->display == NULL) {
        // No display.
        return;
    }

    // Just fill the screen with a color.
    ////glClearColor(((float)engine->state.x)/engine->width, engine->state.angle,
    ////        ((float)engine->state.y)/engine->height, 1);
    ////glClear(GL_COLOR_BUFFER_BIT);

    engine->main->render();

    eglSwapBuffers(engine->display, engine->surface);
}

/**
 * Tear down the EGL context currently associated with the display.
 */
static void engine_term_display(struct engine* engine) {
    if (engine->display != EGL_NO_DISPLAY) {
        eglMakeCurrent(engine->display, EGL_NO_SURFACE, EGL_NO_SURFACE, EGL_NO_CONTEXT);
        if (engine->context != EGL_NO_CONTEXT) {
            eglDestroyContext(engine->display, engine->context);
        }
        if (engine->surface != EGL_NO_SURFACE) {
            eglDestroySurface(engine->display, engine->surface);
        }
        eglTerminate(engine->display);
    }
    engine->animating = 0;
    engine->display = EGL_NO_DISPLAY;
    engine->context = EGL_NO_CONTEXT;
    engine->surface = EGL_NO_SURFACE;
}

/**
 * Process the next input event.
 */
static int32_t engine_handle_input(struct android_app* app, AInputEvent* event) {
    struct engine* engine = (struct engine*)app->userData;
    if (AInputEvent_getType(event) == AINPUT_EVENT_TYPE_MOTION) {
        engine->animating = 1;
        engine->state.x = AMotionEvent_getX(event, 0);
        engine->state.y = AMotionEvent_getY(event, 0);

		engine->main->onMotion(engine->state.x, engine->state.y);

        return 1;
    }
    return 0;
}

/**
 * Process the next main command.
 */
static void engine_handle_cmd(struct android_app* app, int32_t cmd) {
    struct engine* engine = (struct engine*)app->userData;
    switch (cmd) {
        case APP_CMD_SAVE_STATE:
            // The system has asked us to save our current state.  Do so.
            engine->app->savedState = malloc(sizeof(struct saved_state));
            *((struct saved_state*)engine->app->savedState) = engine->state;
            engine->app->savedStateSize = sizeof(struct saved_state);
            break;
        case APP_CMD_INIT_WINDOW:
            // The window is being shown, get it ready.
            if (engine->app->window != NULL) {
                engine_init_display(engine);
                engine_draw_frame(engine);
            }
            break;
        case APP_CMD_TERM_WINDOW:
            // The window is being hidden or closed, clean it up.
            engine_term_display(engine);
            break;
        case APP_CMD_GAINED_FOCUS:
            // When our app gains focus, we start monitoring the accelerometer.
            if (engine->accelerometerSensor != NULL) {
                ASensorEventQueue_enableSensor(engine->sensorEventQueue,
                        engine->accelerometerSensor);
                // We'd like to get 60 events per second (in us).
                ASensorEventQueue_setEventRate(engine->sensorEventQueue,
                        engine->accelerometerSensor, (1000L/60)*1000);
            }
            break;
        case APP_CMD_LOST_FOCUS:
            // When our app loses focus, we stop monitoring the accelerometer.
            // This is to avoid consuming battery while not being used.
            if (engine->accelerometerSensor != NULL) {
                ASensorEventQueue_disableSensor(engine->sensorEventQueue,
                        engine->accelerometerSensor);
            }
            // Also stop animating.
            engine->animating = 0;
            engine_draw_frame(engine);
            break;
    }
}

/**
 * This is the main entry point of a native application that is using
 * android_native_app_glue.  It runs in its own thread, with its own
 * event loop for receiving input events and doing other things.
 */
void android_main(struct android_app* state) {
    struct engine engine;

    // Make sure glue isn't stripped.
    app_dummy();

    memset(&engine, 0, sizeof(engine));
    state->userData = &engine;
    state->onAppCmd = engine_handle_cmd;
    state->onInputEvent = engine_handle_input;
    engine.app = state;

    // Prepare to monitor accelerometer
    engine.sensorManager = ASensorManager_getInstance();
    engine.accelerometerSensor = ASensorManager_getDefaultSensor(engine.sensorManager,
            ASENSOR_TYPE_ACCELEROMETER);
    engine.sensorEventQueue = ASensorManager_createEventQueue(engine.sensorManager,
            state->looper, LOOPER_ID_USER, NULL, NULL);

    if (state->savedState != NULL) {
        // We are starting with a previous saved state; restore from it.
        engine.state = *(struct saved_state*)state->savedState;
    }

	engine.main = make_shared<Main>();

    // loop waiting for stuff to do.

    while (1) {
        // Read all pending events.
        int ident;
        int events;
        struct android_poll_source* source;

        // If not animating, we will block forever waiting for events.
        // If animating, we loop until all events are read, then continue
        // to draw the next frame of animation.
        while ((ident=ALooper_pollAll(engine.animating ? 0 : -1, NULL, &events,
                (void**)&source)) >= 0) {

            // Process this event.
            if (source != NULL) {
                source->process(state, source);
            }

            // If a sensor has data, process it now.
            if (ident == LOOPER_ID_USER) {
                if (engine.accelerometerSensor != NULL) {
                    ASensorEvent event;
                    while (ASensorEventQueue_getEvents(engine.sensorEventQueue,
                            &event, 1) > 0) {
                        LOGI("accelerometer: x=%f y=%f z=%f",
                                event.acceleration.x, event.acceleration.y,
                                event.acceleration.z);
                    }
                }
            }

            // Check if we are exiting.
            if (state->destroyRequested != 0) {
                engine_term_display(&engine);
                return;
            }
        }

        if (engine.animating) {
            // Done with events; draw next animation frame.
            engine.state.angle += .01f;
            if (engine.state.angle > 1) {
                engine.state.angle = 0;
            }

            // Drawing is throttled to the screen update rate, so there
            // is no need to do timing here.
            engine_draw_frame(&engine);
        }
    }
}
//END_INCLUDE(all)
