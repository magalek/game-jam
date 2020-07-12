using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    private void Awake() {
        if (GameManager.Instance.hasWon) {
            GetComponent<TextMeshProUGUI>().text = "U won, gratz : - )";
        }
        else {
            GetComponent<TextMeshProUGUI>().text = "U lost, not gratz ; - (";
        }
    }
}
