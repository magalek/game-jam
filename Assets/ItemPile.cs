using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPile : MonoBehaviour
{
    [Header("Customizable Fields")]
    [SerializeField] int harvestTime;
    
    [Header("References")]
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI interactText;

    [SerializeField] private List<Item> availableItems;

    private SpriteRenderer renderer;

    private bool canHarvest;
    
    private bool CanHarvest {
        get {
            return canHarvest;
        }
        set {
            canHarvest = value;
            renderer.color = value == true ? Color.green : Color.red;
        }
    }

    private void Start() {
        renderer = GetComponentInParent<SpriteRenderer>();
        CanHarvest = true;
    }

    private void OnTriggerStay2D(Collider2D collision) {
     
        if (CanHarvest) interactText.gameObject.SetActive(true);

        if (Input.GetKey(KeyCode.E)) {
            Debug.Log("Pressed E");
            if (CanHarvest) {
                StartCoroutine(HarvestCoroutine(collision.gameObject));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        interactText.gameObject.SetActive(false);
    }

    private IEnumerator HarvestCoroutine(GameObject character) {
        character.GetComponent<CharacterMovement>().CanMove = false;

        CanHarvest = false;
        interactText.gameObject.SetActive(false);

        for (int i = 0; i < harvestTime; i++) {
            yield return new WaitForSeconds(1);
            progressBar.fillAmount = (1f/harvestTime) * (i + 1);
        }

        progressBar.fillAmount = 0;
        Item itemToAdd = availableItems[0];
        character.GetComponent<Inventory>().AddItem(itemToAdd);
        CanHarvest = true;
        character.GetComponent<CharacterMovement>().CanMove = true;

        ItemPopup.Show(itemToAdd);
    }
}
