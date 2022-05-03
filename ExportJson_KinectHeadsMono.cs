using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportJson_KinectHeadsMono : MonoBehaviour
{

    public Eloi.AbstractMetaAbsolutePathFileMono m_exportPath;
    public AbstractGetKinectHeadsAsTransformMono m_accesskinectInfo;

    [TextArea(0,5)]
    public string m_jsonExported;
    [ContextMenu("Export")]
    public void Export() {

        m_accesskinectInfo.GetCurrentState(out KinectHeads source);
        JsonKinectHeadsUtility.GetAsJson(in source, out  m_jsonExported);
        Eloi.E_FileAndFolderUtility.ExportByOverriding(m_exportPath, m_jsonExported);
    }
}
