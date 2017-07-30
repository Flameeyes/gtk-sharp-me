/*
 * This file is part of GTK# Made Easy library.
 * Copyright © 2009 Diego E. Pettenò <flameeyes@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 */


using System;
using GLib;

namespace GtkSharpME
{
	public class CellRendererTextDelegate<T>
		: Gtk.CellRendererText
	{
		[Property("object")]
		public T Object
		{ get; set; }

		public delegate void Setup(Gtk.CellRendererText cell, T obj);

		protected Setup my_setup;

		public CellRendererTextDelegate(Setup method)
		{
			my_setup = method;
		}

		public override void GetSize (Gtk.Widget widget, ref Gdk.Rectangle cell_area,
		                              out int x_offset, out int y_offset,
		                              out int width, out int height)
		{
			my_setup(this, Object);

			base.GetSize (widget, ref cell_area,
			              out x_offset, out y_offset,
			              out width, out height);
		}

		protected override void Render (Gdk.Drawable window, Gtk.Widget widget,
		                                Gdk.Rectangle background_area, Gdk.Rectangle cell_area,
		                                Gdk.Rectangle expose_area, Gtk.CellRendererState flags)
		{
			my_setup(this, Object);

			base.Render (window, widget, background_area, cell_area, expose_area, flags);
		}
	}

	public class CellRendererStringify
		: Gtk.CellRendererText
	{
		[Property("object")]
		public object Object
		{ get; set; }

		public override void GetSize (Gtk.Widget widget, ref Gdk.Rectangle cell_area,
		                              out int x_offset, out int y_offset,
		                              out int width, out int height)
		{
			Text = Object.ToString();

			base.GetSize (widget, ref cell_area,
			              out x_offset, out y_offset,
			              out width, out height);
		}

		protected override void Render (Gdk.Drawable window, Gtk.Widget widget,
		                                Gdk.Rectangle background_area, Gdk.Rectangle cell_area,
		                                Gdk.Rectangle expose_area, Gtk.CellRendererState flags)
		{
			Text = Object.ToString();

			base.Render (window, widget, background_area, cell_area, expose_area, flags);
		}
	}
}
