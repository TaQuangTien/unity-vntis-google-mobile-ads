// <copyright file="VNTIS_GMA_Connector.cs" company="Ta Quang Tien">
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
using System;

public class VNTIS_GMA_Connector {

	public static BannerView bannerView;

	public static void RequestBanner (string BannerAdUnitID,string[] TestDeviceIDs,bool showOnLoad, AdSize size, AdPosition pos) {
		#if UNITY_ANDROID
		string adUnitId = BannerAdUnitID;
		#elif UNITY_IPHONE
		string adUnitId = BannerAdUnitID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		//Initialize a Banner
		bannerView = new BannerView(adUnitId, size, pos);

		//Initialize a Banner Adrequest with test device ids
		AdRequest.Builder adBuilder = new AdRequest.Builder();

		for (int i = 0; i < TestDeviceIDs.Length; i++){
			adBuilder.AddTestDevice(TestDeviceIDs[i]);
		}

		AdRequest request = adBuilder.Build();

		//Load the banner with the request.
		bannerView.LoadAd(request);

		//Show banner on load
		if (showOnLoad){
			bannerView.Show();
		}else{
			bannerView.Hide();
		}
	}

	public static void showBanner(){
			bannerView.Show();
	}

	public static void hideBanner(){
			bannerView.Hide();
	}

	static bool interstitialShowOnLoad = false;

	public static InterstitialAd interstitial;

	public static AdRequest i_request;

	public static void RequestInterstitial (string BannerAdUnitID,string[] TestDeviceIDs,bool showOnLoad) {
		interstitialShowOnLoad = showOnLoad;
		#if UNITY_ANDROID
		string adUnitId = BannerAdUnitID;
		#elif UNITY_IPHONE
		string adUnitId = BannerAdUnitID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		//Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);

		//Register call back
		interstitial.OnAdLoaded += OnInterstitialLoaded;

		// Create interstitial ad request.
		AdRequest.Builder adBuilder = new AdRequest.Builder();
		
		for (int i = 0; i < TestDeviceIDs.Length; i++){
			adBuilder.AddTestDevice(TestDeviceIDs[i]);
		}
		
		i_request = adBuilder.Build();

		// Load the interstitial with the request.
		interstitial.LoadAd(i_request);

	}

	public static void OnInterstitialLoaded(object sender, EventArgs args){
		if (interstitialShowOnLoad){
			interstitial.Show();
			interstitialShowOnLoad = false;
		}
	}

	public static void loadInterstitialAd(){
		if (interstitial.IsLoaded()){
			return;
		}else{
			interstitialShowOnLoad = false;
			interstitial.LoadAd(i_request);
		}
	}

	public static void showInterstitial(){
		if (interstitial.IsLoaded()){
			interstitial.Show();
		}else{
			interstitialShowOnLoad = true;
			interstitial.LoadAd(i_request);
		}
	}

	public static void showInterstitial_Im(){
		if (interstitial.IsLoaded()){
			interstitial.Show();
		}else{
			interstitialShowOnLoad = false;
			interstitial.LoadAd(i_request);
		}
	}
}
