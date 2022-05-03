using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGetKinectHeadsAsTransformMono : MonoBehaviour
{
    public string m_kinectIdName;
    public Transform [] m_headTrackedInKinectRoot;

    public KinectHeads m_toExport;


    private bool isInit;
    public void GetCurrentState(out KinectHeads headsInKinect) {

        RefreshInfo();
        headsInKinect = m_toExport;
    }


    public void SetKinectName(string kinectName) {
        m_kinectIdName = kinectName;
        m_toExport.m_kinectIdName = m_kinectIdName;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (isInit)
            return;
        isInit = true;
        m_toExport.m_kinectIdName = m_kinectIdName;
        m_toExport.m_headTracked = new HeadLocalPosition[m_headTrackedInKinectRoot.Length];
        for (int i = 0; i < m_toExport.m_headTracked.Length; i++)
        {
            m_toExport.m_headTracked[i]= new HeadLocalPosition();
            m_toExport.m_headTracked[i].m_playerIndex = i;
        }
    }

    void Update()
    {
        RefreshInfo();
    }

    private void RefreshInfo()
    {
        for (int i = 0; i < m_headTrackedInKinectRoot.Length; i++)
        {
            m_toExport.m_headTracked[i].m_isTracked = m_headTrackedInKinectRoot[i].gameObject.activeInHierarchy;
            m_toExport.m_headTracked[i].m_localPositionInMeter = m_headTrackedInKinectRoot[i].localPosition;
        }
    }
}


public class JsonKinectHeadsUtility {

    public static void GetAsJson(in KinectHeads source,  out string text)
    {
        text = JsonUtility.ToJson(source);
    }
    public static void SetAsTextAs(in string text, out KinectHeads target)
    {
        target = JsonUtility.FromJson<KinectHeads>(text);
    }
    public static void SetAsTextTo(in string text, ref KinectHeads target)
    {
        KinectHeads fetch = JsonUtility.FromJson<KinectHeads>(text);
        target.m_kinectIdName = fetch.m_kinectIdName;
        target.m_headTracked = fetch.m_headTracked;
    }
}


[System.Serializable]
public class KinectHeads {

    public string m_kinectIdName;
    public HeadLocalPosition[] m_headTracked;
}
[System.Serializable]
public class HeadLocalPosition {
    public bool m_isTracked;
    public int m_playerIndex;
    public Vector3 m_localPositionInMeter;
}