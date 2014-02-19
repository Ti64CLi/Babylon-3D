// Copyright (c) 2013 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

#include <GLES2/gl2.h>
#include <math.h>
#include <stddef.h>
#include <stdint.h>
#include <stdio.h>
#include <string.h>

#include "ppapi/cpp/graphics_3d.h"
#include "ppapi/cpp/instance.h"
#include "ppapi/cpp/input_event.h"
#include "ppapi/cpp/module.h"
#include "ppapi/cpp/var.h"
#include "ppapi/cpp/var_array.h"
#include "ppapi/lib/gl/gles2/gl2ext_ppapi.h"
#include "ppapi/utility/completion_callback_factory.h"

#include "decls.h"
#include "defs.h"

#include "iengine.h"
#include "canvas.h"
#include "engine.h"
#include "arcRotateCamera.h"
#include "pointLight.h"
#include "strings.h"

#ifdef WIN32
#undef PostMessage
// Allow 'this' in initializer list
#pragma warning(disable : 4355)
#endif

void logmsg(const char* pMsg){
	fprintf(stdout,"logmsg: %s\n",pMsg);
}
void errormsg(const char* pMsg){
	fprintf(stderr,"logerr: %s\n",pMsg);
}

namespace {
}  // namespace

using namespace std;
using namespace Babylon;

namespace Babylon {

	class Main {

		// engine
		Canvas::Ptr canvas;
		Engine::Ptr engine;
		Scene::Ptr scene;

	public:

		Main()
		{
		}

		void init(int32_t width, int32_t height, function_t<void (const char*)> fileLoader)
		{
			// engine
			this->canvas = make_shared<Canvas>(width, height, fileLoader);
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

		void onImageLoaded(string name, int width, int height, void* pixels)
		{
			this->canvas->raiseEvent_OnImageLoaded(name, width, height, pixels);
		}
	};

} // namespace

class Graphics3DInstance : public pp::Instance {

	Main main;

public:
	explicit Graphics3DInstance(PP_Instance instance)
		: pp::Instance(instance),
		callback_factory_(this),
		width_(0),
		height_(0)
	{
		RequestInputEvents(PP_INPUTEVENT_CLASS_MOUSE | PP_INPUTEVENT_CLASS_WHEEL | PP_INPUTEVENT_CLASS_TOUCH);
		RequestFilteringInputEvents(PP_INPUTEVENT_CLASS_KEYBOARD);
	}

	virtual bool Init(uint32_t argc, const char* argn[], const char* argv[]) {
		return true;
	}

	virtual void DidChangeView(const pp::View& view) {
		int32_t new_width = view.GetRect().width();
		int32_t new_height = view.GetRect().height();

		if (context_.is_null()) {
			if (!InitGL(new_width, new_height)) {
				// failed.
				return;
			}

			// init here
			main.init(new_width, new_height, [=](const char* file) {
				PostMessage(string("loading image:") + file);
				pp::VarDictionary message;
				message.Set("message", "request_textures");
				pp::VarArray names;
				names.Set(0, file);
				message.Set("names", names);
				PostMessage(message);
			});
			main.loadSceneTutorial4();

			MainLoop(0);
		} else {
			// Resize the buffers to the new size of the module.
			int32_t result = context_.ResizeBuffers(new_width, new_height);
			if (result < 0) {
				fprintf(stderr,
					"Unable to resize buffers to %d x %d!\n",
					new_width,
					new_height);
				return;
			}
		}

		width_ = new_width;
		height_ = new_height;
		glViewport(0, 0, width_, height_);
	}

	virtual bool HandleInputEvent(const pp::InputEvent& event) {

		switch (event.GetType()) {
		case PP_INPUTEVENT_TYPE_MOUSEDOWN:
		case PP_INPUTEVENT_TYPE_MOUSEUP:
		case PP_INPUTEVENT_TYPE_MOUSEMOVE: {
			pp::MouseInputEvent mouse_event(event);
			if (PP_INPUTEVENT_MOUSEBUTTON_LEFT == mouse_event.GetButton()) {
				main.onMotion(mouse_event.GetPosition().x(), mouse_event.GetPosition().y());
			}
										   }
		}

		return true;
	}

	virtual void HandleMessage(const pp::Var& message) {
		// A bool message sets whether the cube is animating or not.

		if (message.is_dictionary()) {
			pp::VarDictionary dictionary(message);
			string message = dictionary.Get("message").AsString();
			if (message == "texture") {
				string name = dictionary.Get("name").AsString();
				int width = dictionary.Get("width").AsInt();
				int height = dictionary.Get("height").AsInt();
				pp::VarArrayBuffer array_buffer(dictionary.Get("data"));
				if (!name.empty() && !array_buffer.is_null()) {
					if (width > 0 && height > 0) {
						PostMessage(string("loaded image:") + name);
						uint32_t* pixels = static_cast<uint32_t*>(array_buffer.Map());
						main.onImageLoaded(name, width, height, pixels);
						array_buffer.Unmap();
					}
				}
			}
		}
	}

private:
	bool InitGL(int32_t new_width, int32_t new_height) {
		if (!glInitializePPAPI(pp::Module::Get()->get_browser_interface())) {
			fprintf(stderr, "Unable to initialize GL PPAPI!\n");
			return false;
		}

		const int32_t attrib_list[] = {
			PP_GRAPHICS3DATTRIB_ALPHA_SIZE, 8,
			PP_GRAPHICS3DATTRIB_DEPTH_SIZE, 24,
			PP_GRAPHICS3DATTRIB_WIDTH, new_width,
			PP_GRAPHICS3DATTRIB_HEIGHT, new_height,
			PP_GRAPHICS3DATTRIB_NONE
		};

		context_ = pp::Graphics3D(this, attrib_list);
		if (!BindGraphics(context_)) {
			fprintf(stderr, "Unable to bind 3d context!\n");
			context_ = pp::Graphics3D();
			glSetCurrentContextPPAPI(0);
			return false;
		}

		glSetCurrentContextPPAPI(context_.pp_resource());

		return true;
	}

	void Render() {

		/*
		glClearColor(0.5, 0.5, 0.5, 1);
		glClearDepthf(1.0f);
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		glEnable(GL_DEPTH_TEST);
		*/

		// render here
		main.render();
	}

	void MainLoop(int32_t) {
		Render();
		context_.SwapBuffers(callback_factory_.NewCallback(&Graphics3DInstance::MainLoop));
	}

	pp::CompletionCallbackFactory<Graphics3DInstance> callback_factory_;
	pp::Graphics3D context_;
	int32_t width_;
	int32_t height_;
};

class Graphics3DModule : public pp::Module {
public:
	Graphics3DModule() : pp::Module() {}
	virtual ~Graphics3DModule() {}

	virtual pp::Instance* CreateInstance(PP_Instance instance) {
		return new Graphics3DInstance(instance);
	}
};

namespace pp {
	Module* CreateModule() { return new Graphics3DModule(); }
}  // namespace pp
