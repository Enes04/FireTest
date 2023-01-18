using UnityEngine;


public class CollectArmy : MonoBehaviour
{
    public int collectCount;
    private float waitOpenAgainTime;
    private float currentTime;
    private bool isCollect;

    private void Update()
    {
        if (isCollect)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitOpenAgainTime)
            {
                currentTime = 0;
                isCollect = false;
                OpenObj(); 
            }
        }
    }
    public void OpenObj()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<Collider>().enabled = true;
    }
    public void CloseObj()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
        isCollect = true;
        waitOpenAgainTime = UnityEngine.Random.Range(4,8);
    }
}
