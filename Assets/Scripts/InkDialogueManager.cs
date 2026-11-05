using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkDialogueManager : MonoBehaviour
{
    public static InkDialogueManager Instance;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Transform choiceContainer;
    public GameObject choiceButtonPrefab;

    private Story currentStory;
    private bool dialogueActive;

    private void Awake()
    {
        Instance = this;
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueActive = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public void ContinueStory()
    {
        if (currentStory == null)
            return;

        foreach (Transform child in choiceContainer)
        {
            Destroy(child.gameObject);
        }

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }

        if (currentStory.currentChoices.Count > 0)
        {
            foreach (Choice choice in currentStory.currentChoices)
            {
                GameObject buttonObject =
                    Instantiate(choiceButtonPrefab, choiceContainer);

                Text buttonText = buttonObject.GetComponentInChildren<Text>();
                Button button = buttonObject.GetComponent<Button>();

                buttonText.text = choice.text;

                int choiceIndex = choice.index;
                button.onClick.AddListener(
                    () => OnChoiceSelected(choiceIndex)
                );
            }
        }
        else if (!currentStory.canContinue)
        {
            EndDialogue();
        }
    }

    private void OnChoiceSelected(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);
        currentStory = null;
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }
}
