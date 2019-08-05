using Entities;
using System.Collections.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// Inteface for Accessing properties of Labels class.
    /// </summary>
    public interface IKeepLabel
    {
        List<Label> GetLabels();

        void CreateLabel(Label label);

        bool UpdateLabel(int LabelID, Label label);

        bool RemoveLabel(int LabelID);
    }
}
