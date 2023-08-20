using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DialoguePrefabsHandler : MonoBehaviour
{
    public GameObject dialogueWindow;
    public TMP_Text dialogueText;
    public GameObject nextButton;
    public RectTransform content;
    public GameObject responsePrefab;

    private DialogueObject.Part currentPart;
    private DialogueObject currentDialogue;
    private TMP_Text[] responseTexts;

    public void ShowDialogue(DialogueObject dialogue)
    {
        dialogueWindow.SetActive(true);
        currentDialogue = dialogue;
        currentPart = dialogue.GetPart("START");
        ShowPart();
    }

    public void ShowPart()
    {
        dialogueText.text = currentPart.text;
        SpawnResponse(currentPart.responses);
        ResizeElements();
    }

    private void SpawnResponse(DialogueObject.Part.Response[] responses)
    {
        nextButton.SetActive(responses == null);
        if (responses == null)
            return;
        responseTexts = new TMP_Text[1];

        responseTexts[0] = Instantiate(responsePrefab,content).GetComponentInChildren<TMP_Text>();
        responseTexts[0].text = responses[0].text;

        //hamlai multiple responses chaidaina sooo vaad me jau this part
        //for (int i = 0; i < responseTexts.Length; i++)
        //{
        //    responseTexts[i] = Instantiate(responsePrefab, content).GetComponentInChildren<TMP_Text>();
        //    responseTexts[i].text = i + 1 + ". " + responses[i].text;
        //}
    }

    private void ResizeElements()
    {
        Canvas.ForceUpdateCanvases();
        float textHeight = dialogueText.textBounds.size.y + 20f;
        dialogueText.rectTransform.sizeDelta = new Vector2(0, textHeight);
        if (responseTexts is { })
        {
            for (int i = 0; i < responseTexts.Length; i++)
            {
                RectTransform rectTransform = responseTexts[i].transform.parent.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(0, responseTexts[i].bounds.size.y);
                rectTransform.anchoredPosition = new Vector2(0, -textHeight);
                textHeight += responseTexts[i].bounds.size.y + 50f;

                rectTransform.name = i.ToString();
                rectTransform.GetComponent<Button>().onClick.AddListener(delegate { NextPart(int.Parse(rectTransform.name)); });
            }

        }
        else
        {
            NextPart(-1);
        }
        

        content.sizeDelta = new Vector2(0, textHeight);
        content.anchoredPosition = new Vector2(0, 0);
    }

    public void NextPart(int responseNumber)
    {
        if (responseNumber == -1)
        {
            if (currentPart.nextId == null)
            {
                dialogueWindow.SetActive(false);
                DeletePreviousResponse();
                return;
            }
            currentPart = currentDialogue.GetPart(currentPart.nextId);
        }
        else
            currentPart = currentDialogue.GetPart(currentPart.responses[responseNumber].ID);
        DeletePreviousResponse();
        ShowPart();
    }

    private void DeletePreviousResponse()
    {
        responseTexts = new TMP_Text[0];
        for (int i = 1; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }
}