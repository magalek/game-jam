using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPile : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI interactText;

    [SerializeField] int harvestTime;

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
            if (CanHarvest) StartCoroutine(HarvestCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        interactText.gameObject.SetActive(false);
    }

    private IEnumerator HarvestCoroutine() {
        Debug.Log("Entered coroutine");
        CanHarvest = false;
        interactText.gameObject.SetActive(false);
        for (int i = 0; i < harvestTime; i++) {
            yield return new WaitForSeconds(1);
            progressBar.fillAmount = (1f/harvestTime) * (i + 1);
        }
        Debug.Log("Harvested");
        progressBar.fillAmount = 0;
        CanHarvest = true;

        ItemPopup.Show();
    }
}
