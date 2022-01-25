using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CounterUpdate : MonoBehaviour
{
    GameObject[] enemies;

    public Text counter;
    public GameObject youWinUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        counter.text = "Corrupted Blobs Remaining: " + enemies.Length.ToString();

        if(enemies.Length == 0) {
            Time.timeScale = 0f;
            youWinUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
