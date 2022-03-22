﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Dddify.Security.Identity
{
    /// <summary>
    /// Represents a service that provides current user information.
    /// </summary>
    public interface ICurrentUser
    {
        ClaimsPrincipal Principal { get; }

        bool IsAuthenticated { get; }

        /// <summary>
        /// Id of the current user. Returns `null`, if the current user has not logged in.
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        /// User name of the current user. Returns `null`, if the current user has not logged in.
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Name of the current user. Returns `null`, if the current user has not logged in.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Email address of the current user.Returns `null`, if the current user has not logged in or not set an email address.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Returns `true`, if the email address of the current user has been verified.
        /// </summary>
        bool EmailVerified { get; }

        /// <summary>
        /// Phone number of the current user. Returns `null`, if the current user has not logged in or not set a phone number.
        /// </summary>
        string PhoneNumber { get; }

        /// <summary>
        /// Returns `true`, if the phone number of the current user has been verified.
        /// </summary>
        bool PhoneNumberVerified { get; }
    }
}
