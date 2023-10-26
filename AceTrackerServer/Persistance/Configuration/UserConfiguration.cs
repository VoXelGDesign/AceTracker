using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserId).HasConversion(
            userId => userId.userId,
            value => new UserId(value));

        builder.Property(u => u.UserName).HasConversion(
            userName => userName.Name,
            name => UserName.Create(name)!);

        builder.Property(u => u.UserPassword).HasConversion(
            userPassword => userPassword.HashedPassword,
            hashedPassword => UserPassword.FromHashedPassword(hashedPassword)!);

        builder.HasIndex(u => u.UserName).IsUnique();

    }
}

