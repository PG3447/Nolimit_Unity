using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private GameObject Kadlub;
    private GameObject Cube;
    private GameObject Cube2;

    private float PredkoscSamolotu;
    private bool autosync = false;

    void Start()
    {
        Physics.autoSyncTransforms = autosync;
        Cube = (GameObject)Instantiate(Resources.Load("Prefabs/Pocisk"));
        Cube.name = "Pocisk";
        Cube.AddComponent<Rigidbody>();
        Cube.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        Cube.SetActive(false);
        PredkoscSamolotu = this.GetComponent<Rigidbody>().velocity.magnitude;
        Kadlub = GameObject.Find("Kadlub");
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cube2 = Instantiate(Cube, Kadlub.transform.position + Kadlub.transform.forward * 2.5f, Quaternion.identity);
            Cube2.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
            Cube2.AddComponent<PociskDelete>();
            Cube2.AddComponent<PociskPunkt>();
            Cube2.SetActive(true);
            Cube2.GetComponent<Rigidbody>().AddForce(Cube2.transform.forward * 11000f);

        }
        if (Input.GetKey(KeyCode.W))
        {
            PredkoscSamolotu = this.GetComponent<Rigidbody>().velocity.magnitude;

            if (PredkoscSamolotu < 100)
            {
                if (Time.deltaTime * this.transform.position.y < 250f)
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50f));
                }
            }
            if (PredkoscSamolotu > 50)
            {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 20f, 0));
            } else {
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 17f, 0));
            }
            Kadlub.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -25f));
            Kadlub.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(10f, 0, 0));
            Kadlub.GetComponent<Renderer>().material.color = Color.red;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-10f, 0, 0));
            Kadlub.GetComponent<Renderer>().material.color = Color.green;
        }

    }
}