using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultTextObject;
    [SerializeField] private TextMeshProUGUI nameTextObject;

    private Event @event;

    private void Start() {
        @event = Resources.LoadAll<Event>("Events")[0];
        
        nameTextObject.text = @event.name;
        resultTextObject.text = @event.description;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            
            bool success = Random.Range(0, 2) == 1 ? true : false;

            UpdateText(success, @event);
        }
    }

    private void UpdateText(bool success, Event @event) {
        int random = Random.Range(0, @event.Items.Count);
        if (success)
            resultTextObject.text = string.Format(@event.succesMessage, @event.Items[random].option == Option.First ? @event.Items[random].item.firstSuccesMessage : @event.Items[random].item.secondSuccesMessage);
        else
            resultTextObject.text = string.Format(@event.failMessage, @event.Items[random].item.failMessage);
    }
}
