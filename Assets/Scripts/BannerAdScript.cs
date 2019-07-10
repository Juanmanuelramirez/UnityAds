using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{
    private string placementId = "bannerPlacement";
    public bool testMode = false;

#if UNITY_IOS
    private string gameId = "3215877";
#elif UNITY_ANDROID
    private string gameId = "3215876";
#endif

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }
}
