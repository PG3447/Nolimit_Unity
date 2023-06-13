using UnityEngine;

public class PociskDelete : MonoBehaviour
{
    private float StartCzas;
    void Start()
    {
        StartCzas = Time.time;
    }

    void FixedUpdate()
    {
        if (Time.time > StartCzas + Random.Range(2f,2.5f)) {
            Destroy(this.gameObject);
        }
    }
}