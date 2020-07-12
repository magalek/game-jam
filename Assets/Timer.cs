using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event Action Ended;

    [SerializeField] private TextMeshProUGUI timerText;
    //[SerializeField] private float countdown;

    private static float timeRemaining = 40;
    private static bool isRunning;

    private void Awake() {
        timerText.text = $"{Mathf.FloorToInt(timeRemaining / 60)} : {Mathf.FloorToInt(timeRemaining % 60).ToString("00")}";
    }

    private void Update() {
        if (isRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                timerText.text = $"{Mathf.FloorToInt(timeRemaining / 60)} : {Mathf.FloorToInt(timeRemaining % 60).ToString("00")}";
            }
            else {
                timerText.text = "0 : 0";
                timeRemaining = 40;
                Ended?.Invoke();
                isRunning = false;
            }
        }
    }

    public static void Start() {
        isRunning = true;
    }

    public static void Stop() {
        timeRemaining = 0;
    }

    public static void ResetTime() {
        timeRemaining = 40;
    }

    public static void ResetTime(float time) {
        timeRemaining = time;
    }
}
