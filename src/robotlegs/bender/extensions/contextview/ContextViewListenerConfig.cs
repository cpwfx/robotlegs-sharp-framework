//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using robotlegs.bender.framework.api;
using robotlegs.bender.extensions.viewManager.api;
using robotlegs.bender.extensions.contextview.api;


namespace robotlegs.bender.extensions.contextview
{
	public class ContextViewListenerConfig : IConfig
	{
		[Inject]
		public IContextView contextView {get;set;}
		
		[Inject]
		public IViewManager viewManager {get;set;}

		#region IConfig implementation

		public void Configure ()
		{
			viewManager.AddContainer(contextView.view);
		}

		#endregion
	}
}
