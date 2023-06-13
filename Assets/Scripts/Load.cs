using UnityEngine;

public class Load : MonoBehaviour
{
    public static void WaitToLoad(bool loading)
    {
        if (loading)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
}