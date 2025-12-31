using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Memento
{
    public class TextEditorState
    {
        private readonly string _title;
        private readonly string _content;

        public TextEditorState(string title, string content)
        {
            _title = title;
            _content = content;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetContent()
        {
            return _content;
        }
    }
}
