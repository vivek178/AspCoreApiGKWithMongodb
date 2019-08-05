using Entities;
using System.Collections.Generic;

namespace GKBusinessLayer
{
    /// <summary>
    /// Interface for Accessing the properties of Label Class.
    /// </summary>
    public interface IKeepLabelService
    {
        List<Label> GetLabels();

        void CreateLabel(Label label);

        bool UpdateLabel(int LabelID, Label label);

        bool RemoveLabel(int LabelID);
    }
}
