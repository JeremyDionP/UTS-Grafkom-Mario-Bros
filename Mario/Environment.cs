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

namespace Mario
{
    internal class Environment
    {
        List<List<Asset3d>> objectListEnvironment = new List<List<Asset3d>>();

        List<Asset3d> island = new List<Asset3d>();
        List<Asset3d> tree1 = new List<Asset3d>();
        List<Asset3d> tree2 = new List<Asset3d>();
        List<Asset3d> tree3 = new List<Asset3d>();
        List<Asset3d> tree4 = new List<Asset3d>();
        List<Asset3d> tree5 = new List<Asset3d>();
        List<Asset3d> tree6 = new List<Asset3d>();

        List<Asset2d> object2d = new List<Asset2d>();

        double _time;
        float degr = 0;
        Camera _camera;

        int counter = 0;
        bool rotate_to_left = true;

        // constructor
        public Environment()
        {

        }

        // fungsi untuk load objek-objek
        public void load(int x, int y)
        {
            // ===== INITIALIZATION =====
            // Island
            var lower_bottom_face = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var lower_island = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var upper_island = new Asset3d(new Vector3(0.35f, 1.0f, 0.5f));
            var upper_top_face = new Asset3d(new Vector3(0.35f, 1.0f, 0.5f));
            var dirt_1 = new Asset3d(new Vector3(0.65f, 0.55f, 0.065f));
            var dirt_2 = new Asset3d(new Vector3(0.65f, 0.55f, 0.065f));
            var dirt_3 = new Asset3d(new Vector3(0.65f, 0.55f, 0.065f));

            // Path
            var path1 = new Asset3d(new Vector3(0.7f, 0.55f, 0.025f));
            var path2 = new Asset3d(new Vector3(0.7f, 0.55f, 0.025f));
            var path3 = new Asset3d(new Vector3(0.7f, 0.55f, 0.025f));
            var path4 = new Asset3d(new Vector3(0.7f, 0.55f, 0.025f));
            var path5 = new Asset3d(new Vector3(0.7f, 0.55f, 0.025f));
            var path6 = new Asset3d(new Vector3(0.7f, 0.55f, 0.025f));

            // Trees
            var tree1_log = new Asset3d(new Vector3(0.45f, 0.3f, 0.05f));
            var tree1_bot_leaves = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree1_mid_leaves = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var tree1_top_leaves = new Asset3d(new Vector3(0.35f, 1.0f, 0.25f));

            var tree2_log = new Asset3d(new Vector3(0.45f, 0.3f, 0.05f));
            var tree2_bot_leaves = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree2_mid_leaves = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var tree2_top_leaves = new Asset3d(new Vector3(0.35f, 1.0f, 0.25f));

            var tree3_log = new Asset3d(new Vector3(0.45f, 0.3f, 0.05f));
            var tree3_bot_leaves = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree3_mid_leaves = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var tree3_top_leaves = new Asset3d(new Vector3(0.35f, 1.0f, 0.25f));

            var tree4_log = new Asset3d(new Vector3(0.45f, 0.3f, 0.05f));
            var tree4_bot_leaves = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree4_mid_leaves = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var tree4_top_leaves = new Asset3d(new Vector3(0.35f, 1.0f, 0.25f));

            var tree5_log = new Asset3d(new Vector3(0.45f, 0.3f, 0.05f));
            var tree5_bot_leaves = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree5_mid_leaves = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var tree5_top_leaves = new Asset3d(new Vector3(0.35f, 1.0f, 0.25f));

            var tree6_log = new Asset3d(new Vector3(0.45f, 0.3f, 0.05f));
            var tree6_bot_leaves = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree6_mid_leaves = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var tree6_top_leaves = new Asset3d(new Vector3(0.35f, 1.0f, 0.25f));

            // ===== CREATE OBJECT =====
            // Island
            lower_bottom_face.createEllipsoid(0, -0.215f, 0, 0.685f, 0.045f, 0.685f, 100, 100);
            lower_island.createCylinder(0, -0.13f, 0, 0.685f, 0.055f, 0.685f, 100, 100);
            upper_island.createCylinder(0, -0.065f, 0, 0.7f, 0.025f, 0.7f, 100, 100);
            upper_top_face.createEllipsoid(0, -0.03f, 0, 0.7f, 0.025f, 0.7f, 100, 100);
            dirt_1.createEllipsoid(0, -0.015f, -0.475f, 0.165f, 0.0075f, 0.165f, 100, 100);
            dirt_2.createEllipsoid(0.15f, -0.015f, -0.5f, 0.1f, 0.0075f, 0.1f, 100, 100);
            dirt_3.createEllipsoid(-0.15f, -0.015f, -0.5f, 0.1f, 0.0075f, 0.1f, 100, 100);

            // Path
            path1.createBlock2(0, -0.013f, 0.4f, 0.125f, 0.0175f, 0.01f);
            path1.rotate(path1.objectCenter, Vector3.UnitX, 90);
            path2.createBlock2(0, -0.014f, 0.45f, 0.125f, 0.0175f, 0.01f);
            path2.rotate(path2.objectCenter, Vector3.UnitX, 90);
            path3.createBlock2(0, -0.015f, 0.5f, 0.125f, 0.0175f, 0.01f);
            path3.rotate(path3.objectCenter, Vector3.UnitX, 90);
            path4.createBlock2(0, -0.0165f, 0.55f, 0.125f, 0.0175f, 0.01f);
            path4.rotate(path4.objectCenter, Vector3.UnitX, 90);
            path5.createBlock2(0, -0.019f, 0.6f, 0.125f, 0.0175f, 0.01f);
            path5.rotate(path5.objectCenter, Vector3.UnitX, 90);
            path6.createBlock2(0, -0.021f, 0.65f, 0.125f, 0.0175f, 0.01f);
            path6.rotate(path6.objectCenter, Vector3.UnitX, 90);

            // Trees
            tree1_log.createCylinder(-0.475f, 0.175f, -0.175f, 0.02f, 0.125f, 0.02f, 100, 100);
            tree1_bot_leaves.createCone(-0.475f, 0.275f, -0.175f, 0.13f, 0.2f, 0.13f, 100, 100);
            tree1_bot_leaves.rotate(tree1_bot_leaves.objectCenter, Vector3.UnitX, 180);
            tree1_mid_leaves.createCone(-0.475f, 0.35f, -0.175f, 0.115f, 0.2f, 0.115f, 100, 100);
            tree1_mid_leaves.rotate(tree1_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree1_top_leaves.createCone(-0.475f, 0.425f, -0.175f, 0.105f, 0.2f, 0.105f, 100, 100);
            tree1_top_leaves.rotate(tree1_top_leaves.objectCenter, Vector3.UnitX, 180);

            tree2_log.createCylinder(-0.495f, 0.125f, 0.2f, 0.0175f, 0.115f, 0.0175f, 100, 100);
            tree2_bot_leaves.createCone(-0.495f, 0.225f, 0.2f, 0.105f, 0.17f, 0.105f, 100, 100);
            tree2_bot_leaves.rotate(tree2_bot_leaves.objectCenter, Vector3.UnitX, 180);
            tree2_mid_leaves.createCone(-0.495f, 0.3f, 0.2f, 0.08f, 0.17f, 0.08f, 100, 100);
            tree2_mid_leaves.rotate(tree2_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree2_top_leaves.createCone(-0.495f, 0.375f, 0.2f, 0.055f, 0.17f, 0.055f, 100, 100);
            tree2_top_leaves.rotate(tree2_top_leaves.objectCenter, Vector3.UnitX, 180);

            tree3_log.createCylinder(-0.595f, 0.1f, 0.025f, 0.015f, 0.075f, 0.015f, 100, 100);
            tree3_bot_leaves.createCone(-0.595f, 0.17f, 0.025f, 0.09f, 0.105f, 0.09f, 100, 100);
            tree3_bot_leaves.rotate(tree3_bot_leaves.objectCenter, Vector3.UnitX, 180);
            tree3_mid_leaves.createCone(-0.595f, 0.215f, 0.025f, 0.075f, 0.105f, 0.075f, 100, 100);
            tree3_mid_leaves.rotate(tree3_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree3_top_leaves.createCone(-0.595f, 0.26f, 0.025f, 0.055f, 0.105f, 0.055f, 100, 100);
            tree3_top_leaves.rotate(tree3_top_leaves.objectCenter, Vector3.UnitX, 180);

            tree4_log.createCylinder(0.575f, 0.175f, 0.05f, 0.02f, 0.125f, 0.02f, 100, 100);
            tree4_bot_leaves.createCone(0.575f, 0.275f, 0.05f, 0.13f, 0.2f, 0.13f, 100, 100);
            tree4_bot_leaves.rotate(tree4_bot_leaves.objectCenter, Vector3.UnitX, 180);
            tree4_mid_leaves.createCone(0.575f, 0.35f, 0.05f, 0.115f, 0.2f, 0.115f, 100, 100);
            tree4_mid_leaves.rotate(tree4_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree4_top_leaves.createCone(0.575f, 0.425f, 0.05f, 0.105f, 0.2f, 0.105f, 100, 100);
            tree4_top_leaves.rotate(tree4_top_leaves.objectCenter, Vector3.UnitX, 180);

            tree5_log.createCylinder(0.475f, 0.125f, -0.175f, 0.0175f, 0.115f, 0.0175f, 100, 100);
            tree5_bot_leaves.createCone(0.475f, 0.225f, -0.175f, 0.105f, 0.17f, 0.105f, 100, 100);
            tree5_bot_leaves.rotate(tree5_bot_leaves.objectCenter, Vector3.UnitX, 180);
            tree5_mid_leaves.createCone(0.475f, 0.3f, -0.175f, 0.08f, 0.17f, 0.08f, 100, 100);
            tree5_mid_leaves.rotate(tree5_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree5_top_leaves.createCone(0.475f, 0.375f, -0.175f, 0.055f, 0.17f, 0.055f, 100, 100);
            tree5_top_leaves.rotate(tree5_top_leaves.objectCenter, Vector3.UnitX, 180);

            tree6_log.createCylinder(0.475f, 0.1f, 0.225f, 0.015f, 0.075f, 0.015f, 100, 100);
            tree6_bot_leaves.createCone(0.475f, 0.17f, 0.225f, 0.09f, 0.105f, 0.09f, 100, 100);
            tree6_bot_leaves.rotate(tree6_bot_leaves.objectCenter, Vector3.UnitX, 180);
            tree6_mid_leaves.createCone(0.475f, 0.215f, 0.225f, 0.075f, 0.105f, 0.075f, 100, 100);
            tree6_mid_leaves.rotate(tree6_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree6_top_leaves.createCone(0.475f, 0.26f, 0.225f, 0.055f, 0.105f, 0.055f, 100, 100);
            tree6_top_leaves.rotate(tree6_top_leaves.objectCenter, Vector3.UnitX, 180);

            // ===== ADD OBJECT =====
            // Island
            island.Add(lower_bottom_face);
            island.Add(lower_island);
            island.Add(upper_island);
            island.Add(upper_top_face);
            island.Add(dirt_1);
            island.Add(dirt_2);
            island.Add(dirt_3);

            // Path
            island.Add(path1);
            island.Add(path2);
            island.Add(path3);
            island.Add(path4);
            island.Add(path5);
            island.Add(path6);

            // Trees
            tree1.Add(tree1_log);
            tree1.Add(tree1_bot_leaves);
            tree1.Add(tree1_mid_leaves);
            tree1.Add(tree1_top_leaves);

            tree2.Add(tree2_log);
            tree2.Add(tree2_bot_leaves);
            tree2.Add(tree2_mid_leaves);
            tree2.Add(tree2_top_leaves);

            tree3.Add(tree3_log);
            tree3.Add(tree3_bot_leaves);
            tree3.Add(tree3_mid_leaves);
            tree3.Add(tree3_top_leaves);

            tree4.Add(tree4_log);
            tree4.Add(tree4_bot_leaves);
            tree4.Add(tree4_mid_leaves);
            tree4.Add(tree4_top_leaves);

            tree5.Add(tree5_log);
            tree5.Add(tree5_bot_leaves);
            tree5.Add(tree5_mid_leaves);
            tree5.Add(tree5_top_leaves);

            tree6.Add(tree6_log);
            tree6.Add(tree6_bot_leaves);
            tree6.Add(tree6_mid_leaves);
            tree6.Add(tree6_top_leaves);

            objectListEnvironment.Add(island);
            objectListEnvironment.Add(tree1);
            objectListEnvironment.Add(tree2);
            objectListEnvironment.Add(tree3);
            objectListEnvironment.Add(tree4);
            objectListEnvironment.Add(tree5);
            objectListEnvironment.Add(tree6);

            // menambahkan shaders ke setiap objek yang ada
            // Load environment
            foreach (List<Asset3d> i in objectListEnvironment)
            {
                foreach (Asset3d j in i)
                {
                    j.load(x, y);
                }
            }

            // load objek 2D
            foreach (Asset2d i in object2d)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
            }

            // rotasi objek sebesar 180 derajat
            //foreach (Asset3d i in object3d)
            //{
            //    i.rotate(Vector3.Zero, Vector3.UnitY, 180);
            //}
        }

        // fungsi untuk render objek-objek
        public void render(FrameEventArgs args, Camera _camera, KeyboardState input, int x, int y)
        {
            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi

            // Render environment
            foreach (List<Asset3d> i in objectListEnvironment)
            {
                foreach (Asset3d j in i)
                {
                    j.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                    //j.rotate(Vector3.Zero, Vector3.UnitY, 25 * time);

                    // Rotate setiap child dari objek
                    foreach (Asset3d k in j.child)
                    {
                        k.rotate(Vector3.Zero, Vector3.UnitY, 720 * time);
                    }
                }
            }

            // animasi daun pohon bergerak seperti tertiup angin
            if (counter < 25 && rotate_to_left)
            {
                counter += 1;

                // Tree 1
                tree1[1].rotate(tree1[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                tree1[2].rotate(tree1[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                tree1[3].rotate(tree1[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);

                // Tree 2
                tree2[1].rotate(tree2[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                tree2[2].rotate(tree2[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                tree2[3].rotate(tree2[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);

                // Tree 3
                tree3[1].rotate(tree3[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                tree3[2].rotate(tree3[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                tree3[3].rotate(tree3[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);

                // Tree 4
                tree4[1].rotate(tree4[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                tree4[2].rotate(tree4[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                tree4[3].rotate(tree4[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);

                // Tree 5
                tree5[1].rotate(tree5[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                tree5[2].rotate(tree5[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                tree5[3].rotate(tree5[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);

                // Tree 6
                tree6[1].rotate(tree6[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                tree6[2].rotate(tree6[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                tree6[3].rotate(tree6[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
            }
            // animasi daun pohon bergerak seperti tertiup angin (reverse)
            else
            {
                rotate_to_left = false;
                if (counter > -25 && !rotate_to_left)
                {
                    counter -= 1;

                    // Tree 1
                    tree1[1].rotate(tree1[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                    tree1[2].rotate(tree1[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                    tree1[3].rotate(tree1[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);

                    // Tree 2
                    tree2[1].rotate(tree2[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                    tree2[2].rotate(tree2[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                    tree2[3].rotate(tree2[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);

                    // Tree 3
                    tree3[1].rotate(tree3[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                    tree3[2].rotate(tree3[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                    tree3[3].rotate(tree3[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);

                    // Tree 4
                    tree4[1].rotate(tree4[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                    tree4[2].rotate(tree4[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                    tree4[3].rotate(tree4[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);

                    // Tree 5
                    tree5[1].rotate(tree5[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                    tree5[2].rotate(tree5[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                    tree5[3].rotate(tree5[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);

                    // Tree 6
                    tree6[1].rotate(tree6[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                    tree6[2].rotate(tree6[0].objectCenter, Vector3.UnitZ, -15 * 0.005f);
                    tree6[3].rotate(tree6[0].objectCenter, Vector3.UnitZ, 15 * 0.005f);
                }
                else
                {
                    rotate_to_left = true;
                }
            }

            // Render objek 2D
            foreach (Asset2d i in object2d)
            {
                i.render(0, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
        }
    }
}
