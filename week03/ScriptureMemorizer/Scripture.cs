using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
    
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] splitWords = text.Split(' ');
            foreach (string wordText in splitWords)
            {
                _words.Add(new Word(wordText));
            }
        }
        public string  GetDisplayText()
        {
            List<string> displayList = new List<string>();
            foreach (Word word in _words)
            {
                displayList.Add(word.GetDisplayText());
            }

            string scriptureText = string.Join(" ", displayList);
            return $"{_reference.GetDisplayText()} - {scriptureText}";
        }
        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();

            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            int actualToHide = Math.Min(numberToHide, visibleWords.Count);

            for (int i = 0; i < actualToHide; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }

        }
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

    }
}