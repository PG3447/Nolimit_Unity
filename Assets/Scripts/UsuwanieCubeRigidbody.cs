using UnityEngine;

public class UsuwanieCubeRigidbody : MonoBehaviour
{
    private float odleglosc;
    private Vector3 Startpozycja;
    private Vector3 pozycjaKamery;
    private Transform Kamera;
    private float obrotKamery;

    void Awake()
    {
        Kamera = GameObject.Find("Main Camera").transform;
        Startpozycja = this.transform.position;
        odleglosc = 0f;
        obrotKamery = 1f;
    }

    public void Czekanie() {
        if (this.enabled) {
            try {
                pozycjaKamery = Kamera.transform.position;
                odleglosc = Vector3.Distance(pozycjaKamery, Startpozycja);
                obrotKamery = Vector3.Dot(Kamera.forward, Startpozycja - pozycjaKamery);
            } catch {

            }

            if (odleglosc > 270f && obrotKamery <= 0f)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
                this.enabled = false;
            }
        }
        return;

    }
}