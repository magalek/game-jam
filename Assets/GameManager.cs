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

    public int Points {
        get => points;
        set {
            points = value;
            if (points == 5) {
                LoadScene(3);
                hasWon = true;
            }
            else if (points == -5) {
                LoadScene(3);
                hasWon = false;
            }
        }
    }

    public Event currentEvent;

    private int points;

    public bool hasWon;

    private List<Event> allEvents = new List<Event>();
    private List<Event> usedEvents = new List<Event>();    

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            allEvents = Resources.LoadAll<Event>("Events").ToList();
            SceneManager.sceneLoaded += StartNewEvent;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }         

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        Timer.Ended += () => LoadScene(2);
    }

    public void LoadScene(int number) {
        SceneManager.LoadScene(number);
    }

    public void HideEventPanel() {
        Character.Instance.GetComponent<CharacterMovement>().CanMove = true;
        Timer.Start();
        eventPanel.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
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
        if (scene.buildIndex == 1) {
            StartNewEvent();
        }
    }

    private void StartNewEvent() {   
        SetEvent();
        Timer.ResetTime();
        Character.Instance.GetComponent<CharacterMovement>().CanMove = false;
        eventPanel.SetActive(true);
        eventPanel.GetComponentInChildren<Button>().onClick.AddListener(HideEventPanel);
        TextMeshProUGUI description = eventPanel.GetComponent<EventMessage>().description;
        TextMeshProUGUI title = eventPanel.GetComponent<EventMessage>().title;
        description.text = currentEvent.description;
        title.text = currentEvent.name;
    }
}
