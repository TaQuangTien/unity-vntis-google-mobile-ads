#pragma warning disable
using UnityEngine;
using System.Collections;

public class AdmobVNTIS_Interstitial : MonoBehaviour
{

	public string InterstitialAdUnitID = "YOUR_AD_UNIT_ID";
	public string InterstitialAdUnitID_IOS = "YOUR_AD_UNIT_ID";
	public string[] TestDeviceIds;
	public bool ShowInterstitialOnLoad = false;

	// Dont destroy on load and prevent duplicate
	public static AdmobVNTIS_Interstitial instance = null;

	void Awake ()
	{
		#if UNITY_IPHONE
		InterstitialAdUnitID = InterstitialAdUnitID_IOS;
		#endif
		if (instance == null) {
			DontDestroyOnLoad (this.gameObject);
			instance = this;
			initializeInterstitial ();
		} else {
			Destroy (this.gameObject);
		}
	}

	void initializeInterstitial ()
	{		
		#if UNITY_EDITOR
		Debug.Log ("AdmobInterstitial created - Admob Plugin only work on real device, not in editor");
		return;
		#endif
		VNTIS_GMA_Connector.RequestInterstitial(InterstitialAdUnitID, TestDeviceIds, ShowInterstitialOnLoad);
	}

	public void loadInterstitialAd ()
	{
		VNTIS_GMA_Connector.RequestInterstitial(InterstitialAdUnitID, TestDeviceIds, false);
	}

	/// <summary>
	/// Show the interstitial. Load if ad is not loaded, and show after load.
	/// </summary>
	public void showInterstitial ()
	{
		VNTIS_GMA_Connector.RequestInterstitial(InterstitialAdUnitID, TestDeviceIds, true);
	}

	/// <summary>
	/// Show the interstitial. Load if ad is not loaded, and NOT show after load.
	/// </summary>
	public void showInterstitialImmediately ()
	{
		if(VNTIS_GMA_Connector.interstitial != null &&
			VNTIS_GMA_Connector.interstitial.IsLoaded()){
			VNTIS_GMA_Connector.interstitial.Show();
		}else{
			loadInterstitialAd ();
		}
	}

	public static void _loadInterstitialAd ()
	{
		#if UNITY_EDITOR
		Debug.Log ("AdmobVNTIS_Interstitial._loadInterstitialAd() called");
		return;
		#endif
		
		if (instance != null) {
			instance.loadInterstitialAd ();
		}
	}

	public static void _showInterstitial ()
	{
		#if UNITY_EDITOR
		Debug.Log ("AdmobVNTIS_Interstitial._showInterstitial() called");
		return;
		#endif

		if (instance != null) {
			instance.showInterstitial ();
		}
	}

	public static void _showInterstitialImmediately ()
	{
		#if UNITY_EDITOR
		Debug.Log ("AdmobVNTIS_Interstitial._showInterstitialImmediately() called");
		return;
		#endif
		if (instance != null) {
			instance.showInterstitialImmediately ();
		}
	}


	public static AdmobVNTIS_Interstitial _get ()
	{
		#if UNITY_EDITOR
		Debug.Log ("AdmobVNTIS_Interstitial._get() called. Return null");
		return null;
		#endif
		return instance;
	}

}
