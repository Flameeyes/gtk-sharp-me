/*
 * This file is part of GTK# Made Easy library.
 * Copyright © 2009 Diego E. Pettenò <flameeyes@gmail.com>
 *
 * GTK# Made Easy is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation, either version 3 of the
 * License, or (at your option) any later version.
 *
 * GTK# Made Easy is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Portability.
 * If not, see <http://www.gnu.org/licenses/>.
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
