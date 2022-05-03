
using UnityEngine;

public class AbstractSetKinectHeadsAsTransformMono : MonoBehaviour
{
    public Eloi.PrimitiveUnityEvent_String m_kinectName;
    public Transform[] m_headTrackedInKinectRoot;
    public KinectHeads m_currentState;


    public void SetCurrentState(KinectHeads headsInKinect)
    {
        m_currentState= headsInKinect;
        RefreshView();
    }
    public void GetCurrentState(out KinectHeads headsInKinect)
    {

        headsInKinect = m_currentState;
    }

    private void Awake()
    {
        RefreshView();
    }
    public void Update()
    {
        RefreshView();
    }


    private void RefreshView()
    {
        m_kinectName.Invoke(m_currentState.m_kinectIdName);
        for (int i = 0; i < m_headTrackedInKinectRoot.Length; i++)
        {

            if (i < m_currentState.m_headTracked.Length) {

                m_headTrackedInKinectRoot[i].localPosition = m_currentState.m_headTracked[i].m_localPositionInMeter;
                m_headTrackedInKinectRoot[i].gameObject.SetActive(m_currentState.m_headTracked[i].m_isTracked);

            }
            else {

                m_headTrackedInKinectRoot[i].localPosition = Vector3.zero;
                m_headTrackedInKinectRoot[i].gameObject.SetActive(false);
            }

        }
    }
}

