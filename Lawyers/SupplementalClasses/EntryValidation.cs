using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lawyers.SupplementalClasses
{
    public class EntryValidation
    {
        List<string> _errorList;
        public EntryValidation()
        {
            _errorList = new List<string>();
        }

        public static bool IsEmpty(string Text)
        {
            if (string.IsNullOrWhiteSpace(Text))
                return false;
            return true;
        }

        public void AddIfEmpty(string Text, string Name)
        {
            try
            {
                if (IsEmpty(Text))
                    _errorList.Add(MissingMessage(Name));
            }
            catch
            {
                throw;
            }
        }

        public bool HasErrors()
        {
            return _errorList.Count > 0 ? true : false;
        }

        public void PrintErrors()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var e in _errorList)
            {
                sb.Append(e).Append("\n");
            }
            MessageBox.Show(sb.ToString());
        }

        private string MissingMessage(string Name)
        {
            return "Please specify " + Name.ToLower();
        }
    }
}
