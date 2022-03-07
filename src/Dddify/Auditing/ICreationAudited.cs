﻿using System;

namespace Dddify.Auditing
{
    /// <summary>
    /// This interface can be implemented to store creation information (who and when created).
    /// </summary>
    public interface ICreationAudited
    {
        /// <summary>
        /// The creator for this entity.
        /// </summary>
        Guid? CreatedBy { get; set; }

        /// <summary>
        /// The created time for this entity.
        /// </summary>
        DateTimeOffset? CreatedAt { get; set; }
    }
}
