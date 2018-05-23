﻿using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OxyEngine.UI.Enums;
using OxyEngine.UI.Styles;

namespace OxyEngine.UI.Renderers
{
  public class ImageRenderer : Renderer
  {
    public ImageRenderer(AreaStack areaStack, StyleDatabase styles) : base(areaStack, styles)
    {
    }

    public void Render(Texture2D texture = null, Rectangle? rect = null, Rectangle? sourceRect = null, 
      HorizontalAlignment hAlign = HorizontalAlignment.FullWidth, VerticalAlignment vAlign = VerticalAlignment.Stretch)
    {
      
    }
  }
}