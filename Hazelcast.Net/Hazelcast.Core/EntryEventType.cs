// Copyright (c) 2008-2020, Hazelcast, Inc. All Rights Reserved.
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

namespace Hazelcast.Core
{
    /// <summary>Type of entry event.</summary>
    /// <remarks>Type of entry event.</remarks>
    [Flags]
    public enum EntryEventType
    {
        Added = 1,
        Removed = 1 << 1,
        Updated = 1 << 2,
        Evicted = 1 << 3,
        Expired = 1 << 4,
        EvictAll = 1 << 5,
        ClearAll = 1 << 6,
        Merged = 1 << 7,
        Invalidation = 1 << 8,
        Loaded = 1 << 9
    }
}