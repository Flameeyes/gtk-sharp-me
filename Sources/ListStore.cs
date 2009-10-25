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
	public static class ListStoreEx
	{
		public static int RemoveAll(this Gtk.ListStore model, Predicate<object[]> predicate)
		{
			TreeIter iter;
			int count = 0;

			if ( !model.GetIterFirst(out iter) )
				return 0;

			do {
				if ( predicate(model.GetRow(iter)) ) {
				    model.Remove(ref iter);
					count++;
				}
			} while ( model.IterNext(ref iter) );

			return count;
		}
	}
}
