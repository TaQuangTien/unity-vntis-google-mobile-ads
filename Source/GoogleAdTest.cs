// <copyright file="GoogleAdTest.cs" company="Ta Quang Tien">
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

public class GoogleAdTest : MonoBehaviour {

	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public void showBanner () {
		Toast.showText ("showBanner Clicked");
		AdmobVNTIS._showBanner ();
	}

	public void hideBanner () {
		Toast.showText ("hideBanner Clicked");
		AdmobVNTIS._hideBanner ();
	}

	public void showIntersitial () {
		Toast.showText ("showInterstitial Clicked");
		AdmobVNTIS_Interstitial._showInterstitial ();
	}

	public void showInterstitialImmediately () {
		Toast.showText ("showInterstitialImmediately Clicked");
		AdmobVNTIS_Interstitial._showInterstitialImmediately ();
	}
}
