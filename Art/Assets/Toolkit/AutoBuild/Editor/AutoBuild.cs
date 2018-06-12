﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using CodeStage.Maintainer;
using CodeStage.Maintainer.Issues;

public static class AutoBuild  {

    [MenuItem("Tools/AutoBuild/BuildPackage")]
    public static void BuildPackage(){

        string[] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            Debug.Log(args[i] +"   "+i);
        }
        string filePath = args[9];
        string mode = args[10];
        if (mode.ToLower()=="debug")
        {
            var records = IssuesFinder.StartSearch(false);
            using (StreamWriter sr = File.CreateText(filePath))
            {
                sr.Write(ReportsBuilder.GenerateReport(IssuesFinder.MODULE_NAME, records));
            }
        }
        lhFramework.Tools.Bundle.BundleBuildManager bundleManager = new lhFramework.Tools.Bundle.BundleBuildManager();
        bundleManager.BuildPackage();
        bundleManager = null;
    }
    [MenuItem("Tools/AutoBuild/BuildSources")]
    public static void BuildSources(){
        string[] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            Debug.Log(args[i] + "   " + i);
        }
        string version = args[9];
        lhFramework.Tools.Bundle.BundleBuildManager bundleManager = new lhFramework.Tools.Bundle.BundleBuildManager();
        bundleManager.BuildPackage();
        bundleManager = null;
    }
}