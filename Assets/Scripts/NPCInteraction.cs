using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
   public TextAsset inkJSON;
   private bool playerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    void OgerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (InkDialogueManager.Instance != null
            && !InkDialogueManager.Instance.IsDialogueActive())
            {
                InkDialogueManager.Instance.StartDialogue(inkJSON);
            }
        }
    }
}
