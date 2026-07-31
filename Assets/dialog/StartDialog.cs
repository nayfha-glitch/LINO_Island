using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StartDialog : MonoBehaviour
{
    [SerializeField] List<string> lines;

    public List<string> Lines
    {
        get { return lines; }
    }
}

