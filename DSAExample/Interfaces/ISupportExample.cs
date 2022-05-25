// -----------------------------------------------------------------------
//   <copyright file=ISupportExample.cs>
//      Copyright © 2022. All Rights Reserved.
//   </copyright>
// -----------------------------------------------------------------------
//  <Author>Vaibhav Lawand</Author>

namespace DSAExample.Interfaces
{
    public interface ISupportExample
    {
        #region Public Properties

        string Description { get; }

        #endregion Public Properties

        #region Public Methods

        void Run();

        #endregion Public Methods
    }
}