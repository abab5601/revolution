using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transfer : MonoBehaviour {
    [Header("玩家會面向此座標直線前進")]
    public Transform GO;
    public User User;
    public SimpleInput.AxisInput yAxis = new SimpleInput.AxisInput("Vertical");
    public UnityEvent end;
    //public UnityEvent ;
    private void OnEnable()
    {
        yAxis.StartTracking();
    }
    private void OnDisable()
    {
        yAxis.StopTracking();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GO_go_point(other.gameObject.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        yAxis.value = 0;

        end.Invoke();
    }
    #region 傳送動作


    
    public void GO_go_point(Transform go)
    {

        Quaternion rotation = Quaternion.LookRotation(GO.position - go.position, Vector3.zero);
        go.rotation = rotation;
        Quaternion quate = Quaternion.identity;
        quate.eulerAngles = new Vector3(0, go.rotation.y, 0);
        go.rotation = quate;
        go.position = Vector3.MoveTowards(go.position, GO.position, Time.deltaTime * User.ability.mobile * 1.5f);
			yAxis.value = 1;

    }




    #endregion
}
