using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using OpenTK.Mathematics;
using LearnOpenTK.Common;

namespace Mario
{
    internal class Mario
    {

        static class Constants
        {
            public const string path = "../../../Shaders/";
        }
        public Mario()
        {
         
        }
        List<List<Asset3d>> objectListMario = new List<List<Asset3d>>();
        List<Asset2d> objectList = new List<Asset2d>();

        List<Asset3d> kepala = new List<Asset3d>();
        List<Asset3d> tanganKanan = new List<Asset3d>();
        List<Asset3d> tanganKiri = new List<Asset3d>();
        List<Asset3d> Badan = new List<Asset3d>();
        List<Asset3d> KakiKiri = new List<Asset3d>();
        List<Asset3d> KakiKanan = new List<Asset3d>();
        List<Asset3d> environment2 = new List<Asset3d>();

        float temp = 0;
        float jump = 0f;
        bool up = true;
        float hitung = 0;


        public void load(int x, int y)
        {

            //INITIALISASI
            //Kepala
            var head = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));

            //Topi
            var hat = new Asset3d(new Vector3(1.0f, 0, 0));
            var hat2 = new Asset3d(new Vector3(1.0f, 0f, 0));
            var hat3 = new Asset3d(new Vector3(1.0f, 0, 0));
            var logo = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));

            //Hidung
            var nose = new Asset3d(new Vector3(1.0f, 0.8f, 0.6f));

            //Mata
            var eye = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var eye2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var pupil = new Asset3d(new Vector3(0.1f, 0.1f, 1.0f));
            var pupil2 = new Asset3d(new Vector3(0.1f, 0.1f, 1.0f));
            var pupil3 = new Asset3d(new Vector3(0f, 0f, 0f));
            var pupil4 = new Asset3d(new Vector3(0f, 0f, 0f));
            var alis = new Asset3d(new Vector3(0f, 0f, 0f));
            var alis2 = new Asset3d(new Vector3(0f, 0f, 0f));

            //Kumis
            var kumis = new Asset3d(new Vector3(0f, 0f, 0f));
            var kumis2 = new Asset3d(new Vector3(0f, 0f, 0f));
            var kumis3 = new Asset3d(new Vector3(0f, 0f, 0f));
            var kumis4 = new Asset3d(new Vector3(0f, 0f, 0f));
            var kumis5 = new Asset3d(new Vector3(0f, 0f, 0f));
            var kumis6 = new Asset3d(new Vector3(0f, 0f, 0f));
            var kumis7 = new Asset3d(new Vector3(0f, 0f, 0f));

            //Telinga
            var telinga = new Asset3d(new Vector3(1.0f, 0.8f, 0.6f));
            var telinga2 = new Asset3d(new Vector3(1.0f, 0.8f, 0.6f));

            //Rambut
            var rambut = new Asset3d(new Vector3(0f, 0f, 0f));
            var rambut3 = new Asset3d(new Vector3(0f, 0f, 0f));
            var rambut5 = new Asset3d(new Vector3(0f, 0f, 0f));
            var rambut6 = new Asset3d(new Vector3(0f, 0f, 0f));
            var rambut7 = new Asset3d(new Vector3(0f, 0f, 0f));
            var rambut8 = new Asset3d(new Vector3(0f, 0f, 0f));
            var rambut9 = new Asset3d(new Vector3(0f, 0f, 0f));

            //Badan
            var badan = new Asset3d(new Vector3(1.0f, 0f, 0f));
            var badan2 = new Asset3d(new Vector3(0f, 0f, 1.0f));

            var leftHand = new Asset3d(new Vector3(1.0f, 0f, 0));
            var rightHand = new Asset3d(new Vector3(1.0f, 0f, 0));
            var leftHand2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var rightHand2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var leftHand3 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var rightHand3 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var jempolKiri = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));


            var leftLeg = new Asset3d(new Vector3(0f, 0, 1.0f));
            var sepatuKiri = new Asset3d(new Vector3(0f, 0f, 0f));
            var rightLeg = new Asset3d(new Vector3(0f, 0, 1.0f));
            var sepatuKanan = new Asset3d(new Vector3(0f, 0f, 0f));
            var coinCube = new Asset3d(new Vector3(1.0f, 0.7f, 0));
            var coin = new Asset3d(new Vector3(1.0f, 1.0f, 0));

            var coba = new Asset2d(new Vector3(0f, 0f, 0f),
                new float[1080],
                new uint[]
                {
                });

            var coba2 = new Asset2d(new Vector3(0f, 0f, 0f),
                new float[]
                {

                },
                new uint[] { }
                );
            var coba3 = new Asset2d(new Vector3(0f, 0f, 0f),
                new float[1080],
                new uint[]
                {
                });
            var coba4 = new Asset2d(new Vector3(0f, 0f, 0f),
                new float[]
                {

                },
                new uint[]
                {
                });


            //=================================================================================================

            //CREATE OBJEK
            //Kepala
            head.createEllipsoid(0, 0.124f, 0, 0.020f, 0.020f, 0.020f, 50.0f, 50.0f);

            //Topi
            hat.createEllipsoid(0, 0.14f, 0.01f, 0.017f, 0.002f, 0.02f, 1000.0f, 100.0f);
            hat2.createEllipsoid(0, 0.141f, 0.005f, 0.021f, 0.018f, 0.007f, 1000.0f, 100.0f);
            hat3.createEllipsoid(0, 0.1395f, -0.005f, 0.022f, 0.01f, 0.019f, 1000.0f, 100.0f);
            logo.createEllipsoid(0, 0.15f, 0.013f, 0.005f, 0.005f, 0.005f, 1000.0f, 100.0f);

            

            //Hidung
            nose.createEllipsoid(0, 0.121f, 0.02f, 0.005f, 0.005f, 0.005f, 100.0f, 100.0f);

            //Mata
            eye.createEllipsoid(0.007f, 0.128f, 0.017f, 0.003f, 0.0047f, 0.003f, 100.0f, 100.0f);
            eye2.createEllipsoid(-0.007f, 0.128f, 0.017f, 0.003f, 0.0047f, 0.003f, 100.0f, 100.0f);
            pupil.createEllipsoid(0.007f, 0.128f, 0.019f, 0.0015f, 0.0024f, 0.0015f, 100.0f, 100.0f);
            pupil2.createEllipsoid(-0.007f, 0.128f, 0.019f, 0.0015f, 0.0024f, 0.0015f, 100.0f, 100.0f);
            pupil3.createEllipsoid(0.007f, 0.128f, 0.02f, 0.00075f, 0.0012f, 0.00075f, 100.0f, 100.0f);
            pupil4.createEllipsoid(-0.007f, 0.128f, 0.02f, 0.00075f, 0.0012f, 0.00075f, 100.0f, 100.0f);
            alis.createEllipsoid(0.007f, 0.134f, 0.018f, 0.0035f, 0.0008f, 0.0008f, 100.0f, 100.0f);
            alis2.createEllipsoid(-0.007f, 0.134f, 0.018f, 0.0035f, 0.0008f, 0.0008f, 100.0f, 100.0f);

            //Kumis
            kumis.createEllipticParaboloid(-0.01f, 0.117f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);
            kumis2.createEllipticParaboloid(0.01f, 0.117f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);
            kumis3.createEllipticParaboloid(-0.007f, 0.1145f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);
            kumis4.createEllipticParaboloid(0.007f, 0.1145f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);
            kumis5.createEllipticParaboloid(-0.004f, 0.113f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);
            kumis6.createEllipticParaboloid(0.004f, 0.113f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);
            kumis7.createEllipticParaboloid(0.00f, 0.1125f, 0.0175f, 0.0013f, 0.0009f, 0.0013f, 100.0f, 100.0f);

            //Telinga
            telinga.createEllipsoid(0.02f, 0.127f, 0f, 0.004f, 0.006f, 0.003f, 100.0f, 100.0f);
            telinga2.createEllipsoid(-0.02f, 0.127f, 0f, 0.004f, 0.006f, 0.003f, 100.0f, 100.0f);

            //Rambut
            rambut.createEllipticParaboloid(-0.019f, 0.13f, 0.005f, 0.0015f, 0.0015f, 0.005f, 100.0f, 100.0f);
            rambut3.createEllipticParaboloid(0.019f, 0.13f, 0.005f, 0.0015f, 0.0015f, 0.005f, 100.0f, 100.0f);
            rambut5.createEllipticParaboloid(0.019f, 0.13f, 0.003f, 0.001f, 0.001f, 0.004f, 100.0f, 100.0f);
            rambut6.createEllipticParaboloid(-0.019f, 0.13f, 0.003f, 0.001f, 0.001f, 0.004f, 100.0f, 100.0f);
            rambut7.createBlock(-0.018f, 0.134f, -0.0021f, 0.0021f, 0.01f);
            rambut8.createBlock(0.018f, 0.134f, -0.0021f, 0.0021f, 0.01f);
            rambut9.createEllipsoid(0, 0.124f, -0.005f, 0.019f, 0.018f, 0.018f, 50.0f, 50.0f);

            //Badan
            badan.createEllipticParaboloid(0f, 0.105f, 0f, 0.017f, 0.015f, 0.01f, 1000.0f, 100.0f);
            badan2.createEllipticParaboloid(0f, 0.055f, 0f, 0.017f, 0.015f, 0.01f, 1000.0f, 100.0f);

            //Tangan
            leftHand.createCylinder(-0.028f, 0.105f, 0f, 0.005f, 0.012f, 0.005f, 1000.0f, 100.0f);
            leftHand2.createTorus(-0.046f, 0.112f, 0f, 0.0042f, 0.0015f, 100.0f, 100.0f);
            leftHand3.createEllipsoid(-0.051f, 0.1135f, 0f, 0.0065f, 0.0055f, 0.0055f, 100.0f, 100.0f);
            jempolKiri.createEllipticParaboloid(-0.05f, 0.125f, 0f, 0.002f, 0.002f, 0.005f, 100.0f, 100.0f);

            rightHand.createCylinder(0.028f, 0.09f, 0f, 0.005f, 0.012f, 0.005f, 100.0f, 100.0f);
            rightHand2.createTorus(0.046f, 0.084f, 0f, 0.0042f, 0.0015f, 100.0f, 100.0f);
            rightHand3.createEllipsoid(0.05f, 0.083f, 0f, 0.0065f, 0.0055f, 0.0055f, 100.0f, 100.0f);


            //Kaki
            leftLeg.createCylinder(-0.013f, 0.05f, 0f, 0.009f, 0.014f, 0.009f, 100.0f, 100.0f);
            sepatuKiri.createEllipsoid(-0.014f, 0.025f, 0f, 0.01f, 0.009f, 0.01f, 100.0f, 100.0f);
            rightLeg.createCylinder(0.013f, 0.05f, 0f, 0.009f, 0.014f, 0.009f, 100.0f, 100.0f);
            sepatuKanan.createEllipsoid(0.014f, 0.025f, 0f, 0.01f, 0.009f, 0.01f, 100.0f, 100.0f);

            coinCube.createCuboid(0, 0.27f, 0f, 0.07f);
            coin.createTorus(0, 0.28f, 0, 0.01f, 0.01f, 50f, 50f);

            //===========================================================================================

            //ADD
            //Kepala
            kepala.Add(head);

            //Hidung
            head.child.Add(nose);

            //Mata
            head.child.Add(eye);
            head.child.Add(eye2);
            head.child.Add(pupil);
            head.child.Add(pupil2);
            head.child.Add(pupil3);
            head.child.Add(pupil4);
            alis.rotate(alis.objectCenter, Vector3.UnitZ, 25);
            head.child.Add(alis);
            alis2.rotate(alis2.objectCenter, Vector3.UnitZ, -25);
            head.child.Add(alis2);

            //Kumis
            kumis.rotate(kumis.objectCenter, Vector3.UnitX, -90);
            kumis.rotate(kumis.objectCenter, Vector3.UnitZ, -45);
            head.child.Add(kumis);
            kumis2.rotate(kumis2.objectCenter, Vector3.UnitX, -90);
            kumis2.rotate(kumis2.objectCenter, Vector3.UnitZ, 45);
            head.child.Add(kumis2);
            kumis3.rotate(kumis3.objectCenter, Vector3.UnitX, -90);
            kumis3.rotate(kumis3.objectCenter, Vector3.UnitZ, -30);
            head.child.Add(kumis3);
            kumis4.rotate(kumis4.objectCenter, Vector3.UnitX, -90);
            kumis4.rotate(kumis4.objectCenter, Vector3.UnitZ, 30);
            head.child.Add(kumis4);
            kumis5.rotate(kumis5.objectCenter, Vector3.UnitX, -90);
            kumis5.rotate(kumis5.objectCenter, Vector3.UnitZ, -15);
            head.child.Add(kumis5);
            kumis6.rotate(kumis6.objectCenter, Vector3.UnitX, -90);
            kumis6.rotate(kumis6.objectCenter, Vector3.UnitZ, 15);
            head.child.Add(kumis6);
            kumis7.rotate(kumis7.objectCenter, Vector3.UnitX, -90);
            head.child.Add(kumis7);

            //Telinga
            head.child.Add(telinga);
            head.child.Add(telinga2);

            //Rambut
            rambut.rotate(rambut.objectCenter, Vector3.UnitX, -90);
            rambut.rotate(rambut.objectCenter, Vector3.UnitZ, -20);
            head.child.Add(rambut);
            rambut3.rotate(rambut3.objectCenter, Vector3.UnitX, -90);
            rambut3.rotate(rambut3.objectCenter, Vector3.UnitZ, 20);
            head.child.Add(rambut3);
            rambut5.rotate(rambut5.objectCenter, Vector3.UnitX, -90);
            rambut5.rotate(rambut5.objectCenter, Vector3.UnitZ, 20);
            head.child.Add(rambut5);
            rambut6.rotate(rambut6.objectCenter, Vector3.UnitX, -90);
            rambut6.rotate(rambut6.objectCenter, Vector3.UnitZ, -20);
            head.child.Add(rambut6);
            rambut7.rotate(rambut7.objectCenter, Vector3.UnitX, -110);
            head.child.Add(rambut7);
            rambut8.rotate(rambut8.objectCenter, Vector3.UnitX, -110);
            head.child.Add(rambut8);
            head.child.Add(rambut9);

            ////Topi
            head.child.Add(hat);
            hat2.rotate(hat2.objectCenter, Vector3.UnitZ, 90);
            hat2.rotate(hat2.objectCenter, Vector3.UnitX, 30);
            head.child.Add(hat2);
            hat3.rotate(hat3.objectCenter, Vector3.UnitX, -20);
            head.child.Add(hat3);
            head.child.Add(logo);

            //Badan
            badan.rotate(badan.objectCenter, Vector3.UnitX, 90);
            Badan.Add(badan);
            badan2.rotate(badan2.objectCenter, Vector3.UnitX, -90);
            //badan.child.Add(badan2);

            head.child.Add(badan);
            head.child.Add(badan2);

            //Tangan
            rightHand.rotate(rightHand.objectCenter, Vector3.UnitZ, -110);
            tanganKanan.Add(rightHand);
            rightHand2.rotate(rightHand2.objectCenter, Vector3.UnitZ, -110);
            //rightHand.child.Add(rightHand2);
            //rightHand.child.Add(rightHand3);

            head.child.Add(rightHand);
            head.child.Add(rightHand2);
            head.child.Add(rightHand3);

            leftHand.rotate(leftHand.objectCenter, Vector3.UnitZ, 70);
            tanganKiri.Add(leftHand);
            leftHand2.rotate(leftHand2.objectCenter, Vector3.UnitZ, 70);
            //leftHand.child.Add(leftHand2);
            //leftHand.child.Add(leftHand3);
            jempolKiri.rotate(jempolKiri.objectCenter, Vector3.UnitX, 90);
            jempolKiri.rotate(jempolKiri.objectCenter, Vector3.UnitZ, -18);
            //leftHand.child.Add(jempolKiri);

            head.child.Add(leftHand);
            head.child.Add(leftHand2);
            head.child.Add(leftHand3);
            head.child.Add(jempolKiri);

            //Kaki
            KakiKiri.Add(leftLeg);
            //leftLeg.child.Add(sepatuKiri);
            KakiKanan.Add(rightLeg);
            //rightLeg.child.Add(sepatuKanan);

            head.child.Add(leftLeg);
            head.child.Add(sepatuKiri);
            head.child.Add(rightLeg);
            head.child.Add(sepatuKanan);
            coin.rotate(coin.objectCenter, Vector3.UnitZ, 90);


            environment2.Add(coinCube);
            head.child.Add(coin);



            objectListMario.Add(kepala);
            objectListMario.Add(Badan);
            objectListMario.Add(tanganKiri);
            objectListMario.Add(tanganKanan);
            objectListMario.Add(KakiKanan);
            objectListMario.Add(KakiKiri);
            objectListMario.Add(environment2);

           
            foreach (Asset3d i in environment2)
            {
                i.load(x, y);
                i.translate(-0.177f, -0.035f, 0.55f);
            }
            foreach (Asset3d i in kepala)
            {
                i.load(x, y);
                i.translate(-0.177f, -0.035f, 0.55f);
            }

            objectList.Add(coba);
            objectList.Add(coba2);
            objectList.Add(coba3);
            objectList.Add(coba4);



            objectList[0].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
            objectList[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
            objectList[2].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
            objectList[3].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);



            float _x = -0.18f;
            float _y = 0.25f;

            objectList[0].updateMousePos(_x, _y);


            _x = -0.09f;
            _y = 0.1625f;

            objectList[0].updateMousePos(_x, _y);

            _x = -0.06f;
            _y = 0.075f;

            objectList[0].updateMousePos(_x, _y);



            float _x2 = -0.18f;
            float _y2 = 0.225f;

            objectList[2].updateMousePos(_x2, _y2);

            _x2 = -0.09f;
            _y2 = 0.105f;

            objectList[2].updateMousePos(_x2, _y2);








        }

        public void render(FrameEventArgs args, Camera _camera, KeyboardState input, int x, int y)
        {

            float time = (float)args.Time;
            Asset3d kotak = environment2[0];

            if (objectList[0].getVerticesLength())
            {
                List<float> _verticesTemp = objectList[0].createCurveBezier();
                objectList[1].setVertices(_verticesTemp.ToArray());
                objectList[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
                objectList[1].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
            objectList[0].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (objectList[2].getVerticesLength())
            {
                List<float> _verticesTemp = objectList[2].createCurveBezier();
                objectList[3].setVertices(_verticesTemp.ToArray());
                objectList[3].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
                objectList[3].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
            objectList[2].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            foreach (List<Asset3d> i in objectListMario)
            {
                foreach (Asset3d j in i)
                {
                    j.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                }

            }

            foreach (Asset3d j in kepala)
            {
                if (jump == 75)
                {
                    //kotak membesar
                    kotak.scale(1.002f, 1.002f, 1.002f);
                    if (hitung == 75)
                    {
                        //kotak mengecil
                        kotak.scale(0.86f, 0.86f, 0.86f);
                        up = true;
                        jump = 0;
                        continue;
                    }
                    up = false;
                }
                else
                {
                    hitung = 0;
                }

                if (jump < 75 && up)
                {
                    temp = 0.001f;
                    jump += 1;

                    //rotasi tangan
                    j.child[33].rotate(new Vector3(-0.16f, 0.09f, 0f), Vector3.UnitZ, temp * 500);
                    j.child[32].rotate(new Vector3(-0.16f, 0.09f, 0f), Vector3.UnitZ, temp * 500);
                    j.child[31].rotate(new Vector3(-0.16f, 0.09f, 0f), Vector3.UnitZ, temp * 500);
                    //rotasi kaki
                    j.child[38].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    j.child[39].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    j.child[40].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    j.child[41].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    //lompat naik
                    j.translate(0, temp, 0);

                }
                if (hitung < 75 && !up)
                {
                    temp = -0.001f;
                    //turun
                    j.translate(0, temp, 0);

                    hitung += 1;

                    //rotasi tangan
                    j.child[33].rotate(new Vector3(-0.16f, 0.09f, 0f), Vector3.UnitZ, temp * 500);
                    j.child[32].rotate(new Vector3(-0.16f, 0.09f, 0f), Vector3.UnitZ, temp * 500);
                    j.child[31].rotate(new Vector3(-0.16f, 0.09f, 0f), Vector3.UnitZ, temp * 500);
                    //rotasi kaki
                    j.child[38].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    j.child[39].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    j.child[40].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);
                    j.child[41].rotate(new Vector3(-0.013f, 0.08f, 0.55f), Vector3.UnitX, temp * 400);

                }
            }

            //rotasi koin
            kepala[0].child[42].rotate(kepala[0].child[42].objectCenter, Vector3.UnitY, 100 * time);

        }

    }
}
