using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Memento
{
    public class TextEditorHistory
    {
        private List<TextEditorState> _states = [];
        private List<TextEditorState> _undoneStates = [];

        private TextEditor _editor;

        public TextEditorHistory(TextEditor editor)
        {
            _editor = editor;
        }

        public void Backup()
        {
            _states.Add(_editor.MakeSnapshot());
        }

        public void Undo()
        {
            if (_states.Count == 0)
            {
                return;
            }

            TextEditorState prevState = _states[^1];
            _undoneStates.Add(prevState);
            _states.Remove(prevState);
            _editor.Restore(prevState);
        }

        public void Redo()
        {
            if (_undoneStates.Count == 0)
            {
                return;
            }

            TextEditorState undoneState = _undoneStates[^1];
            _states.Add(undoneState);
            _undoneStates.Remove(undoneState);
            _editor.Restore(undoneState);
        }
    }
}
