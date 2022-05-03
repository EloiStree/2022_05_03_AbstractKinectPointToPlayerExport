using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportJson_ToKinectHeadsMono : MonoBehaviour
{

    public Eloi.AbstractMetaAbsolutePathFileMono m_importFilePath;
    public AbstractSetKinectHeadsAsTransformMono m_accesskinectInfo;

    [TextArea(0, 5)]
    public string m_jsonExported;
    public KinectHeads m_importedHeads;
    [ContextMenu("Import")]
    public void Import()
    {

        try
        {
            Eloi.E_FileAndFolderUtility.ImportFileAsText(m_importFilePath, out m_jsonExported);
            JsonKinectHeadsUtility.SetAsTextAs(in m_jsonExported, out m_importedHeads);
            m_accesskinectInfo.SetCurrentState(m_importedHeads);
        }
        catch (Exception) {
            Debug.Log("Fail to load", this.gameObject);
        }
    }
}
