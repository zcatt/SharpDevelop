﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Linq;
using ResourceEditor.ViewModels;

namespace ResourceEditor.Commands
{
	class AddStringCommand : ResourceItemCommand
	{
		public override void ExecuteWithResourceItems(System.Collections.Generic.IEnumerable<ResourceItem> resourceItems)
		{
//			if(editor.ResourceList.WriteProtected) {
//				return;
//			}
//			
			var editor = ResourceEditor;
			int count = 1;
			string newNameBase = "New string entry ";
			string newName = newNameBase + count;
			
			while (editor.ContainsResourceName(newName)) {
				count++;
				newName = newNameBase + count;
			}
			
			var selectedItem = GetSelectedItems().FirstOrDefault();
			ResourceItem item = new ResourceItem(editor, newName, "");
			item.IsNew = true;
			if (selectedItem != null)
				item.SortingCriteria = selectedItem.Name;
			else
				item.SortingCriteria = item.Name;
			editor.ResourceItems.Add(item);
			editor.SelectedItems.Clear();
			editor.SelectedItems.Add(item);
			editor.StartEditing();
		}
	}
}
