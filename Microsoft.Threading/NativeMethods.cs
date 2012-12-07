﻿namespace Microsoft.Threading {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// P/Invoke methods
	/// </summary>
	internal static class NativeMethods {
		/// <summary>
		/// Really truly non pumping wait.
		/// Raw IntPtrs have to be used, because the marshaller does not support arrays of SafeHandle, only
		/// single SafeHandles.
		/// </summary>
		/// <param name="handleCount">The number of handles in the <paramref name="waitHandles"/> array.</param>
		/// <param name="waitHandles">The handles to wait for.</param>
		/// <param name="waitAll">A flag indicating whether all handles must be signaled before returning.</param>
		/// <param name="millisecondsTimeout">A timeout that will cause this method to return.</param>
		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		internal static extern Int32 WaitForMultipleObjects(uint handleCount, IntPtr[] waitHandles, bool waitAll, uint millisecondsTimeout);
	}
}