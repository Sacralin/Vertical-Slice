using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NodeAndFlagAssetStateManager
{
    public void ResetAllFlagAssets()
    {
        FlagNodeTools flagNodeTools = new FlagNodeTools();
        List<FlagSO> listofFlagAssets = flagNodeTools.GetAllFlagAssets();
        foreach (FlagSO flagSO in listofFlagAssets)
        {
            foreach (FlagData flagData in flagSO.flagDatas)
            {
                flagData.isFlagEnabled = flagData.flagDefaultState;
            }
        }
    }

    public void ResetAllNodeAssets()
    {
        DialogueSO[] assets = Resources.LoadAll<DialogueSO>("DialogueAssets");
        if (assets.Length != 0)
        {
            foreach (DialogueSO dialogueSO in assets)
            {
                // Reset the currentNode to a new NodeDataSO instance
                dialogueSO.currentNode = new NodeDataSO();
                // Here, you might want to save these changes back to the asset, which isn't
                // possible directly at runtime since changes to scriptable objects in Resources
                // do not persist. Consider a different approach if persistence is needed post-reset.
            }
        }
    }
        
}



