using System;
using System.Collections.Generic;
using Assets;
using Assets.Helpers;
using Assets.Models;
using UnityEngine;
using System.Collections;
using Assets.Models.Factories;

public class World : MonoBehaviour
{
    [SerializeField]
    private Settings _settings;
    private TileManager _tileManager;
    private BuildingFactory _buildingFactory;
    private RoadFactory _roadFactory;
    public bool PCtest = false;

    void Start ()
    {   

        _buildingFactory = GetComponentInChildren<BuildingFactory>();
        _roadFactory = GetComponentInChildren<RoadFactory>();
	    
        _tileManager = GetComponent<TileManager>();
        //get gps into settings
        Input.location.Start(10.0f, 5f);
        //record start position
        if (PCtest)
        {
            _settings.Lat = 37.42588f;
            _settings.Long = -122.1443f;
        }
        else
        {
            _settings.Lat = Input.location.lastData.latitude;
            _settings.Long = Input.location.lastData.longitude;
        }

        //lerp player into that place
        //Debug.Log(String.Format("https://api.mapbox.com/v4/mapbox.{5}/{0},{1},{2}/{3}x{3}@2x.png?access_token={4}", _settings.Long, _settings.Lat, 5, 10, "pk.eyJ1IjoiYWVyb2hhbmQiLCJhIjoiY2l6dWQ0dzVrMDByajMycnd0bDFzNXdndCJ9.x4lSZWbrWwUAfsIcS3km7w", "emerald"));
        _tileManager.Init(_buildingFactory, _roadFactory, _settings);

    }

 

    void Update()
    {

    }

    [Serializable]
    public class Settings
    {
        [SerializeField]
        public float Lat = 37.425885f;
        [SerializeField]
        public float Long = -122.144288f;
        [SerializeField]
        public int Range = 3;
        [SerializeField]
        public int DetailLevel = 16;
        [SerializeField]
        public bool LoadImages = false;
    }
}
