using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Memento
{
    public class TextEditor
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public TextEditorState MakeSnapshot()
        {
            return new TextEditorState(Title, Content);
        }

        public void Restore(TextEditorState state)
        {
            Title = state.GetTitle();
            Content = state.GetContent();
        }
    }
}
