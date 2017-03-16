using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Helpers;
using UnityEngine;

namespace Assets
{
    public enum RoadType
    {
        Path,
        Rail,
        MinorRoad,
        MajorRoad,
        Highway,
    }

    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    internal class RoadPolygon : MonoBehaviour
    {
        public string Id { get; set; }
        public RoadType Type { get; set; }
        private List<Vector3> _verts;
        
        public void Initialize(string id, Vector3 tile, List<Vector3> verts, string kind)
        {
            Id = id;
            Type = kind.ToRoadType();
            _verts = verts;

            for (int index = 1; index < _verts.Count; index++)
            {

                
                    var roadPlane = Instantiate(Resources.Load<GameObject>("RoadQuad"));
                    roadPlane.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>("Road");
                    roadPlane.transform.position = (tile + verts[index] + tile + verts[index - 1]) / 2;
                    roadPlane.transform.SetParent(transform, true);
                    Vector3 scale = roadPlane.transform.localScale;
                    scale.z = Vector3.Distance(verts[index], verts[index - 1]) / 10;
                    scale.x = 1f;
                    //Debug.Log((float)(int)Type);
                    roadPlane.transform.localScale = scale;
                    roadPlane.transform.LookAt(tile + verts[index - 1]);

                    var roadPlane2 = Instantiate(Resources.Load<GameObject>("RoadQuad"));
                    roadPlane2.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>("Road2");
                    roadPlane2.transform.position = (tile + verts[index] + tile + verts[index - 1]) / 2;
                    roadPlane2.transform.position = new Vector3(roadPlane2.transform.position.x, roadPlane2.transform.position.y + 0.3f, roadPlane2.transform.position.z);

                    roadPlane2.transform.SetParent(transform, true);
                    scale.z = Vector3.Distance(verts[index], verts[index - 1]) / 10;
                    scale.x = 0.8f;
                    roadPlane2.transform.localScale = scale;
                    roadPlane2.transform.LookAt(tile + verts[index - 1]);
                
            }
        }
    }
}
