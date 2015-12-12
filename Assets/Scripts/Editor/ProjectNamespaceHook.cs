/*
 * Copyright (c) 2015, Ivan Gadzhega.
 * All rights reserved.
 *
 * This software is the confidential and proprietary information of Ivan Gadzhega.
 * ("Confidential Information"). You shall not disclose such Confidential Information
 * and shall use it only in accordance with the terms of the license agreement
 * you entered into with Ivan Gadzhega.
 */

using SyntaxTree.VisualStudio.Unity.Bridge;
using UnityEditor;

namespace Borodar.LD34.Editor
{
    [InitializeOnLoad]
    public class ProjectNamespaceHook {

        private const string NAMESPACE = "Borodar.LD34";

        static ProjectNamespaceHook()
        {
            ProjectFilesGenerator.ProjectFileGeneration += (string name, string content) =>
                content.Replace("<RootNamespace></RootNamespace>", string.Format("<RootNamespace>{0}</RootNamespace>", NAMESPACE));
        }
    }
}
