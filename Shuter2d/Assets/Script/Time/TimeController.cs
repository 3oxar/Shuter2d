using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void TimeStope()
    {
        Time.timeScale = 0f;
    }

    public void TimeRun()
    {
        Time.timeScale = 1f;
    }
}
