using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] int health = 10;
    public int points = 0;
    [SerializeField] Text healthText;
    [SerializeField] Text pointText;

    void Start()
    {
        healthText.text = health.ToString();
        pointText.text = points.ToString();
    }

    void Update()
    {
        pointText.text = points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        health--;
        healthText.text = health.ToString();
    }

    public void UpdatePoints(int enemyValue)
    {
        points += enemyValue;
    }
}
