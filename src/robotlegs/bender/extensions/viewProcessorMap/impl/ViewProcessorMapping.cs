﻿using System;
using robotlegs.bender.extensions.viewProcessorMap.dsl;
using robotlegs.bender.extensions.matching;

namespace robotlegs.bender.extensions.viewProcessorMap.impl
{
	public class ViewProcessorMapping : IViewProcessorMapping, IViewProcessorMappingConfig
	{
		/*============================================================================*/
		/* Private Properties                                                          */
		/*============================================================================*/

		private ITypeFilter _matcher;
		private object _processor;
		private Type _processorClass;
		private object[] _guards = new object[0];
		private object[] _hooks = new object[0];

		/*============================================================================*/
		/* Public Properties                                                          */
		/*============================================================================*/

		public ITypeFilter Matcher
		{
			get
			{
				return _matcher;
			}
		}

		public object Processor
		{
			get
			{
				return _processor;
			}
			set
			{
				_processor = value;
			}
		}

		public Type ProcessorClass
		{
			get
			{
				return _processorClass;
			}
		}

		public object[] Guards
		{
			get
			{
				return _guards;
			}
		}

		public object[] Hooks
		{
			get
			{
				return _hooks;
			}
		}
		
		/*============================================================================*/
		/* Constructor                                                                */
		/*============================================================================*/

		public ViewProcessorMapping(ITypeFilter matcher, object processor)
		{
			_matcher = matcher;
			SetProcessor(processor);
		}

		/*============================================================================*/
		/* Public Functions                                                           */
		/*============================================================================*/

		public IViewProcessorMappingConfig WithGuards(params object[] guards)
		{
			_guards = ConcatObjectArray(_guards, guards);
			return this;
		}

		public IViewProcessorMappingConfig WithHooks(params object[] hooks)
		{
			_hooks = ConcatObjectArray(_hooks, hooks);
			return this;
		}

		public override String ToString()
		{
			return "Processor " + _processor;
		}

		/*============================================================================*/
		/* Private Functions                                                          */
		/*============================================================================*/

		private void SetProcessor(object processor)
		{
			if (processor is Type)
			{
				_processorClass = processor as Type;
			}
			else
			{
				_processor = processor;
				_processorClass = _processor.GetType();
			}
		}

		private object[] ConcatObjectArray(object[] array1, object[] array2)
		{
			object[] newArray= new object[array1.Length + array2.Length];
			array1.CopyTo (newArray, 0);
			array2.CopyTo(newArray, array1.Length);
			return newArray;
		}
	}
}