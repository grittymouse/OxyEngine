﻿using System;
using OxyEngine.UI.Enums;

namespace OxyEngine.UI.Renderers
{
  public class RootRenderer : Renderer
  {
    private AreaWrapper _areaWrapper;
    private LayoutGraphicsRenderer _horizontalLayoutRenderer;
    private LayoutGraphicsRenderer _verticalLayoutRenderer;
    private FreeGraphicsRenderer _freeGraphicsRenderer;
    
    public RootRenderer(AreaWrapper areaWrapper)
    {
      _areaWrapper = areaWrapper;
      _horizontalLayoutRenderer = new LayoutGraphicsRenderer(areaWrapper);
      _verticalLayoutRenderer = new LayoutGraphicsRenderer(areaWrapper);
      _freeGraphicsRenderer = new FreeGraphicsRenderer(areaWrapper);
    }
    
    public void HorizontalLayout(Action<LayoutGraphicsRenderer> action)
    {
      
    }
    
    public void VerticalLayout(Action<LayoutGraphicsRenderer> action)
    {
      
    }
    
    public void FreeLayout(Action<FreeGraphicsRenderer> action)
    {
      action(_freeGraphicsRenderer);
    }
  }
}