using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject eventPanel => GameObject.Find("Event Message Border");

    public Event currentEvent;

    private List<Event> allEvents = new List<Event>();
    private List<Event> usedEvents = new List<Event>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            SceneManager.sceneLoaded += StartNewEvent;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }

        allEvents = Resources.LoadAll<Event>("Events").ToList();        

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int number) {
        SceneManager.LoadScene(number);
    }

    public void HideEventPanel() {
        Character.Instance.GetComponent<CharacterMovement>().CanMove = true;
        eventPanel.SetActive(false);
    }

    private void SetEvent() {
        if (usedEvents.Count == allEvents.Count) return;
        
        Event buffer;
        do {
            buffer = allEvents[UnityEngine.Random.Range(0, allEvents.Count)];
        } while (usedEvents.Contains(buffer));

        usedEvents.Add(buffer);

        currentEvent = buffer;
    }

    private void StartNewEvent(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex == 0) {
            StartNewEvent();
        }
    }

    private void StartNewEvent() {   
        SetEvent();
        Character.Instance.GetComponent<CharacterMovement>().CanMove = false;
        eventPanel.SetActive(true);
        eventPanel.GetComponentInChildren<Button>().onClick.AddListener(HideEventPanel);
        TextMeshProUGUI description = eventPanel.GetComponent<EventMessage>().description;
        TextMeshProUGUI title = eventPanel.GetComponent<EventMessage>().title;
        description.text = currentEvent.description;
        title.text = currentEvent.name;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            LoadScene(1);
        }
    }
}
