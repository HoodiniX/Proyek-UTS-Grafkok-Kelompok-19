using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Test
{

    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        Asset2d[] _object = new Asset2d[6];
        Asset3d[] _object3d = new Asset3d[30];
        double _time;
        float degr = 0;
        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 1f;

        /*float[] vertices =
        {
            //x    //y    //z   // Colors
            -0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f, // Vertex 1 Merah
            0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f, // Vertex 2 Hijau
            0.0f, 0.5f, 0.0f,   0.0f, 0.0f, 1.0f // Vertex 3 Biru*//*
        };*/

        /* float[] vertices =
         {
             0.5f, 0.5f, 0.0f, // Top Right
             0.5f, -0.5f, 0.0f, // Bottom Right
             -0.5f, -0.5f, 0.0f, // Bottom Left
             -0.5f, 0.5f, 0.0f //Top Left
         };*/


        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();
            //Background Color
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            _object3d[0] = new Asset3d();
            _object3d[1] = new Asset3d();
            _object3d[2] = new Asset3d();
            _object3d[3] = new Asset3d();
            _object3d[4] = new Asset3d();
            _object3d[5] = new Asset3d();
            _object3d[6] = new Asset3d();
            _object3d[7] = new Asset3d();
            _object3d[8] = new Asset3d();
            _object3d[9] = new Asset3d();
            _object3d[10] = new Asset3d();
            _object3d[11] = new Asset3d();
            _object3d[12] = new Asset3d();
            _object3d[13] = new Asset3d();
            _object3d[14] = new Asset3d();
            _object3d[15] = new Asset3d();
            _object3d[16] = new Asset3d();
            _object3d[17] = new Asset3d();
            _object3d[18] = new Asset3d();
            _object3d[19] = new Asset3d();
            _object3d[20] = new Asset3d();
            _object3d[21] = new Asset3d();
            _object3d[22] = new Asset3d();
            _object3d[23] = new Asset3d();
            _object3d[24] = new Asset3d();
            _object3d[25] = new Asset3d();
            _object3d[26] = new Asset3d();
            _object3d[27] = new Asset3d();
            _object3d[28] = new Asset3d();
            _object3d[29] = new Asset3d();
            _camera = new Camera(new Vector3(0, 0, 1), Size.X / (float)Size.Y);

            //_object3d[0].createBoxVertices(0, 0, 0, 0.5f);
            //_object3d[0].createTrapezoidHeadVertices(-0.5f, 0, 0, 0.5f);
            //_object3d[0].createTrapezoidBodyVertices(-0.5f, 0, 0, 0.5f);
            //_object3d[0].createLongBoxVertices(-0.5f, 0, 0, 0.5f);
            //_object3d[0].createEllipsoid2(0.3f, 0.3f, 0.3f, 0.0f, 0.0f, 0.0f, 72, 24);
            _object3d[0].createWheels(0.5f, 0.2f, 0.125f, 0.0f, 0.2f, 0.0f, 72, 3);
            //_object3d[0].createEllipsoid(0.5f, 0.5f, 0.5f, -0.5f, 0.0f, 0.0f);
            //_object3d[0].createCone();
            _object3d[0].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[1].createWheels(0.5f, 0.2f, 0.125f, 0.0f, 0.2f, 0.57f, 72, 3);
            _object3d[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[2].createTrapezoidBodyVertices(0.0f, 0.5f, 0.35f, 0.4f);
            _object3d[2].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[3].createTrapezoidHeadVertices(0.0f, 0.67f, 0.35f, 0.275f);
            _object3d[3].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[4].createLongBoxVertices(0.3f, 0.65f, 0.35f, 0.11f);
            _object3d[4].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[5].createEllipsoid2(0.05f, 0.02f, 0.02f, 0.5f, 0.65f, 0.35f, 72, 24);
            _object3d[5].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[6].createFlatBoxVertices(0, 1.5f, 0, 0.5f);
            _object3d[6].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);

            _object3d[7].createLongBoxVertices(0.45f, 1.48f, 0.2f, 0.11f);
            _object3d[7].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[8].createLongBoxVertices(0.45f, 1.48f, -0.2f, 0.11f);
            _object3d[8].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[9].createLongBoxVertices(-0.45f, 1.48f, 0.2f, 0.11f);
            _object3d[9].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[10].createLongBoxVertices(-0.45f, 1.48f, -0.2f, 0.11f);
            _object3d[10].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[11].createBoxVertices(-0.63f, 1.54f, -0.25f, 0.035f);
            _object3d[11].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[12].createBoxVertices(-0.63f, 1.54f, 0.25f, 0.035f);
            _object3d[12].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[13].createBoxVertices(0.63f, 1.54f, -0.25f, 0.035f);
            _object3d[13].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[14].createBoxVertices(0.63f, 1.54f, 0.25f, 0.035f);
            _object3d[14].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[15].createEllipsoid2(0.015f, 0.015f, 0.015f, 0.63f, 1.555f, 0.25f, 72, 24);
            _object3d[15].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[16].createEllipsoid2(0.015f, 0.015f, 0.015f, 0.63f, 1.555f, -0.25f, 72, 24);
            _object3d[16].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[17].createEllipsoid2(0.015f, 0.015f, 0.015f, -0.63f, 1.555f, 0.25f, 72, 24);
            _object3d[17].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[18].createEllipsoid2(0.015f, 0.015f, 0.015f, -0.63f, 1.555f, -0.25f, 72, 24);
            _object3d[18].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[19].createFlatLongBoxVertices(0.63f, 1.56f, 0.25f, 0.05f);
            _object3d[19].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[20].createFlatLongBoxVertices(0.63f, 1.56f, -0.25f, 0.05f);
            _object3d[20].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[21].createFlatLongBoxVertices(-0.63f, 1.56f, 0.25f, 0.05f);
            _object3d[21].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[22].createFlatLongBoxVertices(-0.63f, 1.56f, -0.25f, 0.05f);
            _object3d[22].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[23].createCone(0.3f, 0.8f, 0.3f, 1.2f, 1.49f, 0.0f, 72, 3);
            _object3d[23].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[24].createTube(0.3f, 1.0f, 0.3f, 1.2f, -0.2f, 0.0f, 72, 3);
            _object3d[24].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[25].createFrontPrism(1.2f, 0.1f, 0.38f, 1.0f);
            _object3d[25].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[26].createBackPrism(1.2f, 0.1f, -0.38f, 1.0f);
            _object3d[26].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[27].createLeftPrism(0.82f, 0.1f, 0.0f, 1.0f);
            _object3d[27].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[28].createRightPrism(1.58f, 0.1f, 0.0f, 1.0f);
            _object3d[28].load(Constants.path + "shader.vert", Constants.path  + "shader.frag", Size.X, Size.Y);

            _object3d[7].rotate(new OpenTK.Mathematics.Vector3(0.45f, 1.48f, 0.2f), _object3d[7]._euler[1], -15f);
            _object3d[7].rotate(new OpenTK.Mathematics.Vector3(0.45f, 1.48f, 0.2f), _object3d[7]._euler[2], 5.5f);
            _object3d[8].rotate(new OpenTK.Mathematics.Vector3(0.45f, 1.48f, -0.2f), _object3d[8]._euler[1], 15f);
            _object3d[8].rotate(new OpenTK.Mathematics.Vector3(0.45f, 1.48f, -0.2f), _object3d[8]._euler[2], 5.5f);
            _object3d[9].rotate(new OpenTK.Mathematics.Vector3(-0.45f, 1.48f, 0.2f), _object3d[9]._euler[1], 15f);
            _object3d[9].rotate(new OpenTK.Mathematics.Vector3(-0.45f, 1.48f, 0.2f), _object3d[9]._euler[2], -5.5f);
            _object3d[10].rotate(new OpenTK.Mathematics.Vector3(-0.45f, 1.48f, -0.2f), _object3d[10]._euler[1], -15f);
            _object3d[10].rotate(new OpenTK.Mathematics.Vector3(-0.45f, 1.48f, -0.2f), _object3d[10]._euler[2], -5.5f);

            _object3d[11].rotate(new OpenTK.Mathematics.Vector3(-0.63f, 1.54f, -0.25f), _object3d[11]._euler[1], -15f);
            _object3d[12].rotate(new OpenTK.Mathematics.Vector3(-0.63f, 1.54f, 0.25f), _object3d[12]._euler[1], 15f);
            _object3d[13].rotate(new OpenTK.Mathematics.Vector3(0.63f, 1.54f, -0.25f), _object3d[13]._euler[1], 15f);
            _object3d[14].rotate(new OpenTK.Mathematics.Vector3(0.63f, 1.54f, 0.25f), _object3d[14]._euler[1], -15f);

            _object3d[23].rotate(new OpenTK.Mathematics.Vector3(1.2f, -0.2f, 0.0f), _object3d[23]._euler[0], -50f);
            _object3d[24].rotate(new OpenTK.Mathematics.Vector3(1.2f, -0.2f, 0.0f), _object3d[24]._euler[0], -50f);
            _object3d[25].rotate(new OpenTK.Mathematics.Vector3(1.2f, -0.2f, 0.0f), _object3d[25]._euler[0], -50f);
            _object3d[26].rotate(new OpenTK.Mathematics.Vector3(1.2f, -0.2f, 0.0f), _object3d[26]._euler[0], -50f);
            _object3d[27].rotate(new OpenTK.Mathematics.Vector3(1.2f, -0.2f, 0.0f), _object3d[27]._euler[0], -50f);
            _object3d[28].rotate(new OpenTK.Mathematics.Vector3(1.2f, -0.2f, 0.0f), _object3d[28]._euler[0], -50f);

            /*_object[0] = new Asset2d(
                new float[]
                {
                    -0.5f, -0.5f, 0.0f,
                    -0.25f, 0.0f, 0.0f,
                    -0.0f, -0.5f, 0.0f
                },
                new uint[]
                {

                }
            );
            _object[1] = new Asset2d(
                new float[]
                {
                    0.5f, -0.5f, 0.0f,
                    0.25f, 0.0f, 0.0f,
                    0.0f, -0.5f, 0.0f
                },
                new uint[]
                {

                }

            );
            _object[2] = new Asset2d(
                new float[]
                {
                    0.25f, 0.0f, 0.0f,
                    0.0f, 0.5f, 0.0f,
                    -0.25f, 0.0f, 0.0f
                },
                new uint[]
                {

                }
            );
            _object[3] = new Asset2d(
                new float[] { },
                new uint[] { }
            );
            _object[4] = new Asset2d(
                new float[1080],
                new uint[] { }
            );
            _object[5] = new Asset2d(
                new float[] { },
                new uint[] { }
            );
            _object[0].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            _object[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            _object[2].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            _object[3].createElips(0.0f, -0.5f, 0.25f, 0.5f);
            _object[3].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            _object[4].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            _object[5].load(Constants.path + "shader.vert", Constants.path + "shader.frag");*/

            CursorGrabbed = true;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            //GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;
            //temp = temp * Matrix4.CreateTranslation(0.5f, 0.5f, 0.5f);
            //degr += MathHelper.DegreesToRadians(1f);
            //temp = temp * Matrix4.CreateRotationX(degr);
            //_object3d[0].rotate(new OpenTK.Mathematics.Vector3(1f, 0.3f, 0.0f), _object3d[0]._euler[0], 1);

            //_object3d[7].rotatede(_object3d[7]._centerPosition, _object3d[7]._euler[0], 1f);
            //_object3d[7].Child[0].rotatede(_object3d[7].Child[0]._centerPosition, _object3d[7].Child[0]._euler[0], 1f);

            _object3d[0].render(new Vector4(0.0f, 0.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[1].render(new Vector4(0.0f, 0.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[2].render(new Vector4(0.0f, 0.3f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[3].render(new Vector4(0.0f, 0.5f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[4].render(new Vector4(0.0f, 0.5f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[5].render(new Vector4(1.0f, 1.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[6].render(new Vector4(0.9f, 0.9f, 0.9f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[7].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[8].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[9].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[10].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[11].render(new Vector4(1.0f, 1.0f, 1.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[12].render(new Vector4(1.0f, 1.0f, 1.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[13].render(new Vector4(1.0f, 1.0f, 1.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[14].render(new Vector4(1.0f, 1.0f, 1.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[15].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[16].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[17].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[18].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[19].render(new Vector4(0.0f, 0.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[20].render(new Vector4(0.0f, 0.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[21].render(new Vector4(0.0f, 0.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[22].render(new Vector4(0.0f, 0.0f, 0.0f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[23].render(new Vector4(0.8627f, 0.0784313f, 0.235294117647f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[24].render(new Vector4(0.66274509803f, 0.662745098039f, 0.66274509803f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[25].render(new Vector4(0.8627f, 0.0784313f, 0.235294117647f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[26].render(new Vector4(0.8627f, 0.0784313f, 0.235294117647f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[27].render(new Vector4(0.8627f, 0.0784313f, 0.235294117647f, 1.0f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[28].render(new Vector4(0.8627f, 0.0784313f, 0.235294117647f, 0.5f), 3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            _object3d[3].rotate(new OpenTK.Mathematics.Vector3(0.0f, 0.67f, 0.35f), _object3d[3]._euler[1], 0.5f);
            _object3d[4].rotate(new OpenTK.Mathematics.Vector3(0.0f, 0.67f, 0.35f), _object3d[4]._euler[1], 0.5f);
            _object3d[5].rotate(new OpenTK.Mathematics.Vector3(0.0f, 0.67f, 0.35f), _object3d[5]._euler[1], 0.5f);

            _object3d[19].rotate(new OpenTK.Mathematics.Vector3(0.63f, 1.56f, 0.25f), _object3d[19]._euler[1], 15f);
            _object3d[20].rotate(new OpenTK.Mathematics.Vector3(0.63f, 1.56f, -0.25f), _object3d[20]._euler[1], 15f);
            _object3d[21].rotate(new OpenTK.Mathematics.Vector3(-0.63f, 1.56f, 0.25f), _object3d[21]._euler[1], 15f);
            _object3d[22].rotate(new OpenTK.Mathematics.Vector3(-0.63f, 1.56f, -0.25f), _object3d[22]._euler[1], 15f);
            
            _object3d[23].rotate(new OpenTK.Mathematics.Vector3(0.7f, 3.0f, 0.8f), _object3d[23]._euler[0], 2f);
            _object3d[24].rotate(new OpenTK.Mathematics.Vector3(0.7f, 3.0f, 0.8f), _object3d[24]._euler[0], 2f);
            _object3d[25].rotate(new OpenTK.Mathematics.Vector3(0.7f, 3.0f, 0.8f), _object3d[25]._euler[0], 2f);
            _object3d[26].rotate(new OpenTK.Mathematics.Vector3(0.7f, 3.0f, 0.8f), _object3d[26]._euler[0], 2f);
            _object3d[27].rotate(new OpenTK.Mathematics.Vector3(0.7f, 3.0f, 0.8f), _object3d[27]._euler[0], 2f);
            _object3d[28].rotate(new OpenTK.Mathematics.Vector3(0.7f, 3.0f, 0.8f), _object3d[28]._euler[0], 2f);

            /*_object3d[23].rotate(new OpenTK.Mathematics.Vector3(2.0f, 2.0f, 0.0f), _object3d[23]._euler[1], 20f);
            _object3d[24].rotate(new OpenTK.Mathematics.Vector3(2.0f, 2.0f, 0.0f), _object3d[24]._euler[1], 20f);
            _object3d[25].rotate(new OpenTK.Mathematics.Vector3(2.0f, 2.0f, 0.0f), _object3d[25]._euler[1], 20f);
            _object3d[26].rotate(new OpenTK.Mathematics.Vector3(2.0f, 2.0f, 0.0f), _object3d[26]._euler[1], 20f);
            _object3d[27].rotate(new OpenTK.Mathematics.Vector3(2.0f, 2.0f, 0.0f), _object3d[27]._euler[1], 20f);
            _object3d[28].rotate(new OpenTK.Mathematics.Vector3(2.0f, 2.0f, 0.0f), _object3d[28]._euler[1], 20f);*/

            //_object3d[0].resetEuler();

            /*_object[0].render(new Vector4(1.0f, 1.0f, 0.0f, 1.0f), 0);
            _object[1].render(new Vector4(1.0f, 1.0f, 0.0f, 1.0f), 0);
            _object[2].render(new Vector4(1.0f, 1.0f, 0.0f, 1.0f), 0);
            _object[3].render(new Vector4(1.0f, 0.0f, 0.0f, 1.0f), 1);
            if (_object[4].getVerticesLength())
            {
                List<float> _verticesTemp = _object[4].createCurveBezier();
                _object[5].setVertices(_verticesTemp.ToArray());
                _object[5].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                _object[5].render(new Vector4(1.0f, 0.0f, 0.0f, 1.0f), 3);
            }
            _object[4].render(new Vector4(1.0f, 0.0f, 0.0f, 1.0f), 2);*/

            SwapBuffers();
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            var input = KeyboardState;
            var mouse_input = MouseState;
            var sensitivity = 0.2f;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            /*if (input.IsKeyReleased(Keys.A))
            {
                Console.WriteLine("Key A sudah dilepas");
            }*/

            float cameraSpeed = 0.5f;
            if (input.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse_input.X, mouse_input.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse_input.X - _lastPos.X;
                var deltaY = mouse_input.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse_input.X, mouse_input.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(_camera.Position, generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position, generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position, generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position, generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Left)
            {
                float _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
                float _y = -(MousePosition.Y - Size.Y / 2) / (Size.Y / 2);

                Console.WriteLine("x = " + _x + " y = " + _y);
                //_object[4].updateMousePosition(_x , _y);
            }
        }
    }
}
