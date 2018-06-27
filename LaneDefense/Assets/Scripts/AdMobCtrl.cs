using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMobCtrl : MonoBehaviour
{
	


	InterstitialAd interstitial;
	BannerView bannerView;

	// Use this for initialization
	void Start()
	{
		

		//Request Ads

			RequestBanner ();
			RequestInterstitial ();

			showInterstitialAd ();
	
	
	}

	public void showInterstitialAd()
	{
		//Show Ad
		if (interstitial.IsLoaded ()) {
			interstitial.Show ();

		} else {
			interstitial.Destroy ();
		}

	}

	public void RequestBanner()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4697579006360442/5518347117";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif


		// Create a 320x50 banner at the bottom of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
		}

		public void RequestInterstitial()
		{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-4697579006360442/1613571751";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		}

		public void HideInterstitialAd(){

			bannerView.Hide ();

		}

		}
