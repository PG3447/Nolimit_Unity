using System.Collections;
using UnityEngine;

public class ScianaLadowanie : MonoBehaviour
{
    private GameObject plane;
    private GameObject newplane;
    private GameObject sciana;
    private GameObject newsciana;
    private GameObject lawa;
    private GameObject newlawa;
    private GameObject pacholek;
    private GameObject newpacholek;
    private GameObject RodzicScian;
    private GameObject newRodzicScian;
    private float WielkoscPlane;
    private int iloscpacholkow;
    private int zwiekszeniemuru;
    public int minpacholkow;
    public int maxpacholkow;
    bool sprawdzaniepacholek;
    private Vector3 polozeniepacholka;
    private Vector3 polozenieScianyRigdbody;
    private float polozeniepacholkaX;
    private float polozeniepacholkaY;
    private float polozeniepacholkaZ;
    private float polozeniesicanyrigidbodyZ;
    private float wysokosc;
   

    void Awake()
    {
        minpacholkow = GameObject.Find("Min").GetComponent<UIMin>().minpacholki;
        maxpacholkow = GameObject.Find("Max").GetComponent<UIMax>().makspacholki;
        if (maxpacholkow <= minpacholkow)
        {
            maxpacholkow = minpacholkow + 100;
        }

    }


    void Start() {
        try
        {
            UsuwanieCubeRigidbody[] ArrayFunctionUsuwanie = FindObjectsOfType(typeof(UsuwanieCubeRigidbody)) as UsuwanieCubeRigidbody[];

            StartCoroutine(WywolanieUsuwania(ArrayFunctionUsuwanie));
        }
        catch {

        }

        GameObject[] SceneObjects = FindObjectsOfType<GameObject>(true);

        foreach (GameObject gameobject in SceneObjects)
        {

            if (gameobject.name == "FirstLoadPacholek")
            {
                pacholek = gameobject;
            }

            if (gameobject.name == "FirstLoadSciana")
            {
                RodzicScian = gameobject;
            }
        }
    }


    private int onoff;
    private IEnumerator WywolanieUsuwania(UsuwanieCubeRigidbody[] ArrayDeleteTime) {

        onoff = 0;
        foreach (UsuwanieCubeRigidbody UsuwanieCubeRigidbody in ArrayDeleteTime)
        {
            UsuwanieCubeRigidbody.Czekanie();
            onoff++;
            if (onoff == 4) { onoff = 0; yield return null; }
        }
        yield break;
    }


    IEnumerator WaitToLoadingWall() {
        yield return new WaitUntil(() => !przetwarzaniedanych);

        //LadowaniePacholkow
        Szukanie();
        WielkoscPlane = plane.GetComponent<Collider>().bounds.size.z;
        newplane = Instantiate(plane, plane.transform.position + plane.transform.forward * (WielkoscPlane / 4), Quaternion.identity);
        Destroy(plane);
        newplane.name = "Plane";
        newplane.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);
        newsciana = Instantiate(sciana, sciana.transform.position + sciana.transform.forward * (WielkoscPlane / 4), Quaternion.identity);

        Destroy(sciana.GetComponent<BoxCollider>());

