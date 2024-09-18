using System.Collections;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject container;
    public GameObject bar;
    public GameObject[] assetsToAppear; // Use an array for multiple assets
    public int time;

    void Start()
    {
        container.SetActive(false);

        foreach (GameObject asset in assetsToAppear)
        {
            asset.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(AnimateBar());
        }
    }

    IEnumerator AnimateBar()
    {
        container.SetActive(true);
        bar.transform.localScale = new Vector3(0, 1, 1);

        LeanTween.scaleX(bar, 1, time);

        yield return new WaitForSeconds(time);

        // Activate each associated asset
        foreach (GameObject asset in assetsToAppear)
        {
            asset.SetActive(true);
        }

        container.SetActive(false);
    }
}
