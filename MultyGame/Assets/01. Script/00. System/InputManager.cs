using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 마우스
    public static bool Key_MouseRight { get; private set; }
    public static bool Key_MouseLeft { get; private set; }

    // 특수
    public static bool Key_Shift { get; private set; }
    public static bool Key_Tap { get; private set; }

    // 키
    public static bool Key_Q { get; private set; }
    public static bool Key_W { get; private set; }
    public static bool Key_E { get; private set; }
    public static bool Key_R { get; private set; }
    public static bool Key_T { get; private set; }

    public static bool Key_A { get; private set; }
    public static bool Key_S { get; private set; }
    public static bool Key_D { get; private set; }
    public static bool Key_F { get; private set; }
    public static bool Key_G { get; private set; }

    public static bool Key_Z { get; private set; }
    public static bool Key_X { get; private set; }
    public static bool Key_C { get; private set; }
    public static bool Key_V { get; private set; }
    public static bool Key_B { get; private set; }

    // 키 셋
    public static bool Title = false;


    private void FixedUpdate()
    {
        Key_MouseLeft = Input.GetMouseButton(0);
        Key_MouseRight = Input.GetMouseButton(1);

        Key_Shift = Input.GetKey(KeyCode.LeftShift);
        Key_Tap = Input.GetKey(KeyCode.Tab);

        Key_Q = Input.GetKey(KeyCode.Q);
        Key_W = Input.GetKey(KeyCode.W);
        Key_E = Input.GetKey(KeyCode.E);
        Key_R = Input.GetKey(KeyCode.R);
        Key_T = Input.GetKey(KeyCode.T);

        Key_A = Input.GetKey(KeyCode.A);
        Key_S = Input.GetKey(KeyCode.S);
        Key_D = Input.GetKey(KeyCode.D);
        Key_F = Input.GetKey(KeyCode.F);
        Key_G = Input.GetKey(KeyCode.G);

        Key_Z = Input.GetKey(KeyCode.Z);
        Key_X = Input.GetKey(KeyCode.X);
        Key_C = Input.GetKey(KeyCode.C);
        Key_V = Input.GetKey(KeyCode.V);
        Key_B = Input.GetKey(KeyCode.B);
    }
}