        nie = true;
        newsciana.name = "Sciana";
        newlawa = Instantiate(lawa, lawa.transform.position + lawa.transform.forward * (WielkoscPlane / 4), Quaternion.identity);
        Destroy(lawa);
        newlawa.name = "PodlogaToLawa";
        newlawa.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);
        iloscpacholkow = Random.Range(minpacholkow, maxpacholkow);
        zwiekszeniemuru = Random.Range(-4, 4);

        StartCoroutine(TworzeniePacholkow(iloscpacholkow));
        StopCoroutine(WaitToLoadingWall());
    } 

    

    private bool nie = false;
    public static bool przetwarzaniedanych = false;
    private void OnTriggerEnter(Collider other)
    {
        if (nie) {
            return;
        }
        if (other.name == "Kadlub")
        {
            if (przetwarzaniedanych)
            {
                Load.WaitToLoad(true);
            }
            StartCoroutine(WaitToLoadingWall());
        }
    }


    private void Szukanie() {
        plane = GameObject.Find("Plane");
        sciana = GameObject.Find("Sciana");
        lawa = GameObject.Find("PodlogaToLawa");
    }

    IEnumerator TworzeniePacholkow(int liczbapacholkow) {
        przetwarzaniedanych = true;
        int duzopacholkow=0;

        for (int i = 1; i <= liczbapacholkow; i++)
        {
            sprawdzaniepacholek = true;
            while (sprawdzaniepacholek)
            {
                polozeniepacholkaX = Mathf.Round(Random.Range(-300, 300));

                polozeniepacholkaY = 1f;

                int losowanie = (int)Mathf.Round(Random.Range(0,2));


                switch (Random.Range(1, 8))
                {
                    case 1:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 32 + zwiekszeniemuru - losowanie, WielkoscPlane / 32 + zwiekszeniemuru));
                        break;
                    case 2:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 16 + zwiekszeniemuru - losowanie, WielkoscPlane / 16 + zwiekszeniemuru));
                        break;
                    case 3:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 32 * 3 + zwiekszeniemuru - losowanie, WielkoscPlane / 32 * 3 + zwiekszeniemuru));
                        break;
                    case 4:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 8 + zwiekszeniemuru - losowanie, WielkoscPlane / 8 + zwiekszeniemuru));
                        break;
                    case 5:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 32 * 5 + zwiekszeniemuru - losowanie, WielkoscPlane / 32 * 5 + zwiekszeniemuru));
                        break;
                    case 6:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 32 * 6 + zwiekszeniemuru - losowanie, WielkoscPlane / 32 * 6 + zwiekszeniemuru));
                        break;
                    case 7:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 32 * 7 + zwiekszeniemuru - losowanie, WielkoscPlane / 32 * 7  + zwiekszeniemuru));
                        break;
                    case 8:
                        polozeniepacholkaZ = newsciana.transform.position.z + Mathf.Round(Random.Range(WielkoscPlane / 4 + zwiekszeniemuru - losowanie - 4, WielkoscPlane / 4 + zwiekszeniemuru - 4));
                        break;
                }

                bool pionok = true;
                float pionx = 0f;
                while (pionok)
                {
                    polozeniepacholka = new Vector3(polozeniepacholkaX, polozeniepacholkaY + pionx, polozeniepacholkaZ);

                    if (!Physics.CheckSphere(polozeniepacholka, 0.2f))
                    {

                        newpacholek = Instantiate(pacholek, polozeniepacholka, Quaternion.identity);
                        newpacholek.name = "Pacholek(Clone)";
                        newpacholek.SetActive(true);

                        float startRandom = -14f;
                        float endRandom = 15f;
                        pionx += 2;

                        if (liczbapacholkow > Random.Range(6000,10000))
                        {
                            startRandom = -12f;
                            endRandom = 71f;
                        }

                        float Number = Mathf.Round(Random.Range(startRandom, endRandom));
                       

                        if (pionx <= Number) {

                            for (int tempi = (int)(Number - pionx);tempi <=Number ; tempi++) {

                                if (Random.Range(0, 4) >= 1)
                                {
                                    polozeniepacholka = new Vector3(polozeniepacholkaX, polozeniepacholkaY + pionx, polozeniepacholkaZ);
                                    newpacholek = Instantiate(pacholek, polozeniepacholka, Quaternion.identity);
                                    newpacholek.name = "Pacholek(Clone)";
                                    newpacholek.SetActive(true);
                                   
                                    i++;
                                    pionx += 2;
                                }
                            }
                        }


                        pionok = false;
                        sprawdzaniepacholek = false;
                        break;
                    }
                    pionx += 2f;


                }

            }
            duzopacholkow++;
            if (duzopacholkow>50) {
                duzopacholkow = 0;
                yield return null;
            }
        }

        
        if (liczbapacholkow > 1250)
        {
            for (int i = 1; i < 8; i++)
            {
                polozeniesicanyrigidbodyZ = newsciana.transform.position.z + WielkoscPlane / 4 * i / 8 + zwiekszeniemuru - 1;
                for (float x = -240; x <= 240; x += 120)
                {
                    polozenieScianyRigdbody = new Vector3(x, 0f, polozeniesicanyrigidbodyZ);
                    newRodzicScian = Instantiate(RodzicScian, polozenieScianyRigdbody, Quaternion.identity);
                    newRodzicScian.name = "ScianaRigidbody(Clone)";
                    newRodzicScian.AddComponent<UsuwanieCubeRigidbody>();
                    newRodzicScian.SetActive(true);


                    
                    wysokosc = 0f;

                    newRodzicScian.transform.localScale = new Vector3(119f, 1f, 45f);
                    while (Physics.CheckBox(newRodzicScian.transform.position + new Vector3(0f, wysokosc, 0f), new Vector3(118f, 1f, 15f)))
                    {
                        wysokosc++;
                    }
                    wysokosc -= 1f;
                    newRodzicScian.transform.position += new Vector3(0f, (wysokosc / 2) - 0.5f, 0f);
                    newRodzicScian.transform.localScale = new Vector3(119f, wysokosc, 45f);

                    Collider[] hitCollidersStart;

                    hitCollidersStart = Physics.OverlapBox(newRodzicScian.transform.position, newRodzicScian.transform.localScale);

                    newRodzicScian.transform.localScale = new Vector3(1f, 1f, 1f);

                    foreach (Collider colider in hitCollidersStart)
                    {
                        if (colider.name == "Pacholek(Clone)")
                        {
                            colider.transform.parent = newRodzicScian.transform;
                        }
                    }
                    newRodzicScian.GetComponent<BoxCollider>().size = new Vector3(119f, wysokosc, 45f);


                    yield return null;
                }
            }
        }
        if (przetwarzaniedanych)
        {
            przetwarzaniedanych = false;
            Load.WaitToLoad(false);
        }

        Destroy(sciana);
        StopCoroutine(TworzeniePacholkow(liczbapacholkow));
    }

}
