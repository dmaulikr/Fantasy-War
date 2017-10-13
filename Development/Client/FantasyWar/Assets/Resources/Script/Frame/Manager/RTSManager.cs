﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSManager : UnitySingleton<RTSManager> {

	public PlayerInfo currentPlayer;

	public List<PlayerInfo> Players = new List<PlayerInfo>();

	void Start(){
		BuildOriginal ();
		RegistInput ();

	}

	void vvv(KeyCode d){
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Y)) {
			Debug.Log ("注册");
			InputManager.ShareInstance.InputEventHandlerRegister_GetKeyDown (KeyCode.F10, vvv);
		}
	}

	void RegistInput(){
		//TODO
		//在InputManager中
		//註冊點選方法
		//註冊框選方法
		//註冊編隊方法
		//註冊選隊方法

		//测试用点选
		InputManager.ShareInstance.InputEventHandlerRegister_GetKeyDown(KeyCode.Mouse0,RTSOperations.PointSelect);
	}

	/// <summary>
	/// 建造初始单位
	/// </summary>
	private void BuildOriginal(){
		foreach (PlayerInfo p in Players) {
			if (p.IsCurrentPlayer) {
				currentPlayer = p;
			}
			UnitManager.ShareInstance.Buildings.Add(p,new List<GameObject> ());
			UnitManager.ShareInstance.Armys.Add(p,new List<GameObject> ());

			GameObject prefeb;
			GameObject go;

			switch (p.racial) {
			case Racial.deemo:
				//实际加载什么就是什么
				prefeb = (GameObject)Resources.Load ("Prefab/GameObject/Cube");

				go = (GameObject)GameObject.Instantiate (prefeb, p.location, Quaternion.identity);
				go.GetComponent<UnitInfo> ().belong = p;
				Debug.Log("初始建筑建造");
				break;
			case Racial.human:
				//实际加载什么就是什么
				prefeb = (GameObject)Resources.Load ("Prefab/GameObject/Base");

				go = (GameObject)GameObject.Instantiate(prefeb, p.location, Quaternion.identity);
				go.GetComponent<UnitInfo> ().belong = p;
				Debug.Log("初始建筑建造");
				break;
			default:
				break;
			}
		}
	}

	public Vector3? ScreenPointToMapPosition(Vector2 point)
	{
		Debug.Log("轉換坐標");
		return null;
		//TODO
		//得到屏幕上的點的3D坐標對應的地面坐標點

	}


}
