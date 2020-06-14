using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class TapToPlaceObject : MonoBehaviour
{
    //[RequireComponent(typeof(ARRaycastManager))]
    [Header("想放置的物件")]
    public GameObject tapObject;
    /// <summary>
    /// AR射線碰撞管理器
    /// </summary>
    public ARRaycastManager arRaycast;
    /// <summary>
    /// AR射線碰撞到的物件(集合：清單)
    /// </summary>
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    /// <summary>
    /// 點擊座標
    /// </summary>
    private Vector2 mousePos;

    private void Start()
    {
        arRaycast = GetComponent<ARRaycastManager>(); //取得AR設線管理元件
    }

    /// <summary>
    /// 點擊放置物件
    /// </summary>
    private void TapObject()
    {
        //判斷是否點擊
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition; //儲存點擊座標

            if(arRaycast.Raycast(mousePos,hits,TrackableType.PlaneWithinPolygon)) //AR射線碰撞
            {
                //生成物件在點擊座標
                Pose pose = hits[0].pose;
                GameObject temp = Instantiate(tapObject, pose.position, pose.rotation); //這個是生成物
                Vector3 look = transform.position;
                look.y = temp.transform.position.y;
                temp.transform.LookAt(look);
            }
        }
    }
}
