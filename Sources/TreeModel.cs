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
using Gtk;

namespace GtkSharpME
{
	public static class TreeModel
	{
		public static T GetValueEx<T>(this Gtk.TreeModel model, TreeIter iter, int column)
		{
			GLib.Value val = new GLib.Value();
			model.GetValue(iter, column, ref val);

			return (T)val.Val;
		}

		public static T GetValueEx<T>(this Gtk.TreeModel model, TreeIter? iter, int column)
		{
			if ( !iter.HasValue || iter == null)
				throw new IndexOutOfRangeException("Null TreeIter given");

			return model.GetValueEx<T>(iter.Value, column);
		}

		public static TreeIter? GetIterFirst(this Gtk.TreeModel model)
		{
			TreeIter iter;

			if ( !model.GetIterFirst(out iter) )
				return null;

			return iter;
		}

		public static object[] GetRow(this Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			object[] row = new object[model.NColumns];
			for(int i = 0; i < model.NColumns; i++) {
				row[i] = model.GetValue(iter, i);
			}

			return row;
		}

		public static object[] Find(this Gtk.TreeModel model, Predicate<object[]> predicate)
		{
			Gtk.TreeIter iter;

			if ( !model.GetIterFirst(out iter) )
				return null;

			do {
				object[] row = model.GetRow(iter);
				if ( predicate(row) )
					return row;

			} while ( model.IterNext(ref iter) );

			return null;
		}
	}
}
