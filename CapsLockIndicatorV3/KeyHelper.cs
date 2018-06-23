/*
 * Created 09.07.2017 18:25
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
 */
using System;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
	/// <summary>
	/// A helper class for accessing the state of Caps/Num/Scroll lock
	/// </summary>
	public static class KeyHelper
	{
		/// <summary>
		/// This property indicates if num lock is active.
		/// </summary>
		public static bool isNumlockActive
		{
			get
			{
				return Control.IsKeyLocked(Keys.NumLock);
			}
		}
		
		/// <summary>
		/// This property indicates if caps lock is active.
		/// </summary>
		public static bool isCapslockActive
		{
			get
			{
				return Control.IsKeyLocked(Keys.CapsLock);
			}
		}
		
		/// <summary>
		/// This property indicates if scroll lock is active.
		/// </summary>
		public static bool isScrolllockActive
		{
			get
			{
				return Control.IsKeyLocked(Keys.Scroll);
			}
		}
	}
}
