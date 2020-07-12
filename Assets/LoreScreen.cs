using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoreScreen : MonoBehaviour
{
    private void Start() {
        GetComponent<Button>().onClick.AddListener(LoadGameScene);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene(1);
    }
}
