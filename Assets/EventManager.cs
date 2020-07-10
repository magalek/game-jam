using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            Event @event = Resources.LoadAll<Event>("Events")[0];

            int random = Random.Range(0, @event.Items.Count);

            string message = string.Format(@event.description, @event.Items[random].item.firstSuccesMessage, @event.Items[random].item.failMessage);

            Debug.Log(message);
        }
    }
}
