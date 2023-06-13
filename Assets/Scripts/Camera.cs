using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    private GameObject samolot;
    private GameObject punktyobjekt;
    private Text punktytekst;
    private int punkty;
    private Vector3 kamerapozycja = new Vector3(0,5f, -25f);

    Camera cam;

    void Start()
    {
        samolot = GameObject.Find("AirPlane");
        punktyobjekt = GameObject.Find("TekstPunkty");
        punktytekst = punktyobjekt.GetComponent<Text>();
    }
    
    void FixedUpdate()
    {
        this.transform.position = samolot.transform.position + kamerapozycja;
        punkty = PociskPunkt.punkty;
        punktytekst.text = "Punkty: " + punkty.ToString();

    }
}
