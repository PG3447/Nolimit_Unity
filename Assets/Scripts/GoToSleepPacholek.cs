using UnityEngine;

public class GoToSleepPacholek : MonoBehaviour
{
    private Rigidbody rigidbodyone;
    void Start()
    {
        rigidbodyone = this.GetComponent<Rigidbody>();
        rigidbodyone.sleepThreshold = 2f;
    }
    void Update()
    {
        if (rigidbodyone.IsSleeping())
        {
            rigidbodyone.Sleep();
            if (!ScianaLadowanie.przetwarzaniedanych)
            {
                Destroy(this.GetComponent<GoToSleepPacholek>());
            }
        }
        else {
            rigidbodyone.Sleep();
        }
    }
}
