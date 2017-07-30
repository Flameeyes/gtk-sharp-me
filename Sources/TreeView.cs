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
using Gtk;

namespace GtkSharpME
{
	public static class TreeView
	{
		public static TreeIter? GetSelected(this Gtk.TreeView view)
		{
			TreeIter selected;
			if ( view.Selection.CountSelectedRows() != 1 )
				return null;

			if ( !view.Selection.GetSelected(out selected) )
				return null;

			return selected;
		}
	}
}
