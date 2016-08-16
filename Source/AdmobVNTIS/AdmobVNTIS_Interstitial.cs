// <copyright file="AdmobVNTIS_Interstitial.cs" company="Ta Quang Tien">
// Copyright (C) 2016 Ta Quang Tien.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>

using UnityEngine;
using System.Collections;

public class AdmobVNTIS_Interstitial : MonoBehaviour
{

	public string InterstitialAdUnitID = "YOUR_AD_UNIT_ID";
	public string[] TestDeviceIds;
	public bool ShowInterstitialOnLoad = false;

	// Dont destroy on load and prevent duplicate
	public static AdmobVNTIS_Interstitial instance = null;

	void Awake ()
	{
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
		if (VNTIS_GMA_Connector.interstitial != null)
			VNTIS_GMA_Connector.loadInterstitialAd ();
		else
			Debug.LogError ("Show - Im");
	}

	/// <summary>
	/// Show the interstitial. Load if ad is not loaded, and show after load.
	/// </summary>
	public void showInterstitial ()
	{
		if (VNTIS_GMA_Connector.interstitial != null)
			VNTIS_GMA_Connector.showInterstitial ();
		else
			Debug.LogError ("Show - Null");
	}

	/// <summary>
	/// Show the interstitial. Load if ad is not loaded, and NOT show after load.
	/// </summary>
	public void showInterstitialImmediately ()
	{
		if (VNTIS_GMA_Connector.interstitial != null)
			VNTIS_GMA_Connector.showInterstitial_Im ();
		else
			Debug.LogError ("Show - Im");
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
