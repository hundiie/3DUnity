using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabManager : MonoBehaviour
{
    public static string LoginID { get; private set; }

    public static void SetLoginID(string Value) { LoginID = Value; }
}
