using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using PlayFab;



public class Main_UI : MonoBehaviour
{
    public enum MainUI { Main, SignUp, SignUpSeccec, Option }

    public static TMP_InputField InputField_Main_ID { get; private set; }
    public static TMP_InputField InputField_Main_Password { get; private set; }
    public static Button Button_Main_Login { get; private set; }
    public static Button Button_Main_SingUp { get; private set; }

    // ȸ������
    public static GameObject SignUp { get; private set; }

    public static TMP_InputField InputField_SignUp_ID { get; private set; }
    public static TMP_InputField InputField_SignUp_Password { get; private set; }
    public static TMP_InputField InputField_SignUp_PasswordCheck { get; private set; }
    public static TMP_InputField InputField_SignUp_Nickname { get; private set; }

    public static TextMeshProUGUI Text_SignUp_ID { get; private set; }
    public static TextMeshProUGUI Text_SignUp_Password { get; private set; }
    public static TextMeshProUGUI Text_SignUp_PasswordCheck { get; private set; }
    public static TextMeshProUGUI Text_SignUp_Nickname { get; private set; }

    public static Button Button_SignUp_Back { get; private set; }
    public static Button Button_SignUp_OK { get; private set; }

    // ȸ������ ����
    public static GameObject SignUpSeccec { get; private set; }
    public static TextMeshProUGUI Text_SignUpSeccec { get; private set; }
    public static Button Button_SignUpSeccec_OK { get; private set; }

    private void Awake()
    {
        // ����
        InputField_Main_ID = transform.Find("InputField_ID").GetComponent<TMP_InputField>();
        Debug.Assert(InputField_Main_ID != null);
        InputField_Main_Password = transform.Find("InputField_Passward").GetComponent<TMP_InputField>();
        Debug.Assert(InputField_Main_Password != null);
        Button_Main_Login = transform.Find("Button_Login").GetComponent<Button>();
        Debug.Assert(Button_Main_Login != null);
        Button_Main_SingUp = transform.Find("Button_SignUp").GetComponent<Button>();
        Debug.Assert(Button_Main_SingUp != null);

        // ȸ������
        SignUp = transform.Find("SignUpPage").gameObject;
        Debug.Assert(SignUp != null);
        InputField_SignUp_ID = SignUp.transform.Find("InputField_SignUp_ID").GetComponent<TMP_InputField>();
        Debug.Assert(InputField_SignUp_ID != null);
        InputField_SignUp_Password = SignUp.transform.Find("InputField_SignUp_Password").GetComponent<TMP_InputField>();
        Debug.Assert(InputField_SignUp_Password != null);
        InputField_SignUp_PasswordCheck = SignUp.transform.Find("InputField_SignUp_PasswordCheck").GetComponent<TMP_InputField>();
        Debug.Assert(InputField_SignUp_PasswordCheck != null);
        InputField_SignUp_Nickname = SignUp.transform.Find("InputField_SignUp_Nickname").GetComponent<TMP_InputField>();
        Debug.Assert(InputField_SignUp_Nickname != null);

        Text_SignUp_ID = SignUp.transform.Find("Text_SignUp_IDText").GetComponent<TextMeshProUGUI>();
        Debug.Assert(Text_SignUp_ID != null);
        Text_SignUp_Password = SignUp.transform.Find("Text_SignUp_PasswordText").GetComponent<TextMeshProUGUI>();
        Debug.Assert(Text_SignUp_Password != null);
        Text_SignUp_PasswordCheck = SignUp.transform.Find("Text_SignUp_PasswordCheckText").GetComponent<TextMeshProUGUI>();
        Debug.Assert(Text_SignUp_PasswordCheck != null);
        Text_SignUp_Nickname = SignUp.transform.Find("Text_SignUp_NicknameText").GetComponent<TextMeshProUGUI>();
        Debug.Assert(Text_SignUp_Nickname != null);

        Button_SignUp_Back = SignUp.transform.Find("Button_SignUp_Back").GetComponent<Button>();
        Debug.Assert(Button_SignUp_Back != null);
        Button_SignUp_OK = SignUp.transform.Find("Button_SignUp_OK").GetComponent<Button>();
        Debug.Assert(Button_SignUp_OK != null);

        // ȸ������ ����
        SignUpSeccec = transform.Find("SignUpSeccecPage").gameObject;
        Debug.Assert(SignUpSeccec != null);
        Text_SignUpSeccec = SignUpSeccec.transform.Find("Text_SignUpSeccec").GetComponent<TextMeshProUGUI>();
        Debug.Assert(Text_SignUpSeccec != null);
        Button_SignUpSeccec_OK = SignUpSeccec.transform.Find("Button_SignUpSeccec_OK").GetComponent<Button>();
        Debug.Assert(Button_SignUpSeccec_OK != null);

        // ��ư����---------------------
        // ����
        Button_Main_Login.onClick.AddListener(() => ButtonPress_Main_Login());
        Button_Main_SingUp.onClick.AddListener(() => ButtonPress_Main_SignUp());
        // ȸ������
        Button_SignUp_OK.onClick.AddListener(() => ButtonPress_SignUp_Ok());
        Button_SignUp_Back.onClick.AddListener(() => ButtonPress_SignUp_Back());
        // ȸ������ ����
        Button_SignUpSeccec_OK.onClick.AddListener(() => ButtonPress_SignUpSeccec_OK());

        // ��ǲ�ʵ� ����---------------------
        // ȸ������
        InputField_SignUp_ID.onValueChanged.AddListener(SignUpIDCondition);
        InputField_SignUp_Password.onValueChanged.AddListener(SignUpPasswordCondition);
        InputField_SignUp_PasswordCheck.onValueChanged.AddListener(SignUpPasswordCheckCondition);
        InputField_SignUp_Nickname.onValueChanged.AddListener(SignUpNicknameCondition);


        SetActiveUI(MainUI.Main, true);
        InitSignUp();
    }
    private void InitSignUp()
    {
        InputField_SignUp_ID.text = "";
        InputField_SignUp_Password.text = "";
        InputField_SignUp_PasswordCheck.text = "";
        InputField_SignUp_Nickname.text = "";
        SignUpIDCondition("");
        SignUpPasswordCondition("");
        SignUpPasswordCheckCondition("");
        SignUpNicknameCondition("");
    }

