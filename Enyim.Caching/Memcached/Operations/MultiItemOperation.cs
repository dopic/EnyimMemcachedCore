using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Enyim.Caching.Memcached.Operations
{
	/// <summary>
	/// Base class for implementing operations working with multiple items.
	/// </summary>
	internal abstract class MultiItemOperation : Operation, IMultiItemOperation
	{
		public MultiItemOperation(IList<string> keys)
		{
			this.Keys = keys;
		}

		public IList<string> Keys { get; private set; }
		IList<string> IMultiItemOperation.Keys { get { return this.Keys; } }
	}

}

#region [ License information          ]
/* ************************************************************
 * 
 *    Copyright (c) 2010 Attila Kisk�, enyim.com
 *    
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *    
 *        http://www.apache.org/licenses/LICENSE-2.0
 *    
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *    
 * ************************************************************/
#endregion
