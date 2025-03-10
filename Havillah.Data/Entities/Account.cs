﻿using Havillah.Data.AggregateRoots;

namespace Havillah.Data.Entities
{
    public class Account : FullAuditedAggregateRoot<int>
    {

        public string Title { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string PasswordHash { get; set; }

        public int? LocationId { get; set; }
       
        public Role Role { get; set; }
        public string? ActivationToken { get; set; }
        public DateTime? Activated { get; set; }
        public bool IsActivated => Activated.HasValue;
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }


        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }

}
