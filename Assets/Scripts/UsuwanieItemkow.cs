using UnityEngine;

public class UsuwanieItemkow : MonoBehaviour
{
    private GameObject samolot;
    private GameObject podloze;
    void Start()
    {
        podloze = GameObject.Find("Plane");
        samolot = GameObject.Find("AirPlane");
        enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Kadlub" || other.name == "SkrzydloPrawe" || other.name == "SkrzydloLewe") {
            podloze = GameObject.Find("Plane");
            samolot = GameObject.Find("AirPlane");
            samolot.transform.position = new Vector3(0, 4f, podloze.transform.position.z - podloze.GetComponent<Collider>().bounds.size.z*2/5);
            return;
        }
        Destroy(other.gameObject);
    }
}