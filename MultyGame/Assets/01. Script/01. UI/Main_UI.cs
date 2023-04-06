using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main_UI : MonoBehaviour
{
    public Selectable firstInput;
    public static InputField InputField_ID { get; private set; }
    public static InputField InputField_Password { get; private set; }

    public static Button Button_Login { get; private set; }
    public static Button Button_SingUp { get; private set; }

    private void Awake()
    {
        InputField_ID = transform.Find("InputField_ID").GetComponent<InputField>();
        Debug.Assert(InputField_ID != null);
        InputField_Password = transform.Find("InputField_Passward").GetComponent<InputField>();
        Debug.Assert(InputField_Password != null);
        Button_Login = transform.Find("Button_Login").GetComponent<Button>();
        Debug.Assert(Button_Login != null);
        Button_SingUp = transform.Find("Button_SignUp").GetComponent<Button>();
        Debug.Assert(Button_SingUp != null);

    }
}
