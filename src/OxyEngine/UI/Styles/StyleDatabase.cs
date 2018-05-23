﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OxyEngine.UI.Styles
{
  public class StyleDatabase
  {
    private Dictionary<string, Style> _database;
    
    // key - child selector, value - parent selector
    // childs "inherit" styles
    private Dictionary<string, string> _childrenToParents;
    
    public StyleDatabase()
    {
      _database = new Dictionary<string, Style>();
      _childrenToParents = new Dictionary<string, string>();
    }

    public StyleDatabase AddStyle(string selector, Style rule)
    {
      if (!IsSimpleSelector(selector))
      {
        throw new Exception("Selector must be simple (simple selectors can't contain spaces)");
      }
      
      _database[selector] = _database.ContainsKey(selector)
        ? Style.Merge(_database[selector], rule)
        : rule;

      return this;
    }

    public Style GetStyle(string selector, bool recalculate = false)
    {
      if (_database.ContainsKey(selector) && !recalculate)
      {
        return _database[selector];
      }
      
      var simpleSelectors = selector.Split(' ');

      var seed = _database[simpleSelectors[0]];
      for (var i = 1; i < simpleSelectors.Length; i++)
      {
        var simpleSelector = simpleSelectors[i];
        seed = Style.Merge(seed, _database[simpleSelector]);
      }
      
      return _database[selector] = seed;
    }
    
    public StyleDatabase SetChildRelation(string child, string parent)
    {
      _childrenToParents[child] = parent;

      return this;
    }
    
    private bool IsSimpleSelector(string selector)
    {
      return !selector.Contains(" ");
    }
  }
}