    private void ButtonPress_Main_Login()
    {
        LoginRequest();
    }
    private void ButtonPress_Main_SignUp()
    {
        InputField_Main_ID.text = "";
        InputField_Main_Password.text = "";
        SetActiveUI(MainUI.SignUp, true);
        InitSignUp();
    }
    private void ButtonPress_SignUp_Ok()
    {
        if (!SignUpID_Check)
        {
            SetActiveUI(MainUI.SignUpSeccec, true);
            Text_SignUpSeccec.text = "���̵� Ȯ��";
            return;
        }
        if (!SignUpPassword_Check)
        {
            SetActiveUI(MainUI.SignUpSeccec, true);
            Text_SignUpSeccec.text = "��й�ȣ Ȯ��";
            return;
        }
        if (!SignUpPasswordCheck_Check)
        {
            SetActiveUI(MainUI.SignUpSeccec, true);
            Text_SignUpSeccec.text = "��й�ȣ Ȯ���� �ȵ�";
            return;
        }
        if (!SignUpNickname_Check)
        {
            SetActiveUI(MainUI.SignUpSeccec, true);
            Text_SignUpSeccec.text = "�г��� Ȯ��";
            return;
        }
            RegisterRequest();
    }
    private void ButtonPress_SignUp_Back()
    {
        SetActiveUI(MainUI.SignUp, false);
    }
    private void ButtonPress_SignUpSeccec_OK()
    {
        SetActiveUI(MainUI.SignUpSeccec, false);
    }

