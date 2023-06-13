using UnityEngine;

public class PociskPunkt : MonoBehaviour
{
    public static int punkty;
    private float liczba;

    private void Start()
    {
        liczba = 0.01975f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Pacholek(Clone)")
        {
            if (Time.deltaTime > liczba) {
                punkty++;
                if (liczba < -2f) { liczba = 0.65f; }
                liczba -= Random.Range(0.2f, 0.65f);
            }

        }
    }

}