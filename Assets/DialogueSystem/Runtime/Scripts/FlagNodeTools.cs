using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlagNodeTools
{
    public List<FlagSO> GetAllFlagAssets()
    {
        List<FlagSO> listOfFlagAssets = new List<FlagSO>();
        FlagSO[] assets = Resources.LoadAll<FlagSO>("FlagAssets");  // find all flag stores in project, returns asset GUIDs
        if (assets.Length != 0)
        {
            foreach (FlagSO asset in assets)
            {
                listOfFlagAssets.Add(asset);
            }

        }
        return listOfFlagAssets;
    }

    public List<string> GetNamesOfFlagAssets(List<FlagSO> listOfFlagAssets)
    {
        List<string> listOfAssetNames = new List<string>();
        if (listOfFlagAssets.Count != 0)
        {
            foreach (FlagSO flagSO in listOfFlagAssets)
            {
                listOfAssetNames.Add(flagSO.name);
            }
        }
        else { listOfAssetNames.Add("No Flag Assets Found!"); } //set default
        return listOfAssetNames;
    }

    public List<string> GetSelectedObjectFlagsList(List<FlagSO> listOfFlagAssets, string selectedFlagSO)
    {
        List<string> listOfFlagNames = new List<string>();
        if (selectedFlagSO != "No Flag Assets Found!")
        {
            foreach (FlagSO flagSO in listOfFlagAssets)
            {
                if (flagSO.name == selectedFlagSO)
                {
                    foreach (FlagData flagData in flagSO.flagDatas)
                    {
                        listOfFlagNames.Add(flagData.flagName);
                    }

                }
            }
        }
        return listOfFlagNames;
    }

    public FlagSO GetFlagSO(List<FlagSO> listOfFlagAssets, string flagSOName)
    {
        foreach(FlagSO flagSO in listOfFlagAssets)
        {
            if(flagSO.name == flagSOName)
            {
                return flagSO;
            }
        }
        return null;
    }
    public List<string> SetTriggerValue(string selectedFlag)
    {
        if (!string.IsNullOrEmpty(selectedFlag))
        {
            List<string> choices = new List<string> { "True", "False" };
            return choices;
        }
        else
        {
            return null;
        }
    }


}
