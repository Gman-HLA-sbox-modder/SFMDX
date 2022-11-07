using System;
using System.Collections.Generic;
using Tools;

// - SFMDX -
// Source Filmmaker in S&box
// Licensed under the MIT License
// 
// Copyright (c) 2022 KiwifruitDev
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace SFMDX;

[Tool( "SFMDX", "movie_filter", "Source Filmmaker: Director's Cut")]
public class EditorWindow : Window
{
    public AnimationSetEditor AnimationSetEditor;
    public ElementViewer ElementViewer;
    public Timeline Timeline;
    public PrimaryViewport PrimaryViewport;
    public SecondaryViewport SecondaryViewport;
	public EditorWindow()
	{
		Title = "Source Filmmaker: Director's Cut";
		Size = new Vector2( 1600, 900 );
        Position = new Vector2( 0, 0 );
		CreateUI();
		Show();
	}

	public void BuildMenu()
	{
		Menu fileMenu = MenuBar.AddMenu( "File" );
		fileMenu.AddOption( "Open" );
		fileMenu.AddOption( "Save" );
		fileMenu.AddOption( "Quit" ).Triggered += () => Close();
        Menu editMenu = MenuBar.AddMenu( "Edit" );
        editMenu.AddOption( "Undo" );
        editMenu.AddOption( "Redo" );
        // Toggle windows
        Menu windowsMenu = MenuBar.AddMenu( "Windows" );
        windowsMenu.AddOption(AnimationSetEditor.GetToggleViewOption());
        windowsMenu.AddOption(ElementViewer.GetToggleViewOption());
        windowsMenu.AddOption(Timeline.GetToggleViewOption());
        windowsMenu.AddOption(PrimaryViewport.GetToggleViewOption());
        windowsMenu.AddOption(SecondaryViewport.GetToggleViewOption());
        Menu viewMenu = MenuBar.AddMenu( "View" );
        viewMenu.AddOption( "TODO" );
        Menu scriptsMenu = MenuBar.AddMenu( "Scripts" );
        scriptsMenu.AddOption( "TODO" );
        Menu helpMenu = MenuBar.AddMenu( "Help" );
        helpMenu.AddOption( "TODO" );
	}

	public void CreateUI()
	{
		Clear();
        AnimationSetEditor = new AnimationSetEditor("Animation Set Editor", "accessibility_new", this, "AnimationSetEditor");
        Dock(AnimationSetEditor, DockArea.Left); // Fill left side
        AnimationSetEditor.Show();
        ElementViewer = new ElementViewer("Element Viewer", "article", this, "ElementViewer");
        Dock(ElementViewer, DockArea.Left); // Fill left side
        ElementViewer.Show();
        Timeline = new Timeline("Timeline", "theaters", this, "Timeline");
        Dock(Timeline, DockArea.Bottom); // Fill bottom
        Timeline.Show();
        PrimaryViewport = new PrimaryViewport("Primary Viewport", "videocam", this, "PrimaryViewport");
        Dock(PrimaryViewport, DockArea.Top); // Fill top
        PrimaryViewport.Show();
        SecondaryViewport = new SecondaryViewport("Secondary Viewport", "videocam", this, "SecondaryViewport");
        Dock(SecondaryViewport, DockArea.Top); // Fill top
        SecondaryViewport.Show();
		BuildMenu();
	}

	[Sandbox.Event.Hotload]
	public void OnHotload()
	{
		CreateUI();
	}
}
