using System;
using System.Text.Json.Nodes;

namespace FinalProject
{
    internal abstract class Recipe
    {
        public abstract string Type { get; }
        public string Category { get; set; }
        public string Group { get; set; }
        public int ResultAmount { get; set; } = 1;
        public Item ResultItem { get; set; }
        
        protected Recipe (Item resultItem, int resultAmount)
        {
            ResultAmount = resultAmount;
            ResultItem = resultItem;
        }

        public abstract string GetJsonString();
    }
}