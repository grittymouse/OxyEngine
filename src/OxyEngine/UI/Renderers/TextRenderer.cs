﻿using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OxyEngine.Dependency;
using OxyEngine.Graphics;
using OxyEngine.UI.Enums;
using OxyEngine.UI.Styles;

namespace OxyEngine.UI.Renderers
{
  public class TextRenderer : Renderer
  {
    private Dictionary<(SpriteFont, string, int), string> _wrapCache;
    
    public TextRenderer(AreaStack areaStack, StyleDatabase styles) : base(areaStack, styles)
    {
      _wrapCache = new Dictionary<(SpriteFont, string, int), string>();
    }
    
    public void Render(Rectangle rect, string text, string styleSelector)
    {
      var textStyles = Styles.GetStyle(styleSelector);
      var font = textStyles.GetRule<SpriteFont>("font");
      
      var textColorValue = textStyles.GetRule<Color>("color");
      var backColorValue = textStyles.GetRule<Color>("background-color");
      
      var beforeColor = GraphicsManager.GetColor();
      GraphicsManager.SetColor(backColorValue.R, backColorValue.G, backColorValue.B, backColorValue.A);
      GraphicsManager.Rectangle("fill", rect.X, rect.Y, rect.Width, rect.Height);
      
      var beforeFont = GraphicsManager.GetFont();
      GraphicsManager.SetFont(font);
      GraphicsManager.SetColor(textColorValue.R, textColorValue.G, textColorValue.B, textColorValue.A);

      var finalText = textStyles.GetRule<bool>("text-wrap") 
        ? WrapText(font, text, rect.Width) 
        : text;
      
      var textSize = font.MeasureString(finalText);
      var finalX = 0f;
      var finalY = 0f;
      
      switch (textStyles.GetRule<HorizontalAlignment>("h-align"))
      {
        case HorizontalAlignment.Left:
          finalX = 0;
          break;
        case HorizontalAlignment.Center:
        case HorizontalAlignment.FullWidth:
          finalX = (rect.Size.X - textSize.X) / 2;
          break;
        case HorizontalAlignment.Right:
          finalX = rect.Size.X - textSize.X;
          break;
      }
      
      switch (textStyles.GetRule<VerticalAlignment>("v-align"))
      {
        case VerticalAlignment.Top:
          finalY = 0;
          break;
        case VerticalAlignment.Middle:
        case VerticalAlignment.Stretch:
          finalY = (rect.Size.Y - textSize.Y) / 2;
          break;
        case VerticalAlignment.Bottom:
          finalY = rect.Size.Y - textSize.Y;
          break;
      }
      
      GraphicsManager.DrawCropped(rect, () =>
      {
        GraphicsManager.Print(finalText, rect.X + finalX, rect.Y + finalY);
      });
      
      GraphicsManager.SetFont(beforeFont);
      GraphicsManager.SetColor(beforeColor.R, beforeColor.G, beforeColor.B, beforeColor.A);
    }

    private string WrapText(SpriteFont font, string text, int maxLineWidth)
    {
      var cacheKey = (font, text, maxLineWidth);
      if (_wrapCache.ContainsKey(cacheKey))
      {
        return _wrapCache[cacheKey];
      }
      
      if (font.MeasureString(text).X < maxLineWidth)
      {
        return text;
      }

      var words = text.Split(' ');
      var wrappedText = new StringBuilder();
      var linewidth = 0f;
      var spaceWidth = font.MeasureString(" ").X;
      foreach (var word in words)
      {
        var size = font.MeasureString(word);
        if (linewidth + size.X < maxLineWidth)
        {
          linewidth += size.X + spaceWidth;
        }
        else
        {
          wrappedText.Append("\n");
          linewidth = size.X + spaceWidth;
        }

        wrappedText.Append(word);
        wrappedText.Append(" ");
      }

      _wrapCache[cacheKey] = wrappedText.ToString();
      
      return _wrapCache[cacheKey];
    }
  }
}