    public void SetActiveUI(MainUI Value, bool ActiveValue)
    {
        switch (Value)
        {
            case MainUI.Main:
                {
                    if (!ActiveValue)
                        break;
                    for (int i = 1; i < System.Enum.GetValues(typeof(MainUI)).Length; i++)
                    {
                        SetActiveUI((MainUI)i, false);
                    }
                }
                break;
            case MainUI.SignUp:
                {
                    SignUp.SetActive(ActiveValue);
                }
                break;
            case MainUI.SignUpSeccec:
                {
                    SignUpSeccec.SetActive(ActiveValue);
                }
                break;
            case MainUI.Option:
                {

                }
                break;
            default:
                break;
        }
    }
    bool SignUpID_Check;
    private void SignUpIDCondition(string Value)
    {
        Regex PasswordRegex = new Regex(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        bool isMatch = PasswordRegex.IsMatch(Value);

        if (!isMatch)
        {
            Text_SignUp_ID.text = "<color=\"red\">�߸��� �̸��� �����Դϴ�.</color>";
            SignUpID_Check = false;
        }
        else
        {
            Text_SignUp_ID.text = "<color=\"green\">Ȯ��</color>";
            SignUpID_Check = true;
        }
    }

    bool SignUpPassword_Check;
    private void SignUpPasswordCondition(string Value)
    {
        Regex PasswordRegex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9]).{8,}$");
        bool isMatch = PasswordRegex.IsMatch(Value);

        if (!isMatch)
        {
            Text_SignUp_Password.text = "<color=\"red\">�߸��� ��й�ȣ�Դϴ�.</color>";
            SignUpPassword_Check = false;
        }
        else
        {
            Text_SignUp_Password.text = "<color=\"green\">Ȯ��</color>";
            SignUpPassword_Check = true;
        }
    }

    bool SignUpPasswordCheck_Check;
    private void SignUpPasswordCheckCondition(string Value)
    {
        if (Value == "")
        {
            Text_SignUp_PasswordCheck.text = "<color=\"red\"></color>";
            SignUpPasswordCheck_Check = false;
            return;
        }
        if (Value != InputField_SignUp_Password.text)
        {
            Text_SignUp_PasswordCheck.text = "<color=\"red\">�ٸ� ��й�ȣ�Դϴ�.</color>";
            SignUpPasswordCheck_Check = false;
        }
        else
        {
            Text_SignUp_PasswordCheck.text = "<color=\"green\">Ȯ��</color>";
            SignUpPasswordCheck_Check = true;
        }
    }

    bool SignUpNickname_Check;
    private void SignUpNicknameCondition(string Value)
    {
        if (Value.Length <= 2)
        {
            Text_SignUp_Nickname.text = "<color=\"red\">�߸��� �г����Դϴ�.</color>";
            SignUpNickname_Check = false;
        }
        else
        {
            Text_SignUp_Nickname.text = "<color=\"green\">Ȯ��</color>";
            SignUpNickname_Check = true;
        }
    }

    // ȸ������
    private void RegisterRequest()
    {
        // ȸ�����Կ� �ʿ��� ���� �Է�
        var Email_request = new RegisterPlayFabUserRequest { Email = InputField_SignUp_ID.text, Password = InputField_SignUp_Password.text, Username = InputField_SignUp_Nickname.text };
        PlayFabClientAPI.RegisterPlayFabUser(Email_request, OnRegisterSuccess, OnRegisterFailire);
    }
    // ȸ������ ����
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        SetActiveUI(MainUI.SignUpSeccec, true);
        Text_SignUpSeccec.text = "ȸ������ ����";
        InitSignUp();
        SetActiveUI(MainUI.SignUp, false);
        Debug.Log("ȸ������ ����");
    }
    // ȸ������ ����
    private void OnRegisterFailire(PlayFabError error)
    {
        InputField_SignUp_ID.text = "";
        SetActiveUI(MainUI.SignUpSeccec, true);
        Text_SignUpSeccec.text = "ȸ������ ����";
        Debug.LogWarning("ȸ������ ����");
    }

    // �α���
    public void LoginRequest()
    {
        // �α��ο� �ʿ��� ���� �Է�
        var Login_request = new LoginWithEmailAddressRequest { Email = InputField_Main_ID.text, Password = InputField_Main_Password.text };
        PlayFabClientAPI.LoginWithEmailAddress(Login_request, OnLoginSuccess, OnLoginFailure);
    }
    // �α��� ����
    private void OnLoginSuccess(LoginResult result)
    {
        PlayfabManager.SetLoginID(result.PlayFabId);
        Debug.Log("�α��� ����");
    }
    // �α��� ����
    private void OnLoginFailure(PlayFabError error)
    {
        SetActiveUI(MainUI.SignUpSeccec, true);
        Text_SignUpSeccec.text = "�α��� ����";
        InputField_Main_Password.text = "";

        Debug.LogWarning("�α��� ���� : " + error);
    }
}
