﻿// Copyright (c) 2008-2021, Hazelcast, Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.IO;
using System.Reflection;

namespace Hazelcast.Testing
{
    /// <summary>
    /// Provides access to files in an assembly project.
    /// </summary>
    /// <remarks>
    /// <para>This is similar to using resources, except that the files are not embedded in the assembly
    /// but directly accessed via the filesystem. This means that the test assembly does not need to be
    /// recompiled when the files change, which can simplify and accelerate iterative development.</para>
    /// </remarks>
    public static class TestFiles
    {
        /// <summary>
        /// Opens an assembly project text file, reads all the text in the file, and then closes the file.
        /// </summary>
        /// <typeparam name="T">A type contained by the assembly.</typeparam>
        /// <param name="path">The path of the file relative to the project.</param>
        /// <returns>The text content of the file.</returns>
        public static string ReadAllText<T>(string path)
            => ReadAllText(typeof (T).Assembly, path);

        /// <summary>
        /// Opens an assembly project text file, reads all the text in the file, and then closes the file.
        /// </summary>
        /// <param name="o">An object of a type contained by the assembly.</param>
        /// <param name="path">The path of the file relative to the project.</param>
        /// <returns>The text content of the file.</returns>
        public static string ReadAllText(object o, string path)
            => ReadAllText(o.GetType().Assembly, path);

        /// <summary>
        /// Opens an assembly project text file, reads all the text in the file, and then closes the file.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="path">The path of the file relative to the project.</param>
        /// <returns>The text content of the file.</returns>
        public static string ReadAllText(Assembly assembly, string path)
        {
            var assemblyLocation = Path.GetDirectoryName(Path.GetFullPath(assembly.Location));
            if (assemblyLocation == null) throw new ArgumentException($"Could not locate assembly \"{assembly.FullName}\".");
            var sourceLocation = Path.Combine(assemblyLocation, "../../.."); // bin/<configuration>/<target>
            var resourceLocation = Path.Combine(sourceLocation, "Resources", path);
            var filepath = Path.GetFullPath(resourceLocation);

            try
            {
                return File.ReadAllText(filepath);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"There is no resource corresponding to \"{path}\" at \"{filepath}\".", nameof(path), e);
            }
        }
    }
}
