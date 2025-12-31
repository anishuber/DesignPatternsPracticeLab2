using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task2.Memento
{
    public class TextEditor
    {
        public string Title { get; private set; } = String.Empty;
        public string Content { get; private set; } = String.Empty;

        public TextEditor() 
        {
            Title = "Untitled";
            Content = String.Empty;
        }
        public TextEditor(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Content = String.Empty;
        }
        public TextEditor(string title, string content)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public TextEditorState MakeSnapshot()
        {
            return new TextEditorState(Title, Content);
        }

        public void Restore(TextEditorState state)
        {
            Title = state.GetTitle();
            Content = state.GetContent();
        }

        public void Write(string text)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(text);
            Content += text;
        }

        public void Rename(string newName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(newName);
            if (!newName.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("New name can contain only letters or numbers.");
            }

            Title = newName;
        }
    }
}
