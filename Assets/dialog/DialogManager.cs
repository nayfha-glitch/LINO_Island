using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond = 20;

    public static DialogManager Instance { get; private set; }

    List<string> lines;
    int currentLine = 0;
    bool isTyping = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        lines = dialog.Lines;
        currentLine = 0;
        StartCoroutine(TypeDialog(lines[currentLine]));
    }

    IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        isTyping = false;
    }

    private void Update()
    {
        if (!dialogBox.activeSelf) return;

        if (!isTyping && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;

            if (currentLine < lines.Count)
            {
                StartCoroutine(TypeDialog(lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                FindObjectOfType<gameController>().SetStateFreeRoam();
            }
        }
    }
}


