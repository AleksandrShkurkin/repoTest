using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyTemplate : MonoBehaviour
{
    public int health = 100;
    public float defense = 1.0f;
    public TextMeshProUGUI healthText;

    void Update()
    {
        healthText.text = "HP: " + health.ToString();
    }

    public void InflictDamage(int player_damage)
    {
        health -= (player_damage - (int)defense);
        if (health <= 0)
        {
            Respawn();
            Destroy(gameObject);
        }
    }

    void Respawn()
    {
        float arenaSizeX = 5.0f;
        float arenaSizeY = 5.0f;
        Vector3 randomPosition = new Vector3(
            Random.Range(-arenaSizeX, arenaSizeX),
            Random.Range(-arenaSizeY, arenaSizeY),
            transform.position.z
        );
        gameObject.GetComponent<EnemyTemplate>().health = 100;
        Instantiate(gameObject, randomPosition, Quaternion.identity);
    }
}
