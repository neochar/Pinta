// 
// PintaCore.cs
//  
// Author:
//       Jonathan Pobst <monkey@jpobst.com>
// 
// Copyright (c) 2010 Jonathan Pobst
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Gtk;
using Pinta.Resources;

namespace Pinta.Core
{
	public static class PintaCore
	{
		public static SystemManager System { get; private set; }
		public static ActionManager Actions { get; private set; }
		public static WorkspaceManager Workspace { get; private set; }
		public static SettingsManager Settings { get; private set; }
		public static ChromeManager Chrome { get; private set; }
		public static PaletteManager Palette { get; private set; }
		public static PaletteFormatManager PaletteFormats { get; private set; }
		public static LayerManager Layers { get; private set; }

#if false // TODO-GTK4
		public static PaintBrushManager PaintBrushes { get; private set; }
		public static ToolManager Tools { get; private set; }
		public static ResourceManager Resources { get; private set; }
		public static RecentFileManager RecentFiles { get; private set; }
		public static LivePreviewManager LivePreview { get; private set; }
		public static EffectsManager Effects { get; private set; }
		public static ImageConverterManager ImageFormats { get; private set; }
		public static IServiceManager Services { get; }
#endif

		public const string ApplicationVersion = "2.2";

		static PintaCore ()
		{
			System = new SystemManager ();
			Settings = new SettingsManager ();
			Actions = new ActionManager ();
			Workspace = new WorkspaceManager ();
			Layers = new LayerManager ();
			PaletteFormats = new PaletteFormatManager ();
			Palette = new PaletteManager ();
			Chrome = new ChromeManager ();

#if false // TODO-GTK4
			// Resources and Settings are intialized first so later
			// Managers can access them as needed.
			Resources = new ResourceManager ();

			PaintBrushes = new PaintBrushManager ();
			Tools = new ToolManager ();
			ImageFormats = new ImageConverterManager ();
			RecentFiles = new RecentFileManager ();
			LivePreview = new LivePreviewManager ();
			Effects = new EffectsManager ();

			Services = new ServiceManager ();

			Services.AddService<IResourceService> (Resources);
			Services.AddService<ISettingsService> (Settings);
			Services.AddService (Actions);
			Services.AddService<IWorkspaceService> (Workspace);
			Services.AddService (Layers);
			Services.AddService<IPaintBrushService> (PaintBrushes);
			Services.AddService<IToolService> (Tools);
			Services.AddService (ImageFormats);
			Services.AddService (PaletteFormats);
			Services.AddService (System);
			Services.AddService (RecentFiles);
			Services.AddService (LivePreview);
			Services.AddService<IPaletteService> (Palette);
			Services.AddService (Chrome);
			Services.AddService (Effects);
#endif
		}

		public static void Initialize ()
		{
#if false // TODO-GTK4
			Actions.RegisterHandlers ();
#endif
		}
	}
}
