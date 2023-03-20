using Defective.JSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HoldModel
{
    public string type;
    public int rotation;
   public HoldModel(string type, int rotation)
    {
        this.type = type;
        this.rotation = rotation;
    }
}
public class camera : MonoBehaviour
{

    public float camSpeed = -0.5f;
    private float x;
    private float y;
    private Vector3 rotateValue;
    // Start is called before the first frame update
    void Start()
    {
        fakeData();
    }
    void fakeData()
    {
        var jsonTextFile = Resources.Load<TextAsset>("JsonData/route");
        var holdStr = new JSONObject(jsonTextFile.text)["data"]["holds"].ToString();
        var lHoldJson = new JSONObject(holdStr.Replace("\'", "\"").Substring(1, holdStr.Length - 1));
        List<List< HoldModel >> lHold = new List<List<HoldModel>>();
        foreach (JSONObject parent in lHoldJson.list)
        {
            List<HoldModel> lSub = new List<HoldModel>();
            foreach (JSONObject sub in parent.list)
            {
                HoldModel holdModel = new HoldModel(sub["type"].ToString(), int.Parse(sub["rotation"].ToString()));
                lSub.Add(holdModel);
            }
            lHold.Add(lSub);
        }
        Debug.Log("lParent: " + lHold.Count);
    }
    // Update is called once perframe
    void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateValue = new Vector3(y, x * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        transform.eulerAngles += rotateValue * camSpeed;
    }
}

