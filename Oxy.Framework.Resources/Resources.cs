﻿using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using QuickFont;
using QuickFont.Configuration;

namespace Oxy.Framework
{
  /// <summary>
  /// Class for managing game assets
  /// </summary>
  public class Resources : LazyModule<Resources>
  {
    /// <summary>
    /// Loads font from path in library
    /// </summary>
    /// <param name="path">Path in library to font file</param>
    /// <param name="size">Size of the font</param>
    /// <returns>Font object</returns>
    /// <exception cref="FileNotFoundException">Fires when font cannot be found or file do not exists</exception>
    public static QFont LoadFont(string path, float size = 12)
    {
      var fullPath = Path.Combine(Common.GetLibraryRoot(), path);
      
      if (!File.Exists(fullPath))
        throw new FileNotFoundException(path);
      
      return new QFont(fullPath, size, new QFontBuilderConfiguration(false));
    }
  }
}