// <copyright file="AdmobVNTIS.cs" company="Ta Quang Tien">
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
using GoogleMobileAds.Api;

public class AdmobVNTIS : MonoBehaviour
{
	public string BannerAdUnitID = "YOUR_AD_UNIT_ID";
	public string[] TestDeviceIds;
	public AdSizeEnum AdvertisementSize = AdSizeEnum.Banner;
	public bool ShowOnLoad = true;
	public AdPosition AdvertisementPosition = AdPosition.Bottom;

	public enum AdSizeEnum
	{
		Banner,
		LeaderBoard,
		MediumRectangle,
		SmartBanner,
		IabBanner
	}
	;

	public enum Rules
	{
		ALIGN_PARENT_BOTTOM = 12,
		ALIGN_PARENT_LEFT = 9,
		ALIGN_PARENT_RIGHT = 11,
		ALIGN_PARENT_TOP = 10,
		CENTER_HORIZONTAL = 14,
		CENTER_IN_PARENT = 13, 	
		CENTER_VERTICAL = 15
	}
	;

	// Dont destroy on load and prevent duplicate
	public static AdmobVNTIS instance = null;

	void Awake ()
	{
		if (instance == null) {
			DontDestroyOnLoad (this.gameObject);
			instance = this;

			#if UNITY_EDITOR
			Debug.Log("AdmobBanner created - Admob Plugin only work on real device, not in editor");
			return;
			#endif
			AdSize adSize = null;
			switch(AdvertisementSize){
			case AdSizeEnum.Banner: adSize = AdSize.Banner; break;
			case AdSizeEnum.IabBanner: adSize = AdSize.IABBanner; break;
			case AdSizeEnum.LeaderBoard: adSize = AdSize.Leaderboard; break;
			case AdSizeEnum.MediumRectangle: adSize = AdSize.MediumRectangle; break;
			case AdSizeEnum.SmartBanner: adSize = AdSize.SmartBanner; break;
			default: adSize = AdSize.SmartBanner; break;
			}
			VNTIS_GMA_Connector.RequestBanner(BannerAdUnitID, TestDeviceIds, ShowOnLoad, adSize, AdvertisementPosition);

		} else {
			Destroy (this.gameObject);
		}
	}

	public void showBanner ()
	{
		if (VNTIS_GMA_Connector.bannerView != null)
			VNTIS_GMA_Connector.showBanner ();
		else
			Debug.LogError ("Show - Null");
	}

	public void hideBanner ()
	{
		if (VNTIS_GMA_Connector.bannerView != null)
			VNTIS_GMA_Connector.hideBanner ();
		else
			Debug.LogError ("Hide - Null");
	}


	public static void _showBanner ()
	{
		#if UNITY_EDITOR
		Debug.Log("AdmobVNTIS._showBanner() called.");
		return;
		#endif

		if (instance != null)
			instance.showBanner ();
	}

	public static void _hideBanner ()
	{
		#if UNITY_EDITOR
		Debug.Log("AdmobVNTIS._hideBanner() called.");
		return;
		#endif

		if (instance != null)
			instance.hideBanner ();
	}

	public static AdmobVNTIS _get ()
	{
		#if UNITY_EDITOR
		Debug.Log("AdmobVNTIS.get() called. Return null.");
		return null;
		#endif
		return instance;
	}
}
