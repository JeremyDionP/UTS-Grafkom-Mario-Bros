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
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }

    internal class Castle
    {
        List<Asset3d> object3d = new List<Asset3d>();
        List<Asset2d> object2d = new List<Asset2d>();

        double _time;
        float degr = 0;
        Camera _camera;

        // constructor
        public Castle()
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

            // Castle
            var castle_body_1 = new Asset3d(new Vector3(0.9f, 0.9f, 0.9f));
            var castle_body_2 = new Asset3d(new Vector3(0.9f, 0.9f, 0.9f));
            var castle_body_3 = new Asset3d(new Vector3(0.9f, 0.9f, 0.9f));
            var castle_body_4 = new Asset3d(new Vector3(0.9f, 0.9f, 0.9f));

            var castle_middle_body = new Asset3d(new Vector3(0.9f, 0.9f, 0.9f));
            var castle_middle_door1 = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var castle_middle_door2 = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));

            var castle_fence_1 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_2 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_3 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_4 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_5 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_6 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_7 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_8 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));

            var castle_front_door = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));

            var castle_fence_9 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_10 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_11 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_12 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_13 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_14 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_15 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_fence_16 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));

            var castle_connector_1 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_connector_2 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_connector_3 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_connector_4 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));

            var castle_connector_top1 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_connector_top2 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_connector_top3 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_connector_top4 = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));

            var castle_top_body = new Asset3d(new Vector3(0.9f, 0.9f, 0.9f));
            var castle_top_roof = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_top_ring = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var castle_top_door = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));

            //var line = new Asset2d(
            //    new Vector3(1.0f, 0.35f, 0.5f),
            //    new float[]
            //    {
            //        0.75f, 0.75f, 0.75f,
            //        0.85f, 0.85f, 0.75f,
            //        0.95f, 0.75f, 0.75f,
            //    },
            //    new uint[] { }
            //);
            //object2d.Add(line);
            //var curve = new Asset2d(
            //    new Vector3(1.0f, 0.35f, 0.5f),
            //    new float[] { },
            //    new uint[] { }
            //);
            //object2d.Add(curve);

            // Tower 1
            var tower1_bottom_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower1_body_structure = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower1_body = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower1_upper_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower1_lower_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower1_upper_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower1_roof = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var tower1_pole = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower1_pole_ball = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower1_banner = new Asset3d(new Vector3(0.25f, 0.25f, 1.0f));

            // Tower 2
            var tower2_bottom_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower2_body_structure = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower2_body = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower2_upper_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower2_lower_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower2_upper_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower2_roof = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var tower2_pole = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower2_pole_ball = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower2_banner = new Asset3d(new Vector3(0.25f, 0.25f, 1.0f));

            // Tower 3
            var tower3_bottom_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower3_body_structure = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower3_body = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower3_upper_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower3_lower_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower3_upper_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower3_roof = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var tower3_pole = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower3_pole_ball = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower3_banner = new Asset3d(new Vector3(0.25f, 0.25f, 1.0f));

            // Tower 4
            var tower4_bottom_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower4_body_structure = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower4_body = new Asset3d(new Vector3(0.85f, 0.85f, 0.85f));
            var tower4_upper_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower4_lower_ring = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower4_upper_part = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var tower4_roof = new Asset3d(new Vector3(1.0f, 0.35f, 0.5f));
            var tower4_pole = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower4_pole_ball = new Asset3d(new Vector3(0.5f, 0.35f, 0.05f));
            var tower4_banner = new Asset3d(new Vector3(0.25f, 0.25f, 1.0f));

            // ===== CREATE OBJECT =====
            // Island
            lower_bottom_face.createEllipsoid(0, -0.215f, 0, 0.685f, 0.045f, 0.685f, 100, 100);
            lower_island.createCylinder(0, -0.13f, 0, 0.685f, 0.055f, 0.685f, 100, 100);
            upper_island.createCylinder(0, -0.065f, 0, 0.7f, 0.025f, 0.7f, 100, 100);
            upper_top_face.createEllipsoid(0, -0.03f, 0, 0.7f, 0.025f, 0.7f, 100, 100);

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
            tree3_mid_leaves.createCone(-0.595f, 0.215f, 0.025f, 0.065f, 0.105f, 0.065f, 100, 100);
            tree3_mid_leaves.rotate(tree3_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree3_top_leaves.createCone(-0.595f, 0.26f, 0.025f, 0.04f, 0.105f, 0.04f, 100, 100);
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
            tree6_mid_leaves.createCone(0.475f, 0.215f, 0.225f, 0.065f, 0.105f, 0.065f, 100, 100);
            tree6_mid_leaves.rotate(tree6_mid_leaves.objectCenter, Vector3.UnitX, 180);
            tree6_top_leaves.createCone(0.475f, 0.26f, 0.225f, 0.04f, 0.105f, 0.04f, 100, 100);
            tree6_top_leaves.rotate(tree6_top_leaves.objectCenter, Vector3.UnitX, 180);

            // Castle
            castle_body_1.createCuboid(-0.165f, 0.165f, 0.165f, 0.35f);
            castle_body_2.createCuboid(0.165f, 0.165f, 0.165f, 0.35f);
            castle_body_3.createCuboid(0.165f, 0.165f, -0.165f, 0.35f);
            castle_body_4.createCuboid(-0.165f, 0.165f, -0.165f, 0.35f);
            castle_middle_body.createCuboid(0, 0.545f, 0, 0.4f);
            castle_middle_door1.createBlock(0, 0.42f, 0.155f, 0.125f, 0.15f);
            castle_middle_door2.createBlock(0, 0.42f, -0.155f, 0.125f, 0.15f);

            castle_fence_1.createCylinder(0, 0.35f, 0.35f, 0.015f, 0.215f, 0.015f, 100, 100);
            castle_fence_1.rotate(castle_fence_1.objectCenter, Vector3.UnitZ, 90);
            castle_fence_2.createCylinder(0, 0.375f, 0.35f, 0.015f, 0.215f, 0.015f, 100, 100);
            castle_fence_2.rotate(castle_fence_2.objectCenter, Vector3.UnitZ, 90);
            castle_fence_3.createCylinder(0, 0.35f, -0.35f, 0.015f, 0.215f, 0.015f, 100, 100);
            castle_fence_3.rotate(castle_fence_3.objectCenter, Vector3.UnitZ, 90);
            castle_fence_4.createCylinder(0, 0.375f, -0.35f, 0.015f, 0.215f, 0.015f, 100, 100);
            castle_fence_4.rotate(castle_fence_4.objectCenter, Vector3.UnitZ, 90);

            castle_fence_5.createCylinder(0.35f, 0.35f, 0, 0.015f, 0.22f, 0.015f, 100, 100);
            castle_fence_5.rotate(castle_fence_5.objectCenter, Vector3.UnitX, 90);
            castle_fence_6.createCylinder(0.35f, 0.375f, 0, 0.015f, 0.22f, 0.015f, 100, 100);
            castle_fence_6.rotate(castle_fence_6.objectCenter, Vector3.UnitX, 90);
            castle_fence_7.createCylinder(-0.35f, 0.35f, 0, 0.015f, 0.22f, 0.015f, 100, 100);
            castle_fence_7.rotate(castle_fence_7.objectCenter, Vector3.UnitX, 90);
            castle_fence_8.createCylinder(-0.35f, 0.375f, 0, 0.015f, 0.22f, 0.015f, 100, 100);
            castle_fence_8.rotate(castle_fence_8.objectCenter, Vector3.UnitX, 90);

            castle_front_door.createBlock(0, 0.07f, 0.275f, 0.15f, 0.2f);

            castle_fence_9.createCylinder(0, 0.759f, 0.205f, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_9.rotate(castle_fence_9.objectCenter, Vector3.UnitZ, 90);
            castle_fence_10.createCylinder(0, 0.789f, 0.205f, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_10.rotate(castle_fence_10.objectCenter, Vector3.UnitZ, 90);
            castle_fence_11.createCylinder(0, 0.759f, -0.205f, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_11.rotate(castle_fence_11.objectCenter, Vector3.UnitZ, 90);
            castle_fence_12.createCylinder(0, 0.789f, -0.205f, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_12.rotate(castle_fence_12.objectCenter, Vector3.UnitZ, 90);
            castle_fence_13.createCylinder(-0.205f, 0.759f, 0, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_13.rotate(castle_fence_13.objectCenter, Vector3.UnitX, 90);
            castle_fence_14.createCylinder(-0.205f, 0.789f, 0, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_14.rotate(castle_fence_14.objectCenter, Vector3.UnitX, 90);
            castle_fence_15.createCylinder(0.205f, 0.759f, 0, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_15.rotate(castle_fence_15.objectCenter, Vector3.UnitX, 90);
            castle_fence_16.createCylinder(0.205f, 0.789f, 0, 0.015f, 0.1275f, 0.015f, 100, 100);
            castle_fence_16.rotate(castle_fence_16.objectCenter, Vector3.UnitX, 90);

            castle_connector_1.createCylinder(-0.205f, 0.7918f, 0.205f, 0.015f, 0.03f, 0.015f, 100, 100);
            castle_connector_2.createCylinder(0.205f, 0.7918f, 0.205f, 0.015f, 0.03f, 0.015f, 100, 100);
            castle_connector_3.createCylinder(-0.205f, 0.7918f, -0.205f, 0.015f, 0.03f, 0.015f, 100, 100);
            castle_connector_4.createCylinder(0.205f, 0.7918f, -0.205f, 0.015f, 0.03f, 0.015f, 100, 100);

            castle_connector_top1.createCone(-0.205f, 0.8885f, 0.205f, 0.015f, 0.05f, 0.015f, 500, 500);
            castle_connector_top1.rotate(castle_connector_top1.objectCenter, Vector3.UnitX, 180);
            castle_connector_top2.createCone(0.205f, 0.8885f, 0.205f, 0.015f, 0.05f, 0.015f, 500, 500);
            castle_connector_top2.rotate(castle_connector_top2.objectCenter, Vector3.UnitX, 180);
            castle_connector_top3.createCone(0.205f, 0.8885f, -0.205f, 0.015f, 0.05f, 0.015f, 500, 500);
            castle_connector_top3.rotate(castle_connector_top3.objectCenter, Vector3.UnitX, 180);
            castle_connector_top4.createCone(-0.205f, 0.8885f, -0.205f, 0.015f, 0.05f, 0.015f, 500, 500);
            castle_connector_top4.rotate(castle_connector_top4.objectCenter, Vector3.UnitX, 180);

            castle_top_body.createCylinder(0, 0.88f, 0, 0.085f, 0.085f, 0.085f, 500, 500);
            castle_top_roof.createCone(0, 1.212f, 0, 0.125f, 0.2f, 0.125f, 500, 500);
            castle_top_roof.rotate(castle_top_roof.objectCenter, Vector3.UnitX, 180);
            castle_top_ring.createTorus(0, 0.75f, 0, 0.09f, 0.005f, 100, 100);
            castle_top_door.createBlock(0, 0.795f, 0.05755f, 0.075f, 0.15f);

            // Tower 1
            tower1_bottom_part.createCylinder(-0.35f, 0.0125f, 0.4f, 0.1325f, 0.02f, 0.1325f, 100, 100);
            tower1_body_structure.createHyperboloid1(-0.35f, 0.2f, 0.4f, 0.085f, 0.1f, 0.085f, 500, 500);
            tower1_body.createCylinder(-0.35f, 0.2f, 0.4f, 0.085f, 0.085f, 0.085f, 500, 500);
            tower1_upper_ring.createTorus(-0.35f, 0.3f, 0.4f, 0.09f, 0.005f, 100, 100);
            tower1_lower_ring.createTorus(-0.35f, 0.1f, 0.4f, 0.09f, 0.005f, 100, 100);
            tower1_upper_part.createCylinder(-0.35f, 0.385f, 0.4f, 0.1345f, 0.02f, 0.1345f, 100, 100);
            tower1_roof.createEllipticParaboloid(-0.35f, 0.595f, 0.4f, 0.09f, 0.09f, 0.075f, 500, 500);
            tower1_roof.rotate(tower1_roof.objectCenter, Vector3.UnitX, 90);
            tower1_pole.createCylinder(-0.35f, 0.65f, 0.4f, 0.005f, 0.035f, 0.005f, 100, 100);
            tower1_pole_ball.createEllipsoid(-0.35f, 0.7f, 0.4f, 0.015f, 0.015f, 0.015f, 100, 100);
            tower1_banner.createCone(-0.245f, 0.64f, 0.4f, 0.0455f, 0.1f, 0.005f, 500, 500);
            tower1_banner.rotate(tower1_banner.objectCenter, Vector3.UnitZ, 90);

            // Tower 2
            tower2_bottom_part.createCylinder(0.35f, 0.0125f, 0.4f, 0.1325f, 0.02f, 0.1325f, 100, 100);
            tower2_body_structure.createHyperboloid1(0.35f, 0.2f, 0.4f, 0.085f, 0.1f, 0.085f, 500, 500);
            tower2_body.createCylinder(0.35f, 0.2f, 0.4f, 0.085f, 0.085f, 0.085f, 500, 500);
            tower2_upper_ring.createTorus(0.35f, 0.3f, 0.4f, 0.09f, 0.005f, 100, 100);
            tower2_lower_ring.createTorus(0.35f, 0.1f, 0.4f, 0.09f, 0.005f, 100, 100);
            tower2_upper_part.createCylinder(0.35f, 0.385f, 0.4f, 0.1345f, 0.02f, 0.1345f, 100, 100);
            tower2_roof.createEllipticParaboloid(0.35f, 0.595f, 0.4f, 0.09f, 0.09f, 0.075f, 500, 500);
            tower2_roof.rotate(tower2_roof.objectCenter, Vector3.UnitX, 90);
            tower2_pole.createCylinder(0.35f, 0.65f, 0.4f, 0.005f, 0.035f, 0.005f, 100, 100);
            tower2_pole_ball.createEllipsoid(0.35f, 0.7f, 0.4f, 0.015f, 0.015f, 0.015f, 100, 100);
            tower2_banner.createCone(0.455f, 0.64f, 0.4f, 0.0455f, 0.1f, 0.005f, 500, 500);
            tower2_banner.rotate(tower2_banner.objectCenter, Vector3.UnitZ, 90);

            // Tower 3
            tower3_bottom_part.createCylinder(0.35f, 0.0125f, -0.4f, 0.1325f, 0.02f, 0.1325f, 100, 100);
            tower3_body_structure.createHyperboloid1(0.35f, 0.2f, -0.4f, 0.085f, 0.1f, 0.085f, 500, 500);
            tower3_body.createCylinder(0.35f, 0.2f, -0.4f, 0.085f, 0.085f, 0.085f, 500, 500);
            tower3_upper_ring.createTorus(0.35f, 0.3f, -0.4f, 0.09f, 0.005f, 100, 100);
            tower3_lower_ring.createTorus(0.35f, 0.1f, -0.4f, 0.09f, 0.005f, 100, 100);
            tower3_upper_part.createCylinder(0.35f, 0.385f, -0.4f, 0.1345f, 0.02f, 0.1345f, 100, 100);
            tower3_roof.createEllipticParaboloid(0.35f, 0.595f, -0.4f, 0.09f, 0.09f, 0.075f, 500, 500);
            tower3_roof.rotate(tower3_roof.objectCenter, Vector3.UnitX, 90);
            tower3_pole.createCylinder(0.35f, 0.65f, -0.4f, 0.005f, 0.035f, 0.005f, 100, 100);
            tower3_pole_ball.createEllipsoid(0.35f, 0.7f, -0.4f, 0.015f, 0.015f, 0.015f, 100, 100);
            tower3_banner.createCone(0.455f, 0.64f, -0.4f, 0.0455f, 0.1f, 0.005f, 500, 500);
            tower3_banner.rotate(tower3_banner.objectCenter, Vector3.UnitZ, 90);

            // Tower 4
            tower4_bottom_part.createCylinder(-0.35f, 0.0125f, -0.4f, 0.1325f, 0.02f, 0.1325f, 100, 100);
            tower4_body_structure.createHyperboloid1(-0.35f, 0.2f, -0.4f, 0.085f, 0.1f, 0.085f, 500, 500);
            tower4_body.createCylinder(-0.35f, 0.2f, -0.4f, 0.085f, 0.085f, 0.085f, 500, 500);
            tower4_upper_ring.createTorus(-0.35f, 0.3f, -0.4f, 0.09f, 0.005f, 100, 100);
            tower4_lower_ring.createTorus(-0.35f, 0.1f, -0.4f, 0.09f, 0.005f, 100, 100);
            tower4_upper_part.createCylinder(-0.35f, 0.385f, -0.4f, 0.1345f, 0.02f, 0.1345f, 100, 100);
            tower4_roof.createEllipticParaboloid(-0.35f, 0.595f, -0.4f, 0.09f, 0.09f, 0.075f, 500, 500);
            tower4_roof.rotate(tower4_roof.objectCenter, Vector3.UnitX, 90);
            tower4_pole.createCylinder(-0.35f, 0.65f, -0.4f, 0.005f, 0.035f, 0.005f, 100, 100);
            tower4_pole_ball.createEllipsoid(-0.35f, 0.7f, -0.4f, 0.015f, 0.015f, 0.015f, 100, 100);
            tower4_banner.createCone(-0.245f, 0.64f, -0.4f, 0.0455f, 0.1f, 0.005f, 500, 500);
            tower4_banner.rotate(tower4_banner.objectCenter, Vector3.UnitZ, 90);

            // ===== ADD OBJECT =====
            // Island
            object3d.Add(lower_bottom_face);
            object3d.Add(lower_island);
            object3d.Add(upper_island);
            object3d.Add(upper_top_face);

            // Path
            object3d.Add(path1);
            object3d.Add(path2);
            object3d.Add(path3);
            object3d.Add(path4);
            object3d.Add(path5);
            object3d.Add(path6);

            // Tower 1
            object3d.Add(tower1_bottom_part);
            object3d.Add(tower1_body_structure);
            object3d.Add(tower1_body);
            object3d.Add(tower1_upper_ring);
            object3d.Add(tower1_lower_ring);
            object3d.Add(tower1_upper_part);
            object3d.Add(tower1_roof);
            object3d.Add(tower1_pole);
            object3d.Add(tower1_pole_ball);
            object3d.Add(tower1_banner);

            // Tower 2
            object3d.Add(tower2_bottom_part);
            object3d.Add(tower2_body_structure);
            object3d.Add(tower2_body);
            object3d.Add(tower2_upper_ring);
            object3d.Add(tower2_lower_ring);
            object3d.Add(tower2_upper_part);
            object3d.Add(tower2_roof);
            object3d.Add(tower2_pole);
            object3d.Add(tower2_pole_ball);
            object3d.Add(tower2_banner);

            // Tower 3
            object3d.Add(tower3_bottom_part);
            object3d.Add(tower3_body_structure);
            object3d.Add(tower3_body);
            object3d.Add(tower3_upper_ring);
            object3d.Add(tower3_lower_ring);
            object3d.Add(tower3_upper_part);
            object3d.Add(tower3_roof);
            object3d.Add(tower3_pole);
            object3d.Add(tower3_pole_ball);
            object3d.Add(tower3_banner);

            // Tower 4
            object3d.Add(tower4_bottom_part);
            object3d.Add(tower4_body_structure);
            object3d.Add(tower4_body);
            object3d.Add(tower4_upper_ring);
            object3d.Add(tower4_lower_ring);
            object3d.Add(tower4_upper_part);
            object3d.Add(tower4_roof);
            object3d.Add(tower4_pole);
            object3d.Add(tower4_pole_ball);
            object3d.Add(tower4_banner);

            // Trees
            object3d.Add(tree1_log);
            object3d.Add(tree1_bot_leaves);
            object3d.Add(tree1_mid_leaves);
            object3d.Add(tree1_top_leaves);
            object3d.Add(tree2_log);
            object3d.Add(tree2_bot_leaves);
            object3d.Add(tree2_mid_leaves);
            object3d.Add(tree2_top_leaves);
            object3d.Add(tree3_log);
            object3d.Add(tree3_bot_leaves);
            object3d.Add(tree3_mid_leaves);
            object3d.Add(tree3_top_leaves);
            object3d.Add(tree4_log);
            object3d.Add(tree4_bot_leaves);
            object3d.Add(tree4_mid_leaves);
            object3d.Add(tree4_top_leaves);
            object3d.Add(tree5_log);
            object3d.Add(tree5_bot_leaves);
            object3d.Add(tree5_mid_leaves);
            object3d.Add(tree5_top_leaves);
            object3d.Add(tree6_log);
            object3d.Add(tree6_bot_leaves);
            object3d.Add(tree6_mid_leaves);
            object3d.Add(tree6_top_leaves);

            // Castle
            object3d.Add(castle_body_1);
            object3d.Add(castle_body_2);
            object3d.Add(castle_body_3);
            object3d.Add(castle_body_4);
            object3d.Add(castle_middle_body);
            object3d.Add(castle_middle_door1);
            object3d.Add(castle_middle_door2);
            object3d.Add(castle_fence_1);
            object3d.Add(castle_fence_2);
            object3d.Add(castle_fence_3);
            object3d.Add(castle_fence_4);
            object3d.Add(castle_fence_5);
            object3d.Add(castle_fence_6);
            object3d.Add(castle_fence_7);
            object3d.Add(castle_fence_8);
            object3d.Add(castle_front_door);
            object3d.Add(castle_fence_9);
            object3d.Add(castle_fence_10);
            object3d.Add(castle_fence_11);
            object3d.Add(castle_fence_12);
            object3d.Add(castle_fence_13);
            object3d.Add(castle_fence_14);
            object3d.Add(castle_fence_15);
            object3d.Add(castle_fence_16);
            object3d.Add(castle_connector_1);
            object3d.Add(castle_connector_2);
            object3d.Add(castle_connector_3);
            object3d.Add(castle_connector_4);
            object3d.Add(castle_connector_top1);
            object3d.Add(castle_connector_top2);
            object3d.Add(castle_connector_top3);
            object3d.Add(castle_connector_top4);
            object3d.Add(castle_top_body);
            object3d.Add(castle_top_roof);
            object3d.Add(castle_top_ring);
            object3d.Add(castle_top_door);

            // menambahkan shaders ke setiap objek yang ada
            // Load kastil dan environment
            foreach (Asset3d i in object3d)
            {
                i.load(x, y);
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

            // Render kastil dan environment
            foreach (Asset3d i in object3d)
            {
                //// Rotate ke kanan
                //if (input.IsKeyDown(Keys.Z))
                //{
                //    i.rotate(Vector3.Zero, Vector3.UnitY, 2.5f);
                //}

                //// Rotate ke kiri
                //if (input.IsKeyDown(Keys.X))
                //{
                //    i.rotate(Vector3.Zero, Vector3.UnitY, -2.5f);
                //}

                i.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                //i.rotate(Vector3.Zero, Vector3.UnitY, 25 * time);

                // Rotate setiap child dari objek
                foreach (Asset3d j in i.child)
                {
                    j.rotate(Vector3.Zero, Vector3.UnitY, 720 * time);
                }
            }

            // Render objek 2D
            foreach (Asset2d i in object2d)
            {
                i.render(0, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            //if (object2d[0].getVerticesLength())
            //{
            //    List<float> _verticesTemp = object2d[0].createCurveBezier();
            //    object2d[1].setVertices(_verticesTemp.ToArray());
            //    //object2d[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            //    object2d[1].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //}
            //object2d[0].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
    }
}
