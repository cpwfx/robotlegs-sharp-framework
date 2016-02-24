//------------------------------------------------------------------------------
//  Copyright (c) 2014-2016 the original author or authors. All Rights Reserved. 
// 
//  NOTICE: You are permitted to use, modify, and distribute this file 
//  in accordance with the terms of the license agreement accompanying it. 
//------------------------------------------------------------------------------

using Robotlegs.Bender.Extensions.EnhancedLogging.Impl;
using Robotlegs.Bender.Framework.API;

namespace Robotlegs.Bender.Extensions.EnhancedLogging
{
	/// <summary>
	/// This extension logs messages for all Injector actions.
	/// 
	/// Warning: this extension will degrade the performance of your application.
	/// </summary>
	public class InjectorActivityLoggingExtension : IExtension/// 
	{
		/*============================================================================*/
		/* Public Functions                                                           */
		/*============================================================================*/

		public void Extend (IContext context)
		{
			InjectorListener listener = new InjectorListener(
				context.injector, context.GetLogger(this));
//			context.afterDestroying(listener.destroy);
			context.AfterDestroying (listener.Destroy);
		}
	}
}

