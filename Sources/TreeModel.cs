/*
 * This file is part of GTK# Made Easy library.
 * Copyright © 2009 Diego E. Pettenò <flameeyes@flameeyes.eu>
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
