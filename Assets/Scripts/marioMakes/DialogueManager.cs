using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextAsset dialogueText;
    private DialogueObject dialogue;


    // Start is called before the first frame update
    void Start()
    {
        dialogue = JsonUtility.FromJson<DialogueObject>(dialogueText.text);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        FindObjectOfType<DialoguePrefabsHandler>().ShowDialogue(dialogue);
    }
}