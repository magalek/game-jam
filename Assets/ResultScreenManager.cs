using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreenManager : MonoBehaviour
{
    public static ResultScreenManager Instance;

    public Image resultImage;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        resultImage = transform.Find("Result Background").GetComponent<Image>();
    }
}
