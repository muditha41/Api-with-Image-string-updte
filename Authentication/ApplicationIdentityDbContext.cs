using App.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Authentication
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserFriends> UserFriends { get; set; }
        public DbSet<UserStatus> UserStatus{ get; set; }
         public DbSet<Status> Status { get; set; }
        public DbSet<UserNotification> UserNotification { get; set; }
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          

            builder.Entity<UserFriends>()
                .HasOne(i=>i.Friend)
                .WithOne(x=>x.Friend)
                .HasForeignKey<UserFriends>(p => p.FriendId)
                .OnDelete(DeleteBehavior.NoAction);
                
            builder.Entity<UserFriends>()
            .HasOne(i => i.User)
            .WithOne(y=>y.User)
            .HasForeignKey<UserFriends>(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserFriends>()
       .HasOne(i => i.UserStatus)
       .WithOne(x => x.UserFriend)
        .HasForeignKey<UserFriends>(p => p.UserStatusId)
       .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<UserStatus>()
            .HasOne(i => i.Status)
            .WithOne(x => x.UserStatus)
            .HasForeignKey<UserStatus>(p => p.StatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<UserStatus>()
          .HasOne(i => i.FriendStatus)
          .WithOne(x => x.FriendStatus)
          .HasForeignKey<UserStatus>(p => p.FriendStatusId)
          .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserNotification>()
           .HasOne(i => i.User)
           .WithOne(x => x.UserNotification)
           .HasForeignKey<UserNotification>(p => p.UserId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserNotification>()
         .HasOne(i => i.Friend)
         .WithOne(x => x.FriendNotification)
         .HasForeignKey<UserNotification>(p => p.FriendId)
         .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
