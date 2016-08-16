// <copyright file="Toast.cs" company="Ta Quang Tien">
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

public class Toast {
	public static int LENGTH_LONG = 1;
	public static int LENGTH_SHORT = 0;
	public static void showText(string message,int duration){
		#if UNITY_EDITOR
		Debug.Log("Message toasted: " + message);
		return;
		#endif
		AndroidJavaObject jo = new AndroidJavaObject ("gs.extralibrary.vn.extraclass",message,duration);
		jo.Dispose ();
	}

	public static void showText(string message){
		showText (message, LENGTH_SHORT);
	}
}