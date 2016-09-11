using System.Collections.Generic;

namespace RunesDataBase.Controls
{
    public interface IAutocompleteSource<out T>
    {
        IEnumerable<T> GetSuggestionsForInput(string key, int? maxSuggestions = null);
    }
}