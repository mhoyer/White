using System;

namespace SilverlightTodo.Models
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        // used for determining items in ItemsControls
        public override string ToString()
        {
            return String.Format("{0} - {1}", Title, Description);
        }
    }
}