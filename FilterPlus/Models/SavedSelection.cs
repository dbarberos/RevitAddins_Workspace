using System.Collections.Generic;

namespace FilterPlus.Models
{
    public class SavedSelection
    {
        public string Name { get; set; }
        public List<SavedElementKey> Elements { get; set; } = new List<SavedElementKey>();
        public List<string> ActiveModelInstanceNames { get; set; } = new List<string>();
    }

    public class SavedElementKey
    {
        public int ElementIdValue { get; set; }
        public int LinkInstanceIdValue { get; set; } // -1 if host model, otherwise link instance ID in host
    }
}
