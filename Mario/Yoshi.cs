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

    internal class Yoshi
    {
        List<List<Asset3d>> objectListYoshi = new List<List<Asset3d>>();

        List<Asset3d> swing = new List<Asset3d>();
        List<Asset3d> tree = new List<Asset3d>();
        List<Asset3d> head = new List<Asset3d>();
        List<Asset3d> body = new List<Asset3d>();
        List<Asset3d> left_arm = new List<Asset3d>();
        List<Asset3d> right_arm = new List<Asset3d>();
        List<Asset3d> left_leg = new List<Asset3d>();
        List<Asset3d> right_leg = new List<Asset3d>();

        List<Asset2d> object2d = new List<Asset2d>();

        double _time;
        float degr = 0;
        Camera _camera;

        int counter = 0;
        bool move_backward = true;

        // constructor
        public Yoshi()
        {

        }

        // fungsi untuk load objek-objek
        public void load(int x, int y)
        {
            // ===== INITIALIZATION =====
            // Swing
            var swing_ring1 = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var swing_ring2 = new Asset3d(new Vector3(0.55f, 0.55f, 0.55f));
            var swing_rope1 = new Asset3d(new Vector3(0.5f, 0.35f, 0.055f));
            var swing_rope2 = new Asset3d(new Vector3(0.5f, 0.35f, 0.055f));
            var swing_chair = new Asset3d(new Vector3(0.5f, 0.45f, 0.075f));

            // Tree
            var tree7_log = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_branch_1 = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_branch_2 = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_branch_3 = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_branch_4 = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_branch_5 = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_branch_6 = new Asset3d(new Vector3(0.4f, 0.25f, 0.025f));
            var tree7_leaf_1 = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree7_leaf_2 = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree7_leaf_3 = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree7_leaf_4 = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));
            var tree7_leaf_5 = new Asset3d(new Vector3(0.25f, 0.75f, 0.45f));

            // Yoshi
            // Head
            var lower_head = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var upper_head = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var spike_1 = new Asset3d(new Vector3(1.0f, 0.25f, 0.0f));
            var spike_2 = new Asset3d(new Vector3(1.0f, 0.25f, 0.0f));
            var spike_3 = new Asset3d(new Vector3(1.0f, 0.25f, 0.0f));

            // Eyes
            var eyelid_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var eyelid_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var top_eyelid_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var top_eyelid_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_eyeball = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var right_eyeball = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var left_iris = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));
            var right_iris = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));
            var left_pupil = new Asset3d(new Vector3(0.0f, 0.5f, 1.0f));
            var right_pupil = new Asset3d(new Vector3(0.0f, 0.5f, 1.0f));

            // Mouth
            var mouth = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));

            // Nose 
            var nose = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_nostril = new Asset3d(new Vector3(0.25f, 0.25f, 0.25f));
            var right_nostril = new Asset3d(new Vector3(0.25f, 0.25f, 0.25f));

            // Body
            var inner_body_1 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var inner_body_2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var outter_body_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var outter_body_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var inner_shell = new Asset3d(new Vector3(1.0f, 0.25f, 0.0f));
            var outer_shell_1 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var outer_shell_2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));

            // Tail
            var tail = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));

            // Leg
            var left_leg_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_leg_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_leg_3 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_knee = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_leg_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_leg_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_leg_3 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_knee = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));

            // Shoes
            var left_shoes_1 = new Asset3d(new Vector3(0.7f, 0.55f, 0.25f));
            var left_shoes_2 = new Asset3d(new Vector3(0.7f, 0.55f, 0.25f));
            var left_shoes_ring = new Asset3d(new Vector3(0.7f, 0.55f, 0.25f));
            var right_shoes_1 = new Asset3d(new Vector3(0.7f, 0.55f, 0.25f));
            var right_shoes_2 = new Asset3d(new Vector3(0.7f, 0.55f, 0.25f));
            var right_shoes_ring = new Asset3d(new Vector3(0.7f, 0.55f, 0.25f));

            // Arms + Hands
            var left_shoulder = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_arm_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_arm_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_elbow = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var left_hand = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_shoulder = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_arm_1 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_arm_2 = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_elbow = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));
            var right_hand = new Asset3d(new Vector3(0.3f, 0.85f, 0.4f));

            // ===== CREATE OBJECT =====
            // Swing
            swing_ring1.createTorus(-0.0525f, 0.249f, -0.475f, 0.0125f, 0.0045f, 100, 100);
            swing_ring1.rotate(swing_ring1.objectCenter, Vector3.UnitZ, 90);
            swing_ring2.createTorus(-0.1475f, 0.249f, -0.475f, 0.0125f, 0.0045f, 100, 100);
            swing_ring2.rotate(swing_ring2.objectCenter, Vector3.UnitZ, 90);
            swing_rope1.createCylinder(-0.0525f, 0.14f, -0.475f, 0.0035f, 0.065f, 0.0035f, 100, 100);
            swing_rope2.createCylinder(-0.1475f, 0.14f, -0.475f, 0.0035f, 0.065f, 0.0035f, 100, 100);
            swing_chair.createBlock2(-0.1f, 0.0375f, -0.475f, 0.125f, 0.015f, 0.025f);

            // Tree
            tree7_log.createCylinder(0, 0.175f, -0.475f, 0.02f, 0.125f, 0.02f, 100, 100);
            tree7_branch_1.createCylinder(0.045f, 0.305f, -0.475f, 0.0075f, 0.045f, 0.0075f, 100, 100);
            tree7_branch_1.rotate(tree7_branch_1.objectCenter, Vector3.UnitZ, 150);
            tree7_branch_2.createCylinder(-0.04f, 0.332f, -0.475f, 0.0075f, 0.025f, 0.0075f, 100, 100);
            tree7_branch_2.rotate(tree7_branch_2.objectCenter, Vector3.UnitZ, -140);
            tree7_branch_3.createCylinder(0.045f, 0.175f, -0.475f, 0.0075f, 0.025f, 0.0075f, 100, 100);
            tree7_branch_3.rotate(tree7_branch_3.objectCenter, Vector3.UnitZ, 130);
            tree7_branch_4.createCylinder(-0.0275f, 0.225f, -0.475f, 0.009f, 0.02f, 0.009f, 100, 100);
            tree7_branch_4.rotate(tree7_branch_4.objectCenter, Vector3.UnitZ, -150);
            tree7_branch_5.createCylinder(-0.1075f, 0.249f, -0.475f, 0.009f, 0.045f, 0.009f, 100, 100);
            tree7_branch_5.rotate(tree7_branch_5.objectCenter, Vector3.UnitZ, 90);
            tree7_branch_6.createCylinder(-0.125f, 0.275f, -0.475f, 0.0075f, 0.015f, 0.0075f, 100, 100);
            tree7_branch_6.rotate(tree7_branch_6.objectCenter, Vector3.UnitZ, -150);
            tree7_leaf_1.createEllipsoid(0, 0.405f, -0.475f, 0.2f, 0.075f, 0.125f, 100, 100);
            tree7_leaf_2.createEllipsoid(0.0755f, 0.185f, -0.475f, 0.055f, 0.025f, 0.02f, 100, 100);
            tree7_leaf_3.createEllipsoid(-0.145f, 0.295f, -0.475f, 0.075f, 0.03f, 0.04f, 100, 100);
            tree7_leaf_4.createEllipsoid(0.09f, 0.325f, -0.475f, 0.08f, 0.025f, 0.04f, 100, 100);
            tree7_leaf_5.createEllipsoid(-0.185f, 0.249f, -0.475f, 0.025f, 0.025f, 0.025f, 100, 100);

            // Yoshi
            // Head
            lower_head.createEllipsoid(-0.1f, 0.1175f, -0.47f, 0.0255f, 0.0175f, 0.025f, 100, 100);
            upper_head.createEllipsoid(-0.1f, 0.12475f, -0.47f, 0.0185f, 0.0255f, 0.0285f, 100, 100);
            spike_1.createEllipticParaboloid(-0.1f, 0.1535f, -0.45f, 0.0025f, 0.0055f, 0.0045f, 100, 100);
            spike_1.rotate(spike_1.objectCenter, Vector3.UnitX, 117.5f);
            spike_2.createEllipticParaboloid(-0.1f, 0.1375f, -0.4355f, 0.0025f, 0.0055f, 0.0045f, 100, 100);
            spike_2.rotate(spike_2.objectCenter, Vector3.UnitX, 155);
            spike_3.createEllipticParaboloid(-0.1f, 0.115f, -0.4355f, 0.0025f, 0.0055f, 0.0045f, 100, 100);
            spike_3.rotate(spike_3.objectCenter, Vector3.UnitX, 200);

            // Eyes
            eyelid_1.createCylinder(-0.095f, 0.1465f, -0.47f, 0.0075f, 0.0085f, 0.0075f, 100, 100);
            eyelid_2.createCylinder(-0.105f, 0.1465f, -0.47f, 0.0075f, 0.0085f, 0.0075f, 100, 100);
            top_eyelid_1.createEllipticParaboloid(-0.095f, 0.1665f, -0.47f, 0.0048f, 0.0048f, 0.00275f, 100, 100);
            top_eyelid_1.rotate(top_eyelid_1.objectCenter, Vector3.UnitX, 90);
            top_eyelid_2.createEllipticParaboloid(-0.105f, 0.1665f, -0.47f, 0.0048f, 0.0048f, 0.00275f, 100, 100);
            top_eyelid_2.rotate(top_eyelid_2.objectCenter, Vector3.UnitX, 90);
            left_eyeball.createEllipsoid(-0.095f, 0.1515f, -0.475f, 0.0055f, 0.0085f, 0.0055f, 100, 100);
            right_eyeball.createEllipsoid(-0.105f, 0.1515f, -0.475f, 0.0055f, 0.0085f, 0.0055f, 100, 100);
            left_iris.createEllipsoid(-0.095f, 0.1515f, -0.4775f, 0.0035f, 0.0055f, 0.0035f, 100, 100);
            right_iris.createEllipsoid(-0.105f, 0.1515f, -0.4775f, 0.0035f, 0.0055f, 0.0035f, 100, 100);
            left_pupil.createEllipsoid(-0.095f, 0.15f, -0.48f, 0.0015f, 0.0015f, 0.0015f, 100, 100);
            right_pupil.createEllipsoid(-0.105f, 0.15f, -0.48f, 0.0015f, 0.0015f, 0.0015f, 100, 100);

            // Mouth
            mouth.createEllipsoid(-0.1f, 0.10675f, -0.473f, 0.0135f, 0.00685f, 0.02f, 100, 100);

            // Nose
            nose.createEllipsoid(-0.1f, 0.1315f, -0.49f, 0.0225f, 0.0225f, 0.0225f, 100, 100);
            left_nostril.createEllipsoid(-0.095f, 0.15f, -0.5f, 0.0015f, 0.0015f, 0.0015f, 100, 100);
            right_nostril.createEllipsoid(-0.105f, 0.15f, -0.5f, 0.0015f, 0.0015f, 0.0015f, 100, 100);

            // Body
            inner_body_1.createEllipsoid(-0.1f, 0.065f, -0.475f, 0.01875f, 0.01875f, 0.01875f, 100, 100);
            inner_body_2.createEllipticParaboloid(-0.1f, 0.1035f, -0.475f, 0.01155f, 0.01155f, 0.0135f, 100, 100);
            inner_body_2.rotate(inner_body_2.objectCenter, Vector3.UnitX, 90);
            outter_body_1.createEllipsoid(-0.1f, 0.065f, -0.47f, 0.0215f, 0.0215f, 0.0215f, 100, 100);
            outter_body_2.createEllipticParaboloid(-0.1f, 0.1045f, -0.47f, 0.01245f, 0.01245f, 0.01245f, 100, 100);
            outter_body_2.rotate(outter_body_2.objectCenter, Vector3.UnitX, 90);
            inner_shell.createEllipticParaboloid(-0.1f, 0.0925f, -0.4515f, 0.0085f, 0.0085f, 0.0055f, 100, 100);
            inner_shell.rotate(inner_shell.objectCenter, Vector3.UnitX, 150);
            outer_shell_1.createTorus(-0.1f, 0.0865f, -0.461f, 0.012f, 0.0015f, 100, 100);
            outer_shell_1.rotate(outer_shell_1.objectCenter, Vector3.UnitX, 32.5f);
            outer_shell_2.createTorus(-0.1f, 0.0855f, -0.465f, 0.012f, 0.0015f, 100, 100);
            outer_shell_2.rotate(outer_shell_2.objectCenter, Vector3.UnitX, -72.5f);

            // Tail
            tail.createEllipticParaboloid(-0.1f, 0.05f, -0.425f, 0.01125f, 0.01125f, 0.0145f, 100, 100);
            tail.rotate(tail.objectCenter, Vector3.UnitX, 200);

            // Leg
            left_leg_1.createEllipticParaboloid(-0.085f, 0.05f, -0.465f, 0.0055f, 0.0055f, 0.0075f, 100, 100);
            left_leg_1.rotate(left_leg_1.objectCenter, Vector3.UnitY, 180);
            left_leg_2.createCylinder(-0.085f, 0.05f, -0.49f, 0.0085f, 0.0045f, 0.0085f, 100, 100);
            left_leg_2.rotate(left_leg_2.objectCenter, Vector3.UnitX, 90);
            left_leg_3.createCylinder(-0.085f, 0.0415f, -0.495f, 0.0075f, 0.0055f, 0.0075f, 100, 100);
            left_knee.createEllipsoid(-0.085f, 0.05f, -0.495f, 0.0085f, 0.0085f, 0.0085f, 100, 100);

            right_leg_1.createEllipticParaboloid(-0.115f, 0.05f, -0.465f, 0.0055f, 0.0055f, 0.0075f, 100, 100);
            right_leg_1.rotate(right_leg_1.objectCenter, Vector3.UnitY, 180);
            right_leg_2.createCylinder(-0.115f, 0.05f, -0.49f, 0.0085f, 0.0045f, 0.0085f, 100, 100);
            right_leg_2.rotate(right_leg_2.objectCenter, Vector3.UnitX, 90);
            right_leg_3.createCylinder(-0.115f, 0.0415f, -0.495f, 0.0075f, 0.0055f, 0.0075f, 100, 100);
            right_knee.createEllipsoid(-0.115f, 0.05f, -0.495f, 0.0085f, 0.0085f, 0.0085f, 100, 100);

            // Shoes
            left_shoes_1.createCylinder(-0.085f, 0.025f, -0.495f, 0.008f, 0.0045f, 0.008f, 100, 100);
            left_shoes_2.createEllipsoid(-0.085f, 0.025f, -0.51f, 0.0085f, 0.0085f, 0.0105f, 100, 100);
            left_shoes_ring.createTorus(-0.085f, 0.0325f, -0.495f, 0.009f, 0.0015f, 100, 100);

            right_shoes_1.createCylinder(-0.115f, 0.025f, -0.495f, 0.008f, 0.0045f, 0.008f, 100, 100);
            right_shoes_2.createEllipsoid(-0.115f, 0.025f, -0.51f, 0.0085f, 0.0085f, 0.0105f, 100, 100);
            right_shoes_ring.createTorus(-0.115f, 0.0325f, -0.495f, 0.009f, 0.0015f, 100, 100);

            // Hands + Arms
            left_shoulder.createEllipticParaboloid(-0.095f, 0.1f, -0.465f, 0.0055f, 0.0055f, 0.0075f, 100, 100);
            left_shoulder.rotate(left_shoulder.objectCenter, Vector3.UnitY, 90);
            left_shoulder.rotate(left_shoulder.objectCenter, Vector3.UnitZ, -45);
            left_shoulder.rotate(left_shoulder.objectCenter, Vector3.UnitX, -25);
            left_arm_1.createCylinder(-0.0775f, 0.084135f, -0.4575f, 0.0085f, 0.0045f, 0.0085f, 100, 100);
            left_arm_1.rotate(left_arm_1.objectCenter, Vector3.UnitZ, 45);
            left_arm_1.rotate(left_arm_1.objectCenter, Vector3.UnitX, -25);
            left_elbow.createEllipsoid(-0.0715f, 0.07875f, -0.45525f, 0.0085f, 0.0085f, 0.0085f, 100, 100);
            left_arm_2.createCylinder(-0.0665f, 0.0845f, -0.4645f, 0.0075f, 0.0095f, 0.0075f, 100, 100);
            left_arm_2.rotate(left_arm_2.objectCenter, Vector3.UnitX, -45);
            left_arm_2.rotate(left_arm_2.objectCenter, Vector3.UnitZ, -45);
            left_hand.createEllipsoid(-0.0575f, 0.0935f, -0.475f, 0.0085f, 0.0085f, 0.0085f, 100, 100);

            right_shoulder.createEllipticParaboloid(-0.105f, 0.1f, -0.465f, 0.0055f, 0.0055f, 0.0075f, 100, 100);
            right_shoulder.rotate(right_shoulder.objectCenter, Vector3.UnitY, -90);
            right_shoulder.rotate(right_shoulder.objectCenter, Vector3.UnitZ, 45);
            right_shoulder.rotate(right_shoulder.objectCenter, Vector3.UnitX, -25);
            right_arm_1.createCylinder(-0.1225f, 0.084135f, -0.4575f, 0.0085f, 0.0045f, 0.0085f, 100, 100);
            right_arm_1.rotate(right_arm_1.objectCenter, Vector3.UnitZ, -45);
            right_arm_1.rotate(right_arm_1.objectCenter, Vector3.UnitX, -25);
            right_elbow.createEllipsoid(-0.12825f, 0.07875f, -0.45525f, 0.0085f, 0.0085f, 0.0085f, 100, 100);
            right_arm_2.createCylinder(-0.135f, 0.0845f, -0.4645f, 0.0075f, 0.0095f, 0.0075f, 100, 100);
            right_arm_2.rotate(right_arm_2.objectCenter, Vector3.UnitX, -45);
            right_arm_2.rotate(right_arm_2.objectCenter, Vector3.UnitZ, 45);
            right_hand.createEllipsoid(-0.1425f, 0.0935f, -0.475f, 0.0085f, 0.0085f, 0.0085f, 100, 100);


            // ===== ADD OBJECT =====
            // Yoshi
            // Head
            head.Add(lower_head);
            head.Add(upper_head);
            head.Add(spike_1);
            head.Add(spike_2);
            head.Add(spike_3);

            // Eyes
            head.Add(eyelid_1);
            head.Add(eyelid_2);
            head.Add(top_eyelid_1);
            head.Add(top_eyelid_2);
            head.Add(left_eyeball);
            head.Add(right_eyeball);
            head.Add(left_iris);
            head.Add(right_iris);
            head.Add(left_pupil);
            head.Add(right_pupil);

            // Mouth
            head.Add(mouth);

            // Nose
            head.Add(nose);
            head.Add(left_nostril);
            head.Add(right_nostril);

            // Body
            body.Add(inner_body_1);
            body.Add(inner_body_2);
            body.Add(outter_body_1);
            body.Add(outter_body_2);
            body.Add(inner_shell);
            body.Add(outer_shell_1);
            body.Add(outer_shell_2);

            // Tail
            body.Add(tail);

            // Leg
            left_leg.Add(left_leg_1);
            left_leg.Add(left_leg_2);
            left_leg.Add(left_leg_3);
            left_leg.Add(left_knee);
            right_leg.Add(right_leg_1);
            right_leg.Add(right_leg_2);
            right_leg.Add(right_leg_3);
            right_leg.Add(right_knee);

            // Shoes
            left_leg.Add(left_shoes_1);
            left_leg.Add(left_shoes_2);
            left_leg.Add(left_shoes_ring);
            right_leg.Add(right_shoes_1);
            right_leg.Add(right_shoes_2);
            right_leg.Add(right_shoes_ring);

            // Hands + Arms
            left_arm.Add(left_shoulder);
            left_arm.Add(left_arm_1);
            left_arm.Add(left_arm_2);
            left_arm.Add(left_elbow);
            left_arm.Add(left_hand);

            right_arm.Add(right_shoulder);
            right_arm.Add(right_arm_1);
            right_arm.Add(right_arm_2);
            right_arm.Add(right_elbow);
            right_arm.Add(right_hand);

            // Swing
            swing.Add(swing_ring1);
            swing.Add(swing_ring2);
            swing.Add(swing_rope1);
            swing.Add(swing_rope2);
            swing.Add(swing_chair);

            // Tree
            tree.Add(tree7_log);
            tree.Add(tree7_branch_1);
            tree.Add(tree7_branch_2);
            tree.Add(tree7_branch_3);
            tree.Add(tree7_branch_4);
            tree.Add(tree7_branch_5);
            tree.Add(tree7_branch_6);
            tree.Add(tree7_leaf_1);
            tree.Add(tree7_leaf_2);
            tree.Add(tree7_leaf_3);
            tree.Add(tree7_leaf_4);
            tree.Add(tree7_leaf_5);

            objectListYoshi.Add(head);
            objectListYoshi.Add(body);
            objectListYoshi.Add(left_arm);
            objectListYoshi.Add(right_arm);
            objectListYoshi.Add(left_leg);
            objectListYoshi.Add(right_leg);
            objectListYoshi.Add(swing);

            // menambahkan shaders ke setiap objek yang ada
            // Load tree
            foreach (Asset3d i in tree)
            {
                i.load(x, y);
            }

            // Load Yoshi dan Swing
            foreach (List<Asset3d> i in objectListYoshi)
            {
                foreach (Asset3d j in i)
                {
                    j.load(x, y);
                }
            }

            // Load objek 2D
            foreach (Asset2d i in object2d)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", x, y);
            }

            // rotasi objek sebesar 180 derajat
            //foreach (Asset3d i in tree)
            //{
            //    i.rotate(Vector3.Zero, Vector3.UnitY, 180);
            //}
            //foreach (List<Asset3d> i in objectListYoshi)
            //{
            //    foreach (Asset3d j in i)
            //    {
            //        j.rotate(Vector3.Zero, Vector3.UnitY, 180);
            //    }
            //}
        }

        // fungsi untuk render objek-objek
        public void render(FrameEventArgs args, Camera _camera, KeyboardState input)
        {
            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi
            //Console.WriteLine(time);
            // Render Yoshi dan Swing dengan animasi
            foreach (List<Asset3d> i in objectListYoshi)
            {
                // animasi mengayun ke belakang menggunakan rotate
                if (counter < 660 && move_backward)
                {
                    counter += 1;
                    foreach (Asset3d j in i)
                    {
                        j.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                        j.rotate(tree[5].objectCenter, Vector3.UnitX, 15 * 0.025f);
                        //j.rotate(Vector3.Zero, Vector3.UnitY, 25 * time);
                        foreach (Asset3d k in j.child)
                        {
                            k.rotate(Vector3.Zero, Vector3.UnitY, 720 * 500);
                        }
                    }
                }
                // animasi mengayun ke depan menggunakan rotate
                else
                {
                    move_backward = false;
                    if (counter > -660 && !move_backward)
                    {
                        counter -= 1;

                        foreach (Asset3d j in i)
                        {
                            j.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                            j.rotate(tree[5].objectCenter, Vector3.UnitX, -15 * 0.025f);
                            //j.rotate(Vector3.Zero, Vector3.UnitY, 25 * time);
                            foreach (Asset3d k in j.child)
                            {
                                k.rotate(Vector3.Zero, Vector3.UnitY, 720 * 500);
                            }
                        }
                    }
                    else
                    {
                        move_backward = true;
                    }
                }
            }

            // Render Yoshi dan Swing tanpa animasi
            //foreach (List<Asset3d> i in objectListYoshi)
            //{
            //    foreach (Asset3d j in i)
            //    {
            //        // Rotate ke kanan
            //        if (input.IsKeyDown(Keys.Z))
            //        {
            //            j.rotate(Vector3.Zero, Vector3.UnitY, 2.5f);
            //        }

            //        // Rotate ke kiri
            //        if (input.IsKeyDown(Keys.X))
            //        {
            //            j.rotate(Vector3.Zero, Vector3.UnitY, -2.5f);
            //        }

            //        j.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //        //j.rotate(tree[5].objectCenter, Vector3.UnitX, -15 * time);
            //        //j.rotate(Vector3.Zero, Vector3.UnitY, 25 * time);

            //        // Rotate setiap child dari objek
            //        foreach (Asset3d k in j.child)
            //        {
            //            k.rotate(Vector3.Zero, Vector3.UnitY, 720 * time);
            //        }
            //    }
            //}

            // Render tree
            foreach (Asset3d i in tree)
            {
                // Rotate ke kanan
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
        }
    }
}
