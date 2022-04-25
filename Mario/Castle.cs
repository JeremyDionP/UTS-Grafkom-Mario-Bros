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
    internal class Castle
    {
        List<List<Asset3d>> objectListCastle = new List<List<Asset3d>>();

        List<Asset3d> house = new List<Asset3d>();
        List<Asset3d> tower1 = new List<Asset3d>();
        List<Asset3d> tower2 = new List<Asset3d>();
        List<Asset3d> tower3 = new List<Asset3d>();
        List<Asset3d> tower4 = new List<Asset3d>();

        List<Asset2d> object2d = new List<Asset2d>();

        double _time;
        float degr = 0;
        Camera _camera;

        int counter = 0;
        bool rotate_to_left = true;

        // constructor
        public Castle()
        {

        }

        // fungsi untuk load objek-objek
        public void load(int x, int y)
        {
            // ===== INITIALIZATION =====
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

            var deco_banner_1 = new Asset3d(new Vector3(1.0f, 1.0f, 0.0f));
            var deco_banner_2 = new Asset3d(new Vector3(1.0f, 0.55f, 0.75f));
            var deco_banner_3 = new Asset3d(new Vector3(1.0f, 0.55f, 0.75f));
            var deco_banner_4 = new Asset3d(new Vector3(1.0f, 1.0f, 0.0f));
            var deco_banner_5 = new Asset3d(new Vector3(1.0f, 1.0f, 0.0f));
            var deco_banner_6 = new Asset3d(new Vector3(1.0f, 0.55f, 0.75f));
            var deco_banner_7 = new Asset3d(new Vector3(1.0f, 0.55f, 0.75f));

            var line_1 = new Asset2d(
                new Vector3(0.0f, 0.0f, 0.0f),
                new float[1080],
                new uint[] { }
            );
            object2d.Add(line_1);

            var curve_1 = new Asset2d(
                new Vector3(0.0f, 0.0f, 0.0f),
                new float[] { },
                new uint[] { }
            );
            object2d.Add(curve_1);

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
            // Castle
            castle_body_1.createCuboid(-0.165f, 0.165f, 0.165f, 0.35f);
            castle_body_2.createCuboid(0.165f, 0.165f, 0.165f, 0.35f);
            castle_body_3.createCuboid(0.165f, 0.165f, -0.165f, 0.35f);
            castle_body_4.createCuboid(-0.165f, 0.165f, -0.165f, 0.35f);
            castle_middle_body.createCuboid(0, 0.545f, 0, 0.4f);
            castle_middle_door1.createBlock2(0, 0.42f, 0.21f, 0.125f, 0.15f, 0.015f);
            castle_middle_door2.createBlock2(0, 0.42f, -0.21f, 0.125f, 0.15f, 0.015f);

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

            castle_front_door.createBlock2(0, 0.07f, 0.35f, 0.15f, 0.2f, 0.015f);

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

            deco_banner_1.createCone(0.0f, 0.2775f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_2.createCone(0.06f, 0.2785f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_2.rotate(deco_banner_2.objectCenter, Vector3.UnitZ, 4.5f);
            deco_banner_3.createCone(-0.06f, 0.2795f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_3.rotate(deco_banner_3.objectCenter, Vector3.UnitZ, -4.5f);
            deco_banner_4.createCone(0.12f, 0.2855f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_4.rotate(deco_banner_4.objectCenter, Vector3.UnitZ, 8.5f);
            deco_banner_5.createCone(-0.12f, 0.2875f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_5.rotate(deco_banner_5.objectCenter, Vector3.UnitZ, -8.5f);
            deco_banner_6.createCone(0.18f, 0.2985f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_6.rotate(deco_banner_6.objectCenter, Vector3.UnitZ, 14.5f);
            deco_banner_7.createCone(-0.18f, 0.2985f, 0.4f, 0.025f, 0.055f, 0.0f, 500, 500);
            deco_banner_7.rotate(deco_banner_7.objectCenter, Vector3.UnitZ, -12.5f);

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
            // Tower 1
            tower1.Add(tower1_bottom_part);
            tower1.Add(tower1_body_structure);
            tower1.Add(tower1_body);
            tower1.Add(tower1_upper_ring);
            tower1.Add(tower1_lower_ring);
            tower1.Add(tower1_upper_part);
            tower1.Add(tower1_roof);
            tower1.Add(tower1_pole);
            tower1.Add(tower1_pole_ball);
            tower1.Add(tower1_banner);

            // Tower 2
            tower2.Add(tower2_bottom_part);
            tower2.Add(tower2_body_structure);
            tower2.Add(tower2_body);
            tower2.Add(tower2_upper_ring);
            tower2.Add(tower2_lower_ring);
            tower2.Add(tower2_upper_part);
            tower2.Add(tower2_roof);
            tower2.Add(tower2_pole);
            tower2.Add(tower2_pole_ball);
            tower2.Add(tower2_banner);

            // Tower 3
            tower3.Add(tower3_bottom_part);
            tower3.Add(tower3_body_structure);
            tower3.Add(tower3_body);
            tower3.Add(tower3_upper_ring);
            tower3.Add(tower3_lower_ring);
            tower3.Add(tower3_upper_part);
            tower3.Add(tower3_roof);
            tower3.Add(tower3_pole);
            tower3.Add(tower3_pole_ball);
            tower3.Add(tower3_banner);

            // Tower 4
            tower4.Add(tower4_bottom_part);
            tower4.Add(tower4_body_structure);
            tower4.Add(tower4_body);
            tower4.Add(tower4_upper_ring);
            tower4.Add(tower4_lower_ring);
            tower4.Add(tower4_upper_part);
            tower4.Add(tower4_roof);
            tower4.Add(tower4_pole);
            tower4.Add(tower4_pole_ball);
            tower4.Add(tower4_banner);

            // Castle
            house.Add(castle_body_1);
            house.Add(castle_body_2);
            house.Add(castle_body_3);
            house.Add(castle_body_4);
            house.Add(castle_middle_body);
            house.Add(castle_middle_door1);
            house.Add(castle_middle_door2);
            house.Add(castle_fence_1);
            house.Add(castle_fence_2);
            house.Add(castle_fence_3);
            house.Add(castle_fence_4);
            house.Add(castle_fence_5);
            house.Add(castle_fence_6);
            house.Add(castle_fence_7);
            house.Add(castle_fence_8);
            house.Add(castle_front_door);
            house.Add(castle_fence_9);
            house.Add(castle_fence_10);
            house.Add(castle_fence_11);
            house.Add(castle_fence_12);
            house.Add(castle_fence_13);
            house.Add(castle_fence_14);
            house.Add(castle_fence_15);
            house.Add(castle_fence_16);
            house.Add(castle_connector_1);
            house.Add(castle_connector_2);
            house.Add(castle_connector_3);
            house.Add(castle_connector_4);
            house.Add(castle_connector_top1);
            house.Add(castle_connector_top2);
            house.Add(castle_connector_top3);
            house.Add(castle_connector_top4);
            house.Add(castle_top_body);
            house.Add(castle_top_roof);
            house.Add(castle_top_ring);
            house.Add(castle_top_door);
            house.Add(deco_banner_1);
            house.Add(deco_banner_2);
            house.Add(deco_banner_3);
            house.Add(deco_banner_4);
            house.Add(deco_banner_5);
            house.Add(deco_banner_6);
            house.Add(deco_banner_7);

            objectListCastle.Add(house);
            objectListCastle.Add(tower1);
            objectListCastle.Add(tower2);
            objectListCastle.Add(tower3);
            objectListCastle.Add(tower4);

            // menambahkan shaders ke setiap objek yang ada
            // Load kastil dan tower
            foreach (List<Asset3d> i in objectListCastle)
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

            // Add titik kurva bezier
            object2d[0].updateMousePos(-0.25f, 0.3725f);
            object2d[0].updateMousePos(0.05f, 0.185f);
            object2d[0].updateMousePos(0.1f, 0.135f);

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

            // Render kastil dan tower
            foreach (List<Asset3d> i in objectListCastle)
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

            // animasi bendera memutar pada tiang
            if (counter < 75 && rotate_to_left)
            {
                counter += 1;
                tower1[9].rotate(tower1[7].objectCenter, Vector3.UnitY, 15 * 0.05f);
                tower2[9].rotate(tower2[7].objectCenter, Vector3.UnitY, -15 * 0.05f);
                tower3[9].rotate(tower3[7].objectCenter, Vector3.UnitY, 15 * 0.05f);
                tower4[9].rotate(tower4[7].objectCenter, Vector3.UnitY, -15 * 0.05f);
            }
            // animasi bendera memutar pada tiang (reverse)
            else
            {
                rotate_to_left = false;
                if (counter > -75 && !rotate_to_left)
                {
                    counter -= 1;
                    tower1[9].rotate(tower1[7].objectCenter, Vector3.UnitY, -15 * 0.05f);
                    tower2[9].rotate(tower2[7].objectCenter, Vector3.UnitY, 15 * 0.05f);
                    tower3[9].rotate(tower3[7].objectCenter, Vector3.UnitY, -15 * 0.05f);
                    tower4[9].rotate(tower4[7].objectCenter, Vector3.UnitY, 15 * 0.05f);
                }
                else
                {
                    rotate_to_left = true;
                }
            }

            // Render kurva bezier
            if (object2d[0].getVerticesLength())
            {
                List<float> _verticesTemp = object2d[0].createCurveBezier(0.4f);
                object2d[1].setVertices(_verticesTemp.ToArray());
                object2d[1].load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
                object2d[1].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
            object2d[0].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
    }
}
