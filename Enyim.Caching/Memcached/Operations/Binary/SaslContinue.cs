using System;
using System.Collections.Generic;
using System.Text;

namespace Enyim.Caching.Memcached.Operations.Binary
{
	/// <summary>
	/// SASL auth step.
	/// </summary>
	internal class SaslContinue : SaslStep
	{
		private byte[] continuation;

		public SaslContinue(ISaslAuthenticationProvider provider, byte[] continuation)
			: base(provider)
		{
			this.continuation = continuation;
		}

		protected internal override IList<ArraySegment<byte>> GetBuffer()
		{
			var request = new BinaryRequest(OpCode.SaslStep)
			{
				Key = this.Provider.Type,
				Data = new ArraySegment<byte>(this.Provider.Continue(this.continuation))
			};

			return request.CreateBuffer();
		}
	}

	internal abstract class SaslStep : Operation
	{
		protected SaslStep(ISaslAuthenticationProvider provider)
		{
			this.Provider = provider;
		}

		protected ISaslAuthenticationProvider Provider { get; private set; }

		protected internal override bool ReadResponse(PooledSocket socket)
		{
			var response = new BinaryResponse();

			var retval = response.Read(socket);

			this.StatusCode = response.StatusCode;
			this.Data = response.Data.Array;

			return retval;
		}

		public int StatusCode { get; private set; }
		public byte[] Data { get; private set; }
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
